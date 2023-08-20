using ClubMembership_Repositories.IRepositories;
using ClubMembership_Services.IServices;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Services.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepo _gradeRepo;
        public GradeService(IGradeRepo gradeRepo)
        {
            _gradeRepo = gradeRepo;
        }

        public Grade GetGrade(int id)=> _gradeRepo.Get(id);

        public Grade GetGradeByCode(string code)=>_gradeRepo.GetByCode(code);

        public IEnumerable<Grade> GetAll()=>_gradeRepo.GetAll();
    }
}
