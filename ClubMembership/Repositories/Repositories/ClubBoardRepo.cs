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
        public void Add(ClubBoard clubBoard)
        {
            using var context = new ClubMembershipContext();
        context.ClubBoards.Add(clubBoard);
            context.SaveChanges();
        }

        public void Delete(ClubBoard clubBoard)
        {
            using var context = new ClubMembershipContext();
            clubBoard.Status = false;
            context.ClubBoards.Update(clubBoard);
            context.SaveChanges();
        }

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
                {if(board.Status==true)
                    list.Add(board);
                }
            }
            return list;
        }

        public ClubBoard GetCurrentByClub(int id)
        {
            using var context = new ClubMembershipContext();
            List<ClubBoard> list = new List<ClubBoard>();
            foreach (ClubBoard board in context.ClubBoards.Include(t => t.Club))
            {
                if (board.ClubId == id)
                {
                    if (board.Status == true)
                        list.Add(board);
                }
            }
            if (list.Count != 0) return list.Last();
            else return null;
        }
    }
}
