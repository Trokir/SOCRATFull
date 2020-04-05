using System;

namespace Socrat.Data.Model
{
    public class ShprossElement : Entity
    {
        public Guid? ShprosId { get; set; }
        public Guid? ChildShprosId { get; set; }
        public Guid? ShprosMainElementId { get; set; }
        public double? RelativeMargin { get; set; }
        public bool? IsRelativeMargin { get; set; }
        public bool IsCenter { get; set; }
        public int? SelectorFlag { get; set; }
        public string SideDirectionForAxisPack { get; set; }
        public double? Margin { get; set; }
        public string SideVector { get; set; }
        public string TypeElement { get; set; }
        public double? LeftMargin { get; set; }
        public double? RightMargin { get; set; }
        public int? Count { get; set; }
        public string Name { get; set; }
        public string OrientationType { get; set; }
        public string Location { get; set; }
        public double? ChordHeight { get; set; }
        public Guid? ShapeId { get; set; }
        public virtual Shape Shape { get; set; }
    }
}