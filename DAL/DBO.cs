using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DAL
{
    public class DBO
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }

        public static int IUD(string sql, SqlParameter[] param, CommandType cmdType)
        {
            using (SqlConnection con = GetConnection())
            {

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = cmdType;

                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                try
                {

                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }
        public static DataTable GetTable(string sql, SqlParameter[] param, CommandType cmdType)
        {
            using (SqlConnection con = GetConnection())
            {

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;

                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;

                }
            }
        }
    }
}
