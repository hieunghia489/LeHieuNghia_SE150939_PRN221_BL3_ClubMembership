using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Services.IServices
{
    public interface IClubBoardService
    {
        List<ClubBoard> GetAll();
        ClubBoard Get(int id);
        List<ClubBoard> GetAllByClub(int id);
        List<ClubBoard> GetCurrentByClub(int id);
    }
}
