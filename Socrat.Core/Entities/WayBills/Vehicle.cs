
using Socrat.Common.Attributes;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.Core.Entities.WayBills
{
    /// <summary>
    /// Учетные данные автомобиля. Типа, чей угодно.
    /// </summary>
    [Editor("Socrat.Module.Waybills")]
    [EntityFormConfiguration("Автотранспорт", "{Title}")]
    [PropertyVisualisation("Автомобиль", "Name", 200, 0)]
    [PropertyVisualisation("Гос.номер", "Number", 100, 10)]
    public class Vehicle:Entity
    {
        #region locals

        private string _name;
        private string _number;

        #endregion

        #region Properties

        /// <summary>
        /// Марка автомобиля. Типа ГАЗ-66
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetField(ref _name, value, () => Name);
        }

        /// <summary>
        /// Регистрационный номер (гос.номер)
        /// </summary>
        public string Number
        {
            get => _number;
            set => SetField(ref _number, value, () => Number);
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"{Name} {Number}";
        }
        #endregion

        

    }
}
