using Socrat.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Socrat.Services.Price
{
    public class Calculator
    {
        public static (double sum, List<CalculationResult> calcs) Calculate(Order order)
        {
            if (!order.OrderRows.Any(row => (row.TenderFormula?.Price ?? 0) != 0))
                throw new 

        }



        public static (double sum, List<CalculationResult> calcs) Calculate(Order order, bool flag)
        {
            double sum = 0;
            List<CalculationResult> calcs = new List<CalculationResult>();

            order.OrderRows.ForEach(item =>
            {
                if (item is OrderRow orderRow)
                {
                    CalculationResult result = Calculate(orderRow);
                    calcs.Add(result);

                    orderRow.PriceItem = result.RoundedPricePerItem;
                    orderRow.PriceRow = orderRow.PriceItem * orderRow.Qty;
                    orderRow.PriceRatio = result.RoundedPricePerMeasurementUnit;
                    orderRow.Koef = result.Factor;

                    sum = sum + (orderRow?.PriceRow ?? 0);
                }
            });

            return (sum, calcs);
        }

        public static CalculationResult Calculate(ICalculationRequest request)
        {
            if (request.AppliedPricePeriod == null)
                throw new PriceNotFoundException(request);

            CalculationResult result = new CalculationResult(request.QuantityPerItem, request);

            //if(request is OrderRow row)
            //{
            //    if (row.TenderFormula.Price != null)

            //}

            int calculationType = -1;

            #region Опеределяем базовые цены
            if (request.ItemType == ProductionType.Spo)
            {
                result.BasePrice = request?.AppliedPricePeriod?.BaseSpo ?? 0;
                calculationType = 1;
            }
            else if (request.ItemType == ProductionType.Spd)
            {
                result.BasePrice = request.AppliedPricePeriod?.BaseSpd ?? 0;
                calculationType = 1;
            }

            else if (request.ItemType == ProductionType.CuttedGlass || request.ItemType == ProductionType.Triplex )
            {
                calculationType = 2;
            }
            else
                calculationType = 3;

            if (result.BasePrice != 0)
                result.Replacements.Add(new Replacement("Базовая цена", result.BasePrice, 0));

            #endregion

            #region Определяем списки материалов
            request.AppliedPricePeriod?.PriceValues
                .Where(priceValue =>
                    request.UsedMaterialNoms.Any(materialNom =>
                        priceValue.MaterialNom.Id == materialNom.Id 
                        && priceValue.PriceSelectType.PriceType.CalculationType == calculationType
                        && priceValue.PriceSelectType.PriceType.NomenclatureCalculationOrder == 0
                        )).ToList()
                            .ForEach(priceValueForMaterialNom =>
                            {
                                //Формируем раздел А. Список основных материалов (замен), 
                                //когда Order == 0 и дополнительных - когда иначе
                                result.Replacements.Add(
                                    new Replacement(
                                        priceValueForMaterialNom, 
                                        priceValueForMaterialNom.PriceSelectType.PriceType.NomenclatureCalculationOrder));
                            });

            request.UsedMaterialNoms
                .Where(materialNom =>
                    request.AppliedPricePeriod.PriceValues.All(priceValue =>
                        priceValue.MaterialNom.Id != materialNom.Id)).ToList()
                            .ForEach(unpricedMaterialNom =>
                            {
                                //Формируем раздел I. Список использованных материалов (замен) без цен
                                result.Replacements.Add(new Replacement(unpricedMaterialNom, true));
                            });
            #endregion

            #region находим надбавку за форму
            if (request.AppliedPrice.PriceForms
                    .FirstOrDefault(
                        priceForm =>
                            priceForm.FormType.Id == request?.AppliedShape?.FormType?.Id) is PriceForm appliedPriceForm)
            {

                result.Modificators.Add(
                        new PriceModificator(
                            $"Наценка за форму \"{appliedPriceForm.FormType}\"",
                            appliedPriceForm.Discount,
                            ModificatorType.Multiplicator,
                            ApplianceType.PerMeasurementUnit,
                            appliedPriceForm
                            ));
            }
            #endregion

            #region находим надбавку за площадь

            if (calculationType == 1)
            {
                foreach (PriceSquRatio ratio in
                    request.AppliedPrice.PriceSquRatios
                        .OrderBy(ratio => ratio.Squ).ToList())
                {
                    if (ratio.Squ > request.QuantityPerItem)
                    {
                        result.Modificators.Add(
                            new PriceModificator(
                                $"Наценка за площадь <={ratio.Squ:f2} квм",
                                ratio.Ratio,
                                ModificatorType.Multiplicator,
                                ApplianceType.PerMeasurementUnit,
                                ratio
                                ));
                        break;
                    }
                };
            }

            #endregion

            #region находим надбавки за сложности

            request.AppliedPrice.PriceSlozs.Where(priceSloz =>
                request.AppliedSlozs.Any(appliedSloz =>
                    appliedSloz.SlozType.Id == priceSloz.SlozType.Id)).ToList()
                        .ForEach(pricedAppliedSloz =>
                        {
                            if (pricedAppliedSloz.AddValueToMeasurementItem != 0)
                            {
                                //Формируем раздел B2. Список модификаторов к (+цена) цене за ед.измерения
                                result.Modificators.Add(
                                new PriceModificator(
                                    $"Наценка за: \"{pricedAppliedSloz.SlozType}\"",
                                    pricedAppliedSloz.AddValueToMeasurementItem ?? 0,
                                    ModificatorType.AdditionalValue,
                                    ApplianceType.PerMeasurementUnit,
                                    pricedAppliedSloz
                                    ));
                            }

                            if (pricedAppliedSloz.MultiplyValueToEntireItem != 0)
                            {
                                //Формируем раздел С1. Список модификаторов (* коэффициент) к цене за единицу
                                result.Modificators.Add(
                                new PriceModificator(
                                    $"Наценка за: \"{pricedAppliedSloz.SlozType}\"",
                                    pricedAppliedSloz.MultiplyValueToEntireItem ?? 1,
                                    ModificatorType.Multiplicator,
                                    ApplianceType.PerItem,
                                    pricedAppliedSloz
                                    ));
                            }

                            if (pricedAppliedSloz.AddValueToEntireItem != 0)
                            {
                                //Формируем раздел С2. Список наценок (+ цена) к цене за единицу
                                result.Modificators.Add(
                                new PriceModificator(
                                    $"Наценка за: \"{pricedAppliedSloz.SlozType}\"",
                                    pricedAppliedSloz.AddValueToEntireItem ?? 0,
                                    ModificatorType.AdditionalValue,
                                    ApplianceType.PerItem,
                                    pricedAppliedSloz
                                    ));
                            }
                        });

            //Формируем раздел J. Список использованных сложностей (замен) без цен
            request.AppliedSlozs.Where(appliedSloz =>
                request.AppliedPrice.PriceSlozs.All(priceSloz =>
                    appliedSloz.SlozType.Id != priceSloz.SlozType.Id)).ToList()
                       .ForEach(unpricedAppliedSloz =>
                       {
                           result.Modificators.Add(
                               new PriceModificator(
                                   $"Наценка за: \"{unpricedAppliedSloz.SlozType}\"",
                                   0,
                                   ModificatorType.Unknown,
                                   ApplianceType.Unknown,
                                   unpricedAppliedSloz
                                   ));
                       });
            #endregion            

            #region Определяем перечни операций
            request.AppliedPricePeriod.PricePeriodProcessingNoms
                .Where(pricePeriodProcessingNoms =>
                    request.AppliedProcessings.Any(processingNom =>
                        processingNom.ProcessingNom.Processing.Id == pricePeriodProcessingNoms.ProcessingNom.Processing.Id)).ToList()
                            .ForEach(pricedPricePeriodProcessingNom =>
                            {
                            if (pricedPricePeriodProcessingNom.AdditionalPriceValue != 0)
                                    result.Modificators.Add(new PriceModificator(
                                    $"Наценка за: \"{pricedPricePeriodProcessingNom.ProcessingNom}\"",
                                    pricedPricePeriodProcessingNom.AdditionalPriceValue,
                                    ModificatorType.AdditionalValue,
                                    ApplianceType.PerItem,
                                    pricedPricePeriodProcessingNom));

                            if (pricedPricePeriodProcessingNom.MultiplyPriceFactor != 0)
                                    result.Modificators.Add(new PriceModificator(
                                        $"Наценка за: \"{pricedPricePeriodProcessingNom.ProcessingNom}\"",
                                        pricedPricePeriodProcessingNom.MultiplyPriceFactor,
                                        ModificatorType.Multiplicator,
                                        ApplianceType.PerItem,
                                        pricedPricePeriodProcessingNom));
                            });

            request.AppliedProcessings.Where(processingNom =>
                request.AppliedPricePeriod.PricePeriodProcessingNoms.All(pricePeriodProcessingNom =>
                    pricePeriodProcessingNom.ProcessingNom.Processing.Id != processingNom.ProcessingNom.Processing.Id)).ToList()
                        .ForEach(unpricedProcessingNom =>
                        {
                            result.Modificators.Add(new PriceModificator(
                                        $"Наценка за: \"{unpricedProcessingNom}\"",
                                        0,
                                        ModificatorType.Unknown,
                                        ApplianceType.Unknown,
                                        unpricedProcessingNom));
                        });
            #endregion

            #region Определяем перечень компонентов и доп.материалов
            //Из компонентов
            request.AppliedPricePeriod.PriceValues.Where(priceValue =>
                    request.UsedComponents.Any(processingComponent =>
                        priceValue.MaterialNom.Id == processingComponent.MaterialNom.Id)).ToList()
                            .ForEach(priceValueForMaterialNom =>
                            {
                                result.Replacements.Add(
                                    new Replacement(
                                        priceValueForMaterialNom,
                                        priceValueForMaterialNom.PriceSelectType.PriceType.NomenclatureCalculationOrder));
                            });

            //Из доп.материалов
            request.AppliedPricePeriod.PriceValues.Where(priceValue =>
                    request.AdditionalMaterialNoms.Any(additionalMaterialNoms =>
                        priceValue.MaterialNom.Id == additionalMaterialNoms.MaterialNom.Id)).ToList()
                            .ForEach(priceValueForMaterialNom =>
                            {
                                result.Replacements.Add(
                                    new Replacement(
                                        priceValueForMaterialNom,
                                        priceValueForMaterialNom.PriceSelectType.PriceType.NomenclatureCalculationOrder,
                                        request.AdditionalMaterialNoms.FirstOrDefault(x => x.MaterialNom.Id == priceValueForMaterialNom.MaterialNom.Id)?.Quantity ?? 0
                                        ));
                            });

            request.AdditionalMaterialNoms
               .Where(additionalMaterialNoms =>
                   request.AppliedPricePeriod.PriceValues.All(priceValue =>
                       priceValue.MaterialNom.Id != additionalMaterialNoms.MaterialNom.Id)).ToList()
                           .ForEach(unpricedAdditionalMaterialNoms =>
                           {
                                //Формируем раздел I. Список использованных материалов (замен) без цен
                                result.Replacements.Add(new Replacement(unpricedAdditionalMaterialNoms.MaterialNom, true));
                           });

            request.UsedComponents
              .Where(usedComponents =>
                  request.AppliedPricePeriod.PriceValues.All(priceValue =>
                      priceValue.MaterialNom.Id != usedComponents.MaterialNom.Id)).ToList()
                          .ForEach(unpricedProcessingComponent =>
                          {
                               //Формируем раздел I. Список использованных материалов (замен) без цен
                               result.Replacements.Add(new Replacement(unpricedProcessingComponent.MaterialNom, true));
                          });

            #endregion

            return result;
        }
    }
}
