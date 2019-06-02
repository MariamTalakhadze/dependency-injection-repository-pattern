using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repository;

namespace BL
{
    public class ShekvetebiLogics : BEntity
    {
        IRepository<Shekvetebi> repo = new ShekvetebiRepository();

        public  IEnumerable<Shekvetebi> getAllShekvetebi()
        {
            return repo.List;
        }
        
        public  Shekvetebi findShekvetebi(int id)
        {
            return repo.FindById(id);
        }

        public  bool addShekvetebi(Shekvetebi user)
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

        public  bool updateShekvetebi(Shekvetebi user)
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

        public  bool deleteShekvetebi(int id)
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