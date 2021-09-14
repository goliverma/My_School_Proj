using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.VM
{
    public class StudentVM : Student
    {
        public string SchoolName { get; set; }
        public string ClassName { get; set; }
        public int Percentage { get; set; }
        public int Id { get; set; }
        public string Csid { get; set; }
        public string Ssid { get; set; }
        public string CityCId { get; set; }
        public List<Classes> classes { get; set; }
    }
}
