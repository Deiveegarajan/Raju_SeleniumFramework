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

    class LogoutPage
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
        public LogoutPage(IWebDriver driver)
        {
            this.webDriver = driver;
        }
        #endregion Constructors

        #region ElementLocators
        private string ChangeLanguage => "//select[@class='select-container form-control']";
        private string UserCaret => "//div[@class='user-caret']";
        private string logout => "//body[@class='bs responsive']/div[@id='applicationHost']/div[@class='outershell rm-outershell']/div[@id='colorSwitchScope']/div[@class='compose-shell rm-shell']/div[@class='mode-scope']/div[@class='theme-wrap']/div[@class='container bs-container']/nav[@class='menu-col toggable-menu pull-left']/div[@class='menu-content dashboard']/div[@class='usermenu pull-left']/div[@class='dropdown react-dropdown dropdown show']/div[@role='presentation']/div[@class='dropdown-menu user-dropdown-menu dropdown-menu show']/button[3]";
        #endregion

        #region Methods

        /// <summary>
        /// Login to Application
        /// </summary>
        /// <param name="searchContent">Parameter of type Syste.String for searchContent</param>
        /// <param name="moduleName">Module Name to login</param>
        /// <returns>Parameter of type System.Boolean for True or False</returns>
        public void LogoutApplication()
        {
            #region Expand left menu and click logout added by Saurabh

            // Expand Laft menu
            if (CommonUtils.IsMenuControlCollapsed())
                CommonUtils.ExpandMenu();
            CommonUtils.PlayWait(5000);
            // Expand User Caret to click Logout
            SeleniumHelper.ClickOnElementByXpath(webDriver, UserCaret);
            CommonUtils.PlayWait(5000);
            // Click Logout button
            SeleniumHelper.ClickOnElementByXpath(webDriver, logout);
            CommonUtils.PlayWait(5000);
            webDriver.Manage().Cookies.DeleteAllCookies();
            CommonUtils.PlayWait(5000);
            webDriver.Quit();
            #endregion

        }
        #endregion Methods

        public static void SelectModule(IWebDriver driver, string moduleName, string elementType)
        {
            driver.FindElement(By.XPath("//span[@title=" + "'" + moduleName + "'" + "]")).Click();
        }
    }
}
