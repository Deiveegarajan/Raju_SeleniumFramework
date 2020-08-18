namespace Elements.Core.Utility.ScreenRecorder
{
    #region Import Namespace
    using Microsoft.Expression.Encoder.ScreenCapture;
    using System.Configuration;
    using System.IO;
    #endregion

    public static class ScreenRecorder
    {
        #region Declarations

        private static ScreenCaptureJob scj;

        #endregion

        #region StartRecording
        /// <summary>
        /// Method to stop the screen capture
        /// </summary>
        /// <param name="fileName">filename to save the recording</param>
        public static void StartRecording(string fileName)
        {
            // Create a instance of ScreenCaptureJob
            scj = new ScreenCaptureJob
            {

                // Specify the path & file name in which you want to save         
                OutputScreenCaptureFileName = GetApplicationRecordingPath() + fileName + ".wmv"
            };

            // Start the Screen Capture Job
            scj.Start();
        }

        #endregion

        #region StopRecording
        /// <summary>
        /// Method to stop the recording
        /// </summary>
        public static void StopRecording()
        {
            //Stop the Screen Capturing
            scj.Stop();
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
        private static string GetApplicationRecordingPath()
        {
            return GetRelativePath() + ConfigurationManager.AppSettings.Get("RecordingPath");
        }
        #endregion
    }
}
