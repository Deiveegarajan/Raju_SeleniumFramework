namespace Elements.Core.Helper
{
    #region Import Namespaces
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using OpenQA.Selenium;
    using System.Collections.ObjectModel;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using System.Threading;
    using OpenQA.Selenium.Remote;
    using System.Reactive.Linq;
    using Elements.Core.BaseClass;
    using Elements.Core.Utility.CommonUtils;
    #endregion

    public static class SeleniumHelper
    {
        #region Declaration
        /// <summary>
        /// Declaring the global variables
        /// </summary>
        public static string text = string.Empty;
        public static int celno;
        public static IWebElement childElement = null;
        public static IList<IWebElement> folders = null;
        public static IList<IWebElement> childElements = null;
        public static int pageIdNumber;
        public static int pgeid = 1;
        public static string resultsDateFormat = "Mddyyyyhmms";
        #endregion       

        #region EnterTextByXpath
        /// <summary>
        /// Public method which includes logic related to AssignTextToElementThroughXPath.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="xPath">Parameter of type System.String for xPath.</param>
        /// <param name="text">Parameter of type System.String for text.</param>
        /// <returns>True or false</returns>
        public static bool EnterTextByXpath(this IWebDriver webDriver, string xPath, string text)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.XPath(xPath));
                if (element != null)
                {
                    Thread.Sleep(2000);
                    element.SendKeys(text);
                    Thread.Sleep(2000);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                e.GetType();
                return false;
            }

        }
        #endregion

        #region EnterTextByName
        /// <summary>
        /// Public method which includes logic related to AssignTextToElementThroughName.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="name">Parameter of type System.String for name.</param>
        /// <param name="text">Parameter of type System.String for text.</param>
        /// <returns>True or false</returns>
        public static bool EnterTextByName(this IWebDriver webDriver, string name, string text)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.Name(name));
                if (element != null)
                {
                    element.SendKeys(text);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                e.GetType();
                return false;
            }

        }
        #endregion

        #region EnterText
        /// <summary>
        /// Public method which includes logic related to Assign text to an element
        /// </summary>
        /// <param name="webElement">Parameter of type OpenQA.Selenium.IWebElement for webElement.</param>
        /// <param name="text">Parameter of type System.String for text.</param>
        /// <returns>True or false</returns>
        public static bool EnterText(this IWebElement webElement, string text)
        {
            try
            {
                if (webElement != null)
                {
                    webElement.SendKeys(text);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                e.GetType();
                return false;
            }
        }
        #endregion

        #region EnterTextById
        /// <summary>
        /// Public method which includes logic related to AssignTextToElementThroughId.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="Id">Parameter of type System.String for Id.</param>
        /// <param name="text">Parameter of type System.String for text.</param>
        /// <returns>True or false</returns>
        public static bool EnterTextById(this IWebDriver webDriver, string id, string text)
        {

            try
            {
                IWebElement element = webDriver.FindElement(By.Id(id));
                if (element != null)
                {
                    element.SendKeys(text);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                e.GetType();
                return false;
            }
        }
        #endregion

        #region SelectListValueById
        /// <summary>
        /// Public method which includes logic related to Select the value from List box element through Id.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="Id">Parameter of type System.String for Id.</param>
        /// <param name="value">Parameter of type System.String for value.</param>
        /// <returns>True or false</returns>
        public static bool SelectListValueById(this IWebDriver webDriver, string id, string value)
        {

            try
            {
                IWebElement element = webDriver.FindElement(By.Id(id));
                if (element != null)
                {
                    element.SendKeys(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                e.GetType();
                return false;
            }
        }
        #endregion SelectListValueById

        #region SelectListValueFromElement
        /// <summary>
        /// Public method which includes logic related to Select the value from List box element through Id.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="Id">Parameter of type System.String for Id.</param>
        /// <param name="value">Parameter of type System.String for value.</param>
        /// <returns>True or false</returns>
        public static bool SelectListValueFromElement(this IWebElement element, string value)
        {

            try
            {

                if (element != null)
                {
                    element.SendKeys(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                e.GetType();
                return false;
            }
        }
        #endregion SelectListValueFromElement

        #region SelectListValueByXpath
        /// <summary>
        /// Public method which includes logic related to Select the value from List box element through Xpath.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="xPath">Parameter of type System.String for Xpath.</param>
        /// <param name="value">Parameter of type System.String for value.</param>
        /// <returns>True or false</returns>
        public static bool SelectListValueByXpath(this IWebDriver webDriver, string xPath, string value)
        {

            try
            {
                IWebElement element = webDriver.FindElement(By.XPath(xPath));
                if (element != null)
                {
                    element.SendKeys(Keys.ArrowDown);
                    SelectElement elements = new SelectElement(element);
                    elements.SelectByValue(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                e.GetType();
                return false;
            }
        }
        #endregion SelectListValueByXpath

        #region SelectListValueByXpathAndSelectByText
        /// <summary>
        /// Public method which includes logic related to Select the value from List box element through Xpath.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="xPath">Parameter of type System.String for Xpath.</param>
        /// <param name="text">Parameter of type System.String for text.</param>
        /// <returns>True or false</returns>
        public static bool SelectListValueByXpathAndSelectByText(this IWebDriver webDriver, string xPath, string value)
        {

            try
            {
                IWebElement element = webDriver.FindElement(By.XPath(xPath));
                if (element != null)
                {
                    element.SendKeys(Keys.ArrowDown);
                    SelectElement elements = new SelectElement(element);
                    elements.SelectByText(value); // Changed from SelectByValue to SelectByText
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                e.GetType();
                return false;
            }
        }
        #endregion SelectListValueByXpathAndSelectByText

        #region SelectListValueByName
        /// <summary>
        /// Public method which includes logic related to Select the value from List box element through Name.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="name">Parameter of type System.String for name.</param>
        /// <param name="value">Parameter of type System.String for value.</param>
        /// <returns>True or false</returns>
        public static bool SelectListValueByName(this IWebDriver webDriver, string name, string value)
        {

            try
            {
                IWebElement element = webDriver.FindElement(By.Name(name));
                if (element != null)
                {
                    element.SendKeys(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                e.GetType();
                return false;
            }
        }
        #endregion SelectListValueByName

        #region SelectListValue
        /// <summary>
        /// Public method which includes logic related to select the value from listbox
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver</param>
        /// <param name="listBoxElement">Parameter of type System.String for listBoxElement </param>
        /// <param name="DropdownXpath">Parameter of type System.String for DropdownXpath</param>
        /// <param name="OptionTagName">Parameter of type System.String for OptionTagName</param>
        /// <param name="value">Parameter of type System.String for value</param>
        /// <returns>Parameter of type System.Boolean for true or false</returns>
        public static bool SelectListValue(IWebDriver webDriver, IWebElement listBoxElement, string DropdownXpath, string OptionTagName, string value)
        {

            SeleniumHelper.MouseHoverClickOnElement(webDriver, listBoxElement);
            IWebElement popup = webDriver.FindElement(By.XPath(DropdownXpath));
            IList<IWebElement> optionElements = popup.FindElements(By.TagName(OptionTagName));
            for (int index = 0; index <= optionElements.Count - 1; index++)
            {
                if (optionElements[index].Text.Equals(value))
                {
                    SeleniumHelper.ClickElement(optionElements[index]);
                    return true;
                }

            }
            return false;
        }
        #endregion 

        #region SelectListBoxValues
        /// <summary>
        /// Public method which includes logic related to select the values from listbox
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver</param>
        /// <param name="listBoxElement">Parameter of type System.String for listBoxElement </param>
        /// <param name="DropdownXpath">Parameter of type System.String for DropdownXpath</param>
        /// <param name="OptionTagName">Parameter of type System.String for OptionTagName</param>
        /// <param name="values">Parameter of type System.String[] for values</param>
        /// <returns>Parameter of type System.string for null or failed item lists</returns>
        public static string SelectListBoxValues(IWebDriver webDriver, IWebElement listBoxElement, string DropdownXpath, string OptionTagName, string[] expectedValues)
        {

            string failedItems = null;
            for (int dropdownIndex = 0; dropdownIndex <= expectedValues.Length - 1; dropdownIndex++)
            {
                //We need this as each time it calls ClickElement, OptionElements will be empty
                SeleniumHelper.MouseHoverClickOnElement(webDriver, listBoxElement);
                IWebElement popup = webDriver.FindElement(By.XPath(DropdownXpath));
                IList<IWebElement> optionElements = popup.FindElements(By.TagName(OptionTagName));
                for (int index = 0; index <= optionElements.Count - 1; index++)
                {
                    if (optionElements[index].Text == expectedValues[dropdownIndex])
                    {
                        if (SeleniumHelper.ClickElement(optionElements[index]) == false)
                        {
                            failedItems = failedItems + "," + optionElements[index];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return failedItems;
        }
        #endregion 

        #region SelectTListValueFromFrame
        /// <summary>
        /// Publuic method which includes logic related to Select the value from list box in frames
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDriver for webDriver</param>
        /// <param name="listBoxElement">Parameter of type System.String for listBoxElement</param>
        /// <param name="xPath">Parameter of type System.String for xPath</param>
        /// <param name="tagName">Parameter of type System.String for tagName </param>
        /// <param name="listValue">Parameter of type System.String for listValue</param>
        /// <returns>Parameter of type Sytem.Boolean for True or False</returns>     
        public static bool SelectTListValueFromFrame(IWebDriver webDriver, IWebElement listBoxElement, string xPath, string tagName, string listValue)
        {
            IWebElement requiredPopup = null;
            Thread.Sleep(1000);
            SeleniumHelper.MouseHoverClickOnElement(webDriver, listBoxElement);
            IList<IWebElement> popups = webDriver.FindElements(By.XPath(xPath));
            for (int index = 0; index <= popups.Count; index++)
            {
                if (popups[index].Text.Contains(listValue))
                {
                    requiredPopup = popups[index];
                    break;
                }
            }

            IList<IWebElement> optionElements = requiredPopup.FindElements(By.TagName(tagName));
            for (int index = 0; index <= optionElements.Count - 1; index++)
            {
                if (optionElements[index].Text == listValue)
                {
                    SeleniumHelper.MouseHoverClickOnElement(webDriver, optionElements[index]);
                    return true;
                }

            }
            return false;
        }
        #endregion 

        #region ClickOnElementByXpath
        /// <summary>
        /// Public method which includes logic related to Clicking Element through Xpath.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="xPath">Parameter of type System.String for xPath checking.</param>
        /// <returns>True or false</returns>
        public static bool ClickOnElementByXpath(this IWebDriver webDriver, string xPath)
        {

            try
            {
                IWebElement element = webDriver.FindElement(By.XPath(xPath));
                if (element != null)
                {
                    if (Initialize.browserType == "IE")
                    {
                        element.SendKeys(Keys.Enter);
                        return true;
                    }
                    else
                    {
                        element.Click();
                        return true;
                    }

                }
                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }
            }

            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }
        }

            #endregion

            #region ClickOnElementById
            /// <summary>
            /// Public method which includes logic related to Clicking Element through Id.
            /// </summary>
            /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
            /// <param name="Id">Parameter of type System.String for Id.</param>
            /// <returns>True or false</returns>
            public static bool ClickOnElementById(this IWebDriver webDriver, string id)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.Id(id));
                if (element != null)
                {
                    if (Initialize.browserType == "IE")
                    {
                        element.SendKeys(Keys.Enter);
                        return true;
                    }
                    else
                    {
                        element.Click();
                        return true;
                    }

                }
                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }
            }

            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }
        }
        #endregion

        #region ClickonElementByName
        /// <summary>
        /// Public method which includes logic related to Clicking Element through Name.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="name">Parameter of type System.String for name.</param>
        /// <returns>True or false</returns>
        public static bool ClickOnElementByName(this IWebDriver webDriver, string name)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.Name(name));
                if (element != null)
                {
                    if (Initialize.browserType == "IE")
                    {
                        element.SendKeys(Keys.Enter);
                        return true;
                    }
                    else
                    {
                        element.Click();
                        return true;
                    }

                }
                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }
            }

            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }

        }
        #endregion

        #region ClickOnElementByLinkText
        /// <summary>
        /// Public method which includes logic related to Clicking Element through linktext.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="linktext">Parameter of type System.String for linktext.</param>
        /// <returns>True or false</returns>
        public static bool ClickOnElementByLinkText(this IWebDriver webDriver, string linktext)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.LinkText(linktext));
                if (element != null)
                {
                    if (Initialize.browserType == "IE")
                    {
                        element.SendKeys(Keys.Enter);
                        return true;
                    }
                    else
                    {
                        element.Click();
                        return true;
                    }

                }
                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }
            }

            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }

        }
        #endregion

        #region ClickOnChkboxByName
        /// <summary>
        /// Public method which includes logic related to Clicking Element through Name.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="name">Parameter of type System.String for name.</param>
        /// /// <param name="value">Parameter of type System.String for value.</param>
        /// <returns>True or false</returns>
        public static bool ClickOnChkboxByName(this IWebDriver webDriver, string name, string value)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.Name(name));

                if (element != null)
                {
                    if (value.ToUpper() == "ON")
                    {
                        if (Initialize.browserType.ToUpper() == "IE")
                        {
                            if (element.Selected == false)
                            {
                                element.SendKeys(Keys.Space);
                                return true;
                            }

                        }
                        else
                        {
                            if (element.Selected == false)
                            {
                                element.Click();
                                return true;
                            }

                        }

                    }
                    else if (value.ToUpper() == "OFF")
                    {
                        if (Initialize.browserType.ToUpper() == "IE")
                        {
                            if (element.Selected == true)
                            {
                                element.SendKeys(Keys.Space);

                            }

                        }
                        else
                        {
                            if (element.Selected == true)
                            {
                                element.Click();

                            }

                        }

                    }
                }

                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }

            }
            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }

            return true;

        }
        #endregion

        #region ClickOnChkbox
        /// <summary>
        /// Public method which includes logic related to Clicking Element through Name.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="name">Parameter of type System.String for name.</param>
        /// /// <param name="value">Parameter of type System.String for value.</param>
        /// <returns>True or false</returns>
        public static bool ClickOnChkbox(IWebElement element, string value)
        {
            try
            {
                //IWebElement element = webDriver.FindElement(By.Name(name));

                if (element != null)
                {
                    if (value == "ON")
                    {
                        if (Initialize.browserType == "IE")
                        {
                            if (element.Selected == false)
                            {
                                element.SendKeys(Keys.Space);
                                return true;
                            }

                        }
                        else
                        {
                            if (element.Selected == false)
                            {
                                element.Click();
                                return true;
                            }

                        }

                    }
                    else if (value == "OFF")
                    {
                        if (Initialize.browserType == "IE")
                        {
                            if (element.Selected == true)
                            {
                                element.SendKeys(Keys.Space);

                            }

                        }
                        else
                        {
                            if (element.Selected == true)
                            {
                                element.Click();

                            }

                        }

                    }
                }

                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }

            }
            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }

            return true;

        }
        #endregion

        #region ClickOnRadioBtn
        /// <summary>
        /// Public method which includes logic related to Clicking on Radio button
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="element">Parameter of type OpenQA.Selenium.IWebElement for element.</param>
        /// <returns>Trur or False</returns>
        public static bool ClickOnRadioBtn(this IWebDriver webDriver, IWebElement element)
        {
            try
            {
                if (element != null)
                {

                    if (Initialize.browserType == "IE")
                    {
                        if (element.Selected == false)
                        {
                            element.SendKeys(Keys.Space);
                            return true;
                        }

                    }
                    else
                    {
                        if (element.Selected == false)
                        {
                            element.Click();
                            return true;
                        }

                    }

                }
                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }
            }
            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }

            return true;

        }
        #endregion

        #region ClickElement
        /// <summary>
        /// Public method which includes logic related to Clicking on Element 
        /// </summary>
        /// <param name="webElement">Parameter of type OpenQA.Selenium.IWebElement for webElement.</param>
        /// <returns>True or false</returns>
        public static bool ClickElement(this IWebElement webElement)
        {
            try
            {
                if (webElement != null)
                {
                    webElement.Click();
                    return true;
                }
                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }
            }

            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }

        }
        #endregion

        #region SubmitButtonByXpath
        /// <summary>
        /// Public method which includes logic related to clicking on button through Xpath
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="xPath">Parameter of type System.String for xpath.</param>
        /// <returns>True or false</returns>
        public static bool SubmitButtonByXpath(this IWebDriver webDriver, string xPath)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.XPath(xPath));
                if (element != null)
                {
                    element.Submit();
                    return true;
                }
                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }
            }

            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }
        }
        #endregion

        #region VerifyElementByXpath
        /// <summary>
        /// Public method which includes logic related to Verifying element through xPath.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="xPath">Parameter of type System.String for xPath.</param>
        /// <returns>True or false</returns>
        public static bool VerifyElementByXpath(this IWebDriver webDriver, string xPath)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.XPath(xPath));
                if (element != null)
                {
                    return true;
                }

                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }
            }
            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }
        }
        #endregion

        #region VerifyElementByClass
        /// <summary>
        /// Public method which includes logic related to Verify element through class.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="Classname">Parameter of type System.String for Classname.</param>
        /// <returns>True or false</returns>
        public static bool VerifyElementByClass(this IWebDriver webDriver, string className)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.ClassName(className));
                if (element != null)
                {
                    return true;
                }

                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }
            }
            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }
        }
        #endregion

        #region VerifyElementByName
        /// <summary>
        /// Public method which includes logic related to Verify element through Name.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="name">Parameter of type System.String for name.</param> 
        /// <returns>True or false</returns>
        public static bool VerifyElementByName(this IWebDriver webDriver, string name)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.Name(name));
                if (element != null)
                {
                    return true;
                }

                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }
            }
            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }
        }
        #endregion

        #region VerifyElementById
        /// <summary>
        /// Public method which includes logic related to Verify element through Id.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="Id">Parameter of type System.String for Id.</param>
        /// <returns>True or false</returns>
        public static bool VerifyElementById(this IWebDriver webDriver, string id)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.Id(id));
                if (element != null)
                {
                    return true;
                }

                else
                {
                    CommonUtils.ThrowExceptionAndBreakTC("Error occured\n" + "Element was NULL\n" + "Unable to Click on Element By Xpath");
                    return false;
                }
            }
            catch (Exception e)
            {
                var errorFullName = e.GetType().FullName;
                var errorMessage = e.Message;
                var errorStackTrace = e.StackTrace;
                CommonUtils.ThrowExceptionAndBreakTC("Unable to Click on Element By Xpath\n" + errorFullName + "\n" + errorMessage + "\n" + errorStackTrace);
                return false;
            }
        }
        #endregion

        #region FindElementByXpath
        /// <summary>
        /// Public method which includes logic related to Finding Element thorugh Xpath.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="xPath">Parameter of type System.String for xPath.</param>
        /// <returns>WebElement</returns>
        public static IWebElement FindElementByXpath(this IWebDriver webDriver, string xPath)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.XPath(xPath));
                if (element == null)
                {
                    return null;
                }
                return element;
            }
            catch (Exception e)
            {
                e.GetType();
                return null;
            }

        }

        #endregion

        #region FindElementByClass
        /// <summary>
        /// Public method which includes logic related to Finding Element thorugh Class.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="Classname">Parameter of type System.String for Classname.</param>
        /// <returns>WebElement</returns>
        public static IWebElement FindElementByClass(this IWebDriver webDriver, string className)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.ClassName(className));
                if (element == null)
                {
                    return null;
                }
                return element;
            }
            catch (Exception e)
            {
                e.GetType();
                return null;
            }
        }
        #endregion

        #region FindElementByName
        /// <summary>
        /// Public method which includes logic related to Finding Element thorugh Class.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="name">Parameter of type System.String for name.</param>
        /// <returns>WebElement</returns>
        public static IWebElement FindElementByName(this IWebDriver webDriver, string name)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.Name(name));
                if (element == null)
                {
                    return null;
                }
                return element;
            }
            catch (Exception e)
            {
                e.GetType();
                return null;
            }
        }
        #endregion

        #region FindElementById
        /// <summary>
        /// Public method which includes logic related to Finding Element thorugh Id.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="Id">Parameter of type System.String for Id.</param>
        /// <returns>WebElement</returns>
        public static IWebElement FindElementById(this IWebDriver webDriver, string id)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.Id(id));
                if (element == null)
                {
                    return null;
                }
                return element;
            }
            catch (NoSuchElementException e)
            {
                Initialize.CreateLog("FindElementById:An Exception was Occured:" + e.Message);
                return null;
            }
        }

        #endregion

        #region FindElementByLinkText
        /// <summary>
        /// Public method which includes logic related to Finding Element thorugh Linkext.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="linktext">Parameter of type System.String for linktext.</param>
        /// <returns>WebElement</returns>
        public static IWebElement FindElementByLinkText(this IWebDriver webDriver, string linktext)
        {
            try
            {
                IWebElement element = webDriver.FindElement(By.LinkText(linktext));
                if (element == null)
                {
                    return null;
                }
                return element;
            }
            catch (Exception e)
            {
                e.GetType();
                return null;
            }
        }
        #endregion

        #region SwitchtoNewWindow
        /// <summary>
        /// Public method which includes logic related to Switching new window.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        public static void SwitchtoNewWindow(this IWebDriver webDriver)
        {
            try
            {
                //string existingWindowHandle = webDriver.CurrentWindowHandle;
                string NewWindowHandle = string.Empty;
                ReadOnlyCollection<string> windowHandles = webDriver.WindowHandles;
                NewWindowHandle = windowHandles[windowHandles.Count - 1];
                webDriver.SwitchTo().Window(NewWindowHandle);
            }
            catch (Exception e)
            {
                e.GetType();
            }

        }
        #endregion

        #region SwitchtoNewFrame
        /// <summary>
        /// Public method which includes logic related to Switching new frame.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        public static void SwitchtoNewFrame(this IWebDriver webDriver, int frameIndex)
        {
            try
            {
                webDriver.SwitchTo().Frame(frameIndex);
            }
            catch (Exception e)
            {
                e.GetType();
            }

        }
        #endregion

        #region SwitchtoNewFrame
        /// <summary>
        /// Public method which includes logic related to Switching new frame.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        public static void SwitchtoNewFrame(this IWebDriver webDriver, IWebElement frameElement)
        {
            try
            {
                webDriver.SwitchTo().Frame(frameElement);
            }
            catch (Exception e)
            {
                e.GetType();
            }

        }
        #endregion

        #region SwitchtoNewFrame
        /// <summary>
        /// Public method which includes logic related to Switching new frame.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        public static void SwitchtoNewFrame(this IWebDriver webDriver, string frameName)
        {
            try
            {
                webDriver.SwitchTo().Frame(frameName);
            }
            catch (Exception e)
            {
                e.GetType();
            }

        }
        #endregion

        #region MouseRightClickOnElement
        /// <summary>
        /// Public method which includes logic related to MouseRightClickOnElement.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>   
        /// <param name="Element">Parameter of type OpenQA.Selenium.IWebElement for webelement.</param>
        public static void MouseRightClickOnElement(this IWebDriver webDriver, IWebElement element)
        {
            try
            {
                Actions builder = new Actions(webDriver);
                builder.ContextClick(element).Build().Perform();
            }
            catch (Exception e)
            {
                e.GetType();
            }

        }
        #endregion

        #region DoTabbingFromElement
        /// <summary>
        /// Public method which includes logic related to do tabbing on specified element
        /// </summary>
        /// <param name="element">Parameter of type OpenQA.Selenium.IwebElement for element</param>
        public static void DoTabbingFromElement(IWebElement element)
        {
            try
            {
                if (element != null)
                {
                    element.SendKeys(Keys.Tab);
                }

            }
            catch (Exception e)
            {
                e.GetType();
            }

        }
        #endregion

        #region Click button using XPath
        /// <summary>
        /// Click on a button using XPath
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="moduleName"></param>
        /// <param name="elementType"></param>
        public static void ClickModuleWithXpath(IWebDriver driver, string moduleName, string elementType)
        {
            driver.FindElement(By.XPath("//span[@title=" + "'" + moduleName + "'" + "]")).Click();
        }
        #endregion

        #region ElementDrawHighlight
        /// <summary>
        /// Draw blue border around the Element to Highlight in GUI
        /// </summary>
        /// <param name="element">Parameter of type OpenQA.Selenium.IwebElement for element</param>
        public static void DrawHighlight(this IWebElement element)
        {
            var rc = (RemoteWebElement)element;
            var driver = (IJavaScriptExecutor)rc.WrappedDriver;
            var script = @"arguments[0].style.cssText = ""border-width: 5px; border-style: solid; border-color: blue""; ";
            driver.ExecuteScript(script, rc);
            Observable.Timer(new TimeSpan(0, 0, 3)).Subscribe(p =>
            {
                var clear = @"arguments[0].style.cssText = ""border-width: 0px; border-style: solid; border-color: blue""; ";
                driver.ExecuteScript(clear, rc);
            });
        }
        #endregion ElementDrawHighlight

        #region MouseHoverClickOnElement
        /// <summary>
        /// Public method which includes logic related to MouseHoverClickOnElement.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>   
        /// <param name="Element">Parameter of type OpenQA.Selenium.IWebElement for webelement.</param>
        public static void MouseHoverClickOnElement(this IWebDriver webDriver, IWebElement element)
        {
            try
            {
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element).Build().Perform();
                Thread.Sleep(1000);
                builder.Click(element).Build().Perform();
            }
            catch (Exception e)
            {
                e.GetType();
            }

        }
        #endregion

        #region MouseHoverClickOnElementUsingSpace
        /// <summary>
        /// Public method which includes logic related to MouseHoverClickOnElement.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>   
        /// <param name="Element">Parameter of type OpenQA.Selenium.IWebElement for webelement.</param>
        public static void MouseHoverClickOnElementUsingSpace(this IWebDriver webDriver, IWebElement element)
        {
            try
            {
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element).Build().Perform();
                builder.MoveToElement(element).SendKeys(Keys.Space).Build().Perform();
            }
            catch (Exception e)
            {
                e.GetType();
            }

        }
        #endregion

        #region MouseHoverOnElement
        /// <summary>
        /// Public method which includes logic related to MouseHoverClickOnElement.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>   
        /// <param name="Element">Parameter of type OpenQA.Selenium.IWebElement for webelement.</param>
        public static void MouseHoverOnElement(this IWebDriver webDriver, IWebElement element)
        {
            try
            {
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element).Build().Perform();
            }
            catch (Exception e)
            {
                e.GetType();
            }

        }
        #endregion

        #region MenuNavigation
        /// <summary>
        /// Public method which includes logic related to MenuNavigation.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>   
        /// <param name="MainMenu">Parameter of type OpenQA.Selenium.IWebElement for MainMenu.</param>
        /// <param name="SubMenu">Parameter of type OpenQA.Selenium.IWebElement for SubMenu.</param>
        public static void MenuNavigation(this IWebDriver webDriver, IWebElement mainMenu, string subMenuXpath)
        {
            try
            {
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(mainMenu).Build().Perform();
                //sync
                Thread.Sleep(1000);
                IWebElement subMenu = FindElementByXpath(webDriver, subMenuXpath);
                builder.MoveToElement(subMenu).Click().Perform();


            }
            catch (Exception e)
            {
                e.GetType();
            }
        }
        #endregion

        #region MenuNavigationById
        /// <summary>
        /// Public method which includes logic related to MenuNavigation.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>   
        /// <param name="MainMenu">Parameter of type OpenQA.Selenium.IWebElement for MainMenu.</param>
        /// <param name="SubMenu">Parameter of type OpenQA.Selenium.IWebElement for SubMenu.</param>
        public static void MenuNavigationById(this IWebDriver webDriver, IWebElement mainMenu, string subMenuId)
        {
            try
            {
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(mainMenu).Build().Perform();
                //sync
                Thread.Sleep(2000);
                IWebElement subMenu = FindElementById(webDriver, subMenuId);
                builder.MoveToElement(subMenu).Click().Perform();
                //subMenu.Click();
            }
            catch (Exception e)
            {
                e.GetType();
            }
        }
        #endregion

        #region MenuNavigationByName
        /// <summary>
        /// Public method which includes logic related to MenuNavigation.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>   
        /// <param name="MainMenu">Parameter of type OpenQA.Selenium.IWebElement for MainMenu.</param>
        /// <param name="SubMenu">Parameter of type OpenQA.Selenium.IWebElement for SubMenu.</param>
        public static void MenuNavigationByName(this IWebDriver webDriver, IWebElement mainMenu, string subMenuName)
        {
            try
            {
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(mainMenu).Build().Perform();
                //sync
                Thread.Sleep(2000);
                IWebElement subMenu = FindElementByName(webDriver, subMenuName);
                builder.MoveToElement(subMenu).Click().Perform();
                //subMenu.Click();
            }
            catch (Exception e)
            {
                e.GetType();
            }
        }
        #endregion

        #region VerifyIsElementEnabled
        /// <summary>
        /// Public method which includes logic related to verification of enabled status.
        /// </summary>
        /// <param name="webelement">Parameter of type OpenQA.Selenium.IWebElement for webelement.</param>
        /// <returns>True or False</returns>
        public static bool VerifyIsElementEnabled(this IWebElement webelement)
        {
            return webelement.Enabled;
        }
        #endregion

        #region VerifyIsElementPresent
        /// <summary>
        /// This method used to verify the element is present in UI
        /// </summary>       
        /// <param name="element">specify the element</param>
        /// <returns>true or false</returns>
        public static bool VerifyIsElementPresent(IWebElement element)
        {
            return element.Displayed;
        }
        #endregion VerifyIsElementPresent

        #region VerifyEditFieldText
        /// <summary>
        /// Public method which includes logic related to verification of element text.
        /// </summary>
        /// <param name="webelement">Parameter of type OpenQA.Selenium.IwebElement for webElement.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText</param>
        /// <returns>True or False</returns>
        public static bool VerifyEditFieldText(this IWebElement webelement, string expText)
        {
            try
            {
                if (webelement.Enabled == true)
                {
                    text = webelement.Text;
                    if (text == "")
                    {
                        text = webelement.GetAttribute("value");
                    }
                }
                else
                {

                    text = webelement.GetAttribute("value");
                }

                if (text.ToUpper() == expText.ToUpper())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                e.GetType();
                return false;
            }
        }
        #endregion

        #region VerifyEditFieldTextByName
        /// <summary>
        /// Public method which includes logic related to verification of element text through name.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="name">Parameter of type System.String for name.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <returns>True or False</returns>
        public static bool VerifyEditFieldTextByName(this IWebDriver webDriver, string name, string expText)
        {
            try
            {
                IWebElement webelement = webDriver.FindElementByName(name);
                if (webelement != null)
                {
                    if (webelement.Enabled == true)
                    {
                        text = webelement.Text;
                    }
                    else
                    {
                        text = webelement.GetAttribute("value");
                    }

                    if (text.ToUpper() == expText.ToUpper())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }//End of Main if
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                e.GetType();
                return false;
            }
        }
        #endregion

        #region VerifyEditFieldTextByXpath
        /// <summary>
        /// Public method which includes logic related to verification of element text through Xpath.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IWebDriver for webDriver.</param>
        /// <param name="Xpath">Parameter of type System.String for Xpath.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <returns>True or False</returns>
        public static bool VerifyEditFieldTextByXpath(this IWebDriver webDriver, string Xpath, string expText)
        {
            try
            {
                IWebElement webelement = webDriver.FindElementByXpath(Xpath);
                if (webelement != null)
                {
                    if (webelement.Enabled == true)
                    {
                        text = webelement.Text;
                        if (text == "")
                        {
                            text = webelement.GetAttribute("value");
                        }
                    }
                    else
                    {

                        text = webelement.GetAttribute("value");
                    }

                    if (text.ToUpper() == expText.ToUpper())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }//End of Main if
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                e.GetType();
                return false;
            }
        }
        #endregion

        #region VerifyListValue
        /// <summary>
        /// Public method which includes logic related to verification of list box value.
        /// </summary>
        /// <param name="webelement">Parameter of type OpenQA.Selenium.IwebElement for webelement.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <returns>True or False</returns>
        public static bool VerifyListValue(this IWebElement webelement, string expText)
        {
            try
            {
                SelectElement selectedValue = new SelectElement(webelement);
                string actualText = selectedValue.SelectedOption.Text;

                if (actualText.ToUpper() == expText.ToUpper())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                e.GetType();
                return false;
            }
        }
        #endregion

        #region CaptureSnapshot
        /// <summary>
        /// Public method which includes logic related to capturing the screenshot.
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebElement for webelement.</param>
        /// <param name="Filepath">Parameter of type System.String for FilePath.</param>
        /// <param name="FileName">Parameter of type System.String for FileName.</param>       
        public static void CaptureSnapshot(this IWebDriver webDriver, string filePath, string fileName)
        {
            try
            {
                string directoryPath = filePath;
                Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
                string screenshot = ss.AsBase64EncodedString;
                byte[] screenshotAsByteArray = ss.AsByteArray;
                if (Directory.Exists(directoryPath))
                {
                    ss.SaveAsFile(directoryPath + fileName + ".Png", OpenQA.Selenium.ScreenshotImageFormat.Png);
                    ss.ToString();
                }
                else
                {
                    Directory.CreateDirectory(directoryPath);
                    ss.SaveAsFile(directoryPath + fileName + ".Png", OpenQA.Selenium.ScreenshotImageFormat.Png);
                    ss.ToString();
                }

            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }
        #endregion

        #region ClearField
        /// <summary>
        /// Public method which includes logic related to clearing the fileds.
        /// </summary>
        /// <param name="we">Parameter of type OpenQA.Selenium.IwebElement for webelement.</param>       
        public static void ClearField(this IWebElement we)
        {
            try
            {
                //Clearing the gallery name edit field
                if (Initialize.browserType == "IE")
                {
                    we.SendKeys(Keys.Control + "a");
                    we.SendKeys(Keys.Delete);
                    if (we.GetAttribute("value") != "")
                    {
                        we.Clear();
                    }
                }
                else
                {
                    we.Clear();
                    if (we.GetAttribute("value") != "")
                    {
                        we.SendKeys(Keys.Control + "a");
                        we.SendKeys(Keys.Delete);
                    }
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }
        #endregion

        #region GetPopupErrorMsg
        /// <summary>
        /// Public method which includes logic related to get the alert message
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <returns>String value:Alert message</returns>
        public static string GetPopupErrorMsg(this IWebDriver webDriver)
        {
            try
            {
                //Handling Alert popups
                IAlert alert = webDriver.SwitchTo().Alert();
                string actualPopupText = alert.Text;
                Thread.Sleep(1000);
                alert.Accept();
                Thread.Sleep(1000);
                return actualPopupText;
            }
            catch (NoAlertPresentException Ae)
            {
                Ae.GetType();
                string actualPopupText = null;
                return actualPopupText;
            }

        }
        #endregion

        #region GetPopupErrorMsgWithDismiss
        /// <summary>
        /// Public method which includes logic related to get the alert message
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <returns>String Value:Alert Message</returns>
        public static string GetPopupErrorMsgWithDismiss(this IWebDriver webDriver)
        {
            try
            {
                //Handling Alert popups
                IAlert alert = webDriver.SwitchTo().Alert();
                string actualPopupText = alert.Text;
                alert.Dismiss();
                return actualPopupText;
            }
            catch (NoAlertPresentException Ae)
            {
                Ae.GetType();
                string actualPopupText = null;
                return actualPopupText;
            }

        }
        #endregion

        #region IsAlertPresent
        /// <summary>
        /// Public method which includes logic related to close the alert message
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <returns>True or False</returns>
        public static void IsAlertPresent(this IWebDriver webDriver)
        {
            try
            {
                //Handling Alert popups
                IAlert alert = webDriver.SwitchTo().Alert();
                if (alert.Text != null)
                {
                    alert.Accept();
                }
                else
                {
                    Initialize.CreateLog("IsAlertPresent:Alert was not existed");
                }

            }
            catch (NoAlertPresentException Ae)
            {
                Ae.GetType();
            }
        }
        #endregion

        #region ReadingDataFromHtmlTable
        /// <summary>
        /// Public method which includes to read the data from html table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="noofPagesIdElement">Parameter of type OpenQA.Selenium.IwebElement for WebElement</param>
        /// <param name="nextPageId">Parameter of type System.String for nextPageId.</param>
        /// <param name="TableId">Parameter of type System.String for TableId.</param>
        /// <param name="trXpath">Parameter of type System.String for trXpath.</param>
        /// <param name="tdXpath">Parameter of type System.String for tdXpath.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <returns>True or False</returns>
        public static bool ReadingDataFromHtmlTable(this IWebDriver webDriver, int pgeIdnumber, string nextPageXpath,
            string tablePropertyName, string tablePropertyValue, string trXpath, string tdXpath, string expText)
        {
            text = string.Empty;
            IWebElement tableElement = null;
            //Capturing the error if any using try-catch
            try
            {
                switch (tablePropertyName.ToUpper())
                {

                    case "NAME":
                        tableElement = SeleniumHelper.FindElementByName(webDriver, tablePropertyValue);
                        break;
                    case "CLASSNAME":
                        tableElement = SeleniumHelper.FindElementByClass(webDriver, tablePropertyValue);
                        break;
                    case "XPATH":
                        tableElement = SeleniumHelper.FindElementByXpath(webDriver, tablePropertyValue);
                        break;
                    case "ID":
                    default:
                        tableElement = SeleniumHelper.FindElementById(webDriver, tablePropertyValue);
                        break;
                }
                //Retrivng the webelement                
                //Collecting total no fo row elements for a page
                IList<IWebElement> trCollection = tableElement.FindElements(By.XPath(trXpath));
                //Initilizing the rowno,cell no
                int rowno, celno;
                rowno = 1;
                //Assinging the each row element from a list
                for (int tdrow = 0; tdrow <= trCollection.Count; tdrow++)
                {
                    celno = 1;
                    //Collecting the total no of cells data for a page
                    IList<IWebElement> tdCollection = trCollection[tdrow].FindElements(By.XPath(tdXpath));
                    //Assigning the each cell data from list
                    for (int tdColumnNumber = 0; tdColumnNumber <= tdCollection.Count; tdColumnNumber++)
                    {
                        //Retriving the each cell data
                        string actualData = (tdCollection[tdColumnNumber].Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;
                            //Exit from loop
                            if (Exit(expText) == false)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count)
                        {
                            //Comparing the total no of pages
                            if (pgeIdnumber != pgeid && !(SeleniumHelper.FindElementByXpath(webDriver, nextPageXpath)).GetAttribute("class").Contains("disabled"))
                            {
                                //Clicking on element
                                SeleniumHelper.ClickElement(SeleniumHelper.FindElementByXpath(webDriver, nextPageXpath));
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                //goto First;
                                return ReadingDataFromHtmlTable(webDriver, pgeIdnumber,
                                    nextPageXpath, tablePropertyName, tablePropertyValue, trXpath, tdXpath, expText);
                            }
                            else
                            {
                                if (Exit(expText) == false)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }

                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                }
            }

            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }
            finally
            {
                pgeid = 1;
            }
            return true;

        }
        #endregion

        #region VerifyCellPropertyValueFromHtmlTable
        /// <summary>
        /// Public method which includes to read the data from html table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="noofPagesIdElement">Parameter of type OpenQA.Selenium.IwebElement for WebElement</param>
        /// <param name="nextPageId">Parameter of type System.String for nextPageId.</param>
        /// <param name="TableId">Parameter of type System.String for TableId.</param>
        /// <param name="trXpath">Parameter of type System.String for trXpath.</param>
        /// <param name="tdXpath">Parameter of type System.String for tdXpath.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <returns>True or False</returns>
        public static bool VerifyCellPropertyValueFromHtmlTable(this IWebDriver webDriver, int pgeIdnumber, string nextPageXpath,
            string tablePropertyName, string tablePropertyValue, string trXpath, string tdXpath, string propertyName, string propertyValue, string expText)
        {
            IWebElement CellElement = null;
            text = string.Empty;
            //Capturing the error if any using try-catch
            IWebElement tableElement = null;
            //Capturing the error if any using try-catch
            try
            {
                switch (tablePropertyName.ToUpper())
                {

                    case "NAME":
                        tableElement = SeleniumHelper.FindElementByName(webDriver, tablePropertyValue);
                        break;
                    case "CLASSNAME":
                        tableElement = SeleniumHelper.FindElementByClass(webDriver, tablePropertyValue);
                        break;
                    case "XPATH":
                        tableElement = SeleniumHelper.FindElementByXpath(webDriver, tablePropertyValue);
                        break;
                    case "ID":
                    default:
                        tableElement = SeleniumHelper.FindElementById(webDriver, tablePropertyValue);
                        break;
                }
                Thread.Sleep(1000);
                //Collecting total no fo row elements for a page
                IList<IWebElement> trCollection = tableElement.FindElements(By.XPath(trXpath));
                //Initilizing the rowno,cell no
                int rowno, celno;
                rowno = 1;
                //Assinging the each row element from a list
                for (int tdrow = 0; tdrow <= trCollection.Count; tdrow++)
                {
                    celno = 1;
                    //Collecting the total no of cells data for a page
                    IList<IWebElement> tdCollection = trCollection[tdrow].FindElements(By.XPath(tdXpath));
                    //Assigning the each cell data from list
                    for (int tdcol = 0; tdcol <= tdCollection.Count; tdcol++)
                    {
                        //Retriving the each cell data
                        string actualData = (tdCollection[tdcol].Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;
                            CellElement = tdCollection[tdcol];
                            //Exit from loop
                            if (Exit(expText) == false)
                            {
                                return false;
                            }
                            else
                            {
                                if (!CellElement.GetAttribute(propertyName).Contains(propertyValue))
                                {
                                    Initialize.CreateLog("Verify Cell element proeprty value from html table:No cell element was found with the follwing information" +
                                        " " + propertyName + ":" + propertyValue);
                                    return false;
                                }
                                return true;
                            }
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count)
                        {
                            //Comparing the total no of pages
                            if (pgeIdnumber != pgeid)
                            {
                                //Clicking on element
                                SeleniumHelper.ClickOnElementByXpath(webDriver, nextPageXpath);
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                return VerifyCellPropertyValueFromHtmlTable(webDriver, pageIdNumber,
                                    nextPageXpath, tablePropertyName, tablePropertyValue, trXpath, tdXpath, propertyName, propertyValue,
                                    expText);
                            }
                            else
                            {
                                if (Exit(expText) == false)
                                {
                                    return false;
                                }
                                else
                                {
                                    if (!CellElement.GetAttribute(propertyName).Contains(propertyValue))
                                    {
                                        Initialize.CreateLog("Verify Cell element proeprty value from html table:No cell element was found with the follwing information" +
                                            " " + propertyName + ":" + propertyValue);
                                        return false;
                                    }
                                    return true;
                                }

                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                }//end of foreach (IWebElement rowelemnt in tr_collection)
                 //Exit crieteria            
            }//End of try

            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }//End of catch

            finally
            {
                pgeid = 1;
            }

            return true;
        }
        #endregion

        #region ReadingElementFromHtmltable
        /// <summary>
        /// Public method which includes logic related to read the data from html table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="noofPagesIdElement">Parameter of type OpenQA.Selenium.IwebElement for WebElement</param>
        /// <param name="nextPageId">Parameter of type System.String for nextPageId.</param>
        /// <param name="TableId">Parameter of type System.String for TableId.</param>
        /// <param name="trXpath">Parameter of type System.String for trXpath.</param>
        /// <param name="tdXpath">Parameter of type System.String for tdXpath.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <param name="strPropertyName">Parameter of type System.String for strPropertyName.</param>
        /// <param name="strProeprtyValue">Parameter of type System.String for strProeprtyValue.</param>
        /// <returns>WebElement:Cell object</returns>
        public static IWebElement ReadingElementFromHtmltable(this IWebDriver webDriver, int pageIdNumber, string nextPageXpath,
            string tablePropertyName, string tablePropertyValue, string trXpath, string tdXpath, string expText, string propertyName, string propertyValue)
        {
            text = string.Empty;
            childElement = null;
            IWebElement tableElement = null;
            //Capturing the error if any using try-catch
            try
            {
                switch (tablePropertyName.ToUpper())
                {

                    case "NAME":
                        tableElement = SeleniumHelper.FindElementByName(webDriver, tablePropertyValue);
                        break;
                    case "CLASSNAME":
                        tableElement = SeleniumHelper.FindElementByClass(webDriver, tablePropertyValue);
                        break;
                    case "XPATH":
                        tableElement = SeleniumHelper.FindElementByXpath(webDriver, tablePropertyValue);
                        break;
                    case "ID":
                    default:
                        tableElement = SeleniumHelper.FindElementById(webDriver, tablePropertyValue);
                        break;
                }
                //Collecting total no fo row elements for a page
                IList<IWebElement> trCollection = tableElement.FindElements(By.XPath(trXpath));
                //Initilizing the rowno,cell no
                int rowno, celno;
                rowno = 1;
                //Assinging the each row element from a list
                for (int tdrow = 0; tdrow <= trCollection.Count; tdrow++)
                {
                    celno = 1;
                    //Collecting the total no of cells data for a page
                    IList<IWebElement> tdCollection = trCollection[tdrow].FindElements(By.XPath(tdXpath));
                    //Assigning the each cell data from list
                    for (int tdcol = 0; tdcol <= tdCollection.Count; tdcol++)
                    {
                        //Retriving the each cell data
                        string actualData = (tdCollection[tdcol].Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;
                            try
                            {
                                switch (propertyName)
                                {

                                    case "TagName":
                                        childElement = tdCollection[celno - 1].FindElement(By.TagName(propertyValue));
                                        break;
                                    case "ClassName":
                                        childElement = tdCollection[celno - 1].FindElement(By.ClassName(propertyValue));
                                        break;
                                    case "Xpath":
                                        childElement = tdCollection[celno - 1].FindElement(By.XPath(propertyValue));
                                        break;
                                    case "Id":
                                    default:
                                        childElement = tdCollection[celno - 1].FindElement(By.Id(propertyValue));
                                        break;
                                }

                            }//End of try
                            catch (Exception e1)
                            {
                                e1.GetBaseException();
                            }//End of Catch

                            //End of if
                            //Exit from loop
                            if (Exit(expText) == false)
                            {
                                return null;
                            }
                            else
                            {
                                return childElement;
                            }
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count)
                        {
                            //Comparing the total no of pages
                            if (pageIdNumber != pgeid)
                            {
                                //Clicking on element
                                SeleniumHelper.ClickOnElementByXpath(webDriver, nextPageXpath);
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                return ReadingElementFromHtmltable(webDriver, pageIdNumber, nextPageXpath, tablePropertyName,
                                   tablePropertyValue, trXpath, tdXpath, expText, propertyName, propertyValue);
                            }
                            else
                            {
                                if (Exit(expText) == false)
                                {
                                    return null;
                                }
                                else
                                {
                                    return childElement;
                                }

                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                }//end of foreach (IWebElement rowelemnt in tr_collection)
                 //Exit crieteria            
            }//End of try

            catch (Exception e)
            {
                e.GetBaseException();
                return null;
            }//End of catch
            finally
            {
                pgeid = 1;
            }
            return childElement;
        }
        #endregion

        #region ReadingElementFromHtmltable
        /// <summary>
        /// Public method which includes logic related to read the data from html table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="noofPagesIdElement">Parameter of type OpenQA.Selenium.IwebElement for WebElement</param>
        /// <param name="nextPageId">Parameter of type System.String for nextPageId.</param>
        /// <param name="TableId">Parameter of type System.String for TableId.</param>
        /// <param name="trXpath">Parameter of type System.String for trXpath.</param>
        /// <param name="tdXpath">Parameter of type System.String for tdXpath.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <param name="strPropertyName">Parameter of type System.String for strPropertyName.</param>
        /// <param name="strProeprtyValue">Parameter of type System.String for strProeprtyValue.</param>
        /// <returns>WebElement:Cell object</returns>
        public static IWebElement ReadingElementFromHtmltable(this IWebDriver webDriver, int pageIdNumber, string nextPageXpath,
            string tablePropertyName, string tablePropertyValue, string rowPropertyName, string rowPorpertyvalue, string cellPropertyName, string cellPropertyValue, string expText, string propertyName, string propertyValue)
        {
            text = string.Empty;
            childElement = null;
            IWebElement tableElement = null;
            IList<IWebElement> trCollection = null;
            IList<IWebElement> tdCollection = null;
            //Capturing the error if any using try-catch
            try
            {
                switch (tablePropertyName.ToUpper())
                {

                    case "NAME":
                        tableElement = SeleniumHelper.FindElementByName(webDriver, tablePropertyValue);
                        break;
                    case "CLASSNAME":
                        tableElement = SeleniumHelper.FindElementByClass(webDriver, tablePropertyValue);
                        break;
                    case "XPATH":
                        tableElement = SeleniumHelper.FindElementByXpath(webDriver, tablePropertyValue);
                        break;
                    case "ID":
                    default:
                        tableElement = SeleniumHelper.FindElementById(webDriver, tablePropertyValue);
                        break;
                }
                //Piece of code which should be executed before loop starts  
                Thread.Sleep(2000);
                //Collecting total no fo row elements for a page     
                switch (rowPropertyName.ToUpper())
                {

                    case "NAME":
                        trCollection = tableElement.FindElements(By.Name(rowPorpertyvalue));
                        break;
                    case "CLASSNAME":
                        trCollection = tableElement.FindElements(By.ClassName(rowPorpertyvalue));
                        break;
                    case "XPATH":
                        trCollection = tableElement.FindElements(By.XPath(rowPorpertyvalue));
                        break;
                    case "TAGNAME":
                        trCollection = tableElement.FindElements(By.TagName(rowPorpertyvalue));
                        break;
                    case "ID":
                    default:
                        trCollection = tableElement.FindElements(By.Id(rowPorpertyvalue));
                        break;
                }
                //Initilizing the rowno,cell no
                int rowno, celno;
                rowno = 1;
                //Assinging the each row element from a list
                for (int tdrow = 0; tdrow <= trCollection.Count; tdrow++)
                {
                    celno = 1;
                    //Collecting the total no of cells data for a page
                    //Piece of code which should be executed before loop starts  
                    Thread.Sleep(1000);
                    //Collecting total no fo row elements for a page     
                    switch (cellPropertyName.ToUpper())
                    {

                        case "NAME":
                            tdCollection = tableElement.FindElements(By.Name(cellPropertyValue));
                            break;
                        case "CLASSNAME":
                            tdCollection = tableElement.FindElements(By.ClassName(cellPropertyValue));
                            break;
                        case "XPATH":
                            tdCollection = tableElement.FindElements(By.XPath(cellPropertyValue));
                            break;
                        case "TAGNAME":
                            tdCollection = tableElement.FindElements(By.TagName(cellPropertyValue));
                            break;
                        case "ID":
                        default:
                            tdCollection = tableElement.FindElements(By.Id(cellPropertyValue));
                            break;
                    }
                    //Assigning the each cell data from list
                    for (int tdcol = 0; tdcol <= tdCollection.Count; tdcol++)
                    {
                        //Retriving the each cell data
                        string actualData = (tdCollection[tdcol].Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;
                            try
                            {
                                switch (propertyName)
                                {

                                    case "TAGNAME":
                                        childElement = tdCollection[tdcol].FindElement(By.TagName(propertyValue));
                                        break;
                                    case "CLASSNAME":
                                        childElement = tdCollection[tdcol].FindElement(By.ClassName(propertyValue));
                                        break;
                                    case "XPATH":
                                        childElement = tdCollection[tdcol].FindElement(By.XPath(propertyValue));
                                        break;
                                    case "ID":
                                    default:
                                        childElement = tdCollection[tdcol].FindElement(By.Id(propertyValue));
                                        break;
                                }

                            }//End of try
                            catch (Exception e1)
                            {
                                e1.GetBaseException();
                            }//End of Catch

                            //End of if
                            //Exit from loop
                            if (Exit(expText) == false)
                            {
                                return null;
                            }
                            else
                            {
                                return childElement;
                            }
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count)
                        {
                            //Comparing the total no of pages
                            if (pageIdNumber == 0)
                            {
                                return null;
                            }
                            if (pageIdNumber != pgeid)
                            {
                                //Clicking on element
                                if (nextPageXpath == null)
                                {
                                    return null;
                                }
                                SeleniumHelper.ClickOnElementByXpath(webDriver, nextPageXpath);
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                return ReadingElementFromHtmltable(webDriver, pageIdNumber, nextPageXpath, tablePropertyName,
                                   tablePropertyValue, rowPropertyName, rowPorpertyvalue, cellPropertyName,
                                   cellPropertyValue, expText, propertyName, propertyValue);
                            }
                            else
                            {
                                if (Exit(expText) == false)
                                {
                                    return null;
                                }
                                else
                                {
                                    return childElement;
                                }

                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                }//end of foreach (IWebElement rowelemnt in tr_collection)
                //Exit crieteria            
            }//End of try

            catch (Exception e)
            {
                e.GetBaseException();
                return null;
            }//End of catch
            finally
            {
                pgeid = 1;
            }
            return childElement;
        }
        #endregion 

        #region ReadingCellElementFromHtmltable
        /// <summary>
        /// Public method which includes logic related to read the Cell element from html table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="noofPagesIdElement">Parameter of type OpenQA.Selenium.IwebElement for WebElement</param>
        /// <param name="nextPageId">Parameter of type System.String for nextPageId.</param>
        /// <param name="TableId">Parameter of type System.String for TableId.</param>
        /// <param name="trXpath">Parameter of type System.String for trXpath.</param>
        /// <param name="tdXpath">Parameter of type System.String for tdXpath.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <param name="strPropertyName">Parameter of type System.String for strPropertyName.</param>
        /// <param name="strProeprtyValue">Parameter of type System.String for strProeprtyValue.</param>
        /// <returns>WebElement:Cell object</returns>
        public static IWebElement ReadingCellElementFromHtmltable(this IWebDriver webDriver, int pageIdNumber, string nextPageXpath,
            string tablePropertyName, string tablePropertyValue, string trXpath, string tdXpath, string expText)
        {
            text = string.Empty;
            childElement = null;
            IWebElement tableElement = null;
            //Capturing the error if any using try-catch
            try
            {
                switch (tablePropertyName.ToUpper())
                {

                    case "NAME":
                        tableElement = SeleniumHelper.FindElementByName(webDriver, tablePropertyValue);
                        break;
                    case "CLASSNAME":
                        tableElement = SeleniumHelper.FindElementByClass(webDriver, tablePropertyValue);
                        break;
                    case "XPATH":
                        tableElement = SeleniumHelper.FindElementByXpath(webDriver, tablePropertyValue);
                        break;
                    case "ID":
                    default:
                        tableElement = SeleniumHelper.FindElementById(webDriver, tablePropertyValue);
                        break;
                }
                //Piece of code which should be executed before loop starts  
                Thread.Sleep(2000);
                //Collecting total no fo row elements for a page                
                IList<IWebElement> trCollection = tableElement.FindElements(By.XPath(trXpath));
                //Initilizing the rowno,cell no
                int rowno, celno;
                rowno = 1;
                //Assinging the each row element from a list
                for (int tdrow = 0; tdrow <= trCollection.Count; tdrow++)
                {
                    celno = 1;
                    //Collecting the total no of cells data for a page
                    IList<IWebElement> tdCollection = trCollection[tdrow].FindElements(By.XPath(tdXpath));
                    //Assigning the each cell data from list
                    for (int tdcol = 0; tdcol <= tdCollection.Count; tdcol++)
                    {
                        //Retriving the each cell data
                        string actualData = (tdCollection[tdcol].Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;
                            childElement = tdCollection[tdcol];
                            if (Exit(expText) == false)
                            {
                                return null;
                            }
                            else
                            {
                                return childElement;
                            }
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count)
                        {
                            //Comparing the total no of pages
                            if (pageIdNumber != pgeid && !(SeleniumHelper.FindElementByXpath(webDriver, nextPageXpath)).GetAttribute("class").Contains("disabled"))
                            {
                                //Clicking on element
                                SeleniumHelper.ClickElement(SeleniumHelper.FindElementByXpath(webDriver, nextPageXpath));
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                return ReadingCellElementFromHtmltable(webDriver, pageIdNumber, nextPageXpath, tablePropertyName,
                                   tablePropertyValue, trXpath, tdXpath, expText);
                            }
                            else
                            {
                                if (Exit(expText) == false)
                                {
                                    return null;
                                }
                                else
                                {
                                    return childElement;
                                }

                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                }//end of foreach (IWebElement rowelemnt in tr_collection)
                //Exit crieteria          
            }//End of try

            catch (Exception e)
            {
                e.GetBaseException();
                return null;
            }//End of catch
            finally
            {
                pgeid = 1;
            }
            return childElement;
        }
        #endregion

        #region ReadingCellElementFromHtmltable
        /// <summary>
        /// Public method which includes logic related to read the cell element from table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDriver for webDriver</param>
        /// <param name="pageIdNumber">Parameter of type System.String for pageIdNumber</param>
        /// <param name="nextPageXpath">Parameter of type System.String for nextpageXpath</param>
        /// <param name="tablePropertyName">Parameter of type System.String for tablePropertyName</param>
        /// <param name="tablePropertyValue">Parameter of type System.String for tablePropertyvalue</param>
        /// <param name="rowPropertyName">Parameter of type System.String for rowPropertyName</param>
        /// <param name="rowPorpertyvalue">Parameter of type System.String for rowPropertyvalue</param>
        /// <param name="cellPropertyName">Parameter of type System.String for cellPropertyName</param>
        /// <param name="cellPropertyValue">Parameter of type System.String for cellPropertyValue</param>
        /// <param name="expText">Parameter of type System.String for pageIdNumber</param>
        /// <returns></returns>
        public static IWebElement ReadingCellElementFromHtmltable(this IWebDriver webDriver, int pageIdNumber, string nextPageXpath,
            string tablePropertyName, string tablePropertyValue, string rowPropertyName, string rowPorpertyvalue, string cellPropertyName, string cellPropertyValue, string expText)
        {
            text = string.Empty;
            childElement = null;
            IWebElement tableElement = null;
            IList<IWebElement> trCollection = null;
            IList<IWebElement> tdCollection = null;
            //Capturing the error if any using try-catch
            try
            {
                switch (tablePropertyName.ToUpper())
                {

                    case "NAME":
                        tableElement = SeleniumHelper.FindElementByName(webDriver, tablePropertyValue);
                        break;
                    case "CLASSNAME":
                        tableElement = SeleniumHelper.FindElementByClass(webDriver, tablePropertyValue);
                        break;
                    case "XPATH":
                        tableElement = SeleniumHelper.FindElementByXpath(webDriver, tablePropertyValue);
                        break;
                    case "ID":
                    default:
                        tableElement = SeleniumHelper.FindElementById(webDriver, tablePropertyValue);
                        break;
                }
                //Piece of code which should be executed before loop starts  
                Thread.Sleep(2000);
                //Collecting total no fo row elements for a page     
                switch (rowPropertyName.ToUpper())
                {

                    case "NAME":
                        trCollection = tableElement.FindElements(By.Name(rowPorpertyvalue));
                        break;
                    case "CLASSNAME":
                        trCollection = tableElement.FindElements(By.ClassName(rowPorpertyvalue));
                        break;
                    case "XPATH":
                        trCollection = tableElement.FindElements(By.XPath(rowPorpertyvalue));
                        break;
                    case "TAGNAME":
                        trCollection = tableElement.FindElements(By.TagName(rowPorpertyvalue));
                        break;
                    case "ID":
                    default:
                        trCollection = tableElement.FindElements(By.Id(rowPorpertyvalue));
                        break;
                }

                //Initilizing the rowno,cell no
                int rowno, celno;
                rowno = 1;
                //Assinging the each row element from a list
                for (int tdrow = 0; tdrow <= trCollection.Count; tdrow++)
                {
                    celno = 1;
                    //Collecting the total no of cells data for a page
                    switch (cellPropertyName.ToUpper())
                    {

                        case "NAME":
                            tdCollection = tableElement.FindElements(By.Name(cellPropertyValue));
                            break;
                        case "CLASSNAME":
                            tdCollection = tableElement.FindElements(By.ClassName(cellPropertyValue));
                            break;
                        case "XPATH":
                            tdCollection = tableElement.FindElements(By.XPath(cellPropertyValue));
                            break;
                        case "TAGNAME":
                            tdCollection = tableElement.FindElements(By.TagName(cellPropertyValue));
                            break;
                        case "ID":
                        default:
                            tdCollection = tableElement.FindElements(By.TagName(cellPropertyValue));
                            break;
                    }
                    //Assigning the each cell data from list
                    for (int tdcol = 0; tdcol <= tdCollection.Count; tdcol++)
                    {
                        //Retriving the each cell data
                        string actualData = (tdCollection[tdcol].Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;
                            childElement = tdCollection[tdcol];
                            if (Exit(expText) == false)
                            {
                                return null;
                            }
                            else
                            {
                                return childElement;
                            }
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count)
                        {
                            //Comparing the total no of pages
                            if (pageIdNumber != pgeid && !(SeleniumHelper.FindElementByXpath(webDriver, nextPageXpath)).GetAttribute("class").Contains("disabled"))
                            {
                                //Clicking on element
                                SeleniumHelper.ClickElement(SeleniumHelper.FindElementByXpath(webDriver, nextPageXpath));
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                return ReadingCellElementFromHtmltable(webDriver, pageIdNumber, nextPageXpath, tablePropertyName,
                                   tablePropertyValue, rowPropertyName, rowPorpertyvalue, cellPropertyName, cellPropertyValue, expText);
                            }
                            else
                            {
                                if (Exit(expText) == false)
                                {
                                    return null;
                                }
                                else
                                {
                                    return childElement;
                                }

                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                }//end of foreach (IWebElement rowelemnt in tr_collection)
                //Exit crieteria          
            }//End of try

            catch (Exception e)
            {
                e.GetBaseException();
                return null;
            }//End of catch
            finally
            {
                pgeid = 1;
            }
            return childElement;
        }
        #endregion

        #region ClickonImgInHtmltable
        /// <summary>
        /// Public method which includes logic related to click on image html table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="noofPagesIdElement">Parameter of type OpenQA.Selenium.IwebElement for WebElement</param>
        /// <param name="nextPageId">Parameter of type System.String for nextPageId.</param>
        /// <param name="TableId">Parameter of type System.String for TableId.</param>
        /// <param name="trXpath">Parameter of type System.String for trXpath.</param>
        /// <param name="tdXpath">Parameter of type System.String for tdXpath.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <param name="strPropertyName">Parameter of type System.String for strPropertyName.</param>
        /// <param name="strProeprtyValue">Parameter of type System.String for strProeprtyValue.</param>
        /// <param name="index">Parameter of type System.int for index.</param>
        /// <returns>True or False values</returns>
        public static bool ClickonImgInHtmltable(this IWebDriver webDriver, int pageIdNumber, IWebElement nextPageLink,
            IWebElement tableElement, string trXpath, string tdXpath, string expText, string propertyName, string propertyValue, int elementIndex)
        {

            //Capturing the error if any using try-catch
            try
            {
                //Initilising the elements                
                childElement = null;
                text = string.Empty;
                Thread.Sleep(1000);
                //Collecting total no fo row elements for a page              
                IList<IWebElement> trCollection = tableElement.FindElements(By.XPath(trXpath));
                //Initilizing the rowno,cell no
                int rowno, celno;
                rowno = 1;
                //Assinging the each row element from a list
                for (int trIndex = 0; trIndex <= trCollection.Count - 1; trIndex++)
                {
                    celno = 1;
                    //Collecting the total no of cells data for a page
                    IList<IWebElement> tdCollection = trCollection[trIndex].FindElements(By.XPath(tdXpath));
                    //Assigning the each cell data from list
                    for (int tdIndex = 0; tdIndex <= tdCollection.Count - 1; tdIndex++)
                    {
                        //Retriving the each cell data
                        string actualData = (tdCollection[tdIndex].Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;
                            try
                            {
                                switch (propertyName.ToUpper())
                                {

                                    case "TAGNAME":
                                        childElement = tdCollection[tdIndex + elementIndex].FindElement(By.TagName(propertyValue));
                                        break;
                                    case "CLASSNAME":
                                        childElement = tdCollection[tdIndex + elementIndex].FindElement(By.ClassName(propertyValue));
                                        break;
                                    case "XPATH":
                                        childElement = tdCollection[tdIndex + elementIndex].FindElement(By.XPath(propertyValue));
                                        break;
                                    case "CSSSELECTOR":
                                        childElement = tdCollection[tdIndex + elementIndex].FindElement(By.CssSelector(propertyValue));
                                        break;
                                    case "ID":
                                    default:
                                        childElement = tdCollection[tdIndex + elementIndex].FindElement(By.Id(propertyValue));
                                        break;
                                }

                                if (childElement != null)
                                {
                                    if (childElement.GetAttribute("type") == "radio")
                                    {
                                        ClickOnRadioBtn(webDriver, childElement);

                                    }
                                    else
                                    {
                                        MouseHoverClickOnElement(webDriver, childElement);
                                    }

                                    if (Exit(expText) == false)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }//End of nested if
                            }
                            catch (Exception e1)
                            {
                                e1.GetBaseException();
                            }

                            //End of if
                            //Exit from loop
                            if (Exit(expText) == false)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count)
                        {
                            //Comparing the total no of pages
                            if (pageIdNumber != pgeid && !nextPageLink.GetAttribute("class").Contains("disabled"))
                            {
                                //Clicking on element
                                SeleniumHelper.ClickElement(nextPageLink);
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                return ClickonImgInHtmltable(webDriver, pageIdNumber, nextPageLink, tableElement,
                                    trXpath, tdXpath, expText, propertyName, propertyValue, elementIndex);
                            }
                            else
                            {
                                if (Exit(expText) == false)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }

                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                }//end of foreach (IWebElement rowelemnt in tr_collection)
                //Exit crieteria     
            }

            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }//End of catch

            finally
            {
                pgeid = 1;
            }

            return true;
        }
        #endregion

        #region ClickonImgInHtmltable
        /// <summary>
        /// Public method which includes logic related to click on image html table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="noofPagesIdElement">Parameter of type OpenQA.Selenium.IwebElement for WebElement</param>
        /// <param name="pageIdNumber">Parameter of type System.String for pageIdNumber</param>
        /// <param name="nextPageXpath">Parameter of type System.String for nextpageXpath</param>
        /// <param name="tablePropertyName">Parameter of type System.String for tablePropertyName</param>
        /// <param name="tablePropertyValue">Parameter of type System.String for tablePropertyvalue</param>
        /// <param name="rowPropertyName">Parameter of type System.String for rowPropertyName</param>
        /// <param name="rowPorpertyvalue">Parameter of type System.String for rowPropertyvalue</param>
        /// <param name="cellPropertyName">Parameter of type System.String for cellPropertyName</param>
        /// <param name="cellPropertyValue">Parameter of type System.String for cellPropertyValue</param>
        /// <param name="strPropertyName">Parameter of type System.String for strPropertyName.</param>
        /// <param name="strProeprtyValue">Parameter of type System.String for strProeprtyValue.</param>
        /// <param name="index">Parameter of type System.int for index.</param>
        /// <returns>True or False values</returns>
        public static bool ClickonImgInHtmltable(this IWebDriver webDriver, int pageIdNumber, IWebElement nextPageXpath,
            string tablePropertyName, string tablePropertyValue, string rowPropertyName,
            string rowPorpertyvalue, string cellPropertyName, string cellPropertyValue, string expText,
            string propertyName, string propertyValue, int elementIndex)
        {

            text = string.Empty;
            childElement = null;
            IWebElement tableElement = null;
            IList<IWebElement> trCollection = null;
            IList<IWebElement> tdCollection = null;
            //Capturing the error if any using try-catch
            try
            {
                switch (tablePropertyName.ToUpper())
                {

                    case "NAME":
                        tableElement = SeleniumHelper.FindElementByName(webDriver, tablePropertyValue);
                        break;
                    case "CLASSNAME":
                        tableElement = SeleniumHelper.FindElementByClass(webDriver, tablePropertyValue);
                        break;
                    case "XPATH":
                        tableElement = SeleniumHelper.FindElementByXpath(webDriver, tablePropertyValue);
                        break;
                    case "ID":
                    default:
                        tableElement = SeleniumHelper.FindElementById(webDriver, tablePropertyValue);
                        break;
                }
                //Piece of code which should be executed before loop starts  
                Thread.Sleep(2000);
                //Collecting total no fo row elements for a page     
                switch (rowPropertyName.ToUpper())
                {

                    case "NAME":
                        trCollection = tableElement.FindElements(By.Name(rowPorpertyvalue));
                        break;
                    case "CLASSNAME":
                        trCollection = tableElement.FindElements(By.ClassName(rowPorpertyvalue));
                        break;
                    case "XPATH":
                        trCollection = tableElement.FindElements(By.XPath(rowPorpertyvalue));
                        break;
                    case "TAGNAME":
                        trCollection = tableElement.FindElements(By.TagName(rowPorpertyvalue));
                        break;
                    case "ID":
                    default:
                        trCollection = tableElement.FindElements(By.Id(rowPorpertyvalue));
                        break;
                }

                //Initilizing the rowno,cell no
                int rowno, celno;
                rowno = 1;
                //Assinging the each row element from a list
                for (int tdrow = 0; tdrow <= trCollection.Count; tdrow++)
                {
                    celno = 1;
                    //Collecting the total no of cells data for a page
                    switch (cellPropertyName.ToUpper())
                    {

                        case "NAME":
                            tdCollection = trCollection[tdrow].FindElements(By.Name(cellPropertyValue));
                            if (tdCollection.Count == 0)
                            {
                                tdCollection = tableElement.FindElements(By.Name(cellPropertyValue));
                            }
                            break;
                        case "CLASSNAME":
                            tdCollection = trCollection[tdrow].FindElements(By.ClassName(cellPropertyValue));
                            if (tdCollection.Count == 0)
                            {
                                tdCollection = tableElement.FindElements(By.ClassName(cellPropertyValue));
                            }
                            break;
                        case "XPATH":
                            tdCollection = trCollection[tdrow].FindElements(By.XPath(cellPropertyValue));
                            if (tdCollection.Count == 0)
                            {
                                tdCollection = tableElement.FindElements(By.XPath(cellPropertyValue));
                            }
                            break;
                        case "TAGNAME":
                            tdCollection = trCollection[tdrow].FindElements(By.TagName(cellPropertyValue));
                            if (tdCollection.Count == 0)
                            {
                                tdCollection = tableElement.FindElements(By.TagName(cellPropertyValue));
                            }
                            break;
                        case "ID":
                        default:
                            tdCollection = trCollection[tdrow].FindElements(By.Id(cellPropertyValue));
                            if (tdCollection.Count == 0)
                            {
                                tdCollection = tableElement.FindElements(By.Id(cellPropertyValue));
                            }
                            break;
                    }
                    //Assigning the each cell data from list
                    for (int tdcol = 0; tdcol <= tdCollection.Count; tdcol++)
                    {
                        //Retriving the each cell data
                        string actualData = (tdCollection[tdcol].Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;
                            try
                            {
                                switch (propertyName.ToUpper())
                                {

                                    case "TAGNAME":
                                        childElement = tdCollection[tdrow + elementIndex].FindElement(By.TagName(propertyValue));
                                        if (childElement == null)
                                        {
                                            childElement = tdCollection[elementIndex].FindElement(By.TagName(propertyValue));
                                        }
                                        break;
                                    case "CLASSNAME":
                                        childElement = tdCollection[tdrow + elementIndex].FindElement(By.ClassName(propertyValue));
                                        if (childElement == null)
                                        {
                                            childElement = tdCollection[elementIndex].FindElement(By.TagName(propertyValue));
                                        }
                                        break;
                                    case "XPATH":
                                        childElement = tdCollection[tdrow + elementIndex].FindElement(By.XPath(propertyValue));
                                        if (childElement == null)
                                        {
                                            childElement = tdCollection[elementIndex].FindElement(By.TagName(propertyValue));
                                        }
                                        break;
                                    case "CSSSELECTOR":
                                        childElement = tdCollection[tdrow + elementIndex].FindElement(By.CssSelector(propertyValue));
                                        if (childElement == null)
                                        {
                                            childElement = tdCollection[elementIndex].FindElement(By.TagName(propertyValue));
                                        }
                                        break;
                                    case "ID":
                                    default:
                                        childElement = tdCollection[tdrow + elementIndex].FindElement(By.Id(propertyValue));
                                        if (childElement == null)
                                        {
                                            childElement = tdCollection[elementIndex].FindElement(By.TagName(propertyValue));
                                        }
                                        break;
                                }

                                if (childElement != null)
                                {
                                    if (childElement.GetAttribute("type") == "radio")
                                    {
                                        ClickOnRadioBtn(webDriver, childElement);

                                    }
                                    else
                                    {
                                        MouseHoverClickOnElement(webDriver, childElement);
                                    }

                                    if (Exit(expText) == false)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }//End of nested if
                            }
                            catch (Exception e1)
                            {
                                e1.GetBaseException();
                            }


                            //End of if
                            //Exit from loop
                            if (Exit(expText) == false)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count)
                        {
                            //Comparing the total no of pages
                            if (pageIdNumber != pgeid && !nextPageXpath.GetAttribute("class").Contains("disabled"))
                            {
                                //Clicking on element
                                SeleniumHelper.ClickElement(nextPageXpath);
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                return ClickonImgInHtmltable(webDriver, pageIdNumber, nextPageXpath, tablePropertyName,
                                    tablePropertyValue, rowPropertyName, rowPorpertyvalue,
                                    cellPropertyName, cellPropertyValue, expText, propertyName, propertyValue, elementIndex);
                            }
                            else
                            {
                                if (Exit(expText) == false)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }

                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                }//end of foreach (IWebElement rowelemnt in tr_collection)
                //Exit crieteria     
            }

            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }//End of catch

            finally
            {
                pgeid = 1;
            }

            return true;
        }
        #endregion

        #region GetElementsFromTableCell
        /// <summary>
        /// Public method which includes logic related to click on image html table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="noofPagesIdElement">Parameter of type OpenQA.Selenium.IwebElement for WebElement</param>
        /// <param name="nextPageId">Parameter of type System.String for nextPageId.</param>
        /// <param name="TableId">Parameter of type System.String for TableId.</param>
        /// <param name="trXpath">Parameter of type System.String for trXpath.</param>
        /// <param name="tdXpath">Parameter of type System.String for tdXpath.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <param name="strPropertyName">Parameter of type System.String for strPropertyName.</param>
        /// <param name="strProeprtyValue">Parameter of type System.String for strProeprtyValue.</param>
        /// <param name="index">Parameter of type System.int for index.</param>
        /// <returns>True or False values</returns>
        public static IList<IWebElement> GetElementsFromTableCell(this IWebDriver webDriver, int pageIdNumber, IWebElement nextPageLink,
            IWebElement tableElement, string trXpath, string tdXpath, string expText, string propertyName, string propertyValue, int elementIndex)
        {
            text = string.Empty;
            //Capturing the error if any using try-catch
            try
            {
                //Piece of code which should be executed before loop starts
                Thread.Sleep(1000);
                //Collecting total no fo row elements for a page              
                IList<IWebElement> trCollection = tableElement.FindElements(By.XPath(trXpath));
                //Initilizing the rowno,cell no
                int rowno, celno;
                rowno = 1;
                //Assinging the each row element from a list
                for (int trIndex = 0; trIndex <= trCollection.Count - 1; trIndex++)
                {
                    celno = 1;
                    //Collecting the total no of cells data for a page
                    IList<IWebElement> tdCollection = trCollection[trIndex].FindElements(By.XPath(tdXpath));
                    //Assigning the each cell data from list
                    for (int tdIndex = 0; tdIndex <= tdCollection.Count - 1; tdIndex++)
                    {
                        //Retriving the each cell data
                        string actualData = (tdCollection[tdIndex].Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;

                            try
                            {
                                switch (propertyName.ToUpper())
                                {

                                    case "TAGNAME":
                                        childElements = tdCollection[tdIndex + elementIndex].FindElements(By.TagName(propertyValue));
                                        break;
                                    case "CLASSNAME":
                                        childElements = tdCollection[tdIndex + elementIndex].FindElements(By.ClassName(propertyValue));
                                        break;
                                    case "XPATH":
                                        childElements = tdCollection[tdIndex + elementIndex].FindElements(By.XPath(propertyValue));
                                        break;
                                    case "ID":
                                    default:
                                        childElements = tdCollection[tdIndex + elementIndex].FindElements(By.Id(propertyValue));
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                                e.GetBaseException();
                            }

                            //End of if
                            //Exit from loop
                            if (Exit(expText) == false)
                            {
                                return null;
                            }
                            else
                            {
                                return childElements;
                            }
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count)
                        {
                            //Comparing the total no of pages
                            if (pageIdNumber != pgeid && !nextPageLink.GetAttribute("class").Contains("disabled"))
                            {
                                //Clicking on element
                                SeleniumHelper.ClickElement(nextPageLink);
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                return GetElementsFromTableCell(webDriver, pageIdNumber, nextPageLink, tableElement,
                                    trXpath, tdXpath, expText, propertyName, propertyValue, elementIndex);
                            }
                            else
                            {
                                if (Exit(expText) == false)
                                {
                                    return null;
                                }
                                else
                                {
                                    return childElements;
                                }
                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                }//end of foreach (IWebElement rowelemnt in tr_collection)
                 //Exit crieteria           
            }//End of try

            catch (Exception e)
            {
                e.GetBaseException();
                return null;
            }//End of catch
            finally
            {
                pgeid = 1;
            }
            return childElements;
        }
        #endregion

        #region ClickonImgInHtmltableByTagName
        /// <summary>
        /// Public method which includes logic related to click on image html table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="noofPagesIdElement">Parameter of type OpenQA.Selenium.IwebElement for WebElement</param>
        /// <param name="nextPageId">Parameter of type System.String for nextPageId.</param>
        /// <param name="TableId">Parameter of type System.String for TableId.</param>
        /// <param name="trXpath">Parameter of type System.String for trXpath.</param>
        /// <param name="tdXpath">Parameter of type System.String for tdXpath.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <param name="strPropertyName">Parameter of type System.String for strPropertyName.</param>
        /// <param name="strProeprtyValue">Parameter of type System.String for strProeprtyValue.</param>
        /// <param name="index">Parameter of type System.int for index.</param>
        /// <returns>True or False values</returns>
        public static bool ClickonImgInHtmltableByTagName(this IWebDriver webDriver, int pageIdNumber, string nextPageId,
            IWebElement tableElement, string expText, string propertyName, string propertyValue, int elementIndex)
        {

            //Capturing the error if any using try-catch
            try
            {
                text = string.Empty;
                Thread.Sleep(1000);
                //Collecting total no fo row elements for a page              
                IList<IWebElement> trCollection = tableElement.FindElements(By.TagName("tr"));
                //Initilizing the rowno,cell no
                int rowno, celno;
                rowno = 1;
                //Assinging the each row element from a list
                for (int trIndex = 0; trIndex <= trCollection.Count - 1; trIndex++)
                {
                    celno = 1;
                    //Collecting the total no of cells data for a page
                    IList<IWebElement> tdCollection = tableElement.FindElements(By.TagName("td"));
                    //Assigning the each cell data from list
                    for (int tdIndex = 0; tdIndex <= tdCollection.Count - 1; tdIndex++)
                    {
                        //Retriving the each cell data
                        string actualData = (tdCollection[tdIndex].Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;
                            try
                            {
                                switch (propertyName.ToUpper())
                                {

                                    case "TAGNAME":
                                        childElement = tdCollection[elementIndex].FindElement(By.TagName(propertyValue));
                                        break;
                                    case "CLASSNAME":
                                        childElement = tdCollection[elementIndex].FindElement(By.ClassName(propertyValue));
                                        break;
                                    case "XPATH":
                                        childElement = tdCollection[elementIndex].FindElement(By.XPath(propertyValue));
                                        break;
                                    case "ID":
                                    default:
                                        childElement = tdCollection[elementIndex].FindElement(By.Id(propertyValue));
                                        break;
                                }

                                if (childElement != null)
                                {
                                    if (childElement.GetAttribute("type") == "radio")
                                    {
                                        ClickOnRadioBtn(webDriver, childElement);

                                    }
                                    else
                                    {
                                        Thread.Sleep(2000);
                                        childElement.Click();
                                    }

                                    if (Exit(expText) == false)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }//End of nested if
                            }
                            catch (Exception e)
                            {
                                e.GetBaseException();
                            }

                            //End of if
                            //Exit from loop
                            if (Exit(expText) == false)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count)
                        {
                            //Comparing the total no of pages
                            if (pageIdNumber != pgeid)
                            {
                                //Clicking on element
                                SeleniumHelper.ClickOnElementById(webDriver, nextPageId);
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                return ClickonImgInHtmltableByTagName(webDriver, pageIdNumber, nextPageId, tableElement,
                                    expText, propertyName, propertyValue, elementIndex);
                            }
                            else
                            {
                                if (Exit(expText) == false)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }

                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                }//end of foreach (IWebElement rowelemnt in tr_collection)            
            }//End of try

            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }//End of catch

            finally
            {
                pgeid = 1;
            }

            return true;
        }
        #endregion ClickonImgInHtmltableByTagName

        #region ClickOnButtonFromGrid
        /// <summary>
        /// Public method which includes logic related to click on image html table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="noofPagesIdElement">Parameter of type OpenQA.Selenium.IwebElement for WebElement</param>
        /// <param name="nextPageId">Parameter of type System.String for nextPageId.</param>
        /// <param name="TableId">Parameter of type System.String for TableId.</param>
        /// <param name="trXpath">Parameter of type System.String for trXpath.</param>
        /// <param name="tdXpath">Parameter of type System.String for tdXpath.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <param name="strPropertyName">Parameter of type System.String for strPropertyName.</param>
        /// <param name="strProeprtyValue">Parameter of type System.String for strProeprtyValue.</param>
        /// <param name="index">Parameter of type System.int for index.</param>
        /// <returns>True or False values</returns>
        public static bool ClickOnButtonFromGrid(this IWebDriver webDriver, int pageIdNumber, string nextPageId,
            IWebElement tableElement, string expText, string propertyName, string propertyValue)
        {
            text = string.Empty;

            //Capturing the error if any using try-catch
            try
            {
                Thread.Sleep(1000);
                //Collecting total no fo row elements for a page              
                IList<IWebElement> trCollection = tableElement.FindElements(By.TagName("tr"));
                //Initilizing the rowno,cell no
                int rowno, celno;
                rowno = 1;
                //Assinging the each row element from a list
                for (int trIndex = 0; trIndex <= trCollection.Count - 1; trIndex++)
                {
                    celno = 1;
                    //Collecting the total no of cells data for a page
                    IList<IWebElement> tdCollection = trCollection[trIndex].FindElements(By.TagName("td"));
                    //Assigning the each cell data from list
                    for (int tdIndex = 0; tdIndex <= tdCollection.Count - 1; tdIndex++)
                    {
                        //Retriving the each cell data
                        string actualData = (tdCollection[tdIndex].Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;
                            try
                            {
                                switch (propertyName.ToUpper())
                                {

                                    case "TAGNAME":
                                        childElement = trCollection[trIndex].FindElement(By.TagName(propertyValue));
                                        break;
                                    case "CLASSNAME":
                                        childElement = trCollection[trIndex].FindElement(By.ClassName(propertyValue));
                                        break;
                                    case "XPATH":
                                        childElement = trCollection[trIndex].FindElement(By.XPath(propertyValue));
                                        break;
                                    case "ID":
                                    default:
                                        childElement = trCollection[trIndex].FindElement(By.Id(propertyValue));
                                        break;
                                }

                                if (childElement != null)
                                {
                                    if (childElement.GetAttribute("type") == "radio")
                                    {
                                        ClickOnRadioBtn(webDriver, childElement);

                                    }
                                    else
                                    {
                                        Thread.Sleep(2000);
                                        childElement.Click();
                                    }

                                    if (Exit(expText) == false)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }//End of nested if
                            }
                            catch (Exception e)
                            {
                                e.GetBaseException();
                            }

                            //End of if
                            //Exit from loop
                            if (Exit(expText) == false)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count && rowno == trCollection.Count)
                        {
                            //Comparing the total no of pages
                            if (pageIdNumber != pgeid)
                            {
                                //Clicking on element
                                SeleniumHelper.ClickOnElementById(webDriver, nextPageId);
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                return ClickOnButtonFromGrid(webDriver, pageIdNumber, nextPageId,
                                    tableElement, expText, propertyName, propertyValue);
                            }
                            else
                            {
                                if (Exit(expText) == false)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }

                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                }//end of foreach (IWebElement rowelemnt in tr_collection)
                 //Exit crieteria           
            }//End of try

            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }//End of catch
            finally
            {
                pgeid = 1;
            }
            return true;
        }
        #endregion ClickOnButtonFromGrid

        #region VerifyRecorddatafromHtmltable
        /// <summary>
        /// Public method which includes logic related to verify the record from html table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="noofPagesIdElement">Parameter of type OpenQA.Selenium.IwebElement for noofPagesIdElement.</param>
        /// <param name="nextPageId">Parameter of type OpenQA.Selenium.IwebElement for nextPageId.</param>
        /// <param name="TableId">Parameter of type System.String for TableId.</param>
        /// <param name="trXpath">Parameter of type System.String for trXpath.</param>
        /// <param name="tdXpath">Parameter of type System.String for tdXpath.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <param name="strchr">Parameter of type System.String for strchr.</param>
        /// <returns>True or False</returns>
        public static bool VerifyRecorddatafromHtmltable(this IWebDriver webDriver, int pgeIdnumber, IWebElement nextPageLink, IWebElement tableElement, string trXpath, string tdXpath, string expText, string charValue)
        {
            //Capturing the error if any using try-catch
            try
            {
                text = string.Empty;
                //Collecting total no fo row elements for a page
                IList<IWebElement> trCollection = tableElement.FindElements(By.XPath(trXpath));
                //Initilizing the rowno,cell no
                int rowno, celno, trno;
                rowno = 1;
                trno = 0;
                //Assinging the each row element from a list
                for (int tdrow = 0; tdrow <= trCollection.Count; tdrow++)
                {
                    celno = 0;
                    //Collecting the total no of cells data for a page
                    IList<IWebElement> tdCollection = trCollection[tdrow].FindElements(By.XPath(tdXpath));
                    //Assigning the each cell data from list
                    for (int tdcol = 0; tdcol <= tdCollection.Count; tdcol++)
                    {
                        //Retriving the each cell data
                        string actualData = (tdCollection[tdcol].Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;
                            if (charValue != "")
                            {
                                for (int itr = celno; itr <= tdCollection.Count; itr++)
                                {
                                    if (tdCollection[itr].Text.Trim() == (charValue))
                                    {
                                        if (Exit(expText) == false)
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            return true;
                                        }
                                    }//End of nested if
                                }//End of for
                            }//End of if

                            //Exit from loop
                            if (Exit(expText) == false)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count - 1)
                        {
                            //Comparing the total no of pages
                            if (pgeIdnumber != pgeid)
                            {
                                //Clicking on element
                                SeleniumHelper.ClickElement(nextPageLink);
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                return VerifyRecorddatafromHtmltable(webDriver, pageIdNumber, nextPageLink, tableElement,
                                    trXpath, tdXpath, expText, charValue);
                            }
                            else
                            {
                                if (Exit(expText) == false)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }

                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                    trno = trno + 1;
                }//end of foreach (IWebElement rowelemnt in tr_collection)
                 //Exit crieteria           
            }//End of try

            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }//End of catch
            finally
            {
                pgeid = 1;
            }
            return true;
        }
        #endregion

        #region GetCellIndexfromHtmltable
        /// <summary>
        /// Public method which includes logic related to get the Cell index from html table
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="noofPagesIdElement">Parameter of type OpenQA.Selenium.IwebElement for noofPagesIdElement.</param>
        /// <param name="nextPageId">Parameter of type OpenQA.Selenium.IwebElement for nextPageId.</param>
        /// <param name="TableId">Parameter of type System.String for TableId.</param>
        /// <param name="trXpath">Parameter of type System.String for trXpath.</param>
        /// <param name="tdXpath">Parameter of type System.String for tdXpath.</param>
        /// <param name="ExpText">Parameter of type System.String for ExpText.</param>
        /// <returns>Cell number</returns>
        public static int GetCellIndexfromHtmltable(this IWebDriver webDriver, int pgeIdnumber, string nextPageId, IWebElement tableElement, string trXpath, string tdXpath, string expText)
        {
            //Capturing the error if any using try-catch
            try
            {
                //Collecting total no fo row elements for a page
                IList<IWebElement> trCollection = tableElement.FindElements(By.XPath(trXpath));
                //Initilizing the rowno,cell no
                int rowno, trno;
                rowno = 1;
                trno = 0;
                //Assinging the each row element from a list
                foreach (IWebElement rowelemnt in trCollection)
                {
                    celno = 0;
                    //Collecting the total no of cells data for a page
                    IList<IWebElement> tdCollection = rowelemnt.FindElements(By.XPath(tdXpath));
                    //Assigning the each cell data from list
                    foreach (IWebElement colement in tdCollection)
                    {
                        //Retriving the each cell data
                        string actualData = (colement.Text).Trim();
                        //Comparing the data
                        if (actualData.ToUpper() == expText.ToUpper())
                        {
                            text = actualData;
                            //Exit from loop
                            return celno;
                        }
                        //Clicking on page next and repeating the process
                        else if (celno == tdCollection.Count - 1)
                        {
                            //Comparing the total no of pages
                            if (pgeIdnumber != pgeid)
                            {
                                //Clicking on element
                                SeleniumHelper.ClickOnElementById(webDriver, nextPageId);
                                pgeid = pgeid + 1;
                                Thread.Sleep(1000);
                                return GetCellIndexfromHtmltable(webDriver, pageIdNumber, nextPageId, tableElement,
                                    trXpath, tdXpath, expText);
                            }
                            else
                            {
                                return celno;

                            }
                        }//end of else if (celno == td_collection.Count)
                        //Increamnt of cell value for each iteartion 
                        celno = celno + 1;
                    }//end of foreach (IWebElement colement in td_collection)
                    //Increment of row value for each iteration
                    rowno = rowno + 1;
                    trno = trno + 1;
                }//end of foreach (IWebElement rowelemnt in tr_collection)
                return celno;
            }

            catch (Exception e)
            {
                e.GetType();
                return -1;
            }
            finally
            {
                pgeid = 1;
            }
        }
        #endregion

        #region GetRecordsCountfromHtmltable
        /// <summary>
        /// Public method which includes logic related to Get the records count from html talbe
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="TableId">Parameter of type System.String for TableId.</param>
        /// <param name="trXpath">Parameter of type System.String for trXpath.</param>
        /// <returns>Records count</returns>
        public static int GetRecordsCountfromHtmltable(this IWebDriver webDriver, IWebElement tableElement, string trXpath)
        {
            //Capturing the error if any using try-catch
            try
            {
                //Collecting total no fo row elements for a page
                IList<IWebElement> trCollection = tableElement.FindElements(By.XPath(trXpath));
                return trCollection.Count;
            }
            catch (Exception e)
            {
                e.GetType();
                return 0;
            }
        }
        #endregion

        #region ChildObjects
        /// <summary>
        /// Public method which includes logic related to get the collection of elements from a parent element
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="PropertyName">Parameter of type System.String for PropertyName</param>
        /// <param name="PropertyValue">Parameter of type System.String for PropertyValue</param>
        /// <returns>Collection of Webelements</returns>
        public static IList<IWebElement> ChildObjects(this IWebDriver webDriver, string propertyName, string propertyValue)
        {
            //Capturing the error if any using try-catch
            try
            {
                //Retrivng the webelements
                switch (propertyName)
                {
                    case "TagName":
                        folders = webDriver.FindElements(By.TagName(propertyValue));
                        return folders;
                    case "ClassName":
                        folders = webDriver.FindElements(By.ClassName(propertyValue));
                        return folders;
                    case "Id":
                        folders = webDriver.FindElements(By.Id(propertyValue));
                        return folders;
                    case "Xpath":
                    default:
                        folders = webDriver.FindElements(By.XPath(propertyValue));
                        return folders;
                }
            }
            catch (Exception e)
            {
                e.GetType();
                return null;
            }
        }
        #endregion

        #region DrangAndDrop
        /// <summary>
        /// Public method which includes logic related to Drag and drop the elements
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.Selenium.IwebDrvier for webDriver.</param>
        /// <param name="SourceElemnt">Parameter of type OpenQA.Selenium.IwebElement for SourceElement.</param>
        /// <param name="DestinationElmnt">Parameter of type OpenQA.Selenium.IwebElement for DestinationElement.</param>
        public static void DrangAndDrop(IWebDriver webDriver, IWebElement sourceElement, IWebElement destinationElement)
        {
            //Capturing the error if any using try-catch
            try
            {
                //Drag and drop
                Actions action = new Actions(webDriver);
                action.DragAndDrop(sourceElement, destinationElement).Perform();
            }
            catch (Exception e)
            {
                e.GetType();
            }
        }
        #endregion

        #region CaptureLogAndScreenShot
        /// <summary>
        /// Public method which includes logic related to Capturing the loig and screenshot
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.IwebDriver for webDriver</param>
        /// <param name="scenarioName">Parameter of type System.String for scenarioName</param>
        /// <param name="stepDetails">Parameter of type System.String for stepDetails</param>
        /// <param name="logPath">Parameter of type System.String for logPath</param>
        public static void CaptureLogAndScreenShot(IWebDriver webDriver, string scenarioName, string stepDetails, string logPath)
        {
            try
            {
                Initialize.CreateLog(scenarioName + ":" + stepDetails);
                CaptureSnapshot(webDriver, logPath, scenarioName + DateTime.Now.ToString(resultsDateFormat));
            }
            catch (Exception e)
            {
                e.GetType();
            }
        }
        #endregion

        #region GetRowElementFromHtmlTable
        /// <summary>
        /// Public method which includes logic related to get the row element from webtable
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.IwebDriver for webDriver</param>
        /// <param name="pageIdNumber">Parameter of type System.string for pageIdNumber</param>
        /// <param name="nextPageBtnPropertyName">Parameter of type System.string for nextPageBtnPropertyName</param>
        /// <param name="nextPageBtnPropertyValue">Parameter of type System.string for nextPageBtnPropertyValue</param>
        /// <param name="tablePropertyName">Parameter of type System.string for tablePropertyName</param>
        /// <param name="tablePropertyValue">Parameter of type System.string for tablePropertyValue</param>
        /// <param name="rowPropertyName">Parameter of type System.string for rowPropertyName</param>
        /// <param name="rowPorpertyvalue">Parameter of type System.string for rowPorpertyvalue</param>
        /// <param name="expRowText">Parameter of type System.string for expRowText</param>
        /// <param name="elementAttributeName">Parameter of type System.string for elementAttributeName</param>
        /// <param name="elementAttributeValue">Parameter of type System.string for elementAttributeValue</param>
        /// <returns>Parameter of type OpenQA.IwebElement for rowElement</returns>
        public static IWebElement GetRowElementFromHtmlTable(this IWebDriver webDriver, int pageIdNumber, string nextPageBtnPropertyName,
            string nextPageBtnPropertyValue, string tablePropertyName, string tablePropertyValue, string rowPropertyName, string rowPorpertyvalue, string expRowText, string elementAttributeName, string elementAttributeValue)
        {
            text = string.Empty;
            childElement = null;
            IWebElement tableElement = null;
            IList<IWebElement> trCollection = null;
            //Capturing the error if any using try-catch
            try
            {
                switch (tablePropertyName.ToUpper())
                {

                    case "NAME":
                        tableElement = SeleniumHelper.FindElementByName(webDriver, tablePropertyValue);
                        break;
                    case "CLASSNAME":
                        tableElement = SeleniumHelper.FindElementByClass(webDriver, tablePropertyValue);
                        break;
                    case "XPATH":
                        tableElement = SeleniumHelper.FindElementByXpath(webDriver, tablePropertyValue);
                        break;
                    case "ID":
                    default:
                        tableElement = SeleniumHelper.FindElementById(webDriver, tablePropertyValue);
                        break;
                }
                //Piece of code which should be executed before loop starts  
                Thread.Sleep(2000);
                //Collecting total no fo row elements for a page     
                switch (rowPropertyName.ToUpper())
                {

                    case "NAME":
                        trCollection = tableElement.FindElements(By.Name(rowPorpertyvalue));
                        break;
                    case "CLASSNAME":
                        trCollection = tableElement.FindElements(By.ClassName(rowPorpertyvalue));
                        break;
                    case "XPATH":
                        trCollection = tableElement.FindElements(By.XPath(rowPorpertyvalue));
                        break;
                    case "TAGNAME":
                        trCollection = tableElement.FindElements(By.TagName(rowPorpertyvalue));
                        break;
                    case "ID":
                    default:
                        trCollection = tableElement.FindElements(By.Id(rowPorpertyvalue));
                        break;
                }

                for (int rowIndex = 0; rowIndex <= trCollection.Count - 1; rowIndex++)
                {
                    if (expRowText != "")
                    {
                        if (trCollection[rowIndex].Text.ToUpper().Contains(expRowText.ToUpper().Trim()))
                        {
                            return trCollection[rowIndex];
                        }
                        else if (pgeid != pageIdNumber && rowIndex == trCollection.Count - 1)
                        {
                            if (pageIdNumber == 0)
                            {
                                return null;
                            }
                            switch (nextPageBtnPropertyName.ToUpper())
                            {

                                case "NAME":
                                    if (ClickOnElementByName(webDriver, nextPageBtnPropertyValue) == false)
                                    {
                                        return GetRowElementFromHtmlTable(webDriver, pageIdNumber, nextPageBtnPropertyName,
                                            nextPageBtnPropertyValue, tablePropertyName, tablePropertyName, rowPropertyName, rowPorpertyvalue, expRowText, elementAttributeName, elementAttributeValue);
                                    }
                                    break;
                                case "LINKTEXT":
                                    if (ClickOnElementByLinkText(webDriver, nextPageBtnPropertyValue) == false)
                                    {
                                        return GetRowElementFromHtmlTable(webDriver, pageIdNumber, nextPageBtnPropertyName,
                                            nextPageBtnPropertyValue, tablePropertyName, tablePropertyName, rowPropertyName, rowPorpertyvalue, expRowText, elementAttributeName, elementAttributeValue);
                                    }
                                    break;
                                case "XPATH":
                                default:
                                    if (ClickOnElementByXpath(webDriver, nextPageBtnPropertyValue) == false)
                                    {
                                        return GetRowElementFromHtmlTable(webDriver, pageIdNumber, nextPageBtnPropertyName,
                                            nextPageBtnPropertyValue, tablePropertyName, tablePropertyName, rowPropertyName, rowPorpertyvalue, expRowText, elementAttributeName, elementAttributeValue);
                                    }
                                    break;
                            }
                        }
                    }
                    else if (elementAttributeName != "")
                    {
                        if (trCollection[rowIndex].GetAttribute(elementAttributeName) == elementAttributeValue)
                        {
                            return trCollection[rowIndex];
                        }
                    }

                }
            }
            catch (Exception e)
            {
                e.GetType();
                return null;
            }
            finally
            {
                pgeid = 1;
            }
            return null;
        }
        #endregion 

        #region GetElementFromRowElement
        /// <summary>
        /// Public methid which includes logic related to get the element from the specified cell in a row
        /// To retrieve the Image kind of elements it is mandatory to pass its attributes
        /// </summary>
        /// <param name="webDriver">Parameter of type OpenQA.IWebDriver</param>
        /// <param name="rowElement">Parameter of type OpenQA.IWebElement</param>
        /// <param name="type">Parameter of type System.String</param>
        /// <param name="tagNameValue">Parameter of type System.string</param>
        /// <param name="attributeName">Parameter of type System.string</param>
        /// <param name="attributeValue">Parameter of type System.string</param>
        /// <param name="expCellText">Parameter of type System.string</param>
        /// <returns>Parameter of type OpenQA.IWebElement</returns>
        public static IWebElement GetElementFromRowElement(this IWebDriver webDriver, IWebElement rowElement, string type, string tagNameValue, string attributeName, string attributeValue, string expCellText)
        {
            IList<IWebElement> tdCollection = rowElement.FindElements(By.TagName("td"));
            for (int tdIndex = 0; tdIndex <= tdCollection.Count - 1; tdIndex++)
            {
                try
                {
                    switch (type.ToUpper())
                    {
                        case "LINK":
                            if (tdCollection[tdIndex].FindElement(By.TagName(tagNameValue)).Text.ToUpper().Trim() == expCellText.ToUpper().Trim())
                            {
                                return tdCollection[tdIndex].FindElement(By.TagName(tagNameValue));
                            }
                            break;

                        case "IMAGE":

                            if (tdCollection[tdIndex].FindElement(By.TagName(tagNameValue)).GetAttribute(attributeName).ToUpper().Trim() == attributeValue.ToUpper().Trim())
                            {
                                return tdCollection[tdIndex].FindElement(By.TagName(tagNameValue));
                            }
                            break;

                        case "TEXT":
                            string ccc = tdCollection[tdIndex].FindElement(By.TagName(tagNameValue)).GetAttribute(attributeName).ToUpper().Trim();
                            if (tdCollection[tdIndex].FindElement(By.TagName(tagNameValue)).GetAttribute(attributeName).ToUpper().Trim() == attributeValue.ToUpper().Trim())
                            {
                                return tdCollection[tdIndex].FindElement(By.TagName(tagNameValue));
                            }
                            break;

                        case "NONE":
                        default:
                            if (tdCollection[tdIndex].Text.ToUpper().Trim() == expCellText.ToUpper().Trim())
                            {
                                return tdCollection[tdIndex];
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    e.GetType();
                }


            }
            return null;
        }
        #endregion 

        #region Exit
        public static bool Exit(string expText)
        {
            if (text.ToUpper() != expText.ToUpper())
            {
                return false;
            }
            return true;
        }
        #endregion

    }
}
