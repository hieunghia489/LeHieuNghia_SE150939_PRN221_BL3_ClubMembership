using ClubMembership_Repositories.IRepositories;
using ClubMembership_Services.IServices;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Services.Services
{
    public class GroupMemberService : IGroupMemberService
    {
        private readonly IGroupMemberRepo _repo;
        public GroupMemberService(IGroupMemberRepo repo)
        {
            _repo = repo;
        }

        public GroupMember Get(int id)=>_repo.Get(id);

        public List<GroupMember> GetAll()=>_repo.GetAll();

        public List<GroupMember> GetByClubBoard(int id) => _repo.GetByClubBoard(id);
    }
}
