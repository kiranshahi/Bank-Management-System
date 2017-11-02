using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDb
    {
        private BMS2Entities _db;
        public UserDb()
        {
            _db = new BMS2Entities();
        }

        public IEnumerable<AspNetUser> GetAll()
        {
            return _db.AspNetUsers.ToList();
        }


        public AspNetUser GetByID(string Id)
        {
            return _db.AspNetUsers.Find(Id);
        }

        public void Insert(AspNetUser users)
        {
            _db.AspNetUsers.Add(users);
            Save();
        }

        public void Delete(string Id)
        {
            AspNetUser users = _db.AspNetUsers.Find(Id);
            _db.AspNetUsers.Remove(users);
            Save();
        }

        public void Update(AspNetUser users)
        {
            _db.Entry(users).State = EntityState.Modified;
            _db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            _db.Configuration.ValidateOnSaveEnabled = true;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}

