using Microsoft.Data.SqlClient;
using School_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Database
{
    class Data
    {
        string connectionString = "Server=BT1704547\\MSSQLSERVER01; Database=StatisticsDB; Integrated Security=true;";

        public List<StudentModel> Get()
        {
            List<StudentModel> users = new List<StudentModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from [StudentModel]", con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    StudentModel user = new StudentModel();
                    user.ID = Convert.ToInt32(rdr["ID"]);
                    user.Age = Convert.ToInt32(rdr["Age"]);
                    user.Name = rdr["Name"].ToString();
                    user.Class = rdr["Class"].ToString();
                    user.OOPS_Marks = Convert.ToInt32(rdr["OOPS_Marks"]);
                    user.C_Marks = Convert.ToInt32(rdr["C_Marks"]);

                    users.Add(user);
                }
                con.Close();
            }
            return users;
        }
        public List<SubjectModel> Get2()
        {
            List<SubjectModel> users = new List<SubjectModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from [SubjectModel]", con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SubjectModel user = new SubjectModel();
                    user.ID = Convert.ToInt32(rdr["ID"]);

                    user.Name = rdr["Name"].ToString();
                   

                    users.Add(user);
                }
                con.Close();
            }
            return users;
        }

    }
}
