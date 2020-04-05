using Socrat.Core.Entities;

namespace Socrat.Services.Price
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReplacement
    {
        /// <summary>
        /// Cтоимость замены номенклатуры
        /// </summary>
        PriceValue PriceValue { get; set; }
        /// <summary>
        /// Заменяемая номенклатура
        /// </summary>
        MaterialNom MaterialNom { get; set; }
        /// <summary>
        /// Порядок подстановок замены (0 - в начале, остальное - в конце)
        /// </summary>
        int Order { get; }
        /// <summary>
        /// Цена замены
        /// </summary>
        double Price { get; }
        /// <summary>
        /// Заменяемое кол-во
        /// </summary>
        double Quantity { get; }
        }
}
