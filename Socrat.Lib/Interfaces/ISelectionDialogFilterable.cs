using System;
using System.Linq.Expressions;
using Socrat.Core;

namespace Socrat.Lib.Interfaces
{
    /// <summary>
    /// Интерфейс диалога выбора с выражением фильтрации
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISelectionDialogFilterable<T>: ISelectionDialog where T : class, IEntity, new()
    {
        Expression<Func<T, bool>> ExternalFilterExp { get; set; }
    }
}