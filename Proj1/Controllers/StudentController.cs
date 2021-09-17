using BAL.Repository;
using BAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.VM;
using Proj1.Models.Filter;
using System;

namespace Proj1.Controllers
{
    [CustomAuthenticationFilter]
    [Authorize(Roles = "Admin,Teacher")]
    //[ServiceFilter(typeof(CustomExceptionFilter))]
    public class StudentController : Controller
    {
        private readonly IStudentRepo context;
        private readonly ILinq context1;

        public StudentController(IStudentRepo context, ILinq context1)
        {
            this.context = context;
            this.context1 = context1;
        }
        private int schoolid()
        {
            return Convert.ToInt32(HttpContext.Session.GetString("schoolId"));
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PostStudent()
        {
            var clist = context.Classes();
            clist.Insert(0, new Classes { ClassId = 0, ClassName = "---select---" });
            ViewBag.classes = clist;
            ViewBag.pageid = 0;
            return View();
        }
        [HttpPost]
        public IActionResult PostStudent(StudentVM stu)
        {
            stu.SchoolId = schoolid();
            if(stu.StudentId == 0)
            {
                if (context.InsertStudent(stu))
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if(context.UpdateStudent(stu))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id !=0)
            {
                var clist = context.Classes();
                //var culist = context.GetCountry();
                //var slist = context.GetState(st.Cid);
                //var cityl = context.GetCity(st.Sid);
                //clist.Insert(0, new Classes { ClassId = 0, ClassName = "---select---" });
                //culist.Insert(0, new Country { Cid = 0, CName = "---select---" });
                //slist.Insert(0, new State { Sid = 0, SName = "---select---" });
                //cityl.Insert(0, new City { CityId = 0, CityName = "---select---" });
                ViewBag.classes = clist;
                return View();
            }
            return View();
        }
        [HttpGet]
        public JsonResult GetCountry()
        {
            return Json(context1.GetCountry());
        }
        [HttpGet]
        public JsonResult GetState(int sid)
        {
            return Json(context1.GetState(sid));
        }
        [HttpGet]
        public JsonResult GetCity(int Stateid)
        {
            return Json(context1.GetCity(Stateid));
        }
        [HttpGet]
        public IActionResult ShowStudentById(int id)
        {
            var data = context1.StudentById(id);
            if(data != null)
            {
                return PartialView("_ShowStudent", data);
            }
            return Ok("nullData");
        }
        [HttpGet]
        public JsonResult GetStudent(string stid)
        {
            return Json(context.EditStudentById(Convert.ToInt32(stid)));
        }
        [HttpGet]
        public JsonResult getStudents()
        {
            var data = context1.StudentBySchool(schoolid());
            return Json(data);
        }
        [HttpPost]
        public JsonResult DeleteStudent(int id)
        {
            if(context.DeleteStu(id))
            {
                return Json("Student Remove success");
            }
            return Json("something went wrong");
        }
    }
}
