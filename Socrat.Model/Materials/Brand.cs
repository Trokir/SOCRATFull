using System;
using System.Collections.ObjectModel;
using Socrat.Lib;

namespace Socrat.Model
{
    public class Brand: Entity
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

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name); }
        }

        [ParentItem]
        private Vendor _Vendor;
        public Vendor Vendor
        {
            get { return _Vendor; }
            set { SetField(ref _Vendor, value, () => Vendor); }
        }

        public Nullable<Guid> Vendor_Id
        {
            get { return Vendor?.Id; }
        }

        private Material _material;
        public Material Material
        {
            get { return _material; }
            set { SetField(ref _material, value, () => Material); }
        }

        public Nullable<Guid> Material_Id
        {
            get { return Material?.Id; }
        }

        protected override string GetTitle()
        {
            return "Бренд: " + Vendor.Name;
        }

        public override string ToString()
        {
            return Name;
        }

        public ObservableCollection<Model.TradeMark> TradeMarks { get; set; }   
    }
}