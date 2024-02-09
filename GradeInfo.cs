using HighschoolDBv8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighschoolDBv8
{
    internal class GradeInfo
    {
        public static void ShowGradeByCourse()
        {
            Console.Clear();
            using HighschoolDbContext db = new HighschoolDbContext();
            var grades = db.Grades.Include(g => g.Course).Include(g => g.Student).OrderBy(g => g.CourseId);
            foreach (var grade in grades)
            {
                Console.WriteLine($"\tCourse: {grade.Course.CourseName}");
                Console.WriteLine($"\tStudent: {grade.Student.FirstName} {grade.Student.LastName}");
                Console.WriteLine($"\tScore: {grade.Score}");
                Console.WriteLine("\t" + new string('-', 20));
            }
            Console.ReadKey();
        }
        public static void ShowGradeByID()
        {
            Console.Clear();
            using HighschoolDbContext db = new HighschoolDbContext();
            Console.Write("\tWrite class name: ");
            string className = Console.ReadLine();
            var classMembers = db.Students.Where(s => s.Class.ClassName == className);
            if (classMembers.Any())
            {
                Console.WriteLine("\n\n\tHere are the members:");
                foreach (Student member in classMembers)
                {
                    Console.WriteLine($"\tStudentID: {member.StudentId} {member.FirstName} {member.LastName}");
                }
            }
            else
            {
                Console.WriteLine("\tNo students found for the given class name");
                return;
            }
            Console.Write("\n\n\tInsert sutdentid: ");
            int inputID = Convert.ToInt32(Console.ReadLine());
            var grades = db.Grades.Include(g => g.Course).Include(g => g.Student).OrderBy(g => g.CourseId).Where(s => s.Student.StudentId == inputID);
            foreach (var grade in grades)
            {
                Console.WriteLine($"\n\tCourse: {grade.Course.CourseName}");
                Console.WriteLine($"\tStudent: {grade.Student.FirstName} {grade.Student.LastName}");
                Console.WriteLine($"\tScore: {grade.Score}");
                Console.WriteLine("\t" + new string('-', 20));
            }
            Console.ReadKey();
        }
        public static void ShowAvgGradeByCourse()
        {
            Console.Clear();
            using HighschoolDbContext db = new HighschoolDbContext();
            Console.WriteLine("\n\tHere is list of courses: ");
            var courses = db.Courses;
            foreach (var course in courses)
            {
                Console.WriteLine($"\n\tCourse ID: {course.Id}");
                Console.WriteLine($"\tCoure Name:{course.CourseName} ");
            }
            Console.Write("\n\tWrite course ID: ");
            int courseID = Convert.ToInt32(Console.ReadLine());
            var grades = db.Grades.Include(g => g.Course).Where(g => g.Course.Id == courseID);
            var avg = grades.Average(g => g.Score);
            Console.Clear();
            var specificCourse = db.Courses.Where(g => g.Id == courseID).FirstOrDefault();
            Console.WriteLine("\n\t" + courseID + ": " + specificCourse.CourseName);
            Console.WriteLine("\tAverage grade for the course : " + avg);
            Console.ReadKey();
        }
    }
}
