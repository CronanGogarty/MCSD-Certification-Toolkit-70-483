using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter5_Class_Hierarchies
{
    public class Employee : Person
    {
        public string DepartmentName { get; set; }
        /*
         * 
         * Although a child class inherits most of the code in its parent class, 
         * it doesn’t inherit the parent class’s constructor.
         * 
         * The solution is to give the child class constructors that call the parent class’s constructors.
         * 
         *Note: When a constructor uses the base keyword to invoke a base class constructor, 
         *the base class’s constructor executes before the body of the child class’s constructor executes.
         *
         */
        public Employee(string firstName)
            : base(firstName) {
                DepartmentName = "Unknown";
        }

        public Employee(string firstName, string lastName)
            : base(firstName, lastName) {
                DepartmentName = "Unknown";
        }

        public Employee(string firstName, string lastName, string departmentName)
            : this(firstName, lastName) //can call a same-class constructor, 
                                        //because that constructor calls a base-class constructor
        {
            if (departmentName == null || departmentName.Length < 1)
            {
                throw new ArgumentOutOfRangeException("departmentName", departmentName, "The DepartmentName cannot be null or an empty string");
            }
            DepartmentName = departmentName;
        }

        public override string ToString()
        {
            return "\tFirstName = " + this.FirstName + ";\n\tLastName = " + this.LastName + ";\n\tDepartmentName = " + this.DepartmentName;
        }
    }
}
