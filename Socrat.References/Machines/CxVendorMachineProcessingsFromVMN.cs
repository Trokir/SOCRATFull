using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Core.Entities.Machines;

namespace Socrat.References.Machines
{
    public partial class CxVendorMachineProcessingsFromVMN : CxGenericRelationsListTable<VendorMachineProcessing, Core.Entities.Processing>
    {
        public VendorMachineNom VendorMachineNom { get; set; }

        public CxVendorMachineProcessingsFromVMN()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Oперация", x => x.Processing, 200, 0);
        }

        protected override AttachedList<VendorMachineProcessing> GetItems()
        {
            return VendorMachineNom?.VendorMachineProcessings;
        }

        protected override VendorMachineProcessing GetNewInstance()
        {
            return new VendorMachineProcessing { VendorMachineNom = this.VendorMachineNom, Loaded = true };
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new Processings.FxProcessingEdit() { OpenMode = openMode };// форма редактора связанной сущности
        }

        protected override FxGenericListTable<Core.Entities.Processing> GetSelectionDialog()
        {
            Processings.FxProcessings fx = new Processings.FxProcessings();
            fx.ExternalPostFilterExp = p => VendorMachineNom.MachineType.MachineTypeProcessings.Any(mtp => mtp.ProcessingType.Id == p.ProcessingType.Id) ;
            fx.ReadOnly = true;
            //fx.AddNewItemInstancePreset(v => v., MachineNom.VendorMachineNom);
            return fx;
        }

        protected override Expression<Func<VendorMachineProcessing, IEntity>> GetTargetEntityReferenceExpression()
        {
            return (x => x.Processing); // ссылка на открываемую сущность (т.к. открываем не сущность из списка, а связанную с ней )
        }

        protected override bool ItemsContainsItemWithChild(Guid childId)
        {
            return VendorMachineNom.VendorMachineProcessings.Count(x => x.Processing.Id == childId) > 0;
        }

    }
}
