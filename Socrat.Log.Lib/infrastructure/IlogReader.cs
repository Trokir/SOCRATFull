using System.Collections.Generic;
using Socrat.Log.Models;

namespace Socrat.Log.infrastructure
{
    interface ILogReader
    {
        List<LogItem> ReadLog(Filter filter, List<LogItem> list = null);
        Filter Filter { get; set; }
    }
}
