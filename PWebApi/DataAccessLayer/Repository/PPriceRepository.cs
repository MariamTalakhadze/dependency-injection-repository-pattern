using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Repository
{
    public class PPriceRepository : IRepository<PPrice>
    {
        DModel _context;

        public PPriceRepository()
        {
            _context = new DModel();
        }
        public IEnumerable<PPrice> List
        {
            get { return _context.PPrices; }
        }
        public void Add(PPrice entity)
        {
            _context.PPrices.Add(entity);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            var entity = _context.PPrices.Where(x => x.ID == id).FirstOrDefault();
            _context.PPrices.Remove(entity);
            _context.SaveChanges();
            return true;
        }
        public PPrice FindById(int id)
        {
            var result = (from r in _context.PPrices where r.ID == id select r).FirstOrDefault();
            return result;
        }

        public void Update(PPrice entity)
        {
            var result = _context.PPrices.SingleOrDefault(b => b.ID == entity.Id);
            if (result != null)
            {
                result.PKindID = entity.PKindID;
                result.Time = entity.Time;
                result.IsCurrent = entity.IsCurrent;
                _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}