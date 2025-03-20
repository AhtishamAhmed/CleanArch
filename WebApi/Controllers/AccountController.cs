using Application.DTOs;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAccountService _accountService;

        public AccountController(IMediator mediator, IAccountService accountService)
        {
            _mediator = mediator;
           _accountService = accountService;
        }

        [HttpPost()]
        public async Task<IActionResult> Authentication(AuthenticationRequestDTO request, CancellationToken cancellation)
        {
            var result = await _accountService.Authenticate(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterRequestDTO request, CancellationToken cancellation)
         {
            var result = await _accountService.RegisterUser(request);
            return Ok(result);
        }

        //[HttpPost]
        //public async Task<IActionResult> Authentication(AuthenticationRequest request, CancellationToken cancellation)
        //{
        //    var result = await _accountService.RegisterUser(request);
        //    return Ok(result);
        //}
    }
}
