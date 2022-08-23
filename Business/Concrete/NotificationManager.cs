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
    public class NotificationManager : INotificationServices
    {
        private readonly INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Add(Notification t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Notification t)
        {
            throw new NotImplementedException();
        }

        public Notification GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetList()
        {
            return _notificationDal.GetAll();
        }

        public void Update(Notification t)
        {
            throw new NotImplementedException();
        }
    }
}
