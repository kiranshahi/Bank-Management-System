using BOL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class ChqIssueDb
    {
        private BMS2Entities _db;
        public ChqIssueDb()
        {
            _db = new BMS2Entities();
        }

        public IEnumerable<tblChqIssue> GetAll()
        {
            return _db.tblChqIssues.ToList();
        }



        public tblChqIssue GetByID(string Id)
        {
            return _db.tblChqIssues.Find(Id);
        }

        public IEnumerable GetChqDetailsByCustName(string custname)
        {
            return _db.tblchqNoes.Where(x => x.custName.StartsWith(custname)).Select(k => new {k.chqNo,k.custName,k.status}).ToList();
        }
       


        public void Insert(tblChqIssue op)
        {
            _db.tblChqIssues.Add(op);            
            Save();
            _db.spInsertchqNos(op.chqId, op.custName);
        }

        public void Delete(string Id)
        {
            tblChqIssue op = _db.tblChqIssues.Find(Id);
            _db.tblChqIssues.Remove(op);
            Save();
        }

        public void Update(tblChqIssue op)
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

