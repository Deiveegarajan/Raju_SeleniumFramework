namespace Elements.Core.Helper
{
    #region Import Namspace
    using System;
    using System.Configuration;
    using System.IO;
    #endregion

    /// <summary>
    /// LogFile class which contains methods CreateLog
    /// </summary>
    public static class LogFile
    {
        public static string dateTime = DateTime.Now.ToString("MM.dd.yyyy");

        #region Methods
        /// <summary>
        /// This method is to Create Log
        /// </summary>
        /// <param name="logText">Specify the Log text to be displayed</param>             
        public static void CreateLog(string logText)
        {
            try
            {
                // Capturing the directory path
                string directoryPath = GetApplicationLogPath();
                // Verifying the correct path
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Create a writer and open the file:
                StreamWriter log;

                if (!File.Exists(directoryPath + "Result" + dateTime + ".txt"))
                {
                    log = new StreamWriter(directoryPath + "Result" + dateTime + ".txt");
                }
                else
                {
                    log = File.AppendText(directoryPath + "Result" + dateTime + ".txt");
                }

                // Write to the file
                log.WriteLine(DateTime.Now);
                log.WriteLine(logText);
                log.WriteLine();

                // Close the stream
                log.Close();
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }
        #endregion

        #region Privatemethods
        /// <summary>
        /// Method to Get the Current directory of Relative path
        /// </summary>
        /// <returns>the relative path</returns>
        private static string GetRelativePath()
        {
            var x = new DirectoryInfo(Directory.GetCurrentDirectory());
            var result = x.Parent.Parent.Parent;
            return result.FullName.ToString();
        }

        /// <summary>
        /// Method to Get the ApplicationDriver path 
        /// </summary>
        /// <returns>the application driver path</returns>
        private static string GetApplicationLogPath()
        {
            return GetRelativePath() + ConfigurationManager.AppSettings.Get("LogPath");
        }

        #endregion Privatemethods
    }
}
