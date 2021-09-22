using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<List<Blog>> GetAllSortedByPostedTimeAsync()
        {
           return await _genericDal.GetAllAsync(I => I.ReleaseDate);
        }
    }
}
