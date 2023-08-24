using ClubMembership_Repositories.IRepositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Repositories.Repositories
{
    public class ClubRepo : IClubRepo
    {
        public void Added(Club club)
        {
            using var context = new ClubMembershipContext();
        context.Clubs.Add(club);
            context.SaveChanges();
        }

        public Club Get(int id)
        {
            using var context = new ClubMembershipContext();
            return context.Clubs.SingleOrDefault(c => c.Id == id);
        }

        public List<Club> GetAll()
        {
            using var context = new ClubMembershipContext();
            return context.Clubs.ToList();
        }

        public Club GetByCode(string code)
        {
            using var context = new ClubMembershipContext();
            return context.Clubs.SingleOrDefault(c => c.Code == code);
        }
    }
}
