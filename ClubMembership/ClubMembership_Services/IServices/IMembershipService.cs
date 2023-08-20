using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Services.IServices
{
    public interface IMembershipService
    {
        List<Membership> GetAll();
        Membership Get(int id);
        Membership GetByCode(string code);
        List<Membership> GetAllByClub(int id);
        List<Membership> GetCurrentByClub(int id);
    }
}
