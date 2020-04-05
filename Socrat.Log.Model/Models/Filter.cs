using System;
using System.Collections.Generic;
using Socrat.Log.Enums;

namespace Socrat.Log.Models
{
    public class Filter
    {
        public int MessageType { get; set; }
        public List<LogType> LogTypes
        {
            get
            {
                var res = new List<LogType>();
                switch (MessageType)
                {
                    //все
                    case 0:
                        res.Add(LogType.EndException);
                        res.Add(LogType.Error);
                        res.Add(LogType.ErrorException);
                        res.Add(LogType.FailureAudit);
                        res.Add(LogType.Finisch);
                        res.Add(LogType.Information);
                        res.Add(LogType.Marker);
                        res.Add(LogType.Start);
                        res.Add(LogType.SuccessAudit);
                        res.Add(LogType.Warning);
                        break;
                    //ошибки
                    case 1:
                        res.Add(LogType.EndException);
                        res.Add(LogType.Error);
                        res.Add(LogType.ErrorException);
                        break;
                    //предупреждения
                    case 2:
                        res.Add(LogType.FailureAudit);
                        res.Add(LogType.Marker);
                        res.Add(LogType.Warning);
                        break;
                    //информация
                    case 3:
                        res.Add(LogType.Finisch);
                        res.Add(LogType.Information);
                        res.Add(LogType.Start);
                        res.Add(LogType.SuccessAudit);
                        break;
                }
                return res;
            }
        }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Application { get; set; }
        public string User { get; set; }
        public string MachineName { get; set; }
        public bool IsPeriod
        {
            get
            {
                return DateFrom != DateTo;
            }
        }

        public Filter()
        {
            MessageType = 0;
            DateFrom = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
            DateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            Application = String.Empty;
            User = String.Empty;
            MachineName = String.Empty;
        }

        public Filter(int mess, DateTime from, DateTime to)
        {
            MessageType = mess;
            DateFrom = from;
            DateTo = to;
            Application = String.Empty;
            User = String.Empty;
            MachineName = String.Empty;
        }

        public Filter(int mess, DateTime from, DateTime to, string application, string user, string machineName)
        {
            MessageType = mess;
            DateFrom = from;
            DateTo = to;
            Application = application;
            User = user;
            MachineName = machineName;
        }

    }
}
