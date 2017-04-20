using System.Data.Entity;
using DZero.Mvc.TestDemo.Models;
namespace DZero.Mvc.TestDemo.DataAccessLayer
{
    public class SchoolDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>().ToTable("TblStudent");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<StudentModel> Studentes { get; set; }
    }

}