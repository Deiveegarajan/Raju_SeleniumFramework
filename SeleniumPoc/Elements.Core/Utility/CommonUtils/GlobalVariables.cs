namespace Elements.Core.Utility.CommonUtils
{
    #region Import NameSpaces
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium;
    using Elements.Core.Helper;
    using System.Configuration;
    using System.Threading;
    #endregion Import NameSpaces

    /// <summary>
    /// These classes can be used to set Global accessbility
    /// </summary>
    public static class GlobalVariables
    {
        public static IWebDriver WebDriver;
        public static string CaseFolderType;
        public static string CaseTitle = "Case - AutomaticTest";
        public static string RoleType;
        public static bool IsCaseWorkerRole = true;
        public static string DocumentTemplateType = "Dokumentmal";
        public static string DocumentType = "Standard brev";
        public static string ImportRegistryTitle;
        public static string ImportType;
        public static string ImportCaseId;
        public static string CASEQuickMenuOptions;
        public static string CaseValue;
        public static bool SetCaseStatus = false;
        public static string RegistryEntryTitle = "Registry Entry - DocumentType";
        public static string FileFormatValue = "PDF";
        public static string DocumentTitle;
        public static string EditDataStatement = "{Space}Automatic{Space}Test{Space}Edit{Space}Doc";
        public static string SearchUserName = "AA";
        public static string DocumentNameToUpload = "CaseFolder.docx";
        public static string MeetingType;
        public static string ProcessName;
        public static string MeetingTabName;
        public static string NewHandlingTitle = "New Handling for Meeting";
        public static string NewSuggestion = "This is a suggestion proposed by proposer";
        public static string Decision = "Decision taken by the proposed team";
    }
}
