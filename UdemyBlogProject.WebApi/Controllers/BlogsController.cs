﻿using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm]BlogUpdateModel blogUpdateModel)
        {
            if (id != blogUpdateModel.Id)
            {
                return BadRequest("Girdiğiniz id veritabanında bulunmamaktadır");
            }

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
            }

            //db den gelen kayıt
         var beUpdated=  await _blogservice.GetByIdAsync(blogUpdateModel.Id);

            beUpdated.Title = blogUpdateModel.Title;
            beUpdated.ShortDescription = blogUpdateModel.ShortDescription;
            beUpdated.Description = blogUpdateModel.Description;


            await _blogservice.UpdateAsync(beUpdated);
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