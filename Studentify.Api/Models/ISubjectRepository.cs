using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Api.Models
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> Search(string name);

        Task<IEnumerable<Subject>> GetSubjects();
        Task<Subject> GetSubject(int subjectId);
        Task<Subject> AddSubject(Subject subject);
        Task<Subject> UpdateSubject(Subject subject);
        Task<Subject> DeleteSubject(int subjectId);
    }
}
