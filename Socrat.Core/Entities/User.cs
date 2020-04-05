using System;
using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class User : Entity
    {
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set { SetField(ref _surname, value, () => Surname, () => Title); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name, () => Title); }
        }

        private string _patronimyc;
        public string Patronimyc
        {
            get { return _patronimyc; }
            set { SetField(ref _patronimyc, value, () => Patronimyc, () => Title); }
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set { SetField(ref _login, value, () => Login); }
        }

        private string _domain;
        public string Domain
        {
            get { return _domain; }
            set { SetField(ref _domain, value, () => Domain); }
        }

        private string _mail;
        public string Mail
        {
            get { return _mail; }
            set { SetField(ref _mail, value, () => Mail); }
        }
        public Guid? RoleId { get; set; }

        private Role _role;
        public virtual Role Role
        {
            get { return _role; }
            set { SetField(ref _role, value, () => Role); }
        }
        public virtual ICollection<ContractShippingSquare> ContractShippingSquares { get; set; } = new HashSet<ContractShippingSquare>();
        public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new HashSet<OrderStatusHistory>();
        public override string ToString()
        {
            return $"{Role?.Name} {Surname} {(!String.IsNullOrEmpty(Name) ? Name?.Substring(0, 1) : String.Empty)}" +
                   $" {(!String.IsNullOrEmpty(Patronimyc) ? Patronimyc?.Substring(0, 1) : String.Empty)}";
        }
        protected override string GetTitle()
        {
            return this.ToString();
        }
    }
}
