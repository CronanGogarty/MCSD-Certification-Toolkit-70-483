using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace MCSD_Certification_Toolkit__exam_70_483_
{
    class Generics
    {
        public static void runGenericExample()
        {
            int[] arrInts = new int[] { 34, 5, 2, 78, 33, 23, 98, 43, 1 };
            char[] arrChars = new char[] { 'a', 'z', 'd', 'j', 'e', 'b' };

            Console.WriteLine("These are the unsorted arrays...");
            writeArray<int>(ref arrInts);
            writeArray<char>(ref arrChars);
            Console.WriteLine();

            Console.WriteLine("Sorting arrays.....");

            #region swapInts
            for (int i = 0; i < arrInts.Length; i++)
            {
                for (int j = i + 1; j < arrInts.Length; j++)
                {
                    if (arrInts[i] > arrInts[j])
                    {
                        swap<int>(ref arrInts[i], ref arrInts[j]);
                    }
                }
            }
            #endregion

            #region swapChars

            for (int i = 0; i < arrChars.Length; i++)
            {
                for (int j = i+1; j < arrChars.Length; j++)
                {
                    if (arrChars[i] > arrChars[j])
                    {
                        swap<char>(ref arrChars[i], ref arrChars[j]);
                    }
                }
            }
            #endregion

            Console.WriteLine("Arrays sorted.....");
            writeArray<int>(ref arrInts);
            writeArray<char>(ref arrChars);


        }

        public static void swap<T>(ref T firstValue, ref T secondValue)
        {
            T tempValue = firstValue;
            firstValue = secondValue;
            secondValue = tempValue;
            //because the values are passed by ref this method actually affects the original variables passed in
        }

        private static void writeArray<T>(ref T[] theArray)
        {
            string output = "{";
            for (int i = 0; i < theArray.Length; i++)
			{
                if (i<theArray.Length-1)
                {
                    output += theArray[i].ToString() + ", ";
                }
                else
                {
                    output += theArray[i].ToString();
                }
			    
			}
            output += "}";
            Console.WriteLine(output);

        }
    }
}
