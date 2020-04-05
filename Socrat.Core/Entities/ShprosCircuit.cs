using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Core.Entities
{
    public class ShprosCircuit : Entity
    {
        private string _Name;
        private Nullable<double> _Length;
        private Nullable<double> _Square;
        public ShprosCircuit()
        {
            ShprosElements = new ObservableCollection<ShprosElement>();
        }
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name); }
        }
        public Nullable<double> Length
        {
            get { return _Length; }
            set { SetField(ref _Length, value, () => Length); }
        }
        public Nullable<double> Square
        {
            get { return _Square; }
            set { SetField(ref _Square, value, () => Square); }
        }


        private Guid? _ShapeId;
        public Guid? ShapeId
        {
            get { return _ShapeId; }
            set { SetField(ref _ShapeId, value, () => ShapeId); }
        } 

        public virtual Shape Shape { get; set; }

            public virtual ObservableCollection<ShprosElement> ShprosElements { get; set; }
            = new ObservableCollection<ShprosElement>();

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
