using Socrat.Common.Enums;
using Socrat.Common.Interfaces.Price;
using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Socrat.Services.Price
{
    public class Calculator
    {
        /// <summary>
        /// Расчитать заказ на дату
        /// </summary>
        /// <param name="order">Заказ</param>
        /// <param name="onDate">Дата, на которую производится расчет</param>
        /// <returns></returns>
        public static (double sum, List<ICalculationResult> calcs) Calculate(Order order, DateTime onDate)
        {
            PricePeriod appliedPricePeriod = ValidateRequest(order, onDate);

            double sum = 0;
            List<ICalculationResult> calcs = new List<ICalculationResult>();

            //Считаем все цены автоматически
            order.OrderRows.ForEach(orderRow =>
            {
                ICalculationResult result = Calculate(new CalculationRequest(orderRow, appliedPricePeriod));
                calcs.Add(result);

                orderRow.PriceRatio = result.RoundedPricePerMeasurementUnit;
                orderRow.PriceItem = result.RoundedPricePerItem;
                orderRow.PriceRow = orderRow.PriceItem * orderRow.Qty;
                orderRow.Koef = result.Factor;

                sum = sum + (orderRow?.PriceRow ?? 0);
            });
            order.SetDisplayedSumAfterDistribution(sum);
            return (sum, calcs);
        }

        /// <summary>
        /// Расчитать строку заказа на дату
        /// </summary>
        /// <param name="orderRow">Строка заказа</param>
        /// <param name="onDate">Дата, на которую производится расчет</param>
        /// <returns></returns>
        public static ICalculationResult Calculate(OrderRow orderRow, DateTime onDate)
        {
            return Calculate(
                new CalculationRequest(
                    orderRow,
                    ValidateRequest(orderRow.Order, onDate)));
        }

        private static PricePeriod ValidateRequest(Order order, DateTime onDate)
        {   
            if (order.Contract != null && order.Contract.PriceId != null)
                // прогрузка прайса, который возможно не прогружен (не сработавший LazyLoad)
                DataProvider.DataHelper.GetItem<Core.Entities.Price>(order.Contract.PriceId.Value);
                
            if (order.Contract?.Price == null)
                throw new PriceNotFoundException(order);

            if (order.Contract.Price != null && order.Contract.Price.PricePeriods.Count == 0)
                // прогрузка прайса, который возможно не прогружен (не сработавший LazyLoad)
                DataProvider.DataHelper.GetAll<PricePeriod>(x => x.PriceId == order.Contract.Price.Id);

            if (!(Calculator.GetActualPricePeriod(order.Contract?.Price,  onDate) is PricePeriod appliedPricePeriod))
                throw new PricePeriodNotFoundException(order);

            if (order.IsOrderRowsPriceTypeConsistent == null)
                throw new TenderCalculationRequestNotCompleteException(order);

            return appliedPricePeriod;
        }

        public static void Distribute(Order order, double value)
        {
            double oldSum = order.OrderRows.Sum(orderRow => orderRow.DisplayedPricePerOrderRow);

            if (oldSum == double.NaN)
                oldSum = 0;
            double orderDelta = 0;
            order.OrderRows.ForEach(orderRow =>
            {
                double rowDelta = 0;
                if (orderRow.DisplayedPricePerOrderRow != double.NaN)
                {
                    double sumFactor = oldSum / orderRow.DisplayedPricePerOrderRow;
                    //rowDelta = orderRow.Recalculate(Math.Round(value / sumFactor, 2));
                    rowDelta = Math.Round(rowDelta, 2);
                    orderDelta += rowDelta;
                }
            });

            double newSum = 0;
            order.OrderRows.ForEach(row =>
                newSum += row.DisplayedPricePerOrderRow);
            order?.SetDisplayedSumAfterDistribution(Math.Round(newSum, 2));
            //OnSumChaged(new SumChangedEventArgs(PriceCalculationTypes.ByPricePerOrder, newSum));
        }

        public static ICalculationResult Calculate(CalculationRequest request)
        {
            ICalculationResult result = new CalculationResult(request.QuantityPerItem, request);
            int calculationType = -1;
            calculationType = GetCalculationType(request);

            #region Опеределяем базовые цены
            if (result.BasePrice != 0)
                result.Replacements.Add(new Replacement("Базовая цена", result.BasePrice, 0));
            #endregion

            // Определяем списки материалов
            result.Replacements.AddRange(
                GetMaterials(request));

            // находим надбавку за форму
            result.Modificators.AddRange(
                GetFormPriceModificators(request));

            // находим надбавку за площадь
            result.Modificators.AddRange(
                GetSizePriceModificators(request));

            // находим надбавки за сложности
            result.Modificators.AddRange(
                GetSlozPriceModificators(request));

            //Формируем раздел J. Список использованных сложностей (замен) без цен
            result.Modificators.AddRange(
               GetUnpricedSlozPriceModificators(request));

            // Определяем перечни операций
            result.Modificators.AddRange(
                GetProcessingPriceModificators(request));

            // Определяем перечни операций без цен
            result.Modificators.AddRange(
                GetUnpricedProcessingPriceModificators(request));

            //Определяем перечень компонентов для операций обработки
            result.Replacements.AddRange(
                GetProcessingComponents(request));

            //Определяем перечень доп.материалов
            result.Replacements.AddRange(
                GetAdditionalMaterials(request));

            //Формируем раздел I. Список использованных материалов (замен) без цен
            result.Replacements.AddRange(
                GetUnpricedProcessingComponents(request));

            result.Replacements.AddRange(
                GetUnpricedAdditionalMaterials(request));
            //Формируем раздел I. Список использованных материалов (замен) без цен

            return result;
        }

        /// <summary>
        /// Возвращает тип расчета в зависимости от типа продукции
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static int GetCalculationType(ICalculationRequest request)
        {
            if (request.ItemType == ProductionTypes.Spo || request.ItemType == ProductionTypes.Spd)
                return 1;
            else if (request.ItemType == ProductionTypes.CuttedGlass || request.ItemType == ProductionTypes.Triplex)
                return 2;
            throw new WrontProductionTypeException(request);
        }

        /// <summary>
        /// Возвращает модификации цены за форму
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static List<IPriceModificator> GetFormPriceModificators(ICalculationRequest request)
        {
            List<IPriceModificator> result = new List<IPriceModificator>();
            if (request.AppliedPrice.PriceForms
                   .FirstOrDefault(
                       priceForm =>
                           priceForm.FormType.Id == request?.AppliedShape?.FormType?.Id) is PriceForm appliedPriceForm)
            {

                result.Add(
                        new PriceModificator(
                            $"Наценка за форму \"{appliedPriceForm.FormType}\"",
                            appliedPriceForm.Discount,
                            PriceModificatorTypes.Multiplicator,
                            PriceApplianceTypes.PerMeasurementUnit,
                            appliedPriceForm
                            ));
            }
            return result;
        }

        /// <summary>
        /// Возвращает модификации цены за замену материалов
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IEnumerable<IReplacement> GetMaterials(ICalculationRequest request)
        {
            int calculationType = GetCalculationType(request);
            List<IReplacement> result = new List<IReplacement>();
            request.AppliedPricePeriod?.PriceValues
             .Where(priceValue =>
                 request.UsedMaterialNoms.Any(materialNom =>
                     priceValue.MaterialNom.Id == materialNom.Id
                    //&& priceValue.PriceSelectType.PriceType.CalculationType == calculationType
                     //&& priceValue.PriceSelectType.PriceType.NomenclatureCalculationOrder == 0
                     )).ToList()
                         .ForEach(priceValueForMaterialNom =>
                         {
                             //Формируем раздел А. Список основных материалов (замен), 
                             //когда Order == 0 и дополнительных - когда иначе
                             result.Add(
                      new Replacement(
                          priceValueForMaterialNom,
                          -1)); //priceValueForMaterialNom.PriceSelectType.PriceType.NomenclatureCalculationOrder));
                         });

            request.UsedMaterialNoms
                .Where(materialNom =>
                    request.AppliedPricePeriod.PriceValues.All(priceValue =>
                        priceValue.MaterialNom.Id != materialNom.Id)).ToList()
                            .ForEach(unpricedMaterialNom =>
                            {
                                //Формируем раздел I. Список использованных материалов (замен) без цен
                                result.Add(new Replacement(unpricedMaterialNom, true));
                            });
            return result;
        }

        /// <summary>
        /// Возвращает модификации цены за площадь
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static List<IPriceModificator> GetSizePriceModificators(ICalculationRequest request)
        {
            List<IPriceModificator> result = new List<IPriceModificator>();
            int calculationType = GetCalculationType(request);
            if (calculationType == 1)
            {
                foreach (PriceSquRatio ratio in
                    request.AppliedPrice.PriceSquRatios
                        .OrderBy(ratio => ratio.Squ).ToList())
                {
                    if (ratio.Squ > request.QuantityPerItem)
                    {
                        result.Add(
                            new PriceModificator(
                                $"Наценка за площадь <={ratio.Squ:f2} квм",
                                ratio.Ratio,
                                PriceModificatorTypes.Multiplicator,
                                PriceApplianceTypes.PerMeasurementUnit,
                                ratio
                                ));
                        break;
                    }
                };
            }
            else if (calculationType < 2)
                throw new WrontProductionTypeException(request);

            return result;
        }

        /// <summary>
        /// Возвращает модификации цены за сложности
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static List<IPriceModificator> GetSlozPriceModificators(ICalculationRequest request)
        {
            List<IPriceModificator> result = new List<IPriceModificator>();

            request.AppliedPrice.PriceSlozs.Where(priceSloz =>
                request.AppliedSlozs.Any(appliedSloz =>
                    appliedSloz.SlozType.Id == priceSloz.SlozType.Id)).ToList()
                        .ForEach(pricedAppliedSloz =>
                        {
                            if (pricedAppliedSloz.AddValueToMeasurementItem != 0)
                            {
                                //Формируем раздел B2. Список модификаторов к (+цена) цене за ед.измерения
                                result.Add(
                                new PriceModificator(
                                    $"Наценка за: \"{pricedAppliedSloz.SlozType}\"",
                                    pricedAppliedSloz.AddValueToMeasurementItem,
                                    PriceModificatorTypes.AdditionalValue,
                                    PriceApplianceTypes.PerMeasurementUnit,
                                    pricedAppliedSloz
                                    ));
                            }

                            if (pricedAppliedSloz.MultiplyValueToEntireItem != 0)
                            {
                                //Формируем раздел С1. Список модификаторов (* коэффициент) к цене за единицу
                                result.Add(
                                new PriceModificator(
                                    $"Наценка за: \"{pricedAppliedSloz.SlozType}\"",
                                    pricedAppliedSloz.MultiplyValueToEntireItem,
                                    PriceModificatorTypes.Multiplicator,
                                    PriceApplianceTypes.PerItem,
                                    pricedAppliedSloz
                                    ));
                            }

                            if (pricedAppliedSloz.AddValueToEntireItem != 0)
                            {
                                //Формируем раздел С2. Список наценок (+ цена) к цене за единицу
                                result.Add(
                                new PriceModificator(
                                    $"Наценка за: \"{pricedAppliedSloz.SlozType}\"",
                                    pricedAppliedSloz.AddValueToEntireItem,
                                    PriceModificatorTypes.AdditionalValue,
                                    PriceApplianceTypes.PerItem,
                                    pricedAppliedSloz
                                    ));
                            }
                        });
            return result;
        }

        /// <summary>
        /// Возвращает модификации цены за сложности у которых не установлены цены
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static List<IPriceModificator> GetUnpricedSlozPriceModificators(ICalculationRequest request)
        {
            List<IPriceModificator> result = new List<IPriceModificator>();
            request.AppliedSlozs.Where(appliedSloz =>
                request.AppliedPrice.PriceSlozs.All(priceSloz =>
                    appliedSloz.SlozType.Id != priceSloz.SlozType.Id)).ToList()
                       .ForEach(unpricedAppliedSloz =>
                       {
                           result.Add(
                               new PriceModificator(
                                   $"Наценка за: \"{unpricedAppliedSloz.SlozType}\"",
                                   0,
                                   PriceModificatorTypes.Unknown,
                                   PriceApplianceTypes.Unknown,
                                   unpricedAppliedSloz
                                   ));
                       });
            return result;
        }

        /// <summary>
        /// Возвращает модификации цены за операции обработки
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static List<IPriceModificator> GetProcessingPriceModificators(ICalculationRequest request)
        {
            List<IPriceModificator> result = new List<IPriceModificator>();
            request.AppliedPricePeriod.PricePeriodProcessingNoms
                .Where(pricePeriodProcessingNoms =>
                    request.AppliedProcessings.Any(processingNom =>
                        processingNom.ProcessingNom.Processing.Id == pricePeriodProcessingNoms.ProcessingNom.Processing.Id)).ToList()
                            .ForEach(pricedPricePeriodProcessingNom =>
                            {
                                if (pricedPricePeriodProcessingNom.AdditionalPriceValue != 0)
                                    result.Add(new PriceModificator(
                                    $"Наценка за: \"{pricedPricePeriodProcessingNom.ProcessingNom}\"",
                                    pricedPricePeriodProcessingNom.AdditionalPriceValue,
                                    PriceModificatorTypes.AdditionalValue,
                                    PriceApplianceTypes.PerItem,
                                    pricedPricePeriodProcessingNom));

                                if (pricedPricePeriodProcessingNom.MultiplyPriceFactor != 0)
                                    result.Add(new PriceModificator(
                                        $"Наценка за: \"{pricedPricePeriodProcessingNom.ProcessingNom}\"",
                                        pricedPricePeriodProcessingNom.MultiplyPriceFactor,
                                        PriceModificatorTypes.Multiplicator,
                                        PriceApplianceTypes.PerItem,
                                        pricedPricePeriodProcessingNom));
                            });
            return result;
        }

        /// <summary>
        /// Возвращает модификации цены за операции обработки c неустановленными ценами
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static List<IPriceModificator> GetUnpricedProcessingPriceModificators(ICalculationRequest request)
        {
            List<IPriceModificator> result = new List<IPriceModificator>();

            request.AppliedProcessings.Where(processingNom =>
               request.AppliedPricePeriod.PricePeriodProcessingNoms.All(pricePeriodProcessingNom =>
                   pricePeriodProcessingNom.ProcessingNom.Processing.Id != processingNom.ProcessingNom.Processing.Id)).ToList()
                       .ForEach(unpricedProcessingNom =>
                       {
                           result.Add(new PriceModificator(
                                       $"Наценка за: \"{unpricedProcessingNom}\"",
                                       0,
                                       PriceModificatorTypes.Unknown,
                                       PriceApplianceTypes.Unknown,
                                       unpricedProcessingNom));
                       });

            return result;
        }

        /// <summary>
        /// Возвращает список компонентов для примененных операций обработки
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IEnumerable<IReplacement> GetProcessingComponents(ICalculationRequest request)
        {
            List<IReplacement> result = new List<IReplacement>();
            request.AppliedPricePeriod.PriceValues.Where(priceValue =>
                    request.UsedComponents.Any(processingComponent =>
                        priceValue.MaterialNom.Id == processingComponent.MaterialNom.Id)).ToList()
                            .ForEach(priceValueForMaterialNom =>
                            {
                            result.Add(
                                new Replacement(
                                    priceValueForMaterialNom,
                                    -1)); // priceValueForMaterialNom.PriceSelectType.PriceType.NomenclatureCalculationOrder));
                            });
            return result;
        }

        /// <summary>
        /// Возвращает список дополнительных материалов
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IEnumerable<IReplacement> GetAdditionalMaterials(ICalculationRequest request)
        {
            List<IReplacement> result = new List<IReplacement>();

            request.AppliedPricePeriod.PriceValues.Where(priceValue =>
                   request.AdditionalMaterialNoms.Any(additionalMaterialNoms =>
                       priceValue.MaterialNom.Id == additionalMaterialNoms.MaterialNom.Id)).ToList()
                           .ForEach(priceValueForMaterialNom =>
                           {
                               result.Add(null
                                   //new Replacement(
                                   //    priceValueForMaterialNom,
                                   //    priceValueForMaterialNom.PriceSelectType.PriceType.NomenclatureCalculationOrder,
                                   //    request.AdditionalMaterialNoms.FirstOrDefault(x => x.MaterialNom.Id == priceValueForMaterialNom.MaterialNom.Id)?.Quantity ?? 0)
                                   );
                           });
            return result;
        }

        /// <summary>
        /// Возвращает список компонентов для примененных операций обработки, не имеющих установленной прайсом цены
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IEnumerable<IReplacement> GetUnpricedProcessingComponents(ICalculationRequest request)
        {
            List<IReplacement> result = new List<IReplacement>();
            request.AdditionalMaterialNoms
              .Where(additionalMaterialNoms =>
                  request.AppliedPricePeriod.PriceValues.All(priceValue =>
                      priceValue.MaterialNom.Id != additionalMaterialNoms.MaterialNom.Id)).ToList()
                          .ForEach(unpricedAdditionalMaterialNoms =>
                               result.Add(new Replacement(unpricedAdditionalMaterialNoms.MaterialNom, true)));
            return result;
        }

        /// <summary>
        /// Возвращает список дополнительных материалов, не имеющих установленной прайсом цены
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IEnumerable<IReplacement> GetUnpricedAdditionalMaterials(ICalculationRequest request)
        {
            List<IReplacement> result = new List<IReplacement>();
            request.UsedComponents
                         .Where(usedComponents =>
                             request.AppliedPricePeriod.PriceValues.All(priceValue =>
                                 priceValue.MaterialNom.Id != usedComponents.MaterialNom.Id)).ToList()
                                     .ForEach(unpricedProcessingComponent =>
                                         result.Add(new Replacement(unpricedProcessingComponent.MaterialNom, true)));
            return result;
        }

        /// <summary>
        /// Актуальный период для текущей даты или null, если не установлен
        /// </summary>
        /// <param name="price">Прайс-лист, для которого определяется актуальный на дату период</param>
        /// <param name="dateTime">Дата определения. Если пустая, то берется текущая</param>
        /// <returns>Период прайс-листа или nullб если его нет</returns>
        public static IPricePeriod GetActualPricePeriod(IPrice price, DateTime? date = null)
        {
            if (date == null)
                date = DateTime.Today.Date;

            if (price.IPricePeriods
                    .Where(period => period.DateBegin <= date)
                    .OrderBy(period => date - period.DateBegin).FirstOrDefault()
                        is IPricePeriod pricePeriod)
                return pricePeriod;
            return null;
        }

    }
}