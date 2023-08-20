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
    public class MembershipRepo : IMembershipRepo
    {
        public Membership Get(int id)
        {
            using var context = new ClubMembershipContext();
            return context.Memberships.Include(t=>t.Student).Include(t=>t.Club).SingleOrDefault(c=>c.Id==id);
        }

        public List<Membership> GetAll()
        {
            using var context = new ClubMembershipContext();
return context.Memberships.Include(t=>t.Student).Include(t=>t.Club).ToList();
        }

        public List<Membership> GetAllByClub(int id)
        {
            using var context = new ClubMembershipContext();
            List<Membership> list = new List<Membership>();
            foreach (var item in context.Memberships.Include(c => c.Club))
            {
                if (item.ClubId == id)
                {                
                        list.Add(item);
                }
            }
            return list;
        }
        

        public Membership GetByCode(string code)
        {
            using var context = new ClubMembershipContext();
            return context.Memberships.Include(t => t.Student).Include(t => t.Club).SingleOrDefault(c => c.Code==code);
        }

        public List<Membership> GetCurrentByClub(int id)
        {
            using var context = new ClubMembershipContext();
            List<Membership> list = new List<Membership>();
            foreach (var item in context.Memberships.Include(c => c.Club))
            {
                if (item.ClubId == id)
                {
                    if (item.Status == true)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }
    }
}
