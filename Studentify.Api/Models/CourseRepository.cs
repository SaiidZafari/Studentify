using Microsoft.EntityFrameworkCore;
using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Api.Models
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext appDbContext;

        public CourseRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }



        public async Task<Course> GetCourse(int courseId)
        {
            return await appDbContext.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await appDbContext.Courses.ToListAsync();
        }
    }

}
