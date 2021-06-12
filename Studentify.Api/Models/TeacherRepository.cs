using Microsoft.EntityFrameworkCore;
using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Api.Models
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext dbContext;

        public TeacherRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            var theTeacher = await dbContext.Teachers.AddAsync(teacher);
            await dbContext.SaveChangesAsync();
            return theTeacher.Entity;
        }

        public async Task<Teacher> DeleteTeacher(int teacherId)
        {
            var theTeacher = await dbContext.Teachers.FirstOrDefaultAsync(t => t.TeacherId == teacherId);

            if (theTeacher != null)
            {
                dbContext.Teachers.Remove(theTeacher);
                await dbContext.SaveChangesAsync();

                return theTeacher;
            }

            return null;
        }

        public async Task<Teacher> GetTeacher(int teacherId)
        {
            return await dbContext.Teachers
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.TeacherId == teacherId);
        }

        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            //return await dbContext.Teachers.ToListAsync();
            return await dbContext.Teachers
                .Include(t => t.Courses)
                .ToListAsync();
        }

        public async Task<IEnumerable<Teacher>> Search(string name)
        {
            IQueryable<Teacher> query = dbContext.Teachers;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(t => t.TeacherName.Contains(name));
            }

            //if (Teacher != null)
            //{
            //    query = query.Where(t => t.TeacherId == id);
            //}

            return await query
                .Include(t => t.Courses)
                .ToListAsync();
        }

        public async Task<Teacher> UpdateTeacher(Teacher teacher)
        {
            var theTeacher = await dbContext.Teachers
               .FirstOrDefaultAsync(t => t.TeacherId == teacher.TeacherId);

            if (theTeacher != null)
            {
                theTeacher.TeacherName = teacher.TeacherName;
                theTeacher.ImageUrl = teacher.ImageUrl;
                theTeacher.Courses = teacher.Courses;               

                await dbContext.SaveChangesAsync();

                return theTeacher;
            }

            return null;
        }
    }
}
