using Application.DTOs;
using Application.Enums;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PersistanceLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceLayer.Seeds.SharedServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _confiquration;

        public AccountService(UserManager<ApplicationUser> userManager, IConfiguration confiquration)
        {
            _userManager = userManager;
            _confiquration = confiquration;
        }

        public async Task<ApiResponse<AuthenticationResponseDTO>> Authenticate(AuthenticationRequestDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user == null)
            {
                throw new ApiException($"User not registered with this {request.Email}");
            }
            var succeeded = await _userManager.CheckPasswordAsync(user, request.Password);
            if(!succeeded)
            {
                throw new ApiException($"Email or Password is not correct");
            }
            var jwtSecurity = await GenereateTokenAsync(user);
            var authenticationResponse = new AuthenticationResponseDTO();
            authenticationResponse.Id = user.Id;
            authenticationResponse.UserName = user.UserName;
            authenticationResponse.Email = user.Email;
            authenticationResponse.IsVerified = user.EmailConfirmed;
            
            var roles = await _userManager.GetRolesAsync(user);
            authenticationResponse.Roles = roles.ToList();

            authenticationResponse.JWTToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurity);

            return new ApiResponse<AuthenticationResponseDTO>(authenticationResponse, "Authenticated User");
        }

        private async Task<JwtSecurityToken> GenereateTokenAsync(ApplicationUser user)
        {
            var dbClaim = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            //string ipAddress = "192.33.123";

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id.ToString()),
            }   
            .Union(dbClaim)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confiquration["JwtSettings:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _confiquration["JwtSettings:Issuer"],
                audience: _confiquration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_confiquration["JwtSettings:DurationInMinutes"])),
                signingCredentials: signingCredentials
            );
            return jwtSecurityToken;
        }

        public async Task<ApiResponse<Guid>> RegisterUser(RegisterRequestDTO registerRequest)
        {
            var user = await _userManager.FindByEmailAsync(registerRequest.Email);
            if(user != null)
            { 
                throw new ApiException($"user already taken {registerRequest.Email}");
            }

            var userModel = new ApplicationUser();
            userModel.UserName = registerRequest.Username;
            userModel.Email = registerRequest.Email;
            userModel.FirstName = registerRequest.FirstName;
            userModel.LastName = registerRequest.LastName;
            userModel.Gender = registerRequest.Gender;
            userModel.EmailConfirmed = true;
            userModel.PhoneNumberConfirmed = true;

            var result = await _userManager.CreateAsync(userModel, registerRequest.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userModel, Roles.Basic.ToString());
                return new ApiResponse<Guid>(userModel.Id, "User Register Successfully");
            }
            else
            {
                throw new ApiException(result.Errors.ToString());
            }
        }
    }
}       