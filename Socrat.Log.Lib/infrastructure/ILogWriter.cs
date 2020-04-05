using Socrat.Log.Models;

namespace Socrat.Log.infrastructure
{
    interface ILogWriter
    {
        void WriteLog(LogItem le);
    }
}
