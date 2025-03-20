using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateStudentDTO : IRequest<ApiResponse<bool>>
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; } 
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}