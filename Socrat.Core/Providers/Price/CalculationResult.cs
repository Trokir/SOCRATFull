using System;
using System.Collections.Generic;
using System.Linq;

namespace Socrat.Core.Providers.Price
{
    public class CalculationResult
    {
        /// <summary>
        /// Точность округления для множителя (то есть, для коэффициента, выражаемого в процентах)
        /// </summary>
        public int FactorPrecision { get; private set; } = 3;

        /// <summary>
        /// Точность округления для цены
        /// </summary>
        public int PricePrecision { get; private set; } = 2;

        /// <summary>
        /// Добавлять надбавку к цене перед применением множителя при вычислении цены за единицу измерения
        /// </summary>
        public bool AddValueBeforeApplyFactorPerMeasurementUnit { get; } = true;

        /// <summary>
        /// Добавлять надбавку к цене перед применением множителя при вычислении цены изделия
        /// </summary>
        public bool AddValueBeforeApplyFactorPerItem { get; } = false;

        /// <summary>
        /// Количество на единицу изделия (т.е. типа - площадь изделия)
        /// </summary>
        public double QuantityPerItem { get => Request.QuantityPerItem; }

        /// <summary>
        /// Количество изделий
        /// </summary>
        public double ItemsQuantity { get => Request.Quantity; }

        /// <summary>
        /// Параметры расчета
        /// </summary>
        public ICalculationRequest Request { get; private set; }

        /// <summary>
        /// Результат расчета
        /// </summary>
        /// <param name="quantityPerItem"></param>
        /// <param name="request"></param>
        public CalculationResult(double quantityPerItem, ICalculationRequest request)
        {
            Request = request;
        }

        /// <summary>
        /// Перечень замен
        /// </summary>
        public List<Replacement> Replacements { get; } = new List<Replacement>();

        /// <summary>
        /// Перечень модификаторов цены
        /// </summary>
        public List<PriceModificator> Modificators { get; } = new List<PriceModificator>();

        /// <summary>
        /// Базовая цена изделия за ед.измерения
        /// </summary>
        public double BasePrice { get; set; }

        /// <summary>
        /// Перечень базовых материалов изделия
        /// </summary>
        public List<Replacement> BaseMaterials
        {
            get => Replacements.Where(replacement => replacement.Order == 0).ToList();
        }

        /// <summary>
        /// Перечень замен комплонентов изделия
        /// </summary>
        public List<Replacement> ComponentMaterials
        {
            get => Replacements.Where(replacement => replacement.Order > 0).ToList();
        }

        /// <summary>
        /// Перечень замен базовых материалов изделия
        /// </summary>
        public List<Replacement> BaseReplacements { get => Replacements.Where(replacement => replacement.Order == 0).ToList(); }

        public double BaseMaterialsPricePerMeasurementUnit { get => BaseReplacements.Sum(baseReplacement => baseReplacement.Price); }

        public double BaseMaterialsPricePerItem { get => BaseMaterialsPricePerMeasurementUnit * QuantityPerItem; }

        public List<Replacement> AdditionalReplacements { get => Replacements.Where(replacement => replacement.Order > 0).ToList(); }

        public double AdditionalMaterialsPricePerMeasurementUnit { get => Math.Round(ComponentMaterials.Sum(baseReplacement => baseReplacement.Price), PricePrecision); }

        public double AdditionalMaterialsPricePerItem { get => Math.Round(AdditionalMaterialsPricePerMeasurementUnit * QuantityPerItem, PricePrecision); }

        public List<Replacement> UnpricedReplacements { get => Replacements.Where(replacement => replacement.Order < 0).ToList(); }

        public List<PriceModificator> PerMeasurementUnitFactors
        {
            get => Modificators
                .Where(modificator =>
                    modificator.ModificatorType == ModificatorType.Multiplicator
                    && modificator.ApplianceType == ApplianceType.PerMeasurementUnit).ToList();
        }

        public double PerMeasurementUnitFactor
        {
            get
            {
                double factor = 1;
                PerMeasurementUnitFactors.ForEach(modificator =>
                {
                    factor = factor * (modificator.Value == 0 ? 1 : (1 + modificator.Value));
                });
                return Math.Round(factor, FactorPrecision);
            }
        }

        /// <summary>
        /// Перечень надбавкок к цене за единицу измерения изделия
        /// </summary>
        public List<PriceModificator> PerMeasurementUnitAdditionalValues
        {
            get => Modificators
                .Where(modificator =>
                    modificator.ModificatorType == ModificatorType.AdditionalValue
                    && modificator.ApplianceType == ApplianceType.PerMeasurementUnit).ToList();
        }

        /// <summary>
        /// Значение надбавки к цене за единицу измерения изделия
        /// </summary>
        public double PerMeasurementUnitAdditionalValue
        {
            get => PerMeasurementUnitAdditionalValues.Sum(modificator => modificator.Value);
        }

        /// <summary>
        /// Модификаторы цены, применяемые к изделию
        /// </summary>
        public List<PriceModificator> PerItemFactors
        {
            get => Modificators
                .Where(modificator =>
                    modificator.ModificatorType == ModificatorType.Multiplicator
                    && modificator.ApplianceType == ApplianceType.PerItem).ToList();
        }

        /// <summary>
        /// Итоговый коэффициент цены, применяемый к изделию
        /// </summary>
        public double PerItemFactor
        {
            get
            {
                double factor = 1;
                PerItemFactors.ForEach(modificator =>
                {
                    factor = factor * (modificator.Value == 0 ? 1 : (1 + modificator.Value));
                });
                return Math.Round(factor, FactorPrecision);
            }
        }

        /// <summary>
        /// Перечень надбавкок к цене изделия
        /// </summary>
        public List<PriceModificator> PerItemAdditionalValues
        {
            get => Modificators
                .Where(modificator =>
                    modificator.ModificatorType == ModificatorType.AdditionalValue
                    && modificator.ApplianceType == ApplianceType.PerItem).ToList();
        }

        /// <summary>
        /// Итоговыя надбавка к цене за изделие
        /// </summary>
        public double PerItemAdditionalValue
        {
            get => PerItemAdditionalValues.Sum(modificator => modificator.Value);
        }

        /// <summary>
        /// Модификаторы стоимости, для которых не надено цен
        /// </summary>
        public List<PriceModificator> UnpricedModificators
        {
            get => Modificators
                .Where(modificator =>
                    modificator.ModificatorType == ModificatorType.Unknown
                    || modificator.ApplianceType == ApplianceType.Unknown).ToList();
        }

        /// <summary>
        /// Базовая цена за ед.измерения изделия
        /// </summary>
        public double BasePricePerMeasurementItem
        {
            get
            {
                if (AddValueBeforeApplyFactorPerMeasurementUnit)
                    return Math.Round((BaseMaterialsPricePerMeasurementUnit + PerMeasurementUnitAdditionalValue) * PerMeasurementUnitFactor, PricePrecision);
                else
                    return Math.Round((BaseMaterialsPricePerMeasurementUnit * PerMeasurementUnitFactor) + PerMeasurementUnitAdditionalValue, PricePrecision);
            }
        }

        /// <summary>
        /// Базовая цена за изделие
        /// </summary>
        public double BasePricePerItem
        {
            get
            {
                double basePrice = Math.Round(BasePricePerMeasurementItem * QuantityPerItem, PricePrecision);
                double minPrice = 0;

                if (Request.ItemType == Entities.ProductionType.Spd || Request.ItemType == Entities.ProductionType.Spo)
                {
                    Modificators.ForEach(modificator =>
                    {
                        if (modificator.Entity is Core.Entities.PriceSquRatio priceSquRatio)
                            minPrice = priceSquRatio.MinPrice;
                    });

                    if (minPrice > basePrice)
                        basePrice = Math.Round(minPrice, PricePrecision);
                }

                return basePrice;
            }
        }

        /// <summary>
        /// Цена за изделие
        /// </summary>
        public double PricePerItem
        {
            get
            {
                if (AddValueBeforeApplyFactorPerItem)
                    return Math.Round((BasePricePerItem + PerItemAdditionalValue) * PerItemFactor + AdditionalMaterialsPricePerItem, PricePrecision);
                else
                    return Math.Round((BasePricePerItem * PerItemFactor) + PerItemAdditionalValue + AdditionalMaterialsPricePerItem, PricePrecision);
            }
        }

        /// <summary>
        /// Цена за ед.измерения изделия
        /// </summary>
        public double PricePerMeasurementItem
        {
            get => Math.Round(PricePerItem / QuantityPerItem, PricePrecision);
        }

        private double _roundedPricePerItem;
        /// <summary>
        /// Округленное значение цены изделия
        /// </summary>
        public double RoundedPricePerItem
        {
            get
            {
                _roundedPricePerItem = 
                    Math.Round(
                        _roundedPricePerMeasurementUnit * 
                        Math.Round(PerItemFactor * 
                        PerMeasurementUnitFactor, 3) * 
                        QuantityPerItem, 
                    PricePrecision);
                return _roundedPricePerItem;
            }
        }

        public double Factor { get => Math.Round(PerItemFactor * PerMeasurementUnitFactor, 3); }

        private double _roundedPricePerMeasurementUnit;
        /// <summary>
        /// Округленное значение цены за ед.изм
        /// </summary>
        public double RoundedPricePerMeasurementUnit
        {
            get
            {
                _roundedPricePerMeasurementUnit = 
                    Math.Round(
                        PricePerItem /
                        QuantityPerItem /
                        PerItemFactor /
                        PerMeasurementUnitFactor,  
                    0);
                return _roundedPricePerMeasurementUnit;
            }
        }

        public override string ToString()
        {
            return $"{Request}";
        }        
    }
}
