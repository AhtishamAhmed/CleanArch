using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GetStudentsDTO : IRequest<ApiResponse<IEnumerable<Student>>>
    {
    }
}
