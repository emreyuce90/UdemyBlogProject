using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.Entities.Interface;

namespace UdemyBlogProject.Entities.Concrete
{
   public  class Comment:ITable
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }

        public string Description { get; set; }
        public DateTime ReleseDate { get; set; }

    }
}
