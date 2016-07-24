using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter5_Class_Hierarchies
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Constructor with first name.
        public Person(string firstName)
        {
            if ((firstName == null) || (firstName.Length < 1))
                throw new ArgumentOutOfRangeException(
                    "firstName", firstName,
                    "FirstName must not be null or blank.");
            FirstName = firstName;
            LastName = "NoName";
        }

        public Person(string firstName, string lastName)
            : this(firstName)
        {
            // Validate the first and last names.

            if ((lastName == null) || (lastName.Length < 1))
            {
                throw new ArgumentOutOfRangeException(
                    "lastName", lastName,
                    "LastName must not be null or blank.");
            }
            // Save the first and last names.
            LastName = lastName;
        }
    }
}
