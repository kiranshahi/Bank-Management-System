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
   public class WithdrawalDb
    {
        private BMS2Entities _db;
        public WithdrawalDb()
        {
            _db = new BMS2Entities();
        }

        public IEnumerable<tblWithdrawal> GetAll()
        {
            return _db.tblWithdrawals.ToList();
        }

        public IEnumerable GetChqStatus(decimal chqno)
        {
            return _db.tblchqNoes.Where(x => x.chqNo == chqno && (x.status == "cancelled" || x.status == "Used")).ToList();
        }

        public tblWithdrawal GetByID(string Id)
        {
            return _db.tblWithdrawals.Find(Id);
        }

        public void Insert(tblWithdrawal op)
        {
            _db.spInsertWithdrawal(op.branchName, op.transDate, op.actNo, op.actName, op.actType, op.chqNo, op.chqDate, op.withAmount, op.paidTo, op.currentBalance);
        }

        public void Delete(string Id)
        {
            tblWithdrawal op = _db.tblWithdrawals.Find(Id);
            _db.tblWithdrawals.Remove(op);
            Save();
        }

        public void Update(tblWithdrawal op)
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
