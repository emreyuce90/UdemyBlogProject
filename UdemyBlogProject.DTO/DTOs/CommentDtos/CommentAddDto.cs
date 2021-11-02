using System;
using UdemyBlogProject.DTO.Interfaces;

namespace UdemyBlogProject.DTO
{
    public class CommentAddDto
    {

        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Description { get; set; }
        public DateTime ReleseDate { get; set; }
        public int? ParentCommentId { get; set; }
        public int BlogId { get; set; }



    }

}
