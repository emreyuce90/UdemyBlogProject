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
        public DateTime ReleaseDate { get; set; }

    }
}
