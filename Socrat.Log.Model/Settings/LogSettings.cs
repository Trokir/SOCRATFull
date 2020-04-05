using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Log.Model.Settings
{
    public static class LogSettings
    {
        
        public static class Read
        {
            public static string StoredProc = "[dbo].[P_LogList]";
       }

        public static class Write
        {
            public static string StoredProc = "[dbo].[P_LogInsert]";
        }

        public static class Parameters
        {
            public static string MessageType = "@MessageType";
            public static string DateFrom = "@DateFrom";
            public static string DateTo = "@DateTo";
            public static string Application = "@Application";
            public static string User = "@User";
            public static string MachineName = "@MachineName";
            public static string LogType ="@LogType";
            public static string Date ="@DateT";
            public static string Message = "@Message";
            public static string Header = "@Header";
            public static string AppName = "@Application";
            public static string ExMessage = "@ExMessage";
            public static string ExSourse = "@ExSource";
            public static string ExStackTrace = "@ExStackTrace";
            public static string ExHelpLink = "@ExHelpLink";
            public static string Version = "@version";
        }

        public static class Fields
        {
            public static string Id = "Id";
            public static string LogType = "LogType";
            public static string Message = "Message";
            public static string Date = "DateT";
            public static string UserId = "l_UserId";
            public static string UserName = "UserLogin";
            public static string Header = "Header";
            public static string Mashine = "MachineName";
            public static string AppName = "AppName";
            public static string ExMessage = "ExMessage";
            public static string ExSource = "ExSource";
            public static string ExStackTrace = "ExStackTrace";
            public static string HelpLink = "HelpLink";
            public static string Version = "Version";
        }
    }
}
