using System.Web.Mvc;
using MVCTestDemo.Models;
using MVCTestDemo.ViewModels;
using MVCTestDemo.BusinessLayer;
using System.Collections.Generic;
using System;

namespace MVCTestDemo.Controllers
{
    public class MyStudentModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            StudentModel e = new StudentModel();
            e.FirstName = controllerContext.RequestContext.HttpContext.Request.Form["FName"];
            e.LastName = controllerContext.RequestContext.HttpContext.Request.Form["LName"];
            var age = controllerContext.RequestContext.HttpContext.Request.Form["Age"];
            e.Age = Convert.ToInt32(age == null ? "0" : age == "" ? "0" : age);
            return e;
        }
    }
    public class Student_Test
    {
        public string StudentName { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return this.StudentName + "，" + this.Age.ToString() + "岁";
        }
    }

    public class StudentController : Controller
    {
        public string Hello()
        {
            return "Hellos";
        }

        public Student_Test GetStudent()
        {
            Student_Test s = new Student_Test()
            {
                StudentName = "Zero",
                Age = 25
            };
            //当返回的类型是「Student_Test」这样的对象时，它会返回对象的实现方法 「ToString()」。
            //方法「ToString()」 默认返回类的全名，即 「NameSpace.ClassName」这样的形式。
            return s;

        }

        [NonAction]//加上 NonAction 属性此方法将不会被web调用到
        public string SimpleMethod()
        {
            return "Hi, I am not action method";
        }

        public ActionResult GetView()
        {
            StudentModel student = new StudentModel();
            student.FirstName = "Zero";
            student.LastName = "Dai";
            student.Age = 12;
            ViewData["Student"] = student;//ViewBag.Student = student;

            StudentModel student2 = new StudentModel();
            student2.FirstName = "Mike";
            student2.LastName = "Jack";
            student2.Age = 30;
            return View("MyView", student2);
        }
        public ActionResult StudentView()
        {
            StudentModel student = new StudentModel();
            student.FirstName = "Zero";
            student.LastName = "Dai";
            student.Age = 12;

            StudentViewModel svm = new StudentViewModel();
            svm.StudentName = student.FirstName + " " + student.LastName;
            svm.Age = student.Age;
            svm.AgeColor = svm.Age > 18 ? "yellow" : "darkseagreen";
            return View("StudentView", svm);
        }
        public ActionResult Index()
        {
            StudentBusinessLayer sbl = new StudentBusinessLayer();
            List<StudentModel> smList = new List<StudentModel>();
            smList = sbl.GetStudents();

            List<StudentViewModel> svmlist = new List<StudentViewModel>();
            foreach (StudentModel item in smList)
            {
                StudentViewModel svm = new StudentViewModel();
                svm.StudentName = item.FirstName + " " + item.LastName;
                svm.Age = item.Age;
                svm.AgeColor = svm.Age > 18 ? "Red" : "darkseagreen";
                svmlist.Add(svm);
            }

            StudentListViewModel slvm = new StudentListViewModel();
            slvm.Student = svmlist;
            //slvm.UserName = "DZero";

            return View("Index", slvm);
        }
        public ActionResult AddNew()
        {
            return View("CreateStudent");
        }

        public ActionResult SaveStudent([ModelBinder(typeof(MyStudentModelBinder))]StudentModel e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        StudentBusinessLayer stubal = new StudentBusinessLayer();
                        stubal.Savestudent(e);
                        //return Content(e.FirstName + "|" + e.LastName + "|" + e.Age);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("CreateStudent");
                    }

                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
    }
}