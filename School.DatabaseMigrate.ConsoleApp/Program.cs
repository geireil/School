using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.DataAccess;
using School.Model;

namespace School.DatabaseMigrate.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Filling db!");
            //PopulateDbWithSampleData();

            Console.ReadKey();            
        }

        private static void PopulateDbWithSampleData()
        {
            using (var data = new SchoolContext())
            {
                for (int i = 1; i < 5; i++)
                {
                    Course course = new Course() { CourseName = "Course nr: " + i.ToString() };
                    data.Courses.Add(course);

                    for (int j = 1; j <= 25; j++)
                    {
                        Student student = new Student() { Name = "Student Person " + i + j };
                        student.Attends.Add(new StudentCourse() { Student = student, Course = course });
                        data.Students.Add(student);
                    }
                }

                data.SaveChanges();
            }
        }
    }
}
