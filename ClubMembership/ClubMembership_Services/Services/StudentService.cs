﻿using ClubMembership_Repositories.Interfaces;
using ClubMembership_Services.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembership_Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;
        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public IEnumerable<Student> GetGrades() => _studentRepo.GetAll();

        public Student GetStudent(int id)=> _studentRepo.Get(id);

        public Student GetStudentByCode(string code)=> _studentRepo.GetByCode(code);
    }
}
