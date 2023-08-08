using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IGradeRepository
    {
        List<Grade> GetAll();
    }
    public class GradeRepository : IGradeRepository
    {
        public List<Grade> GetAll()
        {
           using var context=new ClubMembershipContext();
            return context.Grades.ToList();
        }
    }
}
