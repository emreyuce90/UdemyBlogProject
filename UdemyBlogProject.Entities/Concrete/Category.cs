using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.Entities.Interface;

namespace UdemyBlogProject.Entities.Concrete
{
    public class Category:ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BlogCategory> BlogCategories { get; set; }

    }
}
