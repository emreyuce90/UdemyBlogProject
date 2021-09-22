﻿using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DTO.Interfaces;

namespace UdemyBlogProject.DTO.DTOs.CategoryDtos
{
    public class CategoryUpdateDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
