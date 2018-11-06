using Microsoft.EntityFrameworkCore;

namespace SiinGroupManageStudents.Models
{
    public class SiinGroupManageStudentsContext : DbContext
    {
        public SiinGroupManageStudentsContext (DbContextOptions<SiinGroupManageStudentsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    RollNumber = "D00538",
                    FullName = "Ngô Văn Tuấn",
                    Email = "admin@siingroup.com"
                },
                new Student()
                {
                    RollNumber = "D00529",
                    FullName = "Phan Văn Hoàng Hưng",
                    Email = "nhuconcua@gmail.com"
                },
                new Student()
                {
                    RollNumber = "D00553",
                    FullName = "Nguyễn Văn Ngọc",
                    Email = "ngaccoc@gmail.com"
                }
            );
            modelBuilder.Entity<Mark>().HasData(
                new Mark()
                {
                    Id = 1,
                    SubjectName = "Java Core",
                    StudentRollNumber = "D00538",
                    SubjectMark = 9
                },
                new Mark()
                {
                    Id = 2,
                    SubjectName = "C#",
                    StudentRollNumber = "D00529",
                    SubjectMark = 7
                },
                new Mark()
                {
                    Id = 3,
                    SubjectName = "PHP",
                    StudentRollNumber = "D00553",
                    SubjectMark = 8
                }
            );
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Mark> Mark { get; set; }
    }
}
