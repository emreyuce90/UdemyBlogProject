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
        public async Task<List<Category>> GetCategoryWithBlogsAsync()
        {
            using var context = new UdemyBlogContext();
            return await context.Categories.Include(I => I.BlogCategories).ToListAsync();
        }
    }
}
