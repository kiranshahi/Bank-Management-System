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
   public class ChqIssueBs
    {
        private ChqIssueDb objDb;

        public ChqIssueBs()
        {
            objDb = new ChqIssueDb();
        }

        public IEnumerable<tblChqIssue> GetAll()
        {
            return objDb.GetAll();
        }

        public DataTable showChqStartNo()
        {
            string sql = "select * from tblChqIssue";
            return DBO.GetTable(sql, null, CommandType.Text);
        }

        public tblChqIssue GetByID(string Id)
        {
            return objDb.GetByID(Id);
        }


        public IEnumerable GetChqDetailsByCustName(string custname)
        {
           return objDb.GetChqDetailsByCustName(custname);
        }

        public DataTable getChqIssueDetail(string custname)
        {
            string sql = "select * from tblchqNo where custName = @custNames";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@custNames", custname)
            };
            return DBO.GetTable(sql, param, CommandType.Text);
        }

        public void Insert(tblChqIssue users)
        {
            objDb.Insert(users);
        }

        public void Delete(string Id)
        {
            objDb.Delete(Id);
        }

        public void Update(tblChqIssue users)
        {
            objDb.Update(users);
        }

    }
}


