using BAL.Repository.Interfaces;
using Models.Models;
using Models.VM;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BAL.Repository.RepoClasses
{
    public class StudentRepo : IStudentRepo
    {
        SqlConnection con;
        DataTable dt;
        SqlCommand cmd;
        public StudentRepo()
        {
            con = new SqlConnection(Connnection.Connection());
        }

        public List<Classes> Classes()
        {
            dt = new DataTable();
            List<Classes> cl = new List<Classes>();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_ClassList";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for(int i=0; i < dt.Rows.Count; i++)
            {
                Classes c = new Classes
                {
                    ClassId = (int)dt.Rows[i]["ClassId"],
                    ClassName = (string)dt.Rows[i]["ClassName"]
                };
                cl.Add(c);
            }
            return cl;
        }

        public bool DeleteStu(int sid)
        {
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_DeleteStudent";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", sid);
            if(cmd.ExecuteNonQuery()>0)
            {
                return true;
            }
            con.Close();
            return false;
        }

        public StudentVM EditStudentById(int sid)
        {
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_edit";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", sid);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            StudentVM s = new StudentVM
            {
                StudentId = (int)dt.Rows[0]["StudentId"],
                StudentName = (string)dt.Rows[0]["StudentName"],
                StudentAddress = (string)dt.Rows[0]["StudentAddress"],
                StudentRollNo = (long)dt.Rows[0]["StudentRollNo"],
                ClassId = (int)dt.Rows[0]["ClassId"],
                Sid = (int)dt.Rows[0]["Sid"],
                Cid= (int)dt.Rows[0]["Cid"],
                CityId= (int)dt.Rows[0]["CityId"]
            };
            return s;
        }

        public List<City> GetCity(int sid)
        {
            List<City> cl = new List<City>();
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_getcitybyId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", sid);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for(int i=0; i < dt.Rows.Count; i++)
            {
                City c = new City
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
            List<Country> cl = new List<Country>();
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_Country";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for(int i=0; i<dt.Rows.Count; i++)
            {
                Country c = new Country
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
            List<State> sl = new List<State>();
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_State";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", cid);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for(int i=0; i < dt.Rows.Count; i++)
            {
                State s = new State
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
            var r = relation(st.SchoolId, st.ClassId);
            st.Id = r.Id;
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_InsertStudent";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", st.StudentName);
            cmd.Parameters.AddWithValue("@Address", st.StudentAddress);
            cmd.Parameters.AddWithValue("@RollNo", st.StudentRollNo);
            cmd.Parameters.AddWithValue("@realtionId", st.Id);
            cmd.Parameters.AddWithValue("@cid", st.Cid);
            cmd.Parameters.AddWithValue("@sid", st.Sid);
            cmd.Parameters.AddWithValue("@cityid", st.CityId);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            con.Close();
            return false;
        }

        public Relations relation(int schoolid, int classid)
        {
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_Relation";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SchoolId", schoolid);
            cmd.Parameters.AddWithValue("@ClassId", classid);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            Relations r = new Relations
            {
                Id = (int)dt.Rows[0]["Id"],
                SchoolId = (int)dt.Rows[0]["SchoolId"],
                ClassId = (int)dt.Rows[0]["ClassId"]
            };
            return r;
        }

        public List<StudentVM> resultByClassId(int schoolid, int classid)
        {
            dt = new DataTable();
            List<StudentVM> st = new List<StudentVM>();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_StudentResultClassId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@classId", classid);
            cmd.Parameters.AddWithValue("@schoolId", schoolid);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                StudentVM s = new StudentVM
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
            dt = new DataTable();
            List<StudentVM> st = new List<StudentVM>();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_StudentResultschoolId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@schoolId", schoolid);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                StudentVM s = new StudentVM
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
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_SchoolById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            School st = new School
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
            List<School> st = new List<School>();
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_SchoolList";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for(int i=0; i < dt.Rows.Count; i++)
            {
                School s = new School
                {
                    SchoolId = (int)dt.Rows[i]["SchoolId"],
                    SchoolName = (string)dt.Rows[i]["SchoolName"],
                    SchoolEmail = (string)dt.Rows[i]["SchoolEmail"],
                    SchoolAddress = (string)dt.Rows[i]["SchoolAddress"]
                };
                st.Add(s);
            }
            return st;
        }

        public List<StudentVM> StudentByClassId(int schoolid, int classid)
        {
            dt = new DataTable();
            List<StudentVM> st = new List<StudentVM>();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_StudentByClassId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@classId", classid);
            cmd.Parameters.AddWithValue("@schoolId", schoolid);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                StudentVM s = new StudentVM
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
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_StudentById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", sid);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            StudentVM s = new StudentVM
            {
                StudentId = (int)dt.Rows[0]["StudentId"],
                StudentName = (string)dt.Rows[0]["StudentName"],
                ClassName = (string)dt.Rows[0]["ClassName"],
                StudentRollNo = (long)dt.Rows[0]["StudentRollNo"],
                StudentAddress= (string)dt.Rows[0]["StudentAddress"],
                Percentage = (int)dt.Rows[0]["StudentResult"]
            };
            return s;
        }

        public List<StudentVM> StudentBySchool(int schoolid)
        {
            List<StudentVM> st = new List<StudentVM>();
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_StudentBySchool";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@schoolId", schoolid);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for(var i=0; i < dt.Rows.Count; i++)
            {
                StudentVM s = new StudentVM
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
            var data = relation(st.SchoolId, st.ClassId);
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_UpdateStudent";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", st.StudentId);
            cmd.Parameters.AddWithValue("@name", st.StudentName);
            cmd.Parameters.AddWithValue("@address", st.StudentAddress);
            cmd.Parameters.AddWithValue("@rollNo", st.StudentRollNo);
            cmd.Parameters.AddWithValue("@relationid", data.Id);
            cmd.Parameters.AddWithValue("@cid", st.Cid);
            cmd.Parameters.AddWithValue("@sid", st.Sid);
            cmd.Parameters.AddWithValue("@cityid", st.CityId);
            if (cmd.ExecuteNonQuery()>0)
            {
                return true;
            }
            return false;
        }
    }
}
