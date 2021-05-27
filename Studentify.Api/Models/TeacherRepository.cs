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
            var result = await dbContext.Teachers.AddAsync(teacher);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Teacher> DeleteTeacher(int teacherId)
        {
            var result = await dbContext.Teachers.FirstOrDefaultAsync(t => t.TeacherId == teacherId);

            if (result != null)
            {
                dbContext.Teachers.Remove(result);
                await dbContext.SaveChangesAsync();

                return result;
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
            return await dbContext.Teachers.ToListAsync();
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

            return await query.ToListAsync();
        }

        public Task<Teacher> UpdateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
