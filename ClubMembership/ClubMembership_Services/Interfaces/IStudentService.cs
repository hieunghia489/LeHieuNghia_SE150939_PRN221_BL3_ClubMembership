using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetGrades();
        Student GetStudent(int id);
        Student GetStudentByCode(string code);
    }
}
