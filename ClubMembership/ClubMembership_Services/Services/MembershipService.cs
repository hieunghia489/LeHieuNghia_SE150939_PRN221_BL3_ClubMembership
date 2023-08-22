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
    public class MembershipService : IMembershipService
    {private readonly IMembershipRepo _repo;
        public MembershipService(IMembershipRepo repo) {  _repo = repo; }

        public void Added(Membership membership)=>_repo.Added(membership);

        public void Delete(Membership membership)=>_repo.Delete(membership);

        public Membership Get(int id)=>_repo.Get(id);

        public List<Membership> GetAll()=>_repo.GetAll();

        public List<Membership> GetAllByClub(int id)=>_repo.GetAllByClub(id);

        public Membership GetByCode(string code)=>_repo.GetByCode(code);

        public List<Membership> GetCurrentByClub(int id)=>_repo.GetCurrentByClub(id);

        public void Update(Membership membership)=>_repo.Update(membership);
    }
}
