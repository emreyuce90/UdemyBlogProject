using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DataAccessLayer.Concrete.Mappings
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Title).HasMaxLength(250).IsRequired();
            builder.Property(I => I.ShortDescription).HasMaxLength(200).IsRequired();
            builder.Property(I => I.Description).HasColumnType("ntext").IsRequired();

            //Bir blog birden fazla kategoriye ait olabilir
            //Ayırt edici özellik BlogId

            builder.HasMany(I => I.BlogCategories).WithOne(I => I.Blog).HasForeignKey(I => I.BlogId);

            //bir bloğun birden fazla yorumu olabilir
            builder.HasMany(I => I.Comments).WithOne(I => I.Blog).HasForeignKey(I => I.BlogId);


        }
    }
}
