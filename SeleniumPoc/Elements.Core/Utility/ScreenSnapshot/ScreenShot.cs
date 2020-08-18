namespace Elements.Core.Utility.ScreenSnapshot
{
    #region Import Namespaces
    using System.Configuration;
    using System.IO;
    using OpenQA.Selenium;
    using System;
    #endregion

    public static class ScreenShot
    {
        #region Methods
        /// <summary>
        /// This method used to capture snap shot
        /// </summary>
        /// <param name="o">instance of web driver</param>
        /// <param name="fileName">Specify the file name for screen shot</param>  
        public static void CaptureSnapshot(object o, string fileName)
        {
            string driverInstance = o.GetType().ToString();
            IWebDriver webDriver = (IWebDriver)o;
            string directoryPath = GetApplicationScreenshotPath() + DateTime.Now.ToString("MM.dd.yyyy") + "\\";
            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            if (Directory.Exists(directoryPath))
            {
                ss.SaveAsFile(directoryPath + fileName + ".Png", ScreenshotImageFormat.Png);
                ss.ToString();
            }
            else
            {
                Directory.CreateDirectory(directoryPath);
                ss.SaveAsFile(directoryPath + fileName + ".Png", ScreenshotImageFormat.Png);
                ss.ToString();
            }
        }
        #endregion

        #region private methods
        /// <summary>
        /// method to get the relative path
        /// </summary>
        /// <returns>the relative path</returns>
        private static string GetRelativePath()
        {
            var x = new DirectoryInfo(Directory.GetCurrentDirectory());
            var result = x.Parent.Parent.Parent;
            return result.FullName.ToString();
        }

        /// <summary>
        /// method to get the screen shot folder path
        /// </summary>
        /// <returns>the screen shot folder path</returns>
        private static string GetApplicationScreenshotPath()
        {
            return GetRelativePath() + ConfigurationManager.AppSettings.Get("ScreenshotPath");
        }
        #endregion
    }
}
