using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{   
        
        public interface IRepository<T> where T : BEntity
        {

            IEnumerable<T> List { get; }
            void Add(T entity);
            bool Delete(int id);
            void Update(T entity);
            T FindById(int id);

        }
}