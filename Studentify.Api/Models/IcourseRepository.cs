using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Api.Models
{
     public interface IcourseRepository
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(int courseId);
    }
}
