using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoanDb
    {
        private BMS2Entities _db;
        public LoanDb()
        {
            _db = new BMS2Entities();
        }

        public IEnumerable<tblLoan> GetAll()
        {
            return _db.tblLoans.ToList();
        }



        public tblLoan GetByID(string Id)
        {
            return _db.tblLoans.Find(Id);
        }


        public void Insert(tblLoan op)
        {
            _db.tblLoans.Add(op);
            Save();

        }

        public void Delete(string Id)
        {
            tblLoan op = _db.tblLoans.Find(Id);
            _db.tblLoans.Remove(op);
            Save();
        }

        public void Update(tblLoan op)
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
