using System.Windows.Forms;

namespace Socrat.Lib.Interfaces
{
    public interface ISelectionDialogTest: Socrat.Core.IEntitySelector,Socrat.Core.ITabable
    {
        DialogResult ShowDialog(IWin32Window owner);
        void SetSingleSelectMode(Socrat.Core.IEntity selectedItem);
    }
}
