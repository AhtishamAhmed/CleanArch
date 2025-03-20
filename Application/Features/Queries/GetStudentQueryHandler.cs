using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentDTO, ApiResponse<Student>>
    {
        private readonly IApplicationDbContext _context;

        public GetStudentQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<Student>> Handle(GetStudentDTO request, CancellationToken cancellationToken)
        {
            var student = await _context.students_tbl.FindAsync(request.Id);
            if(student is null)
            {
                throw new ApiException("Student Not Found");
            }
            return new ApiResponse<Student>(student, "Data fetch successfully");
        }
    }
}
