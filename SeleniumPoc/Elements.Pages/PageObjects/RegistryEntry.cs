namespace Elements.Pages.PageObjects
{
    #region Import NameSpaces
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using System.Text;
    using OpenQA.Selenium;
    using Elements.Core.Helper;
    using Elements.Pages.Constants;
    using System.Threading;
    using Elements.Pages.Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Elements.Core.Utility.CommonUtils;
    using OpenQA.Selenium.Interactions;
    using AutoIt;
    using System.Windows.Forms;
    #endregion Import NameSpaces

    public class RegistryEntry
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
        public IWebDriver WebDriver = GlobalVariables.WebDriver;
       
        #endregion Declaration

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Google Home screen class.
        /// </summary>
        /// <param name="driver">Parameter of type OpenQA.Selenium.IWebDriver for driver.</param>
        public RegistryEntry(IWebDriver driver)
        {
            this.webDriver = driver;
        }
        #endregion Constructors

        #region ElementLocators
        private string RegistryButtonLocator => "//div[@class='btn-group pull-left']//button[@type='button']";
        private string RegistryEntryTitle => "RegistryEntryTitle";
        private string RegistryEntryType => "//span[@class='text-capitalize'][contains(text(),'Utgående post/Outbound')]";
        private string AttachDocument => "//button[contains(text(),'Document template')]";
        private string Attachment => "//span[@data-bind=\"t: 'Attach'\"]";
        private string Receiver => "//span[@class='select2-selection select2-selection--multiple']";
        private string Username => "//input[@id='username']";
        private string Password => "//input[@id='password']";
        private string LoginButton => "//button[@class='btn btn-primary']";
        private string SelectHighlighted => "//span[@class='select2-container select2-container--default select2-container--open']//li[1]";
        private string submit => "//input[@value='Select']";
        private string SaveAndEditDocument => "//span[@data-bind=\"t: 'SaveAndEditDocument', if: $root.isPendingDocumentMerge\"]";
        #endregion

        #region Methods

        /// <summary>
        /// Click Registry entry link and click the specified registry entry type
        /// </summary>
        /// <param name="registryType">Registry Type to select/click</param>
        public void CreateRegistryEntry(IWebDriver webDriver, string entryType, string attachmentType, string DocumentTemplateType, string DocumentSubType)
        {
            // Click on New Registry Entry
            SeleniumHelper.ClickOnElementByXpath(webDriver, RegistryButtonLocator);
            CommonUtils.PlayWait();
            // Click on Registry Entry type
            SeleniumHelper.ClickOnElementByXpath(webDriver, "//span[@class='text-capitalize'][contains(text(),'" + entryType + "')]");
            CommonUtils.PlayWait();
            // Enter Registry Entry Title
            SeleniumHelper.EnterTextById(webDriver, RegistryEntryTitle, "Registry Entry Title");
            CommonUtils.PlayWait();
            // Enter Registry Enter Receiver
            SeleniumHelper.EnterTextByXpath(webDriver, Receiver, "AA");
            CommonUtils.PlayWait();
            // Select Anda Apotek
            SeleniumHelper.ClickOnElementByXpath(webDriver, SelectHighlighted);
            CommonUtils.PlayWait();
            SeleniumHelper.ClickOnElementByXpath(webDriver, Attachment);
            CommonUtils.PlayWait();
            // Select Attachment type from Attach Dropdown
            SeleniumHelper.ClickOnElementByXpath(webDriver, "//button[contains(text(),'" + attachmentType + "')]");
            CommonUtils.PlayWait();
            // Select Document Template Type
            SeleniumHelper.ClickOnElementByXpath(webDriver, "//span[contains(text(),'" + DocumentTemplateType + "')]");
            CommonUtils.PlayWait();
            // Select Document Type
            SeleniumHelper.ClickOnElementByXpath(webDriver, "//span[contains(text(),'" + DocumentSubType + "')]");
            CommonUtils.PlayWait();
            // Click Sebmit button
            SeleniumHelper.ClickOnElementByXpath(webDriver, submit);
            CommonUtils.PlayWait();
            
            // Click Save and Edit Document
            SeleniumHelper.ClickOnElementByXpath(webDriver, SaveAndEditDocument);

            #region AutoItX for OpenElementsDesktopClient
            // Handling Alert pop up for OpenElementsDesktopClient
            CommonUtils.PlayWait(20000);
            //This code snippet will fix your specific issue
            AutoItX.WinWait("Untitled - Google Chrome", "", 2);
            AutoItX.WinActivate("Untitled - Google Chrome"); // Activate so that next set of actions happens on this window
            AutoItX.Send("{LEFT}");
            AutoItX.Send("{Enter}");
            #endregion

            // IWebElement element = webDriver.FindElement(By.XPath(SaveAndEditDocument));
            // Login window
            CommonUtils.PlayWait(18000);
            #region Manual code for Validating LoginWebView
            //if (AutoItX.WinActive("LoginWebView").ToString().Equals('1'))
            //{
            //    AutoItX.WinWait("LoginWebView", "", 2);
            //    AutoItX.WinActivate("LoginWebView");
            //    CommonUtils.PlayWait(4000);
            //    AutoItX.Send("guilt");
            //    CommonUtils.PlayWait(5000);
            //    AutoItX.Send("{TAB}");
            //    // Usually checks a checkbox (if it's a "real" checkbox.)
            //    AutoItX.Send("{+}");
            //    CommonUtils.PlayWait(5000);
            //    AutoItX.Send("{TAB}");
            //    AutoItX.Send("{ENTER}");
            //}
            #endregion
            //  System.Runtime.exec("");
            Process.Start(@"C:\Selenium POC\Elements.Selenium\AutoItX Scripts\LoginDocumentFunctionality.exe");
            // Edit and Save Document
            Thread.Sleep(20000);
            AutoItX.WinWait(RegistryEntryTitle + ".docx - Word", "", 10);
            //Set input focus to the edit control of Upload window using the handle returned by WinWait
            AutoItX.ControlClick(RegistryEntryTitle + ".docx - Word", "", "_WwG1");
            AutoItX.WinActivate(RegistryEntryTitle + ".docx - Word");
           // AutoItX.WinSetState(RegistryEntryTitle, @SW_MAXIMIZE);
            AutoItX.Send("{ENTER}");
            AutoItX.Send("Edit document");
            AutoItX.Send("^s");
            CommonUtils.PlayWait(3000);
            //AutoItX.WinClose(RegistryEntryTitle + ".docx - Word");
            AutoItX.Send("!+{F4}", 0);

            #region Assert checkin
            // Add Script for Checkin Msg
            // Process.Start(@"C:\saurabh\Project\AutoItX Scripts\CheckinScript.exe");
            CommonUtils.PlayWait(2000);
            //   AutoItX.WinActivate("Mark as complete");
            AutoItX.ControlClick("Mark as complete", "", "TextBlock");
            AutoItX.MouseClick("left", 1);
            AutoItX.MouseClick("left", 1);
            #endregion
            CommonUtils.PlayWait(25000);

            #region Logout from Application
            LogoutPage LogoutPageObject = new LogoutPage(webDriver);
            LogoutPageObject.LogoutApplication();
            #endregion
            Thread.Sleep(CommonUtils.WaitTime);

        }

        #endregion Methods

    }
}
