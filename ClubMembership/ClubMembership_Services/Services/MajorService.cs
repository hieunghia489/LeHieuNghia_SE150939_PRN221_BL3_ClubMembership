using ClubMembership_Repositories.IRepositories;
using ClubMembership_Repositories.Repositories;
using ClubMembership_Services.IServices;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Services.Services
{

    public class MajorService : IMajorService
    {
        private readonly IMajorRepo _majorRepo;
        public MajorService(IMajorRepo majorRepo)
        {
            _majorRepo = majorRepo;
        }

        public Major Get(int majorId)=>_majorRepo.Get(majorId);
        public IEnumerable<Major> GetAll()=> _majorRepo.GetAll();

        public Major GetByCode(string code)=>_majorRepo.GetByCode(code);
    }
}
