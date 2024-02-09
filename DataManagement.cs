using HighschoolDBv8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighschoolDBv8
{
    internal class DataManagement
    {
        public static void AddNewStaff()
        {
            Console.Clear();
            using HighschoolDbContext db = new HighschoolDbContext();
            string firstname = "First name ";
            string fitstName = Validator.GetValidString(firstname);
            string lastname = "Last name ";
            string lastName = Validator.GetValidString(lastname);
            string p = "Position ";
            string position = Validator.GetValidString(p);
            StaffTable t1 = new StaffTable()
            {
                FirstName = fitstName,
                LastName = lastName,
                Position = position,
            };
            int confirm = Validator.GetValidInt("\n\tConfirm? \n\t[1]. Yes\n\t[2]. No\n\tselect ");
            if (confirm == 1)
            {
                db.StaffTables.Add(t1);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("You will go back to menu.");
                return;
            }
        }
        public void AddNewStudent()
        {
            Console.Clear();
            using HighschoolDbContext db = new HighschoolDbContext();
            string firstname = "First name ";
            string fitstName = Validator.GetValidString(firstname);
            string lastname = "Last name ";
            string lastName = Validator.GetValidString(lastname);
            string personalid = "personal ID ";
            string perosnalID = Validator.GetValidString(personalid);
            string classroom = "class ";
            int classId = Validator.GetValidInt(classroom);
            Student s1 = new Student()
            {
                FirstName = fitstName,
                LastName = lastName,
                PersonalId = personalid,
                ClassId = classId,
            };
            int confirm = Validator.GetValidInt("\n\tConfirm? \n\t[1]. Yes\n\t[2]. No\n\tselect ");
            if (confirm == 1)
            {
                db.Students.Add(s1);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("You will go back to menu.");
                return;
            }
        }
        public static void InsertGrade()
        {
            Console.Clear();
            using HighschoolDbContext db = new HighschoolDbContext();
            string studentid = "StudentID ";
            string teacherid = "TeacherID ";
            
            Grade g = new Grade()
            {

            };
            int confirm = Validator.GetValidInt("\n\tConfirm? \n\t[1]. Yes\n\t[2]. No\n\tselect ");
            if (confirm == 1)
            {
                db.Grades.Add(g);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("You will go back to menu.");
                return;
            }
        }
    }
}
