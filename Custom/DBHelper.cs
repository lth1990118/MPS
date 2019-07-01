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
    }
}