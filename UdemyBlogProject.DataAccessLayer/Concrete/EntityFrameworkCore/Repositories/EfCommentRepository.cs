using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemyBlogProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCommentRepository : EfGenericRepository<Comment>, ICommentDal
    {
        public async Task<List<Comment>> GetAllWithSubCommentsAsync(int blogId, int? parentId)
        {
            var result = new List<Comment>();
            await GetSubComments(blogId, parentId, result);

            return result;
        }

        public async Task GetSubComments(int blogId, int? parentId, List<Comment> result)
        {
            using var context = new UdemyBlogContext();
            var comments = await context.Comments.Where(I => I.BlogId == blogId && I.ParentCommentId == parentId).OrderByDescending(I => I.ReleseDate).ToListAsync();
            if (comments.Count > 0)
            {
                foreach (var comment in comments)
                {
                    if (comment.SubComments == null)
                    {
                        comment.SubComments = new List<Comment>();
                    }
                    await GetSubComments(comment.BlogId,comment.Id,comment.SubComments);
                    if (!result.Contains(comment))
                    {
                        result.Add(comment);
                    }
                }
            }

        }
    }
}
