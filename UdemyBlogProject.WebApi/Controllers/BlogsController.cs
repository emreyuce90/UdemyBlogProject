using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.DTO.DTOs.BlogDtos;
using UdemyBlogProject.Entities.Concrete;
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
        public async Task<IActionResult> Create(BlogAddModel blogAddmodel)
        {
            await _blogservice.AddAsync(_mapper.Map<Blog>(blogAddmodel));
            return Created("", blogAddmodel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,BlogUpdateModel blogUpdateModel)
        {
            if (id!= blogUpdateModel.Id)
            {
                return BadRequest("Girdiğiniz id veritabanında bulunmamaktadır");
            }
            await _blogservice.UpdateAsync(_mapper.Map<Blog>(blogUpdateModel));
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