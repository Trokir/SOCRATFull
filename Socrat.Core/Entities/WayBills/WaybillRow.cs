using Socrat.Common;
using System;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.Core.Entities.WayBills
{
    /// <summary>
    /// Строка накладной
    /// </summary>
    [EntityFormConfiguration("Состав накладной", "Строка накладной: {Title}")]
    [PropertyVisualisation("Название", "Text", 200, 0)]
    [PropertyVisualisation("Площадь", "DisplayNumber", 50, 10)]
    [PropertyVisualisation("Цена за ед.", "PricePerItem", 50, 20)]
    [PropertyVisualisation("Количество", "Items", 50, 30)]
    [PropertyVisualisation("Сумма", "PricePerRow", 50, 40)]
    [PropertyVisualisation("Ставка НДС", "VatRate", 50, 50)]
    [PropertyVisualisation("Сумма НДС", "VatValue", 50, 60)]
    public class WaybillRow : Entity
    {
        public WaybillRow()
        {
            ProductionItems = new AttachedList<WaybillRowItem>(this);
        }

        #region locals
        private string _text;
        private double _quantity;
        private double _pricePerItem;
        private double _items;
        private double _pricePerRow;
        private double _weight;
        private double _vatRate = Preferences.VAT_RATE;
        private double _vatValue;
             
       
        #endregion

        #region Foreign keys

        public Guid ProductionMovementId { get; set; }

        #endregion

        #region Properties
        /// <summary>
        /// Список экземпляров изделий (физических), вошедших в строку накладной
        /// </summary>
        public AttachedList<WaybillRowItem> ProductionItems { get; private set; }

        /// <summary>
        /// Текст строки
        /// </summary>
        public string Text
        {
            get => _text;
            set => SetField(ref _text, value, () => Text);
        }

        /// <summary>
        /// Количество на строку. Пока непонятно зачем, скорее всего - сюдай пойдет площадь изделия
        /// </summary>
        public double Quantity
        {
            get => _quantity;
            set => SetField(ref _quantity, value, () => Quantity);
        }

        /// <summary>
        /// Цена за единицу изделия
        /// </summary>
        public double PricePerItem
        {
            get => _pricePerItem;
            set
            {
                _pricePerRow = _items * _pricePerItem;
                VatValue = Math.Round((_pricePerRow / (1 + VatRate) - _pricePerRow) * (-1), 2, MidpointRounding.ToEven);
                SetField(ref _pricePerItem, value, () => PricePerItem, () => PricePerRow, ()=> VatValue);
            }
        }

        /// <summary>
        /// Количество изделий в строке накладной
        /// </summary>
        public double Items
        {
            get => _items;
            set
            {
                _pricePerRow = _items * _pricePerItem;
                VatValue = Math.Round((_pricePerRow / (1 + VatRate) - _pricePerRow) * (-1), 2, MidpointRounding.ToEven);
                SetField(ref _items, value, () => Items, () => PricePerRow, () => VatValue);
            }
        }

        /// <summary>
        /// Цена строки (PricePerItem * Items)
        /// </summary>
        public double PricePerRow
        {
            get => _pricePerRow;
            set => SetField(ref _pricePerRow, value, () => PricePerRow);
        }

        /// <summary>
        /// Ставка НДС
        /// </summary>
        public double VatRate
        {
            get => _vatRate;
            set => SetField(ref _vatRate, value, () => VatRate);
        }

        /// <summary>
        /// Ставка НДС
        /// </summary>
        public double VatValue
        {
            get => _vatValue;
            set => SetField(ref _vatValue, value, () => VatValue);
        }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight
        {
            get => _weight;
            set => SetField(ref _weight, value, () => Weight);
        }

        /// <summary>
        /// Накладная, содержащая данную строку
        /// </summary>
        /// 
        [ParentItem]
        public virtual ProductionMovement ProductionMovement { get; set; }
        //[ParentItem]
        //public virtual Waybill Waybill
        //{
        //    get => _waybill;
        //    set => SetField(ref _waybill, value, () => Waybill);
        //}


        #endregion

        #region Overrides

        public override string ToString()
        {
            return Text;
        }

        #endregion

        
    }
}
