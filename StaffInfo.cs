using HighschoolDBv8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HighschoolDBv8
{
    internal class StaffInfo
    {
        public static void ShowAllStaff()
        {
            using HighschoolDbContext db = new HighschoolDbContext();
            var staffs = db.StaffTables.ToList();
            Console.WriteLine("\n\tHere are all school staffs.");
            DisplayStaff(staffs);
        }
        public static void DisplayStaff(List<StaffTable> staffs)
        {
            Console.Clear();
            Console.WriteLine("--------");
            foreach (StaffTable staff in staffs)
            {
                Console.WriteLine($"\n\tID: {staff.StaffId}");
                Console.WriteLine($"\tFirst name: {staff.FirstName}");
                Console.WriteLine($"\tLast name: {staff.LastName}");
                Console.WriteLine($"\tPosition: {staff.Position}");
                if (staff.Position == "Teacher")
                {
                    foreach (Class item in staff.Classes)
                    {
                        Console.WriteLine($"\tClass: {item.ClassName}");
                    }
                }
                Console.WriteLine("\t" + new string('-', 20));
            }
            Console.ReadKey();
        }
        public static void ShowAllTeacher()
        {
            using HighschoolDbContext db = new HighschoolDbContext();
            var teachers = db.StaffTables.Include(t => t.Classes).Where(t => t.Position == "Teacher").ToList();
            DisplayStaff(teachers);
        }
        public static void ShowStaffNum()
        {
            using HighschoolDbContext db = new HighschoolDbContext();
            Console.WriteLine("\n\tHere are numbers of staffs\n");
            int teacherNum = db.StaffTables.Count(s => s.Position == "Teacher");
            int libraryanNum = db.StaffTables.Count(s => s.Position == "Librarian");
            int principleNum = db.StaffTables.Count(s => s.Position == "Principal");
            int adminNum = db.StaffTables.Count(s => s.Position == "Administrator");
            int secNum = db.StaffTables.Count(s => s.Position == "Security");
            int nurseNum = db.StaffTables.Count(s => s.Position == "Nurse");
            // Select Position, Count(*) From StaffTable Group By Position;
            Console.WriteLine($"\tTeacher: {teacherNum}\n\tLibrarian: {libraryanNum}" +
                $"\n\tPrincipal: {principleNum}\n\tAdministrator: {adminNum} " +
                $"\n\tSecurity: {secNum}\n\tSchoolNurse: {nurseNum}");
            Console.ReadKey();
        }
    }
}
