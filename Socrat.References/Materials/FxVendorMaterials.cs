using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Lib.Interfaces;

namespace Socrat.References.Materials
{
    public partial class FxVendorMaterials : FxGenericListTable<VendorMaterial>, ISelectionDialogFilterable<VendorMaterial>
    {
        public Vendor Vendor { get; set; }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "MaterialName", 200, 0);
            AddColumn("Тип", "MaterialType", 200, 1);
            Load += FxVendorMaterials_Load;
        }

        private void FxVendorMaterials_Load(object sender, EventArgs e)
        {
            //_items.RemoveAll(x => x.Vendor_Id == null || x.Vendor_Id == Vendor?.Id);
        }

        public FxVendorMaterials()
        {
            InitializeComponent();
        }

        protected override VendorMaterial GetNewInstance()
        {
            return new VendorMaterial { Vendor = this.Vendor };
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxVendorMaterialEdit();
        }

        protected override List<VendorMaterial> GetItems()
        {
            return _items = Repository.GetAll().Where(x => x.VendorId == Vendor.Id).ToList();
        }

        protected override string GetTitle()
        {
            return $"Материалы производителя {Vendor?.Name}";
        }
    }
}