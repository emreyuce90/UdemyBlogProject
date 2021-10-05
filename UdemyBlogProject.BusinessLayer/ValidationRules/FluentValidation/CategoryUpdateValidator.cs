using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DTO.DTOs.CategoryDtos;

namespace UdemyBlogProject.BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(I=>I.Id).InclusiveBetween(0,int.MaxValue).WithMessage("Kategori Id alanı boş geçilemez");
            RuleFor(I => I.Name).NotEmpty().WithMessage("Kategori adı alanı boş geçilemez");
        }
    }
}
