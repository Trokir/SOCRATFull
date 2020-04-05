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
using Socrat.UI.Core;
using Socrat.Core;

namespace Socrat.Shape.Forms
{
    public partial class FxConturForm : FxBaseSimpleDialog
    {
        Core.Entities.ShprosCircuit shprosCircuit;
        public FxConturForm()
        {
            InitializeComponent();
        }
        protected override IEntity GetEntity()
        {
            return shprosCircuit;
        }
        protected override void SetEntity(IEntity value)
        {
            shprosCircuit = value as Core.Entities.ShprosCircuit;
        }
        protected override void OnSaveButtonClick()
        {
            if (shprosCircuit != null)
            {
                shprosCircuit.Name = "Контур";
                shprosCircuit.Length = double.Parse(txtLength.Text.Trim());
                shprosCircuit.Square = shprosCircuit.Length * shprosCircuit.Length;
               
            }
                base.OnSaveButtonClick();
        }

        protected override string GetTitle()
        {
            return $"Контуры";
        }
        public override string ToString()
        {
            return $"{Name}";
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { txtLength };
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(txtLength, shprosCircuit, x => x.Length);
        }
    }
}