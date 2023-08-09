using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Repositories.Interfaces
{
    public interface IMajorRepo
    {
        IEnumerable<Major> GetAll();
        Major Get(int majorId);
        Major GetByCode(string code);
    }
}
