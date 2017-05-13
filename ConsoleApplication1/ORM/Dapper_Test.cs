using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DZero.ConsoleApp.TestDemo
{
    public class Dapper_Test
    {
        public static string connectionString =ConfigurationManager.ConnectionStrings["TblStudentConnection"].ConnectionString;
       
        public void Insert(StudentModel stu)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                var result = conn.Execute("Insert into TblStudent values (@FirstName, @LastName, @Age)",
                                new { FirstName = stu.FirstName, LastName = stu.LastName, Age = stu.Age });
            }
        }

        public void InsertBulk(List<StudentModel>  stulist)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                var result = conn.Execute("Insert into TblStudent values (@FirstName, @LastName, @Age)",stulist);
            }
        }

        public void Delete(string stuId)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                var result = conn.Execute("Delete from TblStudent where StudentId=@StudentId",
                                new { StudentId = stuId });
            }
        }


        public List<StudentModel> Query(string strLastName)
        {
            List<StudentModel> stuList = new List<StudentModel>();
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                stuList = conn.Query<StudentModel>("select * from TblStudent where LastName=@LastName", new { LastName = strLastName }).AsList();
            }
            if (stuList.Count > 0)
            {
                stuList.ForEach((stu) => Console.WriteLine($"Name:{stu.FirstName} {stu.LastName} " + "\n"));
                Console.ReadLine();
            }
            return stuList;
        }

        public List<StudentModel> QueryAll()
        {
            List<StudentModel> stuList = new List<StudentModel>();
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                stuList = conn.Query<StudentModel>("select * from TblStudent").AsList();
            }
            //if (stuList.Count > 0)
            //{
            //    stuList.ForEach((stu) => Console.WriteLine($"ID:{stu.StudentId} Name:{stu.FirstName} {stu.LastName} Age:{stu.Age}" + "\n"));
            //    Console.ReadLine();
               
            //}
            return stuList;
        }

        public  void ExecuteStoredProcedureWithParms(DynamicParameters p1)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@UserName", "cooper");
            p.Add("@Password", "123456");
            p.Add("@LoginActionType", null, DbType.Int32, ParameterDirection.ReturnValue);
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute("dbo.p_validateUser", p, null, null, CommandType.StoredProcedure);
                int result = p.Get<int>("@LoginActionType");
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }

    }
}
