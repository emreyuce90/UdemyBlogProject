using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DTO.Interfaces;

namespace UdemyBlogProject.DTO.DTOs.BlogCategoryDtos
{
    public class BlogCategoryDto:IDto
    {
        public int BlogId { get; set; }
        public int CategoryId { get; set; }

    }
}
