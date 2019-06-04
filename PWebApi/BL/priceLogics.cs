using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repository;

namespace BL
{
    public class priceLogics : BEntity
    {
        IRepository<PPrice> repo = new PPriceRepository();

        public IEnumerable<PPrice> getAllprice()
        {
            return repo.List;
        }

        public PPrice findprice(int id)
        {
            return repo.FindById(id);
        }

        public bool addPrice(PPrice Price)
        {
            try
            {
                repo.Add(Price);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool updatePrice(PPrice price)
        {
            try
            {
                repo.Update(price);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool deletePrice(int id)
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