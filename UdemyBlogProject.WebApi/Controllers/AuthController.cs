using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.BusinessLayer.Utilities.JwtTools;
using UdemyBlogProject.DTO.DTOs.AppUserDtos;
using UdemyBlogProject.Entities.Concrete;
using UdemyBlogProject.WebApi.CustomFilters;

namespace UdemyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        public AuthController(IAppUserService appUserService, IMapper mapper, IJwtService jwtService)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _jwtService = jwtService;
        }
        [HttpPost]
        [ValidModel]
        //Token oluşturma
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
         var user=   await _appUserService.CheckUserNameAndPasswordAsync(_mapper.Map<AppUser>(appUserLoginDto));

            if (user!=null)
            {
                
                return Created("", _jwtService.GenerateToken(user));
            }
            return BadRequest("Kullanıcı adı veya şifre hatalı");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindUserNameAsync(User.Identity.Name);


            return Ok(new AppUserDto { Name = user.Name, Surname = user.Surname }); ;
        }
    }
}