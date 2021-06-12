using Microsoft.AspNetCore.Mvc;
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
        private readonly AppDbContext dbContext;

        public CourseRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Course> AddCourse(Course course)
        {
            var result = await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Course> DeleteCourse(int courseId)
        {
            var result = await dbContext.Courses.FirstOrDefaultAsync(t => t.CourseId == courseId);

            if (result != null)
            {
                dbContext.Courses.Remove(result);
                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Course> GetCourse(int courseId)
        {
            return await dbContext.Courses
                //.Include(c => c.Student)
               .FirstOrDefaultAsync(t => t.CourseId == courseId);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await dbContext.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Course>> Search(string name)
        {
            IQueryable<Course> query = dbContext.Courses;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.CourseName.Contains(name));
            }

            return await query
                //.Include(q => q.Students)
                .ToListAsync();
        }

        public Task<Course> UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetStudentCourses(int studentId)
        {
            var query = dbContext.Students.Include(s => s.Courses).Where(s => s.StudentId == studentId).SelectMany(c => c.Courses);

            return await query.ToListAsync();
        }


    }
}
