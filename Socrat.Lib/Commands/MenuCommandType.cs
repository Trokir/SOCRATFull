namespace Socrat.Lib.Commands
{
    public enum MenuCommandType
    {
        /// <summary>
        /// Добавляется в ряд кнопок, меню действие и контекстное меню
        /// </summary>
        Item,
        /// <summary>
        /// Группа кнопок
        /// </summary>
        Group,
        /// <summary>
        /// Разделитель
        /// </summary>
        Seporator,
        /// <summary>
        /// Только контексное меню
        /// </summary>
        ComtextMenuItem,
        /// <summary>
        /// Группа контексного меню
        /// </summary>
        ContextMenuGroup,
        /// <summary>
        /// Только кнопки и Действия
        /// </summary>
        ButtonsOnly
    }
}