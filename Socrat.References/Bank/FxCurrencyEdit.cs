using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.UI.Core;

namespace Socrat.References.Bank
{
    public partial class FxCurrencyEdit : FxBaseSimpleDialog
    {
        public Socrat.Core.Entities.Currency Currency { get; set; }

        public FxCurrencyEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return Currency;
        }

        protected override void SetEntity(IEntity value)
        {
            Currency = value as Socrat.Core.Entities.Currency;
        }

        protected override string GetTitle()
        {
            return "Валюта";
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, Currency, x => x.Alias);
            BindEditor(meComment, Currency, x => x.Comment);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName, meComment};
        }
    }
}