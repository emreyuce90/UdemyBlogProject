using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.DTO.DTOs.BlogCategoryDtos;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.BusinessLayer.Interfaces
{
    public interface IBlogService : IGenericService<Blog>
    {
        Task<List<Blog>> GetAllSortedByPostedTimeAsync();
        Task AddCategoryToBlogsAsync(BlogCategoryDto blogCategoryDto);

        Task DeleteCategoryFromBlog(BlogCategoryDto blogCategoryDto);

        Task<List<Blog>> GetAllWithCategoryIdAsync(int categoryId);

        Task<List<Blog>> GetFiveBlogsAsync();

    }
}
