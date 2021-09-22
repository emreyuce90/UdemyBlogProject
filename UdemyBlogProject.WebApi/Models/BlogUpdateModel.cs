using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyBlogProject.WebApi.Models
{
    public class BlogUpdateModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public string ImagePath { get; set; }
        //Bloğu yazan kullanıcı
        public int AppUserId { get; set; }
    }
}
