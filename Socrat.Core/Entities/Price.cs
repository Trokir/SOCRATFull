using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Socrat.Core.Entities
{
    public class Price : Entity
    {
        //public Guid Id { get; set; }
        public Guid? DivisionId { get; set; }
        public Guid? CustomerId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        private Customer _customer;
        public virtual Customer Customer
        {
            get { return _customer; }
            set { SetField(ref _customer, value, () => Customer); }
        }

        private Division _division;
        public virtual Division Division
        {
            get { return _division; }
            set { SetField(ref _division, value, () => Division); }
        }

        public virtual ICollection<PricePeriod> PricePeriods { get; set; } = new HashSet<PricePeriod>();
        public virtual ICollection<ContractPrice> ContractPrices { get; set; } = new HashSet<ContractPrice>();

        
        //public virtual PriceSquRatioCollection PriceSquRatios { get; set; } = new PriceSquRatioCollection();
        public virtual ICollection<PriceSquRatio> PriceSquRatios { get; set; } = new HashSet<PriceSquRatio>();

        //public virtual PriceSlozsCollection PriceSlozs { get; set; } = new PriceSlozsCollection();
        public virtual ICollection<PriceSloz> PriceSlozs { get; set; } = new HashSet<PriceSloz>();

        public virtual ICollection<PriceSelectType> PriceSelectTypes { get; set; } = new HashSet<PriceSelectType>();
        public virtual ICollection<PriceForm> PriceForms { get; set; }

        public bool IsCommon
        {
            get
            {
                return PriceType.Equals("Общий", StringComparison.OrdinalIgnoreCase);
            }
        }

        public string PriceType
        {
            get
            {
                if (Customer != null)
                {
                    return "Индивидуальный";
                }
                else
                {
                    return "Общий";
                }
            }
        }

        public string PriceName
        {
            get
            {
                if (Customer != null)
                {
                    return Customer.FullName;
                }
                else
                {
                    return Name;
                }
            }
        }

        public override string ToString()
        {
            return $"{PriceType}: \"{Name}\"";
            //return $"Региональный прайс: \"{Name}\"";
        }

        #region Работа с периодами

        /// <summary>
        /// Актуальный период для текущей даты или null, если не установлен
        /// </summary>
        public PricePeriod CurrentPricePeriod
        {
            get
            {
                return PricePeriods
                    .Where(period => period.DateBegin <= DateTime.Today)
                    .OrderBy(period => DateTime.Today - period.DateBegin).FirstOrDefault();
            }
        }

        /// <summary>
        /// Возвращает период
        /// </summary>
        /// <param name="forDate">Дата, для которой нужно вернуть период</param>
        /// <returns>Экземпляр PricePeriod или null</returns>
        public PricePeriod GetPricePeriod(DateTime forDate)
        {
                return PricePeriods
                    .Where(period => period.DateBegin <= forDate)
                    .OrderBy(period => forDate.Date - period.DateBegin).FirstOrDefault();
        }

        private PricePeriod _selectedPricePeriod;
        [NotMapped]
        public PricePeriod SelectedPricePeriod
        {
            get => _selectedPricePeriod ?? (_selectedPricePeriod = CurrentPricePeriod);
            set => SetField(ref _selectedPricePeriod, value, () => SelectedPricePeriod);
        }

        public PricePeriod GetPrevious(PricePeriod pricePeriod)
        {
            var prevs = PricePeriods
                .Where(period => period.DateBegin < pricePeriod.DateBegin)
                .OrderBy(period => pricePeriod.DateBegin - period.DateBegin);
            return prevs.First();
        }

        public PricePeriod GetNext(PricePeriod pricePeriod)
        {
            return PricePeriods
                .Where(period => period.DateBegin > pricePeriod.DateBegin)
                .OrderBy(period => pricePeriod.DateBegin - period.DateBegin).First();
        }

        #endregion

    }

    public static class PriceExtentions
    {
        public static PriceSquRatio GetAppliedRatio(this ICollection<PriceSquRatio> pricePeriods, double forArea)
        {
            PriceSquRatio result = null;

            foreach (PriceSquRatio ratio in pricePeriods)
            {
                if (forArea == ratio.Squ)
                {
                    result = ratio;
                    break;
                }

                if (forArea < ratio.Squ)
                    continue;

                if (forArea > ratio.Squ)
                {
                    if (result == null)
                        result = ratio;
                    else
                    {
                        if (ratio.Squ < result.Squ)
                            result = ratio;
                    }

                }
            }

            return result;
        }
    }
}
