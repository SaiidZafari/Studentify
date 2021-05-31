using Microsoft.EntityFrameworkCore;
using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Api.Models
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AppDbContext dbContext;

        public GradeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Grade> AddGrade(Grade grade)
        {
            var result = await dbContext.Grades.AddAsync(grade);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Grade> DeleteGrade(int gradeId)
        {
            var result = await dbContext.Grades.FirstOrDefaultAsync(t => t.GradeId == gradeId);

            if (result != null)
            {
                dbContext.Grades.Remove(result);
                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Grade> GetGrade(int gradeId)
        {
            return await dbContext.Grades
                .FirstOrDefaultAsync(t => t.GradeId == gradeId);
        }

        public async Task<IEnumerable<Grade>> GetGrades()
        {
            return await dbContext.Grades.ToListAsync();
        }

        public async Task<IEnumerable<Grade>> Search(string name)
        {
            IQueryable<Grade> query = dbContext.Grades;

            if (query.Count<Grade>() > 0)
            {
                query = query.Where(g => g.StudentGrade == int.Parse(name));
            }

            return await query.ToListAsync();
        }

       

        public Task<Grade> UpdateGrade(Grade grade)
        {
            throw new NotImplementedException();
        }
    }
}
