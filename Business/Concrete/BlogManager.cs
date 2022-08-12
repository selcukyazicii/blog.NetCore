﻿using Business.Abstract;
using DataAccess.Abstract;
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
        public void AddBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog(Blog blog)
        {
            throw new NotImplementedException();
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

        public void UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> ListBlogByWriter(int id)
        {
            return _blogDal.GetAll(x => x.WriterId == id);
        }
    }
}
