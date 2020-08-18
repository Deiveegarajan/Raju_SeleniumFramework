namespace Elements.Core.BaseClass
{
    #region Import Namespaces
    using System;
    using System.Configuration;
    using System.IO;
    using System.Xml;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Safari;
    using System.Windows.Automation;
    using System.Threading;
    using System.Drawing;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Collections;
    using log4net;
    using Elements.Core.Utility.CommonUtils;
    using System.Windows.Forms;
    #endregion

    public class Initialize
    {
        static string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
        static string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
        protected ILog logger = LogManager.GetLogger(typeof(Initialize));

        #region Properties
        /// <summary>
        /// Gets or sets the value of the CurrentWebDriver of type OpenQA.Selenium.IWebDriver.
        /// </summary>
        //public static IWebDriver CurrentWebDriver
        //{
        //    get;
        //    set;
        //}

        private static IWebDriver _driver;
        public static IWebDriver CurrentWebDriver
        {
            get
            {
                CommonUtils.PlayWait(CommonUtils.DelayBetweenActions);
                return _driver;
            }

            set
            { _driver = value; }
        }

        //Declaring global variables
        public static string timerValue;
        public static int iterationCount = 1;
        public static string browserType;
        #endregion

        #region Methods
        /// <summary>
        /// Public method which includes logic related to StartBrowser.
        /// </summary>
        /// <returns>Returns object of type OpenQA.Selenium.IWebDriver.</returns>
        public static IWebDriver StartBrowser()
        {
            log4net.Config.XmlConfigurator.Configure();

            if (iterationCount <= 1)
            {
                timerValue = (DateTime.Now).ToString().Replace(":", ".");
                if (timerValue.Contains(@"/"))
                {
                    timerValue = timerValue.Replace(@"/", "-");
                }
                iterationCount = iterationCount + 1;
            }

            browserType = ConfigurationManager.AppSettings.Get("Browser");
            switch (browserType.ToUpper())
            {
                case "IE":
                    #region ClearCache
                    CommonUtils.ClearCache();
                    try { CommonUtils.KillProcess("iexplore"); } catch { }
                    System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 4351");
                    #endregion
                    string ieDriverPath = GetApplicationDriversPath();
                    InternetExplorerOptions options = new InternetExplorerOptions
                    {
                        IgnoreZoomLevel = true,
                        UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore
                        //UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Ignore
                    };
                    CurrentWebDriver = new InternetExplorerDriver(options);
                    CurrentWebDriver.Manage().Cookies.DeleteAllCookies();
                    break;
                case "CHROME":
                default:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    if (ConfigurationManager.AppSettings.Get("HeadLess").ToLowerInvariant() == "yes")
                    {
                        chromeOptions.AddArgument("--headless");
                        chromeOptions.AddArgument("window-size=" + screenWidth + "x" + screenHeight);
                    }
                    chromeOptions.AddArguments("download.prompt_for_download");
                    chromeOptions.AddArguments("disable-popup-blocking");
                    //To Disable any browser notifications
                    chromeOptions.AddArguments("--disable-notifications");
                    //To disable yellow strip info bar which prompts info messages
                    chromeOptions.AddArguments("disable-infobars");

                    //Map<String, Object> prefs = new HashMap<String, Object>();
                    //prefs.put("profile.default_content_settings.popups", 0);
                    
                    //prefs.put("credentials_enable_service", false);
                    //prefs.put("password_manager_enabled", false);
                    //chromeOptions.SetLoggingPreference("prefs", prefs);

                    chromeOptions.AddArguments("disable-extensions");
                    chromeOptions.AddArguments("chrome.switches", "--disable-extensions");
                    chromeOptions.AddArguments("--test-type");
                   
                    CurrentWebDriver = new ChromeDriver(chromeOptions);
                    CurrentWebDriver.Manage().Cookies.DeleteAllCookies();
                    break;                
            }

            CurrentWebDriver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(30));
            CurrentWebDriver.Manage().Window.Maximize();
            GlobalVariables.WebDriver = CurrentWebDriver;

            return CurrentWebDriver;
        }

        /// <summary>
        /// Public method which includes logic related to Create the log
        /// </summary>
        /// <param name="LogText">Parameter of type System.string for LogText</param>
        public static void CreateLog(string LogText)
        {

            try
            {
                //Capturing the directory path
                string directoryPath = GetApplicationLogResultsPath() + browserType + "\\";
                //Verifying the correct path
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                // Create a writer and open the file:
                StreamWriter log;

                if (!File.Exists(directoryPath + timerValue + ".txt"))
                {
                    log = new StreamWriter(directoryPath + timerValue + ".txt");
                }
                else
                {

                    log = File.AppendText(directoryPath + timerValue + ".txt");
                }

                // Write to the file:
                log.WriteLine(DateTime.Now);
                log.WriteLine(LogText);
                log.WriteLine();

                // Close the stream:
                log.Close();

            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }

        /// <summary>
        /// Public method which includes logic related to get the data from Xml document
        /// </summary>
        /// <param name="expParentNodeText">Parameter of type System.string for expParentNodeText</param>
        /// <param name="expChildNodeText">Parameter of type System.string for expChildNodeText</param>
        /// <returns>retun node text of typr System.string</returns>
        public static string ReadNodeContentFromXml(string expParentNodeText, string expChildNodeText)
        {
            //string xmlDocumentPath = ConfigurationManager.AppSettings.Get("XmlDocPath");
            string xmlDocumentPath = GetApplicationXmlDocPath();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlDocumentPath);
            XmlNodeList nodes = (xmlDoc.SelectSingleNode("OR")).ChildNodes;
            for (int index = 0; index <= nodes.Count - 1; index++)
            {
                if (nodes[index].Name.ToUpper() == expParentNodeText.ToUpper())
                {
                    XmlNodeList childNodes = nodes[index].ChildNodes;
                    for (int childIndex = 0; childIndex <= childNodes.Count - 1; childIndex++)
                    {
                        if (childNodes[childIndex].Name.ToUpper() == expChildNodeText.ToUpper())
                        {
                            return childNodes[childIndex].InnerText;
                        }
                    }
                }
            }
            return null;

        }

        /// <summary>
        /// Public method which includes logic related to Write the test results to excel file
        /// </summary>
        /// <param name="scenarioName">Parameter of type System.string for scenarioName</param>
        /// <param name="status">Parameter of type System.string for status</param>
        /// <param name="diffTime">Parameter of type System.TimeSpan for diffTime</param>
        public static void WriteTestResultsToExcelFile(string scenarioName, string status, TimeSpan diffTime)
        {
            Excel.Application app = null;
            Excel.Workbooks workBooks = null;
            Excel.Workbook workBook = null;
            Excel.Worksheet workSheet = null;
            ArrayList values = new ArrayList();
            //string excelFilePath = ConfigurationManager.AppSettings.Get("ExcelReportPath");
            string excelFilePath = GetApplicationExcelReportPath();
            try
            {
                object misValue = System.Reflection.Missing.Value;
                app = new Excel.Application();
                app.Visible = false;
                workBooks = app.Workbooks;
                workBook = workBooks.Open(excelFilePath, misValue, misValue, misValue, misValue, misValue,
                    misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
                workSheet = (Excel.Worksheet)workBook.ActiveSheet;
                Excel.Range range = workSheet.UsedRange;
                int colCount = range.Columns.Count;
                int rowCount = range.Rows.Count;
                for (int rowIndex = 1; rowIndex <= rowCount; rowIndex++)
                {
                    for (int colIndex = 1; colIndex <= colCount; colIndex++)
                    {
                        if ((range.Cells[rowIndex, colIndex]).Value2 != null)
                        {
                            string val = (range.Cells[rowIndex, colIndex]).Value2.ToString();
                            switch (val.ToUpper())
                            {
                                case "TESTSCENARIO":
                                    for (int index = 1; index <= rowCount; index++)
                                    {
                                        if ((range.Cells[index + 1, colIndex]).Value2 == null)
                                        {
                                            if (!values.Contains(scenarioName))
                                            {
                                                range.Cells[index + 1, colIndex] = scenarioName;
                                            }

                                        }
                                        else
                                        {
                                            values.Add((range.Cells[index + 1, colIndex]).Value2.ToString());
                                        }

                                    }
                                    break;
                                case "RESULTS":
                                    for (int index = 1; index <= rowCount; index++)
                                    {
                                        if ((range.Cells[index + 1, colIndex - 1]).Value2 != null && (range.Cells[index + 1, colIndex - 1]).Value2.ToString() == scenarioName)
                                        {
                                            range.Cells[index + 1, colIndex] = status;
                                            if (status.ToUpper() == "PASS")
                                            {
                                                (range.Cells[index + 1, colIndex] as Excel.Range).Interior.Color = Color.Green.ToArgb();
                                                (range.Cells[index + 1, colIndex] as Excel.Range).Font.Bold = true;
                                            }
                                            else if (status.ToUpper() == "FAIL")
                                            {
                                                (range.Cells[index + 1, colIndex] as Excel.Range).Interior.Color = Color.Purple.ToArgb();
                                                (range.Cells[index + 1, colIndex] as Excel.Range).Font.Bold = true;
                                            }
                                        }
                                    }
                                    break;
                                case "DURATION":
                                    for (int index = 1; index <= rowCount; index++)
                                    {
                                        if ((range.Cells[index + 1, colIndex - 2]).Value2 != null && (range.Cells[index + 1, colIndex - 2]).Value2.ToString() == scenarioName)
                                        {
                                            range.Cells[index + 1, colIndex] = diffTime.ToString();
                                        }
                                    }
                                    break;
                            }

                        }

                    }
                }

            }
            catch (Exception e)
            {
                e.GetType();
            }

            workBook.Save();
            workBook.Close();
            app.Quit();
            workSheet = null;
            workBook = null;
            workBooks = null;
            app = null;
        }

        /// <summary>
        /// Public method which includes logic related to handle the dialog popup
        /// </summary>
        public static Boolean HandleDialogWindow(string parentElementPropertyValue, string dialogElementPropertyValue,
            string comboboxPropertyValue, string documentPath, string openBtnPropertyValue)
        {
            AutomationElement rootElement = AutomationElement.RootElement;
            //Verifying the root Element
            if (rootElement == null)
            {
                CreateLog("HandleDialogWindow:Root element was not found");
                return false;
            }

            //Verifying the dialog box
            Condition parentElementCondition = new PropertyCondition(AutomationElement.NameProperty, parentElementPropertyValue);
            AutomationElement parentElement = rootElement.FindFirst(TreeScope.Children, parentElementCondition);
            if (parentElement == null)
            {
                CreateLog("HandleDialogWindow:Parent dialog winodow was not found");
                return false;
            }

            Condition dialogElementCondition = new PropertyCondition(AutomationElement.NameProperty, dialogElementPropertyValue);
            AutomationElement dialogElementchild = parentElement.FindFirst(TreeScope.Children, dialogElementCondition);
            if (dialogElementchild == null)
            {
                CreateLog("HandleDialogWindow:Child dialog winodow was not found");
                return false;
            }

            //Verifying the combobox
            Condition comboboxCondition = new PropertyCondition(AutomationElement.ClassNameProperty, comboboxPropertyValue);
            AutomationElement combobox = dialogElementchild.FindFirst(TreeScope.Children, comboboxCondition);
            if (combobox == null)
            {
                CreateLog("HandleDialogWindow:Combobox control was not found");
                return false;

            }
            //combobox.SetFocus();
            ValuePattern pattren = combobox.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            pattren.SetValue(documentPath);
            //Verifying the combobox
            Condition btnOpenCondition = new PropertyCondition(AutomationElement.NameProperty, openBtnPropertyValue);
            AutomationElement btnOPen = dialogElementchild.FindFirst(TreeScope.Children, btnOpenCondition);
            if (btnOPen == null)
            {
                CreateLog("HandleDialogWindow:Open button control was not found");
                return false;

            }
            //clicking on open button
            InvokePattern invokePattren = btnOPen.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            invokePattren.Invoke();
            return true;
        }

        /// <summary>
        /// Public method which includes logic related to handle the dialog popup
        /// </summary>
        public static Boolean HandleReportWindow(string parentElementPropertyValue, string dialogElementPropertyValue,
            string titleBarElement, string closeBtnPropertyValue)
        {
            AutomationElement rootElement = AutomationElement.RootElement;
            //Verifying the root Element
            if (rootElement == null)
            {
                CreateLog("HandleReportWindow:Root element was not found");
                return false;
            }

            //Verifying the dialog box
            Condition parentElementCondition = new PropertyCondition(AutomationElement.NameProperty, parentElementPropertyValue);
            AutomationElement parentElement = rootElement.FindFirst(TreeScope.Children, parentElementCondition);
            if (parentElement == null)
            {
                CreateLog("HandleReportWindow:Parent dialog winodow was not found");
                return false;
            }

            Condition dialogElementCondition = new PropertyCondition(AutomationElement.NameProperty, dialogElementPropertyValue);
            AutomationElement dialogElementchild = parentElement.FindFirst(TreeScope.Children, dialogElementCondition);
            if (dialogElementchild == null)
            {
                CreateLog("HandleReportWindow:Child dialog winodow was not found");
                return false;
            }
            //dialogElementchild.

            Condition titleBarElementCondition = new PropertyCondition(AutomationElement.AutomationIdProperty, titleBarElement);
            AutomationElement titleBarElementchild = dialogElementchild.FindFirst(TreeScope.Children, titleBarElementCondition);
            if (titleBarElementchild == null)
            {
                CreateLog("HandleReportWindow:title bar was not found");
                return false;
            }
            //Close button
            Condition btnCloseCondition = new PropertyCondition(AutomationElement.NameProperty, closeBtnPropertyValue);
            AutomationElement btnClose = titleBarElementchild.FindFirst(TreeScope.Children, btnCloseCondition);
            if (btnClose == null)
            {
                CreateLog("HandleReportWindow:Close button control was not found");
                return false;

            }
            //clicking on open button
            InvokePattern invokePattren = btnClose.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            invokePattren.Invoke();
            return true;
        }

        /// <summary>
        /// Gets the Application Relative path of the assemble where the current code is executed
        /// </summary>
        /// <returns>path in string format</returns>
        private static string GetRelativePath()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo fileInfo = new System.IO.FileInfo(path);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(fileInfo.Directory.ToString());
            stringBuilder.Replace(fileInfo.Directory.Parent.ToString(), "");
            stringBuilder.Replace(fileInfo.Directory.Name, "");
            stringBuilder.Replace("\\TestResults\\", "");
            return stringBuilder.ToString();

            //var x = new DirectoryInfo(Directory.GetCurrentDirectory());
            //var result = x.Parent.Parent.Parent.Parent;
            //return result.FullName.ToString();
        }

        /// <summary>
        /// Gets the Applications DriversPath
        /// </summary>
        /// <remakrs>replacment for appconfig key <add key="DriversPath" value=""/></remakrs>
        /// <returns>path in string format</returns>
        private static string GetApplicationDriversPath()
        {
            return GetRelativePath() + ConfigurationManager.AppSettings.Get("DriversPath");
        }

        /// <summary>
        /// Gets the Applications LogResultsPath
        /// </summary>
        /// <remakrs>replacment for appconfig key <add key="LogResultsPath" value=""/></remakrs>
        /// <returns>path in string format</returns>
        private static string GetApplicationLogResultsPath()
        {
            return GetRelativePath() + ConfigurationManager.AppSettings.Get("LogResultsPath");
        }

        /// <summary>
        /// Gets the Applications XmlDocPath
        /// </summary>
        /// <remakrs>replacment for appconfig key <add key="XmlDocPath" value=""/></remarks>
        /// <returns>path in string format</returns>
        private static string GetApplicationXmlDocPath()
        {
            return GetRelativePath() + ConfigurationManager.AppSettings.Get("XmlDocPath");
        }

        /// <summary>
        /// Gets the Applications Reports Path
        /// </summary>
        /// <remakrs>replacment for appconfig key <add key ="ExcelReportPath" value=""/></remakrs>
        /// <returns>path in string format</returns>
        private static string GetApplicationExcelReportPath()
        {
            return GetRelativePath() + ConfigurationManager.AppSettings.Get("ExcelReportPath") + "_" + browserType + ".xls";
        }

        #endregion
    }
}
