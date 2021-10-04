using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyBlogProject.DTO.DTOs.AppUserDtos;
using UdemyBlogProject.DTO.DTOs.BlogDtos;
using UdemyBlogProject.DTO.DTOs.CategoryDtos;
using UdemyBlogProject.Entities.Concrete;
using UdemyBlogProject.WebApi.Models;

namespace UdemyBlogProject.WebApi.Mapper.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            //Blog 
            CreateMap<Blog, BlogListDto>();
            CreateMap<BlogListDto, Blog>();

            CreateMap<BlogAddModel, Blog>();
            CreateMap<Blog, BlogAddModel>();

            CreateMap<Blog, BlogUpdateModel>();
            CreateMap<BlogUpdateModel, Blog>();

            //Kategori
            CreateMap<Category, CategoryAddDto>();
            CreateMap<CategoryAddDto, Category>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();

            CreateMap<AppUser, AppUserLoginDto>();
            CreateMap<AppUserLoginDto, AppUser>();

        }
    }
}
