using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentDTO, ApiResponse<bool>>
    {
        private readonly IApplicationDbContext _context;

        public RemoveStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<bool>> Handle(RemoveStudentDTO request, CancellationToken cancellationToken)
        {
            var student = await _context.students_tbl.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(student is null)
            {
                return new ApiResponse<bool>(false, "Student Not Found");
            }

            _context.students_tbl.Remove(student);
            await _context.SaveChangesAsync();
            return new ApiResponse<bool>(true, "Deleted successfully");
        }
    }
}