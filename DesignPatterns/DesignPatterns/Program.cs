using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var facade = new SchoolFacade();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Teacher");
                Console.WriteLine("3. Add Subject");
                Console.WriteLine("4. Get Students in Class");
                Console.WriteLine("5. Get Subjects Taught by Teacher");
                Console.WriteLine("6. Exit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddStudent(facade);
                        break;
                    case 2:
                        AddTeacher(facade);
                        break;
                    case 3:
                        AddSubject(facade);
                        break;
                    case 4:
                        GetStudentsInClass(facade);
                        break;
                    case 5:
                        GetSubjectsTaughtByTeacher(facade);
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddStudent(SchoolFacade facade)
        {
            Console.WriteLine("Enter Student Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Class:");
            var className = Console.ReadLine();
            Console.WriteLine("Enter Section:");
            var section = Console.ReadLine();

            var student = SchoolObjectFactory.CreateStudent(name, className, section);
            facade.AddStudent(student);
            Console.WriteLine("Student added successfully!");
        }

        static void AddTeacher(SchoolFacade facade)
        {
            Console.WriteLine("Enter Teacher Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Class:");
            var className = Console.ReadLine();
            Console.WriteLine("Enter Section:");
            var section = Console.ReadLine();

            var teacher = SchoolObjectFactory.CreateTeacher(name, className, section);
            facade.AddTeacher(teacher);
            Console.WriteLine("Teacher added successfully!");
        }

        static void AddSubject(SchoolFacade facade)
        {
            Console.WriteLine("Enter Subject Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Subject Code:");
            var subjectCode = Console.ReadLine();
            Console.WriteLine("Enter Teacher Name:");
            var teacherName = Console.ReadLine();

            var teacher = facade.GetTeacherByName(teacherName);
            if (teacher == null)
            {
                Console.WriteLine($"Teacher with name '{teacherName}' not found. Subject could not be added.");
                return;
            }

            var subject = SchoolObjectFactory.CreateSubject(name, subjectCode, teacher);
            facade.AddSubject(subject);
            Console.WriteLine("Subject added successfully!");
        }

        static void GetStudentsInClass(SchoolFacade facade)
        {
            Console.WriteLine("Enter Class:");
            var className = Console.ReadLine();

            var studentsInClass = facade.GetStudentsInClass(className);
            if (studentsInClass.Count == 0)
            {
                Console.WriteLine($"No students found in class '{className}'.");
                return;
            }

            Console.WriteLine($"Students in class '{className}':");
            foreach (var student in studentsInClass)
            {
                Console.WriteLine($"Student: {student.Name}, Class: {student.Class}, Section: {student.Section}");
            }
        }

        static void GetSubjectsTaughtByTeacher(SchoolFacade facade)
        {
            Console.WriteLine("Enter Teacher Name:");
            var teacherName = Console.ReadLine();

            var subjectsTaughtByTeacher = facade.GetSubjectsTaughtByTeacher(teacherName);
            if (subjectsTaughtByTeacher.Count == 0)
            {
                Console.WriteLine($"No subjects found taught by '{teacherName}'.");
                return;
            }

            Console.WriteLine($"Subjects taught by '{teacherName}':");
            foreach (var subject in subjectsTaughtByTeacher)
            {
                Console.WriteLine($"Subject: {subject.Name}, Subject Code: {subject.SubjectCode}, Teacher: {subject.Teacher.Name}");
            }
        }
    }
}
