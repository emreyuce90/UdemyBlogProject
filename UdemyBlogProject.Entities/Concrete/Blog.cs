using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.Entities.Interface;

namespace UdemyBlogProject.Entities.Concrete
{
    public class Blog:ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string ImagePath { get; set; }
        //Bloğu yazan kullanıcı
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        //Bloğun kategorileri

        public List<BlogCategory> BlogCategories { get; set; }

        //Bloğun yorumları olacak
        public List<Comment> Comments { get; set; }


    }
}
