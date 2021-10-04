using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.DTO.DTOs.CategoryDtos;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DataAccessLayer.Interfaces
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        Task<List<Category>> GetCategoryWithBlogsAsync();
    }
}
