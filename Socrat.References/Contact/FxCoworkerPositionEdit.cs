using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References
{
    public partial class FxCoworkerPositionEdit : FxBaseSimpleDialog
    {
        private ButtonEditAssistent<Coworker, Division.FxCowokers, Division.FxCoworkerEdit> _coworkerButtonEditAssistant;
        private ButtonEditAssistent<Core.Entities.Division, Division.FxDivisions, Division.FxDivisionEdit> _divisionButtonEditAssistant;
        private ButtonEditAssistent<WorkPosition, Division.FxWorkPositions, Division.FxWorkPositionEdit> _workPositionButtonEditAssistant;

        public CoworkerPosition CoworkerPosition { get; set; }

        public FxCoworkerPositionEdit()
        {
            InitializeComponent();
        }

        protected override void BindData()
        {
            _coworkerButtonEditAssistant = new ButtonEditAssistent<Coworker, Division.FxCowokers, Division.FxCoworkerEdit>(
                beCoworker, CoworkerPosition.Coworker, OnDialogOutput, eButtonsType.All);
            _coworkerButtonEditAssistant.BindProperty(CoworkerPosition, x => x.Coworker);

            _divisionButtonEditAssistant = new ButtonEditAssistent<Core.Entities.Division, Division.FxDivisions, Division.FxDivisionEdit>(
                beDivision, CoworkerPosition.Division, OnDialogOutput, eButtonsType.All);
            _divisionButtonEditAssistant.BindProperty(CoworkerPosition, x => x.Division);

            _workPositionButtonEditAssistant = new ButtonEditAssistent<WorkPosition, Division.FxWorkPositions, Division.FxWorkPositionEdit>(
                 beWorkPosition, CoworkerPosition.WorkPosition, OnDialogOutput, eButtonsType.All);
            _workPositionButtonEditAssistant.BindProperty(CoworkerPosition, x => x.WorkPosition);
        }

        protected override void SetEntity(IEntity value)
        {
            CoworkerPosition = value as CoworkerPosition;
        }

        protected override IEntity GetEntity()
        {
            return CoworkerPosition;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>
            {
                beCoworker,
                beDivision,
                beWorkPosition
            };
        }
    }
}