using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter5_Class_Hierarchies
{
    class Chapter5
    {
        public void chapter5ClassHierarchies()
        {
            Console.Clear();
            Console.WriteLine("Chapter 5 - Class Hierarchies");
            //
            useParentConstructors();

            Console.WriteLine();
            Program.returnToIndex();

        }

        private void useParentConstructors()
        {
            Console.WriteLine("\n---------------------------------\nUsing parent constructors and calling same-class constructors...");
            Employee newEmployee = null;
            do
            {
                Console.WriteLine("\nCreate a new Employee object:\nenter firstname,\nor firstname & lastname,\nor firstname, lastname and departmentname");
                string input = Console.ReadLine();
                char[] splitters = { ' ' };
                string[] inputArr = input.Split(splitters);
                if (inputArr.Length == 1)
                {
                    newEmployee = new Employee(inputArr[0]);
                }
                else if (inputArr.Length == 2)
                {
                    newEmployee = new Employee(inputArr[0], inputArr[1]);
                }
                else if (inputArr.Length == 3)
                {
                    newEmployee = new Employee(inputArr[0], inputArr[1], inputArr[2]);
                }
                else
                    Console.WriteLine("Unknown input - unable to create an Employee object from your input.");
            } while (newEmployee==null);

            Console.WriteLine("\nThe following employee was created based on your input\n" + newEmployee.ToString());

            
        }
    }
}
