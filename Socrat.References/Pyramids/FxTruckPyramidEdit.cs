using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities.Machines;
using Socrat.UI.Core;
using Socrat.Core.Entities.Pyramids;
using Socrat.References.Division;
using DevExpress.Utils;
using Socrat.DataProvider;

namespace Socrat.References.Pyramids
{
    public partial class FxTruckPyramidEdit : FxBaseSimpleDialog
    {
        private ButtonEditAssistent<TruckPyramidType, FxTruckPyramidTypes, FxTruckPyramidTypeEdit> _truckPyramidTypeButtonEditAssistent;
        private ButtonEditAssistent<Core.Entities.Division, FxDivisions, FxDivisionEdit> _divisionButtonEditAssistent;

        

        public TruckPyramid TruckPyramid { get; set; }
        public FxTruckPyramidEdit()
        {
            InitializeComponent();

            //seNum.Properties.AllowNullInput = DefaultBoolean.True;
            //seNum.Properties.NullText = "Не установлено";
            //seNum.Properties.MinValue = 0;
            //seNum.Properties.MaxValue = decimal.MaxValue;
            //this.seNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.seNum_KeyUp);

            Load += FxTruckPyramidEdit_Load;
        }

        private void FxTruckPyramidEdit_Load(object sender, System.EventArgs e)
        {
            _truckPyramidTypeButtonEditAssistent = new ButtonEditAssistent<TruckPyramidType, FxTruckPyramidTypes, FxTruckPyramidTypeEdit>(
                beTruckPyramidTypes, TruckPyramid.TruckPyramidType, OnDialogOutput, readOnly: this.ReadOnly); //, eButtonsType.Search
            _truckPyramidTypeButtonEditAssistent.BindProperty(TruckPyramid, x => x.TruckPyramidType);
            _truckPyramidTypeButtonEditAssistent.SelectionChanged += _truckPyramidTypeButtonEditAssistent_SelectionChanged;

            //_divisionButtonEditAssistent = new ButtonEditAssistent<Core.Entities.Division, FxDivisions, FxDivisionEdit>(
            //    beDivisions, TruckPyramid.Division, OnDialogOutput, eButtonsType.Search, readOnly: this.ReadOnly);
            //_divisionButtonEditAssistent.BindProperty(TruckPyramid, x => x.Division);
            
        }

        private void _truckPyramidTypeButtonEditAssistent_SelectionChanged(object sender, EventArgs e)
        {
            TruckPyramidType tpt = TruckPyramid.TruckPyramidType;
            DataHelper.ApplyBackReference(tpt, tpt.Pyramids, TruckPyramid);
        }

        private void _DeleteItemEvent(object sender, ListItemEventArgs e)
        {
            ((IRefreshable)sender)?.RefreshData();
        }

        protected override IEntity GetEntity()
        {
            return TruckPyramid;
        }

        protected override void SetEntity(IEntity value)
        {
            TruckPyramid = value as TruckPyramid;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teMark, TruckPyramid, x => x.Mark);
            BindEditor(teNum, TruckPyramid, x => x.Num);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beTruckPyramidTypes, teNum };
        }

        //private void seNum_KeyUp(object sender, KeyEventArgs e)
        //{            
        //    if (e.KeyData == Keys.Delete)
        //    {
        //        SpinEdit se = sender as SpinEdit;
        //        if (se!= null && se.EditValue != null && (decimal)se.EditValue == 0)
        //            se.EditValue = null;
        //    }
        //}
    }
}
