using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Services.IServices
{
    public interface IMajorService
    {
        IEnumerable<Major> GetAll();
        Major Get(int majorId);
        Major GetByCode(string code);
    }
}
