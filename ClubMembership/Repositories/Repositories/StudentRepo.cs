using ClubMembership_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Repositories.Repositories
{
    public class StudentRepo : IStudentRepo
    {
        public Student Get(int id)
        {
            using var context = new ClubMembershipContext();
            return context.Students.Include(c=>c.Grade).Include(c=>c.Major).SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            using var context = new ClubMembershipContext();
            return context.Students.Include(c => c.Grade).Include(c => c.Major).ToList();
        }

        public Student GetByCode(string code)
        {
            using var context = new ClubMembershipContext();
            return context.Students.Include(c => c.Grade).Include(c => c.Major).SingleOrDefault(c => c.Code == code);
        }
    }
}
