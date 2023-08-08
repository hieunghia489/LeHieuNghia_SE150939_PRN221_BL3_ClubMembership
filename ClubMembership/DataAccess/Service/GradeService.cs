using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public interface IGradeService
    {
        List<Grade> GetAll();
    }
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        public GradeService(IGradeRepository gradeRepository) { _gradeRepository = gradeRepository; }

        public List<Grade> GetAll()=> _gradeRepository.GetAll();
    }
}
