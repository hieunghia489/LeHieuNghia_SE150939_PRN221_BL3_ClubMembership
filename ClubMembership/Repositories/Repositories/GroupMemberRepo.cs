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
        public GroupMember Get(int id)
        {
            using var context = new ClubMembershipContext();
            return context.GroupMembers.Include(c => c.Membership).Include(c => c.ClubBoard).SingleOrDefault(c => c.Id == id);
        }

        public List<GroupMember> GetAll()
        {
            using var context = new ClubMembershipContext();
            return context.GroupMembers.Include(c => c.Membership).Include(c => c.ClubBoard).ToList();
        }

        public List<GroupMember> GetByClubBoard(int id)
        {
            using var context = new ClubMembershipContext();
            List<GroupMember> list = new List<GroupMember>();
            foreach (var groupMember in context.GroupMembers.Include(c => c.Membership).Include(c => c.ClubBoard))
            {
                if (groupMember.ClubBoardId == id)
                {
                    list.Add(groupMember);
                }
            }
            return list;
        }
    }
}
