using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSD_Certification_Toolkit__exam_70_483_
{
    class Chapter2
    {

        public void chapter2()
        {
            Console.WriteLine("App running...");

            //binary or |

            bool result = binaryOr(true, true);
            Console.WriteLine("true | true\t= " + result);

            result = binaryOr(true, false);
            Console.WriteLine("true | false\t= " + result);

            result = binaryOr(false, true);
            Console.WriteLine("false | true\t= " + result);

            result = binaryOr(false, false);
            Console.WriteLine("false | false\t= " + result);

            Console.WriteLine("----------------------------");

            result = conditionalOr(true, true);
            Console.WriteLine("true || true\t= " + result);

            result = conditionalOr(true, false);
            Console.WriteLine("true || false\t= " + result);

            result = conditionalOr(false, true);
            Console.WriteLine("false || true\t= " + result);

            result = conditionalOr(false, false);
            Console.WriteLine("false || false\t= " + result);

            Program.dividingLine();

            result = bitwiseExclusiveOr(true, true);
            Console.WriteLine("true ^ true\t= " + result);

            result = bitwiseExclusiveOr(true, false);
            Console.WriteLine("true ^ false\t= " + result);

            result = bitwiseExclusiveOr(false, true);
            Console.WriteLine("false ^ true\t= " + result);

            result = bitwiseExclusiveOr(false, false);
            Console.WriteLine("false ^ false\t= " + result);

            Console.WriteLine("----------------------------");

            Switch switcher = new Switch();
            switcher.switcher("Good Morning");
            switcher.switcher("Hello");
            switcher.switcher("Good Evening");
            switcher.switcher("totally random string");

            Console.WriteLine("----------------------------");

            switcher.switchNums(2);
            switcher.switchNums(-10);

            Console.WriteLine("----------------------------");
            string strToReverse = "";
            do {
                Console.WriteLine("Enter a string to reverse...");
                strToReverse = Console.ReadLine();
            } while (strToReverse == "" || strToReverse == null);

            Console.WriteLine(reverseString(strToReverse));

            Program.returnToIndex();
        }

        private static bool binaryOr(bool one, bool two)
        {
            return (one | two);
        }

        private static bool conditionalOr(bool one, bool two)
        {
            return (one || two);
        }

        private static bool bitwiseExclusiveOr(bool one, bool two)
        {
            return (one ^ two);
        }

        private static string reverseString(string inString)
        {
            int len = inString.Length;
            char[] charArray = new char[len];
            int index = len - 1;

            foreach (char c in inString)
            {
                charArray[index] = c;
                index--;

            }
            string outString = new string(charArray);
            return outString;
        }
    }
}
