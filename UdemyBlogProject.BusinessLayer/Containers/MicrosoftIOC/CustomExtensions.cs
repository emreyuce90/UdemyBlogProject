using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.BusinessLayer.Concrete;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.BusinessLayer.Utilities.JwtTools;
using UdemyBlogProject.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using UdemyBlogProject.DataAccessLayer.Interfaces;

namespace UdemyBlogProject.BusinessLayer.Containers.MicrosoftIOC
{
    public static class CustomExtensions
    {
        public static void  AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            
        }
    }
}
