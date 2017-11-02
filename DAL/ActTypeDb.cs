using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class ActTypeDb
    {
        private BMS2Entities _db;
        public ActTypeDb()
        {
            _db = new BMS2Entities();
        }

        public IEnumerable<tblactType> GetAll()
        {
            return _db.tblactTypes.ToList();
        }



        public tblactType GetByID(string Id)
        {
            return _db.tblactTypes.Find(Id);
        }

        public void Insert(tblactType op)
        {
            _db.tblactTypes.Add(op);
            Save();
        }

        public void Delete(string Id)
        {
            tblactType op = _db.tblactTypes.Find(Id);
            _db.tblactTypes.Remove(op);
            Save();
        }

        public void Update(tblactType op)
        {
            _db.Entry(op).State = EntityState.Modified;
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


