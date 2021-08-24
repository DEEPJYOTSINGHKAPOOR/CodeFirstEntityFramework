
using CodeFirstEntityFramework.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace CodeFirstEntityFramework
{

    public enum CourseLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }

    // a course can have q author and many tags
   

    // a author can have many courses
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");
            PlutoContext plutoContext = new PlutoContext();


            //plutoContext.Authors.Add(new Author()
            //{
            //    Id = 2,
            //    Name = "Mihir"
            //});
            //plutoContext.SaveChanges();


            plutoContext.Courses.Add(new Course() {
                AuthorId=1,
                Id=1,
                Description="intro to c++ course",
                FullPrice=320,
                
                Tags =new List<Tag>{
                    new Tag() { 
                        Id=1,
                        Name = "C++"
                    }
                },
                Level = CourseLevel.Beginner,
                Title = "C++ Introduction"
            });
            plutoContext.SaveChanges();

            //plutoContext.Authors.Add();


        }
    }
}

//its easier to write data annotations and write less code but it makes our domain classes very cluttered since we need to
//give db-specific knowledge, so generally prefer fluent-api