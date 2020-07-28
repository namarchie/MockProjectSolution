using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Application.Users.Dtos
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Ban chua nhap username");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Ban chua nhap password")
                .MinimumLength(6).WithMessage("Password phai co it nhat 6 ki tu");

        }
    }
}
