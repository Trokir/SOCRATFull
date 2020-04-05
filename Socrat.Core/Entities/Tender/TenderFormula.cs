using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Socrat.Core.Entities.Tender
{
    public class TenderFormula : Entity
    {
        public TenderFormula()
        {
            OrderRows = new AttachedList<OrderRow>(this);
        }

        public Guid TenderId { get; set; }
        public Guid FormulaId { get; set; }

        private double? _price;
        public double? Price
        {
            get { return _price; }
            set { SetField(ref _price, value, () => Price); }
        }
    
        [NotMapped]
        public double? SquReady
        {
            get => GetSquReady();
        }

        private double? GetSquReady()
        {
            return OrderRows?.Sum(x => x.Square);
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
        private Tender _Tender;
        [ParentItem]
        public virtual Tender Tender
        {
            get { return _Tender; }
            set { SetField(ref _Tender, value, () => Tender); }
        }

        private Formula _formula;
        public virtual Formula Formula
        {
            get { return _formula; }
            set { SetField(ref _formula, value, () => Formula); }
        }
        protected override string GetTitle()
        {
            return $"Тендер {Tender?.Name} Тендерная формула";
        }

        public AttachedList<OrderRow> OrderRows { get; }

        public override string ToString()
        {
            return $"Тендерная формула {Formula} ({Tender})";
        }
    }
}
