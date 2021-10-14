using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.DTO.DTOs.AppUserDtos;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.BusinessLayer.Concrete
{
    public class AppUserManager:GenericManager<AppUser>,IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        public AppUserManager(IGenericDal<AppUser> genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<AppUser> CheckUserNameAndPasswordAsync(AppUser appuser)
        {
            return await _genericDal.GetAsync(I => I.Username == appuser.Username && I.Password == appuser.Password);
        }

        public async Task<AppUser> FindUserNameAsync(string userName)
        {
           return await _genericDal.GetAsync(I => I.Name == userName);
            
        }
    }
}
