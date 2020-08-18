namespace Elements.Pages.PageObjects
{
    #region Import NameSpaces
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium;
    using Elements.Core.Helper;
    using System.Configuration;
    using Elements.Pages.Constants;
    using System.Threading;
    using Elements.Pages.Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Elements.Core.Utility.CommonUtils;
    #endregion Import NameSpaces

    public class LoginPage
    {
        #region Declaration
        /// <summary>
        /// Public Constant variable to hold the value of webDriver.
        /// </summary>
        private readonly IWebDriver webDriver;
        /// <summary>
        /// Private Constant variable to hold the value of webElement.
        /// </summary>
        public IWebElement webElement;
        /// <summary>
        ///  Public Constant variable to hold the collection of webelements.
        /// </summary>
        public IWebElement Welements = null;

        public string fileDirectoryPath = Constants.resultsPath;
        /// <summary>
        /// Public variables which holds xpath values
        /// </summary>
        //public string googleHomeScreenSearchBoxXpath = AutomationBase.ReadNodeContentFromXml("GoogleHomeScreen", "GoogleHomeScreen_TxtSearchboxXpath");
        //public string googleHomeScreenSearchButtonXpath = AutomationBase.ReadNodeContentFromXml("GoogleHomeScreen", "GoogleHomeScreen_BtnSeachXpath");
        #endregion Declaration

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Google Home screen class.
        /// </summary>
        /// <param name="driver">Parameter of type OpenQA.Selenium.IWebDriver for driver.</param>
        public LoginPage(IWebDriver driver)
        {
            this.webDriver = driver;
            string url = ConfigurationManager.AppSettings.Get("LoginUrl");
            this.webDriver.Navigate().GoToUrl(url);
        }
        #endregion Constructors

        #region ElementLocators
        private string ChangeLanguage => "//select[@class='select-container form-control']";
        private string ChangeDatabase => "select-database";
        private string LoginAsDifferentUser => "//button[contains(text(),'Login as a different user')]";
        private string Username => "//input[@id='username']";
        private string Password => "//input[@id='password']";
        private string LoginButton => "//button[@class='btn btn-primary']";
        
        #endregion

        #region Methods

        /// <summary>
        /// Login to Application
        /// </summary>
        /// <param name="searchContent">Parameter of type Syste.String for searchContent</param>
        /// <param name="moduleName">Module Name to login</param>
        /// <returns>Parameter of type System.Boolean for True or False</returns>
        public void LoginToApplication(string moduleName = "")
        {
            #region Code for DB Select, Language Select and Login added by Saurabh

            // Select Database 
            SeleniumHelper.SelectListValueById(webDriver, "select-database", ConfigurationManager.AppSettings.Get("Database"));

            // Set Language to English
            SeleniumHelper.SelectListValueByXpathAndSelectByText(webDriver, "//select[@class='select-container form-control']", "English");

            // Click Login as a different User
            Thread.Sleep(4000);
            SeleniumHelper.ClickOnElementByXpath(webDriver, "//button[contains(text(),'Login as a different user')]");

            // Enter Username and Password

            // Switch window
            webDriver.SwitchTo().Window(webDriver.WindowHandles.Last());
            Thread.Sleep(4000);
            SeleniumHelper.EnterTextByXpath(webDriver, "//input[@id='username']", ConfigurationManager.AppSettings.Get("Username"));
            Thread.Sleep(1000);
            SeleniumHelper.EnterTextByXpath(webDriver, "//input[@id='password']", ConfigurationManager.AppSettings.Get("Password"));
            Thread.Sleep(2000);

            // Click checkbox
            SeleniumHelper.ClickOnChkboxByName(webDriver, "rememberMe", "ON");

            // Click Login button
            SeleniumHelper.ClickOnElementByXpath(webDriver, "//button[@class='btn btn-primary']");
            Thread.Sleep(2000);

            webDriver.SwitchTo().Window(webDriver.WindowHandles.Last());
            SelectModule(webDriver, "Record management", "Class");


            #endregion

            //CommonUtils.PlayWait(CommonUtils.DashboardWaitTime);

            //if (CommonUtils.IsMenuControlCollapsed())
            //    CommonUtils.ExpandMenu();
        }
        #endregion Methods

        public static void SelectModule(IWebDriver driver, string moduleName, string elementType)
        {
            driver.FindElement(By.XPath("//span[@title=" + "'" + moduleName + "'" + "]")).Click();
        }
    }
}
