namespace Elements.Pages.Enums
{
    #region Import Namespaces
    using System.Reflection;
    #endregion

    public class StringValue : System.Attribute
    {
        public string Value { get; private set; }

        public StringValue(string value)
        {
            Value = value;
        }
    }
    public static class ExtensionMethods
    {

        public static string GetStringValue(this System.Enum value)
        {
            string stringValue = value.ToString();
            System.Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValue[] attrs = fieldInfo.GetCustomAttributes(typeof(StringValue), false) as StringValue[];
            if (attrs.Length > 0)
            {
                stringValue = attrs[0].Value;
            }
            return stringValue;
        }
    }
    public static class RegistryTypes
    {
        public enum EntryType
        {
            [StringValue("Utgående post/Outbound")]
            OutgoingType,
            [StringValue("Internt notat med oppfølging/Internal")]
            InternalNoteMedType,
            [StringValue("Internt notat uten oppfølging/internal")]
            InternalNoteUtenType,
            [StringValue("Saksframlegg/Case draft")]
            CaseDraftType,
            [StringValue("Inngående/Incoming")]
            IncomingType,
            [StringValue("Dokumentpost i saksmappe")]
            DocumentPostType,
            [StringValue("Basisregistrering")]
            BasicRegistrationType,
            [StringValue("Registrering")]
            RegistrationType
        };
    }
    /// <summary>
    /// Select Attachment options
    /// </summary>
    public static class AttachmentType
    {
        public enum AttachType
        {
            [StringValue("Document template")]
            DocumentTemplate,
            [StringValue("File")]
            File,
            [StringValue("Message")]
            Message
        };
    }
    /// <summary>
    /// Select Document Template type
    /// </summary>
    public static class DocumentTemplateType
    {
        public enum TemplateType
        {
            [StringValue("Dokumentmal")]
            Dokumentmal,
            [StringValue("Standardbrev")]
            Standardbrev
        };
    }

    /// <summary>
    /// Select Document sub type
    /// </summary>
    public static class DocumentSubType
    {
        public enum DocumentType
        {
            [StringValue("Brev - Word")]
            BrevDocument,
            [StringValue("Standard brev")]
            Standardbrev,
            [StringValue("E-post")]
            EPost
        };
    }

    /// <summary>
    /// Mark as Read/Unread in Registry Entry
    /// </summary>
    public static class SelectRegistryEntry
    {
        public enum MarkAs
        {
            [StringValue("Read")]
            Read,
            [StringValue("UnRead")]
            Unread
        };
    }

    public static class ApplicationModules
    {
        public enum Module
        {
            // Elements 2.0 Name
            [StringValue("Record Management")]
            Saksbehandling,
            [StringValue("Meeting")]
            Møtemodul,
            [StringValue("Administrator")]
            Systemadministrasjon,
            [StringValue("eBuildingCase")]
            eByggesak
        };
    }
    public static class MeetingDocumentList
    {
        public enum MeetingDocListValues
        {
            [StringValue("Møteprotokoll")]
            MeetingProtocol,
            [StringValue(" Møteprotokoll umiddelbart godkjente saker Meeting")]
            MeetingProtocolApprovedInMeeting,
            [StringValue("Møteinnkalling")]
            MeetingNotice,
            [StringValue("Saksliste")]
            CaseList,
            [StringValue("Saksfremlegg")]
            CaseDraft,
            [StringValue("Forside")]
            FirstPageMeetingNotice,
            [StringValue("Notat")]
            Notat
        };
    }

    public static class MeetingListTab
    {
        public enum ListTabValues
        {
            [StringValue("Case protocols")]
            Caseprotocols,
            [StringValue("Meeting documents")]
            MeetingDocuments,
            [StringValue("Case documents")]
            Casedocuments
        };
    }

    public static class MeetingTabNames
    {
        public enum TabControl
        {
            [StringValue("Case list")]
            CaseList,
            [StringValue("Documents")]
            Documents,
            [StringValue("Attendance")]
            Attendance,
            [StringValue("Distributionlist")]
            Distributionlist
        };
    }

    public static class AttendeeSecretaryNames
    {
        public enum SecretaryNames
        {
            [StringValue("guilt")]
            guilt,
            [StringValue("steinar Abrahamsen")]
            steinar,
            [StringValue("Kiran Kumar")]
            Kiran,
            [StringValue("K Kumar")]
            KKumar
        };
    }

    public static class MeetingSortBy
    {
        public enum MenuNames
        {
            [StringValue("Type")]
            SortByType,
            [StringValue("No.")]
            SortByNo,
            [StringValue("Casetitle")]
            SortByCaseTitle
        };
    }

    public static class ReportFormat
    {
        public enum FormatNames
        {
            [StringValue("PDF")]
            PDF,
            [StringValue("HTML")]
            HTML,
            [StringValue("Word")]
            Word,
            [StringValue("Excel")]
            Excel,
            [StringValue("Text")]
            Text
        };
    }
}
