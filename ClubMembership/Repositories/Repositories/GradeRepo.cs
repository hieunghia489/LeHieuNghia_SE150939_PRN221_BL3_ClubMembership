using ClubMembership_Repositories.IRepositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Repositories.Repositories
{
   
    public class GradeRepo : IGradeRepo
    {
        public Grade Get(int id)
        {
            using var context = new ClubMembershipContext();
            return context.Grades.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Grade> GetAll()
        {
            using var context = new ClubMembershipContext();
            return context.Grades.ToList();
        }

        public Grade GetByCode(string code)
        {
            using var context = new ClubMembershipContext();
            return context.Grades.SingleOrDefault(c => c.Code == code);
        }
    }
}
