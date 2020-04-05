using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities.Machines;

namespace Socrat.References.Machines
{
    public partial class CxVendorMachineOptionsFromVMN : CxGenericListTable<VendorMachineOption> //XXXX own
    {
        public VendorMachineNom VendorMachineNom { get; set; }

        public CxVendorMachineOptionsFromVMN()
        {
            InitializeComponent();
        }

        protected override IEntity GetOwner()
        {
            return VendorMachineNom;
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", x => x.Name, 200, 0);
            AddColumn("Описание", x => x.Description, 200, 0);
        }

        protected override AttachedList<VendorMachineOption> GetItems()
        {
            return VendorMachineNom?.VendorMachineOptions;
        }

        protected override VendorMachineOption GetNewInstance()
        {
            return new VendorMachineOption { VendorMachineNom = this.VendorMachineNom, Loaded = true };
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxVendorMachineOptionEdit() { OpenMode = openMode };
        }
        
    }
}
