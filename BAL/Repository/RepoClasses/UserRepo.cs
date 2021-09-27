using BAL.Repository.Interfaces;
using DAL.DataProvider;
using Models.Models;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace BAL.Repository.RepoClasses
{
    public class UserRepo : IUserRepo
    {
        //SqlConnection con;
        //DataTable dt;
        //SqlCommand cmd;
        Collection<SqlParameter> param;
        IDataProvider context;
        public UserRepo()
        {
            //con = new SqlConnection(Connnection.Connection());
        }
        public User Login(User u)
        {
            //dt = new DataTable();
            //con.Open();
            //cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "sp_Login";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@username", u.UserName);
            //cmd.Parameters.AddWithValue("@userpass", u.UserPass);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            context = new DataProvider();
            param = new();
            param.Add(new SqlParameter("@username", u.UserName));
            param.Add(new SqlParameter("@userpass", u.UserPass));
            var data = context.ConnectDataBaseWithParam(param, "sp_Login");
            if (data.Rows.Count > 0)
            {
                User U = new User
                {
                    UserId = (int)data.Rows[0]["UserId"],
                    UserName = (string)data.Rows[0]["UserName"],
                    UserPass = (string)data.Rows[0]["UserPass"],
                    IsActive = (bool)data.Rows[0]["IsActive"],
                    UserRoles = (string)data.Rows[0]["RName"]
                };
                return U;
            }
            return null;
        }
    }
}
