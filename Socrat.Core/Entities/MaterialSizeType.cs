using System;
using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class MaterialSizeType : Entity
    {
        public Guid? MaterialMarkTypeId { get; set; }

        private double _thickness;
        public double Thickness
        {
            get { return _thickness; }
            set { SetField(ref _thickness, value, () => Thickness); }
        }

        public Guid? MeasureId { get; set; }
        public Guid? DefaultMaterialNomId { get; set; }
        private MaterialNom _DefaultMaterialNom;
        public virtual MaterialNom DefaultMaterialNom
        {
            get { return _DefaultMaterialNom; }
            set { SetField(ref _DefaultMaterialNom, value, () => DefaultMaterialNom); }
        } 
        [ParentItem]
        private MaterialMarkType _materialMarkType;
        public virtual MaterialMarkType MaterialMarkType
        {
            get { return _materialMarkType; }
            set { SetField(ref _materialMarkType, value, () => MaterialMarkType, () => Title); }
        }
        private MaterialNom _materialNom;
        public virtual MaterialNom MaterialNom
        {
            get { return _materialNom; }
            set { SetField(ref _materialNom, value, () => MaterialNom); }
        }

        private Measure _measure;
        public virtual Measure Measure
        {
            get { return _measure; }
            set { SetField(ref _measure, value, () => Measure); }
        }

        private string _Mark;
        public string Mark
        {
            get { return _Mark; }
            set { SetField(ref _Mark, value, () => Mark); }
        } 
        
        public virtual ICollection<MaterialNom> MaterialNoms { get; set; } = new HashSet<MaterialNom>();
        public Material Material
        {
            get { return MaterialMarkType?.Material; }
        }
        public Guid? MaterialId
        {
            get { return Material?.Id; }
        }
        public string Code
        {
            get { return GetCode(); }
        }

        private string GetCode()
        {
            if (MaterialMarkType != null)
            {
                if (MaterialMarkType.Material != null)
                {
                    switch (MaterialMarkType.Material.MaterialEnum)
                    {
                        case MaterialEnum.Film:
                        case MaterialEnum.TriplexFilm:    
                        case MaterialEnum.Triplex:
                            return !string.IsNullOrEmpty(Mark) 
                                ? $"{Mark}{MaterialMarkType?.Code}"
                                : Thickness > 0 
                                    ? $"{Thickness}{MaterialMarkType?.Code}" 
                                    : String.Empty;
                        default:
                            return Thickness > 0 ? $"{Thickness}{MaterialMarkType?.Code}" : String.Empty;
                    }
                }
               
            }
            return string.Empty;
            
        }

        protected override string GetTitle()
        {
            return $"Типоразмер материала: {Code}";
        }

        public override string ToString()
        {
            return Code;
        }
    }
}
