﻿using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DTO.Interfaces;

namespace UdemyBlogProject.DTO.DTOs.CategoryDtos
{
    public class CategoryAddDto:IDto
    {
        public string Name { get; set; }
    }
}
