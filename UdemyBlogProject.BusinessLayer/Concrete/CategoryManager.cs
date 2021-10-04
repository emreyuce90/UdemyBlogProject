using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.DTO.DTOs.CategoryDtos;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.BusinessLayer.Concrete
{
   public class CategoryManager:GenericManager<Category>,ICategoryService
    {
        private readonly IGenericDal<Category> _genericDal;
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(IGenericDal<Category> genericDal, ICategoryDal categoryDal) :base(genericDal)
        {
            _genericDal = genericDal;
            _categoryDal = categoryDal;
        }



        public async Task<List<Category>> GetAllSortByIdAsync()
        {
           return await  _genericDal.GetAllAsync(I => I.Id);
        }

        public async Task<List<Category>> GetCategoryWithBlogsAsync()
        {
            return await _categoryDal.GetCategoryWithBlogsAsync();
        }
    }
}
