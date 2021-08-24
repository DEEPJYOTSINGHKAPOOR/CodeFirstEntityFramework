using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEntityFramework.Data.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }


        public string StudentName { get; set; }

        public IList<Course> Courses { get; set; }
    }
}
