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
        public void Added(Participant participant)
        {
            using var context = new ClubMembershipContext();
        context.Participants.Add(participant);
            context.SaveChanges();
        }

        public void Delete(Participant participant)
        {
            using var context = new ClubMembershipContext();
            participant.Status = false;
            context.Participants.Update(participant);
            context.SaveChanges();
        }

        public Participant Get(int id)
        {
            using var context = new ClubMembershipContext();
            return context.Participants.Include(c=>c.Membership).Include(c => c.Membership.Student).Include(c=>c.ClubActivity).SingleOrDefault(c => c.Id == id);
                }

        public List<Participant> GetAll()
        {
            using var context = new ClubMembershipContext();
            return context.Participants.Include(c => c.Membership).Include(c => c.Membership.Student).Include(c => c.ClubActivity).ToList();
        }

        public List<Participant> GetByActivity(int id)
        {
            using var context = new ClubMembershipContext();
            List<Participant> list = new List<Participant>();
            foreach (Participant p in context.Participants.Include(c => c.Membership).Include(c => c.Membership.Student).Include(c => c.ClubActivity))
            {
                if (p.ClubActivityId == id)
                {
                    if(p.Status==true)
                    {
                        list.Add(p);
                    }
                }
            }
            return list;
        }

        public List<Participant> GetByMember(int id)
        {
            using var context = new ClubMembershipContext();
            List<Participant> list = new List<Participant>();
            foreach (Participant p in context.Participants.Include(c => c.Membership).Include(c=>c.Membership.Student).Include(c => c.ClubActivity))
            {
                if (p.MembershipId == id)
                {
                  if(p.Status==true)  list.Add(p);
                }
            }
            return list;
        }

        public void Update(Participant participant)
        {
            using var context = new ClubMembershipContext();
            context.Participants.Update(participant);
            context.SaveChanges();
        }
    }
}
