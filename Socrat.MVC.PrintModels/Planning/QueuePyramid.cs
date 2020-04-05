using Socrat.Common.Interfaces.Planning;
using System.Collections.Generic;

namespace Socrat.MVC.PrintModels.Planning
{
    public class QueuePyramid : PrintModel, IQueuePyramid
    {
        public QueuePyramid(string id, IQueue queue, int pyramidInQueue)
        {
            Id = id;
            Queue = queue;
            PyramidInQueue = pyramidInQueue;
        }

        public string Id { get; set; }

        public IQueue Queue { get; set; }

        public int PyramidInQueue { get; set; }
    }

    public class QueuePyramidCollection : PrintModel
    {
        public List<QueuePyramid> Items { get; set; }

        public QueuePyramidCollection()
        {
            Items = new List<QueuePyramid>();
        }
    }
}
