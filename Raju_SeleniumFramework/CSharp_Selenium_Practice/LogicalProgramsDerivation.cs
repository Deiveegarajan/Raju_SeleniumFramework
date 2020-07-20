using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium_Practice
{
    public class LogicalProgramsDerivation
    {

        #region - Patterns

        public void Pattern1()
        {
            for(int i=0; i < 5; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(i);
                }
                Console.WriteLine();
            }
            /* --Output--
            #
            ##
            ###
            ####
            #####   

            0
            11
            222
            3333
            44444
            */
        }

        public void Pattern2()
        {
            //int i, j, k;
            //for (i = 5; i >= 1; i--)
            //{
            //    for (j = i; j > 1; j--)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (k = 5; k >= i ; k--)
            //    {
            //        Console.Write(i);
            //    }
            //    Console.WriteLine();
            //}

            int i, j, k;
            for (i = 5; i >= 1; i--)
            {
                for (j = 1; j < i; j++)
                {
                    Console.Write(" ");
                }
                for (k = 5; k >= i; k--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        #endregion - Patterns
        public void ArrayReverse()
        {
            dynamic d = 20;

            int[] array = { 1, 2, 3, 4, 5 };
            //Get array size
            int length = array.Length;
            //Declare and Create the reversed Array
            int[] reversed = new int[length];
            //Initialize the reversed array
            for (int index = 0; index < length; index++)
            {
                var result = reversed[length - index - 1] = array[index];
            }

            //Print the reversed array
            for (int index = 0; index < length; index++)
            {
                Console.WriteLine(reversed[index] + " "); //Output : 54321
            }
        }

        public void ArrayElementsOfTypeInteger()
        {
            int[] array;
            array = new int[10];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 4;
            array[4] = 5;
            array[5] = 6;
            array[6] = 7;
            array[7] = 8;
            array[8] = 9;
            array[9] = 10;

            int temp = 0;
            for (int index = 0; index < array.Length; index++)
            {
                temp = temp + array[index];
                var result = temp;
                // Console.WriteLine(result + "\n");
            }

            int[] ar = new int[] { 1, 2, 3, 4, 10, 11 };
            //  ar[0] = 1;
            //   ar[1] = 2;
            //   ar[2] = 3;
            //   ar[3] = 4;
            //   ar[4] = 10;
            //   ar[5] = 11;

            int temps = 0; int rslt = 0;
            for (int index = 0; index < ar.Length; index++)
            {
                temps = temps + ar[index];
                rslt = temp;

            }
            Console.Write(rslt);
        }

        //Program which reads two arrays from the console and checks whether they are equal
        public void ReadTwoArrayFromConsoleAndCheckTwoArrayAreEqual()
        {
            int firstArray = int.Parse(Console.ReadLine());
        }

        public List<int> ReturnListofIntegers(List<int> a, List<int> b)
        {
            return a;
            return b;
        }

        public void DifferenceBetweenSumsOfTwoDiagonals()
        {
            // Input: mat[][] = 11 2 4
            // 4 5 6
            // 10 8 - 12
            //  Output : 15
            //  Sum of primary diagonal = 11 + 5 + (-12) = 4.
            //  Sum of primary diagonal = 4 + 5 + 10 = 19.
            //   Difference = |19 - 4| = 15.

            int[][] diagonalMatrix = new int[3][]
                {
                  new int[] { 11, 2, 4 },
                  new int[] { 4, 5, 6 },
                  new int[] { 10, 8, -12 },
                };

            int output = 0;

            output = NewMethod(diagonalMatrix, output);
        }

        private static int NewMethod(int[][] diagonalMatrix, int output)
        {
            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            int result = 0;

            for (int i = 0; i < diagonalMatrix.Length; i++)
            {
                for (int j = 0; j < diagonalMatrix.Length; j++)
                {
                    if (i == j)
                    {
                        result = diagonalMatrix[i][j];
                        primaryDiagonal += result;
                    }
                    if (i + j == 2)
                    {
                        result = diagonalMatrix[i][j];
                        secondaryDiagonal += result;
                    }
                }
            }
            var negInt =  primaryDiagonal - secondaryDiagonal;
            output = Math.Abs(negInt);
            Console.WriteLine(output);
            return output;
        }

        //Sort the List of string values and print first 3 values in decending order
        public void ListOfstring()
        {
            List<string> listString = new List<string> { "Germany", "Japan", "China", "India" };

            listString.Sort();
            listString.Reverse();
            foreach (var v in listString)
            {
                var v1 = listString.GetRange(0, 3);

                Console.WriteLine(v1);
            }
        }
        //Verify if the dates in the list have passed in the current year
        public void VerifyTheDatesInListPassedInCurrentYear()
        {
            var years = new List<string> { "01.02.1980", "04.05.1985", "06.08.1988", "24.09.1999", "18.11.1986", "11.10.1983" };

            foreach (var item in years)
            {

                var dateConversion = DateTime.Parse(item);
                //TmpDate.Month = Datetime.Now.Month

                var v = dateConversion.Month == DateTime.Now.Month;

                if (dateConversion.Month == DateTime.Now.Month)
                {
                    Console.WriteLine(item);
                }
                else
                {
                    var day = dateConversion.Day;
                    var month = dateConversion.Month;
                    var year = DateTime.Now.Year;
                    var timeDifference = DateTime.Now.Subtract(new DateTime(year, month, day));

                    if (timeDifference.Days > 0)
                    {
                        // Console.WriteLine(String.Format("{0} days passed from current day to {1}", timeDifference.Days.ToString, dateConversion.Day.ToString + "." + dateConversion.Month.ToString + "." + DateTime.Now.Year.ToString));
                    }
                    else
                    {
                        // Console.WriteLine(String.Format("{0} days until the date {1}", Math.Abs(timeDifference.Days).ToString, day.ToString + "." + month.ToString + "." + year.ToString));
                    }
                }
            }

        }

        public void Practice_Dictionary_Calc_PrintNoOfVictoriesOfEachTourFrance()
        {
            var victories = new Dictionary<int, string>()
            { { 2006, "Oscar Pereiro" }, { 2007, "Alberto Contador" }, { 2008, "Carlos Sastre" }, { 2009, "Alberto Contador" },
                { 2010, "Andy Schleck" }, { 2011, "Cadel Evans" }, { 2012, "Bradley Wiggins" }, { 2013, "Chris Froome" },
                { 2014, "Vincenzo Nibali" }, { 2015, "Chris Froome" }, { 2016, "Chris Froome" }, { 2017, "Chris Froome" },
                { 2018, "Geraint Thomas"}};

            var winnerCounts = new Dictionary<string, int>();

            foreach (var winnerName in victories.Values)
            {
                var c = winnerName;
                if (winnerCounts.ContainsKey(winnerName))
                {
                    var cc = winnerCounts.Values;
                    // var s= cc + 1;

                }
                else
                {
                    //  winnerCounts.Add(winnerName,winnerCounts);
                }

            }

            foreach (var winner in winnerCounts)
            {
                if (winner.Value > 1)
                {
                    Console.WriteLine("{0} with {1} victories", winner.Key, winner.Value);
                }
                else
                {
                    Console.WriteLine("{0} with 1 victory", winner.Key);
                }
            }

        }

        public void CalculateTheCombinedWeightOfPackagesSentToOneCity()
        {

          //  Dictionary<string, double> combinedWeight = new Dictionary<string, Dictionary<string, double>>
         //   {
                //{
                //    "Raju",  new Dictionary<string, double>()
                //    {
                //        { "Madrid",2.1},
                //        { "Paris",1.1}
                //    },
                //    { "Lio", new Dictionary<string, double>()
                //    {
                //        { "New York",2.1},
                //        { "Paris",3.3},
                //        { "Berlin", 0.8}
                //    },
                //},
         //   };
        }

        /*
         -Minimum length: 8 characters
         -Starts with uppercase letter
         -Maximum 20 characters
          The user is allowed 3 attempts to write the correct string (not taking into accounts the situations when the user typed nothing).
         */
        public void ValidateUserInputString(string inputString)
        {
            var letterCount = inputString.Count();

            char[] charSeperated = inputString.ToCharArray();

            bool isFirstLetterCaseUpper = char.IsUpper(charSeperated[0]);

            try
            {
                bool b = isFirstLetterCaseUpper == true && letterCount >= 8 && letterCount <= 20;

                if (isFirstLetterCaseUpper == true && letterCount >= 8 && letterCount <= 20)
                {
                    Console.WriteLine(inputString);
                }
                else
                {
                    throw new Exception("Condition is false");
                }
            }
            catch (Exception)
            {
                if (isFirstLetterCaseUpper == false)
                {
                    throw new Exception("Fist letter should be UpperCase");
                }
                else if (letterCount <= 8)
                {
                    throw new Exception("Total letter should be minimum of 8 Characters");
                }
                else if (letterCount >= 20)
                {
                    throw new Exception("Total letter should be maximum of 20 Characters");
                }
            }
        }

        public void PrintOneValueFromLine(int n)
        {
            
            for (int i = 0; i <= n; i++)
            {
                int a = i % 3;
                int b = i % 5;
                int c = i / 3;
                int d = i / 5;
                if (i % 3 == 0 && i % 5 != 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0 && i % 5 != 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 3 != 0 && i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (i % 3 != 0 && i % 5 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        /*
        find the minimum and maximum values that can be calculated by summing exactly four of the five integers. Then print the respective minimum and maximum values as a single line of two space-separated long integers.
        For example, . Our minimum sum is  and our maximum sum is . We would print 16 24     
        */
        public void FindMaxAndMinValues()
        {

        }
    }
}


