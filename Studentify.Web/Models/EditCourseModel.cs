using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Web.Models
{
    public class EditCourseModel
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string SubjectId { get; set; }

        public string TeacherId { get; set; }
    }
}
