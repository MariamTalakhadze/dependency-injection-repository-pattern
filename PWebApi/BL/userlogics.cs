using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repository;

namespace BL
{
    public class userlogics : BEntity
    {
        IRepository<userinfo> repo = new UserInfoRepository();

        public IEnumerable<userinfo> getAllUsers()
        {
            return repo.List;
        }

        public userinfo findUsers(int id)
        {
            return repo.FindById(id);
        }

        public bool addUsers(userinfo user)
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

        public bool updateUsers(userinfo user)
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

        public bool deleteUsers(int id)
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