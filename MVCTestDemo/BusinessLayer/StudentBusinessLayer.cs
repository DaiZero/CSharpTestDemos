using MVCTestDemo.Models;
using System.Collections.Generic;
namespace MVCTestDemo.BusinessLayer
{
    public class StudentBusinessLayer
    {

        public List<StudentModel> GetStudents()
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
       
    }
}