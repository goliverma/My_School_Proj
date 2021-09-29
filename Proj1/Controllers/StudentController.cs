using Aspose.Words;
using Aspose.Words.Reporting;
using Aspose.Words.Tables;
using BAL.Repository;
using BAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.VM;
using Proj1.Models.Filter;
using System;
using System.Collections.Generic;
using System.Drawing;

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
            return Json(context.GetCountry());
        }
        [HttpGet]
        public JsonResult GetState(int sid)
        {
            return Json(context.GetState(sid));
        }
        [HttpGet]
        public JsonResult GetCity(int Stateid)
        {
            return Json(context.GetCity(Stateid));
        }
        [HttpGet]
        public IActionResult ShowStudentById(int id)
        {
            var data = context.StudentById(id);
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
            var data = context.StudentBySchool(schoolid());
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
        [HttpGet]
        public JsonResult HtmlToPDF()
        {
            var data = context.StudentBySchool(schoolid());
            #region without template
            //Document doc = new();
            //DocumentBuilder docbuild = new(doc);
            //Table tbl = docbuild.StartTable();
            ////docbuild.InsertCell();
            ////docbuild.Write("Student Data Table");
            ////one cell ka formate set krna k liya
            ////tbl.PreferredWidth = PreferredWidth.FromPercent(150);
            ////docbuild.CellFormat.PreferredWidth = PreferredWidth.FromPercent(50);
            ////docbuild.CellFormat.Borders.LineWidth = 1.5;
            ////docbuild.CellFormat.Shading.BackgroundPatternColor = Color.Pink;
            ////docbuild.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            ////docbuild.EndRow();
            ////Header Design
            //docbuild.InsertCell();
            //docbuild.Write("Student Id");
            //tbl.PreferredWidth = PreferredWidth.FromPercent(150);
            //docbuild.CellFormat.PreferredWidth = PreferredWidth.FromPercent(10);
            //docbuild.CellFormat.Borders.LineWidth = 1.5;
            //docbuild.CellFormat.Shading.BackgroundPatternColor = Color.Pink;
            //docbuild.ParagraphFormat.Alignment = ParagraphAlignment.Center;

            //docbuild.InsertCell();
            //docbuild.Write("Student Name");
            //docbuild.CellFormat.PreferredWidth = PreferredWidth.FromPercent(10);

            //docbuild.InsertCell();
            //docbuild.Write("Roll No");
            //docbuild.CellFormat.PreferredWidth = PreferredWidth.FromPercent(10);

            //docbuild.InsertCell();
            //docbuild.Write("Class");
            //docbuild.CellFormat.PreferredWidth = PreferredWidth.FromPercent(10);

            //docbuild.InsertCell();
            //docbuild.Write("Address");
            //docbuild.CellFormat.PreferredWidth = PreferredWidth.FromPercent(10);

            //docbuild.EndRow();
            ////Header Insert in Doc
            //foreach(Cell cell in tbl.Rows[0].Cells)
            //{
            //    Paragraph p = cell.FirstParagraph;
            //    p.Runs[0].Font.Bold = true;
            //    p.Runs[0].Font.Color = Color.White;
            //}
            ////this proces to insert tbody
            //Cell currentcell;
            //foreach (var item in data)
            //{
            //    currentcell = docbuild.InsertCell();
            //    docbuild.Write(item.StudentId.ToString());
            //    docbuild.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            //    currentcell.CellFormat.VerticalMerge = CellMerge.First;
            //    docbuild.CellFormat.Borders.LineWidth = 1;
            //    docbuild.CellFormat.Shading.BackgroundPatternColor = Color.White;

            //    currentcell = docbuild.InsertCell();
            //    docbuild.Write(item.StudentName);

            //    currentcell = docbuild.InsertCell();
            //    docbuild.Write(item.StudentRollNo.ToString());

            //    currentcell = docbuild.InsertCell();
            //    docbuild.Write(item.ClassName);

            //    currentcell = docbuild.InsertCell();
            //    docbuild.Write(item.StudentAddress);

            //    docbuild.EndRow();

            //}
            ////file save path
            //doc.Save($"C:\\Users\\gauravverma\\Downloads\\reports.doc");
            #endregion
            #region with Template
            Document doc = new(@"C:\Users\gauravverma\Desktop\My_School_Proj\Proj1\Models\Template\StudentTemplate.docx");
            List<StudentVM> students = new(data);
            ReportingEngine reporting = new();
            reporting.BuildReport(doc, students, "student");
            doc.Save(@"C:\Users\gauravverma\Desktop\My_School_Proj\Proj1\wwwroot\TXT\OutPut\\Reports.docx");
            #endregion
            return Json("Export");
        }
    }
}
