using NUnit.Framework;
using System;
using System.IO;

namespace CSharp_Selenium_Practice
{
    public class Program : CoreBase
    {

        [Test]
        public void LogicalProgramming()
        {

            var basicProgram = new LogicalProgramsDerivation();
            basicProgram.ReverseString();
            basicProgram.PrintOneValueFromLine(15);
            //  basicProgram.ArrayReverse();
            //  basicProgram.ArrayElementsOfTypeInteger();
            //  basicProgram.DiagonalMatrix();
            //basicProgram.ValidateUserInputString("deiveegaraja");

            //var stacks = new StacksNonGeneric();
            //stacks.Stack();

            //var queue = new QueueNonGeneric();
            //queue.Queue();

            //var arrayList = new ArrayListNonGeneric();
            //arrayList.ArrayList();
        }

        [Test]
        public void Keywords()
        {

            var basicProgram = new Keywords();
            basicProgram.Object(10.0);//we can pass any type of values as parameter
        }

        [Test]
        public void StringProcessing()
        {
            var text = new StringAndTextProcessing();
            text.StringDeclaration();
            text._StringAndCharArrayAndReplace();
            text._SwitchingUpperAndLowerCaseLetters();
            text._SearchStringWithinAnotherString();
            text._StringConcatenationAndInterpolation();
            text.CompareStringInAlphabetical();
            text.StringTrim_RegularExpression_Interning();
            text.StringBuilder();
            text.StringFormatting_ParsingData();
        }

        [Test]
        public void SampleProgram()
        {
            CoreBase cB = new CoreBase(2,3);
            var ouptut= cB.LoginSamplePage();
            Console.WriteLine(ouptut);

            TwoOrMultiDimensionArray twoDimenstion = new TwoOrMultiDimensionArray();
            twoDimenstion.TwoDimenstional();
        }

        [Test]
        public void TestInterfacesAndAbstract()
        {
            //Interfaces
            var interfacesClass = new ImplementationInterfaceClass();
            interfacesClass.CoreInterfaceMethodA("Raju", "Lio");
            interfacesClass.SampleDerivedMethod(5, 5);
            interfacesClass.SampleMethod();

          // interfacesClass.Parameter(par);

            ICoreInterfaceBase2 interBase2 = new ImplementationInterfaceClass();
            interBase2.CoreInterfaceMethodA(10);
            interBase2.CoreInterfaceMethodA("Raju", "Lio");

            //Abstact
            var abstractClass = new ImplementationOfAbstractClass();
           // var abstractClasss = new ImplementationOfAbstractClass(4,5);
            abstractClass.AbstractMethod();
            abstractClass.MethodA();
            abstractClass.MethodB(15);
        }

        [Test]
        public void EventsAndDelegates()
        {
            DelegatesEx del = new DelegatesEx();
            del.InvokingDelegate();
        }

        [Test]
        public void StaticClass()
        {
            StaticBaseClass.CoreBase();
            StaticBaseClass.UserValue = 10;
        }

        [Test]
        public void Oops()
        {
            
            var b = new InheritanceBaseClass.InheritanceDerivedClass1();
            Console.WriteLine(b.GetValue());//10

            //Inheritance
            string whatPlayed = "";

            Drum drums = new Drum();
            PlayMusicService music1 = new PlayMusicService(new Drum());
            whatPlayed = music1.PlayAlbum();
            Console.WriteLine(whatPlayed);

            Piano piano = new Piano();
            PlayMusicService music2 = new PlayMusicService(new Piano());
            whatPlayed = music2.PlayAlbum();
            Console.WriteLine(whatPlayed);

            //Polymorphism
            var overloading = new StaticOrCompileTimeOrMethodOverloading();
            overloading.PolyMethodOverloading();
            overloading.PolyMethodOverloading(5, 3);
            overloading.PolyMethodOverloading(3, 0.3, true);
          
            var baseKeyword = new InheritanceUsingBaseKeywordDerivedClass(true,10);
            var baseKeyword1 = new InheritanceUsingBaseKeywordDerivedClass();
            baseKeyword.Weight = 70;
              
            var overRiding = new ImplementationOfRuntimeOrMethodOverRiding1();
            overRiding.OverRidingMethod();
            overRiding.PolyMethodOverridding();
            overRiding.SampleMethod();
            

            // Abstraction
            var abstraction = new AbsractionDerivedClass(20,10);
            double a = abstraction.area();
            Console.WriteLine("Area: {0}", a);

            // Encapsulaton
            var encapsulation = new EncapsulationBaseClasss();

            // set accessor will invoke
            encapsulation.Name = "Suresh Dasari";
            // set accessor will invoke
            encapsulation.Location = "Hyderabad";
            // get accessor will invoke
            Console.WriteLine("Name: " + encapsulation.Name);
            // get accessor will invoke
            Console.WriteLine("Location: " + encapsulation.Location);
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

