using Socrat.Common.Enums;
using Socrat.Core;

namespace Socrat.Services.Price
{
    public class PriceModificator : IPriceModificator
    {
        public string Name { get; private set; }
        public double Value { get; private set; }
        public double Sum { get; set; }
        public PriceModificatorTypes ModificatorType {get; private set; }
        public PriceApplianceTypes ApplianceType { get; private set; }
        public IEntity Entity { get; private set; }
        public string ModificatorTypeName
        {
            get
            {
                if (ModificatorType == PriceModificatorTypes.AdditionalValue)
                    return "Добавить";
                else if (ModificatorType == PriceModificatorTypes.Multiplicator)
                    return "Умножить";
                else
                    return $"{ModificatorType}";
            }
        }
        public string ApplianceTypeName
        {
            get
            {
                if (ApplianceType == PriceApplianceTypes.PerMeasurementUnit)
                    return "К цене ед.изм";
                else if (ApplianceType == PriceApplianceTypes.PerItem)
                    return "К цене изделия";
                else
                    return $"{ModificatorType}";
            }
        }
        public PriceModificator(string name, double value, PriceModificatorTypes modificatorType, PriceApplianceTypes applicanceType, Entity entity)
        {
            Name = name;
            Value = value;
            ModificatorType = modificatorType;
            ApplianceType = applicanceType;
            Entity = entity;
        }
        public override string ToString()
        {
            return $"{Entity}";
        }
    }
}
