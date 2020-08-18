namespace Elements.Core.Utility.CommonUtils
{
    #region Import Namespace
    using OpenQA.Selenium;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using Elements.Core.BaseClass;
    using System.Diagnostics;
    using System.Threading;
    using System.Configuration;
    using System.IO;
    using OpenQA.Selenium.Support.UI;
    using Elements.Core.Helper;

    // using OpenQA.Selenium.Support.UI;
    #endregion

    public static class CommonUtils
    {
        #region GetDescriptionFromEnum
        /// <summary>
        /// Method to get Enum Description value
        /// </summary>
        /// <param name="enumValue">specify the enum</param>
        /// <returns>description of the enum</returns>
        public static string GetDescriptionFromEnum(object enumValue)
        {
            string strDescription = string.Empty;
            var enumType = enumValue.GetType().GetField(enumValue.ToString());

            if (enumType != null)
            {
                object[] attrs = enumType.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return strDescription;
        }
        #endregion

        #region GetSelectedValue
        /// <summary>
        /// Method to get the selected value from the dropdown
        /// </summary>
        /// <param name="webDriver">instance of web driver</param>
        /// <param name="webElement">instance of wb element</param>
        /// <returns></returns>
        public static string GetSelectedValue(object webElement)
        {
            var value = (string)((IJavaScriptExecutor)Initialize.CurrentWebDriver).ExecuteScript("return arguments[0].options[arguments[0].selectedIndex].text;", webElement);
            return value;
        }
        #endregion

        #region GenerateRandomNumber

        /// <summary>
        /// Method to generate a random string
        /// </summary>
        /// <param name="length">provide the length of the random string to be returned</param>
        /// <returns>Random Number</returns>
        public static string GenerateRandomNumber(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        /// <summary>
        /// Generates Random Number between range provided.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandomNumber(int min = int.MinValue, int max = int.MaxValue)
        {
            lock (syncLock)
            {
                // synchronize
                return getrandom.Next(min, max);
            }
        }
        #endregion

        #region Wait for page to load 

        #region Wait for page to load 
        /// <summary>
        /// Wait until element is clickable
        /// </summary>
        /// <param name="Driver"></param>
        /// <param name="WebElement">Elements to be clicked</param>
        /// <param name="timeout">Max time to wait</param>
        public static void ClickAndWaitForPageToLoad(IWebDriver Driver, IWebElement WebElement, int timeout = 30)
        {
            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(WebElement));
        }
        #endregion

        #endregion

        /// <summary>
        /// Throw error message and break the TC. This method can be used in combination of Assert Messages.
        /// </summary>
        /// <param name="errorMessage">Error Message to be displayed</param>
        public static void ThrowExceptionAndBreakTC(string errorMessage = "Error")
        {
            throw new Exception(errorMessage);
        }

        /// <summary>
        /// To Kill the Process
        /// </summary>
        public static void ProcessKill(string ProcessName)
        {
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
            }
        }

        /// <summary>
        /// We ned to kill Internet explorer and Firefox to stop them locking files
        /// </summary>
        /// <param name="ProcessName"></param>
        public static void KillProcess(string ProcessName)
        {
            ProcessName = ProcessName.ToLower();
            foreach (Process P in Process.GetProcesses())
            {
                if (P.ProcessName.ToLower().StartsWith(ProcessName))
                    P.Kill();
            }
        }

        public static void ClearCache()
        {
            string IE1 = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + @"\AppData\Local\Microsoft\Intern~1";
            string IE2 = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + @"\AppData\Local\Microsoft\Windows\History";
            string IE3 = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + @"\AppData\Local\Microsoft\Windows\Tempor~1";
            string IE4 = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + @"\AppData\Roaming\Microsoft\Windows\Cookies";
            string IE5 = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + @"\AppData\Local\Microsoft\Windows\Caches";
            string IE6 = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + @"\AppData\Local\Microsoft\WebsiteCache";
            string IE7 = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + @"\AppData\LocalLow\Microsoft\CryptnetUrlCache";
            string Flash = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + @"\AppData\Roaming\Macromedia\Flashp~1";
            var InternetCache = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            var Cookies = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            //var Temp = Environment.ExpandEnvironmentVariables("%TEMP%");

            //try { KillProcess("iexplore"); } catch { }
            ClearAllSettings(new string[] { IE1, IE2, IE3, IE4, IE5, IE6, IE7, Flash, InternetCache, Cookies });
        }

        private static void ClearAllSettings(string[] ClearPath)
        {
            foreach (string HistoryPath in ClearPath)
            {
                if (Directory.Exists(HistoryPath))
                {
                    DoDelete(new DirectoryInfo(HistoryPath));
                }

            }
        }

        private static void DoDelete(DirectoryInfo folder)
        {
            try
            {

                foreach (FileInfo file in folder.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch
                    { }

                }
                foreach (DirectoryInfo subfolder in folder.GetDirectories())
                {
                    DoDelete(subfolder);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Wait time in milliseconds
        /// </summary>
        public static int WaitTime = Convert.ToInt32(ConfigurationManager.AppSettings.Get("WaitTime"));

        /// <summary>
        /// Wait time in milliseconds between each step executed in TC
        /// </summary>
        public static int DelayBetweenActions = Convert.ToInt32(ConfigurationManager.AppSettings.Get("DelayBetweenEachStep"));

        /// <summary>
        /// DashBoardWait time in milliseconds
        /// </summary>
        public static int DashboardWaitTime = Convert.ToInt32(ConfigurationManager.AppSettings.Get("DashboardWaitTime"));

        /// <summary>
        /// Refresh the current browser
        /// </summary>
        public static void RefreshBrowserWindow(object o)
        {
            string driverInstance = o.GetType().ToString();
            IWebDriver webDriver = (IWebDriver)o;
            webDriver.Navigate().Refresh();
        }

        /// <summary>
        /// Refresh page and wait 5 secs before and 10 secs after refresh
        /// </summary>
        public static void RefreshScreenAndWaitPrePost(object o)
        {
            Thread.Sleep(WaitTime);
            RefreshBrowserWindow(o);
            Thread.Sleep(WaitTime * 2);
        }

        /// <summary>
        /// Wait for milliseconds.
        /// </summary>
        /// <param name="waitTime">Time to wait</param>
        public static void PlayWait(int waitTime)
        {
            Thread.Sleep(waitTime);
        }

        /// <summary>
        /// Wait for milliseconds. Default wait time from app config
        /// </summary>
        public static void PlayWait()
        {
            Thread.Sleep(WaitTime);
        }

        private static string CollapseMenuLocator => "//button[@class='btn btn-md btn-link pull-left btn-menu-toggle']";
        //private static readonly IWebElement ExpandMenuWebElement = MenuControlCollapsedElement(GlobalVariables.WebDriver);
        private static string DashboardElement => "//body[@class='bs responsive']/div[@id='applicationHost']/div[@class='outershell rm-outershell']/div[@id='colorSwitchScope']/div[@class='compose-shell rm-shell']/div[@class='mode-scope']/div[@class='theme-wrap']/div[@class='container bs-container menu-collapsed']/main[@class='main-container']/div[@class='row']/div[@class='col-xs-12 main-content-container menu-collapsed']/div[@class='content-container']/div[@class='content-col menu-collapsed']/div[@class='main-content']/div[@data-bind='compose: $data.activeElement, visible: $data.activeElement() && $data.activeElement().isActive()']/div[@class='dashboard-grid']/div[@class='widget-container grid-stack grid-stack-instance-9517 grid-stack-animate']/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/a[1]";

        public static void ExpandMenu()
        {
            PlayWait();
            IWebElement ExpandMenuWebElement = MenuControlCollapsedElement(GlobalVariables.WebDriver);
            ExpandMenuWebElement.DrawHighlight();
            ExpandMenuWebElement.Click();
        }

        public static IWebElement MenuControlCollapsedElement(object o)
        {
            IWebDriver webDriver = (IWebDriver)o;
            IWebElement collapseElement = SeleniumHelper.FindElementByXpath(webDriver, CollapseMenuLocator);
            return collapseElement;
        }

        public static bool IsMenuControlCollapsed()
        {
            IWebElement ExpandMenuWebElement = MenuControlCollapsedElement(GlobalVariables.WebDriver);
            return (ExpandMenuWebElement != null) ? SeleniumHelper.VerifyIsElementPresent(ExpandMenuWebElement) : false;
        }


    }
}
