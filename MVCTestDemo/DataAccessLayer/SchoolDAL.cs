using System.Data.Entity;
using MVCTestDemo.Models;
namespace MVCTestDemo.DataAccessLayer
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