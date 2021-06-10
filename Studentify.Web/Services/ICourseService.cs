using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Web.Services
{
     public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCourses();

        Task<Course> GetCourse(int id);

        Task<IEnumerable<Course>> Search(string name);

        Task<IEnumerable<Course>> GetStudentCourses(int studentId);

        Task<Course> UpdateCourse(Course course);

        Task DeleteCourse(int id);

        Task<Course> CreateCourse(Course course);
    }
}
