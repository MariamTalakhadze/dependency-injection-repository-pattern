using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repository;

namespace BL
{
    public class MomxmarebeliLogics : BEntity
    {
         IRepository<Momxmarebeli> repo = new MomxmarebeliRepository();

        public  IEnumerable<Momxmarebeli> getAllMomxmarebeli()
        {
            return repo.List;
        }

        public  Momxmarebeli findMomxmarebeli(int id)
        {
            return repo.FindById(id);
        }

        public  bool addMomxmarebeli(Momxmarebeli user)
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

        public bool updateMomxmarebeli(Momxmarebeli user)
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

        public  bool deleteMomxmarebeli(int id)
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