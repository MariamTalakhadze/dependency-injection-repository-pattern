using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repository;

namespace BL
{
    public class orderLogics : BEntity
    {
        IRepository<POrder> repo = new POrderRepsitory();

        public IEnumerable<POrder> getAllorder()
        {
            return repo.List;
        }

        public POrder findorder(int id)
        {
            return repo.FindById(id);
        }

        public bool addOrder(POrder order)
        {
            try
            {
                repo.Add(order);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool updateorders(POrder order)
        {
            try
            {
                repo.Update(order);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool deleteorders(int id)
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