using System.Collections.Generic;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.Module.Price
{
    public class FxFormTypes : FxGenericListTable2<FormType>
    {
        protected override void OnCommandsInitializing(List<ReferenceCommand> commands)
        {
            CxTableList.CanExportToExcel = false;
            CxTableList.CanBePrinted = false;
            CxTableList.RightPaneVisible = true;
        }
    }

    public class FxPayments : FxGenericListTable2<Payment> { }
}