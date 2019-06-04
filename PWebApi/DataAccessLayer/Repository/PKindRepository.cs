using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Repository
{
    public class PKindRepository : IRepository<pkind>
    {
        DModel _context;

        public PKindRepository()
        {
            _context = new DModel();
        }
        public IEnumerable<pkind> List
        {
            get { return _context.pkinds; }
        }
        public void Add(pkind entity)
        {
            _context.pkinds.Add(entity);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            var entity = _context.pkinds.Where(x => x.ID == id).FirstOrDefault();
            _context.pkinds.Remove(entity);
            _context.SaveChanges();
            return true;
        }
        public pkind FindById(int id)
        {
            var result = (from r in _context.pkinds where r.ID == id select r).FirstOrDefault();
            return result;
        }

        public void Update(pkind entity)
        {
            var result = _context.pkinds.SingleOrDefault(b => b.ID == entity.Id);
            if (result != null)
            {
                result.Title = entity.Title;
                result.Description = entity.Description;
                _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}