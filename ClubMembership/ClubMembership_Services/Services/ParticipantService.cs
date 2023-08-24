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
    public class ParticipantService :IParticipantService
    {
        private readonly IParticipantRepo _repo;
        public ParticipantService(IParticipantRepo repo) {
        _repo = repo;
        }

        public void Added(Participant participant)=>_repo.Added(participant);

        public void Delete(Participant participant)=>_repo.Delete(participant);

        public Participant Get(int id)=>_repo.Get(id);

        public List<Participant> GetAll() => _repo.GetAll();

        public List<Participant> GetByActivity(int id) => _repo.GetByActivity(id);

        public List<Participant> GetByMember(int id) => _repo.GetByMember(id);

        public void Update(Participant participant)=>_repo.Update(participant);
    }
}
