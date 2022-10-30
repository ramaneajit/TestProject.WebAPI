using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TestProject.WebAPI.Models;
using System.Linq;

namespace TestProject.WebAPI.DataServices
{
    public class DataAccess
    {

        private readonly IConfiguration _config;

        public DataAccess(IConfiguration config)
        {
            _config = config;
        }

        public string GetConnectionstring()
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");
            return connectionString;
        }

        public DataTable GetDataTable(string command)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string connetionString = GetConnectionstring();
                var conn = new MySqlConnection(connetionString);
                MySqlCommand cmd = new MySqlCommand(command, conn);
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
                conn.Close();

                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
            }

            return dt;
        }

        public bool InsertOrUpdateOrDeleteData(string command)
        {
            try
            {
                string connetionString = GetConnectionstring();
                var conn = new MySqlConnection(connetionString);
                MySqlCommand cmd = new MySqlCommand(command, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public List<User> GetUsersList(DataTable usersDt)
        {
            List<User> users = new List<User>();
            if (usersDt != null && usersDt.Rows.Count > 0)
            {
                users = (from DataRow dr in usersDt.Rows
                         select new User()
                         {
                             Id = Convert.ToInt32(dr["Id"]),
                             Name = dr["Name"] != null ? Convert.ToString(dr["Name"]) : string.Empty,
                             EmailAddress = dr["EmailAddress"] != null ? Convert.ToString(dr["EmailAddress"]) : string.Empty,
                             Expenses = dr["MonthlyExpenses"] != null ? Convert.ToInt32(dr["MonthlyExpenses"]) : 0,
                             Salary = dr["MonthlySalary"] != null ? Convert.ToInt32(dr["MonthlySalary"]) : 0,
                         }).ToList();
            }
            return users;
        }
    }
}
