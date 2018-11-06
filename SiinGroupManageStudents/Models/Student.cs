using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiinGroupManageStudents.Models
{
    public class Student
    {
        [Key]
        public string RollNumber { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public StudentStatus Status { get; set; }

        public List<Mark> Marks { get; set; }

        public Student()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = StudentStatus.Deactive;
        }
    }

    public enum StudentStatus
    {
        Active = 1,
        Deactive = 0
    }
}
