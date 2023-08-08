using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public interface IMajorService
    {
        List<Major> GetAll();
    }
    public class MajorService : IMajorService
    {
        private readonly IMajorRepository _repository;
        public MajorService(IMajorRepository repository) { _repository = repository; }

        public List<Major> GetAll()=> _repository.GetAll();
    }
}
