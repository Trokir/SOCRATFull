using System.Windows.Forms;
using Socrat.Core;

namespace Socrat.Lib.Interfaces
{
    public interface ISelectionDialog : Socrat.Core.IEntitySelector, Socrat.Core.ITabable
    {
        DialogResult ShowDialog(IWin32Window owner);
        void SetSingleSelectMode(IEntity selectedItem);
    }
}
