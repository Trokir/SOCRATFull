using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Contact
{
    public partial class FxContactTypeEdit : FxBaseSimpleDialog
    {
        public ContactType ContactType { get; set; }

        public FxContactTypeEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return ContactType;
        }

        protected override void SetEntity(IEntity value)
        {
            ContactType = value as ContactType;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName };
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, ContactType, x => x.Name);
            BindEditor(teMask, ContactType, x => x.RegexMask);
        }
    }
}