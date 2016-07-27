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

            Program.dividingLine();

            implementInterface();

            Program.dividingLine();

            implementsIComparable();

            Program.dividingLine();

            equatablePerson();

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
                
                
                if (input.Length > 1 && (input.Trim() != ""))
                {
                    char[] splitters = { ' ' };
                    string[] inputArr = input.Split(splitters);
                    try
                    {
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
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message + "\n");
                    }
                    
                }
                
            } while (newEmployee==null);

            Console.WriteLine("\nThe following employee was created based on your input\n" + newEmployee.ToString());

            
        }

        private void implementInterface()
        {
            Console.WriteLine("Implement interface...\n");
            Student stu = new Student("John", "Self");
            //within student class I have explicitely implemented the IStudent interface
            //that means that the object stu, of type Student can only access the members of that type and parent type
            Console.WriteLine("Student created\n" + stu.FirstName + " " + stu.LastName);

            /*
             * To access the members of the IStudent interface I must use an object of that type
             */
            IStudent iStu = stu;

            //populate the course list
            List<string> studentCourses = new List<string>();
            studentCourses.Add("Maths");
            studentCourses.Add("English");
            studentCourses.Add("Science");
            iStu.Courses = studentCourses;

            Console.WriteLine("\nStudent is taking the following subjects");
            iStu.PrintGrades();
        }

        private void implementsIComparable()
        {
            Console.WriteLine("Implement IComparable Interface...");
            Console.WriteLine("Create 2 objects of type 'car' then compare car1 to car2\nIt is possible to use Array.Sort to sort an array of Car objects because the 'Car' class implements the IComparable interface");
            Car car1 = new Car();
            car1.Name = "Volvo 850";
            car1.Price = 5000;
            car1.MaxMph = 85;
            car1.Horsepower = 1200;

            Car car2 = new Car();
            car2.Name = "Mazda Miata MX5";
            car2.Price = 12000;
            car2.MaxMph = 120;
            car2.Horsepower = 1100;

            Console.WriteLine("\nCar 1 = " + car1.Name + ", value = " + car1.Price + ", horsepower = " + car1.Horsepower + ", MaxMph = " + car1.MaxMph + "\nCar 2 = " + car2.Name + ", value = " + car2.Price + ", horsepower = " + car2.Horsepower + ", MaxMph = " + car2.MaxMph);


            Console.WriteLine("car1.compareTo(car2) returns the value " + car1.CompareTo(car2).ToString());
            Console.WriteLine("car2.CompareTo(car1) returns the value " + car2.CompareTo(car1).ToString());


            //because the Car type implements the IComparable interface, we can use Array.Sort to sort an array of car objects
            Car[] cars = new Car[2];
            cars[0] = car1;
            cars[1] = car2;

            Console.WriteLine("\nBefore sorting the array...");
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine("Cars[" + i + "] = " + cars[i].Name);
            }

            Array.Sort(cars);
            Console.WriteLine("\nAfter sorting the array...");
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine("Cars[" + i + "] = " + cars[i].Name);
            }

            Program.dividingLine();

            


            try
            {
                bool firstRun = true;
                string yesNo = "";
                do
                {
                    
                    if (!firstRun)
                    {
                        Console.WriteLine("\nSelect another property to compare by? y|n");
                        yesNo = Console.ReadLine().ToLower();
                    }

                    if (yesNo != "n")
                    {
                        compareByChoice(cars);
                    }
                    
                    firstRun = false;

                } while (yesNo != "n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }

        private void compareByChoice(Car[] cars)
        {
            try
            {
                int selection;
                Console.WriteLine("These are the properties you can compare by.");
                foreach (string property in Enum.GetNames(typeof(CarComparer.CompareField)))
                {
                    Console.WriteLine(property.ToString());
                }
                do
                {

                    Console.WriteLine("\nEnter the number of the property you wish to compare with (ascending)");
                    if (!Int32.TryParse(Console.ReadLine(), out selection))
                    {
                        selection = -1;
                    }
                } while (selection < 1 || selection > 4);

                CarComparer comparer = new CarComparer();
                comparer.SortBy = (CarComparer.CompareField)selection;
                Array.Sort(cars, comparer);

                Console.WriteLine("Cars array sorted by " + comparer.SortBy);
                for (int i = 0; i < cars.Length; i++)
                {
                    Console.WriteLine("Cars[" + i + "] = " + cars[i].Name);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void equatablePerson()
        {
            Program.dividingLine();
            Console.WriteLine("Implement IEquatable...");
            Console.WriteLine("\nFirst we create 2 objects of type 'Person'.\nThe Person class does not implement the IEquatable interface.");
            Console.WriteLine("\nEach Person object has the same firstname and lastname values.\nThen add these 2 objects to a List<Person> checking to see if List<Person> already contains an equal object.");
            Person person1 = new Person("John", "Self");
            Person person2 = new Person("John", "Self");

            List<Person> personList = new List<Person>();
            if (!personList.Contains(person1))
            {
                personList.Add(person1);
            }

            if (!personList.Contains(person2))
            {
                personList.Add(person2);
            }

            Console.WriteLine("Now output the contents of the List<Person> list");
            foreach (Person p in personList)
            {
                int index = 1;
                Console.WriteLine("Person " + index + " in List<Person> = " + p.FirstName + " " + p.LastName);
                index++;
            }

            Console.WriteLine("\n\nNow create 2 objects of type 'EquatablePerson'\nThe EquatablePerson class does implement the IEquatable interface.\nAgain each object is given the same property values.\nWhen we attemp to add them to a List<EquatablePerson> the .Contains method returns true and the 2nd object is not added to the list.");
            EquatablePerson eperson1 = new EquatablePerson();
            EquatablePerson eperson2 = new EquatablePerson();
            eperson1.FirstName = "John";
            eperson1.LastName = "Self";

            eperson2.FirstName = "John";
            eperson2.LastName = "Self";

            

            List<EquatablePerson> epersonList = new List<EquatablePerson>();
            if (!epersonList.Contains(eperson1))
            {
                epersonList.Add(eperson1);
            }
            if (!epersonList.Contains(eperson2))
            {
                epersonList.Add(eperson2);
            }

            Console.WriteLine("Now output the contents of the List<EquatablePerson> list");
            foreach (EquatablePerson ep in epersonList)
            {
                int index = 1;
                Console.WriteLine("Person " + index + " in List<Person> = " + ep.FirstName + " " + ep.LastName);
                index++;
            }
        }
    }
}
