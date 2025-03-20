using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentDTO, ApiResponse<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthencateUser _authencateUser;

        public CreateStudentCommandHandler(IApplicationDbContext context, IMapper mapper,IAuthencateUser authencateUser)
        {
            _context = context;
            _mapper = mapper;
            _authencateUser = authencateUser;
        }


        public async Task<ApiResponse<bool>> Handle(CreateStudentDTO request, CancellationToken cancellationToken)
        {
            //var student = new Student();
            //student.Name = request.Name;
            //student.Email = request.Email;
            //student.Password = request.Password;
            
            var student = _mapper.Map<Student>(request);
            student.Id = Guid.NewGuid();
            student.CreatedBy = _authencateUser.UserId;

            await _context.students_tbl.AddAsync(student);
            await _context.SaveChangesAsync();
            return new ApiResponse<bool>(true, "Student add successfully") ;
        }
    } 
}