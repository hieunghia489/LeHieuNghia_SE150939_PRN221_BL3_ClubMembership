using ClubMembership_Repositories.IRepositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Repositories.Repositories
{
   
    public class MajorRepo : IMajorRepo
    {
        public Major Get(int majorId)
        {
            using var context = new ClubMembershipContext();
            return context.Majors.SingleOrDefault(c => c.Id == majorId);
        }

        public IEnumerable<Major> GetAll()
        {
            using var context = new ClubMembershipContext();
            return context.Majors.ToList();
        }

        public Major GetByCode(string code)
        {
            using var context = new ClubMembershipContext();
            return context.Majors.SingleOrDefault(c => c.Code   == code);
        }
    }
}
