using BOL;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoanTypeBs
    {
        private loanTypeDb objDb;

        public LoanTypeBs()
        {
            objDb = new loanTypeDb();
        }

        public IEnumerable<tblLoanType> GetAll()
        {
            return objDb.GetAll();
        }

        public IEnumerable GetLoanType()
        {
            return objDb.GetLoanType();
        }

        public tblLoanType GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }

        public void Insert(tblLoanType users)
        {
            objDb.Insert(users);
        }

        public void Delete(string Id)
        {
            objDb.Delete(Id);
        }

        public void Update(tblLoanType users)
        {
            objDb.Update(users);
        }

    }
}
