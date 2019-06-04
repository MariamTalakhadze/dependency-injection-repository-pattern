using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Repository
{
    public class POrderRepsitory : IRepository<POrder>
    {
        DModel _context;

        public POrderRepsitory()
        {
            _context = new DModel();
        }
        public IEnumerable<POrder> List
        {
            get { return _context.POrders; }
        }
        public void Add(POrder entity)
        {
            _context.POrders.Add(entity);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            var entity = _context.POrders.Where(x => x.ID == id).FirstOrDefault();
            _context.POrders.Remove(entity);
            _context.SaveChanges();
            return true;
        }
        public POrder FindById(int id)
        {
            var result = (from r in _context.POrders where r.ID == id select r).FirstOrDefault();
            return result;
        }

        public void Update(POrder entity)
        {
            var result = _context.POrders.SingleOrDefault(b => b.ID == entity.Id);
            if (result != null)
            {
                result.PID = entity.PID;
                result.NOrders = entity.NOrders;
                result.Descrip = entity.Descrip;
                _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}