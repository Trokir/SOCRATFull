using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public partial class FxPriceFormEdit : FxBaseSimpleDialog
    {
        public PriceForm PriceForm { get; set; }
        private IPriceService _priceService;
        private Core.Entities.Price _price;

        public FxPriceFormEdit()
        {
            Init();
        }

        public FxPriceFormEdit(Core.Entities.Price price)
        {
            _price = price;
            Init();
        }
        private void Init()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override void SaveButtonClicked()
        {
            IRepository<PriceForm> repository = DataHelper.GetRepository<PriceForm>();
            PriceForm.Edit = DateTime.Now;
            repository.Save(PriceForm);
            PriceForm.Changed = false;
            base.SaveButtonClicked();
        }

        protected override IEntity GetEntity()
        {
            return PriceForm;
        }

        protected override void SetEntity(IEntity value)
        {
            PriceForm = value as PriceForm;

            PriceForm.Price = _price;
            PriceForm.PriceId = _price.Id;
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teValue, beFormType };
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teValue, PriceForm, x => x.Discount);

            beFormType.DataBindings.Clear();
            beFormType.DataBindings.Add("EditValue", PriceForm, "FormType.Name", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void beFormType_Click(object sender, EventArgs e)
        {
            FxFormTypes formTypes = new FxFormTypes();
            formTypes.SetSingleSelectMode(PriceForm.FormType);
            DialogResult dialogResult = formTypes.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && formTypes.SelectedItem != null)
                PriceForm.FormType = formTypes.SelectedItem as FormType;
        }
    }
}