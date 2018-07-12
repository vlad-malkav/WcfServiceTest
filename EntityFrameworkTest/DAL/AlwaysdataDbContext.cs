using System;
using System.Data.Entity;
using System.Linq;
using EntityFrameworkTest.Models;

namespace EntityFrameworkTest.DAL
{
    public partial class AlwaysdataDbContext : DbContext
    {
        public AlwaysdataDbContext() : base("alwaysdata")
        {
            Database.SetInitializer<AlwaysdataDbContext>(new SchoolInitializer());
            Database.Initialize(true);
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        private static void AddStudent()
        {
            using (var context = new AlwaysdataDbContext())
            {
                var student = new Student
                {
                    LastName = "Khan",
                    FirstMidName = "Ali",
                    EnrollmentDate = DateTime.Parse("2005-09-01")
                };
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        private static void ChangeStudent()
        {
            using (var context = new AlwaysdataDbContext())
            {
                var student = (from d in context.Students
                    where d.FirstMidName == "Ali"
                    select d).Single();
                student.LastName = "Aslam";
                context.SaveChanges();

            }
        }

        private static void DeleteStudent()
        {

            using (var context = new AlwaysdataDbContext())
            {
                var bay = (from d in context.Students where d.FirstMidName == "Ali" select d).Single();
                context.Students.Remove(bay);
                context.SaveChanges();
            }
        }
    }
}