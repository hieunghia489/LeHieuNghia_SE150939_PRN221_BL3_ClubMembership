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
    public class ClubBoardService : IClubBoardService
    {
        private readonly IClubBoardRepo _repo;
        public ClubBoardService(IClubBoardRepo repo)
        {
            _repo = repo;
        }

        public void Add(ClubBoard clubBoard)=>_repo.Add(clubBoard);

        public void Delete(ClubBoard clubBoard)=>_repo.Delete(clubBoard);

        public ClubBoard Get(int id)=>_repo.Get(id);

        public List<ClubBoard> GetAll()=>_repo.GetAll();

        public List<ClubBoard> GetAllByClub(int id)=>_repo.GetAllByClub(id);

        public ClubBoard GetCurrentByClub(int id)=>_repo.GetCurrentByClub(id);
    }
}
