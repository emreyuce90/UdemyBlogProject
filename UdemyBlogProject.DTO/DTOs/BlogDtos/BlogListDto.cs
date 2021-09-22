using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DTO.Interfaces;

namespace UdemyBlogProject.DTO.DTOs.BlogDtos
{
    public class BlogListDto:IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string ImagePath { get; set; }
    }
}
