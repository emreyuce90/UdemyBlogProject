using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.BusinessLayer.Concrete
{
    public class BlogManager:GenericManager<Blog>,IBlogService
    {
        private readonly IGenericDal<Blog> _genericDal;
        public BlogManager(IGenericDal<Blog> genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
