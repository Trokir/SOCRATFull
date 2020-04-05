using System.Collections.Generic;

namespace Socrat.Common.Interfaces.Planning
{
    /// <summary>
    /// План нарезки -> МАТЕРИАЛ СТЕКЛА -> стекла одного размера -> экземпляры стекол
    /// </summary>
    public interface IGlassCuttingsPlanGlass
    {
        /// <summary>
        /// Проброс заголовка с уровня отчета для репита на каждой странице
        /// </summary>
        IPlanningActivityHeader Header { get; }
        /// <summary>
        /// Интерфейс номенклатуры
        /// </summary>
        IMaterialNom MaterialNom { get; }
        /// <summary>
        /// Название стекла
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Коллекция элементов 
        /// </summary>
        List<IGlassCuttingsPlanGlassRow> Sizes { get; }
    }
}
