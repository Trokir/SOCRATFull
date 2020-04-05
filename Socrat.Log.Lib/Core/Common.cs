using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Socrat.Log.Enums;
using Socrat.Log.infrastructure;
using Socrat.Log.Models;

namespace Socrat.Log.Core
{
    public static class Common
    {
        static string _productName = String.Empty;

        public static string User { get; set; }

        static ILogReader _reader;

        static ILogWriter _writer;

        private static LogPlace _logPlace = LogPlace.Xml;

        public static LogPlace LogPlace
        {
            get
            {
                return _logPlace;
            }
            set
            {
                _logPlace = value;
            }
        }

        public static string Version { get; set; }
        
        public static string ProductName 
        {
            get
            {
                if (String.IsNullOrEmpty(_productName))
                {
                    return Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                }
                return _productName;
            }
            set { _productName = value; } 
        }

        public static string GetCurrentFileName()
        {
            return Path.GetFullPath(Path.GetPathRoot(Environment.GetEnvironmentVariable("windir"))+ "\\LogSD\\" + ProductName + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
        }

        public static string GetCurrentDirName()
        {
            return Path.GetFullPath(Path.GetPathRoot(Environment.GetEnvironmentVariable("windir")) + "\\LogSD\\" + ProductName);
        }

        public static List<LogItem> ReadLog(Filter filter, List<LogItem> list = null)
        {
            switch (LogPlace)
            {
                case LogPlace.Sql:
                    _reader = new LogSqlReader();
                    break;
                case LogPlace.Xml:
                    _reader = new LogXmlReader();
                    break;
            }
            return _reader.ReadLog(filter, list);
        }

        public static void WriteLog(LogItem le)
        {
            switch (LogPlace)
            {
                case LogPlace.Sql:
                    _writer = new LogSqlWriter();
                    break;
                case LogPlace.Xml:
                    _writer = new LogXmlWriter();
                    break;
            }
            _writer.WriteLog(le);
        }
    }
}
