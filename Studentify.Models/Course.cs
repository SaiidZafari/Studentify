using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentify.Models
{
    public class Course
    {
        public int CourseId { get; set; } 
        
        public string CourseName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int SubjectId { get; set; }

        public int TeacherId { get; set; }

        public IEnumerable<Student> Students { get; set; } = new List<Student>();

       
    }
}
