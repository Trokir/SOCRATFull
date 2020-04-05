using System;

namespace Socrat.Data.Model
{
    public class AppParamValue : Entity
    {
        public Guid AppParamsId { get; set; }

        public Guid DivisionId { get; set; }


        public string Value { get; set; }


        public virtual AppParam AppParam { get; set; }


        public virtual Division Division { get; set; }
    }
}