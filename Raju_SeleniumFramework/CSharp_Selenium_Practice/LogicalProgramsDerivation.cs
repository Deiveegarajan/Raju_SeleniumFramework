using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium_Practice
{
  public   class LogicalProgramsDerivation
    {
        public void ArrayReverse()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            //Get array size
            int length = array.Length;
            //Declare and Create the reversed Array
            int[] reversed = new int[length];
            //Initialize the reversed array
            for (int index = 0; index < length; index++)
            {
               var result= reversed[length - index - 1] = array[index];
            }

            //Print the reversed array
            for (int index = 0; index < length; index++)
            {
                Console.WriteLine(reversed[index]+" "); //Output : 54321
            }
        }
    }
}
