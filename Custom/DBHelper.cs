using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MPS.Custom
{
    public class DbHelperSQL
    {
        protected static string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public DbHelperSQL()
        {
        }

       
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataTable</returns>
        public static DataTable Query(string SQLString, List<SqlParameter> Parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = SQLString;
                    comm.Connection = connection;
                    foreach (var item in Parameters)
                    {
                        comm.Parameters.Add(item);
                    }
                    SqlDataAdapter command = new SqlDataAdapter(comm);
                    command.Fill(ds, "ds");
                    comm.Parameters.Clear();
                    return ds.Tables[0];
                }
                catch (System.Data.SqlClient.SqlException ex)
                {                    
                    throw new Exception(ex.Message);
                }
                finally {
                   
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static DataSet QueryDataSet(string SQLString, List<SqlParameter> Parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = SQLString;
                    comm.Connection = connection;
                    foreach (var item in Parameters)
                    {
                        comm.Parameters.Add(item);
                    }
                    SqlDataAdapter command = new SqlDataAdapter(comm);
                    comm.CommandTimeout = 180;
                    command.Fill(ds, "ds");
                    comm.Parameters.Clear();
                    return ds;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw ex;// new Exception(ex.Message);
                }
                finally
                {

                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static int QueryCount(string SQLString, List<SqlParameter> Parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    DataSet ds = new DataSet();
                    connection.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = SQLString;
                    comm.Connection = connection;
                    foreach (var item in Parameters)
                    {
                        comm.Parameters.Add(item);
                    }
                    SqlDataAdapter command = new SqlDataAdapter(comm);
                    command.Fill(ds, "ds");
                    DataTable dt = ds.Tables[0];
                    comm.Parameters.Clear();
                    return dt.Rows.Count;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static int QueryCountOnly(string SQLString, List<SqlParameter> Parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    DataSet ds = new DataSet();
                    connection.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = SQLString;
                    comm.Connection = connection;
                    foreach (var item in Parameters)
                    {
                        comm.Parameters.Add(item);
                    }
                    SqlDataAdapter command = new SqlDataAdapter(comm);
                    command.Fill(ds, "ds");
                    DataTable dt = ds.Tables[0];
                    comm.Parameters.Clear();
                    return Convert.ToInt32(dt.Rows[0][0]);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet( string cmdText, params SqlParameter[] commandParameters)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, CommandType.StoredProcedure, cmdText, commandParameters);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                cmd.Parameters.Clear();
            }
            return ds;
        }
        /// <summary>
        /// 为执行命令准备参数
        /// </summary>
        /// <param name="cmd">SqlCommand 命令</param>
        /// <param name="conn">已经存在的数据库连接</param>
        /// <param name="trans">数据库事物处理</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
        /// <param name="cmdParms">返回带参数的命令</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open) // 判断数据库连接状态
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;

            if (trans != null) // 判断是否需要事物处理
                cmd.Transaction = trans;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}