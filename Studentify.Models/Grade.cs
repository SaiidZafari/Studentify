using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentify.Models
{
    public class Grade
    {
        public int GradeId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public int StudentGrade { get; set; }
    }
}
