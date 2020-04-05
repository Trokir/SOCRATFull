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
using DevExpress.XtraEditors.Controls;

using Socrat.Core;
using Socrat.DataProvider;
using Socrat.UI.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities.Work;
using Socrat.Core.Entities.Machines;
using Socrat.Core.Helpers;

namespace Socrat.References.Work
{
    public partial class FxWorkShiftsTemplateListEdit : FxBaseSimpleDialog
    {
        public WorkShiftType WorkShiftType { get; private set; }
        public MachineType MachineType { get; private set; }

        public WorkShiftsTemplateList WorkShiftsTemplateList { get; set; }

        private CxWorkShiftTemplate _cxWorkShiftTemplate;

        public FxWorkShiftsTemplateListEdit()
        {
            InitializeComponent();
            this.Text = GetTitle();

            WorkShiftsTemplateList = new WorkShiftsTemplateList() { Loaded = true };

            this.Load += FxWorkShiftsTemplateListEdit_Load;

            SaveButtonClick += (_sender, args) =>
            {
                if (!Entity?.Changed ?? false)
                    return;

                if (this.ReadOnly)
                {
                    DataHelper.RevertEx(WorkShiftsTemplateList);
                    return;
                }

                DialogResult dr = DialogResult.Yes;
                if (args.FromClosing)
                    dr = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                args.Cancel = dr == DialogResult.Cancel;
                if (dr == DialogResult.No)
                {
                    DataHelper.RevertEx(WorkShiftsTemplateList);
                    return;
                }

                //if (ValidationHelper.Validate<WeeklyWorkShiftsList>(
                //      ValidationStage.OnEdit,
                //      WorkShiftsTemplateList,
                //      WorkShiftsTemplateList.WorkShiftsTemplates))
                {                   
                    bool res = DataHelper.SaveEx(WorkShiftsTemplateList.WorkShiftsTemplates.Where(t=>t.Changed));
                    if(res)
                        WorkShiftsTemplateList.Changed = false;                    
                }

            };
        }

        protected override IEntity GetEntity()
        {
            return WorkShiftsTemplateList;
        }

        private void FxWorkShiftsTemplateListEdit_Load(object sender, EventArgs e)
        {
            PrepareLookUpEdit(leWorkShiftType);
            PrepareLookUpEdit(leMachineType);

            if (Site != null && Site.DesignMode == true)
                return;
            leMachineType.Properties.DataSource = DataHelper.GetAll<MachineType>();
            leWorkShiftType.Properties.DataSource = DataHelper.GetAll<WorkShiftType>(t => t.Division.Id == Constants.CurrentDivision.Id);

            IniWorkShiftsTemplate();
            _cxWorkShiftTemplate.ApplyFilter(MachineType, WorkShiftType);
        }

        private void PrepareLookUpEdit(LookUpEdit le)
        {
            le.Properties.ShowFooter = false;
            le.Properties.ShowHeader = false;
            le.Properties.DisplayMember = "AliasName";
            le.Properties.Columns.Add(
                new LookUpColumnInfo(le.Properties.DisplayMember));
        }

        private void IniWorkShiftsTemplate()
        {
            _cxWorkShiftTemplate = new CxWorkShiftTemplate()
            {
                WorkShiftsTemplateList = WorkShiftsTemplateList,
                //DependedSaving = true,
                ReadOnly = this.ReadOnly
            };
            pcWorkShifts.Controls.Add(_cxWorkShiftTemplate);
            _cxWorkShiftTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            //_cxWorkShiftTemplate.DialogOutput += (sender, ta) => OnDialogOutput(ta);
        }

        protected override string GetTitle()
        {
            return "Недельный плановый график работы оборудования";
        }

        private volatile bool autoChanging = false;
        private void chGo_CheckedChanged(object sender, EventArgs e)
        {
            if (chGo.Checked == true)
            {
                chGo.Text = "Отменить";
                if (autoChanging == false)
                {
                    OnFilterSet();
                }
            }
            else
            {
                chGo.Text = "Применить";
                if (autoChanging == false)
                {
                    OnFilterReset();
                }
            }
        }

        private void OnFilterReset()
        {
            _cxWorkShiftTemplate.ApplyFilter(null, null);
        }

        private void OnFilterSet()
        {
            _cxWorkShiftTemplate.ApplyFilter(MachineType, WorkShiftType);
        }

        private void _ValueChanged(object sender, EventArgs e)
        {
            SetFilterState();
        }

        private void SetFilterState()
        {
            if (leWorkShiftType.EditValue != null || leMachineType.EditValue != null)
            {
                WorkShiftType = leWorkShiftType.EditValue as WorkShiftType;
                MachineType = leMachineType.EditValue as MachineType;
                chGo.Text = "Применить";
                autoChanging = true;
                chGo.Checked = false;
                autoChanging = false;
            }
            else
            {
                WorkShiftType = null;
                MachineType = null;
                chGo.Text = "Отменить";
                autoChanging = true;
                chGo.Checked = true;
                autoChanging = false;
            }
        }

        private void leWorkShiftType_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                leWorkShiftType.EditValue = null;
        }

        private void leMachineType_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                leMachineType.EditValue = null;
        }

    }
}
