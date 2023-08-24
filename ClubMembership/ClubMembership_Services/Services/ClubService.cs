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
    public class ClubService : IClubService
    {
        private readonly IClubRepo _repo;
        public ClubService(IClubRepo repo){
            _repo = repo;
}
        public Club Get(int id)=>_repo.Get(id);

        public List<Club> GetAll()=>_repo.GetAll();

        public Club GetByCode(string code)=>_repo.GetByCode(code);
        public void Added(Club club)=>_repo.Added(club);
    }
}
