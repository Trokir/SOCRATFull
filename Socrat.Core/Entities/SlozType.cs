using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Socrat.Core.Added;
using Socrat.Core.Helpers;

namespace Socrat.Core.Entities
{
    public class SlozType : Entity, IShortNamedEntity
    {
        private string _shortName;
        [StringLength(10)]
        public string ShortName
        {
            get { return _shortName; }
            set { SetField(ref _shortName, value, () => ShortName, () => Title); }
        }
        private string _name;
        [StringLength(70)]
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }
        public virtual ICollection<OrderRowSloz> OrderRowSlozs { get; set; } = new HashSet<OrderRowSloz>();
        public virtual ICollection<PriceSloz> PriceSlozs { get; set; } = new HashSet<PriceSloz>();
        public virtual ICollection<Processing> Processings { get; set; } = new HashSet<Processing>();

        private string _EnumCode;
        public string EnumCode
        {
            get { return _EnumCode; }
            set { SetField(ref _EnumCode, value, () => EnumCode); }
        }

        [NotMapped]
        public SlozEnum Enumerator
        {
            get { return EnumHelper<SlozEnum>.Parse(EnumCode); }
            set { _EnumCode = value.ToString(); }
        }

        protected override string GetTitle()
        {
            return $"Тип сложности: {ShortName}";
        }

        public override string ToString()
        {
            return $"Тип сложности: {ShortName}";
        }
    }
}
