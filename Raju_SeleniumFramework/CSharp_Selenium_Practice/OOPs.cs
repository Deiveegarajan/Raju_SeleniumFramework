using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium_Practice
{
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
        // int i; Interface can't contains fileds
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

    #region Interface signature
    //An interface can inherit from one or more base interfaces
    interface IDerivedFromCoreInterface : ICoreInterfaceBase1, ICoreInterfaceBase2
    {
        void SampleDerivedMethod(int a, int b);
        // int CoreInterfaceMethodA(int i);
    }
    #endregion

    #region Derived Class for Interface Class
    // If a class is Inheriting from an interface it is to implement the members of its parent(interface).
    // A Class can inherit from a class and interface at the same time
    public class ImplementationInterfaceClass : IDerivedFromCoreInterface
    {
        //Explicit interface member implementation
        public void SampleDerivedMethod(int a, int b)
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
        public ImplementationInterfaceClass(int x, int y)
        {
            var output = x * y;
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

    #endregion

    #region Abstract Class Defination/Signature
    /*
     * Abstract Class : Non abstract Methods(Methods with Method body) and also Asbstrat Methods (Methods without method body)
     * Use the abstract modifier in a class declaration to indicate that a class is intended only to be a BASE CLASS of other classes, not instantiated on its own
     * The abstract modifier can be used with classes, methods, properties, indexers, and events
     * Members marked as abstract must be implemented by non-abstract classes that derive from the abstract class.
     * Abstract method declaration should be using either abstrat keyword (without body) or virtual keyword (with body), and we must derived with OVERRIDE keyword.
     * Abstract Method must be overridden in non-abstract child class.
     * Default access modifier of a abstract class will be private
     * An abstract class can contain variable
     * Within the abstract class we can implement or define a property  
     * It can contain constructor and We can implement method (Non Abstract) and We can have static members
     * Will not support multiple inheritance
     * By default abstract class, abstract members are virtual due to that reason we don’t require to use virtual keyword 
     * Each class with atleast one abstract method must be abstract, it is possible to keep all non-abstract methods in abstract class
     * Abstact Class can have a Constructor, even though we can't instantiate the abstract class, if we create object of derived class then abstract base class constructor will also be called 
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
        public void ConcreteMethod()
        {
            Console.WriteLine("This is the Concrete method");
        }

        //Constructor
        public AbsractBaseClass()
        {
            var output = 5 + 5;
            Console.WriteLine(output);
        }
        //Parameter Constructor
        public AbsractBaseClass(int i, int j)
        {
            var output = i + j;
            Console.WriteLine(output);
        }
    }
    abstract class Motorcycle
    {
        // Anyone can call this.
        public void StartEngine() {/* Method statements here */ }

        // Only derived classes can call this.
        protected void AddGas(int gallons) { /* Method statements here */ }

        // Derived classes can override the base class implementation.
        public virtual int Drive(int miles, int speed) { /* Method statements here */ return 1; }

        // Derived classes must implement this.
        public abstract double GetTopSpeed();
    }

    /*
     * Abstract methods do not provide an implementation and force the derived classes to override the method
     * If Derived class Doesn't have Constructor, the instance execute the base class constructor
     */
    public class ImplementationOfAbstractClass : AbsractBaseClass
    {
        // Use OVERRIDE keyword to derive the Abstract method
        public override void MethodA()
        {
            int a = 5, b = 10;
            var rslt = a + b;
        }

        public void DerivedConcMethod()
        {
            ConcreteMethod();// This is the concrete method, we need not to use override keyword to access it.
        }

        public ImplementationOfAbstractClass()
        {
            var output = 5 + 5;
            Console.WriteLine(output);
        }

        //Parameter Constructor
        //public ImplementationOfAbstractClass(int i, int j)
        //{
        //    var output = i + j;
        //    Console.WriteLine(output);
        //}

        public override int MethodB(int i)
        {
            return i;
        }
        public override void AbstractMethod()
        {
            //Base class method can be called from within the derived class using the base keyword.
            base.AbstractMethod();

            Console.WriteLine("This is the Derived Method");
        }
    }
    #endregion

    #region Constructors and It's types
    /*
     * When a class or struct is created, its constructor is called.It can be used to set initial values for fields
     * If a class does not have a constructor, a parameterless constructor is automatically generated and default values are used to initialize the object fields. For example, an int is initialized to 0
     * It cannot have a return type (like void or int).Within a class, you can create only one static constructor
     * A static constructor cannot be a parameterized constructor, A class can have any number of constructors with diff parameters.                                                                                                                                                                                                                       
     * A static constructor is used to initialize static fields of the class and to write the code that needs to be executed only once.
     */
    public class Constructors
    {
        //Read only values are only able to modify inside the Constructor whereas the const value can't change across the project
        public readonly int i = 10;
        public const double pi = 3.14;

        //1.Default Constrcutor : If we didn't keep this constrctor, by default the system will create a default constructor and assign default values to their memebers
        public Constructors()
        {
            //All numeric fields in the class to zero and All string and object fields to null.
            i = 20;
            Console.WriteLine(i);
        }

        //public Constructors()
        //{
        // We can't have the same paramter type for constructor                                                      
        //}

        //2.Parametrized Constructor
        public Constructors(int i, double j)
        {
            //A constructor with at least one parameter is called a parameterized constructor. 
            //The advantage of a parameterized constructor is that you can initialize each instance of the class with a different value.
            var k = i * j;
            Console.WriteLine(k);
        }

        //3.Static Constuctor
        static Constructors()
        {
            //A static constructor does not take access modifiers or have parameters
            //A static constructor is called automatically to initialize the class before the first instance is created or any static members are referenced.
            //A typical use of static constructors is when the class is using a log file and the constructor is used to write entries to this file.
            Console.WriteLine("Static Constructor");
        }

        //4. Private Constructor
        private Constructors(int i)
        {
            //When a constructor is created with a private specifier, it is not possible for other classes to derive from this class, neither is it possible to create an instance of this class.
            //They are usually used in classes that contain static members only.
        }
        //5. Copy Constructor
        public Constructors(Constructors constr)
        {
            //The constructor which creates an object by copying variables from another object is called a copy constructor. 
            //The purpose of a copy constructor is to initialize a new instance to the values of an existing instance
            var reslt = constr.i;
        }
        //Constructors constr1=new  Constructors (constr2); 
    }
    #endregion

    #region Inheritance
    /*
     * Protected members are visible only in derived Class
     * Internal members are visible only in derived classes that are located in the same assembly as the base class. They are not visible in derived classes located in a different assembly from the base class.
     * Inheritance applies only to classes and interfaces. Other type categories (structs, delegates, and enums) do not support inheritance
     * Code reusabiltiy and providing more functionality
     * If a class has private constrcutor,it cannot be inherited
     * We can't access the private members of parent class
     */
    #region 1. Inner Class Inheritance
    public class InheritanceBaseClass
    {
        private int value = 10;

        public class InheritanceDerivedClass1 : InheritanceBaseClass
        {
            public int GetValue()
            {
                return this.value;
            }
        }
    }
    public class InheritanceDerivedClass2 : InheritanceBaseClass
    {
        //public int GetValue()
        //{
        //    return this.value; - Inaccessible due to its protection(Access modifier : private)
        //}

        private int i = 0;
        public int j = 1;
    }

    public class InheritanceDerivedClass3 : InheritanceDerivedClass2
    {
        public void method1()
        {
            Console.WriteLine(j);
            //Console.WriteLine(i); We can't access the private members of parent class
        }
    }

    #endregion

    #region 2. Abstract Class Inheritance
    public abstract class A
    {
        public abstract void Method1();

      //  public virtual abstract void Method1(); abstract method can't be marked as VIRTUAL
        public void ByDefaultAbstractMethodsAreVirtual()
        {
            //we need not 
        }
    }

    public class B : A 
    {
        public override  void Method1()
        {
            // Do something.
        }
    }
    #endregion

    #region 3. Multi level Inheritance
    public class Music
    {
        public virtual string play()
        {
            return "Play Music";
        }
    }
    public class Drum : Music
    {
        public override string play()
        {
            return "Play Drums";
        }
    }
    public class Piano : Music
    {
        public void CallAlreadyOverriddenMethod()
        {
            play();
        }
        public override string play()
        {
            return "Play Piano";
        }

        public virtual string sing()
        {
            return "sing song";
        }
    }
    public class Violin : Piano
    {
        public override string play()
        {
            return "Play Piano";
        }
        public override string sing()
        {
            return "sing song";
        }
    }
    public class PlayMusicService
    {
        private readonly Music _musicContext;
        public PlayMusicService(Music musicContext)
        {
            this._musicContext = musicContext;
        }

        public string PlayAlbum()
        {
            return _musicContext.play();
        }
    }
    #endregion

    #region 4.Using Base Keyword, call the Base class constructor
    public class InheritanceUsingBaseKeywordParentClass
    {
        private bool male;

        // This Constructor calls another constuctor
        public InheritanceUsingBaseKeywordParentClass() : this(true)
        {

        }
        // This is the Constructor that is inherited
        public InheritanceUsingBaseKeywordParentClass(bool male)
        {
            this.male = male;
        } 
        public bool Male
        {
            get{ return male; }
            set { this.male =value;}
        }
    }
    public class InheritanceUsingBaseKeywordDerivedClass :InheritanceUsingBaseKeywordParentClass
    {
        private int weight;
        //Using base keyword, we can call the constructor of base class
        public InheritanceUsingBaseKeywordDerivedClass(bool male, int weight): base(male)
        {
            this.weight = weight;
        }
        public InheritanceUsingBaseKeywordDerivedClass()
        {
            Console.WriteLine("Instance Constructor");
        }
        public int Weight
        {
            get { return weight ;}
            set { this.weight = value; }
        }
    }
    #endregion

    #endregion

    #region Polymorphism
    /*
     * Polymorphism is a Greek word, "one name many forms". In other words, one object has many forms or has one name with multiple functionalities.
     * It provides the ability to a class to have multiple implementations with the same name
     * 
     */

    #region Method Over loading/ Compile time polymorphism
    public class StaticOrCompileTimeOrMethodOverloading
    {
        //It is also known as Late Binding. 
        //Here, the method name and the method signature (number of parameters and parameter type must be the same and may have a different implementation)
        // It is also known as Compile Time Polymorphism, because the decision of which method is to be called is made at compile time
        //A fucntion will be over loading in two situation, 1. When datatype of arguments are changed,2.When No.of arguments are changed

        public void PolyMethodOverloading()
        {
            Console.WriteLine("Method Overloading same name, without parameter");
        }
        public void PolyMethodOverloading(int a, int b)
        {
            var output = a + b;
            Console.WriteLine("Method Overloading same name, without different parameter");
        }
        public void PolyMethodOverloading(int a, double b, bool c)
        {
            var output = a + b;
            Console.WriteLine("Method Overloading same name, without different parameters");
        }

        //Data type/return type should be same, diff datatype and same parameter won't work
        //public int PolyMethodOverloading(int a, float b, bool c)
        //{

        //    Console.WriteLine("Method Overloading same name, without different parameters");
        //    return a;
        //}
    }
    #endregion

    #region Method Over Riding/ Compile time polymorphism
    public class DynamicOrRunTimeOrMethodOverRiding
    {
        //It is also known as Early Binding. 
        //Here, the method name and the method signature (number of parameters and parameter type must be the same and may have a different implementation)
        // To override the methods, Use VIRTUAL keyword in base class method and OVERRIDE/NEW keyword in the derived class method.
        // if the base class methods are not called in the derived class, the base class methods(virtual fn) will be called.
        public virtual int PolyMethodOverridding()
        {
            Console.WriteLine("this is the base class method of Over riding");
            return 0;
        }
        public void OverRidingMethod()
        {
            Console.WriteLine("This function doesn't contains the virtual keyword");
        }
    }
    public class ImplementationOfRuntimeOrMethodOverRiding1 : DynamicOrRunTimeOrMethodOverRiding
    {
        public double Radius { get; set; }
        public void SampleMethod()
        {
            //we can call any of the base class method using BASE keyword in the Derived class methods
            base.PolyMethodOverridding();
            Console.WriteLine("Instance method from derived class");
        }

        // use Sealed class to prevent from further inheritance of the method
        public sealed override int PolyMethodOverridding()
        {
            Console.WriteLine("this is the derived class method of Over ridden from the Base class");
            return 10;
        }

        //We can use NEW keyword to use base class if we want to create/instantiate a object to a class which contains one/more virtual functions
        public new void OverRidingMethod()
        {
            Console.WriteLine("this is the derived class method of Over ridden from the Base class without using override keyword");
        }
    }
    public class ImplementationOfRuntimeOrMethodOverRiding2 : ImplementationOfRuntimeOrMethodOverRiding1
    {
        //It is impossible to inherit the Sealed methods in the base class
        //public override int PolyMethodOverridding()
        //{
        //    return 20;
        //}
    }
    #endregion
    #endregion

    #region Abstraction
    /* Abstraction means Working with something we know how to use, without knowing, how it works internally.
     * Defination:
     * Abstraction is "the process of identifying common patterns that have systematic variations; 
     * an abstraction represents the common pattern and provides a means for specifying which variation to use"
     * 
     * Abstraction can be achieved using abstract classes in C#.
     * C# allows you to create abstract classes that are used to provide a partial class implementation of an interface.
     * Implementation is completed when a derived class inherits from it.
     * Abstract classes contain abstract methods, which are implemented by the derived class. The derived classes have more specialized functionality.
     * Advantages:
     * It reduces the complexity of viewing the things and Avoids code duplication and increases reusability.
     * Helps to increase security of an application or program as only important details are provided to the user.
     */
    abstract class AbsractionBaseClass
    {
        public abstract int area();
    }

    class AbsractionDerivedClass : AbsractionBaseClass
    {
        private int length;
        private int width;

        public AbsractionDerivedClass(int a = 0, int b = 0)
        {
            length = a;
            width = b;
        }
        public override int area()
        {
            Console.WriteLine("Derived class area :");
            return (width * length);
        }
    }
    #endregion

    #region Encapsultion
    /*Encapsulation means that a group of related properties, methods, and other members are treated as a single unit or object
     *The class is the real-time example for encapsulation because it will combine various types of data members and member functions into a single unit.
     * If we define class fields with properties, then the encapsulated class won’t allow us to access the fields directly instead, 
     * we need to use getter and setter functions to read or write data based on our requirements.
     * Encapsulation is implemented by using access specifiers. An access specifier defines the scope and visibility of a class member
     */
    class EncapsulationBaseClasss
    {
        private string location;
        private string name;

        public string Location { get { return location; } set { location = value; } }
        public string Name { get { return name; } set { name = value; } }
     
    }
    #endregion

}
