using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.BusinessLayer.Utilities.JwtTools
{
    public interface IJwtService
    {
        JwtToken GenerateToken(AppUser appuser);
    }
}
