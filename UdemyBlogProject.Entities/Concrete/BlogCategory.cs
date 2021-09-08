using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.Entities.Interface;

namespace UdemyBlogProject.Entities.Concrete
{
    public class BlogCategory:ITable
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BlogId { get; set; }


    }
}
