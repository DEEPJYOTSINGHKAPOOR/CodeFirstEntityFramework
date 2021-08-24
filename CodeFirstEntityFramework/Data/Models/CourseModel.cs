using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEntityFramework.Data.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }



        public Author Author { get; set; }
        public int AuthorId { get; set; }



        public IList<Tag> Tags { get; set; }

        public IList<Student> Students { get; set; }
    }

}
