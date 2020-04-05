using System.Collections.Generic;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Machines
{
    public partial class FxEquipVendors : FxGenericListTable<Vendor>
    {
        public FxEquipVendors()
        {
            InitializeComponent();
            ExternalFilterExp =  v => v.Type == 2;
        }
        
        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
            AddColumn("Доп. информация", "Description", 200, 1);
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxEquipVendorEdit() { OpenMode = openMode };
        }
    }
}