using System;
using System.Collections.Generic;

namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter5_Class_Hierarchies
{
    public class Student : Person, IStudent
    {
        private List<string> myCourses = new List<string>();

        public List<string> Courses
        {
            get
            {
                return myCourses;
            }
            set
            {
                myCourses = value;
            }
        }

        public void PrintGrades()
        {
            foreach (string course in myCourses)
            {
                Console.WriteLine("Course = " + course);
            }
        }

        public Student(string firstName, string lastName)
            :base(firstName, lastName)  { }
    }
}
