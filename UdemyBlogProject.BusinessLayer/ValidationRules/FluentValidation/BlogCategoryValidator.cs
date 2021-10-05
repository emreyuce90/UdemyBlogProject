using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DTO.DTOs.BlogCategoryDtos;

namespace UdemyBlogProject.BusinessLayer.ValidationRules.FluentValidation
{
    public class BlogCategoryValidator:AbstractValidator<BlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(I => I.BlogId).ExclusiveBetween(0, int.MaxValue).WithMessage("Blog id boş geçilemez");
            RuleFor(I => I.CategoryId).ExclusiveBetween(0, int.MaxValue).WithMessage("Category id boş geçilemez");

        }
    }
}
