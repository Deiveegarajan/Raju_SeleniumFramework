using NUnit.Framework;
using System;
using System.IO;

namespace CSharp_Selenium_Practice
{
    public class Program : CoreBase
    {
        [Test]
        public void SampleProgram()
        {
            CoreBase cB = new CoreBase(2,3);
            var ouptut= cB.LoginSamplePage();
            Console.WriteLine(ouptut);
        }

        [Test]
        public void TestInterfaces()
        {
            var interfacesClass = new ImplementationInterfaceClass();
            interfacesClass.CoreInterfaceMethodA("Raju", "Lio");
            interfacesClass.SampleDerivedMethod(5, 5);
            interfacesClass.SampleMethod();

          //  interfacesClass.Parameter(par);

            ICoreInterfaceBase2 interBase2 = new ImplementationInterfaceClass();
            interBase2.CoreInterfaceMethodA(10);
            interBase2.CoreInterfaceMethodA("Raju", "Lio");
        }
        [Test]
        public void Pattern1()
        {
            int number = 10;
            int row, col, temp = 1;
            int[] arr = new int[6] { 1, 2, 3, 4, 10, 11 };
            
            for( row=1;row <=number; row++)
            {
                for (col=1; col<= row; col++)
                {
                    Console.Write(temp);
                    temp++;
                }
                Console.WriteLine();
            }
        }

        [Test]
        public void Patterns_Pyramid()
        {
            int number = 10;
            int i, j, k;

            for (i = 0; i < 5; i++)
            {
               
            }
        }
        [Test]
        public void ArraySum()
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int arCount = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp)) ;
           // int result = SimpleArraySum(ar);

          //  textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();


        }

        [Test]
        public void WordOpen()
        {
            string Folder = @"C:\\Users\\EI11484\\Downloads";
            var files = new DirectoryInfo(Folder).GetFiles("*.*");
            string latestfile = "";
            DateTime lastupdated = DateTime.MinValue;
            foreach (FileInfo file in files)
            {
                if (file.Name != "desktop.ini")
                    if (file.LastWriteTime > lastupdated)
                    {
                        lastupdated = file.LastWriteTime;
                        latestfile = file.Name;
                        Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                        object miss = System.Reflection.Missing.Value;
                        object path = @"C:\Users\EI11534\Downloads\Report.docx";

                        object readOnly = true;
                        Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                        string totaltext = "";
                        for (int i = 0; i < docs.Paragraphs.Count; i++)
                        {
                            totaltext += " \r\n " + docs.Paragraphs[i + 1].Range.Text.ToString();
                        }
                        Console.WriteLine(totaltext);
                        Console.ReadLine();
                        docs.Close();
                        word.Quit();
                    }
            }
            Console.Write("LatestFileName:" + latestfile);
            Console.ReadLine();
        }

        #region "PRIVATE METHODS"
        public void SimpleArraySum(int[] ar)
        {
            int store = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                var v = ar[i];
                int stores = v + v;

                Console.WriteLine(store);
            
            }

            /*
            * Write your code here.
            */
            // ar ={1,2,3,4,10,11};
            int a = 0;
            foreach (var output in ar)
            {
                a = a + output;
            }
            Console.WriteLine(a);
        }
        #endregion
    }
}

