using System;

namespace Socrat.Core.Entities
{
    public class Log : Entity
    {
        //public long Id { get; set; }
        public long? LogType { get; set; }
        public string Message { get; set; }
        public DateTime? DateT { get; set; }
        public string UserLogin { get; set; }
        public string Header { get; set; }
        public string MachineName { get; set; }
        public string AppName { get; set; }
        public string ExMessage { get; set; }
        public string ExSource { get; set; }
        public string ExStackTrace { get; set; }
        public string HelpLink { get; set; }
        public string Version { get; set; }
    }
}
