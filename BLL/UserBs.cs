using DAL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBs
    {

        private UserDb objDb;

        public UserBs()
        {
            objDb = new UserDb();
        }

        public IEnumerable<AspNetUser> GetAll()
        {
            return objDb.GetAll();
        }

        public AspNetUser GetByID(string Id)
        {
            return objDb.GetByID(Id);
        }

        public void Insert(AspNetUser users)
        {
            objDb.Insert(users);
        }

        public void Delete(string Id)
        {
            objDb.Delete(Id);
        }

        public void Update(AspNetUser users)
        {
            objDb.Update(users);
        }

    }
}

