using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Core.Entities;
// ReSharper disable All

namespace Socrat.Core.BL
{
    public class PriceCalculation
    {
        /// <summary>
        /// Строка элемента заказа
        /// </summary>
        public OrderRow OrderedItem { get; }

        /// <summary>
        /// Единственный!!! применимый прайс
        /// </summary>
        public Price AppliedPrice { get; private set; }

        /// <summary>
        /// Период, применяемы для расчета на указанную дату
        /// </summary>
        public PricePeriod AppliedPricePeriod{ get; private set; }

        /// <summary>
        /// Дата, по которой выбирается прайс для вычисления (расчетная дата)
        /// </summary>
        public DateTime AppliedDate { get; private set; }
        
        /// <summary>
        /// Расчитанная цена за единицу измерения
        /// </summary>
        public double PriceForMeasurementUnit { get; private set; } 

        /// <summary>
        /// Коэффициент наценки за сложность КС
        /// </summary>
        public double ComplexityFactor { get; private set; }

        /// <summary>
        /// Коэффициент наценки за геометрию КГ
        /// </summary>
        public double GeometryFactor
        {
            get => QuantityFactor * FormFactor;
        }

        /// <summary>
        /// Коэффициент наценки за количество единиц измерения в изделии
        /// </summary>
        public double QuantityFactor { get; private set; }

        /// <summary>
        /// Коэффициент наценки за фигуру изделии
        /// </summary>
        public double FormFactor { get; private set; }

        /// <summary>
        /// Итоговый коэффициент наценки
        /// </summary>
        public double K { get => ComplexityFactor * GeometryFactor; }

        /// <summary>
        /// Перечень установленных для выбранного периода цен
        /// </summary>
        public List<PriceValue> PriceValues { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="orderedItem"></param>
        public PriceCalculation(OrderRow orderedItem)
        {
            OrderedItem = orderedItem;
        }

        /// <summary>
        /// Расчитывает цену элемента заказа
        /// </summary>
        /// <param name="appliedDate">Дата, для которой производится расчет</param>
        public void Calculate(DateTime appliedDate)
        {
            if (OrderedItem == null)
                throw new ArgumentNullException("Элемент заказа для расчета пуст(null)");

            //Находим применимый прайс через контракт заказа и сохраняем расчетную дату
            AppliedPrice = OrderedItem.Order.Contract.Price;
            AppliedDate = appliedDate;
            AppliedPricePeriod = AppliedPrice.GetPricePeriod(AppliedDate);
            PriceValues = AppliedPricePeriod.PriceValues.ToList();

            //По алгоритму:
            // тут расчитывается стоимость квадратного метра
            //PriceForMeasurementUnit = AppliedPricePeriod.BaseSpo +
            var p = OrderedItem.Formula.FormulaItems
                .Select(formulaItem => formulaItem.MaterialNomId)
                .Intersect(PriceValues.Select(priceValue => priceValue.MaterialNomId));

            //В результате получаем первую искомую величину, стоимость 1 кв.м.изделия,
            //и сохраняем ее в строке заказа(обозначим ее как X). - ничего не сохраняем, только расчитываем результат
            //Далее расчитываем вторую искомую величину, к - т наценки: фигуры и сложности изделия(обозначим его как К)
            //По номеру каталожной фигуры строки смотрим принадлежность фигуры к группе фигур по которым привязаны наценки за фигуру
            //и получаем перый коэффициент(К1/FormFactor).

            //FormFactor = AppliedPrice.PriceForms
            //                     .Where(priceForm => 
            //                         priceForm.FormTypeId == OrderedItem.Shape.FormTypeId)
            //                     .FirstOrDefault()?.Discount ?? 1;

            //По габаритам изделия вычисляем площадь и по результату подбираем диапазон площади из таблицы наценок за площадь,
            //выбирая из нее второй коэффициент(К2/QuantityFactor).
            QuantityFactor = AppliedPrice.PriceSquRatios
                                 .GetAppliedRatio(OrderedItem.Square)?.Ratio ?? 1;

            //Перемножаем К1 и К2, результатом будет коэффициент(КГ) за геометрическую форму изделия.
            //Реализован через член GeometryFactor как вычисляемая проперть



        }
    }
}
