using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Contract
{
    public partial class FxContractShippingSquareEdit : FxBaseSimpleDialog
    {
        public ContractShippingSquare ContractShippingSquare { get; set; }

        public FxContractShippingSquareEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return ContractShippingSquare;
        }

        protected override void SetEntity(IEntity value)
        {
            ContractShippingSquare = value as ContractShippingSquare;
        }

        protected override void BindData()
        {
            base.BindData();
            this.DataBindings.Clear();
            this.DataBindings.Add("Text", ContractShippingSquare, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            BindEditor(teSquAmount, ContractShippingSquare, "SquAmount");
            BindEditor(teSquPrice, ContractShippingSquare, "PriceSqu");
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teSquAmount, teSquPrice};
        }

        protected override void SaveButtonClicked()
        {
            if (ContractShippingSquare.Changed)
                ContractShippingSquare.User = SocratEntities.User;
            base.SaveButtonClicked();
        }
    }
}