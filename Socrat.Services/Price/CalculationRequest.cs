using Socrat.Common.Enums;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Socrat.Services.Price
{
    public class CalculationRequest : ICalculationRequest
    {
        public CalculationRequest(OrderRow orderRow, PricePeriod appliedPricePeriod)
        {
            OrderRow = orderRow;
            AppliedPricePeriod = appliedPricePeriod;
        }

        #region Имплементация Providers.Price.ICalculationRequest
        /// <summary>
        /// Строка заказа
        /// </summary>
        public OrderRow OrderRow { get; private set; }
        public List<ProcessingComponent> UsedComponents { get => OrderRow.Components; }
        /// <summary>
        /// Тип изделия
        /// </summary>
        public ProductionTypes ItemType { get => OrderRow.ProductionType; }
        /// <summary>
        /// Цена за единицу изделия для Providers.Price.ICalculationRequest
        /// </summary>
        public double QuantityPerItem => (OrderRow.Square / OrderRow.Qty ?? 1);
        /// <summary>
        /// Количество изделий в строке заказа для Providers.Price.ICalculationRequest
        /// </summary>
        public double Quantity => OrderRow.Qty ?? 0;
        /// <summary>
        /// Применяемый прайс-лист для Providers.Price.ICalculationRequest
        /// </summary>
        public Core.Entities.Price AppliedPrice
        {
            get
            {
                if (OrderRow.Order?.Contract?.Price is Core.Entities.Price appliedPrice)
                    return appliedPrice;
                else return null;
                //throw new Exception($"Цена элемента заказа не может быть расчитана - " +
                //    $"нет сопоставленного c этим заказом и его контрактом прайс-листа ");
            }
        }
        /// <summary>
        /// Применяемый дата расчета для Providers.Price.ICalculationRequest
        /// </summary>
        public DateTime AppliedDate { get; set; } = DateTime.Today;
        /// <summary>
        /// Применяемый период прайс-листа для Providers.Price.ICalculationRequest
        /// </summary>
        public PricePeriod AppliedPricePeriod { get; private set; }
        /// <summary>
        /// Перечень использованных материалов
        /// </summary>
        public List<MaterialNom> UsedMaterialNoms { get => OrderRow.MaterialNoms; }
        /// <summary>
        /// Примененная фигура для Providers.Price.ICalculationRequest
        /// </summary>
        public Shape AppliedShape { get => OrderRow.Shape; }
        /// <summary>
        /// Перечень использованных сложностей  для Providers.Price.ICalculationRequest
        /// </summary>
        public List<OrderRowSloz> AppliedSlozs { get => OrderRow.OrderRowSlozs.ToList(); }
        /// <summary>
        /// Перечень примененных операций  для Providers.Price.ICalculationRequest
        /// </summary>
        public List<FormulaItemProcessing> AppliedProcessings { get => OrderRow.FormulaItemProcessings; }
        /// <summary>
        /// Дополнительные материалы
        /// </summary>
        public List<MaterialNomWithQuantity> AdditionalMaterialNoms
        {
            get
            {
                List<MaterialNomWithQuantity> res = new List<MaterialNomWithQuantity>();
                OrderRow.Formula.GetAllItems()
                    ?.ForEach(formulaItem =>
                    {
                        if (formulaItem.MaterialNom != null)
                        {
                            if (formulaItem is FrameItem frame)
                            {
                                if (frame.FrameItemProperty?.ShprosNom is MaterialNom materialNomA)
                                    res.Add(new MaterialNomWithQuantity(materialNomA, (OrderRow.Shape?.GrossElementsLength ?? 0) / 1000));
                                if (frame.FrameItemProperty?.ShprosFixator is MaterialNom materialNomB)
                                    res.Add(new MaterialNomWithQuantity(materialNomB, OrderRow.Shape.EndsRetainer ?? 0));
                                if (frame.FrameItemProperty?.ShprosXConnector is MaterialNom materialNomC)
                                    res.Add(new MaterialNomWithQuantity(materialNomC, OrderRow.Shape.CrossRetainer ?? 0));
                                //if (frame.FrameItemProperty?.ShprosTConnector is MaterialNom materialNomD)
                                //    res.Add(new MaterialNomWithQuantity(materialNomD, Shape.EndsRetainer ?? 0));
                                //if (frame.FrameItemProperty?.ShprosYConnector is MaterialNom materialNomE)
                                //    res.Add(new MaterialNomWithQuantity(materialNomE, Shape.EndsRetainer ?? 0));
                            }

                        }
                    });
                return res;
            }
        }

       

        public CalculationResult CalculationResult { get; set; }

        #endregion
    }
}
