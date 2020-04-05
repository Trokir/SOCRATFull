using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Socrat.Core.Entities
{
    public class Vendor : Entity
    {

        public Vendor()
        {
            _brands = new ObservableCollection<Brand>();
            _vendorMaterialNoms = new ObservableCollection<VendorMaterialNom>();
            _vendorMaterials = new ObservableCollection<VendorMaterial>();
            _tradeMarks = new ObservableCollection<TradeMark>();
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetField(ref _name, value, () => Name, () => Title);
                _name = _name.Trim();
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetField(ref _description, value, () => Description); }
        }

        protected override string GetTitle()
        {
            return "Производитель: " + Name;
        }

        public override string ToString()
        {
            return Name;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Changed = true;
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                VendorMaterial _vendorMaterial = null;
                foreach (var item in e.OldItems)
                {
                    _vendorMaterial = item as VendorMaterial;
                    if (_vendorMaterial != null)
                    {
                        var _brands = Brands.Where(x => x.MaterialId != _vendorMaterial.MaterialId);
                        Brands = new ObservableCollection<Brand>(_brands);
                        var _tms = TradeMarks.Where(x => x.MaterialId != _vendorMaterial.MaterialId);
                        TradeMarks = new ObservableCollection<TradeMark>(_tms);
                        var _noms = VendorMaterialNoms.Where(x => x.MaterialId != _vendorMaterial.MaterialId);
                        VendorMaterialNoms = new ObservableCollection<VendorMaterialNom>(_noms);
                    }
                }
            }
        }


        private ObservableCollection<Brand> _brands;
        public virtual ObservableCollection<Brand> Brands
        {
            get { return _brands; }
            set { SetBrands(value); }
        }

        private void SetBrands(ObservableCollection<Brand> value)
        {
            _brands = value;
            _brands.CollectionChanged -= OnCollectionChanged;
            _brands.CollectionChanged += OnCollectionChanged;
        }

        private ObservableCollection<TradeMark> _tradeMarks;
        public virtual ObservableCollection<TradeMark> TradeMarks
        {
            get => _tradeMarks;
            set
            {
                _tradeMarks = value;
                _tradeMarks.CollectionChanged -= OnCollectionChanged;
                _tradeMarks.CollectionChanged += OnCollectionChanged;
            }
        }


        private ObservableCollection<VendorMaterial> _vendorMaterials;
        public virtual ObservableCollection<VendorMaterial> VendorMaterials
        {
            get => _vendorMaterials;
            set
            {
                _vendorMaterials = value;
                _vendorMaterials.CollectionChanged -= OnCollectionChanged;
                _vendorMaterials.CollectionChanged += OnCollectionChanged;
            }
        }

        private ObservableCollection<VendorMaterialNom> _vendorMaterialNoms;
        public virtual ObservableCollection<VendorMaterialNom> VendorMaterialNoms
        {
            get => _vendorMaterialNoms;
            set
            {
                _vendorMaterialNoms = value;
                _vendorMaterialNoms.CollectionChanged -= OnCollectionChanged;
                _vendorMaterialNoms.CollectionChanged += OnCollectionChanged;
            }
        }

        public bool ContainsMaterial(Material material)
        {
            bool res = false;
            if (material != null)
            {
                var _mats = VendorMaterials.Select(x => x.MaterialId);
                res = _mats.Contains(material.Id);
            }
            return res;
        }
    }
}
