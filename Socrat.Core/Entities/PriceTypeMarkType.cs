using System;

namespace Socrat.Core.Entities
{
    public class PriceTypeMarkType : Entity
    {
        public Guid? PriceTypeId { get; set; }
        public Guid? MaterialMarkTypeId { get; set; }

        private MaterialMarkType _materialMarkType;
        public virtual MaterialMarkType MaterialMarkType
        {
            get { return _materialMarkType; }
            set { SetField(ref _materialMarkType, value, () => MaterialMarkType); }
        }

        private PriceType _priceType;
        public virtual PriceType PriceType
        {
            get { return _priceType; }
            set { SetField(ref _priceType, value, () => PriceType); }
        }

        public override string ToString()
        {
            return "Типоразмер раздела прайса";
        }
    }
}
