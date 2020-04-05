using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Formula
{
    public partial class FxInsetPositionEdit : FxBaseSimpleDialog
    {
        public InsetPosition InsetPosition { get; set; }

        public FxInsetPositionEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return InsetPosition;
        }

        protected override void SetEntity(IEntity value)
        {
            InsetPosition = value as InsetPosition;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(seElement, InsetPosition, x => x.Num);
            BindEditor(seSide, InsetPosition, x => x.SideNum);
            BindEditor(tePosition, InsetPosition, x => x.Position);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { seElement, seSide, tePosition};
        }
    }
}