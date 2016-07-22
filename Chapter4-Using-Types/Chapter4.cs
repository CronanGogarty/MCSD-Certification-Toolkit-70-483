using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter4_Using_Types
{
    class Chapter4
    {
        public void chapter4UsingTypes()
        {
            Console.Clear();
            Console.WriteLine("Chapter 4 - Using Types");
            Program.dividingLine();
            castReferenceValues();
            Program.dividingLine();

            //create some object and test check their type using the 'is' keyword
            Person personObject = new Person();
            Console.WriteLine( isType(personObject) );
            Employee employeeObject = new Employee();
            Console.WriteLine(isType(employeeObject));
            Manager managerObject = new Manager();
            Console.WriteLine(isType(managerObject));
            Program.dividingLine();
            Console.WriteLine("Us the 'as' keyword to cast ");

            Employee managerEmployee = managerObject as Employee;   //will eturn null if cast cannot be completed
            
                if (managerEmployee != null)
                {
                    Console.WriteLine("Successfully execute operation;\nEmployee managerEmployee = managerObject as Employee");
                }
            

            Employee personEmployee = personObject as Employee; //this will return null because a person type cannot be cast to an Employee type
            if (personEmployee == null)
            {
                Console.WriteLine("Could not execute operation;\nEmployee personEmployee = personObject as Employee");
            }
            Program.dividingLine();
            Program.returnToIndex();
        }

        private void castReferenceValues()
        {
            //employee is a subclass of Person
            Employee employee1 = new Employee();
            Person person1 = employee1; //this is a narrowing conversion and can be implicit
            Person person2 = new Employee();
            ///Converting a reference value to an ancestor class or interface does not actually change the value; 
            ///it just makes it act as if it were of the new type
            ///In the previous example, person1 is a Person variable, but it references an Employee object.

            Employee employee2 = (Employee)person1; // Allowed because person1 is actually an Employee.

            Person person3 = new Person();
            try
            {
                Employee employee3 = (Employee)person2; //valid cast - person2 is actually of type Employee
                Employee employee4 = (Employee)person3; //invalid cast - this is a narowing conversion and person3 is not of type Employee
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("You cannot cast Person type to an Employee type");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

            if (person3 is Person)
            {
                Console.WriteLine("The above InvalidCastException occurred because person3 is of type Person - you tried to cast it to the subclass Employee");
            }

        }

        private string isType<T>(T type)
        {
            string result = "";
            Console.WriteLine(type.ToString());

            //The is operator determines whether an object is compatible with a particular type
            if (type is Person) //Person, Employee and Manager all evaluate to true because Employee and Manager are subclasses of Person
            {
                result += "The type " + type.ToString() + " is of type Person";
                if (type is Employee)   //Employee and Manager evaluate to true because Manger is a subclass of Employee
                {
                    result += "\nThe type " + type.ToString() + " is also of type Employee";
                    if (type is Manager) //Only Manager evaluates to true because the other types are superclasses
                    {
                        result += "\nThe type " + type.ToString() + " is also of type Manager";
                    }
                }
            }

            else
            {
                result = "No match";
            }
            return result;
        }

        private void castArrays()
        {
            Console.WriteLine("Casting Arrays");

            //create and populate the employees array
            Employee[] employees = new Employee[8];
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = new Employee();
                employees[i].EmployeeID = i;
            }

            //cast emplayees array to persons array
            //remember the Employee type inherits from Person type so this is a widening conversion
            //because it is a widening conversion, it can be implicit
            Person[] persons = employees;



        }


    }
}
