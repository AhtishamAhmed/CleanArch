using Application.Interfaces;
using System.Security.Claims;

namespace WebApi.SharedServices
{
    public class AuthencateUser : IAuthencateUser
    {
        public AuthencateUser(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext.User.FindFirstValue("uid");
        }
        public string UserId { get; set; }
    }
}
