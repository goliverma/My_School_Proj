using BAL.Repository.Interfaces;
using Models.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BAL.Repository.RepoClasses
{
    public class UserRepo : IUserRepo
    {
        SqlConnection con;
        DataTable dt;
        SqlCommand cmd;
        public UserRepo()
        {
            con = new SqlConnection(Connnection.Connection());
        }
        public User Login(User u)
        {
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_Login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", u.UserName);
            cmd.Parameters.AddWithValue("@userpass", u.UserPass);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            if(dt.Rows.Count > 0)
            {
                User U = new User
                {
                    UserId = (int)dt.Rows[0]["UserId"],
                    UserName = (string)dt.Rows[0]["UserName"],
                    UserPass = (string)dt.Rows[0]["UserPass"],
                    IsActive = (bool)dt.Rows[0]["IsActive"],
                    UserRoles = (string)dt.Rows[0]["RName"]
                };
                return U;
            }
            return null;
        }
    }
}
