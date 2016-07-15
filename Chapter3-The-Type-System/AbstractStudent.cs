using System;

namespace MCSD_Certification_Toolkit__exam_70_483_
{
    public abstract class AbstractStudent
    {
        public abstract void outputDetails();
    }

    public class CollegeStudent : AbstractStudent
    {
        public string firstName;
        public string lastName;
        public string major;
        public double GPA;

        public override void outputDetails()
        {
            Console.WriteLine("Student " + firstName + " " + lastName +
               " enrolled in " + major + " is has a GPA of " + GPA);
        }
    }
}
