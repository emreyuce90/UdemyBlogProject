using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.DataAccessLayer.Interfaces;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.BusinessLayer.Concrete
{
    public class CommentManager:GenericManager<Comment>,ICommentService
    {
        private readonly IGenericDal<Comment> _genericDal;
        private readonly ICommentDal _commentDal;
        public CommentManager(IGenericDal<Comment> genericDal,ICommentDal commentDal):base(genericDal)
        {
            _genericDal = genericDal;
            _commentDal=commentDal;
        }

        public async Task<List<Comment>> GetAllWithSubCommentsAsync(int blogId, int? parentId)
        {
          return await _commentDal.GetAllWithSubCommentsAsync(blogId,parentId);
        }
    }
}
