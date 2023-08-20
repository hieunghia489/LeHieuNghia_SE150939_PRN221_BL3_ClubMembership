using ClubMembership_Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Repositories.Repositories
{
    public class ClubActivityRepo : IClubActivityRepo
    {
        public ClubActivity Get(int id)
        {
            using var context = new ClubMembershipContext();
            return context.ClubActivities.Include(t => t.Club).SingleOrDefault(c => c.Id == id);
        }

        public List<ClubActivity> GetAll()
        {
            using var context = new ClubMembershipContext();
            return context.ClubActivities.Include(t => t.Club).ToList();
        }

        public List<ClubActivity> GetAllByClub(int id)
        {
            using var context = new ClubMembershipContext();
            List<ClubActivity> list = new List<ClubActivity>();
            foreach (ClubActivity clubActivity in context.ClubActivities.Include(t => t.Club))
            {
                if(clubActivity.ClubId == id)
                {
                    list.Add(clubActivity);
                }
            }
            return list;
        }

        public List<ClubActivity> GetCurrentByClub(int id)
        {
            using var context = new ClubMembershipContext();
            List<ClubActivity> list = new List<ClubActivity>();
            foreach (ClubActivity clubActivity in context.ClubActivities.Include(t => t.Club))
            {
                if (clubActivity.ClubId == id)
                {
                   if(clubActivity.Status==true) list.Add(clubActivity);
                }
            }
            return list;
        }
    }
}
