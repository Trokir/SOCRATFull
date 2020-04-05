using Socrat.Common.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.Core.Entities.WayBills
{
    /// <summary>
    /// Накладная
    /// </summary>
    //[Editor("Socrat.Module.Waybills")]
    //[EntityFormConfiguration("Накладные", "Накладная: {Title}")]
    //[PropertyVisualisation("У", "IsManagementAccounted", 10, 0)]
    //[PropertyVisualisation("Дата", "Dated", 50, 5, false, DevExpress.Utils.HorzAlignment.Center, "", "d")]
    //[PropertyVisualisation("Номер", "DisplayNumber", 50, 10)]
    //[PropertyVisualisation("Грузополучатель", "Consignee", 50, 20, true)]
    //[PropertyVisualisation("Адрес", "DeliveryAddress", 200, 30, true)]
    //[PropertyVisualisation("Водитель/автомобиль", "Driver", 50, 40)]
    //[PropertyVisualisation("Примечание", "Comments", 500, 50)]
    public class Waybill : Entity
    {
        public Waybill()
        {
            
        }

        #region Locals

        
        private bool _isManagementAccounted = false;
        

        private Customer _seller;
        private Customer _consignee;
        private Customer _buyer;
        private Customer _consignor;

        private CustomerAddress _deliveryAddress;
        private CustomerCoworker _customerCoworker;
        private Vehicle _vehicle;

        #endregion

        #region ForeignKeys

        public Guid SellerId { get; set; }
        public Guid ConsigneeId { get; set; }
        public Guid BuyerId { get; set; }
        public Guid ConsignorId { get; set; }

        public Guid DeliveryAddressId{ get; set; }
        public Guid CustomerCoworkerId { get; set; }
        public Guid VehicleId { get; set; }

        #endregion

        #region Properties
        

        

        /// <summary>
        /// Признак накладной "управленческого учета" (У)
        /// </summary>
        public bool IsManagementAccounted
        {
            get => _isManagementAccounted;
            set => SetField(ref _isManagementAccounted, value, () => IsManagementAccounted);
        }

        

        /// <summary>
        /// Заказчик (то есть, для документа - покупатель)
        /// </summary>
        //[ParentItem]
        public virtual Customer Buyer
        {
            get => _buyer;
            set => SetField(ref _buyer, value, () => Buyer);
        }

        /// <summary>
        /// Грузополучатель для документа
        /// </summary>
        public virtual Customer Consignee
        {
            get => _consignee;
            set => SetField(ref _consignee, value, () => Consignee);
        }

        /// <summary>
        /// продавец
        /// </summary>
        public virtual Customer Seller
        {
            get => _seller;
            set => SetField(ref _seller, value, () => Seller);
        }

        /// <summary>
        /// грузоотправитель
        /// </summary>
        public virtual Customer Consignor
        {
            get => _consignor;
            set => SetField(ref _consignor, value, () => Consignor);
        }

        /// <summary>
        /// Адрес доставки
        /// </summary>
        public virtual CustomerAddress DeliveryAddress
        {
            get => _deliveryAddress;
            set => SetField(ref _deliveryAddress, value, () => DeliveryAddress);
        }

        /// <summary>
        /// Водитель/экспедитор - ссылка на работника контрагента
        /// </summary>
        public virtual CustomerCoworker CustomerCoworker
        {
            get => _customerCoworker;
            set => SetField(ref _customerCoworker, value, () => CustomerCoworker);
        }

        /// <summary>
        /// Автомашина
        /// </summary>
        public virtual Vehicle Vehicle
        {
            get => _vehicle;
            set => SetField(ref _vehicle, value, () => Vehicle);
        }

        public virtual ProductionMovement ProductionMovement { get; set; }

        #endregion

        #region ViewModel
        /// <summary>
        /// Сцепка "Персона + автомобиль" для отображения в гриде
        /// </summary>
        [NotMapped]
        public string Driver { get => $"{CustomerCoworker?.Coworker} ({Vehicle})"; }

        /// <summary>
        /// Сцепка номера с буквой "У" для накладных lol "управленческого учета"
        /// </summary>
        [NotMapped]
        public string DisplayNumber { get => _isManagementAccounted ? $"{ProductionMovement.Number}У" : $"{ProductionMovement.Number}"; }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"{ProductionMovement.Source?.Division?.Number.PadLeft(2, '0')}/{ProductionMovement.Dated.Year}/{ProductionMovement.Source?.Code}/{DisplayNumber}";
        }

        #endregion

       
    }
}
