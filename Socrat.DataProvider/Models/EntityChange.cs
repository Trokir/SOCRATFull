using System;

namespace Socrat.Data.Model
{
    public class EntityChange : Entity
    {
        public Guid Guid { get; set; }

        /// <summary>
        ///     Тик (класс)
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        ///     Строковое представление
        /// </summary>
        public string TextPresentation { get; set; }

        /// <summary>
        ///     Автор изменений
        /// </summary>
        public string Editor { get; set; }

        /// <summary>
        ///     Дата изменений
        /// </summary>
        public DateTime Dated { get; set; }

        /// <summary>
        ///     Тип изменений
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Как-бы XML-cериализованное представление
        /// </summary>
        public string Serialized { get; set; }
    }
}