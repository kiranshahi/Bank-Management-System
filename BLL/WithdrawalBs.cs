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
    public class WithdrawalBs
    {
        private WithdrawalDb objDb;

        public WithdrawalBs()
        {
            objDb = new WithdrawalDb();
        }

        public IEnumerable<tblWithdrawal> GetAll()
        {
            return objDb.GetAll();
        }

        public IEnumerable GetChqStatus(decimal chqno)
        {
            return objDb.GetChqStatus(chqno);
        }

        //public DataTable GetChqStatus(decimal chqno)
        //{
        //    string sql = "select chqNo,status from tblchqNo where chqNo=@chqno and status='cancelled'";
        //    SqlParameter[] param = new SqlParameter[]
        //    {
        //        new SqlParameter("@chqno", chqno)
        //    };
        //    return DBO.GetTable(sql, param, CommandType.Text);
        //}

        public tblWithdrawal GetByID(string Id)
        {
            return objDb.GetByID(Id);
        }

        public void Insert(tblWithdrawal op)
        {
            objDb.Insert(op);
        }

        public void Delete(string Id)
        {
            objDb.Delete(Id);
        }

        public void Update(tblWithdrawal op)
        {
            objDb.Update(op);
        }

    }
}
