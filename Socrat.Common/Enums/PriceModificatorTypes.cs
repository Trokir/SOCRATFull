namespace Socrat.Common.Enums
{
    /// <summary>
    /// Способы модификайции цены
    /// </summary>
    public enum PriceModificatorTypes
    {
        /// <summary>
        /// Модификация путем прибавления значения к цене
        /// </summary>
        AdditionalValue = 0,
        /// <summary>
        /// Модификация путем прибавления умножения цены на коэффициент
        /// </summary>
        Multiplicator = 1,
        /// <summary>
        /// Не установлен
        /// </summary>
        Unknown = 2

    }
}
