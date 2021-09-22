using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.BusinessLayer.Interfaces
{
    public interface IBlogService : IGenericService<Blog>
    {
        Task<List<Blog>> GetAllSortedByPostedTimeAsync();
    }
}
