using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.Core.Entities.Machines;
using Socrat.Core.Entities.Work;
using Socrat.Core.Helpers;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Statuses
{
    public partial class FxMasterStatusesEdit : FxBaseSimpleDialog
    {
        public MasterStatusesMarks MasterStatusesMarks { get; set; }
        public FxMasterStatusesEdit()
        {
            InitializeComponent();
            Load += OnLoad;

            MasterStatusesMarks = new MasterStatusesMarks {Loaded = true};
            MasterStatusesMarks.Status = DataHelper.GetItem<OrderStatus>(x => x.Enumerator == OrderStatusEnum.Ready);
            MasterStatusesMarks.AssembleTeamNoSet = true;
            MasterStatusesMarks.CutterTeamNoSet = true;
        }

        protected override IEntity GetEntity()
        {
            return MasterStatusesMarks;
        }

        protected override void SetEntity(IEntity value)
        {
            MasterStatusesMarks = value as MasterStatusesMarks;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            deDoneDate.Properties.MinValue = DateTime.Today.AddDays(-2);
            deDoneDate.Properties.MaxValue = DateTime.Today.AddDays(2);
            deDoneDate.DateTime = DateTime.Now;

            lueStatuses.Properties.DataSource = null;
            lueStatuses.Properties.DataSource = DataHelper.GetAll<OrderStatus>()
                .Where(x => x.Enumerator > OrderStatusEnum.Plan && x.Enumerator < OrderStatusEnum.Unload)
                .OrderBy(x => x.Enumerator);

            lueAssembliers.Properties.DataSource = null;
            lueAssembliers.Properties.DataSource = DataHelper.GetAll<Team>().ToList()
                .Where(x => x.TeamType.Enumerator == TeamTypeEnum.Assebliers);

            lueCutters.Properties.DataSource = null;
            lueCutters.Properties.DataSource = DataHelper.GetAll<Team>().ToList()
                .Where(x => x.TeamType.Enumerator == TeamTypeEnum.Cutters);
        }

        protected override void BindData()
        {
            base.BindData();
            BindCheckedButton(btnSet1, MasterStatusesMarks, "SetDoneDate");
            BindCheckedButton(btnReset1, MasterStatusesMarks, "ResetDoneDate");
            BindCheckedButton(btnSkip1, MasterStatusesMarks, "NosetDoneDate");
            BindEditor(deDoneDate, MasterStatusesMarks, x => x.DoneDate);

            BindCheckedButton(btnSetAllCutters, MasterStatusesMarks, "CutterTeamSetAll");
            BindCheckedButton(btnSkipCutters, MasterStatusesMarks, "CutterTeamNoSet");
            BindCheckedButton(btnResetCutters, MasterStatusesMarks, "CutterTeamReset");
            BindCheckedButton(btnAddCutters, MasterStatusesMarks, "CutterTeamSetWhereEmpty");
            BindEditor(lueCutters, MasterStatusesMarks, x => x.CutterTeam);

            BindCheckedButton(btnAllAssembeTeam, MasterStatusesMarks, "AssembleTeamSetAll");
            BindCheckedButton(btnResetAssembleTeam, MasterStatusesMarks, "AssembleTeamReset");
            BindCheckedButton(btnAddAssebleTeam, MasterStatusesMarks, "AssembleTeamSetWhereEmpty");
            BindCheckedButton(btnSkipAssembleTeam, MasterStatusesMarks, "AssembleTeamNoSet");
            BindEditor(lueAssembliers, MasterStatusesMarks, x => x.AssembleTeam);

            BindCheckedButton(btnSetStatus, MasterStatusesMarks, "SetStatus");
            BindCheckedButton(btnSkipStatus, MasterStatusesMarks, "NoSetStatus");
            BindEditor(lueStatuses, MasterStatusesMarks, x => x.Status);

            btnSkipCutters.Checked = true;
            btnSkipAssembleTeam.Checked = true;
        }

        private void BindCheckedButton(CheckButton checkButton, object obj, string propName)
        {
            checkButton.DataBindings.Clear();
            checkButton.DataBindings.Add("Checked", obj, propName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            List<BaseEdit> _baseEdits = new List<BaseEdit>();
            if (MasterStatusesMarks.SetDoneDate)
                _baseEdits.Add(deDoneDate);
            if (MasterStatusesMarks.SetStatus)
                _baseEdits.Add(lueStatuses);
            if (!MasterStatusesMarks.CutterTeamNoSet)
                _baseEdits.Add(lueAssembliers);
            if (!MasterStatusesMarks.AssembleTeamNoSet)
                _baseEdits.Add(lueCutters);
            if (_baseEdits.Count<1)
                _baseEdits = new List<BaseEdit> { deDoneDate, lueAssembliers, lueCutters, lueStatuses};
            return _baseEdits;
        }
    }
}