using Microsoft.EntityFrameworkCore;
using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Api.Models
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext dbContext;

        public SubjectRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Subject> AddSubject(Subject subject)
        {
            var result = await dbContext.Subjects.AddAsync(subject);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Subject> DeleteSubject(int subjectId)
        {
            var result = await dbContext.Subjects.FirstOrDefaultAsync(t => t.SubjectId == subjectId);

            if (result != null)
            {
                dbContext.Subjects.Remove(result);
                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Subject> GetSubject(int subjectId)
        {
            return await dbContext.Subjects
                .FirstOrDefaultAsync(t => t.SubjectId == subjectId);
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await dbContext.Subjects.ToListAsync();
        }

        public async Task<IEnumerable<Subject>> Search(string name)
        {
            IQueryable<Subject> query = dbContext.Subjects;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(t => t.SubjectName.Contains(name));
            }

            return await query.ToListAsync();
        }

        public Task<Subject> UpdateSubject(Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
