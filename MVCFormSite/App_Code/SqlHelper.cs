using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// SqlHelper 的摘要说明
/// </summary>
public class SqlHelper
{
    public static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    }  
  
    /// <summary>  
    /// 执行查询并将结果返回至DataTable中  
    /// </summary>  
    /// <param name="strSql">查询语句</param>  
    /// <param name="parameters">可能带的参数</param>  
    /// <returns>返回一张查询结果表</returns>  
    public static DataTable ExecuteDataTable(string strSql, params SqlParameter[] parameters)  
    {  
        using (SqlConnection conn = new SqlConnection(GetConnectionString()))  
        {  
            conn.Open();  
            using (SqlCommand cmd = new SqlCommand())  
            {  
                cmd.Connection = conn;  
                cmd.CommandText = strSql;  
                foreach (SqlParameter p in parameters)  
                {  
                    cmd.Parameters.Add(p);  
                }  
                DataSet ds = new DataSet();  
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))  
                {  
                    adapter.Fill(ds);  
                    return ds.Tables[0];  
                }  
            }  
        }  
    }  
  
    /// <summary>  
    /// (重载)执行查询并将结果返回至DataTable中  
    /// </summary>  
    /// <param name="strSql">查询语句</param>  
    /// <returns>返回一张查询结果表</returns>  
    public static DataTable ExecuteDataTable(string strSql)  
    {  
        using (SqlConnection conn = new SqlConnection(GetConnectionString()))  
        {  
            conn.Open();  
            using (SqlCommand cmd = new SqlCommand())  
            {  
                cmd.Connection = conn;  
                cmd.CommandText = strSql;  
                DataSet ds = new DataSet();  
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))  
                {  
                    adapter.Fill(ds);  
                    return ds.Tables[0];  
                }  
            }  
        }  
    }  
  
  
    /// <summary>  
    /// 执行对数据的增删改操作  
    /// </summary>  
    /// <param name="strSql"></param>  
    /// <param name="parameters"></param>  
    public static int ExecuteNonQuery(string strSql, params SqlParameter[] parameters)  
    {
        int rownum = 0;
        using (SqlConnection conn = new SqlConnection(GetConnectionString()))  
        {  
            conn.Open();  
            using (SqlCommand cmd = new SqlCommand())  
            {  
                cmd.Connection = conn;  
                cmd.CommandText = strSql;  
                foreach (SqlParameter p in parameters)  
                {  
                    cmd.Parameters.Add(p);  
                }
                rownum = cmd.ExecuteNonQuery();  
            }  
        }
        return rownum;
    }  
  
    /// <summary>  
    /// (重载)执行对数据的增删改操作  
    /// </summary>  
    /// <param name="strSql">查询语句</param>  
    public static void ExecuteNonQuery(string strSql)  
    {  
        using (SqlConnection conn = new SqlConnection(GetConnectionString()))  
        {  
            conn.Open();  
            using (SqlCommand cmd = new SqlCommand())  
            {  
                cmd.Connection = conn;  
                cmd.CommandText = strSql;  
                cmd.ExecuteNonQuery();  
            }  
        }  
    }  
  
    /// <summary>  
    /// 执行查询并返回结果集中第一行第一列的值  
    /// </summary>  
    /// <param name="strSql"></param>  
    /// <param name="parameters"></param>  
    /// <returns></returns>  
    public static object ExecuteScalar(string strSql, params SqlParameter[] parameters)  
    {  
        using (SqlConnection conn = new SqlConnection(GetConnectionString()))  
        {  
            conn.Open();  
            using (SqlCommand cmd = new SqlCommand())  
            {  
                cmd.Connection = conn;  
                cmd.CommandText = strSql;  
                foreach (SqlParameter p in parameters)  
                {  
                    cmd.Parameters.Add(p);  
                }  
                return cmd.ExecuteScalar();  
            }  
        }  
    }  
  
    /// <summary>  
    /// (重载)执行查询并返回结果集中第一行第一列的值  
    /// </summary>  
    /// <param name="strSql">查询语句</param>  
    /// <returns></returns>  
    public static object ExecuteScalar(string strSql)  
    {  
        using (SqlConnection conn = new SqlConnection(GetConnectionString()))  
        {  
            conn.Open();  
            using (SqlCommand cmd = new SqlCommand())  
            {  
                cmd.Connection = conn;  
                cmd.CommandText = strSql;  
                return cmd.ExecuteScalar();  
            }  
        }  
    }  
}
