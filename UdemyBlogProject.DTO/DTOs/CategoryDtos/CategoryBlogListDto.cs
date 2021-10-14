using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DTO.Interfaces;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DTO.DTOs.CategoryDtos
{
    public class CategoryBlogListDto : IDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int BlogCount { get; set; }
    }
}
