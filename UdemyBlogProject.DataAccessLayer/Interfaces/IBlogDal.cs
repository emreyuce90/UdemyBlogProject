using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DataAccessLayer.Interfaces
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        Task<List<Blog>> GetAllWithCategoryIdAsync(int categoryId);

        Task<List<Blog>> GetFiveBlogsAsync();

        Task<List<Blog>> SearchBlogsAsync(string searchString);

        
    }
}
