using BAL.Repository.Interfaces;
using DAL.DataProvider;
using Models.Models;
using Models.VM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BAL.Repository.RepoClasses
{
    public class StudentRepo : IStudentRepo
    {
        //public readonly SqlConnection con;
        //DataTable dt;
        //SqlCommand cmd;
        IDataProvider context;
        Collection<SqlParameter> param;

        public StudentRepo()
        {
            //con = new SqlConnection(Connnection.Connection());
        }

        public List<Classes> Classes()
        {
            context = new DataProvider();
            //dt = new DataTable();
            List<Classes> cl = new();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_ClassList",
            //    CommandType = CommandType.StoredProcedure
            //};
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            var data = context.ConnectDataBase("sp_ClassList");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Classes c = new()
                {
                    ClassId = (int)data.Rows[i]["ClassId"],
                    ClassName = (string)data.Rows[i]["ClassName"]
                };
                cl.Add(c);
            }
            return cl;
        }

        public bool DeleteStu(int sid)
        {
            context = new DataProvider();
            bool rdata = false;
            //dt = new DataTable();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_DeleteStudent",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@sid", sid);
            //if(cmd.ExecuteNonQuery()>0)
            //{
            //    return true;
            //}
            //con.Close();
            param = new();
            param.Add(new SqlParameter("@sid", sid));
            if (context.SaveDataEntity(param, "sp_DeleteStudent"))
            {
                rdata = true;
            }
            return rdata;
        }

        public StudentVM EditStudentById(int sid)
        {
            context = new DataProvider();
            //dt = new DataTable();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_edit",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@id", sid);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            param = new();
            param.Add(new SqlParameter("@id", sid));
            var dt = context.ConnectDataBaseWithParam(param, "sp_edit");
            StudentVM s = new()
            {
                StudentId = (int)dt.Rows[0]["StudentId"],
                StudentName = (string)dt.Rows[0]["StudentName"],
                StudentAddress = (string)dt.Rows[0]["StudentAddress"],
                StudentRollNo = (long)dt.Rows[0]["StudentRollNo"],
                ClassId = (int)dt.Rows[0]["ClassId"],
                Sid = (int)dt.Rows[0]["Sid"],
                Cid = (int)dt.Rows[0]["Cid"],
                CityId = (int)dt.Rows[0]["CityId"]
            };
            return s;
        }

        public List<City> GetCity(int sid)
        {
            List<City> cl = new();
            //dt = new DataTable();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_getcitybyId",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@sid", sid);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            context = new DataProvider();
            param = new();
            param.Add(new SqlParameter("@sid", sid));
            var dt = context.ConnectDataBaseWithParam(param, "sp_getcitybyId");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                City c = new()
                {
                    CityId = (int)dt.Rows[i]["CityId"],
                    CityName = (string)dt.Rows[i]["CityName"],
                    Sid = (int)dt.Rows[i]["Sid"]
                };
                cl.Add(c);
            }
            return cl;
        }

        public List<Country> GetCountry()
        {
            List<Country> cl = new();
            //dt = new DataTable();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_Country",
            //    CommandType = CommandType.StoredProcedure
            //};
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            context = new DataProvider();
            var dt = context.ConnectDataBase("sp_Country");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Country c = new()
                {
                    Cid = (int)dt.Rows[i]["Cid"],
                    CName = (string)dt.Rows[i]["CName"]
                };
                cl.Add(c);
            }
            return cl;
        }

        public List<State> GetState(int cid)
        {
            List<State> sl = new();
            //dt = new DataTable();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_State",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@id", cid);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            context = new DataProvider();
            param = new();
            param.Add(new SqlParameter("@id", cid));
            var dt = context.ConnectDataBaseWithParam(param, "sp_State");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                State s = new()
                {
                    Sid = (int)dt.Rows[i]["Sid"],
                    SName = (string)dt.Rows[i]["SName"],
                    Cid = (int)dt.Rows[i]["Cid"]
                };
                sl.Add(s);
            }
            return sl;
        }

        public bool InsertStudent(StudentVM st)
        {
            bool result = false;
            var r = relation(st.SchoolId, st.ClassId);
            st.Id = r.Id;
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_InsertStudent",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@Name", st.StudentName);
            //cmd.Parameters.AddWithValue("@Address", st.StudentAddress);
            //cmd.Parameters.AddWithValue("@RollNo", st.StudentRollNo);
            //cmd.Parameters.AddWithValue("@realtionId", st.Id);
            //cmd.Parameters.AddWithValue("@cid", st.Cid);
            //cmd.Parameters.AddWithValue("@sid", st.Sid);
            //cmd.Parameters.AddWithValue("@cityid", st.CityId);
            //if (cmd.ExecuteNonQuery() > 0)
            //{
            //    return true;
            //}
            //con.Close();
            context = new DataProvider();
            param = new();
            param.Add(new SqlParameter("@Name", st.StudentName));
            param.Add(new SqlParameter("@Address", st.StudentAddress));
            param.Add(new SqlParameter("@RollNo", st.StudentRollNo));
            param.Add(new SqlParameter("@realtionId", st.Id));
            param.Add(new SqlParameter("@cid", st.Cid));
            param.Add(new SqlParameter("@sid", st.Sid));
            param.Add(new SqlParameter("@cityid", st.CityId));
            if (context.SaveDataEntity(param, "sp_InsertStudent"))
            {
                result = true;
            }
            return result;
        }

        public Relations relation(int schoolid, int classid)
        {
            //dt = new DataTable();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_Relation",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@SchoolId", schoolid);
            //cmd.Parameters.AddWithValue("@ClassId", classid);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            context = new DataProvider();
            param = new();
            param.Add(new SqlParameter("@SchoolId", schoolid));
            param.Add(new SqlParameter("@ClassId", classid));
            var dt = context.ConnectDataBaseWithParam(param, "sp_Relation");
            Relations r = new()
            {
                Id = (int)dt.Rows[0]["Id"],
                SchoolId = (int)dt.Rows[0]["SchoolId"],
                ClassId = (int)dt.Rows[0]["ClassId"]
            };
            return r;
        }

        public List<StudentVM> resultByClassId(int schoolid, int classid)
        {
            //dt = new DataTable();
            List<StudentVM> st = new();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_StudentResultClassId",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@classId", classid);
            //cmd.Parameters.AddWithValue("@schoolId", schoolid);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            context = new DataProvider();
            param = new();
            param.Add(new SqlParameter("@classId", classid));
            param.Add(new SqlParameter("@schoolId", schoolid));
            var dt = context.ConnectDataBaseWithParam(param, "sp_StudentResultClassId");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentVM s = new()
                {
                    StudentId = (int)dt.Rows[i]["StudentId"],
                    StudentName = (string)dt.Rows[i]["StudentName"],
                    StudentRollNo = (long)dt.Rows[i]["StudentRollNo"],
                    StudentAddress = (string)dt.Rows[i]["StudentAddress"],
                    Percentage = (int)dt.Rows[i]["StudentResult"]
                };
                st.Add(s);
            }
            return st;
        }

        public List<StudentVM> ResultBySchool(int schoolid)
        {
            //dt = new DataTable();
            List<StudentVM> st = new();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_StudentResultschoolId",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@schoolId", schoolid);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            context = new DataProvider();
            param = new();
            param.Add(new SqlParameter("@schoolId", schoolid));
            var dt = context.ConnectDataBaseWithParam(param, "sp_StudentResultschoolId");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentVM s = new()
                {
                    StudentId = (int)dt.Rows[i]["StudentId"],
                    StudentName = (string)dt.Rows[i]["StudentName"],
                    StudentRollNo = (long)dt.Rows[i]["StudentRollNo"],
                    StudentAddress = (string)dt.Rows[i]["StudentAddress"],
                    ClassId = (int)dt.Rows[i]["ClassId"],
                    ClassName = (string)dt.Rows[i]["ClassName"],
                    Percentage = (int)dt.Rows[i]["StudentResult"]
                };
                st.Add(s);
            }
            List<StudentVM> st1 = st.OrderBy(it => it.ClassId)
                .Select(it => new StudentVM()
                {
                    StudentId = it.StudentId,
                    StudentName = it.StudentName,
                    StudentRollNo = it.StudentRollNo,
                    StudentAddress = it.StudentAddress,
                    ClassName = it.ClassName,
                    Percentage = it.Percentage
                })
                .ToList();
            return st1;
        }

        public School School(int id)
        {
            //dt = new DataTable();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_SchoolById",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@id", id);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            context = new DataProvider();
            param = new();
            param.Add(new SqlParameter("@id", id));
            var dt = context.ConnectDataBaseWithParam(param, "sp_SchoolById");
            School st = new()
            {
                SchoolId = (int)dt.Rows[0]["SchoolId"],
                SchoolName = (string)dt.Rows[0]["SchoolName"],
                SchoolEmail = (string)dt.Rows[0]["SchoolEmail"],
                SchoolAddress = (string)dt.Rows[0]["SchoolAddress"]
            };
            return st;
        }

        public List<School> Schools()
        {
            List<School> st = new();
            //dt = new DataTable();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_SchoolList",
            //    CommandType = CommandType.StoredProcedure
            //};
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            context = new DataProvider();
            var data = context.ConnectDataBase("sp_SchoolList");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                School s = new()
                {
                    SchoolId = (int)data.Rows[i]["SchoolId"],
                    SchoolName = (string)data.Rows[i]["SchoolName"],
                    SchoolEmail = (string)data.Rows[i]["SchoolEmail"],
                    SchoolAddress = (string)data.Rows[i]["SchoolAddress"]
                };
                st.Add(s);
            }
            return st;
        }

        public List<StudentVM> StudentByClassId(int schoolid, int classid)
        {
            //dt = new DataTable();
            List<StudentVM> st = new();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_StudentByClassId",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@classId", classid);
            //cmd.Parameters.AddWithValue("@schoolId", schoolid);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            context = new DataProvider();
            param = new();
            param.Add(new SqlParameter("@classId", classid));
            param.Add(new SqlParameter("@schoolId", schoolid));
            var dt = context.ConnectDataBaseWithParam(param, "sp_StudentByClassId");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentVM s = new()
                {
                    StudentId = (int)dt.Rows[i]["StudentId"],
                    StudentName = (string)dt.Rows[i]["StudentName"],
                    StudentRollNo = (long)dt.Rows[i]["StudentRollNo"],
                    StudentAddress = (string)dt.Rows[i]["StudentAddress"]
                };
                st.Add(s);
            }
            return st;
        }

        public StudentVM StudentById(int sid)
        {
            //dt = new DataTable();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_StudentById",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@sid", sid);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            context = new DataProvider();
            param = new();
            param.Add(new SqlParameter("@sid", sid));
            var dt = context.ConnectDataBaseWithParam(param, "sp_StudentById");
            StudentVM s = new()
            {
                StudentId = (int)dt.Rows[0]["StudentId"],
                StudentName = (string)dt.Rows[0]["StudentName"],
                ClassName = (string)dt.Rows[0]["ClassName"],
                StudentRollNo = (long)dt.Rows[0]["StudentRollNo"],
                StudentAddress = (string)dt.Rows[0]["StudentAddress"],
                Percentage = dt.Rows[0]["StudentResult"].ToString() != "" ? (int)dt.Rows[0]["StudentResult"] : 0
            };
            return s;
        }

        public List<StudentVM> StudentBySchool(int schoolid)
        {
            List<StudentVM> st = new();
            //dt = new DataTable();
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_StudentBySchool",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@schoolId", schoolid);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //con.Close();
            context = new DataProvider();
            param = new();
            param.Add(new SqlParameter("@schoolId", schoolid));
            var dt = context.ConnectDataBaseWithParam(param, "sp_StudentBySchool");
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                StudentVM s = new()
                {
                    StudentId = (int)dt.Rows[i]["StudentId"],
                    StudentName = (string)dt.Rows[i]["StudentName"],
                    StudentRollNo = (long)dt.Rows[i]["StudentRollNo"],
                    StudentAddress = (string)dt.Rows[i]["StudentAddress"],
                    SchoolName = (string)dt.Rows[i]["SchoolName"],
                    ClassName = (string)dt.Rows[i]["ClassName"],
                    ClassId = (int)dt.Rows[i]["ClassId"],
                    Cid = (int)dt.Rows[i]["Cid"],
                    Sid = (int)dt.Rows[i]["Sid"],
                    CityId = (int)dt.Rows[i]["CityId"]

                };
                st.Add(s);
            }
            List<StudentVM> st1 = st.OrderBy(it => it.ClassId)
                .Select(it => new StudentVM()
                {
                    StudentId = it.StudentId,
                    StudentName = it.StudentName,
                    StudentRollNo = it.StudentRollNo,
                    StudentAddress = it.StudentAddress,
                    SchoolName = it.SchoolName,
                    ClassName = it.ClassName,
                    ClassId = it.ClassId,
                    Cid = it.Cid,
                    Sid = it.Sid,
                    CityId = it.CityId
                })
                 .ToList();
            return st1;
        }

        public bool UpdateStudent(StudentVM st)
        {
            bool result = false;
            var data = relation(st.SchoolId, st.ClassId);
            st.Id = data.Id;
            //con.Open();
            //cmd = new SqlCommand
            //{
            //    Connection = con,
            //    CommandText = "sp_UpdateStudent",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@id", st.StudentId);
            //cmd.Parameters.AddWithValue("@name", st.StudentName);
            //cmd.Parameters.AddWithValue("@address", st.StudentAddress);
            //cmd.Parameters.AddWithValue("@rollNo", st.StudentRollNo);
            //cmd.Parameters.AddWithValue("@relationid", data.Id);
            //cmd.Parameters.AddWithValue("@cid", st.Cid);
            //cmd.Parameters.AddWithValue("@sid", st.Sid);
            //cmd.Parameters.AddWithValue("@cityid", st.CityId);
            //if (cmd.ExecuteNonQuery()>0)
            //{
            //    return true;
            //}
            context = new DataProvider();
            param = new();
            param.Add(new SqlParameter("@id", st.StudentId));
            param.Add(new SqlParameter("@name", st.StudentName));
            param.Add(new SqlParameter("@address", st.StudentAddress));
            param.Add(new SqlParameter("@rollNo", st.StudentRollNo));
            param.Add(new SqlParameter("@relationid", st.Id));
            param.Add(new SqlParameter("@cid", st.Cid));
            param.Add(new SqlParameter("@sid", st.Sid));
            param.Add(new SqlParameter("@cityid", st.CityId));
            if (context.SaveDataEntity(param, "sp_UpdateStudent"))
            {
                result = true;
            }
            return result;
        }
    }
}
