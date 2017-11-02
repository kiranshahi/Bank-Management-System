using BOL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class loanTypeDb
    {
        private BMS2Entities _db;
        public loanTypeDb()
        {
            _db = new BMS2Entities();
        }

        public IEnumerable<tblLoanType> GetAll()
        {
            return _db.tblLoanTypes.ToList();
        }


        public IEnumerable GetLoanType()
        {
            return _db.tblLoanTypes.Select(x=>x.Loan_Type).ToList();
        }

        public tblLoanType GetByID(int Id)
        {
            return _db.tblLoanTypes.Where(x=>x.Master_Loan_Id == Id).FirstOrDefault();
        }

      
        public void Insert(tblLoanType op)
        {
            _db.tblLoanTypes.Add(op);
            Save();
 
        }

        public void Delete(string Id)
        {
            tblLoanType op = _db.tblLoanTypes.Find(Id);
            _db.tblLoanTypes.Remove(op);
            Save();
        }

        public void Update(tblLoanType op)
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


