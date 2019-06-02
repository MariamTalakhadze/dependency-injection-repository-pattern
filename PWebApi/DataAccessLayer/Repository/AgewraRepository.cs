using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;

namespace DataAccessLayer.Repository
{
    public class AgewraRepository :IRepository<Agwera>
    {
        DataModel _context;

        public AgewraRepository()
        {
            _context = new DataModel();
        }
        public IEnumerable<Agwera> List
        {
            get { return _context.Agweras; }
        }

        public void Add(Agwera entity)
        {
            _context.Agweras.Add(entity);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var entity = _context.Agweras.Where(x => x.AgweraID == id).FirstOrDefault();
            _context.Agweras.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public Agwera FindById(int id)
        {
            var result = (from r in _context.Agweras where r.AgweraID == id select r).FirstOrDefault();
            return result;
        }

        public void Update(Agwera entity)
        {
            var result = _context.Agweras.SingleOrDefault(b => b.AgweraID == entity.Id);
            if (result != null)
            {
                result.Dasaxeleba = entity.Dasaxeleba;
                result.Pasi = entity.Pasi;
                _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}