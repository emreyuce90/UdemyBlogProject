using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.BusinessLayer.Concrete;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.BusinessLayer.Utilities.JwtTools;
using UdemyBlogProject.BusinessLayer.ValidationRules;
using UdemyBlogProject.BusinessLayer.ValidationRules.FluentValidation;
using UdemyBlogProject.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.DTO.DTOs.AppUserDtos;
using UdemyBlogProject.DTO.DTOs.BlogCategoryDtos;
using UdemyBlogProject.DTO.DTOs.CategoryDtos;

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

            services.AddScoped<ICommentService,CommentManager>();
            services.AddScoped<ICommentDal,EfCommentRepository>();


            services.AddScoped<IJwtService, JwtManager>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            //AppUserLoginDto'yu validate et AppUserLoginValidator'da yazılan kurallara göre
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();
            services.AddTransient<IValidator<BlogCategoryDto>, BlogCategoryValidator>();
            services.AddTransient<IValidator<CategoryAddDto>,CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>,CategoryUpdateValidator>();
           
            
        }
    }
}
