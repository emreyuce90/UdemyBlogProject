using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.DTO.DTOs.CategoryDtos;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDal
    {
        public async Task<List<Category>> GetCategoriesByBlogIdAsync(int id)
        {
            //blogid den bloğa ait kategorileri getir
            //blog -blogcategory -category
            //blogcategory ile category tablolarını joinleyip blogid ile filtreleme yapalım
            using var context = new UdemyBlogContext();
           return await context.Categories.Join(context.BlogCategories, c => c.Id, bc => bc.CategoryId, (category, blogcategory) => new
            {
                category = category,
                blogcategory = blogcategory
            }
             ).Where(I => I.blogcategory.BlogId == id).Select(I => new Category
             {
                 Id = I.category.Id,
                 Name = I.category.Name
             }).ToListAsync();
            
        }

        public async Task<List<Category>> GetCategoryWithBlogsAsync()
        {
            using var context = new UdemyBlogContext();
            return await context.Categories.Include(I => I.BlogCategories).ToListAsync();
        }
    }
}
