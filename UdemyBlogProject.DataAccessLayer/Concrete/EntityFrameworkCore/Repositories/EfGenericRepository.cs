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

        public async Task AddRangeAsync(List<Tentity> tentities)
        {
            using var context = new UdemyBlogContext();
            await context.AddRangeAsync(tentities);
            await context.SaveChangesAsync();
        }

        public async Task<List<Tentity>> GetAllAsync()
        {
            using var context = new UdemyBlogContext();
            return await context.Set<Tentity>().ToListAsync();
        }

        public async Task<List<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>> filter)
        {
            using var context = new UdemyBlogContext();
            return await context.Set<Tentity>().Where(filter).ToListAsync();
        }

        public async Task<List<Tentity>> GetAllAsync<Tkey>(Expression<Func<Tentity, Tkey>> keySelector)
        {
            using var context = new UdemyBlogContext();
            return await context.Set<Tentity>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<Tentity>> GetAllAsync<Tkey>(Expression<Func<Tentity, bool>> filter, Expression<Func<Tentity, Tkey>> keySelector)
        {
            using var context = new UdemyBlogContext();
            return await context.Set<Tentity>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<Tentity> GetAsync(Expression<Func<Tentity, bool>> filter)
        {
            using var context = new UdemyBlogContext();
            return await context.Set<Tentity>().FindAsync(filter);
        }

        public async Task RemoveAsync(Tentity tentity)
        {
            using var context = new UdemyBlogContext();
            context.Remove(tentity);
            await context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(List<Tentity> tentities)
        {
            using var context = new UdemyBlogContext();
            context.RemoveRange(tentities);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tentity tentity)
        {
            using var context = new UdemyBlogContext();
            context.Update(tentity);
            await context.SaveChangesAsync();
        }
    }
}
