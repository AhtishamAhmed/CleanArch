using Application.DTOs;
using Application.Wrappers;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<ApiResponse<AuthenticationResponseDTO>> Authenticate(AuthenticationRequestDTO request);
        Task<ApiResponse<Guid>> RegisterUser(RegisterRequestDTO registerRequest);
    }   
}