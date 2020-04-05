using Socrat.Common.Interfaces.MVC;
using System;
using System.Collections.Generic;

namespace Socrat.Common.Interfaces
{
    /// <summary>
    /// Контракт контрола, поддерживающего печать
    /// </summary>
    public interface IPrintable
    {
        /// <summary>
        /// Нечто может быть напечатано на шаблоне по умолчанию?
        /// </summary>
        /// <returns></returns>
        bool CanPrintByDefault(object data);

        /// <summary>
        /// Нечто может быть напечатано?
        /// </summary>
        /// <returns></returns>
        bool CanPrint(object data);

        /// <summary>
        /// Контроллер печати имплементирующего печать контрола
        /// </summary>
        IController PrintController { get; }

        /// <summary>
        /// Печать. Подразумевает вызов диалога выбора шаблонов при их наличии больше одного
        /// </summary>
        void Print(object data);

        /// <summary>
        /// Печать на шаблоне по умолчанию. Если таковой найдется
        /// </summary>
        void PrintByDefault(object data);

        /// <summary>
        /// Генерирует кнопки печати ("Печать" - на шаблоне по умолчанию и "Печать..." - с выбором шаблона, если их несколько
        /// Или переопределяет их
        /// </summary>
        List<object> CreatePrintCommands();

        /// <summary>
        /// Заглушка для имплементации метода, который подсовывает данные при вызове печати
        /// То есть, условно, в гриде этот метод может пихнуть сюда выбраный элемент грида
        /// </summary>
        /// <returns></returns>
        List<object> GetPrintableData();

        /// <summary>
        /// Инициализирует контроллер печати для специфического типа
        /// </summary>
        /// <returns></returns>
        void CreatePrintController(Type requestorType, Type controllerType, IView parentView);
    }
}
