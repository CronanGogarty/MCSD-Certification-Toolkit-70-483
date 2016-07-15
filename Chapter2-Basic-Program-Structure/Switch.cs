using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSD_Certification_Toolkit__exam_70_483_
{
    class Switch
    {
        public void switcher(string condition)
        {
            switch (condition)
            {
                case "Good Morning":
                    Console.WriteLine("Good morning to you");
                    break;

                case "Hello":
                    Console.WriteLine("Hello");
                    break;

                case "Good Evening":
                    Console.WriteLine("Wonderful evening");
                    break;

                default:
                    Console.WriteLine("So long");
                    break;
            }
        }

        public void switchNums(int number)
        {
            switch (number)
            {
                case 0:
                case 1:
                case 2:
                    Console.WriteLine(number + " is contained in the set of whole numbers.");
                    break;
                case -1:
                case -10:
                    Console.WriteLine(number + " is contained in the set of Integers.");
                    break;
            }
        }
    }
}
