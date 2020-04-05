using System;
using System.Collections.Generic;



namespace Socrat.Core.Entities
{
    public class ShprossMainElement : Entity
    {
        private string _Name;
        private double? _ChordHeight;
        private double? _Radius;
        private double? _CenterOfRadius;
        private Guid? _ShapeId;
        private bool? _IsVertical;
        private bool? _IsHorisontal;
        private bool? _IsAxis;


        public ShprossMainElement()
        {
            ShapePoints  = new AttachedList<ShapePoint>(this);
        }

     
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name); }
        }

       
        public double? ChordHeight
        {
            get { return _ChordHeight; }
            set { SetField(ref _ChordHeight, value, () => ChordHeight); }
        }


       
        public double? CenterOfRadius
        {
            get { return _CenterOfRadius; }
            set { SetField(ref _CenterOfRadius, value, () => CenterOfRadius); }
        } 



        public double? Radius
        {
            get { return _Radius; }
            set { SetField(ref _Radius, value, () => Radius); }
        } 



       

        public Guid? ShapeId
        {
            get { return _ShapeId; }
            set { SetField(ref _ShapeId, value, () => ShapeId); }
        }


      
        public bool? IsVertical
        {
            get { return _IsVertical; }
            set { SetField(ref _IsVertical, value, () => IsVertical); }
        }

      
        public bool? IsHorisontal
        {
            get { return _IsHorisontal; }
            set { SetField(ref _IsHorisontal, value, () => IsHorisontal); }
        }
        
        public bool? IsAxis
        {
            get { return _IsAxis; }
            set { SetField(ref _IsAxis, value, () => IsAxis); }
        }
        [ParentItem]
        public virtual Shape Shape { get; set; }

        public double? ElementLength { get; set; }

        public virtual AttachedList<ShapePoint> ShapePoints { get;  }

        protected override string GetTitle()
        {
            return $"Контур";
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
