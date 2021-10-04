using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.BusinessLayer.Interfaces
{
    public interface IAppUserService:IGenericService<AppUser>
    {
        Task<AppUser> CheckUserNameAndPasswordAsync(AppUser appuser);
        Task<AppUser> FindUserNameAsync(string userName);
    }
}
