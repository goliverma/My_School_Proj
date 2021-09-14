using BAL.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proj1.Models.Filter;
using System;

namespace Proj1.Controllers
{
    //[ServiceFilter(typeof(CustomExceptionFilter))]
    public class SchoolController : Controller
    {
        private readonly IStudentRepo context;

        public SchoolController(IStudentRepo context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("schoolId", string.Empty);
            return View();
        }
        [HttpGet]
        public IActionResult ShowSchool(int id)
        {
            var data = context.School(id == 0 ? Convert.ToInt32(HttpContext.Session.GetString("schoolId")) : id);
            HttpContext.Session.SetString("schoolId", data.SchoolId.ToString());
            return View(data);
        }
        [HttpGet]
        public JsonResult getSchool()
        {
            return Json(context.Schools());
        }
    }
}
