using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Repositories.IRepositories
{
    public interface IParticipantRepo
    {
        List<Participant> GetAll();
        Participant Get(int id);
        List<Participant> GetByMember(int id);
        List<Participant> GetByActivity(int id);
    }
}
