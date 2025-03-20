using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RemoveStudentDTO : IRequest<ApiResponse<bool>>
    {
        public Guid Id { get; set; }
    }
}
