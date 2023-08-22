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
        public void Added(Membership membership)
        {
            using var context = new ClubMembershipContext();
        context.Memberships.Add(membership);
            context.SaveChanges();
        }

        public void Delete(Membership membership)
        {
            using var context = new ClubMembershipContext();
            if (context.Memberships.Contains(membership))
            {
                membership.Status = false;
                context.Memberships.Update(membership);
                context.SaveChanges() ;
            }
        }

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
            foreach (var item in context.Memberships.Include(c => c.Club).Include(c=>c.Student))
            {
                if (item.ClubId == id)
                {        if(item.Status==true)        
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
            foreach (var item in context.Memberships.Include(c => c.Club).Include(t => t.Student))
            {
                if (item.ClubId == id)
                {
                    if (item.Status == true)
                    {
                        if(item.LeaveDate==null||item.LeaveDate.Value.CompareTo(DateTime.Now)==1)
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public void Update(Membership membership)
        {
            using var context = new ClubMembershipContext();
            if (context.Memberships.Contains(membership))
            {
                context.Memberships.Update(membership);
                context.SaveChanges();
            }
        }
    }
}
