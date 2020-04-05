using System;

namespace Socrat.Lib
{
    /// <summary>
    /// Атрибут для маркировки поля - ссылки на родителя.
    /// Для размыкания рекурсий при рекурсивном обновлении признака Changed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class ParentItemAttribute: Attribute
    {
    }
}