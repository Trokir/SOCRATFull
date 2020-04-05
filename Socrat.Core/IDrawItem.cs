namespace Socrat.Core
{
    /// <summary>
    /// Отображемый элемент
    /// </summary>
    public interface IDrawableItem
    {
        /// <summary>
        /// Толшина для отображения
        /// </summary>
        double DrawThickness { get; }
    }

    /// <summary>
    /// Элеент имеющий толщину
    /// </summary>
    public interface IThickableItem
    {
        /// <summary>
        /// Толщина
        /// </summary>
        double Thickness { get; }
    }

    /// <summary>
    /// Элеент который может содержать зуб
    /// </summary>
    public interface IDentableItem
    {
        /// <summary>
        /// Зуб оперделен
        /// </summary>
        bool DentExists { get; }
    }

    public interface IGermContainer
    {
        double? GermDepth { get; set; }
    }
}