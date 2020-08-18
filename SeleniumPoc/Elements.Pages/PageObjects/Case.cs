namespace Elements.Pages.PageObjects
{
    #region Import NameSpaces
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using Elements.Core.Helper;
    using System.Configuration;
    using Elements.Pages.Constants;
    using Elements.Core.Utility.CommonUtils;
    using System.Threading;
    using SeleniumExtras.WaitHelpers;
    using Elements.Pages.Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Support.UI;
    #endregion Import NameSpaces
    public class Case
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
        public Case(IWebDriver driver)
        {
            this.webDriver = driver;
           // string url = ConfigurationManager.AppSettings.Get("LoginUrl");
            //this.webDriver.Navigate().GoToUrl(url);
        }

        #endregion Constructors

        #region ElementLocators
        private string NewCaseButton => "//button[@title='New case']";
        private string CaseTitleID => "caseTitle";
        private string saveCase => "//span[@data-bind=\"t: 'SkipSaveBtnLbl'\"]";
        private string ExpandMenuLocator => "";
        private string CollapseMenuLocator => "//button[@class='btn btn-md btn-link pull-left btn-menu-toggle']";


        #endregion

        #region Methods

        public void ExpandMenu()
        {
            CommonUtils.PlayWait();
            var element = MenuControlCollapsedElement();
            element.DrawHighlight();
            element.Click();
        }

        public IWebElement MenuControlCollapsedElement()
        {
            IWebElement collapseElement = SeleniumHelper.FindElementByXpath(webDriver, CollapseMenuLocator);
            return collapseElement;
        }

        public bool IsMenuControlCollapsed()
        {
            var element = MenuControlCollapsedElement();
            return (element != null) ? SeleniumHelper.VerifyIsElementPresent(element) : false;
        }

        /// <summary>
        /// Create Case
        /// </summary>
        /// <param name="searchContent">Parameter of type Syste.String for searchContent</param>
        /// <param name="moduleName">Module Name to login</param>
        /// <returns>Parameter of type System.Boolean for True or False</returns>
        public void CreateCase()
        {
            //CommonUtils.PlayWait(CommonUtils.DashboardWaitTime);

            //if (CommonUtils.IsMenuControlCollapsed())
            //    CommonUtils.ExpandMenu();

            #region Click New Case button, Enter title and click Save

            // Click New Case Button
            //Wait for dashborad load
            CommonUtils.PlayWait(30000);
            SeleniumHelper.ClickOnElementByXpath(webDriver, NewCaseButton);

            // Enter Title 
            CommonUtils.PlayWait();
            SeleniumHelper.EnterTextById(webDriver, CaseTitleID, "Create new case");

            // Click Save case
            SeleniumHelper.ClickOnElementByXpath(webDriver, saveCase);

            #endregion
        }
        #endregion Methods

    }
}
