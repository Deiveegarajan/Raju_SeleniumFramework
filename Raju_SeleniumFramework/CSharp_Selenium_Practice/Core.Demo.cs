
using System;

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

    #region Static Contructor Class Defination/Signature
    public static class CoreStaticClass
    {
        public static int UserValue { get; }
        public static int UserCode { get; }

        static CoreStaticClass()
        {
            
        }

        public static void CoreBase()
        {

        }

        public static int LoginSamplePage()
        {
            return UserValue * UserCode;
        }
    }
    #endregion

    #region Interface Defination/Signature  - Multiple level Inheritance
    /*
     * Interface is the complete ABSTRACT CLASS. All the interface/Abstract Methods must Derived/Implemented in the Child Class. 
     * Interface contains only abstract methods(A method without method body is called as Abstract methods ),and cannot be instantiated
     * Interface is an user-defined Data type.
     * All the members by default are public members.The modifier 'public/private/protected' is not valid for this item
     * An interface can be a member of a namespace/class. An interface declaration can contain declarations (signatures without any implementation) of the METHODS,PROPERTIES,INDEXERS,EVENTS
     * It can't contain Static method and members. If you want to keep,In 8.1(full defination) we should define.
     */
    interface IEquatable<T>
    {
        bool Equals(T obj);
    }
    public interface IParameter
    {
        // Property implementation
        int X { get; set; }
        int Y { get; set; }

        //public double Distance =>
        //   Math.Sqrt(X * X + Y * Y);
    }
    public interface ICoreInterfaceBase2
    {
        int CoreInterfaceMethodA(int i);

        string CoreInterfaceMethodA(string name, string password);
    }
    interface ICoreInterfaceBase1
    {
        void SampleMethod();
    }

    //An interface can inherit from one or more base interfaces
    interface IDerivedFromCoreInterface : ICoreInterfaceBase1, ICoreInterfaceBase2
    {
        void SampleDerivedMethod(int a, int b);
       // int CoreInterfaceMethodA(int i);
    }

    // If a class is Inheriting from an interface it is to implement the members of its parent(interface).
    // A Class can inherit from a class and interface at the same time
    public class ImplementationInterfaceClass: IDerivedFromCoreInterface
    {
        //Explicit interface member implementation
        public void SampleDerivedMethod(int a,int b)
        {
            var output = a * b;
        }
        public string CoreInterfaceMethodA(string name, string password)
        {
            return name;
        }
        public void SampleMethod()
        {

        }
        //Alternative implementation way - need not to be public, interface members are public here
         int ICoreInterfaceBase2.CoreInterfaceMethodA(int i)
        {
            i = 10;   
            return i;
        }
        //Paramaterized Constructor
       public ImplementationInterfaceClass(int x,int y)
        {
           var output= x* y;
        }

        // Constructor
        public ImplementationInterfaceClass()
        {

        }
        // Direct Inheritance by passing the interface as parameter
        public void Parameter(IParameter par)
        {
            var rsltA = par.X;
            var rsltB = par.Y;
        }
    }
    #endregion

    #region Abstract Class Defination/Signature
    /*
     * Abstract Class : Non abstract Methods(Methods with Method body) and also Asbstrat Methods (Methods without method body)
     * Use the abstract modifier in a class declaration to indicate that a class is intended only to be a BASE CLASS of other classes, not instantiated on its own
     * The abstract modifier can be used with classes, methods, properties, indexers, and events
     * Members marked as abstract must be implemented by non-abstract classes that derive from the abstract class.
     * Abstract method declaration should be using either abstrat keyword (without body) or virtual keyword (with body), and we must derived with OVERRIDE keyword.
     * Abstract Method must be overridden in non-abstract child class.
     */

    public abstract class AbsractBaseClass
    {
        //Abstract method declarations are only permitted in abstract classes.
        public abstract void MethodA();

       // public virtual void MethodB(); We can't keep virtual keyword in the declartion(without body).
        public abstract int MethodB(int i);

        //An abstract method is implicitly a virtual method.
        // Default implementation which can be overridden by subclasses(using override keyword).
        public virtual void AbstractMethod()
        {
            Console.WriteLine("This is the Abstract Base Method");
        }
    }
    /*
     * Abstract methods do not provide an implementation and force the derived classes to override the method
     */
    public class ImplementationOfAbstractClass : AbsractBaseClass
    {
        // Use OVERRIDE keyword to derive the Abstract method
        public override void MethodA()
        {
            int a = 5, b = 10;

            var rslt = a + b;
        }

        public override int MethodB(int i)
        {
            return i;
        }
       
        public override void AbstractMethod()
        {
            //To Print or Call the base class Abstract method 
            base.AbstractMethod();

            Console.WriteLine("This is the Derived Method");
        }
    }
    #endregion
}

