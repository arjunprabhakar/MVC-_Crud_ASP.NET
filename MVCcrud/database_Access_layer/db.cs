using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MVCcrud.Models;

namespace MVCcrud.database_Access_layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);


        public void Add_record(Employee emp)
        {
            SqlCommand com = new SqlCommand("Sp_employee_add", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Empname",emp.Empname);
            com.Parameters.AddWithValue("@Email",emp.Email);
            com.Parameters.AddWithValue("@Salary",emp.Salary);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Update_record(Employee emp)
        {
            SqlCommand com = new SqlCommand("Sp_employee_update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", emp.Empid);
            com.Parameters.AddWithValue("@Empname", emp.Empname);
            com.Parameters.AddWithValue("@Email", emp.Email);
            com.Parameters.AddWithValue("@Salary", emp.Salary);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public DataSet Show_recod_byid(int Empid)
        {
            SqlCommand com = new SqlCommand("Sp_employee_id",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id",Empid);
            SqlDataAdapter da=new SqlDataAdapter(com);
            DataSet ds=new DataSet();
            da.Fill(ds);
            return ds;

        }

        public DataSet Show_data()
        {
            SqlCommand com = new SqlCommand("Sp_employee_All", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public void delete_record(int Empid)
        {
            SqlCommand com = new SqlCommand("Sp_employee_delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id",Empid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

    }
}