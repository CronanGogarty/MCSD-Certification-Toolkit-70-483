using System;
using MCSD_Certification_Toolkit__exam_70_483_.Chapter4_Using_Types;

namespace MCSD_Certification_Toolkit__exam_70_483_
{
    class Program
    {
        static sbyte selectedChapter = -1;
        static string indexStr = "a";
        

        public static void Main(string[] args)
        {
            initializeScreen();
        }

        private static void initializeScreen()
        {
            //setup the index screen where the user selects which chapter to jump to
            Console.WriteLine("Welcome to MSCD Certification Toolkit (exam 70-483");
            Console.WriteLine("Choose a chapter to run. Enter the chapter number and press enter.");
            dividingLine();
            selectChapter();
        }

        public static void dividingLine()    {
            Console.WriteLine("----------------------------");
        }

        private static void selectChapter()
        {
            //get the user input - an int value corresponding to the chapter number to jump to
            do
            {
                try
                {
                    Console.WriteLine("0 - Exit application");
                    Console.WriteLine("2 - Chapter 2: Basic Program Structure");
                    Console.WriteLine("3 - Chapter 3: Working With The Type System");
                    Console.WriteLine("4 - Chapter 4: Using Types");
                    selectedChapter = sbyte.Parse(Console.ReadLine());

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (selectedChapter == -1);

            switch (selectedChapter)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 2:
                    Chapter2 chapter2 = new Chapter2();
                    chapter2.chapter2();
                    break;
                case 3:
                    Chapter3 chapter3 = new Chapter3();
                    chapter3.chapter3TheTypeSystem();
                    break;
                case 4:
                    Chapter4 chapter4 = new Chapter4();
                    chapter4.chapter4UsingTypes();
                    break;
                default:
                    Console.WriteLine("Unknown entry");
                    selectChapter();
                    break;

            }
        }

        public static void returnToIndex()
        {
            selectedChapter = 0;
            do
            {
                try
                {
                    Console.WriteLine("Type 'y' to return to index");
                    indexStr = Console.ReadLine().ToUpper();
                    switch (indexStr)
                    {
                        case "Y":
                            Console.Clear();
                            initializeScreen();
                            break;
                        default:
                            Console.WriteLine("Please enter a valid selection.");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    initializeScreen();
                }
            } while (selectedChapter == 0);
        }
    }
}
