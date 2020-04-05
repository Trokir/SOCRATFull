namespace Socrat.Lib.Module
{
    public interface IModule
    {
        /// <summary>
        /// Имя модуля
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Соединение модуля
        /// </summary>
        SqlHelper SqlHelper { get; set; } 
        /// <summary>
        /// Главнаяю форма модуля
        /// </summary>
        Socrat.Core.ITabable Form { get;}
    }
}
