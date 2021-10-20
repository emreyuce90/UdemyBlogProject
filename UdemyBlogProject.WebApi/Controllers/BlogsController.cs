using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.DTO.DTOs.BlogCategoryDtos;
using UdemyBlogProject.DTO.DTOs.BlogDtos;
using UdemyBlogProject.Entities.Concrete;
using UdemyBlogProject.WebApi.CustomFilters;
using UdemyBlogProject.WebApi.Models;

namespace UdemyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {

        private readonly IBlogService _blogservice;
        private readonly IMapper _mapper;
        public BlogsController(IBlogService blogservice, IMapper mapper)
        {
            _blogservice = blogservice;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogservice.GetAllSortedByPostedTimeAsync()));
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BlogListDto>(await _blogservice.GetByIdAsync(id)));
        }

        [HttpPost]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Create([FromForm]BlogAddModel blogAddmodel)
        {

            if (blogAddmodel.File != null)
            {
                if (blogAddmodel.File.ContentType != "image/jpeg")
                {
                    return BadRequest("Tanınmayan dosya tipi!Lütfen sadece jpeg uzantılı dosyalar yükleyiniz");
                }
                var name = Guid.NewGuid() + blogAddmodel.File.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", name);
                var stream = new FileStream(path, FileMode.Create);
                await blogAddmodel.File.CopyToAsync(stream);
                blogAddmodel.ImagePath = name;
            }

            await _blogservice.AddAsync(_mapper.Map<Blog>(blogAddmodel));
            return Created("", blogAddmodel);
        }

        //[ServiceFilter(typeof(ValidId<Blog>))]
        [Authorize]
        [ValidModel]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm]BlogUpdateModel blogUpdateModel)
        {
            
            if (id != blogUpdateModel.Id)
            {
                return BadRequest("Girdiğiniz id veritabanında bulunmamaktadır");
            }
            var beUpdated = await _blogservice.GetByIdAsync(blogUpdateModel.Id);
            if (blogUpdateModel.File != null)
            {
                if (blogUpdateModel.File.ContentType != "image/jpeg")
                {
                    return BadRequest("Lütfen sadece jpeg uzantılı resimler yükleyiniz");
                }

                string uniqueName = Guid.NewGuid() + blogUpdateModel.File.FileName;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", uniqueName);
                var stream = new FileStream(path, FileMode.Create);
                await blogUpdateModel.File.CopyToAsync(stream);
                blogUpdateModel.ImagePath = uniqueName;
                beUpdated.ImagePath = blogUpdateModel.ImagePath;
            }

            //db den gelen kayıt
           
            beUpdated.Title = blogUpdateModel.Title;
            beUpdated.ShortDescription = blogUpdateModel.ShortDescription;
            beUpdated.Description = blogUpdateModel.Description;


            await _blogservice.UpdateAsync(beUpdated);
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Blog>))]

        public async Task<IActionResult> Delete(int id)
        {
            await _blogservice.RemoveAsync(new Blog { Id = id });
            return NoContent();
        }

        [Authorize]
        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> AddCategoryToBlog(BlogCategoryDto blogCategoryDto)
        {
            await _blogservice.AddCategoryToBlogsAsync(blogCategoryDto);
            return Created("", blogCategoryDto);
        }


        [ValidModel]
        [Authorize]
        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveCategoryFromBlog(BlogCategoryDto blogCategoryDto)
        {
            await _blogservice.DeleteCategoryFromBlog(blogCategoryDto);
            return NoContent();
        }
        //[ServiceFilter(typeof(ValidId<Category>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBlogsWithCategories(int id)
        {
            var blogs = await _blogservice.GetAllWithCategoryIdAsync(id);

            return Ok(blogs);
     
        }



    }
}