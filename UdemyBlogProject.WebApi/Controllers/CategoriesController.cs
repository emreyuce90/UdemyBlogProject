using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.DTO.DTOs.CategoryDtos;
using UdemyBlogProject.Entities.Concrete;
using UdemyBlogProject.WebApi.CustomFilters;

namespace UdemyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetAllAsync()));
        }
        [HttpGet("{id}")]
        //[ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(_mapper.Map<CategoryListDto>(await _categoryService.GetByIdAsync(Id)));
        }
        [Authorize]
        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> AddCategory([FromForm]CategoryAddDto categoryAddDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryAddDto));
            return Created("", categoryAddDto);
        }
        [Authorize]
        [HttpPut("{id}")]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> UpdateCategory(int id, [FromForm]CategoryUpdateDto categoryUpdateDto)
        {
            if (categoryUpdateDto.Id != id)
            {
                return BadRequest("Girdiğiniz id ye ait bir kayıt bulunamadı");
            }
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryUpdateDto));
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.RemoveAsync(new Category { Id = id });
            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CategoriesCountBlogs()
        {
            //Kategoriler Bloglarla birlikte geldi
            var categories = await _categoryService.GetCategoryWithBlogsAsync();
            //Göstermek istediğimiz tablo kategoriler ve blog sayıları
            List<CategoryBlogListDto> dto = new List<CategoryBlogListDto>();

            //gelen kategorileri tek tek dön her biri bir kategori
            foreach (var category in categories)
            {
                //Dtomuzdan bir nesne örneği alalım 
                CategoryBlogListDto listDto = new CategoryBlogListDto()
                {
                    //Dto muzdaki kategorimize db den gelen kategoriyi eşitledik 
                    Id = category.Id,
                    Name=category.Name,
                    //Db den gelen kategorinin blog sayılarını BlogCount nesnesine eşitledik
                    BlogCount = category.BlogCategories.Count
                    
                };
                //dto listemize ekle
                dto.Add(listDto);
            }
            return Ok(dto);
        }

    }
}