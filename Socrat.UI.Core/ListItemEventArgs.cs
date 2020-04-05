using System;

namespace Socrat.UI.Core
{
    public class ListItemEventArgs : EventArgs
    {
        public ListItemEventArgs(Guid id)
        {
            ItemId = id;
        }

        public Guid ItemId { get; set; }
    }
}