using System;
using Socrat.Common.Enums;

namespace Socrat.Data.Model
{
    /// <summary>
    ///     информация по браку изделия
    /// </summary>
    public class Defect : Entity
    {
        public virtual OrderRowItem OrderRowItem { get; set; }
        public Guid OrderRowItemId { get; set; }
        public DefectType DefectType { get; set; }
        public DefectReason DefectReason { get; set; }
        public string Comment { get; set; }
        public string Code1с { get; set; }
    }
}