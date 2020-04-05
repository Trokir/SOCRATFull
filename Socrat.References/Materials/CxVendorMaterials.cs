using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class CxVendorMaterials : CxGenericListTable<VendorMaterial>
    {
        public Vendor Vendor { get; set; }

        public CxVendorMaterials()
        {
            InitializeComponent();
        }

        protected override ObservableCollection<VendorMaterial> GetItems()
        {
            return Vendor?.VendorMaterials;
        }

        protected override VendorMaterial GetNewInstance()
        {
            return new VendorMaterial { Vendor = this.Vendor };
        }

        protected override void InitColumns()
        {
            AddColumn("Материал", x => x.Material, 200, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxVendorMaterialEdit();
        }

        protected override void AddItem()
        {
            FxMaterials _fx = new FxMaterials();
            _fx.SetSingleSelectMode(null);
            _fx.ItemSelected += (sender, args) =>
            {
                Material _material = _fx.SelectedItem as Material;
                if (Vendor.VendorMaterials.Count(x => x.Material.Id == _material.Id) < 1)
                {
                    Vendor.VendorMaterials.Add(
                        new VendorMaterial
                        {
                            Vendor = this.Vendor,
                            Material = _material
                        });
                }
                gvGrid.RefreshData();
            };
            _fx.ItemMultiSelected += (sender, args) =>
            {
                List<Material> _materials = _fx.SelectedItems;
                foreach (Material material in _materials)
                {
                    if (Vendor.VendorMaterials.Count(x => x.Material.Id == material.Id) < 1)
                    {
                        Vendor.VendorMaterials.Add(
                        new VendorMaterial
                        {
                            Vendor = this.Vendor,
                            Material = material
                        });
                    }
                }
                gvGrid.RefreshData();
            };
            _fx.DialogOutput += FxOnDialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private void FxOnDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }
    }
}
