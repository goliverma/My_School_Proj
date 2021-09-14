using BAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.VM;
using Proj1_api.Filters;

namespace Proj1_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [TokenAuthenticationFilter]
    public class ReportsController : ControllerBase
    {
        private readonly IStudentRepo studentRepo;

        public ReportsController(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }
        [HttpGet("getStudent")]
        public ActionResult<StudentVM> getStudent(int sid)
        {
            if (sid != 0 && sid.ToString() != null)
            {
                var data = studentRepo.StudentBySchool(sid);
                return Ok(data);
            }
            return NotFound();
        }
    }
}
