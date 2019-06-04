using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Repository
{
    public class UserInfoRepository : IRepository<userinfo>
    {
        DModel _context;

        public UserInfoRepository()
        {
            _context = new DModel();
        }
        public IEnumerable<userinfo> List
        {
            get { return _context.userinfoes; }
        }
        public void Add(userinfo entity)
        {
            _context.userinfoes.Add(entity);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            var entity = _context.userinfoes.Where(x => x.ID == id).FirstOrDefault();
            _context.userinfoes.Remove(entity);
            _context.SaveChanges();
            return true;
        }
        public userinfo FindById(int id)
        {
            var result = (from r in _context.userinfoes where r.ID == id select r).FirstOrDefault();
            return result;
        }

        public void Update(userinfo entity)
        {
            var result = _context.userinfoes.SingleOrDefault(b => b.ID == entity.Id);
            if (result != null)
            {
                result.NameSurname = entity.NameSurname;
                result.MobileNumber = entity.MobileNumber;
                _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}