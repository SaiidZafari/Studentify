using Studentify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentify.Api.Models
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> Search(string name);

        Task<IEnumerable<Grade>> GetGrades();
        Task<Grade> GetGrade(int gradeId);
        Task<Grade> AddGrade(Grade grade);
        Task<Grade> UpdateGrade(Grade grade);
        Task<Grade> DeleteGrade(int gradeId);
    }
}
