using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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
            Console.WriteLine(isType(personObject));
            Employee employeeObject = new Employee();
            Console.WriteLine(isType(employeeObject));
            Manager managerObject = new Manager();
            Console.WriteLine(isType(managerObject));
            Program.dividingLine();
            Console.WriteLine("Us the 'as' keyword to cast ");

            Employee managerEmployee = managerObject as Employee;   //will eturn null if cast cannot be completed

            if (managerEmployee != null)
            {
                Console.WriteLine("Successfully completed cast using 'as';\nEmployee managerEmployee = managerObject as Employee");
            }


            Employee personEmployee = personObject as Employee; //this will return null because a person type cannot be cast to an Employee type
            if (personEmployee == null)
            {
                Console.WriteLine("Could not complete cast using 'as';\nEmployee personEmployee = personObject as Employee.\npersonEmployee = null");
            }
            Program.dividingLine();
            castArrays();

            Program.dividingLine();
            parseOperations();

            Program.dividingLine();
            stringOperations();

            Program.dividingLine();
            stringDotFormat();

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
            Console.WriteLine("Casting Arrays.\nNOTE:-When you cast an array to a new array type, the new array variable is actually a reference to the existing array not a completely new array.");

            //*NOTE
            //When you cast an array to a new array type, the new array variable is actually a reference to the existing array not a completely new array.
            //If you want to make a new array instead of just a new way to refer to an existing array, use Array.Copy or some other method to copy the array. 

            //create and populate the employees array
            Employee[] employees = new Employee[8];
            Console.WriteLine("The contents of the employees array");
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = new Employee();
                employees[i].EmployeeID = i;
                Console.WriteLine("employees[" + i + "].EmployeeID = " + i);
            }

            Console.WriteLine();

            //cast employees array to persons array
            //remember the Employee type inherits from Person type so this is a widening conversion
            //because it is a widening conversion, it can be implicit
            Person[] persons = employees;
            Console.WriteLine("The contents of the persons array\ninside the loop each element is cast to type Employee to access the properties of that type");
            for (int i = 0; i < persons.Length; i++)
            {
                //we have an array of Person[] but each record is really an Employee, with all the properties of that type
                //to access the properties of the Employee type, we need a narrowing cast
                //a narrowing cast must be exlicit and may cause an exception
                Employee currentEmployee = (Employee)persons[i];
                Console.WriteLine("Persons[" + i + "].employeeID = " + currentEmployee.EmployeeID);
            }

            Console.WriteLine();

            // Explicit cast back to an array of Employees.
            // (The Persons in the array happen to be Employees.)
            employees = (Employee[])persons;
            // Use the is operator.
            if (persons is Employee[])
                Console.WriteLine("employees = (Employee[])persons;\nWe can perform this explicit cast bacuase persons refers to an array of Employee types");
            {
                // Treat them as Employees.
                for (int i = 0; i < persons.Length; i++)
                {
                    Console.WriteLine("persons[" + i + "] = " + persons[i].ToString());
                }
            }

            Console.WriteLine();

            Console.WriteLine("use 'as' to cast the persons array to an Employee[] array");
            employees = persons as Employee[];  //use 'as' to cast the persons array to an Employee[] array

            Manager[] managers = persons as Manager[];  //After this as statement, managers is null.


            if (persons is Manager[])
            {

            }
            else
            {
                Console.WriteLine("persons array is not of type Manager[]");
            }

            managers = employees as Manager[]; //After this as statement, managers is null.


            if (managers is Person[])
            {
                for (int i = 0; i < persons.Length; i++)
                {
                    Console.WriteLine("managers[" + i + "] = " + managers[i].ToString());
                }
            }

        }

        private void parseOperations()
        {
            Console.WriteLine("Parse operations");
            int input;
            //bool tryParseSuccess;
            //string inputString;

            do
            {
                Console.WriteLine("Enter a positive integer value");

                //inputString = Console.ReadLine();
                //tryParseSuccess = int.TryParse(inputString, out input);
                //if (!tryParseSuccess || input <= 0)
                //the above lines can be refactored into;
                if (!int.TryParse(Console.ReadLine(), out input)) input = -1;
                if (input <= 0)
                {
                    Console.WriteLine("You did not enter a valid positive integer - please try again");
                }
                else
                {
                    Console.WriteLine("You entered a valid positive integer - " + input.ToString() + " thank you.");
                }
            } while (input <= 0);

            //all result in 3:45 PM April 1, 2014. (U.S. Locale)
            DateTime.Parse("3:45 PM April 1, 2014").ToString();
            DateTime.Parse("1 apr 2014 15:45").ToString();
            DateTime.Parse("15:45 4/1/14").ToString();
            DateTime.Parse("3:45pm 4.1.14").ToString();

            decimal amount;
            if (!true)
            {
                //this code will throw a FormatException if it is run
                //The reason this code fails is that, by default, the decimal.Parse method enables thousands and decimal separators but not currency symbols.
                amount = decimal.Parse("$123,456.78");
            }
            else
            {
                /*
                 * You can make decimal.Parse enable currency symbols by adding another parameter that is a combination of values defined by the System.Globalization.NumberStyles enumeration
                 * Alternatively, you can pass the method the composite style Currency, as shown in the following code:
                 */
                amount = decimal.Parse("$123,456.78", NumberStyles.Currency);
            }

            Console.WriteLine();

            Console.WriteLine("Using BitConverter.GetBytes\nint myInteger = 34251\nBitConverter.GetBytes(myInteger) returns an array of bytes with the following values;");
            int myInteger = 34251;
            byte[] myIntegerByteArray = BitConverter.GetBytes(myInteger);
            for (int i = 0; i < myIntegerByteArray.Length; i++)
            {
                Console.WriteLine(myIntegerByteArray[i]);
            }

        }

        private void stringOperations()
        {

            Console.WriteLine("String operations...");
            /*
             * One way to create a new string is to pass a character and the number of times you want to repeat it
             * into the new string() method - e.g. new string('c', 5) would return 'ccccc';
             */

            Console.WriteLine();
            Console.WriteLine("Using new string('char', int) to create a new string that repeats char int number of times.");
            for (int i = 1; i <= 10; i++)
            {
                string indent = new string(' ', 4 * i);
                Console.WriteLine(indent + i.ToString());
            }

            //use the String.empty field
            string emptyString = "";
            //emptyString = String.Empty;
            if (emptyString == string.Empty)
            {
                Console.WriteLine("You have an empty string");
            }

            //use the string.length property and the indexer
            string lengthString = "Hello this is a string of text - it will be referenced by the 'intern pool' which is a table maintained by the CLR that holds a reference to each unique text value used by the program";
            Console.WriteLine(lengthString);
            Console.WriteLine("The above string is " + lengthString.Length + " characters in length.\nWe can use the indexer to get individual characters, for example, the character stored at index 4 = " + lengthString[4] + ".");

            //use string.ToCharArray to create an array
            Console.WriteLine("\n\nWe can convert a string into an array of characters using string.ToCharArray(), manipulate the array, then create a new string by passing the array into a new string constructor");
            char[] characters = lengthString.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
                if (i % 2 == 0) characters[i] = char.ToUpper(characters[i]);
                else characters[i] = char.ToLower(characters[i]);
            string crazyCaseString = new string(characters);
            Console.WriteLine("\n" + crazyCaseString);

            //use the string's indexer as a source of iteration in a foreach loop
            int[] counts = new int[26];
            lengthString = lengthString.ToUpper();
            foreach (char ch in lengthString)
            {
                if (char.IsLetter(ch))
                {
                    //get an int value from 0-26 to represent the char
                    //Unicode values have in int value, we subtract the value of 'A' from the char value to get 0-26
                    int index = (int)ch - (int)'A';
                    counts[index]++;    //then increment the value of the index in the counts array
                                        //this counts the occurences of each letter in the string
                }
            }

            //create an array of the alphabet
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            foreach (int i in counts)
            {
                char currChar = (char)alpha[i];
                Console.WriteLine("The char " + currChar + " occurs " + counts[i] + " times in the above string");
            }

        }

        private void stringDotFormat()
        {
            Console.WriteLine("String.Format() operations...");
            int i = 163;
            Console.WriteLine("The int value 163 can be output in different ways using string.Format()\nFirst cast the value 163 to a char then output, then use '{1,4}' to display 4 characters wide, finally use '0x{2:X}' to output 163 in hexicedimal.");
            Console.WriteLine(string.Format("{0} = {1,4} or 0x{2:X}", (char)i, i, i));

            string text = string.Format("{1} {4} {2} {1} {3}\n{1} {3} {0} {1} {3}", "who", "I", "therefore", "am", "think");
            Console.WriteLine("\n" + text);

            Console.WriteLine(String.Format("{2}, {0}, {3}", "vidi", "Venti", "Veni", "vici"));
        }

    }
}
