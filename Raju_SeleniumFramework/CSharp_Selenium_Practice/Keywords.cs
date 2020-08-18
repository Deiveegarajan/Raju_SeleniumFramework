using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium_Practice
{
    class Keywords
    {
        /* DYNAMIC
         * dynamic allows the type of value to change after it is assigned to initially
         * Intellisense help is not available for dynamic type of variables since their type is unknown until run time.
         * dynamic variables can be used to create properties and return values from a function.
         * The dynamic keyword is used to declare dynamic types. 
         * The dynamic types tell the compiler that the object is defined as dynamic and skip type-checking at compiler time; delay type-checking until runtime. 
         * All syntaxes are checked and errors are thrown at runtime
         *  It plays a vital role in key technologies such as LINQ
         */
        public void Dynamic(dynamic anyDatatype = null)
        {
            dynamic integer = 143;
            Console.WriteLine(integer);//143

            integer = "We can use same variable for diffenent datatypes";
            Console.WriteLine(integer);//"We can use same variable for diffenent datatypes";

            dynamic stringValue = integer;
            Console.WriteLine(stringValue);//"We can use same variable for diffenent datatypes"

            //  public dynamic Property
            //{
            //     get; 
            //}
    }

        /* VAR
         * when you don't know what will be the return type of the field, use VAR keyword
         * var variables cannot be used for property or return values from a function. They can only be used as local variable in a function.
         * 
         */
        public void Var()
        {
            //var type of variables are required to be initialized at the time of declaration or else they encounter the compile time error
            // var i; //Implicity typed variables must be Initialised 
            var i = 10;
            //var i = "A local variable or function method - is already defined in this scope";
            int j = 10;
            
        }

        /* OBJECT
         * While declaring the variable, if we are not sure about the datatype use OBJECT TYPE
         * It is the top most base class in C#
         * we can pass any type of values as parameter
         */
        public void Object(object obj)
        {
            object o = 19;
            var type = o.GetType();
        }
    }
}
