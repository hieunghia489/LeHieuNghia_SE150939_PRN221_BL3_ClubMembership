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
    public class ClubBoardRepo : IClubBoardRepo
    {
        public ClubBoard Get(int id)
        {
            using var context = new ClubMembershipContext();
            return context.ClubBoards.Include(t => t.Club).SingleOrDefault(c => c.Id == id);
        }

        public List<ClubBoard> GetAll()
        {
            using var context = new ClubMembershipContext();
            return context.ClubBoards.Include(t => t.Club).ToList();
        }

        public List<ClubBoard> GetAllByClub(int clubId)
        {
            using var context = new ClubMembershipContext();
            List<ClubBoard> list = new List<ClubBoard>();
            foreach (ClubBoard board in context.ClubBoards.Include(t => t.Club))
            {
                if (board.ClubId == clubId)
                {
                    list.Add(board);
                }
            }
            return list;
        }

        public List<ClubBoard> GetCurrentByClub(int id)
        {
            using var context = new ClubMembershipContext();
            List<ClubBoard> list = new List<ClubBoard>();
            foreach (ClubBoard board in context.ClubBoards.Include(t => t.Club))
            {
                if (board.ClubId == id)
                {
                   if(board.Status==true) list.Add(board);
                }
            }
            return list;
        }
    }
}
