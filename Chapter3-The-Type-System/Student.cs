using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSD_Certification_Toolkit__exam_70_483_
{
    class Student
    {
        public static int StudentCount;
        public string firstName;
        public string lastName;
        public string grade;

        public string concatenateName()
        {
            string fullName = this.firstName + " " + this.lastName;
            return fullName;
        }

        public void displayName()
        {
            string name = concatenateName();
            Console.WriteLine(name);
        }


        public Student(string first, string last, string grade)
        {
            this.firstName = first;
            this.lastName = last;
            this.grade = grade;
        }

        public Student()
        {
            //because a non-default constructor has been created, we now have to specify the empty 'default' constructor
        }
    }
}
