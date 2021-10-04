using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DTO.Interfaces;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DTO.DTOs.CategoryDtos
{
    public class CategoryBlogListDto : IDto
    {
        public Category Categories { get; set; }
        public int BlogCount { get; set; }
    }
}
