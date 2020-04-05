using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Socrat.Log.Enums;
using Socrat.Log.infrastructure;
using Socrat.Log.Models;

namespace Socrat.Log.Core
{
    internal class LogXmlReader : ILogReader
    {
        public  List<LogItem> ReadLog(Filter filter, List<LogItem> list = null)
        {
            Filter = filter;
            list = list ?? (new List<LogItem>());
            var dateFrom = new DateTime(filter.DateFrom.Year, filter.DateFrom.Month, filter.DateFrom.Day);
            var dateTo = new DateTime(filter.DateTo.Year, filter.DateTo.Month, filter.DateTo.Day);
            if (dateFrom > dateTo)
            {
                DateTime buffer = dateTo;
                dateTo = dateFrom;
                dateFrom = buffer;
            }

            while (dateFrom <= dateTo)
            {
                list = ReadLog(dateFrom, filter.LogTypes, list);
                dateFrom = dateFrom.AddDays(1);
            }
            return list;
        }

        public Filter Filter { get; set; }

        internal List<LogItem> ReadLog(String path, List<LogItem> list = null)
        {
            return ReadLog(null, path,list);
        }

        internal List<LogItem> ReadLog(List<LogType> logTypes, String path, List<LogItem> list = null)
        {
            if (!Directory.Exists(path)) return list;
            return Directory.GetFiles(path).Where(logFile => Path.GetExtension(logFile) == ".log").Aggregate(list, (current, logFile) => ReadLogEx(logTypes, logFile, current));
        }

        internal List<LogItem> ReadLog(DateTime date, List<LogType> logTypes, List<LogItem> list = null)
        {
            return ReadLog(date, logTypes, Common.GetCurrentDirName(), list);
        }

        internal List<LogItem> ReadLog(DateTime date,List<LogType> logTypes,String path, List<LogItem> list = null)
        {
            list = list ?? (new List<LogItem>());

            if (File.Exists(String.Format("{0}\\{1}.log", path, date.ToString("yyyyMMdd"))))
            {
                list = ReadLogEx(logTypes, String.Format("{0}\\{1}.log", path, date.ToString("yyyyMMdd")), list);
            }
            return list;
        }

        internal List<LogItem> ReadLogEx(List<LogType> logTypes, String path, List<LogItem> list = null)
        {
            list = list ?? (new List<LogItem>());

            if (!File.Exists(path)) return list;
            var fs = File.ReadAllText(path);
            var xel = XElement.Parse(String.Format("<root>{0}</root>",fs));

            foreach (var element in xel.XPathSelectElements("LogItem"))
            {
                var le = new LogItem
                {
                    LogType = CLogType(element.XPathSelectElement("LogType")),
                    Message = CStr(element.XPathSelectElement("Message")),
                    Date = CStr(element.XPathSelectElement("DateT")),
                    User = CStr(element.XPathSelectElement("User")),
                    Header = CStr(element.XPathSelectElement("Header")),
                    MachineName = CStr(element.XPathSelectElement("MachineName")),
                    Application = CStr(element.XPathSelectElement("Application")),
                    Version = CStr(element.XPathSelectElement("Version"))
                };
                if (element.XPathSelectElement("Exception") != null)
                {
                    var exc = new MyException
                    {
                        Message = CStr(element.XPathSelectElement("Exception/Message")),
                        Source = CStr(element.XPathSelectElement("Exception/Source")),
                        StackTrace = CStr(element.XPathSelectElement("Exception/StackTrace")),
                        HelpLink = CStr(element.XPathSelectElement("Exception/HelpLink"))
                    };
                    le.Ex = exc;
                }
                if (logTypes==null)
                    list.Add(le);
                else if (logTypes.Contains(le.LogType))
                    list.Add(le);

            }
            return list;
        }
        
        String CStr(XElement el)
        {
            return el == null ? null : el.Value;
        }

        LogType CLogType(XElement el)
        {
            return (LogType)Enum.Parse(typeof(LogType), el.Value);
        }


       

    }
}
