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

namespace Socrat.References.Work
{
    // уже НЕ используется (вызывался из cx смен по бригаде), оставлен на небольшое время, вдруг попросят вернуть редактирование сущности из бригады
    public partial class FxWeeklyWorkShiftsEdit : FxBaseSimpleDialog
    {
        private ButtonEditAssistent<WorkShiftType, FxWorkShiftTypes, FxWorkShiftTypeEdit> _workShiftTypeButtonEditAssistent;
        private ButtonEditAssistent<MachineNom, Machines.FxMachineNoms, Machines.FxMachineNomEdit> _machineNomButtonEditAssistent;
        //private ButtonEditAssistent<Team, FxTeams, FxTeamEdit> _teamButtonEditAssistent;

        public WeeklyWorkShifts WeeklyWorkShifts { get; set; }
        public FxWeeklyWorkShiftsEdit()
        {
            InitializeComponent();           

            //seYear.Properties.MinValue = 2016;
            //seYear.Properties.MaxValue = DateTime.Now.Year + 2;
            //seWeekNum.Properties.MinValue = 1;
            //seWeekNum.Properties.MaxValue = 52;


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
                beWorkShiftTypes, WeeklyWorkShifts.WorkShiftType, OnDialogOutput, readOnly: this.ReadOnly); //, eButtonsType.Search
            _workShiftTypeButtonEditAssistent.ExternalFilterExp = t => t.Division.Id == Constants.CurrentDivision.Id;
            _workShiftTypeButtonEditAssistent.BindProperty(WeeklyWorkShifts, x => x.WorkShiftType);
            _workShiftTypeButtonEditAssistent.SelectionChanged += _workShiftTypeButtonEditAssistent_SelectionChanged;


            _machineNomButtonEditAssistent = new ButtonEditAssistent<MachineNom, Machines.FxMachineNoms, Machines.FxMachineNomEdit>(
                beMachineNoms, WeeklyWorkShifts.MachineNom, OnDialogOutput, readOnly: this.ReadOnly); //, eButtonsType.Search
            _machineNomButtonEditAssistent.ExternalFilterExp = t => t.Division.Id == Constants.CurrentDivision.Id;
            _machineNomButtonEditAssistent.BindProperty(WeeklyWorkShifts, x => x.MachineNom);
            //_machineNomButtonEditAssistent.SelectionChanged += _machineNomButtonEditAssistent_SelectionChanged;



            //_teamButtonEditAssistent = new ButtonEditAssistent<Team, FxTeams, FxTeamEdit>(
            //    beTeams, WeeklyWorkShifts.Team, OnDialogOutput, readOnly: this.ReadOnly); //, eButtonsType.Search
            //_teamButtonEditAssistent.ExternalFilterExp = t => t.Division.Id == Constants.CurrentDivision.Id;
            //_teamButtonEditAssistent.BindProperty(WeeklyWorkShifts, x => x.Team);
            //_teamButtonEditAssistent.SelectionChanged += _teamButtonEditAssistent_SelectionChanged;




            //leWeekDay.Properties.ValueMember = "Value";
            //leWeekDay.Properties.DisplayMember = "Text";
            //leWeekDay.Properties.Columns.Add(
            //    new DevExpress.XtraEditors.Controls.LookUpColumnInfo(leWeekDay.Properties.DisplayMember));
            //leWeekDay.Properties.DataSource = Core.Helpers.EnumHelper<Core.Added.WeekDaysEnum>.GetAll();
            ////leWeekDay.Properties.DataSource = Core.Helpers.EnumHelper_t<Core.Added.WeekDaysEnum>.GetAll(true);
            ///
            if(WeeklyWorkShifts != null && WeeklyWorkShifts.Year > 0 && WeeklyWorkShifts.WeekNum > 0)
            {
                wp1.SetWeek(WeeklyWorkShifts.Year, WeeklyWorkShifts.WeekNum);

            }
        }

        //private void _teamButtonEditAssistent_SelectionChanged(object sender, EventArgs e)
        //{
        //    Team t = WeeklyWorkShifts.Team;
        //    if (t != null)
        //    {
        //        using (new EntityChangedLocker(t))
        //        {
        //            foreach (WorkShift ws in WeeklyWorkShifts.WorkShifts)
        //            {
        //                if (!t.WorkShifts.Contains(ws))
        //                    t.WorkShifts.Add(ws);
        //            }  
        //        }
        //    }
        //}

        // пока эта коллекция (mn.WorkShifts) не реализована, возможно - не нужна
        //private void _machineNomButtonEditAssistent_SelectionChanged(object sender, EventArgs e)
        //{
        //    MachineNom mn = WeeklyWorkShifts.MachineNom;
        //    if (mn != null)
        //    {
        //        mn.Loaded = false;
        //        foreach (WorkShift ws in WeeklyWorkShifts.WorkShifts)
        //        {
        //            if (!mn.WorkShifts.Contains(ws))
        //                mn.WorkShifts.Add(ws);
        //        }
        //        mn.Loaded = true;
        //    }
        //}

        private void _workShiftTypeButtonEditAssistent_SelectionChanged(object sender, EventArgs e)
        {
            WorkShiftType wst = WeeklyWorkShifts.WorkShiftType;
            if (wst != null)
            {
                using (new EntityChangedLocker(wst))
                {
                    foreach (WorkShift ws in WeeklyWorkShifts.WorkShifts)
                    {
                        if (!wst.WorkShifts.Contains(ws))
                            wst.WorkShifts.Add(ws);
                    }
                }
                
            }
        }

        protected override IEntity GetEntity()
        {
            return WeeklyWorkShifts;
        }

        protected override void SetEntity(IEntity value)
        {
            WeeklyWorkShifts = value as WeeklyWorkShifts;
        }

        protected override void BindData()
        {
            base.BindData();

            //BindEditor(seYear, WeeklyWorkShifts, x => x.Year);
            //BindEditor(seWeekNum, WeeklyWorkShifts, x => x.WeekNum);
            BindEditor(seDuration1, WeeklyWorkShifts, x => x.ShiftDuration1);
            BindEditor(seDuration2, WeeklyWorkShifts, x => x.ShiftDuration2);
            BindEditor(seDuration3, WeeklyWorkShifts, x => x.ShiftDuration3);
            BindEditor(seDuration4, WeeklyWorkShifts, x => x.ShiftDuration4);
            BindEditor(seDuration5, WeeklyWorkShifts, x => x.ShiftDuration5);
            BindEditor(seDuration6, WeeklyWorkShifts, x => x.ShiftDuration6);
            BindEditor(seDuration7, WeeklyWorkShifts, x => x.ShiftDuration7);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beWorkShiftTypes, beMachineNoms }; //, seYear, seWeekNum
        }        

        private void seDuration_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (sender is BaseEdit editor && editor.EditValue != null && (decimal)editor.EditValue == 0)
                    editor.EditValue = null;
            }
        }

        public override bool Validate()
        {
            if(wp1.Week == null)
            {
                XtraMessageBox.Show("Не установлена неделя!", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return base.Validate();
        }

        private void wp1_ValueChanged(object sender, EventArgs e)
        {
            if(wp1.Week != null)
            {
                WeeklyWorkShifts.Year = wp1.Year.Value;
                WeeklyWorkShifts.WeekNum = wp1.Week.Value;
            }            
        }
    }
}
