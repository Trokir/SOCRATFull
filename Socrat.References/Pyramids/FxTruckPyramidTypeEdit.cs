using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Socrat.UI.Core;
using Socrat.Core.Entities.Pyramids;
using Socrat.Core;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace Socrat.References.Pyramids
{
    public partial class FxTruckPyramidTypeEdit : FxBaseSimpleDialog
    {
        public TruckPyramidType TruckPyramidType { get; set; }
        public FxTruckPyramidTypeEdit()
        {
            InitializeComponent();

            PrepareSpinEdit(seSideCount);           
            PrepareSpinEdit(seB);

        }
       
        protected override IEntity GetEntity()
        {
            return TruckPyramidType;
        }

        protected override void SetEntity(IEntity value)
        {
            TruckPyramidType = value as TruckPyramidType;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, TruckPyramidType, x => x.Name);
            BindEditor(chkDefault, TruckPyramidType, x => x.IsDefault);
            BindEditor(seSideCount, TruckPyramidType, x => x.SideCount);
            //BindEditor(seWidth, TruckPyramidType, x => x.SideWidth);
            //BindEditor(seHeight, TruckPyramidType, x => x.SideHeight);           

            BindEditor(seA, TruckPyramidType, x => x.A);
            BindEditor(seA1, TruckPyramidType, x => x.A1);
            BindEditor(seA4, TruckPyramidType, x => x.A4);
            BindEditor(seB, TruckPyramidType, x => x.B);
            BindEditor(seB1, TruckPyramidType, x => x.B1);
            BindEditor(seH, TruckPyramidType, x => x.H);
            BindEditor(seH1, TruckPyramidType, x => x.H1);







        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName, seSideCount, seA, seA1, seA4, seB, seB1, seH, seH1 };
        }

        private void PrepareSpinEdit(SpinEdit se)
        {
            se.Properties.AllowNullInput = DefaultBoolean.True;
            se.Properties.NullText = "Не установлено";
            se.Properties.MinValue = 0;
            se.Properties.MaxValue = decimal.MaxValue;
            se.KeyUp += new System.Windows.Forms.KeyEventHandler(se_KeyUp);
        }

        private void se_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                SpinEdit se = sender as SpinEdit;
                if (se != null && se.EditValue != null && (decimal)se.EditValue == 0)
                    se.EditValue = null;
            }
        }
    }
}
