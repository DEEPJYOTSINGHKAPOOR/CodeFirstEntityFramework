

using CodeFirstEntityFramework.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace CodeFirstEntityFramework
{
    public class PlutoContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Student> Students { get; set;  }


        //we have named are connection string as DefaultConnection in appconfig so thats why we need to specify here, 
        //we can also specify class name i.e PlutoContext as connstring in appconfig ,in this way we dont need to specify base name
        public PlutoContext()
            : base("name = DefaultConnection")
        {

        }

        //chain method call - thats why called as fluent api
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(t => t.Description)
                .IsRequired();




            //! s1-c1,c2
            //! s2 - c1,c2,c5
            //! will automatically generate StudentCourse table
            //! many to many - Student--course
            modelBuilder.Entity<Student>()
              .HasMany<Course>(s => s.Courses)
              .WithMany(c => c.Students)
              .Map(cs =>
              {
                  cs.MapLeftKey("StudentRefId");
                  cs.MapRightKey("CourseRefId");
                  cs.ToTable("StudentCourse");
              });

            // a course can have 1 author, 
            //1 author can have many courses
            modelBuilder.Entity<Course>()
                .HasRequired<Author>(a => a.Author)
                .WithMany(c => c.Courses)
                .HasForeignKey<int>(a => a.AuthorId);
        }

    }
}
