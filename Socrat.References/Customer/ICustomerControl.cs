using System;
using Socrat.Core;

namespace Socrat.References.Customer
{
    public interface ICustomerControl: ITabable
    {
        bool ReadOnly { get; set; }
        Core.Entities.Customer Customer { get; set; }
        event EventHandler NeedFocus;
    }
}
