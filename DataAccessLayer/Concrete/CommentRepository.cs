using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CommentRepository : IGenericDal<Comment>
    {
        public void Delete(Comment t)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll(Expression<Func<Comment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Comment GeyById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Comment t)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
