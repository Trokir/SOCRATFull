using System;
using Socrat.Lib;

namespace Socrat.Model
{
    public class ContractTenderFormula: Entity
    {

        private Formula _formula;
        public Formula Formula
        {
            get { return _formula; }
            set { SetField(ref _formula, value, () => Formula); }
        }

        public Nullable<Guid> Formula_Id
        {
            get { return Formula?.Id; }
        }

        private double _Price;
        public double Price
        {
            get { return _Price; }
            set { SetField(ref _Price, value, () => Price); }
        }
       
        private double _Limit;
        public double Limit
        {
            get { return _Limit; }
            set { SetField(ref _Limit, value, () => Limit); }
        } 

        private double _SquReady;
        public double SquReady
        {
            get { return _SquReady; }
            set { SetField(ref _SquReady, value, () => SquReady); }
        }


        private Nullable<DateTime> _EditDate;
        public Nullable<DateTime> EditDate
        {
            get { return _EditDate; }
            set { SetField(ref _EditDate, value, () => EditDate); }
        }

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

        protected override string GetTitle()
        {
            return $"Договор № {Contract?.Num} Тендерная формула";
        }
    }
}