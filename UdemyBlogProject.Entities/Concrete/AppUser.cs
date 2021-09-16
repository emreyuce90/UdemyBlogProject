using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.Entities.Interface;

namespace UdemyBlogProject.Entities.Concrete
{
   public class AppUser:ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }

        public List<Blog> Blogs { get; set; }

    }
}
