using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZero.ConsoleApp.TestDemo
{
    class EF_Test
    {
        Student_dbEntities sde = new Student_dbEntities();
        public void Add()
        {

            TblStudent stu = new TblStudent();
            stu.FirstName = "Shadow";
            stu.LastName = "Moon";
            stu.Age = 20;
            if (sde.TblStudent.Where<TblStudent>(s => (s.FirstName + s.LastName) == (stu.FirstName + stu.LastName)).Count() > 0)
            {
                Console.WriteLine($"重复姓名：{stu.FirstName} {stu.LastName}");
            }
            else
            {
                sde.TblStudent.Add(stu);
                sde.SaveChanges();
                Console.WriteLine($"新增学生：{stu.FirstName} {stu.LastName}");
            }
        }

        public void Add2()
        {

            TblStudent stu = new TblStudent();
            stu.FirstName = "Shadow";
            stu.LastName = "Sun";
            stu.Age = 20;
            if (sde.TblStudent.Where<TblStudent>(s => (s.FirstName + s.LastName) == (stu.FirstName + stu.LastName)).Count() > 0)
            {
                Console.WriteLine($"重复姓名：{stu.FirstName} {stu.LastName}");
            }
            else
            {
                sde.TblStudent.Add(stu);
                sde.SaveChanges();
                Console.WriteLine($"新增学生：{stu.FirstName} {stu.LastName}");
            }
        }

        public void Delete()
        {

            var studentlist = sde.TblStudent.Where<TblStudent>(s => s.FirstName == "Shadow").ToList();
            if (studentlist != null)
            {
                
                foreach (TblStudent item in studentlist)
                {
                    sde.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    Console.WriteLine($"删除：{item.FirstName} {item.LastName}");
                }
                sde.SaveChanges();
            }
            else
            {
                Console.WriteLine("数据表无FirstName为Shadow的人");
            }
        }
    }
}
