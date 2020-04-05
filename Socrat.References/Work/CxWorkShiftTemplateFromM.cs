using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.Core.Entities.Work;
using Socrat.DataProvider;

namespace Socrat.References.Work
{
    public partial class CxWorkShiftTemplateFromM : CxGenericListTable<WorkShiftsTemplate> //XXXX own
    {
        //public Core.Entities.Machines.MachineNom MachineNom { get; set; }

        public WorkShiftsTemplateList WorkShiftsTemplateList{ get; set; }
       
        public CxWorkShiftTemplateFromM()
        {
            InitializeComponent();

            CanOpen = false; // блокируем открытие окна редактора сущности
            RightPaneVisible = false; // скрываем панель команд
            ActionPaneVisible = false;

            this.RefreshingData += _RefreshingData;
            this.Load += CxWorkShiftTemplateFromM_Load;
        }

        protected override IEntity GetOwner()
        {
            return WorkShiftsTemplateList;
        }

        private void CxWorkShiftTemplateFromM_Load(object sender, EventArgs e)
        {
            gvGrid.OptionsBehavior.Editable = !this.ReadOnly;
            gvGrid.OptionsBehavior.ReadOnly = this.ReadOnly;
        }

        protected override AttachedList<WorkShiftsTemplate> GetItems()
        {            
            return WorkShiftsTemplateList.WorkShiftsTemplates;
        }

        protected override void InitCommands()
        {
            // а не нужны в этом компоненте команды
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Тип смены", x => x.WorkShiftType, 200, 0);

            var col = AddColumn("Пн", x => x.ShiftDuration1, 50, 0, "Продолжительность смены (Понедельник)");
            SetColumnSpinEditor(col, 24);
            col = AddColumn("Вт", x => x.ShiftDuration2, 50, 0, "Продолжительность смены (Вторник)");
            SetColumnSpinEditor(col, 24);
            col = AddColumn("Ср", x => x.ShiftDuration3, 50, 0, "Продолжительность смены (Среда)");
            SetColumnSpinEditor(col, 24);
            col = AddColumn("Чт", x => x.ShiftDuration4, 50, 0, "Продолжительность смены (Четверг)");
            SetColumnSpinEditor(col, 24);
            col = AddColumn("Пт", x => x.ShiftDuration5, 50, 0, "Продолжительность смены (Пятница)");
            SetColumnSpinEditor(col, 24);
            col = AddColumn("Сб", x => x.ShiftDuration6, 50, 0, "Продолжительность смены (Суббота)");
            SetColumnSpinEditor(col, 24);
            col = AddColumn("Вс", x => x.ShiftDuration7, 50, 0, "Продолжительность смены (Воскресенье)");
            SetColumnSpinEditor(col, 24);

            SetNotEditableColumns(new string[] { "WorkShiftType" });
        }

        private void SetColumnSpinEditor(GridColumn textColumn, int maxValue)
        {
            RepositoryItemSpinEdit spinEdit = new RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(spinEdit)).BeginInit();
            spinEdit.AutoHeight = false;
            spinEdit.MinValue = 0;
            spinEdit.MaxValue = maxValue;
            spinEdit.DisplayFormat.Format = new NumberFormatInfo();
            spinEdit.DisplayFormat.FormatString = "n0";
            spinEdit.EditFormat.Format = new NumberFormatInfo();
            spinEdit.EditFormat.FormatString = "n0";
            spinEdit.IsFloatValue = false;
            spinEdit.Mask.EditMask = "n0";
            spinEdit.Mask.MaskType = MaskType.Numeric;
            gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { spinEdit });
            textColumn.ColumnEdit = spinEdit;
            spinEdit.MouseUp += spinEdit_MouseUp;
            //spinEdit.EditValueChangedDelay = 300;
            //spinEdit.EditValueChanged += ColumnEdit_EditValueChanged;
            ((System.ComponentModel.ISupportInitialize)(spinEdit)).EndInit();
        }

        private void SetNotEditableColumns(string[] fieldNames)
        {
            foreach (GridColumn gvGridColumn in gvGrid.Columns)
            {
                if (fieldNames.Contains(gvGridColumn.FieldName))
                {
                    gvGridColumn.OptionsColumn.AllowEdit = false;
                    gvGridColumn.OptionsColumn.AllowFocus = false;
                }
                else
                {
                    gvGridColumn.OptionsColumn.AllowEdit = true;
                    gvGridColumn.OptionsColumn.AllowFocus = true;
                }
            }
        }

        

        private void spinEdit_MouseUp(object sender, MouseEventArgs e)
        {
            SpinEdit _spnEdit = sender as SpinEdit;
            if (_spnEdit != null)
                _spnEdit.SelectAll();
        }

        //protected override WorkShiftsTemplate GetNewInstance()
        //{
        //    return new WorkShiftsTemplate { MachineNom = this.MachineNom, Loaded = true };
        //}

        //protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        //{
        //    return new FxWorkShiftWeekEdit() { OpenMode = openMode };
        //}

        private void _RefreshingData(object sender, EventArgs e)
        {            
            if(WorkShiftsTemplateList?.MachineNom == null)
                return;
            
            using (new EntityChangedLocker(WorkShiftsTemplateList))
            {
                WorkShiftsTemplateList.WorkShiftsTemplates.Clear();


                Expression<Func<WorkShiftType, bool>> crWST = t => t.Division.Id == WorkShiftsTemplateList.MachineNom.Division.Id;
                AttachedList<WorkShiftType> _workShiftTypes = new AttachedList<WorkShiftType>(DataHelper.GetAll(crWST).OrderBy(t => t.OrderNum));

                var existsWST = DataHelper.GetAll<WorkShiftsTemplate>(t =>
                               t.MachineNom.Id == WorkShiftsTemplateList.MachineNom.Id
                           );


                foreach (var wst in _workShiftTypes)
                {
                    WorkShiftsTemplate wstempl = existsWST.FirstOrDefault(t => t.WorkShiftType.Id == wst.Id);
                    if (wstempl == null)
                    {
                        wstempl = new WorkShiftsTemplate() { MachineNom = WorkShiftsTemplateList.MachineNom, WorkShiftType = wst, MachineNomId = WorkShiftsTemplateList.MachineNom.Id, WorkShiftTypeId = wst.Id };
                    }
                    wstempl.WorkShiftsTemplateList = WorkShiftsTemplateList;
                    wstempl.Loaded = true;
                    WorkShiftsTemplateList.WorkShiftsTemplates.Add(wstempl);
                }
            }
            
        }

        

    }
}
