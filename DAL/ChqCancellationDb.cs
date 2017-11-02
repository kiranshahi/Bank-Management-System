using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class ChqCancellationDb
    {
        private BMS2Entities _db;
        public ChqCancellationDb()
        {
            _db = new BMS2Entities();
        }

        public IEnumerable<tblChqCancellation> GetAll()
        {
            return _db.tblChqCancellations.ToList();
        }



        public tblChqCancellation GetByID(string Id)
        {
            return _db.tblChqCancellations.Find(Id);
        }

        public void Insert(tblChqCancellation op)
        {
            _db.spinsertChqCanellationDetails(op.acctNo, op.custName, op.chqNo, op.cancellationDate, op.Reason);
        }

        public void Delete(string Id)
        {
            tblChqCancellation op = _db.tblChqCancellations.Find(Id);
            _db.tblChqCancellations.Remove(op);
            Save();
        }

        public void Update(tblChqCancellation op)
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
