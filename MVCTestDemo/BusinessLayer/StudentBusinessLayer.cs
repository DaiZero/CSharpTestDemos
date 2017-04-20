using DZero.Mvc.TestDemo.Models;
using System.Collections.Generic;
using DZero.Mvc.TestDemo.DataAccessLayer;
using System.Linq;

namespace DZero.Mvc.TestDemo.BusinessLayer
{
    public class StudentBusinessLayer
    {

        public List<StudentModel> GetStudentss()
        {
            List<StudentModel> stulist = new List<Models.StudentModel>();
            StudentModel st = new StudentModel()
            {
                FirstName = "Wei",
                LastName = "Liu",
                Age = 17
            };
            stulist.Add(st);
            st = new StudentModel()
            {
                FirstName = "Feng",
                LastName = "Wang",
                Age = 26
            };
            stulist.Add(st);
            st = new StudentModel()
            {
                FirstName = "Brous",
                LastName = "Lee",
                Age = 15
            };
            stulist.Add(st);
            st = new StudentModel()
            {
                FirstName = "Jack",
                LastName = "Chen",
                Age = 30
            };
            stulist.Add(st);
            return stulist;
        }
        public List<StudentModel> GetStudents()
        {
            SchoolDAL scooldal = new SchoolDAL();
            return scooldal.Studentes.ToList();
        }
        public bool IsValidUser(UserDetailsModels u)
        {
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public StudentModel Savestudent(StudentModel e)
        {
            SchoolDAL salesDal = new SchoolDAL();
            salesDal.Studentes.Add(e);
            salesDal.SaveChanges();
            return e;
        }
    }
}