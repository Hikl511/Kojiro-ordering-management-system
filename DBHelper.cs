using System.Data;
using System.Data.SqlClient;

namespace Kojiro_ordering_management_system
{
    internal class DBHelper
    {
        public static string CoonString = "server=.;database=Kojiror;uid=sa;pwd=1234";
        public static SqlConnection conn = null;
        public static void connt()
        {
            if (conn == null)
            {
                conn = new SqlConnection(CoonString);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }
        }
        //查
        public static SqlDataReader GDR(string sql)
        {
            connt();
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        //增删改
        public static bool ENQ(string sql)
        {
            connt();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }
        //聚合函数
        public static object ES(string sql)
        {
            connt();
            SqlCommand cmd = new SqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            conn.Close();
            return result;
        }
    }
}
