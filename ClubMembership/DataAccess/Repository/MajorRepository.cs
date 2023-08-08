using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMajorRepository
    {
        List<Major> GetAll();
    }
    public class MajorRepository : IMajorRepository
    {
        public List<Major> GetAll()
        {
           using var context=new ClubMembershipContext();
            return context.Majors.ToList();
        }
    }
}
