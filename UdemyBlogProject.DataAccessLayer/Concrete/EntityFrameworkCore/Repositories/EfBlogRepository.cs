using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.DTO.DTOs.BlogDtos;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBlogRepository : EfGenericRepository<Blog>, IBlogDal
    {
        public async Task<List<Blog>> GetAllWithCategoryIdAsync(int categoryId)
        {
            using var context = new UdemyBlogContext();
            return await context.Blogs.Join(context.BlogCategories, b => b.Id, bc => bc.BlogId, (blog, categoryBlog) => new
            {
                blog = blog,
                categoryBlog = categoryBlog

            }).Where(I => I.categoryBlog.CategoryId == categoryId)
            .Select(I => new Blog
            {
                Description = I.blog.Description,
                Id = I.blog.Id,
                ImagePath = I.blog.ImagePath,
                ReleaseDate = I.blog.ReleaseDate,
                ShortDescription = I.blog.ShortDescription,
                Title = I.blog.ShortDescription,


            }).ToListAsync();
        }

        public async Task<List<Blog>> GetFiveBlogsAsync()
        {
            using var context = new UdemyBlogContext();
            return await context.Blogs.OrderByDescending(I => I.ReleaseDate).Take(5).ToListAsync();
        }

        public Task<List<Blog>> SearchBlogsAsync(string searchString)
        {
            var context = new UdemyBlogContext();
            return context.Blogs.Where(I => I.Description.Contains(searchString)).ToListAsync();
        }
    }
}
