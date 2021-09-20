using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.Entities.Interface;

namespace UdemyBlogProject.BusinessLayer.Concrete
{
    public class GenericManager<Tentity> : IGenericService<Tentity> where Tentity : class, ITable, new()
    {
        //BLL katmanı DAL katmanını ctorda almalı 
        private readonly IGenericDal<Tentity> _genericDal;
        public GenericManager(IGenericDal<Tentity> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task AddAsync(Tentity tentity)
        {
           await _genericDal.AddAsync(tentity);
        }

        public async Task AddRangeAsync(List<Tentity> tentities)
        {
            await _genericDal.AddRangeAsync(tentities);
        }

        public async Task<List<Tentity>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

       
        public async Task<Tentity> GetByIdAsync(int id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Tentity tentity)
        {
            await _genericDal.RemoveAsync(tentity);
        }

        public async Task RemoveRangeAsync(List<Tentity> tentities)
        {
         await _genericDal.RemoveRangeAsync(tentities);
        }

        public async Task UpdateAsync(Tentity tentity)
        {
            await _genericDal.UpdateAsync(tentity);
        }
    }
}
