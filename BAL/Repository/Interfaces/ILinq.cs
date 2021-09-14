using Models.Models;
using Models.VM;
using System.Collections.Generic;

namespace BAL.Repository
{
    public interface ILinq
    {
        List<School> GetSchool();
        List<Classes> GetClass();
        List<Student> GetStudents();
        List<Relations> GetRelations();
        List<City> GetCities();
        List<State> GetStates();
        List<Country> GetCountries();
        List<Results> GetResults();
        List<City> GetCity(int sid);
        List<Country> GetCountry();
        List<State> GetState(int cid);
        List<StudentVM> resultByClassId(int schoolid, int classid);
        List<StudentVM> ResultBySchool(int schoolid);
        List<StudentVM> StudentByClassId(int schoolid, int classid);
        StudentVM StudentById(int sid);
        List<StudentVM> StudentBySchool(int schoolid);
    }
}
