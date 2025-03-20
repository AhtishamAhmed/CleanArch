using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var result = await _mediator.Send(new GetStudentsDTO());
            return Ok(result);
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> GetStudentById(GetStudentDTO student, CancellationToken cancellation)
        {
            var result = await _mediator.Send(student, cancellation);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(CreateStudentDTO student, CancellationToken cancellation)
        {
            var result = await _mediator.Send(student, cancellation);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(RemoveStudentDTO student, CancellationToken cancellation)
        {
            var result = await _mediator.Send(student, cancellation);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentDTO student, CancellationToken cancellation)
        {
            var result = await _mediator.Send(student, cancellation);
            return Ok(result);
        } 
    }
}