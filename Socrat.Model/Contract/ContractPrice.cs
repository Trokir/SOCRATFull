using System;
using Socrat.Lib;

namespace Socrat.Model
{
    public class ContractPrice: Entity
    {
        [ParentItem]
        private Contract _Contract;
        public Contract Contract
        {
            get { return _Contract; }
            set { SetField(ref _Contract, value, () => Contract); }
        }

        public Nullable<Guid> Contract_Id
        {
            get { return Contract?.Id; }
        }

        private PriceType _PriceType;
        public PriceType PriceType
        {
            get { return _PriceType; }
            set { SetField(ref _PriceType, value, () => PriceType); }
        }

        public Nullable<Guid> PriceType_Id
        {
            get { return PriceType?.Id; }
        }

        private Price _Price;
        public Price Price
        {
            get { return _Price; }
            set { SetField(ref _Price, value, () => Price); }
        }

        public Nullable<Guid> Price_Id
        {
            get { return Price?.Id; }
        }

        public string PriceColumn
        {
            get { return Price?.Name; }
        }

        private Nullable<double> _Discount;
        public Nullable<double> Discount
        {
            get { return _Discount; }
            set { SetField(ref _Discount, value, () => Discount); }
        }

        private Nullable<double> _Delta;
        public Nullable<double> Delta
        {
            get { return _Delta; }
            set { SetField(ref _Delta, value, () => Delta); }
        }

        private DateTime _EditDate;
        public DateTime EditDate
        {
            get { return _EditDate; }
            set { SetField(ref _EditDate, value, () => EditDate); }
        }

        private string _Editor;
        public string Editor
        {
            get { return _Editor; }
            set { SetField(ref _Editor, value, () => Editor); }
        }

        protected override string GetTitle()
        {
            return $"Договор № {Contract?.Num} праис {Price?.Name}";
        }
    }
}