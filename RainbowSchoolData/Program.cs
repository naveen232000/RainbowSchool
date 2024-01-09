using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RainbowSchoolData
{
    public class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
    }

    public class Teacher : Student
    {
        public string Subject { get; set; }
    }

    public class Subject
    {
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public Teacher Teacher { get; set; }
    }

    public class School
    {
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Subject> Subjects { get; set; }

        public void FillData()
        {
            Students = new List<Student>
            {
                new Student { Name = "John", Class = "10", Section = "A" },
                new Student { Name = "Jane", Class = "10", Section = "B" },
                new Student { Name = "Jack", Class = "11", Section = "A" },
                new Student { Name = "Jill", Class = "11", Section = "B" }
            };

            Teachers = new List<Teacher>
            {
                new Teacher { Name = "Mr. Smith", Class = "10", Section = "A", Subject = "Mathematics" },
                new Teacher { Name = "Ms. Johnson", Class = "10", Section = "B", Subject = "Science" },
                new Teacher { Name = "Mr. Brown", Class = "11", Section = "A", Subject = "English" },
                new Teacher { Name = "Ms. Davis", Class = "11", Section = "B", Subject = "Social Studies" }
            };

            Subjects = new List<Subject>
            {
                new Subject { Name = "Mathematics", SubjectCode = "MATH101", Teacher = Teachers[0] },
                new Subject { Name = "Science", SubjectCode = "SCI101", Teacher = Teachers[1] },
                new Subject { Name = "English", SubjectCode = "ENG101", Teacher = Teachers[2] },
                new Subject { Name = "Social", SubjectCode = "SS101", Teacher = Teachers[3] }
            };
            
        }
        public List<Student> AllStudent()
        {
            List<Student> studentsInClass = new List<Student>();

            foreach (Student student in Students)
            {
                studentsInClass.Add(student);
            }

            return studentsInClass;
        }
        public List<Subject> AllSubject()
        {
            List<Subject> subjectInClass = new List<Subject>();

            foreach (Subject Subject in Subjects)
            {
                subjectInClass.Add(Subject);
            }

            return subjectInClass;
        }

        public List<Student> StsInCls(string className)
        {
            List<Student> studentsInClass = new List<Student>();

            foreach (Student student in Students)
            {
                if (student.Class == className)
                {
                    studentsInClass.Add(student);
                }
            }

            return studentsInClass;
        }

        public List<Subject> SubByTeacher(string teacherName)
        {
            List<Subject> subjectsTaughtByTeacher = new List<Subject>();

            foreach (Subject subject in Subjects)
            {
                if (subject.Teacher.Name == teacherName)
                {
                    subjectsTaughtByTeacher.Add(subject);
                }
            }

            return subjectsTaughtByTeacher;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            School school = new School();
            school.FillData();
            while (true)
            {
                Console.WriteLine("\nEnter Your choice: \n1)Get All Details\n2) Get Student by Class\n3) Get Subject by Teacher\n4) Exit\n");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        {
                            Console.WriteLine("\nAll Student Details \n");
                            List<Student> Sic = school.AllStudent();
                            foreach (Student student in Sic)
                            {
                                Console.WriteLine("{0,-10} {1,-10} {2,-10}", student.Name, student.Class, student.Section);
                            }
                            Console.WriteLine("\nAll Subject Details \n");
                            List<Subject> Sbt = school.AllSubject();
                            foreach (Subject subject in Sbt)
                            {
                                Console.WriteLine("{0,-13} {1,-10} {2,-10}", subject.Name, subject.SubjectCode, subject.Teacher.Name);
                            }

                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\nEnter Class (10) :");
                            string cls=Console.ReadLine();
                            List<Student> Sic = school.StsInCls(cls);
                            foreach (Student student in Sic)
                            {
                                Console.WriteLine("{0,-10} {1,-10} {2,-10}", student.Name, student.Class, student.Section);
                            }

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\nEnter Teacher Name : ");
                            string t=Console.ReadLine();
                            List<Subject> Sbt = school.SubByTeacher(t);
                            foreach (Subject subject in Sbt)
                            {
                                Console.WriteLine("{0,-10} {1,-10} {2,-10}", subject.Name, subject.SubjectCode, subject.Teacher.Name);
                            }
                            break;
                        }
                    case 4:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter Correct Choice");
                            break;
                        }
                }
            }
        }
    }
}
