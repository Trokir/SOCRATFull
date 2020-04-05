using System;
using System.Drawing;
using System.Globalization;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using DevExpress.Utils.Svg;
using Socrat.Log.Enums;
using Socrat.Log.Model.Models;

namespace Socrat.Log.Models
{
    public class LogItem
    {
        String _date;
        String _header;

        public LogItem()
        {
            DateT = DateTime.Now;
        }

        public SvgImage Icon { get { return IconWorker.GetIcon(LogType); } }

        private long _id;
        public long Id
        {
            get => _id;
            set => _id = value;
        }

        private string _user;
        public string User
        {
            set { _user = value; }
            get{
                return String.IsNullOrEmpty(_user) ? Environment.UserName : _user;
            }
        }
        private string _version;
        public string Version
        {
            set { _version = value; }
            get { return _version==null ? GetVersion() : _version; }
        }

        private string GetVersion()
        {
            return Assembly.GetEntryAssembly()?.GetName().Version.ToString();
        }

        public string Header
        {
            get
            {
                if (!String.IsNullOrEmpty(_header)) return _header;
                if (Ex != null)
                {
                    return Ex.Message;
                }
                string[] mass = Message.Split(new[] { '\n' });
                return mass[0];
            }
            set
            {
                _header = value;
            }
        }
        public LogType LogType { get; set; }

        public SvgImage LogIcon
        {
            get { return IconWorker.GetIcon(LogType); }
        }


        public MyException Ex { get; set; }
        public string Message { get; set; }
        public String Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public DateTime DateT
        {
            set { _date = value.ToString("dd.MM.yyyy HH:mm:ss"); }
            get {return DateTime.ParseExact(_date, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);}
        }
        private string _machineName;
        public string MachineName
        {
            set { _machineName = value; }
            get
            {
                return String.IsNullOrEmpty(_machineName) ? Environment.MachineName : _machineName;
            }
        }
        private string _application;
        public string Application
        {
            set { _application = value; }
            get { return String.IsNullOrEmpty(_application) ? Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) : _application; }
        }
        public string ToXml()
        {
            var xElement = new XElement("LogItem");
            xElement.Add(new XElement("LogType", LogType));
            xElement.Add(new XElement("Message", Message));
            xElement.Add(new XElement("DateT", Date));
            xElement.Add(new XElement("User", User));
            xElement.Add(new XElement("Header", Header));
            xElement.Add(new XElement("MachineName", MachineName));
            xElement.Add(new XElement("Application", Application));
            xElement.Add(new XElement("Version", Version));
            if (Ex != null)
            {
                var xElementEx = new XElement("Exception");
                xElementEx.Add(new XElement("Message", Ex.Message));
                xElementEx.Add(new XElement("Source", Ex.Source));
                xElementEx.Add(new XElement("StackTrace", Ex.StackTrace));
                xElementEx.Add(new XElement("HelpLink", Ex.HelpLink));
                xElement.Add(xElementEx);
            }
            return xElement.ToString();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", Date, Header, LogType, User, MachineName, Application);
        }
    }
}
