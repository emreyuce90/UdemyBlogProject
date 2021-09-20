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

        Task<Tentity> GetByIdAsync(int id);

        Task AddAsync(Tentity tentity);
        Task AddRangeAsync(List<Tentity> tentities);
        Task UpdateAsync(Tentity tentity);
        Task RemoveAsync(Tentity tentity);
        Task RemoveRangeAsync(List<Tentity> tentities);
    }
}
