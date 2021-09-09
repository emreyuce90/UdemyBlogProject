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


        //Her bir yorumun alt yorumları olabilir
        //Hangi yoruma yorum yapıldığını anlamak için parentcommentid kullanılır
        //parentcomment id nullable dır eğer boş ise yorum bloğa yapılmıştır eğer id var ise
        //yorum yoruma yapılmıştır.
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public List<Comment> SubComments { get; set; }

    }
}
