using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.DTO.DTOs.CategoryDtos;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.BusinessLayer.Interfaces
{
    public interface ICategoryService:IGenericService<Category>
    {
        Task<List<Category>> GetAllSortByIdAsync();

        Task<List<Category>> GetCategoryWithBlogsAsync();

    }
}
