using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using Socrat.UI.Core;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.Shape.Forms
{
    public partial class FxAxis : FxBaseSimpleDialog
    {
        private List<string> itemsLocationList;
        ShprosElement shprosElement;

        public ShprosElement ShprosElement
        {
            get => shprosElement;
            set => shprosElement = value; }

        public FxAxis()
        {
            //shprosElement = new Core.Entities.ShprosElement();
            InitializeComponent();
            Load += FxAxis_Load;
        }

        private void FxAxis_Load(object sender, EventArgs e)
        {
            cmbVektor.Properties.NullText = "";
            itemsLocationList = ShprosElement.ComboItems;
            //itemsLocationList = new List<string> { "Слева", "Справа", "Центр" };
            cmbVektor.Properties.DropDownRows = itemsLocationList.Count;
            cmbVektor.Properties.DataSource = itemsLocationList;
            txtMargin.EditValue = "0";
        }

        protected override IEntity GetEntity()
        {
            return ShprosElement;
        }
        protected override void SetEntity(IEntity value)
        {
            ShprosElement = value as ShprosElement;
        }
        public override bool Validate()
        {
            return true;
        }
        private string BuildLocationString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            switch (cmbVektor.Text)
            {
                case "Слева":
                    stringBuilder.Append("Л- ");
                    break;
                case "Справа":
                    stringBuilder.Append("П- ");
                    break;
                case "Центр":
                    stringBuilder.Append("Ц- ");
                    break;

            }
            stringBuilder.Append(txtMargin.Text.Trim());
            stringBuilder.Append("    мм");
            return stringBuilder.ToString();
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { txtMargin, cmbVektor };
        }

        protected override void OnSaveButtonClick()
        {
            ShprosElement.Location = BuildLocationString();
            ShprosElement.SideVector = cmbVektor.Text.Trim();
            float.TryParse(txtMargin.Text, out float l);
            ShprosElement.Margin = l;
            base.OnSaveButtonClick();
        }
    }
}