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
using Socrat.Core.Entities.Work;
using Socrat.References.Division;
using DevExpress.Utils;
using Socrat.DataProvider;

namespace Socrat.References.Work
{
    public partial class FxTeamEdit : FxBaseSimpleDialog
    {
        private ButtonEditAssistent<TeamType, FxTeamTypes, FxTeamTypeEdit> _teamTypeButtonEditAssistent;

        private CxWeeklyWorkShiftsFromTeam _cxWorkShifts; //CxWorkShifts

        public Team Team { get; set; }
        public FxTeamEdit()
        {
            InitializeComponent();

            seNum.Properties.AllowNullInput = DefaultBoolean.True;
            seNum.Properties.NullText = "Не установлено";
            seNum.Properties.MinValue = 0;
            seNum.Properties.MaxValue = decimal.MaxValue;
            this.seNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.seNum_KeyUp);

            Load += FxTeamEdit_Load;
        }

        private void FxTeamEdit_Load(object sender, System.EventArgs e)
        {
            _teamTypeButtonEditAssistent = new ButtonEditAssistent<TeamType, FxTeamTypes, FxTeamTypeEdit>(
                beTeamTypes, Team.TeamType, OnDialogOutput, eButtonsType.Search | eButtonsType.Clear, readOnly: this.ReadOnly); // readOnly: true
            _teamTypeButtonEditAssistent.BindProperty(Team, x => x.TeamType);
            _teamTypeButtonEditAssistent.SelectionChanged += _teamTypeButtonEditAssistent_SelectionChanged;

            InitWorkShifts();
            
        }

        private void _teamTypeButtonEditAssistent_SelectionChanged(object sender, EventArgs e)
        {
            TeamType tt = Team.TeamType;
            DataHelper.ApplyBackReference(tt, tt.Teams, Team);
        }

        private void InitWorkShifts()
        {
            _cxWorkShifts = new CxWeeklyWorkShiftsFromTeam()//    CxWorkShifts()
            {
                Team = Team,
                //DynamicParentEntity = Team,
                DependedSaving = true,
                ReadOnly = this.ReadOnly
            };
            pcWorkShifts.Controls.Add(_cxWorkShifts);
            _cxWorkShifts.Dock = DockStyle.Fill;
            _cxWorkShifts.DialogOutput += (sender, ta) => OnDialogOutput(ta);
            _cxWorkShifts.DeleteItemEvent += _DeleteItemEvent;
        }

        private void _DeleteItemEvent(object sender, ListItemEventArgs e)
        {
            ((IRefreshable)sender)?.RefreshData();
        }

        protected override IEntity GetEntity()
        {
            return Team;
        }

        protected override void SetEntity(IEntity value)
        {
            Team = value as Team;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, Team, x => x.Name);
            BindEditor(seNum, Team, x => x.Num);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName, beTeamTypes };
        }

        private void seNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (seNum.EditValue != null && (decimal)seNum.EditValue == 0)
                    seNum.EditValue = null;
            }
        }
    }
}
