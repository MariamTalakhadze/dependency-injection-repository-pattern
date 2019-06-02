using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Repository
{
    public class ShekvetebiRepository : IRepository<Shekvetebi>
    {
        DataModel _context;

        public ShekvetebiRepository()
        {
            _context = new DataModel();
        }

        public IEnumerable<Shekvetebi> List
        {
            get { return _context.Shekvetebis; }
        }


        public void Add(Shekvetebi entity)
        {
            _context.Shekvetebis.Add(entity);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var entity = _context.Shekvetebis.Where(x => x.ShekvetaID == id).FirstOrDefault();
            _context.Shekvetebis.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public Shekvetebi FindById(int id)
        {
            var result = (from r in _context.Shekvetebis where r.ShekvetaID == id select r).FirstOrDefault();
            return result;
        }

        public void Update(Shekvetebi entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}