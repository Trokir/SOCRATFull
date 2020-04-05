using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Socrat.Data.Model
{
    public class Bank : Entity
    {
        public Bank()
        {
            Accounts = new HashSet<Account>();
        }


        [MaxLength(9)] public string Bik { get; set; }


        [MaxLength(200)] public string Alias { get; set; }


        [MaxLength(200)] public string Filial { get; set; }


        [MaxLength(20)] public string Ks { get; set; }


        [MaxLength(12)] public string Phone { get; set; }


        [MaxLength(100)] public string Comment { get; set; }


        [MaxLength(30)] public string ShortName { get; set; }

        public Guid? AddressId { get; set; }


        public virtual ICollection<Account> Accounts { get; set; }

        public virtual Address Address { get; set; }
    }
}