using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Common
{
    public partial class FxCountryEdit : FxBaseSimpleDialog
    {
        public Country Country { get; set; }

        public FxCountryEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return Country;
        }

        protected override void SetEntity(IEntity value)
        {
            Country = value as Country;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teAlias, Country, x => x.AliasName);
            BindEditor(teShort, Country, x => x.ShortName);
            BindEditor(meFull, Country, x => x.FullName);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teAlias, teShort};
        }
    }
}