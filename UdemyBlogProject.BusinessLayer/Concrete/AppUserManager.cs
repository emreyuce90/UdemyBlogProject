using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.DataAccessLayer.Interfaces;
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
    }
}
