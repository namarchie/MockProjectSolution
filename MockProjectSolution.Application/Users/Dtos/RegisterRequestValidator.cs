using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Application.Users.Dtos
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName khong duoc de trong")
                .MaximumLength(50).WithMessage("FirstName khong duoc qua 50 ki tu");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName khong duoc de trong")
                .MaximumLength(50).WithMessage("LastName khong duoc qua 50 ki tu");
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Ngay sinh khong duoc qua 100 nam");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email khong duoc de trong")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Dinh dang email chua dung");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("SDT khong duoc de trong");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Ban chua nhap username");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Ban chua nhap password")
                .MinimumLength(6).WithMessage("Password phai co it nhat 6 ki tu");
            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Mat khau phai giong nhau");
                }
            });
        }
    }
}
