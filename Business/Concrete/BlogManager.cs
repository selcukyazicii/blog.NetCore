using Business.Abstract;
using DataAccess.Abstract;
using Entity;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
       

      
        //Find ID
        public Blog GetById()
        {
            throw new NotImplementedException();
        }
        //Get All Blogs
        public List<Blog> GetList()
        {
            return _blogDal.GetAll();
        }
        //Get the Last 3 Posts in Blog
        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetAll().OrderByDescending(x => x.CreateDate).Take(3).ToList();
        }
        public List<Blog> ListCategoryWithBlog(string searchText)
        {
            return _blogDal.GetListWithCategory(searchText);
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetAll(x => x.BlogID == id);
        }




        public List<Blog> ListBlogByWriter(int id)
        {
            return _blogDal.GetAll(x => x.WriterId == id);
        }
        public List<BlogListesiVM> BlogListele(int id)
        {
           var a= _blogDal.BlogListele(id);
           return a;
        }
        public void Add(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void Delete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void Update(Blog t)
        {
            t.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _blogDal.Update(t);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GeyById(id);
        }
        public List<GetBlogsWithCategoryName> BlogListWithCatName()
        {
           return _blogDal.BlogListWithCategoryNamee();
        }
    }
}
