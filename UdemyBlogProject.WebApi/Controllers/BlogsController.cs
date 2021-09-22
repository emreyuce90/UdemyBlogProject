using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogservice;
        public BlogsController(IBlogService blogservice)
        {
            _blogservice = blogservice;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _blogservice.GetAllSortedByPostedTimeAsync());
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _blogservice.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            await _blogservice.AddAsync(blog);
            return Created("", blog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,Blog blog)
        {
            if (id!=blog.Id)
            {
                return BadRequest("Girdiğiniz id veritabanında bulunmamaktadır");
            }
            await _blogservice.UpdateAsync(blog);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogservice.RemoveAsync(new Blog { Id = id });
            return NoContent();
        }    
    }
}