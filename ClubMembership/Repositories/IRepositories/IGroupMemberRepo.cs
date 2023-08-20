using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Repositories.IRepositories
{
    public interface IGroupMemberRepo
    {
        List<GroupMember> GetAll();
        GroupMember Get(int id);
        List<GroupMember> GetByClubBoard (int id);
    }
}
