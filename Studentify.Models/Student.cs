using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentify.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }        

        public string ImageUrl { get; set; }


        public IEnumerable<Course> Courses { get; set; } = new List<Course>();

        public IEnumerable<Grade> Grades { get; set; } = new List<Grade>();

    }
}
