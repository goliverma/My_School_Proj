using Models.Models;
using Models.VM;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BAL.Repository.RepoClasses
{
    public class Linq : ILinq
    {
        SqlConnection con;
        DataTable dt;
        SqlCommand cmd;
        public Linq()
        {
            con = new SqlConnection(Connnection.Connection());
        }

        public List<City> GetCity(int sid)
        {
            var city = GetCities();
            return city.Where(c => c.Sid == sid).Select(c => new City()
            {
                CityId = (int)c.CityId,
                CityName = (string)c.CityName,
                Sid = (int)c.Sid
            }).ToList();
        }

        public List<Country> GetCountry()
        {
            var country = GetCountries();
            return country.Select(c => new Country()
            {
                Cid = (int)c.Cid,
                CName = (string)c.CName
            }).ToList();
        }

        public List<State> GetState(int cid)
        {
            var state = GetStates();
            return state.Where(s => s.Cid == cid)
                .Select(s => new State()
                {
                    Sid = (int)s.Sid,
                    SName = (string)s.SName,
                    Cid = (int)s.Cid
                }).ToList();
        }

        public List<StudentVM> resultByClassId(int schoolid, int classid)
        {
            var relation = GetRelations();
            var clas = GetClass();
            var school = GetSchool();
            var student = GetStudents();
            var result = GetResults();
            var data = student.Join(relation, st => st.Id, rel => rel.Id, (st, rel) => (rel, st))
                .Join(school, st => st.rel.SchoolId, sch => sch.SchoolId, (st, sch) => (st, st.rel, sch))
                .Join(clas, st => st.rel.ClassId, cl => cl.ClassId, (st, cl) => (st, st.rel, cl, st.sch))
                .Join(result, st => st.st.st.st.ResultId, rlt => rlt.ResultId, (st, rlt) => (st, st.rel, st.sch, st.cl, rlt))
                .Where(st => st.rel.SchoolId == schoolid && st.rel.ClassId == classid)
                .Select(st => new StudentVM()
                {
                    StudentId = (int)st.st.st.st.st.StudentId,
                    StudentName = (string)st.st.st.st.st.StudentName,
                    StudentRollNo = (long)st.st.st.st.st.StudentRollNo,
                    StudentAddress = (string)st.st.st.st.st.StudentAddress,
                    Percentage = (int)(st.rlt.English + st.rlt.Hindi + st.rlt.Math + st.rlt.Science) / 4
                })
                .ToList();
            return data;
        }

        public List<StudentVM> ResultBySchool(int schoolid)
        {
            var student = GetStudents();
            var school = GetSchool();
            var clas = GetClass();
            var relation = GetRelations();
            var result = GetResults();
            var data = student.Join(relation, st => st.Id, rel => rel.Id, (st, rel) => new { st, rel })
                .Join(school, stsh => stsh.rel.SchoolId, sch => sch.SchoolId, (stsh, sch) => new { stsh, sch })
                .Join(clas, stcl => stcl.stsh.rel.ClassId, cl => cl.ClassId, (stcl, cl) => new { stcl, cl })
                .Join(result, stres => stres.stcl.stsh.st.ResultId, res => res.ResultId, (stres, res) => new { stres, res })
                .Where(x => x.stres.stcl.sch.SchoolId == schoolid)
                .Select(x => new StudentVM()
                {
                    StudentId = (int)x.stres.stcl.stsh.st.StudentId,
                    StudentName = (string)x.stres.stcl.stsh.st.StudentName,
                    StudentRollNo = (long)x.stres.stcl.stsh.st.StudentRollNo,
                    StudentAddress = (string)x.stres.stcl.stsh.st.StudentAddress,
                    ClassId = (int)x.stres.cl.ClassId,
                    ClassName = (string)x.stres.cl.ClassName,
                    Percentage = (int)(x.res.English + x.res.Hindi + x.res.Math + x.res.Science) / 4
                })
                .ToList();
            return data;
        }

        public List<StudentVM> StudentByClassId(int schoolid, int classid)
        {
            var student = GetStudents();
            var school = GetSchool();
            var clas = GetClass();
            var relation = GetRelations();
            var data = student.Join(relation, st => st.Id, rel => rel.Id, (st, rel) => new { st, rel })
                .Join(school, stsch => stsch.rel.SchoolId, sch => sch.SchoolId, (stsch, sch) => new { stsch, sch })
                .Join(clas, stcl => stcl.stsch.rel.ClassId, cl => cl.ClassId, (stcl, cl) => new { stcl, cl })
                .Where(x => x.cl.ClassId == classid && x.stcl.sch.SchoolId == schoolid)
                .Select(x => new StudentVM()
                {
                    StudentId = (int)x.stcl.stsch.st.StudentId,
                    StudentName = (string)x.stcl.stsch.st.StudentName,
                    StudentRollNo = (long)x.stcl.stsch.st.StudentRollNo,
                    StudentAddress = (string)x.stcl.stsch.st.StudentAddress
                })
                .ToList();
            return data;
        }

        public StudentVM StudentById(int sid)
        {
            var student = GetStudents();
            var clas = GetClass();
            var relation = GetRelations();
            var result = GetResults();
            var data = student.Join(relation, st => st.Id, rel => rel.Id, (st, rel) => new { st, rel })
                .Join(clas, stcl => stcl.rel.ClassId, cl => cl.ClassId, (stcl, cl) => new { stcl, cl })
                .Join(result, stre => stre.stcl.st.ResultId, re => re.ResultId, (stre, re) => new { stre, re })
                .Where(x => x.stre.stcl.st.StudentId == sid)
                .Select(x => new StudentVM()
                {
                    StudentId = (int)x.stre.stcl.st.StudentId,
                    StudentName = (string)x.stre.stcl.st.StudentName,
                    ClassName = (string)x.stre.cl.ClassName,
                    StudentRollNo = (long)x.stre.stcl.st.StudentRollNo,
                    StudentAddress = (string)x.stre.stcl.st.StudentAddress,
                    Percentage = (int)(x.re.English + x.re.Hindi + x.re.Math + x.re.Science) / 4
                })
                .FirstOrDefault();
            return data;
        }

        public List<StudentVM> StudentBySchool(int schoolid)
        {
            var student = GetStudents();
            var school = GetSchool();
            var country = GetCountries();
            var state = GetStates();
            var city = GetCities();
            var clas = GetClass();
            var relation = GetRelations();
            var data = student.Join(relation, st => st.Id, rel => rel.Id, (st, rel) => new { st, rel })
                .Join(school, stsch => stsch.rel.SchoolId, sch => sch.SchoolId, (stsch, sch) => new { stsch, sch })
                .Join(clas, stcl => stcl.stsch.rel.ClassId, cl => cl.ClassId, (stcl, cl) => new { stcl, cl })
                .Join(country, stc => stc.stcl.stsch.st.Cid, c => c.Cid, (stc, c) => new { stc, c })
                .Join(state, sts => sts.stc.stcl.stsch.st.Sid, s => s.Sid, (sts, s) => new { sts, s })
                .Join(city, stcity => stcity.sts.stc.stcl.stsch.st.CityId, city => city.CityId, (stcity, city) => new { stcity, city })
                .Where(x => x.stcity.sts.stc.stcl.sch.SchoolId == schoolid)
                .Select(x => new StudentVM()
                {
                    StudentId = (int)x.stcity.sts.stc.stcl.stsch.st.StudentId,
                    StudentName = (string)x.stcity.sts.stc.stcl.stsch.st.StudentName,
                    StudentRollNo = (long)x.stcity.sts.stc.stcl.stsch.st.StudentRollNo,
                    StudentAddress = (string)x.stcity.sts.stc.stcl.stsch.st.StudentAddress,
                    SchoolName = (string)x.stcity.sts.stc.stcl.sch.SchoolName,
                    ClassName = (string)x.stcity.sts.stc.cl.ClassName,
                    ClassId = (int)x.stcity.sts.stc.cl.ClassId,
                    Cid = (int)x.stcity.sts.c.Cid,
                    Sid = (int)x.stcity.s.Sid,
                    CityId = (int)x.city.CityId
                })
                .OrderBy(x => x.ClassId)
                .ToList();
            return data;
        }
        #region Datatable code

        public List<City> GetCities()
        {
            dt = new DataTable();
            List<City> cities = new List<City>();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from City";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                City c = new City
                {
                    CityId = (int)dt.Rows[i]["CityId"],
                    CityName = (string)dt.Rows[i]["CityName"],
                    Sid = (int)dt.Rows[i]["Sid"]
                };
                cities.Add(c);
            }
            return cities;
        }

        public List<Classes> GetClass()
        {
            dt = new DataTable();
            List<Classes> cities = new List<Classes>();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Classes";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Classes c = new Classes
                {
                    ClassId = (int)dt.Rows[i]["ClassId"],
                    ClassName = (string)dt.Rows[i]["ClassName"]
                };
                cities.Add(c);
            }
            return cities;
        }

        public List<Country> GetCountries()
        {
            dt = new DataTable();
            List<Country> cities = new List<Country>();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Country";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Country c = new Country
                {
                    Cid = (int)dt.Rows[i]["Cid"],
                    CName = (string)dt.Rows[i]["CName"]
                };
                cities.Add(c);
            }
            return cities;
        }

        public List<Relations> GetRelations()
        {
            dt = new DataTable();
            List<Relations> cities = new List<Relations>();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from relation";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Relations c = new Relations
                {
                    Id = (int)dt.Rows[i]["Id"],
                    ClassId = (int)dt.Rows[i]["ClassId"],
                    SchoolId = (int)dt.Rows[i]["SchoolId"]
                };
                cities.Add(c);
            }
            return cities;
        }

        public List<Results> GetResults()
        {
            dt = new DataTable();
            List<Results> cities = new List<Results>();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Results";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Results c = new Results
                {
                    ResultId = (int)dt.Rows[i]["ResultId"],
                    StudentId = (int)dt.Rows[i]["StudentId"],
                    English = (int)dt.Rows[i]["English"],
                    Math = (int)dt.Rows[i]["Math"],
                    Hindi = (int)dt.Rows[i]["Hindi"],
                    Science = (int)dt.Rows[i]["Science"]
                };
                cities.Add(c);
            }
            return cities;
        }

        public List<School> GetSchool()
        {
            dt = new DataTable();
            List<School> cities = new List<School>();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from schools";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                School c = new School
                {
                    SchoolId = (int)dt.Rows[i]["SchoolId"],
                    SchoolName = (string)dt.Rows[i]["SchoolName"],
                    SchoolEmail = (string)dt.Rows[i]["SchoolEmail"],
                    SchoolAddress = (string)dt.Rows[i]["SchoolAddress"]
                };
                cities.Add(c);
            }
            return cities;
        }

        public List<State> GetStates()
        {
            dt = new DataTable();
            List<State> cities = new List<State>();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from States";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                State c = new State
                {
                    Sid = (int)dt.Rows[i]["Sid"],
                    Cid = (int)dt.Rows[i]["Cid"],
                    SName = (string)dt.Rows[i]["SName"]
                };
                cities.Add(c);
            }
            return cities;
        }

        public List<Student> GetStudents()
        {
            dt = new DataTable();
            List<Student> cities = new List<Student>();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Students";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student c = new Student
                {
                    StudentId = (int)dt.Rows[i]["StudentId"],
                    StudentName = (string)dt.Rows[i]["StudentName"],
                    StudentRollNo = (long)dt.Rows[i]["StudentRollNo"],
                    StudentAddress = (string)dt.Rows[i]["StudentAddress"],
                    Id = (int)dt.Rows[i]["Id"],
                    ResultId = (int)dt.Rows[i]["ResultId"],
                    Cid = (int)dt.Rows[i]["Cid"],
                    Sid = (int)dt.Rows[i]["Sid"],
                    CityId = (int)dt.Rows[i]["CityId"],
                };
                cities.Add(c);
            }
            return cities;
        }

        #endregion
    }
}
