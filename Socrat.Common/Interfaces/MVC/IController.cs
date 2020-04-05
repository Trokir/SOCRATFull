namespace Socrat.Common.Interfaces.MVC
{
    /// <summary>
    /// Типа интерфейс базового контроллера.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Рогдительский контроллер: тот, кто породил текущий. 
        /// Может быть и пуст, по крайней мере, пока.
        /// Теоретически, самый первый - это типа экземпляр стартапа
        /// </summary>
        IController Parent { get; }
        /// <summary>
        /// Порождаемая контроллером форма
        /// </summary>
        IView View { get; }
        /// <summary>
        /// Порождаемая контроллером модель отображения
        /// </summary>
        IViewModel ViewModel { get; }

        #region Методы для переопределения

        /// <summary>
        /// Заглушка для переопределения в имплементации
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        IViewModel GetViewModel(object data);

        /// <summary>
        /// Заглушка для переопределения в имплементации
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        IView GetView(object data);

        #endregion
    }
}
