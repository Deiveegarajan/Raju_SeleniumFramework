using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace TestBase2
{
    public interface IDrivers : IWebDriver, IFindsById, IFindsByLinkText, IFindsByName, IFindsByXPath
    {
        void RunTest();
       // string Make => get;
    }

    public interface IElements : IWebElement
    {
        //Place holder
    }
}
