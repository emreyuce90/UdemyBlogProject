using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DataAccessLayer.Concrete.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasMany(I => I.BlogCategories).WithOne(I => I.Category).HasForeignKey(I => I.CategoryId);
        }
    }
}
