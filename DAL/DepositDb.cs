using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DepositDb
    {
        private BMS2Entities _db;
        public DepositDb()
        {
            _db = new BMS2Entities();
        }

        public IEnumerable<tblDeposit> GetAll()
        {
            return _db.tblDeposits.ToList();
        }



        public tblOpenAct GetByID(string Id)
        {
            return _db.tblOpenActs.Where(x => x.acctNo == Id).FirstOrDefault();
            
        }

        public void Insert(tblDeposit op)
        {
            _db.spInsertDeposit(op.branchName, op.transactionDate, op.acctNo, op.actName, op.actType,  op.depositAmount, op.Depositer, op.currentBalance);
            //_db.tblDeposits.Add(op);
            //Save();
        }

        public void Delete(string Id)
        {
            tblDeposit op = _db.tblDeposits.Find(Id);
            _db.tblDeposits.Remove(op);
            Save();
        }

        public void Update(tblDeposit op)
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

