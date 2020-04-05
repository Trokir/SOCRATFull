using System;

namespace Socrat.Core
{
    public interface IEntitySelector
    {
        event EventHandler ItemSelected;
        IEntity SelectedItem { get; }
    }
}
