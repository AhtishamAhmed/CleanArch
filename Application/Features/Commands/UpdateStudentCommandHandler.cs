using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentDTO, ApiResponse<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthencateUser _authencateUser;

        public UpdateStudentCommandHandler(IApplicationDbContext context, IMapper mapper, IAuthencateUser authencateUser)
        {
            _context = context;
            _mapper = mapper;
            _authencateUser = authencateUser;
        }
        public async Task<ApiResponse<bool>> Handle(UpdateStudentDTO request, CancellationToken cancellationToken)
        {
            var student = await _context.students_tbl.FirstOrDefaultAsync(x => x.Id == request.Id);

            //student.Name = request.Name;
            //student.Email = request.Email;
            //student.Password = request.Password;
            student.ModifiedBy = _authencateUser.UserId;
            student.ModifiedOn = DateTime.Now;
            _mapper.Map(request, student);
            return new ApiResponse<bool>(true, "Updated Data Successfully") ;
        }
    }
}