using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OpenActDb
    {
        private BMS2Entities _db;
        public OpenActDb()
        {
            _db = new BMS2Entities();
        }

        public IEnumerable<tblOpenAct> GetAll()
        {
            return _db.tblOpenActs.ToList();
        }

       

        public string GetByID(string op)
        {
           return _db.spshowcurrentBalancecustNameByAccNo(op).ToString();
        }

      

        public void Insert(tblOpenAct op)
        {
            _db.spInsertCustAct(op.branchName, op.actType, op.actApprovedBy, op.custName, op.DOB, op.openingDate, op.acctNo, op.openingBalance, op.currentBalance, op.nomineeName, op.nomineeRelation, op.Photo);
            //_db.tblOpenActs.Add(op);
            //Save();
        }

        public void Delete(string Id)
        {
            tblOpenAct op = _db.tblOpenActs.Find(Id);
            _db.tblOpenActs.Remove(op);
            Save();
        }

        public void Update(tblOpenAct op)
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

