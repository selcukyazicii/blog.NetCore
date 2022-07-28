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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void AddBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Blog GetById()
        {
            throw new NotImplementedException();
        }
        
        public List<Blog> GetList()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> ListCategoryWithBlog()
        {
           return _blogDal.GetListWithCategory();
        }

        public List<Blog>GetBlogById(int id)
        {
            return _blogDal.GetAll(x => x.BlogID == id);
        }

        public void UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> ListBlogByWriter(int id)
        {
            throw new NotImplementedException(); 
        }
    }
}
