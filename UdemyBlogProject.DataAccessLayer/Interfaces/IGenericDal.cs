using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.Entities.Interface;

namespace UdemyBlogProject.DataAccessLayer.Interfaces
{
    public interface IGenericDal<Tentity> where Tentity :class, ITable,new()
    {
        Task<List<Tentity>> GetAllAsync();
        Task<List<Tentity>> GetAllAsync(Expression<Func<Tentity,bool>> filter);
        Task<Tentity> GetAsync(Expression<Func<Tentity,bool>> filter);

        Task AddAsync(Tentity tentity);
        Task UpdateAsync(Tentity tentity);
        Task RemoveAsync(Tentity tentity);

    }
}
