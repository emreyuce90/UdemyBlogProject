using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.Entities.Interface;

namespace UdemyBlogProject.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Tentity> : IGenericDal<Tentity> where Tentity : class, ITable, new()
    {
        public async Task AddAsync(Tentity tentity)
        {
            using var context = new UdemyBlogContext();
            await context.AddAsync(tentity);
            await context.SaveChangesAsync();
        }

        public async Task<List<Tentity>> GetAllAsync()
        {
            using var context = new UdemyBlogContext();
            return await context.Set<Tentity>().ToListAsync();
        }

        public Task<List<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Tentity> GetAsync(Expression<Func<Tentity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Tentity tentity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Tentity tentity)
        {
            throw new NotImplementedException();
        }
    }
}
