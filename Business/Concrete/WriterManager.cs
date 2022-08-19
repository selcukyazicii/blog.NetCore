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
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer t)
        {
            _writerDal.Insert(t);
        }


        public void Delete(Writer t)
        {
            throw new NotImplementedException();
        }

        public Writer GetById(int id)
        {
            return _writerDal.GeyById(id);
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterById(int id)
        {
            var data = _writerDal.GetAll(x => x.WriterId == id);
            return data;
        }

        public void Update(Writer t)
        {
            Writer writer = new Writer();
            writer.WriterName = t.WriterName;
            writer.WriterAbout = t.WriterAbout;
            writer.WriterImage = t.WriterImage;
            writer.WriterMail = t.WriterMail;
            writer.WriterId = t.WriterId;
            writer.WriterStatus = true;
            writer.WriterPassword = t.WriterPassword;
            _writerDal.Update(writer);
        }
    }
}
