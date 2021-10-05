using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DTO.DTOs.AppUserDtos;

namespace UdemyBlogProject.BusinessLayer.ValidationRules
{
    public class AppUserLoginValidator:AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez");
        }
    }
}
