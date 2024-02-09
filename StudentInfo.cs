using HighschoolDBv8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighschoolDBv8
{
    internal class StudentInfo
    {
        public static void ShowAllStudents()
        {
            using HighschoolDbContext db = new HighschoolDbContext();
            var students = db.Students.Include(s => s.Class);
            foreach (var student in students)
            {
                Console.WriteLine($"\n\tID: {student.StudentId}");
                Console.WriteLine($"\tFirst name: {student.FirstName}");
                Console.WriteLine($"\tLast name: {student.LastName}");
                Console.WriteLine($"\tPosition: {student.Class.ClassName}");
            }
            Console.ReadKey();
        }
        public static void ShowStudentsByNameOrder()
        {
            using HighschoolDbContext db = new HighschoolDbContext();
            List<Student> students;
            switch (GetNameOrderChoice())
            {
                case 1:
                    students = db.Students.Include(s => s.Class).OrderBy(s => s.FirstName).ToList();
                    DisplayStudents(students);
                    break;
                case 2:
                    students = db.Students.Include(s => s.Class).OrderByDescending(s => s.FirstName).ToList();
                    DisplayStudents(students);
                    break;
                case 3:
                    students = db.Students.Include(s => s.Class).OrderBy(s => s.LastName).ToList();
                    DisplayStudents(students);
                    break;
                case 4:
                    students = db.Students.Include(s => s.Class).OrderByDescending(s => s.LastName).ToList();
                    DisplayStudents(students);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        public static void DisplayStudents(List<Student> students)
        {
            Console.Clear();
            foreach (Student student in students)
            {
                Console.WriteLine($"\n\tClass: {student.Class.ClassName}");
                Console.WriteLine($"\tFirst Name: {student.FirstName}");
                Console.WriteLine($"\tLast Name : {student.LastName}");
                Console.WriteLine("\t" + new string('-', 20));
            }
            Console.ReadKey();
        }
        public static int GetNameOrderChoice()
        {
            Console.Clear();
            Console.WriteLine("\tView the students sorted by first name or last name");
            Console.WriteLine("\t1. First Name\n\t2. Last Name");
            Console.Write("\n\tSelect: ");
            if (!int.TryParse(Console.ReadLine(), out int nameChoice) || (nameChoice != 1 && nameChoice != 2))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.ReadKey();
                return 0;
            }
            Console.Clear();
            if (nameChoice == 1)
            {
                Console.WriteLine("\tView the students sorted First name by ascending or descending");
                Console.WriteLine("\t1. Ascending\n\t2. Descending");
                Console.Write("\n\tSelect: ");
                if (!int.TryParse(Console.ReadLine(), out int orderChoice) || (orderChoice != 1 && orderChoice != 2))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    return 0;
                }
                if (orderChoice == 1)
                    return 1;
                else
                    return 2;
            }
            else
            {
                Console.WriteLine("\tView the students sorted First name by ascending or descending");
                Console.WriteLine("\t1. Ascending\n\t2. Descending");
                Console.Write("\n\tSelect: ");
                if (!int.TryParse(Console.ReadLine(), out int orderChoice) || (orderChoice != 1 && orderChoice != 2))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.ReadKey();
                    return 0;
                }
                if (orderChoice == 1)
                    return 3;
                else
                    return 4;
            }
        }
        public static void ShowStudentsByClass()
        {
            Console.Clear();
            using HighschoolDbContext db = new HighschoolDbContext();
            Console.Write("\n\tInsert Class Name: ");
            string className = Console.ReadLine();
            var result = db.Classes.Where(c => c.ClassName == className).FirstOrDefault();
            if (result == null)
            {
                Console.Clear();
                Console.WriteLine("\n\n\tOooops!Something went wrong.");
                Console.ReadKey();
                return;
            }
            int classID = result.Id;
            List<Student> students = db.Students.Where(s => s.ClassId == classID).ToList();
            DisplayStudents(students);
        }
    }
}
