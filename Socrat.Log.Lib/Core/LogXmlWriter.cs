using System;
using System.IO;
using Socrat.Log.infrastructure;
using Socrat.Log.Models;

namespace Socrat.Log.Core
{
    internal class LogXmlWriter : ILogWriter
    {
        static readonly object Locker = new object();

        private void WriteLog(string log)
        {
            if (!Directory.Exists(Common.GetCurrentDirName()))
                Directory.CreateDirectory(Common.GetCurrentDirName());
            using (var fs = File.AppendText(Common.GetCurrentFileName()))
            {
                fs.WriteLine(log);
            }
        }

        public void WriteLog(LogItem le)
        {
            lock (Locker)
            {
                WriteLog(le.ToXml());
            }
        }

       

        internal void WriteLog(LogItem le,String path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var filename = le.DateT.ToString("yyyyMMdd") + ".log";
            using (var fs = File.AppendText(string.Format("{0}//{1}",path,filename)))
            {
                fs.WriteLine(le.ToXml());
            }
        }
    }
}
