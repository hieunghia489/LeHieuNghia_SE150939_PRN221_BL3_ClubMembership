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
    public class ClubActivityService : IClubActivityService
    {
        private readonly IClubActivityRepo _repo;
        public ClubActivityService(IClubActivityRepo repo)
        {
            _repo = repo;
        }
        public ClubActivity Get(int id)=>_repo.Get(id);

        public List<ClubActivity> GetAll()=>_repo.GetAll();

        public List<ClubActivity> GetAllByClub(int id)=>_repo.GetAllByClub(id);

        public List<ClubActivity> GetCurrentByClub(int id)=>_repo.GetCurrentByClub(id);
    }
}
