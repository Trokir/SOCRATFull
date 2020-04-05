using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References;
using Socrat.References.Processings;
using Socrat.UI.Core;

namespace Socrat.Module.Price
{
    public partial class FxPricePeriodProcessingNomEdit : FxBaseSimpleDialog
    {
        private ButtonEditAssistent<ProcessingNom, FxProcessingNoms, FxProcessingNomEdit> _processingNomButtonEditAssistant;
        public PricePeriodProcessingNom PricePeriodProcessingNom { get; set; }
        public FxPricePeriodProcessingNomEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return PricePeriodProcessingNom;
        }

        protected override void SetEntity(IEntity value)
        {
            PricePeriodProcessingNom = value as PricePeriodProcessingNom;
        }

        protected override void BindData()
        {
            base.BindData();

            _processingNomButtonEditAssistant = new ButtonEditAssistent<ProcessingNom, FxProcessingNoms, FxProcessingNomEdit>(
                 beProcessing, PricePeriodProcessingNom.ProcessingNom, OnDialogOutput, eButtonsType.All);
            _processingNomButtonEditAssistant.BindProperty(PricePeriodProcessingNom,  x => x.ProcessingNom);

            BindEditor(meAdditionalPriceValue, PricePeriodProcessingNom, x => x.AdditionalPriceValue);
            BindEditor(peMultiplyPriceFactor, PricePeriodProcessingNom, x => x.MultiplyPriceFactorForEditor);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>
            {
                beProcessing
            };
        }

        private void teAdditionalPriceValue_FormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            e.Value = $"{e.Value:c2}";
            e.Handled = true;
        }

        private void teMultiplyPriceFactor_FormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal factor))
                {
                    ((TextEdit)sender).Text = $"{factor:f2} %";
                    e.Handled = true;
                }
            }
        }
    }
}