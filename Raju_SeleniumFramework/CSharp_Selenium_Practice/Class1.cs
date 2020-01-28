using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium_Practice
{
    public class SeleniumTests
    {
        [Test]
        public void Test1()
        {

            int[] arr = new int[6] { 1, 2, 3, 4, 10, 11 };
            SimpleArraySum(arr);
        }
    

    #region "PRIVATE METHODS"
    public void SimpleArraySum(int[] arr)
        {
            int store = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var v = arr[i];
                int stores = v + v;

                Console.WriteLine(store);
            
            }
     
        }

        #endregion 
    }
}
