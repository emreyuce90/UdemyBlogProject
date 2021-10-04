using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.DTO.DTOs.BlogCategoryDtos;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.BusinessLayer.Concrete
{
    public class BlogManager:GenericManager<Blog>,IBlogService
    {
        private readonly IGenericDal<Blog> _genericDal;
        //Bloğu kategoriye ekleyeceğimiz için aslında BlogCategory tablosuna kayıt yapacağız
        private readonly IGenericDal<BlogCategory> _blogCategoryDal;
        public BlogManager(IGenericDal<Blog> genericDal,IGenericDal<BlogCategory> blogCategoryDal) :base(genericDal)
        {
            _genericDal = genericDal;
            _blogCategoryDal = blogCategoryDal;
        }

        public async Task AddCategoryToBlogsAsync(BlogCategoryDto blogCategoryDto)
        {
            var control = await _blogCategoryDal.GetAsync(I => I.BlogId == blogCategoryDto.BlogId && I.CategoryId == blogCategoryDto.CategoryId);

            if (control == null)
            {
                await _blogCategoryDal.AddAsync(new BlogCategory { BlogId = blogCategoryDto.BlogId, CategoryId = blogCategoryDto.CategoryId });
            }
        }

        public  async Task DeleteCategoryFromBlog(BlogCategoryDto blogCategoryDto)
        {
            //Sana gelen id den bloğu bul
            var blog = await _blogCategoryDal.GetAsync(I => I.BlogId == blogCategoryDto.BlogId && I.CategoryId == blogCategoryDto.CategoryId);
            if (blog!=null)
            {
                await _blogCategoryDal.RemoveAsync(new BlogCategory { BlogId=blogCategoryDto.BlogId,CategoryId = blogCategoryDto.CategoryId});
            }
        }

        public async Task<List<Blog>> GetAllSortedByPostedTimeAsync()
        {
           return await _genericDal.GetAllAsync(I => I.ReleaseDate);
        }
    }
}
