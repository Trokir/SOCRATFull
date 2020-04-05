using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Order;
using Socrat.UI.Core;

namespace Socrat.References.Processings
{
    public partial class FxProcessingEdit : FxBaseSimpleDialog
    {
        public Processing Processing { get; set; }
        private ButtonEditAssistent<SlozType, FxSlozTypes, FxShortNamedEntityEdit> _slozTypeButtonEditAssistent;
        private ButtonEditAssistent<ProcessingType, FxProcessingTypes, FxProcessingTypeEdit>
            _procTypeButtonEditAssistent;

        public FxProcessingEdit()
        {
            InitializeComponent();
            Load += FxProcessingEdit_Load;
        }

        private void FxProcessingEdit_Load(object sender, EventArgs e)
        {
            _slozTypeButtonEditAssistent = 
                new ButtonEditAssistent<SlozType, FxSlozTypes, FxShortNamedEntityEdit>(beSlozType, Processing.SlozType, OnDialogOutput);
            _slozTypeButtonEditAssistent.BindProperty(Processing, x => x.SlozType);

            _procTypeButtonEditAssistent = 
                new ButtonEditAssistent<ProcessingType, FxProcessingTypes, FxProcessingTypeEdit>(beProcessingType, 
                    Processing.ProcessingType, OnDialogOutput);
            _procTypeButtonEditAssistent.BindProperty(Processing, x => x.ProcessingType);
        }

        protected override IEntity GetEntity()
        {
            return Processing;
        }

        protected override void SetEntity(IEntity value)
        {
            Processing = value as Processing;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, Processing, x => x.Name);
            BindEditor(teShortName, Processing, x => x.ShortName);
            BindEditor(seStep, Processing, x => x.Step);
            BindEditor(teOutcropSize, Processing, x => x.OutcropSize);

            beProcessingType.EditValue = Processing?.ProcessingType;
            beSlozType.EditValue = Processing?.SlozType;
            ceColor.Color = Processing?.Color ?? Color.Empty;
        }

        //private void LoadData()
        //{
        //    ProcessingTypes = DataHelper.GetAll<ProcessingType>();
        //    lueProcessingType.Properties.DataSource = null;
        //    lueProcessingType.Properties.DataSource = ProcessingTypes;

        //    SlozTypes = DataHelper.GetAll<SlozType>();
        //    lueSlozType.Properties.DataSource = null;
        //    lueSlozType.Properties.DataSource = SlozTypes;
        //}

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beProcessingType, teName, teShortName, seStep};
        }

        //private void lueProcessingType_EditValueChanged(object sender, System.EventArgs e)
        //{
        //    Guid _id;
        //    if (lueProcessingType.EditValue != null && Guid.TryParse(lueProcessingType.EditValue.ToString(), out _id))
        //    {
        //        Processing.ProcessingType = ProcessingTypes.FirstOrDefault(x => x.Id == _id);
        //    }
        //}

        //private void lueSlozType_EditValueChanged(object sender, EventArgs e)
        //{
        //    Guid _id;
        //    if (lueSlozType.EditValue != null && Guid.TryParse(lueSlozType.EditValue.ToString(), out _id))
        //    {
        //        Processing.SlozType = SlozTypes.FirstOrDefault(x => x.Id == _id);
        //    }
        //}

        private void ceColor_EditValueChanged(object sender, EventArgs e)
        {
            if (Processing != null)
                Processing.Color = ceColor.Color;
        }

        //private void lueProcessingType_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    switch (e.Button.Kind)
        //    {
        //        case ButtonPredefines.Ellipsis:
        //            SelectProcessingType();
        //            break;
        //        case ButtonPredefines.Search:
        //            OpenProcessingType();
        //            break;
        //    }
        //}

        //private void OpenProcessingType()
        //{
        //    FxProcessingTypeEdit _fx = new FxProcessingTypeEdit();
        //    _fx.Entity = Processing.ProcessingType;
        //    _fx.DialogOutput += _fx_DialogOutput;
        //    OnDialogOutput(_fx, DialogOutputType.Dialog);
        //}

        //private void _fx_DialogOutput(object sender, WindowOutputEventArgs e)
        //{
        //    OnDialogOutput(e.NewTab, e.OutputType);
        //}

        //private void SelectProcessingType()
        //{
        //    FxProcessingTypes _fx = new FxProcessingTypes();
        //    _fx.SetSingleSelectMode(this.Processing);
        //    _fx.DialogOutput += _fx_DialogOutput;
        //    _fx.ItemSelected += (sender, args) =>
        //    {
        //        Processing.ProcessingType = _fx.SelectedItem as ProcessingType;

        //        ProcessingTypes = DataHelper.GetAll<ProcessingType>();
        //        lueProcessingType.Properties.DataSource = null;
        //        lueProcessingType.Properties.DataSource = ProcessingTypes;
        //        lueProcessingType.EditValue = Processing.ProcessingType?.Id;
        //    };
        //    OnDialogOutput(_fx, DialogOutputType.Dialog);
        //}

        //private void lueSlozType_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    switch (e.Button.Kind)
        //    {
        //        case ButtonPredefines.Ellipsis:
        //            SelectSlozType();
        //            break;
        //        case ButtonPredefines.Search:
        //            OpenSlozType();
        //            break;
        //    }
        //}

        //private void OpenSlozType()
        //{
        //    FxShortNamedEntityEdit _fx = new FxShortNamedEntityEdit("Тип сложности");
        //    _fx.Entity = Processing.SlozType;
        //    _fx.DialogOutput += _fx_DialogOutput;
        //    OnDialogOutput(_fx, DialogOutputType.Dialog);
        //}

        //private void SelectSlozType()
        //{
        //    FxSlozTypes _fx = new FxSlozTypes();
        //    _fx.SetSingleSelectMode(this.Processing);
        //    _fx.DialogOutput += _fx_DialogOutput;
        //    _fx.ItemSelected += (sender, args) =>
        //    {
        //        Processing.SlozType = _fx.SelectedItem as SlozType;

        //        SlozTypes = DataHelper.GetAll<SlozType>();
        //        lueSlozType.Properties.DataSource = null;
        //        lueSlozType.Properties.DataSource = SlozTypes;
        //        lueSlozType.EditValue = Processing.SlozType?.Id;
        //    };
        //    OnDialogOutput(_fx, DialogOutputType.Dialog);
        //}
    }
}