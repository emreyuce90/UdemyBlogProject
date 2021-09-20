using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBlogRepository:EfGenericRepository<Blog>,IBlogDal
    {

    }
}
