using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public partial class FxFormTypeEdit : FxBaseSimpleDialog
    {
        private IPriceService _priceService;
        public FormType FormType { get; set; }
        public FxFormTypeEdit()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override IEntity GetEntity()
        {
            return FormType;
        }

        protected override void SetEntity(IEntity value)
        {
            FormType = value as FormType;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName };
        }

        protected override string GetTitle()
        {
            return "Тип фигуры";
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, FormType, x => x.Name);
        }
    }
}