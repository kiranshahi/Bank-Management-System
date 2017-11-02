using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoanBs
    {
        private LoanDb objDb;

        public LoanBs()
        {
            objDb = new LoanDb();
        }

        public IEnumerable<tblLoan> GetAll()
        {
            return objDb.GetAll();
        }

        public tblLoan GetByID(string Id)
        {
            return objDb.GetByID(Id);
        }

        public void Insert(tblLoan users)
        {
            objDb.Insert(users);
        }

        public void Delete(string Id)
        {
            objDb.Delete(Id);
        }

        public void Update(tblLoan users)
        {
            objDb.Update(users);
        }

    }
}

