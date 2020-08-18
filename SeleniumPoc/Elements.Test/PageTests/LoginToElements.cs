namespace Elements.Test.PageTests
{
    #region Import NameSpaces
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using Elements.Core.BaseClass;
    using Elements.Pages.PageObjects;
    using log4net;
    using Elements.Core.Helper;
    using Elements.Core.Utility.CommonUtils;
    using Elements.Pages.Enums;
    using Elements.Core.Utility.ScreenRecorder;
    using System.Threading;
    #endregion

    [TestClass]
    public class LoginToElements : Initialize
    {
        #region Declaration
        /// <summary>
        /// Private Shared variable to hold the value of webDriver.
        /// </summary>
        private static IWebDriver webDriver;
        #endregion

        #region Default Constructors
        public LoginToElements()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Default Constructors

        #region DefaultProperties
        /// <summary>
        /// Private variable to hold the value of testContextInstance
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #endregion

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            webDriver = StartBrowser();
        }
        
        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            if (webDriver != null)
            {
                webDriver.Quit();
                webDriver = null;

            }
        }

        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private static readonly ILog log = LogManager.GetLogger(typeof(LoginToElements));
        //private static readonly ILog Log = LogManager.GetLogger(nameof(LoginToElements));

        #region TestMethods
        [TestMethod]
        public void LoginToElements2_0()
        {
            //ScreenRecorder.StartRecording(TestContext.TestName);
            log.Info("Entering the Method");
            log.Info("Log current method");

            //CreateLog("CreateLog");
            LogFile.CreateLog("CreateLog");

            //Logger logger = new Logger();
            //Log.Info("HTML Logger");
            //Logger.Log = "HTML Logger";

            LoginPage LoginPageObject = new LoginPage(webDriver);
            LoginPageObject.LoginToApplication(ApplicationModules.Module.Saksbehandling.GetStringValue());
            CommonUtils.RefreshScreenAndWaitPrePost(webDriver);


            Thread.Sleep(CommonUtils.WaitTime);
        }
        #endregion
    }
}
