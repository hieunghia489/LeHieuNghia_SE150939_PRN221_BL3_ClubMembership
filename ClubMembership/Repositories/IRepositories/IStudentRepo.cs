using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Repositories.IRepositories
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student GetByCode(string code);
    }
}
