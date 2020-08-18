
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharp_Selenium_Practice
{
    #region General Information

    #region Default Access Modifiers
    /* 
     * top level class: internal
     * method: private
     * members (unless an interface or enum): private (including nested classes)
     * members (of interface or enum): public
     * constructor: private (note that if no constructor is explicitly defined, a public default constructor will be automatically defined)
     * delegate: internal
     * interface: internal
     * explicitly implemented interface member: public!
     */
    #endregion
    
    #endregion

    #region Normal Base Class Defination/Signature
    public class CoreBase
    {
        Nullable<int> nullValue = null;

        int? nullable = null;

        int i = 5;
       // int? nullResult = i;//5
        public int UserValue { get; }
        public int UserCode { get; }

        public CoreBase(int userValue, int userCode)
        {
            UserValue = userValue;
            UserCode = userCode;
        }

        public CoreBase()
        {
            
        }
        public int LoginSamplePage()
        {
            return UserValue *UserCode;
        }
    }
    #endregion

    #region Static Classes and Static Class Members Defination/Signature
    /*
     * A static class is same as a non-static class, but difference is: a static class cannot be instantiated(we cannot use the new operator to create a variable of the class type).
     * It can Contains only static members and It's Sealed (We can't inherit the class),instead call the Class name.classmembers
     * It is possible to keep static members in Non-static classes.
     * Classes, interfaces, and static classes may have static constructors. A static constructor is called at some point between when the program starts and the class is instantiated.
     * We can't derive/Inherit from Static class.
     * A static constructor in a non-static class runs only once when the class is instantiated for the first time
     * A static constructor in a static class runs only once when any of its static members accessed for the first time.
     * Static members are allocated in high frequency heap area of the memory.
     */
    public static class StaticBaseClass
    {
        public static int UserValue { get; set; }
        public static int UserCode { get; }

        //Access Modifier is not allowed for the Static Constructors
        //Static Constructor must be Parameterless
        static StaticBaseClass()
        {
            Console.WriteLine("Static Constructor");
        }

        public static void CoreBase()
        {
            Console.WriteLine("Static Method");
        }

        public static int LoginSamplePage()
        {
            return UserValue * UserCode;
        }
    }
    #endregion

    #region Desctructor or Finalizer
    /*Finalizers (which are also called destructors) are used to perform any necessary final clean-up when a class instance is being collected by the garbage collector
     * Finalizers cannot be defined in structs. They are only used with classes.
     * A class can only have one finalizer.
     * Finalizers cannot be inherited or overloaded.
     * Finalizers cannot be called. They are invoked automatically.
     * A finalizer does not take modifiers or have parameters.
     * 
     */
    public class Destroyer
    {
        public override string ToString() => GetType().Name;

        ~Destroyer() => Console.WriteLine($"The {ToString()} destructor is executing.");
    }
    #endregion

    #region Arrays
    /*An array is user defined datatype and stores a fixed-size sequential collection of elements of the same type.
     *An array is used to store a collection of data, but it is often more useful to think of an array as a collection of variables of the same type stored at contiguous memory locations.
     * Each value/location is defined using the index. First index of array always starts with 0 and last index is ends with (Size-1) of array.
     * It is reference type.
     * All arrays consist of contiguous memory locations. The lowest address corresponds to the first element and the highest address to the last element.
     * Arrays are most useful for creating and working with a fixed number of strongly-typed objects
     * 
     * 
     */
    #region One or Single Dimension Array
    public class SingleDimensionArray
    {
        //Type 1 : Initialization with size of Array
        public void ArrayWithSizeInitializingElements()
        {
            //When we declare an array type variable, it is a reference, which doesnot have a value(it points to null)
            //This is because the memory for the elements is not allocated yet
            // NEW keyword is used to allocate the memory, elements of an array always stored in DYNAMIC MEMORY(HEAP).
            int[] oneDimension = new int[3];
            //Default elment value is 0 of an array
            oneDimension[0] = 1;
            oneDimension[2] = 3;
        }
        //Type 2 : Initialization without size of Array, directly we can add the fixed index of values while initiating the array
        public void ArrayWithoutSizeInitializingElements()
        {
            int[] oneDimension = new int[5] { 1,2,3,4,5};
            for (int i = 0; i < oneDimension.Length; i++)
            {
                var output = oneDimension[i] = i;
                Console.WriteLine(output);
            }

            try
            {
                Console.WriteLine(oneDimension[7]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("When we try to access an invalid(not existing) element in an array");
                throw;
            }
        }
        //Type 3 : Initialization 
        public void ArrayNonSpecifieidIndexValuesWhileInitializingElements()
        {
            int[] oneDimension = new int[] { 1, 2, 3, 4, 5,6,7,8,9 };
            int[] oneDimensions = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,10,11,12 };
            foreach (var output in oneDimension)
            {
                Console.WriteLine(oneDimension);
            }
            Console.WriteLine("Size of Array:",oneDimension.Length);
            Console.WriteLine("Rank of Array:", oneDimension.Rank);

            oneDimension.CopyTo(oneDimensions, 0);
        }

        public void ReadingArrayFromConsole()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int index = 0; index < n; index++)
            {
                array[index] = int.Parse(Console.ReadLine());
            }
        }

        public void CheckForSymmetricArray()
        {
            Console.WriteLine("Enter a postive interger:");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            Console.WriteLine("Enter the values of the array:");

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            bool symmetric = true;
            for (int i = 0; i < array.Length/2; i++)
            {
                if(array[i] != array[n - i - 1])
                {
                    symmetric = false;
                    break;
                }
            }
            Console.WriteLine("Is smmetric?{0})",symmetric);
        }
    }
    #endregion One or Single Dimension Array

    #region Two or Multi Dimension Array
    //We can easily represent the Standard CHESS BOARD as a two-dimension array with size 8(8 cells in a horizontal and 8 cells in vertical direction)
    //We call more than one we will call two/multi dimensional,because they have two dimensions and etc, they are also known as Matices.
    public class TwoOrMultiDimensionArray
    {
        public void ArrayInitialization()
        {
            int[] oneDimension = new int[5] { 1,2,3,4,5};

            //Matrix[row,column]
            double[,] twoDimension = new double[2,3] 
            {
                { 0.2,1.2,3.1 },// row 0 values
                { 2.2,4.2,8.3 } // row 1 values
            };
            string[,,] threeDimenstion;
        }
        public void TwoDimenstional()
        {
            int[,] twoDimension = { { 1, 2 }, { 4, 3 } };
            //We can get the number of the ROWS of 2 dimensional array by using as below
            twoDimension.GetLength(0);
            twoDimension.GetLength(1);

            //Print the martic in console
            for (int row = 0; row < twoDimension.GetLength(0); row++)
            {
                for (int column = 0; column < twoDimension.GetLength(1); column++)
                {
                    var matrics = twoDimension[row, column];
                    Console.Write(matrics);
                }
                Console.WriteLine();
            }
        }
        public void ReadingMatrixFromConsole()
        {
            Console.WriteLine("Enter the number of the rows:");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of the rows:");
            int columns = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, columns];
            Console.WriteLine("Enter the cells of the martix");

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Console.WriteLine("matrix[{0},{1}",row,column);
                    matrix[row, column] = int.Parse(Console.ReadLine());
                }
            }
        }

        public void MaximalPlatformInMatrix()
        {
            int[,] matrix =
            {
                {0,1,2,3,4 },
                {2,4,6,8,10 },
                {3,6,9,3,12 },
                {4,8,12,16,20 }
            };
            //Find the maximal sum platform of size 2x2
            long bestsum = long.MinValue;
            int bestrow = 0;
            int bestcolumn = 0;

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int column = 0; column < matrix.GetLength(1)-1; column++)
                {
                    long sum = matrix[row, column] + matrix[row, column + 1]
                        + matrix[row + 1, column] + matrix[row + 1, column + 1];

                    if(sum > bestsum)
                    {
                        bestsum = sum;
                        bestrow = row;
                        bestcolumn = column;
                    }
                }
            }
        }
    }
    #endregion Two or Multi Dimension Array

    #region Array of Array or Jagged Array
    //Jagged array are arrays of arrays, or arrays in which each row contains an array of its own
    // And that array can have length different than those in the other rows
    public class ArrayOfArrayOrJaggedArray
    {
        public void JaggedArray()
        {
            //Declaration and allocation
            int[][] jaggedArray;
            jaggedArray = new int[2][];

            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[3];

            //Declare,allocate and initialize
            int[][] myJaggedArray =
            {
                new int[]{1,2,3}, 
                new int[]{1,2},
                new int[]{1,2,3,4}
            };

            //Initialization and Access to the Elements
            myJaggedArray[0][2] = 45;

            //The elements of the Jagged array can be one-dimensional and multi-dimensional arrays
            int[][,] jaggedOfMulti = new int[2][,];
            jaggedOfMulti[0] = new int[,] { { 1, 2 }, { 3, 5 } };
            jaggedOfMulti[1] = new int[,] { { 3, 4, 5 }, { 5, 6, 7} };

        }
    }
    #endregion Array of Array or Jagged Array
    #endregion Arrays
        
    #region Collections
    /*
     * Collection is representing the collection of objects.
     * There are two ways to group objects: by creating arrays of objects, and by creating collections of objects.
     * Every collection is representing with one pre-defined class that class will contain member function and property
     * Collections provide a more flexible way to work with groups of objects. 
     * Unlike arrays, the group of objects you work with can grow and shrink dynamically as the needs of the application change
     * For some collections, you can assign a key to any object that you put into the collection so that you can quickly retrieve the object by using the key.
     * A collection is a class, so you must declare an instance of the class before you can add elements to that collection.
     * A generic collection enforces type safety so that no other data type can be added to it. 
     * When you retrieve an element from a generic collection, you do not have to determine its data type or convert it.
     */
    #region Generic Collection
    #region Lists
    //Represents a list of objects that can be accessed by index. Provides methods to search, sort, and modify lists.
    public class GenericCollectionLists
    {
        public void Lists()
        {
            //Create a list of Strings
            //Type 1:
            var list = new List<string>();
            list.Add("Raju");
            list.Add("Lio");
            list.Add("Vamshi");

            //Type 2:
            var lists = new List<string> { "Raju", "Lio", "Ammu","Appu" };

            //Iterate through the list
            foreach (var item in list)
            {
                Console.WriteLine(item +" ");
            }

            lists.Remove("Lio"); 
            lists.RemoveAt(4);// Removes selected index
            for (int i = 0; i < lists.Count; i++)
            {
                var output = lists[i];
                Console.WriteLine(output);
            }
            //lists.RemoveAll();
        }
    }
    public class Galaxy
    {
        public string Name { get; set; }
        public int MegaLightYears { get; set; }

        private static void IterateThroughList()
        {
           // List<T> type = new List<T>; T- type of list, it accepts all type of datatype as well as class 
            var theGalaxies = new List<Galaxy>
        {
            new Galaxy() { Name="Tadpole", MegaLightYears=400},
            new Galaxy() { Name="Pinwheel", MegaLightYears=25},
            new Galaxy() { Name="Milky Way", MegaLightYears=0},
            new Galaxy() { Name="Andromeda", MegaLightYears=3}
        };

            foreach (Galaxy theGalaxy in theGalaxies)
            {
                Console.WriteLine(theGalaxy.Name + "  " + theGalaxy.MegaLightYears);
            }

            // Output:
            //  Tadpole  400
            //  Pinwheel  25
            //  Milky Way  0
            //  Andromeda  3
        }
    }
    #endregion Lists

    #region Dictionaries
    //Represents a collection of key/value pairs that are organized based on the key.
    //the key cannot be null, but value can be.key must be unique. 
    // Duplicate keys are not allowed if you try to use duplicate key then compiler will throw an exception.
    //We can only store same types of elements.The capacity of a Dictionary is the number of elements that Dictionary can hold.
    public class Dictionaries
    {
        public void Dictionary()
        {
            Dictionary<int, string> pair = new Dictionary<int, string>();
            pair.Add(01, "one");
            pair.Add(02, "two");
            pair.Add(03, "three");// Add key-value pairs in Dictionary<TKey, TValue> collection.
            pair.Add(04, "four");//Adds an item to the Dictionary collection.

            var counts=pair.Count;
            pair.Remove(03);// Removes the element with the specified key.
            pair.ContainsKey(02);//Checks whether the specified key exists in Dictionary<TKey, TValue>.
            pair.ContainsValue("four");//Checks whether the specified value exists in Dictionary<TKey, TValue>.
        //    pair.TryGetValue(01,"one");//Returns true and assigns the value with specified key, if key does not exists then return false.

            foreach (var item in pair)
            {
                var keyValue = item;
                Console.Write(keyValue); // one two three four
            }
            Console.WriteLine(pair[03]); // Output - three

            pair.Clear();//Removes all the elements from Dictionary<TKey, TValue>.

            // Console.WriteLine(pair["one"]); we can't access value by calling object value

            for (int item = 0; item < pair.Count; item++)
            {
                var output = pair[item];
                Console.Write(output);
            }
        }

        public void DictionaryDeclaration()
        {
            //It is recommended to program to the interface rather than to the class.
            //So, use IDictionary<TKey, TValue> type variable to initialize a dictionary object.
            IDictionary<string, double> directAssign = new Dictionary<string, double>() { { "one", 1.0 }, { "two", 2.2 }, { "three", 3.0 } };

            directAssign.FirstOrDefault(value => value.Key == "one");
            //directAssign.FirstOrDefault(value => value.Key == "one").Value;

            Dictionary<int, HashSet<int>> _myUniquePairOfIntegerKeys;
            // OR
            Dictionary<string, Dictionary<string, bool>> _myUniquePairOfStringKeysWithABooleanValue;
            //OR
            Dictionary<Dictionary<int, string>, Dictionary<string, bool>> _myUniquePairOfStringKeysWithABooleanValues;
        }
    }
    #endregion Dictionariesp

    #endregion Generic Collections

    #region Non-Generic Collections
    /*
     * 
     * 
     * 
     */

    #region Array List
    /* It can contain elements of any data types.Unlike an array, you don't need to specify the size of ArrayList
     * It is similar to an array, except that it grows automatically as you add items in it.
     * The ArrayList class implements IEnumerable, ICollection, and IList interfaces
     * We can create an object of ArrayList class and assign it to the variable of any base interface type
     * if you assign it to IEnumerable or ICollection type variable then you won't be able to add elements and access ArrayList by index.
     * ArrayList can contain multiple null and duplicate valueso
     * ArrayList class includes Sort(ascending) and Reverse(decending/reverse the element) 
     * Major methods: Add(), AddRange(), Remove(), RemoveRange(), Insert(), InsertRange(), Sort(), Reverse() methods.
     */
    public class ArrayListNonGeneric
    {
        public void ArrayListImplementation()
        {
            ArrayList myArryList1 = new ArrayList();// Recommended
             // or - with some limitations
            IList myArryList2 = new ArrayList();
            // or - with some limitations
            ICollection myArryList3 = new ArrayList();
            // or - with some limitations
            IEnumerable myArryList4 = new ArrayList();
        }
        public void ArrayList()
        {
            //IList Doesn't contains RemoveRange, InsertRange and etc
            IList arrayList = new ArrayList();
            arrayList.Add("one");
            arrayList.Add(2);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(3.01);
            arrayList.Add(9);
            arrayList.Add(1.1f);
            arrayList.Add(null);
            arrayList.Add(true);

            for (int list = 0; list < arrayList.Count; list++)
            {
                var output = arrayList[list];
                Console.Write(output +" "); //Output: one 2 2 3 3.01 9 1.1 true
            }
            arrayList.Remove(9);//removes 9
            arrayList.RemoveAt(5);  //Removes 1.1 the first element from an ArrayList

            // ArrayList elements can be accessed using indexer, in the same way as an array
            var firstIndexValue = arrayList[0];// return one

            // Type casting
            double sixthElement = (double)arrayList[4];// return 3.01

            arrayList.Insert(3, "three");
            arrayList.Insert(5, 10.22);
            Console.WriteLine();

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);// Output : one 2 2 three 3 10.22 3.01  1.1 true
            }

            ArrayList arrayList1 = new ArrayList();
            arrayList1.Add(100);
            arrayList1.Add(500);
            arrayList1.Add(200);
            arrayList1.Add(300);
            arrayList1.Add(400);

            arrayList1.Sort();//ascending order - 100 200 300 400 500
            arrayList1.Reverse();// decending/reverse - 500 400 300 200 100

            arrayList1.InsertRange(2, arrayList);
            arrayList1.RemoveRange(0, 2);//Removes two elements starting from 1st item (0 index)

            foreach (var item in arrayList1)
            {
                Console.Write(item+" "); // one 2 2 three 3 10.22 3.01  True 300 200 100
            }
        }
    }
    #endregion Array List

    #region Sorted List
    /* SortedList collection stores key-value pairs in the ascending order of key by default.
     * SortedList class implements IDictionary & ICollection interfaces, so elements can be accessed both by key and index.
     * Key can't be null or different datatype but Value can be null or different data type.
     * It sorts the elements everytime you add the elements
     * SortedList key can be of any data type, but you cannot add keys of different data types in the same SortedList
     * The key type of the first key-value pair remains the same for all other key-value pairs
     * SortedList can be accessed by index or key. Unlike other collection, SortedList requires key instead of index to access a value for that key.
     * Access individual value using indexer. SortedList indexer accepts key to return value associated with it
     */
    public class SortedListNonGeneric
    {
        public void SortedList()
        {
            SortedList sortedList = new SortedList()
            {
                 {3, "Three"},
                 {4, "Four"},
                 {1, "One"},
                 {5, "Five"},
                 {2, "Two"}
            };

            sortedList.Contains(2); // returns true
            sortedList.ContainsKey(2); // returns true
            sortedList.ContainsValue("Five"); // returns true

            foreach (DictionaryEntry kvp in sortedList)
            {
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value); 
            }

            SortedList sortedList1 = new SortedList();
            sortedList1.Add(3, "Three");
            sortedList1.Add(4, "Four");
            sortedList1.Add(1, "One");
            sortedList1.Add(5, "Five");
            sortedList1.Add(2, "Two");

            sortedList.ContainsValue("One"); // returns true
            SortedList sortedList2 = new SortedList();
            sortedList2.Add("one", 1);
            sortedList2.Add("two", 2);
            sortedList2.Add("three", 3);
            sortedList2.Add("four", 4);

            SortedList sortedList3 = new SortedList();
            sortedList3.Add(1.5, 100);
            sortedList3.Add(3.5, 200);
            sortedList3.Add(2.4, 300);
            sortedList3.Add(2.3, null);
            sortedList3.Add("string", null); //Run time error -  InvalidOperationException

            int j = (int)sortedList2["two"];// return 2
            string str = (string)sortedList2["four"]; // return 4

            for (int i = 0; i < sortedList2.Count; i++)
            {
                Console.WriteLine("key: {0}, value: {1}",sortedList2.GetKey(i), sortedList2.GetByIndex(i));
            }
        }
    }
    #endregion Sorted List

    #region Stacks
    //Represents a collection of key/value pairs that are organized based on the key.
    public class StacksNonGeneric
    {
        public void Stack()
        {
            var lastInFirstOut = new Stack() { };
            lastInFirstOut.Push(3);
            lastInFirstOut.Push(5);
            lastInFirstOut.Push(null);
            lastInFirstOut.Push("String value");
            lastInFirstOut.Push(100.010);
            lastInFirstOut.Push(1);
            lastInFirstOut.Push(3);//Insert the values/element to the stack the top most empty location

            foreach (var item in lastInFirstOut)
            {
                var output = item;
                Console.Write(output+" "); // 3 1 100.01 String value  5 3 
            }
            var retriveTopMostElement1 = lastInFirstOut.Peek();//3
            var retriveTopMostElement2 = lastInFirstOut.Peek();//3
            lastInFirstOut.Contains(1);//true

            var retriveAndRemoveTopMostElementPermanantly1 = lastInFirstOut.Pop();//3
            var retriveAndRemoveTopMostElementPermanantly2 = lastInFirstOut.Pop();//1

            Console.WriteLine();
            foreach (var item in lastInFirstOut)
            {
                var output = item;
                Console.Write(output+ " ");// 100.01 String value  5 3
            }
            lastInFirstOut.Contains(1);//false
            lastInFirstOut.Clear();//removes all elements
        }
    }
    #endregion Stacks

    #region Queue
    //Queue stores the elements in FIFO style (First In First Out), exactly opposite of the Stack collection.
    //It contains the elements in the order they were added.
    //Queue collection allows multiple null and duplicate values.
    //Use the Enqueue() method to add values and the Dequeue() method to retrieve the values from the Queue
    public class QueueNonGeneric
    {
        public void Queue()
        {
            Queue que = new Queue() { };
            que.Enqueue(1);
            que.Enqueue("two");
            que.Enqueue(1);
            que.Enqueue(null);
            que.Enqueue(null);
            que.Enqueue(2);
            que.Enqueue(4);//Add the Value
            que.Dequeue();// Removes and returns an item from the beginning of the queue(top most element).
            que.Peek();//Returns an first item from the queue

            foreach (var item in que.ToArray())
            {
                var output = item;
                Console.Write( output +" ");//two 1 2 4
            }
            Console.WriteLine();
            for (int item = 0; item < que.Count; item++)
            {
               var output = que.Dequeue();
               Console.Write(output +" "); // Output : two 1
            }
            var result = que.Peek();
            que.Contains(4);//true
            que.Clear(); // clears all the elements from the queue
            Console.WriteLine(result);// null
        }
    }
    #endregion Queue

    #region Hash table
    /*Hashtable collection stores key-value pairs.
     * It optimizes lookups by computing the hash code of each key and stores it in a different bucket internally and then matches the hash code of the specified key at the time of accessing values.
     * We can't have a duplicate keys in hash table.
     * it can contains a key and a value of any data type.
     * So values must be cast to an appropriate data type(Type casting), otherwise it will give compile-time error.
     * Hashtable key cannot be null whereas the value can be null
     * Hashtable retrieves an item by comparing the hashcode of keys and type casting. So it is slower in performance than Dictionary collection
     * When you try to access non existing key,it'll give null values.
     */
    public class HashTableNonGeneric
    {
        public void HashTable()
        {
            //Weekly typed datatype, so we can add any type of datatype
            Hashtable ht = new Hashtable();
            ht.Add(1, "One");
            ht.Add(2, "Two");
            ht.Add(3, "Three");
            ht.Add(4, "Four");
            ht.Add(5, null);
            ht.Add("Fv", "Five");
            ht.Add(8.5F, 8.5);

            Hashtable hts = new Hashtable()
                {
                    { 1, "One" },
                    { 2, "Two" },
                    { 3, "Three" },
                    { 4, "Four" },
                    { 5, null },
                    { "Fv", "Five" },
                    { 8.5F, 8.5 }
                };

            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine("key:{0}, value:{1}", item.Key, item.Value);
            }
              //Key: Fv, Value: Five

            string strValue1 = (string)ht[2];
            string strValue2 = (string)ht["Fv"];//Five
            float fValue = (float)ht[8.5F];//8.5
            Console.Write(strValue1," "+strValue2+" "+fValue);  //two Five 8.5
        }
    }
    #endregion Hash table

    #endregion Non-Generic Collections

    #endregion Collections

    #region String and Text Processing
    /*
     * String is a Sequence of Characters stored in a certain address in memory.
     * In .NET framework each character has a serial number from the UNICODE table.
     * It can be a character, a word or a long passage surrounded with the double quotes 
     */
    public class StringAndTextProcessing
    {
        public void StringDeclaration()
        {
            string useStringKeyword = "Hello"; // uses string keyword

            String useStringClass = "Hello"; // uses System.String class

            //Use backslash(\) before double quotes and some special characters such as \,\n,\r,\t, etc. to include it in a string.
            string textWithDoubleQuote = "This is a \"string\" in C#.";
            string textOption = "xyzdef\\rabc";
            string directoryPath = "\\\\mypc\\ shared\\project";

            //it will be very tedious to prefix \ for every special character. 
            //Prefixing the string with an @ indicates that it should be treated as a literal and should not escape any character
            string str3 = @"xyzdef\rabc";// xyzdef\\rabc
            string directory = @"\mypc\shared\project"; // \\mypc\\shared\\project
            string email = @"test@test.com"; //test@test.com

            //Use @ and \ to declare a multi-line string.
            string multilineString = @"this is a \
                      multi line \
                      string";//"this is a \\\r\n                      multi line \\\r\n                      string"
        }

        public void _StringAndCharArrayAndReplace()
        {
            //String as Char array
            char[] character = { 's', 't', 'r', 'i', 'n', 'g', ' ', 'c', 'h', 'a', 'r' };//char[11]
            string stringArray = new string(character); //string char
            int length = stringArray.Length; //11
            for (int i = 0; i < length; i++)
            {
                Console.Write(stringArray[i] + "\t");// s t r i n g  c h a r
            }

            string str = "abcde";
            string assignValueOfAnotherString = str;//abcde
            char ch = assignValueOfAnotherString[2];// c
            //str[1] = 'a'; compile error

            string charReplace = str.Replace('a','z').Replace('b', 'y'); //zycde

            string name = "Raju, Tamizh, Ammu, Appu,Amma, Appa";
            char[] seperators = new char[] { ',', '.', ' ' };// sepeated by comma, dot and space
            string[] splitNames = name.Split(',');

            foreach (var item in splitNames)
            {
                //Remove the empty element after spliting 
                if(name != "")
                {
                    Console.WriteLine(item);
                }
            }

            //To remove empty entries after splitting
            string[] nameArr = name.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

        }

        public void _SwitchingUpperAndLowerCaseLetters()
        {
            string text = "All  Kind OF LeTTeRs";
            Console.WriteLine(text.ToLower());// all kind of letters
            Console.WriteLine(text.ToUpper());// ALL KIND OF LETTERS
            Console.WriteLine(text.ToLower() == "all kind of letters"); // true
        }

        public void _SearchStringWithinAnotherString()
        {
            string book = "Travel to the entire, X world before die";
            int index = book.IndexOf("to");// substring wil be found and the first character of the searched word
            Console.WriteLine(index);// 7 
            Console.WriteLine(book.IndexOf("Entire"));//5
            Console.WriteLine(book.IndexOf("X"));
            Console.WriteLine(book.IndexOf("WORLD"));// -1 
            Console.WriteLine(book.LastIndexOf("die"));

            //Find all the occurance of the substring

            string quote = "The main intent of the \"Intro C#\"" + "book is to introduce the C# programming to newbies";
            string keyword = "C#";
            int indexValue = quote.IndexOf(keyword);//30

            while(indexValue != -1)
            {
                Console.Write("Keyword {0} is found at Index:{1}",keyword,indexValue);//
                index = quote.IndexOf(keyword, indexValue + 1);
                //indexValue++;
            }

            // Extract the portion of a String
            string particularText = quote.Substring(0, 14); // The main intent 

        }

        public void _StringConcatenationAndInterpolation()
        {
            //Multiple strings can be concatenated with + operator.
            string name = "Mr." + "Raju " + "Lio" + ", Code: 007";//Mr.Raju Lio, Code: 007

            string firstName = "Raju";
            string lastName = "Lio";
            string code = "007";

            string concatKeyword = string.Concat(firstName, lastName, code); // Rajulio007
            string concatenation = "Mr." + firstName + " " + lastName + ", Code: " + code;//Mr.Raju Lio, Code: 007

            //An interpolated string is a mixture of static string and string variable where string variables should be in {} brackets.
            //Use two braces, "{{" or "}}" to include { or } in a string.
            string interpolation = $"Mr. {firstName} {lastName}, Code: {code}";//Mr. Raju Lio, Code: 007
        }

        public void CompareStringInAlphabetical()
        {
            //Comparison for Equality
            string word1 = "C#"; string word2 = "c#";
            Console.WriteLine(word1.Equals("C#")); //true
            Console.WriteLine(word1 =="C#");       //true
            Console.WriteLine(word1 == word2);     //false
            Console.WriteLine(word1.Equals(word2));//false

            //To ignore the diff b/w small and capital letter in string comparison
            Console.WriteLine(word1.Equals(word2, StringComparison.CurrentCultureIgnoreCase)); //True

            //Compare lexicographical order
            //Two string have to be same value,they mush have same length and all the characters should match occordingly
            string text1 = "sCore"; string text2 = "Scary"; string text3 = "sCary";
            Console.WriteLine(text1.CompareTo(text2)); //1
            Console.WriteLine(text1.CompareTo(text1)); //-1
            Console.WriteLine(text1.CompareTo(text1)); //0 

            //Compare lexicographical order and To ignore the letters casing
            Console.WriteLine(string.Compare(text1,text3,true)); //0

        }

        public void StringTrim_RegularExpression_Interning()
        {
            // Trim (remove the unwanted space)
            string fileData = "     \n\n      RajuLio 111 # $$ &&& %%%%% ##         ";
            string trim = fileData.Trim();    //RajuLio 111 # $$ &&& %%%%% ##
            string leftTrim = fileData.TrimEnd();//"     \n\n      RajuLio 111 # $$ &&& %%%%% ##"
            string rightTrim = fileData.TrimStart();//"RajuLio 111 # $$ &&& %%%%% ##         "

            char[] chars = new char[] { '1', '#', '$', '&', '%' };
            string trimChars = fileData.Trim(chars); //"     \n\n      RajuLio 111 # $$ &&& %%%%% ##         "

            //Regular Expressions
            string document = "Dev's number:9876543210\nFranky can be" + "found at 0543322. \nRaju's number:98373627372";
            string replacedDoc = Regex.Replace(document, "(08)[0-9]{9}", "$1*******");//Dev's number:9876543210\nFranky can befound at 0543322. \nRaju's number:98373627372"

            //Interning
            string declared = "Internet";
            string built = new StringBuilder("Internet").ToString();//Internet
            string interned = string.Intern(built);//Internet

            Console.WriteLine(object.ReferenceEquals(declared, built)); // False
            Console.WriteLine(object.ReferenceEquals(declared, interned)); //True
        }

        public void StringBuilder()
        {
            // String concat 
            string collector = "Numbers: ";
            for (int index = 0; index < 2000; index++)
            {
                collector += index;
            }
            Console.WriteLine(collector.Substring(0,1024));

            //String builder is a class that surves to build and change strings. 
            //It overcomes the perfomance problems when concatenating strings of type string.
            //The class is built in the form of array of characters & we need to know about in it can be freeldy changed
            StringBuilder sb = new StringBuilder(100);
            sb.Append("Numbers: ");

            for (int index = 0; index <=200; index++)
            {
                sb.Append(index);
            }
            Console.WriteLine(sb.ToString().Substring(0,1024));

            int lengthOfString = sb.Length;
            sb.Replace('N', 'M');
            sb.ToString();
            sb.Insert(2, "Raju");
            sb.Remove(2, 3);
            int capacity = sb.Capacity;
        }

        public void StringFormatting_ParsingData()
        {
            //In .NET is that practically every object of a class and primitive variables
            //This is done by the method ToString(...),which is present in all .NET objects.
            DateTime dateTime = new DateTime();
            string dt = dateTime.ToString();

            //Use of String.Format
            //It is a static method by which we can format text and other data through a template(fomratting string)
            Console.WriteLine("Raju arrives office around {0}", "Sharp time");

            string name = "Raju"; string task = "Selenium"; string location = "EvryIndia";
            string formattedText = string.Format("Today is {0:MM/DD/YYYY} and {1} is working on {2} in {3}.", dt, name, task, location);

            //Reverse operation of data formatting is data parsing. Converting from text to some other data type, the opp of ToString()
            string text = "15"; string text2 = "True";
            int intValue = int.Parse(text); // 15
            bool boolValue = bool.Parse(text2); // True
        }
    }
    #endregion String and Text Processing

    #region Struct
    /*
     * C# includes a value type entity same as class called "structure".
     * Structs are mainly useful to hold small data values and it's sealed(can't inherit)
     * A structure can be defined using the struct operator.structures cannot have default constructor
     * A structure can implement one or more interfaces.Structure members cannot be specified as abstract, virtual, or protected.
     * It can contain parameterized constructor, static constructor, constants, fields, methods, properties, indexers, operators, events and nested types,but not destructor.
     * A structure is declared using struct keyword with public or internal modifier. 
     * The default modifer is internal for the struct and its members. However, you can use private or protected modifier when declared inside a class.
     * must assign values to all the members of a struct in parameterized constructor, otherwise it will give compile time error if any member remains unassigned.
     * A struct can include static parameterless constructor and static fields.
     * Define when,
     * It logically represents a single value, similar to primitive types (integer, double, and so on).
     * It has an instance size smaller than 16 bytes.It is immutable.It will not have to be boxed frequently.
     */
    public struct structure
    {
        public int EmpId;
        public string FirstName;
        public string LastName;

        //A struct object can be created with or without the new operator, same as primitive type variables.
        //When you create a struct object using the new operator, an appropriate constructor is called.

        public structure(int empid, string fname, string lname)
        {
            EmpId = empid;
            FirstName = fname;
            LastName = lname;
        }
    }
    //The default modifer is internal for the struct and its members. However, you can use private or protected modifier when declared inside a class.
    public class StructClass
    {
        structure emp;
        structure emp1 = new structure();
        //emp1.structure(12,"s","R");
    }
    #endregion Struct

    #region Partial Class
    /*
     * Each class in C# resides in a separate physical file with a .cs extension.Nested partial types are allowed.
     * C# provides the ability to have a single class implementation in multiple .cs files using the partial modifier keyword.
     * The partial modifier can be applied to a class, method, interface or structure.
     * All the partial class definitions must be in the same assembly,same access modifier and namespace
     * If any part is declared abstract, sealed or base type then the whole class is declared of the same type.
     * Different parts can have different base types and so the final class will inherit all the base types.
     * Advantage:
     * Multiple developers can work simultaneously with a single class in separate files.
       When working with automatically generated source, code can be added to the class without having to recreate the source file.
       For example, Visual Studio separates HTML code for the UI and server side code into two separate files: .aspx and .cs files.
     */

    //Example: PartialClassFile1.cs
    public partial class MyPartialClass
    {
        public MyPartialClass()
        {
            Console.WriteLine("Partial Class constructor");
        }

        public void Method1(int val)
        {
            Console.WriteLine(val);
        }
    }

    //Example: PartialClassFile2.cs
    public partial class MyPartialClass
    {
        public void Method2(int val)
        {
            Console.WriteLine(val);
        }
    }
    //MyPartialClass in PartialClassFile1.cs defines the constructor and one public method, Method1,
    //whereas PartialClassFile2 has only one public method, Method2. The compiler combines these two partial classes into one class as below:
    /*
    public partial class MyPartialClass
    {
        public MyPartialClass()
        {
            Console.WriteLine("Partial Class constructor");
        }

        public void Method1(int val)
        {
            Console.WriteLine(val);
        }
        public void Method2(int val)
        {
            Console.WriteLine(val);
        }
    }
    */

    #region Partial class methods
    /*
     * A partial method may or may not have an implementation.
     * If the partial method doesn't have an implementation in any part then the compiler will not generate that method in the final class
     */
    public partial class MyPartialClass2
    {
        partial void PartialMethod(int val);

        public MyPartialClass2()
        {

        }
        public void Method2(int val)
        {
            Console.WriteLine(val);
        }
    }
    public partial class MyPartialClass2
    {
        public void Method1(int val)
        {
            Console.WriteLine(val);
        }

        partial void PartialMethod(int val)
        {
            Console.WriteLine(val);
        }
    }
    /*
     * AFter compliation of the Partial class methods
    public partial class MyPartialClass2
    {
        public MyPartialClass2()
        {

        }
        public void Method1(int val)
        {
            Console.WriteLine(val);
        }
        public void Method2(int val)
        {
            Console.WriteLine(val);
        }
        partial void PartialMethod(int val)
        {
            Console.WriteLine(val);
        }
    }
    */
    #endregion Partial class methods
    #endregion

    #region Enumerators
    /*
     *In C#, enum is a value type data type. The enum is used to declare a list of named integer constants 
     * It can be defined using the enum keyword directly inside a namespace, class, or structure. 
     * The enum is used to give a name to each constant so that the constant integer can be referred using its name.
     */
    public class GlobalEnumarator
    {
        public enum WeekDays
        {
            //By default constants integer value is starts from zero
            Monday = 0,
            Tuesday = 1,
            Wednesday = 2,
            Thursday = 3,
            Friday = 4,
            Saturday , // Need not to assign the value, it will take automatically based on order
            Sunday = 6
        }

        #region String value implementation for the Global Enums
        public class StringValue : System.Attribute
        {
            public string Value { get; private set; }

            public StringValue(string value)
            {
                Value = value;
            }
        }
        #endregion
        public enum EnumAsStringProperty
        {
            [StringValue("RajuLio")]
            UserName,
        }
        
        public void EnumImplementation()
        {
            Console.WriteLine(WeekDays.Sunday);// 6
            Console.WriteLine(WeekDays.Saturday);//5
            Console.WriteLine(EnumAsStringProperty.UserName); // RajuLio
            Console.WriteLine(Enum.GetName(typeof(WeekDays), 4));// Friday
           // Console.WriteLine(Enum.GetValues(typeof(WeekDays),1));
        }
    }
    #endregion Enumerator

    #region Indexer
    /*
     * C# indexers are usually known as smart arrays, created with 'this' keyword.Parameterized property are called indexer
     * Indexer is a class property that allows you to access a member variable of a class or struct using the features of an array.
     * Indexers are accessed using indexes where as properties are accessed by names.
     * Indexers are created using this keyword. Indexers in C# are applicable on both classes and structs. 
     * Indexers are implemented through get and set accessors for the [ ] operator.
     * ref and out parameter modifiers are not permitted in indexer.
     * The formal parameter list of an indexer corresponds to that of a method and at least one parameter should be specified.
     * Indexer is an instance member so can't be static but property can be static,can be overloaded.
     * 
     */
    //Example 1:
    class SampleCollection<T>
    {
        // Declare an array to store the data elements.
        private T[] arr = new T[100];

        // Define the indexer to allow client code to use [] notation.
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
    }
    class IndexerImplementation
    {
        public  void Index()
        {
            var stringCollection = new SampleCollection<string>();
            stringCollection[0] = "Hello, World";
            Console.WriteLine(stringCollection[0]);
        }
    }

    //Example 2
    public class Indexer
    {
        public string Name {get;set;}
        private float[] temps = new float[5] { 56.2F, 56.7F, 56.5F, 56.9F,56.7F};
        private Indexer[] _userName;

        //Example 1
        //public int this[int index]
        //{
        //    get
        //    {
        //        return _userName[index];
        //    }
        //    set
        //    {
        //        _userName[index] = value;
        //    }
        //}

        private string[] names = new string[10];
        public string this[int i]
        {
            get
            {
                return names[i];
            }
            set
            {
                names[i] = value;
            }
        }
        public void IndexImplementation()
        {
            Indexer Team = new Indexer();
            Team[0] = "Rocky";
            Team[1] = "Teena";
            Team[2] = "Ana";
            Team[3] = "Victoria";
            Team[4] = "Yani";
            Team[5] = "Mary";
            Team[6] = "Gomes";
            Team[7] = "Arnold";
            Team[8] = "Mike";
            Team[9] = "Peter";
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Team[i]);
            }
            Console.ReadKey();
        }
    }
    #endregion Indexer

    #region Delegates
    /*
     * A delegate is like a pointer to a function.
     * It is a reference type data type and it holds the reference of a method. All the delegates are implicitly derived from System.Delegate class.
     * A method that is going to assign to delegate must have same signature as delegate
     * Delegates can be invoke like a normal function or Invoke() method.
     * Multiple methods can be assigned to the delegate using "+" operator. It is called multicast delegate.
     */
    public class DelegatesEx
    {
        //This delegate can be used to point to methods
        public delegate void PrintMethods();//Parameter less
        public delegate void GetMethods(int value);//Parameter
        public void MethodCalling()
        {
            //TYPE : 1
            PrintMethods getMethods = new PrintMethods(Method1);
            PrintMethods getMethod2 = new PrintMethods(Method2);
            
            //Field initialize can't reference the Non static field, method or property
            //PrintMethods getMethods = new PrintMethods(Method4); -- error

            //TYPE : 2
            PrintMethods printFirstMethod = Method1;
            PrintMethods printSecondMethod = Method2;
           // PrintMethods printThirdMethod = Method3; Non-static mehtod can't initialize
            printFirstMethod();
            printFirstMethod();
            printSecondMethod();
            //printThirdMethod(10); Can't pass paramter, since it is not a parmeter delegate
            getMethod2();

            GetMethods getMethod = Method3;
            getMethod(10);

        }

        //The delegate can be invoked like a method because it is a reference to a method
        public void InvokingDelegate()
        {
          //The delegate can be invoked by two ways:using() operator or using the Invoke() method of delegate
            PrintMethods printDelegate = Method1;
            printDelegate.Invoke();//Static Method 1
            printDelegate();//Static Method 1
        }

        //GetMethods(Methods1,100), To call below methods
        public void PassDelegateAsParamter(GetMethods delegateFunc, int numToPrint)
        {
            delegateFunc(numToPrint);
        }

        public void MulticastDelegate()
        {
            PrintMethods print = Method1;
            print += Method2;
        }
        public static void Method1()
        {
            Console.WriteLine("Static Method 1");
        }
        public static void Method2()
        {
            Console.WriteLine("Static Method 2");
        }
        public static void Method3(int num)
        {
            Console.WriteLine("Static Method with Paramater");
        }
        public void Method4()
        {

        }
    }
    #endregion Delegates

    #region Events
    /*
     * An event has a publisher, subscriber, notification and a handler. Generally, UI controls use events extensively. 
     * An event is nothing but an encapsulated delegate. As we have learned in the previous section, a delegate is a reference type data type
     * Use event keyword with delegate type to declare an event
     * 
     * 
     */
    public class Events
    {
        // declare delegate
        //This delegate can be used to point to methods
        public delegate void Delegates(object sender, int arg);

        //declare event of type delegate
        public event Delegates DelegateEventMethod;

        //Invoking an Event






        public void EventMethod(int arg)
        {
            if(DelegateEventMethod != null)
            {
 
            }
        }
       
        public event EventHandler DelegateEventMethods
        {
            add
            {
                Console.WriteLine("Add operation");
            }
            remove
            {
                Console.WriteLine("Remove operation");
            }
        }

        private class DelegatesCalling
        {

        }
    }
    #endregion Events
}
