using System;
using System.Collections.Generic;
using System.Data;
using Socrat.Log.Enums;
using Socrat.Log.infrastructure;
using Socrat.Log.Model.Settings;
using Socrat.Log.Models;

namespace Socrat.Log.Core
{
    internal class LogSqlReader : ILogReader
    {
        public List<LogItem> ReadLog(Filter filter, List<LogItem> list = null)
        {
            Filter = filter;
            list = list ?? (new List<LogItem>());
            var dateFrom = new DateTime(filter.DateFrom.Year, filter.DateFrom.Month, filter.DateFrom.Day);
            var dateTo = new DateTime(filter.DateTo.Year, filter.DateTo.Month, filter.DateTo.Day);
            if (dateFrom > dateTo)
            {
                var buffer = dateTo;
                dateTo = dateFrom;
                dateFrom = buffer;
            }
            if (dateFrom == dateTo)
            {
                dateTo = dateTo.AddDays(1);
            }
            var data = new DataTable();
            SqlHelper.FillTable(data, LogSettings.Read.StoredProc, new[]
            {
                 SqlHelper.NewInParameter(LogSettings.Parameters.MessageType ,filter.MessageType)
                ,SqlHelper.NewInParameter(LogSettings.Parameters.DateFrom, dateFrom)
                ,SqlHelper.NewInParameter(LogSettings.Parameters.DateTo, dateTo)
                ,SqlHelper.NewInParameter(LogSettings.Parameters.Application, filter.Application)
                ,SqlHelper.NewInParameter(LogSettings.Parameters.User,filter.User)
                ,SqlHelper.NewInParameter(LogSettings.Parameters.MachineName,filter.MachineName)
            },  CommandType.StoredProcedure);
            foreach (DataRow row in data.Rows)
            {
                MyException ex = null;
                if (!String.IsNullOrEmpty(Convert.ToString(row[LogSettings.Fields.ExMessage])))
                {
                    ex = new MyException
                    {
                        Message = row[LogSettings.Fields.ExMessage].ToString()
                        ,
                        StackTrace = row[LogSettings.Fields.ExStackTrace].ToString()
                        ,
                        Source = row[LogSettings.Fields.ExSource].ToString()
                        ,
                        HelpLink = row[LogSettings.Fields.HelpLink].ToString()
                    };
                }
                var le = new LogItem
                {
                    Message = row[LogSettings.Fields.Message].ToString()
                    ,DateT = (DateTime)row[LogSettings.Fields.Date]
                    ,User = row[LogSettings.Fields.UserName].ToString()
                    ,LogType = (LogType)Enum.Parse(typeof(LogType), row[LogSettings.Fields.LogType].ToString())
                    ,MachineName = row[LogSettings.Fields.Mashine].ToString()
                    ,Application = row[LogSettings.Fields.AppName].ToString()
                    ,Header = row[LogSettings.Fields.Header].ToString()
                    ,Ex = ex
                    ,Version = Convert.ToString(row[LogSettings.Fields.Version])
                };
                if (row[LogSettings.Fields.Id] != null)
                {
                    long _id = 0;
                    if (long.TryParse(row[LogSettings.Fields.Id].ToString(), out _id))
                        le.Id = _id;
                }
                list.Add(le);
            }
            return list;
        }

        public Filter Filter { get; set; }
    }
}
