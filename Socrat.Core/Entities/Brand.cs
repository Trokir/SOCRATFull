using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Socrat.Core.Entities
{
    public class Brand : Entity
    {
        public Brand()
        {
            TradeMarks = new ObservableCollection<TradeMark>();
            TradeMarks.CollectionChanged += CollectionChanged;
        }

        private void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Changed = true;
        }

        public Guid? VendorId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }
        public Guid? MaterialId { get; set; }

        private Material _material;
        public virtual Material Material
        {
            get { return _material; }
            set { SetField(ref _material, value, () => Material); }
        }

        [ParentItem]
        private Vendor _vendor;
        public virtual Vendor Vendor
        {
            get => _vendor; 
            set { SetField(ref _vendor, value, () => Vendor); }
        }

        protected override string GetTitle()
        {
            return "Απενδ: " + Vendor.Name;
        }

        public override string ToString()
        {
            return Name;
        }
        public virtual ObservableCollection<TradeMark> TradeMarks { get; set; }
        public virtual ICollection<VendorMaterialNom> VendorMaterialNoms { get; set; } = new HashSet<VendorMaterialNom>();

        public bool MaterialVendorMaching(Material material, Vendor vendor)
        {
            bool res = false;
            res = (material != null) && (material.Id == MaterialId);
            res = res && (vendor != null) && (vendor.Id == VendorId);
            return res;
        }
    }
}
