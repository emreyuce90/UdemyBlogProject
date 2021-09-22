using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DTO.Interfaces;

namespace UdemyBlogProject.DTO.DTOs.AppUserDtos
{
    public class AppUserLoginDto:IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
