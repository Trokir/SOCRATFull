using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Customer
{
    public partial class FxOpfEdit : FxBaseSimpleDialog
    {
        public Opf Opf { get; set; }

        public FxOpfEdit()
        {
            InitializeComponent();
        }

        protected override void SetEntity(IEntity value)
        {
            Opf = value as Opf;
        }

        protected override IEntity GetEntity()
        {
            return Opf;
        }

        protected override string GetTitle()
        {
            return "Органицационно-правовая форма";
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teAlias, Opf, x => x.Alias);
            BindEditor(teName, Opf, x => x.Name);
            BindEditor(meComment, Opf, x => x.Comment);
            ceIP.Checked = Opf.IsIP ?? false;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teAlias, teName};
        }

        private void ceIP_CheckedChanged(object sender, System.EventArgs e)
        {
            Opf.IsIP = ceIP.Checked;
        }
    }
}