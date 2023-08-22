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
    public class GroupMemberRepo : IGroupMemberRepo
    {
        public void Added(GroupMember member)
        {
            using var context = new ClubMembershipContext();
        context.GroupMembers.Add(member);
            context.SaveChanges();
        }

        public void Delete(GroupMember member)
        {
            using var context = new ClubMembershipContext();
            member.Status = false;
            context.GroupMembers.Update(member);
            context.SaveChanges();
        }

        public GroupMember Get(int id)
        {
            using var context = new ClubMembershipContext();
            return context.GroupMembers.Include(c => c.Membership).Include(c=>c.Membership.Student).Include(c => c.ClubBoard).SingleOrDefault(c => c.Id == id);
        }

        public List<GroupMember> GetAll()
        {
            using var context = new ClubMembershipContext();
            return context.GroupMembers.Include(c => c.Membership).Include(c => c.Membership.Student).Include(c => c.ClubBoard).ToList();
        }

        public List<GroupMember> GetByClubBoard(int id)
        {
            using var context = new ClubMembershipContext();
            List<GroupMember> list = new List<GroupMember>();
            foreach (var groupMember in context.GroupMembers.Include(c => c.Membership).Include(c => c.Membership.Student).Include(c => c.ClubBoard))
            {
                if (groupMember.ClubBoardId == id)
                {
                    if(groupMember.Status==true)
                    list.Add(groupMember);
                }
            }
            return list;
        }
    }
}
