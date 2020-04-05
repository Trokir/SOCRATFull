using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Division
{
    public partial class FxDivisionCoworkerEdit : FxBaseSimpleDialog
    {
        public CoworkerPosition CoworkerPosition { get; set; }

        public FxDivisionCoworkerEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return CoworkerPosition;
        }

        protected override void SetEntity(IEntity value)
        {
           CoworkerPosition = value as CoworkerPosition;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beCoworker, bePosition};
        }

        private void beCoworker_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FxCowokers _fx = new FxCowokers();
            _fx.SetSingleSelectMode(CoworkerPosition.Coworker);
            _fx.DialogOutput += _fx_DialogOutput;
            _fx.ItemSelected += (o, args) =>
            {
                beCoworker.EditValue = _fx.SelectedItem;
                CoworkerPosition.Coworker = _fx.SelectedItem as Coworker;
            };
            OnDialogOutput(_fx, DialogOutputType.Dialog, this);
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        private void bePosition_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FxWorkPositions _fx = new FxWorkPositions();
            _fx.SetSingleSelectMode(CoworkerPosition.WorkPosition);
            _fx.DialogOutput += _fx_DialogOutput;
            _fx.ItemSelected += (o, args) =>
            {
                bePosition.EditValue = _fx.SelectedItem;
                CoworkerPosition.WorkPosition = _fx.SelectedItem as WorkPosition;
            };
            OnDialogOutput(_fx, DialogOutputType.Dialog, this);
        }

        protected override void BindData()
        {
            base.BindData();
            beCoworker.DataBindings.Clear();
            beCoworker.DataBindings.Add("EditValue", CoworkerPosition, "Coworker", true, DataSourceUpdateMode.OnPropertyChanged);
            bePosition.DataBindings.Clear();
            bePosition.DataBindings.Add("EditValue", CoworkerPosition, "WorkPosition", true, DataSourceUpdateMode.OnPropertyChanged);
            lcDivision.DataBindings.Clear();
            lcDivision.DataBindings.Add("Text", CoworkerPosition, "Division");
        }
    }
}