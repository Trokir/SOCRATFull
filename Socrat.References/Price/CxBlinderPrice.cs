using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;
using Socrat.DataProvider;

namespace Socrat.References.Price
{
    public partial class CxBlinderPrice : CxGenericListTable<PriceValue>
    {
        private IPriceService _priceService;
        public PricePeriod PricePeriod { get; set; }
        public PriceType PriceType { get; set; }
        public Core.Entities.Price Price { get; set; }
        public List<PriceValue> PriceValues { get; set; }

        public CxBlinderPrice(Core.Entities.Price price, PricePeriod pricePeriod, PriceType priceType)
        {
            Price = price;
            PricePeriod = pricePeriod;
            PriceType = priceType;
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override ObservableCollection<PriceValue> GetItems()
        {
            IRepository<PriceValue> repos = DataHelper.GetRepository<PriceValue>();

            var v = repos.GetAll().Where(p => p.PricePeriodId == PricePeriod.Id).ToList();
            //  var res = repos.GetAll().First().MaterialNom.MaterialSizeType.MaterialMarkType.Name;

            ObservableCollection<PriceValue> result = new ObservableCollection<PriceValue>(repos.GetAll().Where(p => p.PricePeriodId == PricePeriod.Id && p.PriceTypeId == PriceType.Id).ToList());

            return result;
        }

        protected override void OpenItem()
        {
            Guid? g = GetCurrentRowId();
            PriceValue entity = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());
            //FxPriceElementEdit form = new FxPriceElementEdit();
            FxPriceValueEdit f = new FxPriceValueEdit() { Added = false };
            f.PriceValue = entity;
            //f.Added = false;
            f.Show();
            //form.PriceValue = entity;
            //form.ShowDialog();
        }

        protected override IEntityEditor GetEditor()
        {
            //PriceValue entity = new PriceValue();
            //FxPriceElementEdit form = new FxPriceElementEdit();
            //var f = new FxPriceValueEdit();
            //f.PriceValue = new PriceValue();
            //form.PriceValue = entity;
            //form.ShowDialog();
            //return form;//new FxPriceElementEdit();

            FxPriceValueEdit edit = new FxPriceValueEdit() { Added = true };

            PriceValue priceValue = new PriceValue();

            priceValue.PricePeriod = PricePeriod;
            priceValue.PricePeriodId = PricePeriod.Id;

            priceValue.PriceType = PriceType;
            priceValue.PriceTypeId = PriceType.Id;

            priceValue.MaterialNom = new MaterialNom();

            edit.PriceValue = priceValue;
            //edit.Added = true;
            edit.ShowDialog();
            return edit;
        }

        protected override void InitColumns()
        {
            string priceStr = string.Empty;

            switch (PriceType.Name)
            {
                case "Жалюзи":
                    priceStr = "Цена, р/м2";
                    break;
                case "Пленка":
                    priceStr = "Цена, р/м2";
                    break;
            }
            AddColumn("Наименование", "MaterialNom.MaterialSizeType.MaterialMarkType.Name", 150, 0);
            AddColumn(priceStr, "PriceVal", 250, 1);
        }
    }
}