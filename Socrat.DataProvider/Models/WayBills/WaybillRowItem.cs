using System;

namespace Socrat.Data.Model
{
    public class WaybillRowItem : Entity
    {
        public virtual OrderRowItem OrderRowItem { get; set; }
        public WaybillRow WaybillRow { get; set; }
        public Guid OrderRowItemId { get; set; }
        public Guid WaybillRowId { get; set; }
    }
}