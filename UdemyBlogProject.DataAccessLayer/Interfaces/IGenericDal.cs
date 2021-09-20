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
        //Standart filtresiz sorted metodu
        Task<List<Tentity>> GetAllAsync<Tkey>(Expression<Func<Tentity,Tkey>> keySelector);

        //Hem fltreli hem sorted metodu
        Task<List<Tentity>> GetAllAsync<Tkey>(Expression<Func<Tentity,bool>> filter,Expression<Func<Tentity,Tkey>> keySelector);

        Task<Tentity> GetAsync(Expression<Func<Tentity,bool>> filter);

        Task<Tentity> GetByIdAsync(int id);

        Task AddAsync(Tentity tentity);
        Task AddRangeAsync(List<Tentity> tentities);
        Task UpdateAsync(Tentity tentity);
        Task RemoveAsync(Tentity tentity);

        Task RemoveRangeAsync(List<Tentity> tentities);
    }
}
