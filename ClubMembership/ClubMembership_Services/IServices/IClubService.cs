using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Services.IServices
{
    public interface IClubService
    {
        List<Club> GetAll();
        Club Get(int id);
        Club GetByCode(string code);
    }
}
