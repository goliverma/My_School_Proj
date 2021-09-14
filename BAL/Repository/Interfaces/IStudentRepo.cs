using Models.Models;
using Models.VM;
using System.Collections.Generic;
using System.Data;

namespace BAL.Repository.Interfaces
{
    public interface IStudentRepo
    {
        List<School> Schools();
        School School(int id);
        List<StudentVM> StudentBySchool(int schoolid);
        List<Classes> Classes();
        List<StudentVM> StudentByClassId(int schoolid, int classid);
        List<StudentVM> ResultBySchool(int schoolid);
        List<StudentVM> resultByClassId(int schoolid, int classid);
        StudentVM StudentById(int sid);
        bool InsertStudent(StudentVM st);
        Relations relation(int schoolid, int classid);
        StudentVM EditStudentById(int sid);
        bool UpdateStudent(StudentVM st);
        List<Country> GetCountry();
        List<State> GetState(int cid);
        List<City> GetCity(int sid);
        bool DeleteStu(int sid);
    }
}
