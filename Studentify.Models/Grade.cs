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

        public int StudentId { get; set; } // Foreign key
        
        public Student Student { get; set; } // Reference navigatio

        public int CourseId { get; set; } // Foreign key

        public Course Course { get; set; } // Reference navigatio

        public int StudentGrade { get; set; }    

        
    }
}
