using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DataAccessLayer.Concrete.Mappings
{
    public class BlogCategoryMap : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasIndex(I => new { I.BlogId, I.CategoryId }).IsUnique();
        }
    }
}
