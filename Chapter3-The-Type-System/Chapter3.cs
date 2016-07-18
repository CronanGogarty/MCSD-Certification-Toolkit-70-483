using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSD_Certification_Toolkit__exam_70_483_
{
    class Chapter3
    {
        bool validInput, closeBook;
        string inputStr;
        enum Months: byte
        {
            Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sept,
            Oct, Nov, Dec
        };
        public void chapter3TheTypeSystem()
        {
            Console.Clear();
            usingValueTypes();
            Program.dividingLine();
            string name = Enum.GetName(typeof(Months), 8);
            Console.WriteLine("The 8th month in the enum is " + name);

            Console.WriteLine("The underlying values of the Months enum:");
            foreach (byte values in Enum.GetValues(typeof(Months)))
            {
                Console.WriteLine(values);
            }
            Program.dividingLine();
            createBookStruct();
            Program.dividingLine();
            makeStudents();
            Program.dividingLine();
            int num1 = 12;
            int num2 = 43;
            Console.WriteLine("Prior to changeNumbers -> num1 = {0}; num2 = {1}", num1, num2);
            changeNumbers(num1, num2);
            Console.WriteLine("After changeNumbers and sum -> num1 = {0}; num2 = {1}", num1, num2);
            Program.dividingLine();
            CollegeStudent colStudent = new CollegeStudent();
            colStudent.firstName = "Colin";
            colStudent.lastName = "Stewart";
            colStudent.major = "Computer Science";
            colStudent.GPA = 4.0;
            colStudent.outputDetails();
            Program.dividingLine();
            int result = MyExtendedMethods.square(45);
            int result1 = 8;
            result1 = result1.square(); // here I am calling the extension method that I have extended to the int type.
            Console.WriteLine("MyExtendedMethods.square(45) = {0}", result);
            Console.WriteLine("int result1 = 8; result1.square() = {0}", result1);
            Program.dividingLine();
            PropertyStudent myStudent = new PropertyStudent("Tom", "Thumb");    //call the constructor
            myStudent.MiddleInitial = 'R';  //access private member variables using the public properties
            myStudent.Age = 15;
            myStudent.GPA = 3.5;
            myStudent.displayDetails();
            Program.dividingLine();
            Console.WriteLine("C# generic method.....");
            Generics.runGenericExample();
            Program.dividingLine();
            Program.returnToIndex();
        }

        private void changeStudent(Student inStudent)
        {
            //because student is a reference type changes made in this method will change the student at Program level
            inStudent.lastName = "Self";
        }

        //pass value types to method cause a copy of the values to be passed, 
        //the ints 'num1' and 'num2' declared in class Chapter3 will not be altered by the methods
        private void changeNumbers(int first, int second)
        {
            int num1 = first + 21;
            int num2 = second - 12;

            Console.WriteLine("Inside changeNumbers -> num1 = {0}; num2 = {1}", num1, num2);

            Console.WriteLine("Sum({0}, {1}) = {2}", first, second, sum(first, second));
        }
        private int sum(int first, int second)
        {
            return first + second;
        }

        private void makeStudents()
        {
            Student firstStudent = new Student();
            Student.StudentCount++;
            Student secondStudent = new Student();
            Student.StudentCount++;
            Student thirdStudent = new Student("Peter", "String", "80%");
            Student.StudentCount++;

            firstStudent.firstName = "John";
            firstStudent.lastName = "Smith";
            firstStudent.grade = "six";

            secondStudent.firstName = "Tom";
            secondStudent.lastName = "Thumb";
            secondStudent.grade = "two";

            Console.WriteLine("firstStudent.firstName = " + firstStudent.firstName);
            Console.WriteLine("secondStudent.firstName = " + secondStudent.firstName);
            Console.WriteLine("thirdStudent.firstName = " + thirdStudent.firstName);
            Console.WriteLine("Student.StudentCount = " + Student.StudentCount);

            Program.dividingLine();

            firstStudent.displayName();
            Console.WriteLine(secondStudent.concatenateName());

            //pass reference type - method will affect the instance passed to it
            changeStudent(firstStudent);
            Console.WriteLine("Now firstStudent fullname = " + firstStudent.concatenateName());

        }

        private void createBookStruct()
        {
            Console.WriteLine("Create a new struct for a book");
            Book myBook = new Book("MCSD Certification Toolkit (Exam 70-483)", "Certification", "Covaci, Tiberiu", 648, 10, 81118612095, "Soft Cover");

            myBook.Title = "MCSD Certification Toolkit - Exam 70-483";  //set the title using the public property
            Console.WriteLine(myBook.Title);
            Console.WriteLine(myBook.category);
            Console.WriteLine(myBook.author);
            Console.WriteLine(myBook.numPages);
            Console.WriteLine(myBook.currentPage);
            Console.WriteLine(myBook.ISBN);
            Console.WriteLine(myBook.coverStyle);

            changePage(myBook);

        }

        
        private void changePage(Book thisBook)
        {
            do
            {
                try
                {
                    Console.WriteLine("N - Next page");
                    Console.WriteLine("P - Previous page");
                    Console.WriteLine("X - Exit book");
                    inputStr = Console.ReadLine().ToUpper();
                    switch (inputStr)
                    {
                        case "N":
                            thisBook.nextPage();
                            validInput = true;
                            break;
                        case "P":
                            thisBook.prevPage();
                            validInput = true;
                            break;
                        case "X":
                            validInput=true;
                            closeBook = true;
                            break;
                        default:
                            Console.WriteLine("Not a valid input");
                            validInput = false;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    changePage(thisBook);
                }
            } while (!validInput || !closeBook);
        }

        private void usingValueTypes()
        {
            Console.WriteLine("Create a vriety of value-types and display some properties of each value-type variable");

            // declare some numeric data types
            int myInt;
            double myDouble;
            byte myByte;
            char myChar;
            decimal myDecimal;
            float myFloat;
            long myLong;
            short myShort;
            bool myBool;

            // assign values to these types and then
            // print them out to the console window
            // also use the sizeOf operator to determine
            // the number of bytes taken up be each type

            myInt = 5000;
            Console.WriteLine("Integer");
            Console.WriteLine(myInt);
            Console.WriteLine(myInt.GetType());
            Console.WriteLine(sizeof(int));
            Console.WriteLine();

            myDouble = 5000.0;
            Console.WriteLine("Double");
            Console.WriteLine(myDouble);
            Console.WriteLine(myDouble.GetType());
            Console.WriteLine(sizeof(double));
            Console.WriteLine();

            myByte = 254;
            Console.WriteLine("Byte");
            Console.WriteLine(myByte);
            Console.WriteLine(myByte.GetType());
            Console.WriteLine(sizeof(byte));
            Console.WriteLine();

            myChar = 'r';
            Console.WriteLine("Char");
            Console.WriteLine(myChar);
            Console.WriteLine(myChar.GetType());
            Console.WriteLine(sizeof(byte));
            Console.WriteLine();

            myDecimal = 20987.89756M;
            Console.WriteLine("Decimal");
            Console.WriteLine(myDecimal);
            Console.WriteLine(myDecimal.GetType());
            Console.WriteLine(sizeof(byte));
            Console.WriteLine();

            myFloat = 254.09F;
            Console.WriteLine("Float");
            Console.WriteLine(myFloat);
            Console.WriteLine(myFloat.GetType());
            Console.WriteLine(sizeof(byte));
            Console.WriteLine();

            myLong = 2544567538754;
            Console.WriteLine("Long");
            Console.WriteLine(myLong);
            Console.WriteLine(myLong.GetType());
            Console.WriteLine(sizeof(byte));
            Console.WriteLine();

            myShort = 3276;
            Console.WriteLine("Short");
            Console.WriteLine(myShort);
            Console.WriteLine(myShort.GetType());
            Console.WriteLine(sizeof(byte));
            Console.WriteLine();

            myBool = true;
            Console.WriteLine("Boolean");
            Console.WriteLine(myBool);
            Console.WriteLine(myBool.GetType());
            Console.WriteLine(sizeof(byte));
            Console.WriteLine();
        }

        //Data structures, or simply structs, are value types that you can use for storing related sets of variables. 
        //Structs share some similarities with classes, but they also have certain restrictions.

        /*The following points about constructors in structs are worth noting:
        - Constructors are optional, but if included they must contain parameters. No default constructors are allowed.
        - Fields cannot be initialized in a struct body.
        - Fields can be initialized only by using the constructor or after the struct is declared.
        - Private members can be initialized using only the constructor.
        - Creating a new struct type without the new operator will not result in a call to a constructor if one is present.
        - If your struct contains a reference type (class) as one of its members, 
         you must call the reference type’s constructor explicitly.
         */
        public struct Book
        {
            private string title;
            public string category;
            public string author;
            public int numPages;
            public int currentPage;
            public double ISBN;
            public string coverStyle;

            public string Title { 
                get { return title; }
                set { title = value; }
            }  

            public Book(string title, string category, string author, int numPages, int
               currentPage, double isbn, string cover)
            {
                this.title = title;
                this.category = category;
                this.author = author;
                this.numPages = numPages;
                this.currentPage = currentPage;
                this.ISBN = isbn;
                this.coverStyle = cover;
            }



            public void nextPage()
            {
                if (currentPage != numPages)
                {
                    currentPage++;
                    Console.WriteLine("Current page is now: " + this.currentPage);
                }
                else
                {
                    Console.WriteLine("At the end of the book.");
                }
            }

            public void prevPage()
            {
                if (currentPage != 1)
                {
                    
                    currentPage--;
                    Console.WriteLine("Current page is now: " + this.currentPage);
                }
                else
                {
                    Console.WriteLine("At the beginning of the book.");
                }
            }
        }
    }
}
