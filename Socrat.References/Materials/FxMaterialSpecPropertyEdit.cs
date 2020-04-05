using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxMaterialSpecPropertyEdit : FxBaseSimpleDialog
    {
        public MaterialSpecProperty MaterialSpecProperty { get; set; }

        protected override IEntity GetEntity()
        {
            return MaterialSpecProperty;
        }

        protected override void SetEntity(IEntity value)
        {
            MaterialSpecProperty = value as MaterialSpecProperty;
        }

        public FxMaterialSpecPropertyEdit()
        {
            InitializeComponent();
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, MaterialSpecProperty, x => x.Name);
            BindEditor(meComment, MaterialSpecProperty, x => x.Comment);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>{teName};
        }
    }
}