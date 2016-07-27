using System;
using System.Collections.Generic;

namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter5_Class_Hierarchies
{
    class TeachingAssistant : Person, IStudent
    {

        private Student MyStudent = new Student("Teaching", "Assistant");

        public List<string> Courses
        {
            get
            {
                return MyStudent.Courses;
            }
            set
            {
                MyStudent.Courses = value;
            }
        }

        public void PrintGrades()
        {
            MyStudent.PrintGrades();
        }

        public TeachingAssistant(string firstName, string lastName) : base(firstName, lastName) { }

    }
}
