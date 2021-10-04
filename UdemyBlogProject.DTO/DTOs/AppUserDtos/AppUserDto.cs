using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DTO.Interfaces;

namespace UdemyBlogProject.DTO.DTOs.AppUserDtos
{
    public class AppUserDto:IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
