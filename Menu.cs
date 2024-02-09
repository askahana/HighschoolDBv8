using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighschoolDBv8
{
    internal class Menu
    {
        public static void GetMenuChoice()
        {
            bool isKeeping = true;
            while (isKeeping)
            {
                Console.Clear();
                Console.WriteLine("\n\t[Maine Menu]\n\n\tChoose what data you would like to accesss.");
                Console.WriteLine("\n\n\t1. Student\n\t2. School staff\n\t3. Grade and Course\n\t4. Exit");
                string select = "Select";
                int choice = Validator.GetValidInt(select);
                switch (choice)
                {
                    case 1:
                        StudentMenu();
                        break;
                    case 2:
                        StaffMenu();
                        break;
                    case 3:
                        GradeMenu();
                        break;
                    case 4:
                        isKeeping = false;
                        Console.WriteLine("\tThank you for using!");
                        break;
                    default:
                        Console.WriteLine("\n\tSelect 1 - 3");
                        break;
                }
            }
            Console.ReadKey();
        }
        public static void StudentMenu()
        {
            bool isKeeping = true;
            while (isKeeping)
            {
                Console.Clear();
                string menu1 = "\n\t1. See students by ID order\n";
                string menu2 = "\t2. See students by name order\n";
                string menu3 = "\t3. See students by class.\n";
                string menu4 = "\t4. Go back to main menu\n";
                string select = "\n\tSelect";
                string menu = menu1 + menu2 + menu3 + menu4 + select;
                int choice = Validator.GetValidInt(menu);
                switch (choice)
                {
                    case 1:
                        StudentInfo.ShowAllStudents();
                        break;
                    case 2:
                        StudentInfo.ShowStudentsByNameOrder();
                        break;
                    case 3:
                        StudentInfo.ShowStudentsByClass();
                        break;
                    case 4:
                        isKeeping = false;
                        GetMenuChoice();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void GradeMenu()
        {
            bool isKeeping = true;
            while (isKeeping)
            {
                Console.Clear();
                string menu1 = "\n\t1. See all courses\n";
                string menu2 = "\t2. See all grades by course\n";
                string menu3 = "\t3. See grades each student. \n";
                string menu4 = "\t4. See average grades by course.\n";
                string menu5 = "\t5. Go back to main menu\n";
                string select = "\n\tSelect";
                string menu = menu1 + menu2 + menu3 + menu4 + menu5 + select;
                int choice = Validator.GetValidInt(menu);
                switch (choice)
                {
                    case 1:
                        CourseInfo.ShowAllCourse();
                        break;
                    case 2:
                        GradeInfo.ShowGradeByCourse();
                        break;
                    case 3:
                        GradeInfo.ShowGradeByID();
                        break;
                    case 4:
                        GradeInfo.ShowAvgGradeByCourse();
                        break;
                    case 5:
                        isKeeping = false;
                        GetMenuChoice();
                        break;
                    default:
                        break;
                }
            }
        }
        public static void StaffMenu()
        {
            bool isKeeping = true;
            while (isKeeping)
            {
                Console.Clear();
                string menu1 = "\n\t1. See all school staff\n";
                string menu2 = "\t2. See all teachers \n";
                string menu3 = "\t3. Add new staff.\n"; // See teacher info by id
                string menu4 = "\t4. See the number of staff\n";
                string menu5 = "\t5. Go back to main menu\n";
                string menu6 = "\t6. See teachers avarage salary by position\n";
                string select = "\n\tSelect";
                string menu = menu1 + menu2 + menu3 + menu4 + menu5+ select;
                int choice = Validator.GetValidInt(menu);
                switch (choice)
                {
                    case 1:
                        StaffInfo.ShowAllStaff();
                        break;
                    case 2:
                        StaffInfo.ShowAllTeacher();
                        break;
                    case 3:
                        DataManagement.AddNewStaff();
                        break;
                    case 4:
                        StaffInfo.ShowStaffNum();
                        break;
                    case 5:
                        isKeeping = false;
                        GetMenuChoice();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
