using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.BusinessLayer.Concrete
{
    public class CommentManager:GenericManager<Comment>,ICommentService
    {
        private readonly IGenericDal<Comment> _genericDal;
        public CommentManager(IGenericDal<Comment> genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
