using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DTO.DTOs.CategoryDtos;

namespace UdemyBlogProject.BusinessLayer.ValidationRules.FluentValidation
{
   public class CategoryAddValidator:AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Kategori adı alanı boş geçilemez");
        }
    }
}
