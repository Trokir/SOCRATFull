using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socrat.Core.Entities
{
    public class ShprossElement : Entity
    {
        private string _Name;
        private string _Location;
        private string _OrientationType;
        private string _TypeElement;
        private double? _LeftMargin;
        private double? _RightMargin;
        private int? _Count;
        private int? _SelectorFlag;
        private string _SideDirectionForAxisPack;
        private double? _Margin;
        private double? _ChordHeight;
        private string _SideVector;
        private bool _IsCenter;
        //private bool _IsSelectedColor;
        private Guid? _ShapeId;
        //private List<string> _ComboItems;
        //private bool _Flag;
        private bool? _IsRelativeMargin;
        private Guid? _ShprosId;
        private Guid? _ChildShprosId;
        private Guid? _ShprosMainElementId;
        private double? _RelativeMargin;
        public ShprossElement()
        {

        }
        public ShprossElement GetNewShprossElement()
        {

            var elem = new ShprossElement
            {
                Name = "",
                Location = "",
                OrientationType = "",
                TypeElement = "",
                LeftMargin = 0.0,
                RightMargin = 0.0,
                Count = 0,
                SelectorFlag = 1,
                SideDirectionForAxisPack = "",
                Margin = 0.0,
                ChordHeight = 0.0,
                SideVector = "",
                IsCenter = false,
                IsRelativeMargin = false,
                ShprosId = null,
                ChildShprosId = null,
                ShprosMainElementId = null,
                Shape = this.Shape

            };
            return elem;
        }
        //public ShprossElement GetNewShprossElement()
        //{

        //    var elem = new ShprossElement
        //    {
        //        Name = this.Name,
        //        Location = this.Location,
        //        OrientationType = this.OrientationType,
        //        TypeElement = this.TypeElement,
        //        LeftMargin = this.LeftMargin,
        //        RightMargin = this.RightMargin,
        //        Count = this.Count,
        //        SelectorFlag = this.SelectorFlag,
        //        SideDirectionForAxisPack = this.SideDirectionForAxisPack,
        //        Margin = this.Margin,
        //        ChordHeight = this.ChordHeight,
        //        SideVector = this.SideVector,
        //        IsCenter = this.IsCenter,
        //        IsRelativeMargin = this.IsRelativeMargin,
        //        ShprosId = this.ShprosId,
        //        ChildShprosId = this.ChildShprosId,
        //        ShprosMainElementId = this.ShprosMainElementId,
        //        Shape = this.Shape

        //    };
        //    return elem;
        //}



        public Guid? ShprosId
        {
            get { return _ShprosId; }
            set { SetField(ref _ShprosId, value, () => ShprosId); }
        }

       
        public Guid? ChildShprosId
        {
            get { return _ChildShprosId; }
            set { SetField(ref _ChildShprosId, value, () => ChildShprosId); }
        }


      
        public Guid? ShprosMainElementId
        {
            get { return _ShprosMainElementId; }
            set { SetField(ref _ShprosMainElementId, value, () => ShprosMainElementId); }
        }

      
        public double? RelativeMargin
        {
            get { return _RelativeMargin; }
            set { SetField(ref _RelativeMargin, value, () => RelativeMargin); }
        }


        public bool? IsRelativeMargin
        {
            get { return _IsRelativeMargin ?? false; }
            set { SetField(ref _IsRelativeMargin, value, () => IsRelativeMargin); }
        }

        [NotMapped]
        public bool Flag { get; set; }

        public bool IsCenter
        {
            get { return _IsCenter; }
            set { SetField(ref _IsCenter, value, () => IsCenter); }
        }

        [NotMapped]
        public bool IsSelectedColor { get; set; }

        public int? SelectorFlag
        {
            get { return _SelectorFlag; }
            set { SetField(ref _SelectorFlag, value, () => SelectorFlag); }
        }
        public string SideDirectionForAxisPack
        {
            get { return _SideDirectionForAxisPack; }
            set { SetField(ref _SideDirectionForAxisPack, value, () => SideDirectionForAxisPack); }
        }
        public double? Margin
        {
            get { return _Margin; }
            set { SetField(ref _Margin, value, () => Margin); }
        }
        public string SideVector
        {
            get { return _SideVector; }
            set { SetField(ref _SideVector, value, () => SideVector); }
        }
        public string TypeElement
        {
            get { return _TypeElement; }
            set { SetField(ref _TypeElement, value, () => TypeElement); }
        }
        public double? LeftMargin
        {
            get { return _LeftMargin; }
            set { SetField(ref _LeftMargin, value, () => LeftMargin); }
        }
        public double? RightMargin
        {
            get { return _RightMargin; }
            set { SetField(ref _RightMargin, value, () => RightMargin); }
        }
        public int? Count
        {
            get { return _Count; }
            set { SetField(ref _Count, value, () => Count); }
        }
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name); }
        }
        public string OrientationType
        {
            get { return _OrientationType; }
            set { SetField(ref _OrientationType, value, () => OrientationType); }
        }
        public string Location
        {
            get { return _Location; }
            set { SetField(ref _Location, value, () => Location); }
        }
        public double? ChordHeight
        {
            get { return _ChordHeight; }
            set { SetField(ref _ChordHeight, value, () => ChordHeight); }
        }

        public Guid? ShapeId { get; set; } // навигационные свойства и ключи - SetField - не вызывать!
                                           //{
                                           //    get { return _ShapeId; }
                                           //    set { SetField(ref _ShapeId, value, () => ShapeId); }
                                           //}



        [ParentItem]
        public virtual Shape Shape { get; set; }
        protected override string GetTitle()
        {
            return $"Элементы шпроса";
        }
        public override string ToString()
        {
            return $"{Name} {OrientationType} {Location}";
        }
    }
}
