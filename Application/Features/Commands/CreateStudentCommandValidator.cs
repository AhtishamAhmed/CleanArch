using Application.DTOs;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentDTO>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name Is Required");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email Is Required");
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password Is Required");
        }
    }
}