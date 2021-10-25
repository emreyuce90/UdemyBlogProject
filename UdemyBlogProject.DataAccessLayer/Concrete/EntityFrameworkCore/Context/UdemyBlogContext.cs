using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.DataAccessLayer.Concrete.Mappings;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context
{
    public class UdemyBlogContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=UdemyBlogDB;integrated security =true");
           // optionsBuilder.UseSqlServer("workstation id = myblogdb39.mssql.somee.com; packet size = 4096; user id = emreyuce39_SQLLogin_1; pwd = 91ztc8184j; data source = myblogdb39.mssql.somee.com; persist security info = False; initial catalog = myblogdb39");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new BlogCategoryMap());

            modelBuilder.ApplyConfiguration(new BlogMap());

            modelBuilder.ApplyConfiguration(new CategoryMap());

            modelBuilder.ApplyConfiguration(new CommentMap());

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }


    }
}
