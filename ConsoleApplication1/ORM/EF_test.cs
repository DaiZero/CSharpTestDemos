using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZero.ConsoleApp.TestDemo
{
    class EF_Test
    {
        Student_dbEntities db = new Student_dbEntities();
        public void Add()
        {

            TblStudent stu = new TblStudent();
            stu.FirstName = "Shadow";
            stu.LastName = "Moon";
            stu.Age = 20;
            if (db.TblStudent.Where<TblStudent>(s => (s.FirstName + s.LastName) == (stu.FirstName + stu.LastName)).Count() > 0)
            {
                Console.WriteLine($"重复姓名：{stu.FirstName} {stu.LastName}");
            }
            else
            {
                //方法一：
                //sde.TblStudent.Add(stu);
                //方法二:
                db.Entry(stu).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                Console.WriteLine($"新增学生：{stu.FirstName} {stu.LastName}");
            }
        }

        public void Add2()
        {

            TblStudent stu = new TblStudent();
            stu.FirstName = "Shadow";
            stu.LastName = "Sun";
            stu.Age = 20;
            if (db.TblStudent.Where<TblStudent>(s => (s.FirstName + s.LastName) == (stu.FirstName + stu.LastName)).Count() > 0)
            {
                Console.WriteLine($"重复姓名：{stu.FirstName} {stu.LastName}");
            }
            else
            {
                db.TblStudent.Add(stu);
                db.SaveChanges();
                Console.WriteLine($"新增学生：{stu.FirstName} {stu.LastName}");
            }
        }

        public void Delete()
        {

            var studentlist = db.TblStudent.Where<TblStudent>(s => s.FirstName == "Shadow").ToList();
            if (studentlist != null)
            {
                foreach (TblStudent item in studentlist)
                {
                    //方法一：
                    //sde.TblStudent.Remove(item);
                    //方法二：
                    db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    Console.WriteLine($"删除：{item.FirstName} {item.LastName}");
                }
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("数据表无FirstName为Shadow的人");
            }
        }

        public List<TblStudent> QueryAll()
        {
            List<TblStudent> stulist = new List<TblStudent>();
            var studentPredicate = PredicateBuilder.False<TblStudent>();

            studentPredicate = studentPredicate.Or(x=>x.FirstName.Contains("Shadow"));
            studentPredicate = studentPredicate.Or(x => x.LastName.Contains("Sun"));

            var data = db.TblStudent.Where(studentPredicate).ToList();//.Compile() 将生成一个委托，表示 lambda 表达式。
            return data;
        }
    }
}
