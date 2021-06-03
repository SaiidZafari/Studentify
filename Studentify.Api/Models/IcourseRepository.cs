using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Api.Models
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> Search(string name);

        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int courseId);
        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task<Course> DeleteCourse(int courseId);
        Task<IEnumerable<Course>> GetStudentCourses(int studentId);
    }
}
