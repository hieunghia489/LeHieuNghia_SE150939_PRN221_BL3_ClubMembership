using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Services.Interfaces
{
   public interface IGradeService
    {
        IEnumerable<Grade> GetGrades();
        Grade GetGrade(int id);
        Grade GetGradeByCode(string code);
    }
}
