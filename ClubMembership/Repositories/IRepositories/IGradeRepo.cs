using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Repositories.IRepositories
{
    public interface IGradeRepo
    {
        IEnumerable<Grade> GetAll();
        Grade Get(int id);
        Grade GetByCode(string code);
    }
}
