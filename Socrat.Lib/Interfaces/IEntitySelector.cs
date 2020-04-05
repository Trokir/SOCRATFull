using System;

namespace Socrat.Lib
{
    public interface IEntitySelector
    {
        event EventHandler ItemSelected;
        IEntity SelectedItem { get; }
    }
}
