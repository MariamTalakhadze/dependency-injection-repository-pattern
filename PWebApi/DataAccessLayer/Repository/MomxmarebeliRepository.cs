using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Repository
{
    public class MomxmarebeliRepository : IRepository<Momxmarebeli>
    {
        DataModel _context;

        public MomxmarebeliRepository()
        {
            _context = new DataModel();
        }

        public IEnumerable<Momxmarebeli> List
        {
            get { return _context.Momxmarebelis; }
        }

        public void Add(Momxmarebeli entity)
        {
            _context.Momxmarebelis.Add(entity);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var entity = _context.Momxmarebelis.Where(x => x.MomxmarebeliID == id).FirstOrDefault();
            _context.Momxmarebelis.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public void Update(Momxmarebeli entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        Momxmarebeli IRepository<Momxmarebeli>.FindById(int id)
        {
            var result = (from r in _context.Momxmarebelis where r.MomxmarebeliID == id select r).FirstOrDefault();
            return result;
        }
    }
}