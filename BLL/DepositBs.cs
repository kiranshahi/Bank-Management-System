using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class DepositBs
    {
        private DepositDb objDb;

        public DepositBs()
        {
            objDb = new DepositDb();
        }

        public IEnumerable<tblDeposit> GetAll()
        {
            return objDb.GetAll();
        }

        public tblOpenAct GetByID(string Id)
        {
            return objDb.GetByID(Id);
        }

        public void Insert(tblDeposit op)
        {
            objDb.Insert(op);
        }

        public void Delete(string Id)
        {
            objDb.Delete(Id);
        }

        public void Update(tblDeposit op)
        {
            objDb.Update(op);
        }

        public DataTable showcurrbalanceByaccno(string accno)
        {
            string sql = "spshowcurrentBalancecustNameByAccNo";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@acctno",accno)
            };
            return DBO.GetTable(sql, param, CommandType.StoredProcedure);
        }


    }
}


