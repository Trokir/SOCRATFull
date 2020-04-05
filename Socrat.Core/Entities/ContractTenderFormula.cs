using System;

namespace Socrat.Core.Entities
{
    public class ContractTenderFormula : Entity
    {
        //public Guid Id { get; set; }
        public Guid? ContractId { get; set; }
        public Guid? FormulaId { get; set; }

        private double? _price;
        public double? Price
        {
            get { return _price; }
            set { SetField(ref _price, value, () => Price); }
        }

        private double? _squReady;
        public double? SquReady
        {
            get { return _squReady; }
            set { SetField(ref _squReady, value, () => SquReady); }
        }

        private DateTime? _editDate;
        public DateTime? EditDate
        {
            get { return _editDate; }
            set { SetField(ref _editDate, value, () => EditDate); }
        }

        private double? _limit;
        public double? Limit
        {
            get { return _limit; }
            set { SetField(ref _limit, value, () => Limit); }
        }
        [ParentItem]
        private Contract _contract;
        public virtual Contract Contract
        {
            get { return _contract; }
            set { SetField(ref _contract, value, () => Contract); }
        }

        private Formula _formula;
        public virtual Formula Formula
        {
            get { return _formula; }
            set { SetField(ref _formula, value, () => Formula); }
        }
        protected override string GetTitle()
        {
            return $"Договор № {Contract?.Num} Тендерная формула";
        }
    }
}
