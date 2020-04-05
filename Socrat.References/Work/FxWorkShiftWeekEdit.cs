using System;
using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.UI.Core;
using Socrat.Core.Entities.Work;
using Socrat.Core.Entities.Machines;
using System.Windows.Forms;
using Socrat.Core.Added;
using Socrat.DataProvider;

namespace Socrat.References.Work
{
    // уже НЕ используется (вызывался из cx шаблона смен по оборудованию), оставлен на небольшое время, вдруг попросят вернуть редактирование сущности из оборудования
    public partial class FxWorkShiftWeekEdit : FxBaseSimpleDialog
    {

        private ButtonEditAssistent<WorkShiftType, FxWorkShiftTypes, FxWorkShiftTypeEdit> _workShiftTypeButtonEditAssistent;
        private ButtonEditAssistent<MachineNom, Machines.FxMachineNoms, Machines.FxMachineNomEdit> _machineNomButtonEditAssistent;

        public WorkShiftsTemplate WorkShiftWeek { get; set; }
        public FxWorkShiftWeekEdit()
        {
            InitializeComponent();

            InitSpinControl(seDuration1);
            InitSpinControl(seDuration2);
            InitSpinControl(seDuration3);
            InitSpinControl(seDuration4);
            InitSpinControl(seDuration5);
            InitSpinControl(seDuration6);
            InitSpinControl(seDuration7);

            Load += FxWorkShiftWeekEdit_Load;
        }

        private void InitSpinControl(SpinEdit se)
        {
            se.Properties.AllowNullInput = DefaultBoolean.True;
            se.Properties.NullText = "Не установлено";
            se.Properties.MinValue = 0;
            se.Properties.MaxValue = 48;
            se.KeyUp += this.seDuration_KeyUp;
        }

        private void FxWorkShiftWeekEdit_Load(object sender, System.EventArgs e)
        {
            _workShiftTypeButtonEditAssistent = new ButtonEditAssistent<WorkShiftType, FxWorkShiftTypes, FxWorkShiftTypeEdit>(
                beWorkShiftTypes, WorkShiftWeek.WorkShiftType, OnDialogOutput, eButtonsType.Search, readOnly: this.ReadOnly);
            _workShiftTypeButtonEditAssistent.ExternalFilterExp = t => t.Division.Id == Constants.CurrentDivision.Id;
            _workShiftTypeButtonEditAssistent.BindProperty(WorkShiftWeek, x => x.WorkShiftType);
            _workShiftTypeButtonEditAssistent.SelectionChanged += _workShiftTypeButtonEditAssistent_SelectionChanged;

            _machineNomButtonEditAssistent = new ButtonEditAssistent<MachineNom, Machines.FxMachineNoms, Machines.FxMachineNomEdit>(
                beMachineNoms, WorkShiftWeek.MachineNom, OnDialogOutput, eButtonsType.Search, readOnly: this.ReadOnly);
            _machineNomButtonEditAssistent.ExternalFilterExp = t => t.Division.Id == Constants.CurrentDivision.Id;
            _machineNomButtonEditAssistent.BindProperty(WorkShiftWeek, x => x.MachineNom);
            _machineNomButtonEditAssistent.SelectionChanged += _machineNomButtonEditAssistent_SelectionChanged;
            
            //leWeekDay.Properties.ValueMember = "Value";
            //leWeekDay.Properties.DisplayMember = "Text";
            //leWeekDay.Properties.Columns.Add(
            //    new DevExpress.XtraEditors.Controls.LookUpColumnInfo(leWeekDay.Properties.DisplayMember));
            //leWeekDay.Properties.DataSource = Core.Helpers.EnumHelper<Core.Added.WeekDaysEnum>.GetAll();
            ////leWeekDay.Properties.DataSource = Core.Helpers.EnumHelper_t<Core.Added.WeekDaysEnum>.GetAll(true);
        }

        private void _workShiftTypeButtonEditAssistent_SelectionChanged(object sender, EventArgs e)
        {
            WorkShiftType wst = WorkShiftWeek.WorkShiftType;
            DataHelper.ApplyBackReference(wst, wst.WorkShiftWeeks, WorkShiftWeek);
        }

        private void _machineNomButtonEditAssistent_SelectionChanged(object sender, EventArgs e)
        {
            MachineNom mn = WorkShiftWeek.MachineNom;
            DataHelper.ApplyBackReference(mn, mn.WorkShiftWeeks, WorkShiftWeek);
        }

        protected override IEntity GetEntity()
        {
            return WorkShiftWeek;
        }

        protected override void SetEntity(IEntity value)
        {
            WorkShiftWeek = value as WorkShiftsTemplate;
        }

        protected override void BindData()
        {
            base.BindData();
            //BindEditor(leWeekDay, WorkShiftWeek, x => x.WeekDay);
            BindEditor(seDuration1, WorkShiftWeek, x => x.ShiftDuration1);
            BindEditor(seDuration2, WorkShiftWeek, x => x.ShiftDuration2);
            BindEditor(seDuration3, WorkShiftWeek, x => x.ShiftDuration3);
            BindEditor(seDuration4, WorkShiftWeek, x => x.ShiftDuration4);
            BindEditor(seDuration5, WorkShiftWeek, x => x.ShiftDuration5);
            BindEditor(seDuration6, WorkShiftWeek, x => x.ShiftDuration6);
            BindEditor(seDuration7, WorkShiftWeek, x => x.ShiftDuration7);

        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beWorkShiftTypes, beMachineNoms };
        }        

        private void seDuration_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (sender is BaseEdit editor && editor.EditValue != null && (decimal)editor.EditValue == 0)
                    editor.EditValue = null;
            }
        }

        
    }
}
