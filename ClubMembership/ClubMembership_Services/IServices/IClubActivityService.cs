using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Services.IServices
{
    public interface IClubActivityService
    {
        List<ClubActivity> GetAll();
        ClubActivity Get(int id);
        List<ClubActivity> GetAllByClub(int id);
        List<ClubActivity> GetCurrentByClub(int id);
    }
}
