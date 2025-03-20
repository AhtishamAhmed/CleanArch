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
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsDTO, ApiResponse<IEnumerable<Student>>>
    {
        private readonly IApplicationDbContext _context;

        public GetStudentsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<IEnumerable<Student>>> Handle(GetStudentsDTO request, CancellationToken cancellation)
        {
            var students = await _context.students_tbl.ToListAsync(cancellation);
            if(students is null)
            {
                throw new ApiException("Students Not Found");
            }
            return new ApiResponse<IEnumerable<Student>>(students, "Data fetch successfully");
        }
    }
}