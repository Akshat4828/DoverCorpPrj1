using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class TeacherDatabase
    {
        public int id { get; set; }
        public string tName { get; set; }
        public string subject { get; set; }
        public string emailId { get; set; }
    }


    class TeacherDO
    {
        public List<TeacherDatabase> teachers { get; set; }

        public TeacherDO()
        {
            teachers = new List<TeacherDatabase>()
            {
                new TeacherDatabase{ id = 101, tName = "AKSHAT", subject = "Python", emailId = "a@gmail.com"},
                new TeacherDatabase{ id = 102, tName = "JACK",   subject = "CLOUD",  emailId = "b@gmail.com"},
                new TeacherDatabase{ id = 103, tName = "EMLY",   subject = "JAVA",   emailId = "c@gmail.com"},
                new TeacherDatabase{ id = 104, tName = "SHAAN",  subject = "REACT",  emailId = "d@gmail.com"}
            };
        }

        public List<TeacherDatabase> GetAllTeachers()
        {
            return teachers;
        }

        public TeacherDatabase GetTeacherById(int id)
        {
            TeacherDatabase temp;
            foreach (TeacherDatabase t in teachers)
            {
                if (t.id == id)
                    return temp = new TeacherDatabase { id = t.id, tName = t.tName, subject = t.subject, emailId = t.emailId };

            }
            Console.WriteLine("ID didn't Mached");
            return null;

        }

        public bool AddTeacher(List<TeacherDatabase> t1, TeacherDatabase t)
        {
            t1.Add(t);
            return true;
        }

        public bool EditTeachers(List<TeacherDatabase> t1, TeacherDatabase t2)
        {

            foreach (TeacherDatabase t in t1)
            {
                if (t.id == t2.id)
                {
                    if (!t2.tName.Equals("NA"))
                        t.tName = t2.tName;

                    if (!t2.subject.Equals("NA"))
                        t.subject = t2.subject;

                    if (!t2.emailId.Equals("NA"))
                        t.emailId = t2.emailId;

                }
                return true;
            }
            return false;
        }

        public bool deleteTeacher(List<TeacherDatabase> td, int id)
        {
            foreach (TeacherDatabase t in td)
            {


                if (t.id == id)
                {
                    td.Remove(t);
                    return true;

                }
            }
            return false;
        }
    }
    class Project
    {
        static void Main(string[] args)
        {
            TeacherDO context = new TeacherDO();
            List<TeacherDatabase> teachers = context.GetAllTeachers().ToList();

            Console.WriteLine($"1. DISPLAY all teacher record");
            Console.WriteLine($"2. FETCH a particular teacher record by ID");
            Console.WriteLine($"3. ADD new teacher");
            Console.WriteLine($"4. EDIT teacher record");
            Console.WriteLine($"5. DELETE teacher");
            Console.WriteLine("===============================");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter the Operation you need to perform :");
                int ch = Convert.ToInt32(Console.ReadLine());
                
                if (ch > 5)
                {
                    Console.WriteLine("Please Enter Proper Option");
                    break;
                }
                else
                {
                    switch (ch)
                    {
                        case 1:
                            
                                    Console.WriteLine();
                                    foreach (TeacherDatabase t in teachers)
                                    {
                                        Console.WriteLine($"{t.id} {t.tName} {t.subject} {t.emailId}");
                                    }
                                    break;

                        case 2:
                                    Console.WriteLine();
                                    Console.WriteLine("Enter the Id to be Searched");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();

                                    TeacherDatabase res = context.GetTeacherById(id);
                                    Console.WriteLine($"TeacherId = {res.id}   ");
                                    Console.WriteLine($"TeacherName = {res.tName}");
                                    Console.WriteLine($"Subject = {res.subject}");
                                    Console.WriteLine($"EmailId = {res.emailId}");
                                    break;

                        case 3:
                                
                                        Console.WriteLine();
                                        Console.WriteLine("Enter the Number of Teacher you want to add ");
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                        for (int i = 0; i < n; i++)
                                        {


                                            TeacherDatabase t = new TeacherDatabase();
                                            Console.WriteLine("Please Enter the Id");
                                            t.id = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Please Enter the Name");
                                            t.tName = Console.ReadLine();
                                            Console.WriteLine("Please Enter the Subject");
                                            t.subject = Console.ReadLine();
                                            Console.WriteLine("Please Enter the EmailId");
                                            t.emailId = Console.ReadLine();
                                            if (context.AddTeacher(teachers, t) == true)
                                            {

                                                Console.WriteLine("Teacher Data Added");
                                 
                                            }
                                            else
                                                Console.WriteLine("Not Added");
                                        }
                                        Console.WriteLine();
                                        Console.WriteLine("========================================");
                                        Console.WriteLine("Teachers after Added to DataBase");

                                        foreach (TeacherDatabase t in teachers)
                                        {
                                            Console.WriteLine($"{t.id} {t.tName} {t.subject} {t.emailId}");
                                        }

                                        break;
                            case 4:

                                    TeacherDatabase td = new TeacherDatabase();
                                    Console.WriteLine("Enter the Id u Want to update");
                                    td.id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter The Teacher name you want to update else assign NA");
                                    td.tName = Console.ReadLine();
                                    Console.WriteLine("Enter The  Subject you want to update else assign NA");
                                    td.subject = Console.ReadLine();
                                    Console.WriteLine("Enter the EnailId you want to update else assign 0");
                                    td.emailId = Console.ReadLine();
                                    if (context.EditTeachers(teachers, td) == true)
                                        Console.WriteLine("Edited");
                                    else
                                        Console.WriteLine("Not Edited");

                                    Console.WriteLine("TEACHET DATABASE AFTER EDITING");
                                    Console.WriteLine("=============================================");
                                    foreach (TeacherDatabase t in teachers)
                                        Console.WriteLine($"{t.id} {t.tName} {t.subject} {t.emailId}");

                                    break;

                        case 5:
                                    Console.WriteLine("Enter the Id to be Deleted");
                                    int t_id = Convert.ToInt32(Console.ReadLine());
                                    if (context.deleteTeacher(teachers, t_id) == true)
                                        Console.WriteLine($"Teacher record deleted having id {t_id}");
                                    else
                                        Console.WriteLine($"{t_id} not found");
                                    Console.WriteLine("=======================================");
                                    Console.WriteLine();
                                    Console.WriteLine("DataBase after deleting Record");
                                    foreach (TeacherDatabase t in teachers)
                                        Console.WriteLine($"{t.id} {t.tName} {t.subject} {t.emailId}");
                                    break;







                    }
                }
            }
        }
    }
}
