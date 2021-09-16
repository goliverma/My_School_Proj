using BAL.Repository;
using BAL.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proj1.Models.Filter;
using System;

namespace Proj1.Controllers
{
    //[ServiceFilter(typeof(CustomExceptionFilter))]
    public class OperationsController : Controller
    {
        private readonly IStudentRepo context;
        private readonly ILinq context1;

        public OperationsController(IStudentRepo context, ILinq context1)
        {
            this.context = context;
            this.context1 = context1;
        }
        [HttpGet]
        //[ResponseCache(CacheProfileName = "ListCache")]
        public IActionResult StudentListBySchool()
        {
            //var data = context.StudentBySchool(schoolid());
            #region comment
            //ViewData["SortOrder"] = SortOrder;
            //switch(SortBy)
            //{
            //    case "Name":
            //        {
            //            switch (SortOrder)
            //            {
            //                case "Asc":
            //                    {
            //                        data = data.OrderBy(it => it.StudentName).ToList();
            //                        break;
            //                    }
            //                case "Desc":
            //                    {
            //                        data = data.OrderByDescending(it => it.StudentName).ToList();
            //                        break;
            //                    }
            //                default:
            //                    {
            //                        data = data.OrderBy(it => it.StudentName).ToList();
            //                        break;
            //                    }
            //            }
            //            break;
            //        }
            //    case "RollNo":
            //        {
            //            switch (SortOrder)
            //            {
            //                case "Asc":
            //                    {
            //                        data = data.OrderBy(it => it.StudentRollNo).ToList();
            //                        break;
            //                    }
            //                case "Desc":
            //                    {
            //                        data = data.OrderByDescending(it => it.StudentRollNo).ToList();
            //                        break;
            //                    }
            //                default:
            //                    {
            //                        data = data.OrderBy(it => it.StudentRollNo).ToList();
            //                        break;
            //                    }
            //            }
            //            break;
            //        }
            //    default:
            //        {
            //            break;
            //        }
            //}
            #endregion
            return View();
        }
        [HttpGet]
        public JsonResult getstudentListBySchool()
        {
            return Json(context1.StudentBySchool(schoolid()));
        }
        [HttpGet]
        public IActionResult SchoolClass(string a)
        {
            if (a != null)
            {
                HttpContext.Session.SetString("pageValue", a);
            }
            else
            {
                HttpContext.Session.SetString("pageValue", "");
            }
            return View();
        }
        [HttpGet]
        public IActionResult StudentListByClassId(int id)
        {
            return View();
        }
        [HttpGet]
        public JsonResult getStudentListByClassId(string id)
        {
            return Json(context1.StudentByClassId(schoolid(), Convert.ToInt32(id)));
        }
        [HttpGet]
        public JsonResult getClass()
        {
            return Json(context.Classes());
        }
        [HttpGet]
        //[ResponseCache(CacheProfileName = "ListCache")]
        public IActionResult ShowAllResult()
        {
            return View(/*context.ResultBySchool(schoolid())*/);
        }
        [HttpGet]
        public JsonResult getShowAllResult()
        {
            return Json(context1.ResultBySchool(schoolid()));
        }
        public IActionResult StudentResultByClassId(int id)
        {
            return View(/*context1.resultByClassId(schoolid(), id)*/);
        }
        [HttpGet]
        public JsonResult getStudentResultByClassId(int id)
        {
            return Json(context1.resultByClassId(schoolid(), id));
        }
        [HttpGet]
        public IActionResult StudentById(int sid)
        {
            return View(context1.StudentById(sid));
        }
        private int schoolid()
        {
            return Convert.ToInt32(HttpContext.Session.GetString("schoolId"));
        }
    }
}
