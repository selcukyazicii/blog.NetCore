using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public void AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }
         
        public List<Comment> GetListComment(int id)
        {
            return _commentDal.GetAll(x => x.BlogID == id);
        }

        
    }
}
