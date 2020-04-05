using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socrat.Core.Entities
{
    [PropertyVisualisation("Цена", "PriceVal", 150, 1)]
    [PropertyVisualisation("Изменено", "Date", 180, 0)]
    [PropertyVisualisation("Редактор", "Editor", 150, 2)]
    [EntityFormConfiguration("История изменения цены", "Архивное значение")]
    public class PriceValueHistory : Entity, ICloneable
    {
        #region Ctors
        public PriceValueHistory() {}

        #endregion

        #region Locals

        private double _priceVal;
        private DateTime _date;
        private string _editor;
        private MaterialNom _materialNom;
        private PricePeriod _pricePeriod;
        private PriceSelectType _priceSelectType;
        private PriceValue _priceValue;

        #endregion

        #region Foreign keys

        public Guid PricePeriodId { get; set; }

        public Guid? PriceSelectTypeId { get; set; }

        public Guid MaterialNomId { get; set; }

        public Guid PriceValueId { get; set; }

        #endregion

        #region Collection

        #endregion

        #region Properties

        public double PriceVal
        {
            get => _priceVal;
            set => SetField(ref _priceVal, value, () => PriceVal);
        }

        public DateTime Date
        {
            get => _date;
            set => SetField(ref _date, value, () => Date);
        }

        public string Editor
        {
            get => _editor;
            set => SetField(ref _editor, value, () => Editor);
        }

        public MaterialNom MaterialNom
        {
            get => _materialNom;
            set => SetField(ref _materialNom, value, () => MaterialNom);
        }


        public PricePeriod PricePeriod
        {
            get => _pricePeriod;
            set => SetField(ref _pricePeriod, value, () => PricePeriod);
        }


        public PriceSelectType PriceSelectType
        {
            get => _priceSelectType;
            set => SetField(ref _priceSelectType, value, () => PriceSelectType);
        }


        public PriceValue PriceValue
        {
            get => _priceValue;
            set => SetField(ref _priceValue, value, () => PriceValue);
        }

        #endregion

        #region Overrides

        protected override string GetTitle()
        {
            return $"Цена: {DisplayName}";
        }

        public override string ToString()
        {
            return DisplayName;
        }

        #endregion

        #region ICloneable implementation

        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion

        #region ViewModel fields

        [NotMapped]
        public string DisplayName { get => $"{MaterialNom}"; }
        [NotMapped]
        public string ValueInGrid { get => $"{MaterialNom}: {PriceVal:c2}"; }
        [NotMapped]
        public Guid? PriceTypeId { get => PriceType?.Id; }
        [NotMapped]
        public Guid? MaterialMarkTypeId { get => MaterialMarkType?.Id; }
        [NotMapped]
        public Guid? MeasureId { get; set; }
        [NotMapped]
        public Guid? MaterialSizeTypeId { get; set; }
        [NotMapped]
        public Guid? VendorMaterialNomId { get; set; }
        [NotMapped]
        public PriceType PriceType
        {
            get => PriceSelectType.PriceType;
        }
        [NotMapped]
        public MaterialMarkType MaterialMarkType
        {
            get => MaterialNom.VendorMaterialNom?.MaterialMarkType;
        }
        [NotMapped]
        public Measure Measure { get => PriceSelectType.PriceType.Measure; }
        [NotMapped]
        public MaterialSizeType MaterialSizeType { get => MaterialNom?.MaterialSizeType; }
        [NotMapped]
        public VendorMaterialNom VendorMaterialNom { get => MaterialNom?.VendorMaterialNom; }
        #endregion
    }
}
