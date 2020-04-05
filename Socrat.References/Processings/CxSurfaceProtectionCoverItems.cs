using System.Collections.ObjectModel;
using Socrat.Lib;
using Socrat.Model;
using Socrat.UI.Core;

namespace Socrat.References.Processings
{
    public partial class CxSurfaceProtectionCoverItems : CxGenericListTable<Model.CoverItem>
    {
        public Model.SurfaseCoverProtection SurfaseCoverProtection { get; set; }

        public CxSurfaceProtectionCoverItems()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Комплектующие","Name", 200, 0);
            AddColumn("Кол-во", "Qty", 100, 1);
            AddColumn("Едиэ.изм", "Measure", 200, 0);
        }

        protected override ObservableCollection<CoverItem> GetItems()
        {
            return SurfaseCoverProtection.CoverItems;
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxBaseSimpleDialog();
        }

        public override void RefreshData()
        {
            gcGrid.DataSource = null;
            gcGrid.DataSource = Items;
            if (SelectedItem != null)
                SetFocusedRow(SelectedItem.Id);
            OnRefreshButtonClick();
        }
    }
}
