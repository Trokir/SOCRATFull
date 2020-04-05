using Socrat.Common.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Reflection;

namespace Socrat.Core.Entities
{
    /// <summary>
    /// Виртуальная сущность для представления цен на номенклатуру в гриде
    /// </summary>
    [EntityFormConfiguration("Перечень цен", "Редактировать цену")]
    [PropertyVisualisation("Рубрика", "PriceTopic", 60, 0, false)]
    [PropertyVisualisation("Тип материала", "MaterialType", 70, 10, true)]
    [PropertyVisualisation("Материал", "Material", 70, 20, true)]
    [PropertyVisualisation("Группа материалов", "MaterialMarkType", 70, 30, true)]
    [PropertyVisualisation("Название", "DisplayName", 250, 40)]
    [PropertyVisualisation("Толщина", "MaterialSizeType.Thickness", 20, 50, false, DevExpress.Utils.HorzAlignment.Center, "", "f0", "", " мм.")]
    [PropertyVisualisation("Цена, руб.", "Price", 20, 60, false, DevExpress.Utils.HorzAlignment.Far, "", "c2")]
    [PropertyVisualisation("за", "PriceMeasurementUnit", 20, 70, false, DevExpress.Utils.HorzAlignment.Center)]
    [PropertyVisualisation("Применять", "FlaggedProductionTypeName", 40, 80, false, DevExpress.Utils.HorzAlignment.Center)]
    [PropertyVisualisation("Код 1С", "Code1c", 20, 90, false)]
    public class VirtualPriceItem : Entity
    {
        public VirtualPriceItem(){}
        public VirtualPriceItem(PriceValue priceValue)
        {
            _priceValue = priceValue;
            _pricePeriod = priceValue.PricePeriod;
            _materialNom = priceValue.MaterialNom;
            _value = priceValue.PriceVal;
            _FlaggedProductionType = priceValue.FlaggedProductionType;
            _MeasurementUnit = priceValue.MeasurementUnit;
            _PriceTopic = priceValue.PriceTopic;
            _code1c = priceValue.MaterialNom?.Code1C;
        }
        public VirtualPriceItem(MaterialNom materialNom)
        {
            MaterialNom = materialNom;
            _value = 0;
            _code1c = materialNom.Code1C;
        }

        #region Local variables

        private double _value;
        private MaterialNom _materialNom;
        private PriceValue _priceValue;
        private PricePeriod _pricePeriod;
        private string _code1c;
        private FlaggedProductionTypes _FlaggedProductionType;
        private Measure _MeasurementUnit;
        private string _PriceTopic;

        #endregion

        #region Foreign keys

        public Guid MaterialNomId { get; set; }
        public Guid? MaterialTypeId { get => PriceValue?.MaterialNom.Material.MaterialType.Id; }
        public Guid? MaterialId { get => PriceValue?.MaterialNom.Material.Id; }
        public Guid? PriceValueId { get; set; }
        public Guid? MaterialMarkTypeId { get => MaterialMarkType?.Id; }
        public Guid? PricePeriodId { get; set; }
        public Guid? MeasureId { get; set; }
        #endregion

        #region Properties

        public virtual MaterialNom MaterialNom
        {
            get => _materialNom;
            set => SetField(ref _materialNom, value, () => MaterialNom);
        }
        public virtual PriceValue PriceValue
        {
            get => _priceValue;
            set => SetField(ref _priceValue, value, () => PriceValue);
        }
        [ParentItem]
        public virtual PricePeriod PricePeriod
        {
            get => _pricePeriod;
            set => SetField(ref _pricePeriod, value, () => PricePeriod);
        }
        public virtual Measure MeasurementUnit
        {
            get => _MeasurementUnit;
            set => SetField(ref _MeasurementUnit, value, () => MeasurementUnit);
        }
        public virtual string PriceTopic
        {
            get => _PriceTopic;
            set => SetField(ref _PriceTopic, value, () => PriceTopic);
        }

        public double Price
        {
            get => _value;
            set
            {
                SetField(ref _value, value, () => Price);
            }
        }

        public string Code1c
        {
            get => _code1c;
            set => SetField(ref _code1c, value, () => Code1c);
        }

        /// <summary>
        /// Флаг принадлежности к типам продукции (используется для формирования цены)
        /// </summary>
        public FlaggedProductionTypes FlaggedProductionType
        {
            get { return _FlaggedProductionType; }
            set { SetField(ref _FlaggedProductionType, value, () => FlaggedProductionType); }
        }

        #endregion

        #region ViewModel fields
        [NotMapped]
        public virtual MaterialType MaterialType { get => PriceValue?.MaterialNom.Material.MaterialType; }
        [NotMapped]
        public virtual Material Material {get => PriceValue?.MaterialNom.Material;}
        [NotMapped]
        public virtual MaterialMarkType MaterialMarkType {get => MaterialNom?.VendorMaterialNom?.MaterialMarkType;}
        [NotMapped]
        public virtual Measure Measure { get => MaterialNom.MaterialSizeType.Measure; }
        [NotMapped]
        public virtual MaterialSizeType MaterialSizeType { get => MaterialNom.MaterialSizeType; }
        [NotMapped]
        public virtual VendorMaterialNom VendorMaterialNom { get => MaterialNom.VendorMaterialNom; }
        [NotMapped]
        public string DisplayName { get => $"{MaterialNom}"; }
        [NotMapped]
        public string PriceMeasurementUnit { get => $"{PriceValue?.MeasurementUnit?.ShortName}"; }
        [NotMapped]
        public string FlaggedProductionTypeName
        {
            get => _FlaggedProductionType.GetString();
        }
        [NotMapped]
        public virtual Material SupposedMaterial { get; set; }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"{DisplayName} {Price:c2}";
        }
        #endregion
    }
}
