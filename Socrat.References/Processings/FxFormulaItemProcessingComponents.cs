using System.Windows.Forms;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Processings
{
    public partial class FxFormulaItemProcessingComponents : FxBaseSimpleDialog
    {
        private FormulaItemProcessing _formulaItemProcessing;
        public FormulaItemProcessing FormulaItemProcessing
        {
            get => _formulaItemProcessing;
            set => SetFormulaItemProcessing(value);
        }

        private CxProcessingComponents _cxProcessingComponents;


        public FxFormulaItemProcessingComponents()
        {
            InitializeComponent();
            InitComponents();
        }

        private void InitComponents()
        {
            _cxProcessingComponents = new CxProcessingComponents();
            _cxProcessingComponents.DependedSaving = true;
            _cxProcessingComponents.FormulaItemProcessing = FormulaItemProcessing;
            _cxProcessingComponents.DialogOutput += _cxProcessingComponents_DialogOutput;
            pcComponents.Controls.Add(_cxProcessingComponents);
            _cxProcessingComponents.Dock = DockStyle.Fill;
        }

        private void _cxProcessingComponents_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        protected override IEntity GetEntity()
        {
            return FormulaItemProcessing;
        }

        protected override void SetEntity(IEntity value)
        {
            FormulaItemProcessing = value as FormulaItemProcessing;
        }

        private void SetFormulaItemProcessing(FormulaItemProcessing value)
        {
            _formulaItemProcessing = value;
            _cxProcessingComponents.FormulaItemProcessing = _formulaItemProcessing;
            lcName.Text = _formulaItemProcessing.Title;
            Text = "Комплектующие операции";
        }

        protected override string GetTitle()
        {
            return "Комплектующие операции";
        }

        public override bool Validate()
        {
            return true;
        }
    }
}