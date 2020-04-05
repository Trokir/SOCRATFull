using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socrat.Core.Entities
{
    public class Account : Entity
    {
        public Guid CustomerId { get; set; }
        private string _alias;
        public string Alias
        {
            get { return GetAlias(); }
            set { SetField(ref _alias, value, () => Alias, () => Title); }
        }
        public Guid BankId { get; set; }

        private string _rs;
        public string Rs
        {
            get { return _rs; }
            set { SetField(ref _rs, value, () => Rs, () => AccountTitle); }
        }
        public Guid? CurrencyId { get; set; }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { SetField(ref _comment, value, () => Comment); }
        }

        private Bank _bank;
        public virtual Bank Bank
        {
            get { return _bank; }
            set { SetField(ref _bank, value, () => Bank, () => AccountTitle, () => Ks, () => Bik); }
        }

        [NotMapped]
        public string Filial
        {
            get { return $"{Bank.Filial}"; }
        }

        public string Bik
        {
            get { return Bank?.Bik; }
        }

        public string Ks
        {
            get { return Bank?.Ks; }
        }
        private Currency _currency;
        public virtual Currency Currency
        {
            get { return _currency; }
            set { SetField(ref _currency, value, () => Currency, () => CurrencyId); }
        }

        private Customer _customer;
        public virtual Customer Customer
        {
            get { return _customer; }
            set { SetField(ref _customer, value, () => Customer); }
        }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public string AccountTitle
        {
            get { return GetAccountTitle(); }
        }

        private string GetAccountTitle()
        {
            string _title = !string.IsNullOrEmpty(Alias)
                ? Alias
                : Bank != null
                    ? Bank?.Alias
                    : string.Empty;
            _title += !string.IsNullOrEmpty(_title) ? " " : string.Empty;
            _title += Rs;
            return _title;
        }

        private string GetAlias()
        {
            if (!string.IsNullOrEmpty(_alias))
                return _alias;
            string _res = string.Empty;
            _res = Bank != null
                ? !string.IsNullOrEmpty(Bank.ShortName)
                    ? Bank.ShortName
                    : Bank.Alias
                : string.Empty;
            _res += " " + (!string.IsNullOrEmpty(Rs) && Rs.Length >= 5
                        ? Rs.Substring(Rs.Length - 5, 5)
                        : string.Empty);
            return _res;
        }

        protected override string GetTitle()
        {
            return AccountTitle;
        }
    }
}
