using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repository;

namespace BL
{
    public class KindLogics : BEntity
    {
        IRepository<pkind> repo = new PKindRepository();

        public IEnumerable<pkind> getAllKind()
        {
            return repo.List;
        }

        public pkind findkind(int id)
        {
            return repo.FindById(id);
        }

        public bool addKind(pkind kind)
        {
            try
            {
                repo.Add(kind);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool updatekinds(pkind kind)
        {
            try
            {
                repo.Update(kind);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool deletekinds(int id)
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