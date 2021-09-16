using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DataAccessLayer.Concrete.Mappings
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.Surname).HasMaxLength(100);
            builder.Property(I => I.Username).HasMaxLength(20).IsRequired();
            builder.Property(I => I.Password).HasMaxLength(20).IsRequired();
            builder.Property(I => I.EMail).HasMaxLength(50);

            //Kullanıcı açısından blogların durumu
            //1 kullanıcı birden fazla blog yazabilir,fakat bir blogun mutlaka bir kullanıcısı olmalıdır.Buradaki fk ise AppUserId dir

            builder.HasMany(I => I.Blogs).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId);

        }
    }
}
