using System;
using Socrat.Common.Enums;

namespace Socrat.Data.Model
{
    public class MaterialNomDefault : Entity
    {
        public Guid MaterialNomId { get; set; }


        public virtual MaterialNom MaterialNom { get; set; }


        public MaterialEnum MaterialEnum { get; set; }
    }
}