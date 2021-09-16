using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DataAccessLayer.Concrete.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.AuthorName).HasMaxLength(50).IsRequired();
            builder.Property(I => I.AuthorEmail).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Description).HasMaxLength(500).IsRequired();

            builder.HasMany(I => I.SubComments).WithOne(I => I.ParentComment).HasForeignKey(I => I.ParentCommentId);
            

            
        }
    }
}
