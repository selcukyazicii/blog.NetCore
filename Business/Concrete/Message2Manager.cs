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
    public class Message2Manager : IMessage2Services
    {
        private readonly IMessage2Dal _message2Dal;
        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }
        public void Add(Message2 t)
        {
            _message2Dal.Insert(t);
        }

        public void Delete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public Message2 GetById(int id)
        {
            return _message2Dal.GeyById(id);
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            //return _message2Dal.GetAll(x => x.ReceiverId == id);
            return _message2Dal.GetListWithMessageByWriter(id);
        }

        public List<Message2> GetList()
        {
            return _message2Dal.GetAll();
        }

        public void Update(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}
