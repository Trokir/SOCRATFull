using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using Socrat.Core;
using DevExpress.XtraEditors;
using Socrat.UI.Core;
using Socrat.Core.Entities.Work;
using Socrat.References.Division;

namespace Socrat.References.Work
{
    public partial class FxWorkShiftTypeEdit : FxBaseSimpleDialog
    {
        //private ButtonEditAssistent<Core.Entities.Division, FxDivisions, FxDivisionEdit> _divisionButtonEditAssistent;

        public WorkShiftType WorkShiftType { get; set; }
        public FxWorkShiftTypeEdit()
        {
            InitializeComponent();

            seNum.Properties.AllowNullInput = DefaultBoolean.True;
            seNum.Properties.NullText = "Не установлено";
            seNum.Properties.MinValue = 0;
            seNum.Properties.MaxValue = decimal.MaxValue;
            this.seNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.seNum_KeyUp);

            Load += FxWorkShiftTypeEdit_Load;
        }

        private void FxWorkShiftTypeEdit_Load(object sender, System.EventArgs e)
        {
            //_divisionButtonEditAssistent = new ButtonEditAssistent<Core.Entities.Division, FxDivisions, FxDivisionEdit>(
            //    beDivisions, WorkShiftType.Division, OnDialogOutput, eButtonsType.Search, readOnly: this.ReadOnly);
            //_divisionButtonEditAssistent.BindProperty(WorkShiftType, x => x.Division);
        }

        protected override IEntity GetEntity()
        {
            return WorkShiftType;
        }

        protected override void SetEntity(IEntity value)
        {
            WorkShiftType = value as WorkShiftType;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, WorkShiftType, x => x.Name);
            BindEditor(seNum, WorkShiftType, x => x.OrderNum);
            BindEditor(ceColor, WorkShiftType, x => x.Color);
            
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName  }; //, seNum ,beDivisions
        }

        
        private void ceColor_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Delete)
                ceColor.EditValue = null;
        }

        private void seNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if(seNum.EditValue!= null && (decimal)seNum.EditValue == 0)
                    seNum.EditValue = null;
            }
                
        }
    }
}
