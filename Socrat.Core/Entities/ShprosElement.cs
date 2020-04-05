using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socrat.Core.Entities
{
    public class ShprosElement : Entity
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
        private bool _IsSelectedColor;
        private Guid? _ShprosCircuitId;
        private Guid? _ShapeId;
        private List<string> _ComboItems;
        private bool _Flag;
        private bool? _IsRelativeMargin;

        public ShprosElement()
        {
            ComboItems = new List<string>();
        }

        private Guid? _ShprosId;
        public Guid? ShprosId
        {
            get { return _ShprosId; }
            set { SetField(ref _ShprosId, value, () => ShprosId); }
        }

        private Guid? _ChildShprosId;
        public Guid? ChildShprosId
        {
            get { return _ChildShprosId; }
            set { SetField(ref _ChildShprosId, value, () => ChildShprosId); }
        } 


        private double? _RelativeMargin;
        public double? RelativeMargin
        {
            get { return _RelativeMargin; }
            set { SetField(ref _RelativeMargin, value, () => RelativeMargin); }
        } 


        public bool? IsRelativeMargin
        {
            get { return _IsRelativeMargin??false; }
            set { SetField(ref _IsRelativeMargin, value, () => IsRelativeMargin); }
        }

        public bool Flag
        {
            get { return _Flag; }
            set { SetField(ref _Flag, value, () => Flag); }
        }
        public bool IsCenter
        {
            get { return _IsCenter; }
            set { SetField(ref _IsCenter, value, () => IsCenter); }
        }
        public bool IsSelectedColor
        {
            get { return _IsSelectedColor; }
            set { SetField(ref _IsSelectedColor, value, () => IsSelectedColor); }
        }
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



        public Guid? ShprosCircuitId
        {
            get { return _ShprosCircuitId; }
            set { SetField(ref _ShprosCircuitId, value, () => ShprosCircuitId); }
        }
        public Guid? ShapeId
        {
            get { return _ShapeId; }
            set { SetField(ref _ShapeId, value, () => ShapeId); }
        }
        public List<string> ComboItems
        {
            get { return _ComboItems; }
            set { SetField(ref _ComboItems, value, () => ComboItems); }
        }
        public virtual ShprosCircuit ShprosCircuit { get; set; }
        public virtual Shape Shape { get; set; }
        protected override string GetTitle()
        {
            return $"Элементы шпроса";
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
