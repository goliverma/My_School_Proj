using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataProvider
{
    public class DataProvider : IDataProvider
    {
        private SqlConnection con;
        private DataTable dt;
        private SqlCommand cmd;
        public DataProvider()
        {
            con = new SqlConnection(Connnection.Connection());
        }

        public DataTable ConnectDataBase(string Procuder)
        {
            dt = new DataTable();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procuder;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }

        public DataTable ConnectDataBaseWithParam(Collection<SqlParameter> param, string Procuder)
        {
            dt = new DataTable();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procuder;
            if (param != null)
            {
                foreach (SqlParameter p in param)
                {
                    if (p != null)
                    {
                        if (p.Value == null)
                        {
                            p.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(p);
                    }
                }
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                con.Close();
                return dt;
            }
            return null;
        }

        public bool SaveDataEntity(Collection<SqlParameter> param, string Procuder)
        {
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procuder;
            if(param != null)
            {
                foreach (SqlParameter p in param)
                {
                    if(p != null)
                    {
                        if(p.Value == null)
                        {
                            p.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(p);
                    }
                }
                con.Open();
                if(cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                con.Close();
            }
            return false;
        }
    }
}
