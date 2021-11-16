using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        private readonly IBlogDal _blogDal;
        private readonly IGenericDal<Blog> _genericDal;
        //Bloğu kategoriye ekleyeceğimiz için aslında BlogCategory tablosuna kayıt yapacağız
        private readonly IGenericDal<BlogCategory> _blogCategoryDal;
        public BlogManager(IGenericDal<Blog> genericDal,IGenericDal<BlogCategory> blogCategoryDal, IBlogDal blogDal) :base(genericDal)
        {
            _genericDal = genericDal;
            _blogCategoryDal = blogCategoryDal;
            _blogDal = blogDal;
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
                await _blogCategoryDal.RemoveAsync(blog);
            }
        }

        public async Task<List<Blog>> GetAllSortedByPostedTimeAsync()
        {
           return await _genericDal.GetAllAsync(I => I.ReleaseDate);
        }

        public async Task<List<Blog>> GetAllWithCategoryIdAsync(int categoryId)
        {
            return await _blogDal.GetAllWithCategoryIdAsync(categoryId);
        }

        public async Task<List<Blog>> GetFiveBlogsAsync()
        {
           return await _blogDal.GetFiveBlogsAsync();
        }

        public async Task<List<Blog>> SearchBlogsAsync(string searchString)
        {
            return await _blogDal.SearchBlogsAsync(searchString);
        }
    }
}
