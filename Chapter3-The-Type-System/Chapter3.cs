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
            Program.returnToIndex();
        }

        private void createBookStruct()
        {
            Console.WriteLine("Create a new struct for a book");
            Book myBook = new Book("MCSD Certification Toolkit (Exam 70-483)", "Certification", "Covaci, Tiberiu", 648, 10, 81118612095, "Soft Cover");

            Console.WriteLine(myBook.title);
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
                            Program.returnToIndex();
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
            private string _title;
            public string category;
            public string author;
            public int numPages;
            public int currentPage;
            public double ISBN;
            public string coverStyle;

            public string title { get { return _title; } }  

            public Book(string title, string category, string author, int numPages, int
               currentPage, double isbn, string cover)
            {
                this._title = title;
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
