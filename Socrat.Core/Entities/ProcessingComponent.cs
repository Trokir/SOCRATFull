using System;

namespace Socrat.Core.Entities
{
    public class ProcessingComponent: Entity
    {
        public Guid MaterialNomId { get; set; }

        private MaterialNom _MaterialNom;
        public virtual MaterialNom MaterialNom
        {
            get { return _MaterialNom; }
            set { SetField(ref _MaterialNom, value, () => MaterialNom); }
        }

        private double _Qty;
        public double Qty
        {
            get { return _Qty; }
            set { SetField(ref _Qty, value, () => Qty); }
        }

        public Guid MeasureId { get; set; }

        private Measure _Measure;
        public virtual Measure Measure
        {
            get { return _Measure; }
            set { SetField(ref _Measure, value, () => Measure); }
        }

        public Guid FormulaItemProcessingId { get; set; }

        [ParentItem]
        private FormulaItemProcessing _FormulaItemProcessing;
        public virtual FormulaItemProcessing FormulaItemProcessing
        {
            get { return _FormulaItemProcessing; }
            set { SetField(ref _FormulaItemProcessing, value, () => FormulaItemProcessing); }
        }

        protected override string GetTitle()
        {
            return "Операция";
        }

        public ProcessingComponent Clone()
        {
            ProcessingComponent _component = new ProcessingComponent();
            CopyFieldsValues(this, _component);
            _component.Id = Guid.NewGuid();
            _component.Measure = Measure;
            _component.MaterialNom = MaterialNom;
            return _component;
        }
    }
}