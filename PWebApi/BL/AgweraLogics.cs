using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repository;

namespace BL
{
    public class AgweraLogics :BEntity
    {
        IRepository<Agwera> repo = new AgewraRepository();

        public  IEnumerable<Agwera> getAllAgwera()
        {
            return repo.List;
        }

        public  Agwera findAgwera(int id)
        {
            return repo.FindById(id);
        }

        public  bool addAgwera(Agwera user)
        {
            try
            {
                repo.Add(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  bool updateAgwera(Agwera user)
        {
            try
            {
                repo.Update(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  bool deleteAgwera(int id)
        {
            try
            {
                repo.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}