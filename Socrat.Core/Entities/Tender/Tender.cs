using System;
using System.Linq;
using Socrat.Core.Added;

namespace Socrat.Core.Entities.Tender
{
    public class Tender: Entity
    {
        public Tender()
        {
            TenderFormulas = new AttachedList<TenderFormula>(this);
            TenderCustomers = new AttachedList<TenderCustomer>(this);
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name); }
        }

        private DateTime _DateCreate;
        public DateTime DateCreate
        {
            get { return _DateCreate; }
            set { SetField(ref _DateCreate, value, () => DateCreate); }
        }


        private bool _IsClose;

        public bool IsClose
        {
            get { return _IsClose; }
            set { SetField(ref _IsClose, value, () => IsClose); }
        }

        public virtual AttachedList<TenderFormula> TenderFormulas { get; }
        public virtual AttachedList<TenderCustomer> TenderCustomers { get; }

        public override string ToString()
        {
            return $"Тендер {Name} от {DateCreate.ToString("dd.MM.yyyy")}";
        }

        public bool CheckFormula(Formula formula)
        {
            return TenderFormulas.Any(x => FormulaComparer.Compare(x.Formula, formula));
        }

        public TenderFormula GetTenderFormula(Formula formula)
        {
            return TenderFormulas.FirstOrDefault(x => FormulaComparer.Compare(x.Formula, formula));
        }
    }
}