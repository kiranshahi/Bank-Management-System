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
   public class OpenActBs
    {
        private OpenActDb objDb;

        public OpenActBs()
        {
            objDb = new OpenActDb();
        }

        public IEnumerable<tblOpenAct> GetAll()
        {
            return objDb.GetAll();
        }

        public string GetByID(string op)
        {
            return objDb.GetByID(op);
        }

        public void Insert(tblOpenAct op)
        {
            objDb.Insert(op);
        }

        public void Delete(string Id)
        {
            objDb.Delete(Id);
        }

        public void Update(tblOpenAct op)
        {
            objDb.Update(op);
        }

        public DataTable showBankDetails()
        {
            string sql = "spShowBankDetails";
            return DBO.GetTable(sql, null, CommandType.StoredProcedure);
        }

        public DataTable showaccno()
        {
            string sql = "select top 1 openActId from tblOpenAct order by openActId desc";
            return DBO.GetTable(sql, null, CommandType.Text);
        }

        public DataTable showCustDetails()
        {
            string sql = "spLoadCustAct";
            return DBO.GetTable(sql, null, CommandType.StoredProcedure);
        }

        public DataTable showCustDetailsById(int id)
        {
            string sql = "spLoadCustActByAccNo";
            SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@id",id)
            };
            return DBO.GetTable(sql, param, CommandType.StoredProcedure);
        }

        public DataTable showCustDetailsByName(string name)
        {
            string sql = "spLoadCustActByCustName";
            SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@name",name+"%")
            };
            return DBO.GetTable(sql, param, CommandType.StoredProcedure);
        }

        public int createAccount(string branchname, string acttype, string actapproveby, string custname, DateTime dob, DateTime openingdate, string accno, decimal openingbalance, decimal currentbalance, string nomineename, string nomineerelation, string photo)
        {
            string sql = "spInsertCustAct";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@a",branchname),
                new SqlParameter("@b",acttype),
                new SqlParameter("@c",actapproveby),
                new SqlParameter("@d",custname),
                new SqlParameter("@e",dob),
                new SqlParameter("@f",openingdate),
                new SqlParameter("@g",accno),
                new SqlParameter("@h",openingbalance),
                new SqlParameter("@i",currentbalance),
                new SqlParameter("@j",nomineename),
                new SqlParameter("@k",nomineerelation),
                new SqlParameter("@l",photo)
            };
            return DBO.IUD(sql, param, CommandType.StoredProcedure);
        }

        public int updateAccount(string branchname, string acttype, string actapproveby, string custname, DateTime dob, DateTime openingdate, decimal openingbalance, decimal currentbalance, string nomineename, string nomineerelation, string photo, int id)
        {
            string sql = "spUpdateCustAct";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@a",branchname),
                new SqlParameter("@b",acttype),
                new SqlParameter("@c",actapproveby),
                new SqlParameter("@d",custname),
                new SqlParameter("@e",dob),
                new SqlParameter("@f",openingdate),
                new SqlParameter("@g",openingbalance),
                new SqlParameter("@h",currentbalance),
                new SqlParameter("@i",nomineename),
                new SqlParameter("@j",nomineerelation),
                new SqlParameter("@k",photo),
                new SqlParameter("@id",id)
            };
            return DBO.IUD(sql, param, CommandType.StoredProcedure);
        }

        public int deleteAccount(string acctno, int id)
        {
            string sql = "spDeleteCustAct";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@acctno", acctno),
                 new SqlParameter("@id",id)
            };
            return DBO.IUD(sql, param, CommandType.StoredProcedure);
        }



    }
}

