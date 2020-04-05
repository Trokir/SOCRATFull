using System;
using System.Text;

namespace Socrat.Log.Models
{
    public class MyException
    {
        public MyException()
        {
            Message = null;
            Source = null;
            StackTrace = null;
            HelpLink = null;
        }

        public MyException(Exception exc)
        {
            Message = exc.Message;
            Source = exc.Source;
            StackTrace = exc.StackTrace;
            HelpLink = exc.HelpLink;
        }
        
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string HelpLink { get; set; }

        public override string ToString()
        {
            var mess = new StringBuilder();
            mess.AppendLine("");
            mess.AppendLine("");
            mess.AppendLine("");
            mess.AppendLine("=======================================================");
            mess.AppendLine("=======================EXCEPTION=======================");
            mess.AppendLine("=======================================================");
            mess.AppendLine("");
            mess.AppendLine("Message:");
            mess.Append(Message);
            mess.AppendLine("");
            mess.AppendLine("Source:");
            mess.Append(Source);
            mess.AppendLine("");
            mess.AppendLine("StackTrace:");
            mess.Append(StackTrace);
            mess.AppendLine("");
            mess.AppendLine("HelpLink:");
            mess.Append(HelpLink);
            mess.AppendLine("");
            mess.AppendLine("=======================================================");
            return mess.ToString();
        }
    }
}
