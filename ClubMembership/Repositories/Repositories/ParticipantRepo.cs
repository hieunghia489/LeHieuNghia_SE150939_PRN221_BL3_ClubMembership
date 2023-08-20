using ClubMembership_Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Repositories.Repositories
{
    public class ParticipantRepo : IParticipantRepo
    {
        public Participant Get(int id)
        {
            using var context = new ClubMembershipContext();
            return context.Participants.Include(c=>c.Membership).Include(c=>c.ClubActivity).SingleOrDefault(c => c.Id == id);
                }

        public List<Participant> GetAll()
        {
            using var context = new ClubMembershipContext();
            return context.Participants.Include(c => c.Membership).Include(c => c.ClubActivity).ToList();
        }

        public List<Participant> GetByActivity(int id)
        {
            using var context = new ClubMembershipContext();
            List<Participant> list = new List<Participant>();
            foreach (Participant p in context.Participants.Include(c => c.Membership).Include(c => c.ClubActivity))
            {
                if (p.ClubActivityId == id)
                {
                    list.Add(p);
                }
            }
            return list;
        }

        public List<Participant> GetByMember(int id)
        {
            using var context = new ClubMembershipContext();
            List<Participant> list = new List<Participant>();
            foreach (Participant p in context.Participants.Include(c => c.Membership).Include(c => c.ClubActivity))
            {
                if (p.MembershipId == id)
                {
                    list.Add(p);
                }
            }
            return list;
        }
    }
}
