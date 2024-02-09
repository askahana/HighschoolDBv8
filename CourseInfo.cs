using HighschoolDBv8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighschoolDBv8
{
    internal class CourseInfo
    {
        public static void ShowAllCourse()
        {
            Console.Clear();
            using HighschoolDbContext db = new HighschoolDbContext();
            var courses = db.Courses;
            Console.WriteLine("\n\tHere är all courses\n");
            foreach(var course in courses)
            {
                Console.WriteLine($"\t・ {course.CourseName}");               
            }
            Console.ReadKey();
        }
    }
}
