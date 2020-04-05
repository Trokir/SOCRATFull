using Socrat.Log.infrastructure;
using Socrat.Log.Model.Settings;
using Socrat.Log.Models;

namespace Socrat.Log.Core
{
    internal class LogSqlWriter : ILogWriter
    {
        public void WriteLog(LogItem le)
        {
            if (le.Ex == null)
            {
                SqlHelper.ExecuteProcedure(LogSettings.Write.StoredProc, new[]
                {
                     SqlHelper.NewInParameter(LogSettings.Parameters.LogType, le.LogType)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.Date, le.DateT)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.Message, le.Message)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.Header, le.Header)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.User, le.User)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.MachineName, le.MachineName)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.AppName, le.Application)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.Version, le.Version)});
            }
            else
            {
                SqlHelper.ExecuteProcedure(LogSettings.Write.StoredProc, new[]
                {
                     SqlHelper.NewInParameter(LogSettings.Parameters.LogType, le.LogType)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.Date, le.DateT)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.Message, le.Message)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.Header, le.Header)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.User, le.User)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.MachineName, le.MachineName)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.Application, le.Application)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.ExMessage, le.Ex.Message)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.ExSourse, le.Ex.Source)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.ExStackTrace, le.Ex.StackTrace)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.ExHelpLink, le.Ex.HelpLink)
                    ,SqlHelper.NewInParameter(LogSettings.Parameters.Version, le.Version)
                });
            }
        }
    }
}
