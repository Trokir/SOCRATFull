using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added.Order;
using Socrat.Core.Entities;
using Socrat.Core.Helpers;
using Socrat.UI.Core;

namespace Socrat.References.Order
{
    public partial class FxDefect : FxBaseSimpleDialog
    {
        public Defect Defect { get; set; }

        public FxDefect()
        {
            InitializeComponent();
            Load += FxDefect_Load;
        }

        private void FxDefect_Load(object sender, System.EventArgs e)
        {
            lueType.Properties.DataSource = EnumHelper<DefectType>.GetAll();
            EnumHelper<DefectType>.PrepareLookUp(lueType);

            lueReason.Properties.DataSource = EnumHelper<DefectReason>.GetAll();
            EnumHelper<DefectReason>.PrepareLookUp(lueReason);
        }

        protected override IEntity GetEntity()
        {
            return Defect;
        }

        protected override void SetEntity(IEntity value)
        {
            Defect = value as Defect;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(lueType, Defect, x => x.DefectType);
            BindEditor(lueReason, Defect, x => x.DefectReason);
            BindEditor(meComment, Defect, x => x.Comment);
            BindEditor(teCode1c, Defect, x => x.Code1с);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new AttachedList<BaseEdit> {lueType, lueReason, meComment };
        }
    }
}