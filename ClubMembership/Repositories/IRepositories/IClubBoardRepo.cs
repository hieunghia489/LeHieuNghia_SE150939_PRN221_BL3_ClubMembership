using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Repositories.IRepositories
{
    public interface IClubBoardRepo
    {
        List<ClubBoard> GetAll();
        ClubBoard Get(int id);
        List<ClubBoard> GetAllByClub(int id);
        ClubBoard GetCurrentByClub(int id);
        void Add(ClubBoard clubBoard);
        void Delete(ClubBoard clubBoard);

    }
}
