using System;
using System.Linq;
using System.Collections.ObjectModel;
using DevExpress.XtraGrid.Views.Grid;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;

namespace Socrat.References.Price
{
    public partial class CxPriceTypes : CxGenericListTable<PriceValue>
    {
        private IPriceService _priceService;
        public ObservableCollection<PriceType> PriceTypes { get; set; }
        public Core.Entities.Price Price { get; set; }
        public CxPriceTypes()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override ObservableCollection<PriceValue> GetItems()
        {
            ObservableCollection<PriceValue> priceValues = new ObservableCollection<PriceValue>(PriceTypes.SelectMany(p => p.PriceValues, (pt, col) => col).ToList());
            PricePeriod period = Price.PricePeriods.OrderByDescending(p => p.DateBegin).DefaultIfEmpty(new PricePeriod()).First();
            if (period.PriceId != null)
            {
                IRepository<PriceSelectType> priceSelectTypes = Socrat.DataProvider.DataHelper.GetRepository<PriceSelectType>();
                int val = priceSelectTypes.GetAll().Count(p => p.PriceId == period.PriceId);

                ObservableCollection<PriceValue> result = new ObservableCollection<PriceValue>(priceValues.Where(p =>
                    p.PricePeriod.DateBegin == period.DateBegin.Value && period.PriceId == Price.Id));
                return result;
            }

            return new ObservableCollection<PriceValue>();
        }

        protected override void OpenItem()
        {

            FxPriceValueEdit edit = new FxPriceValueEdit();

            Guid? g = GetCurrentRowId();
            if(g == Guid.Empty)
            {
                return;
            }

            PriceValue entity = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());

            edit.PriceValue = entity;
            edit.DialogOutput += Form_DialogOutput;
            OnDialogOutput(edit, DialogOutputType.Dialog);
            edit.Show();
        }

        private void Form_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        protected override IEntityEditor GetEditor()
        {
            FxPriceValueEdit editor = new FxPriceValueEdit();

            PriceValue val = (PriceValue)((GridView)gcGrid.MainView).GetFocusedRow();
            if (val != null)

            {
                PriceValue newVal = new PriceValue()
                {
                    MaterialNomId = val.MaterialNomId,
                    MaterialNom = val.MaterialNom,
                    PriceTypeId = val.PriceTypeId,
                    PriceType = val.PriceType,
                    PricePeriodId = val.PricePeriodId,
                    PricePeriod = val.PricePeriod
                };
                editor.PriceValue = newVal;
                editor.Added = true;
            }
            else
            {
                PriceValue newVal = new PriceValue();

                PricePeriod pp = Price.PricePeriods.OrderByDescending(p => p.DateBegin).FirstOrDefault();


                newVal.PricePeriod = pp;
                newVal.PriceType = new PriceType();
                editor.PriceValue = newVal;
                editor.Added = true;
            }

            return editor;
        }

        private void Editor_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        protected override void InitColumns()
        {
            AddColumn("Раздел прайса", "PriceType.Name", 250, 3);
            AddColumn("Материал", "PriceType.Material.Name", 250, 4);
            AddColumn("Подтип прайса", "PriceType.MaterialMarkType.Name", 250, 5);
            AddColumn("Тип прайса", "MaterialNom.VendorMaterialNom", 250, 6);
            AddColumn("Значение прайса", "PriceVal", 250, 7);

            GroupByColumn("PriceType.Name");
            GroupByColumn("PriceType.Material.Name");
            GroupByColumn("PriceType.MaterialMarkType.Name");
        }
    }
}
