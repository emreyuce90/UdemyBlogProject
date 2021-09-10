using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.Entities.Interface;

namespace UdemyBlogProject.BusinessLayer.Interfaces
{
    public interface IGenericService<Tentity> where Tentity :class,ITable,new()
    {
        //Hepsini getirir
        Task<List<Tentity>> GetAllAsync();
        //Where şartı ile hepsini getirir
        Task<List<Tentity>> GetAllAsync(Expression<Func<Tentity,bool>> filter);
        //Where şartı + orderby descending
        Task<List<Tentity>> GetAllAsync<Tkey>(Expression<Func<Tentity,bool>> filter,Expression<Func<Tentity,Tkey>> keySelector);
        //Sadece sort
        Task<List<Tentity>> GetAllAsync<Tkey>(Expression<Func<Tentity,Tkey>> keySelector);
        //Tek bir ürün getirme
        Task<Tentity> GetAsync(Expression<Func<Tentity,bool>> filter);


        Task AddAsync(Tentity tentity);
        Task AddRangeAsync(List<Tentity> tentities);
        Task UpdateAsync(Tentity tentity);
        Task RemoveAsync(Tentity tentity);
        Task RemoveRangeAsync(List<Tentity> tentities);
    }
}
