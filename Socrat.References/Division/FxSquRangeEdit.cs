using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References.Division;
using Socrat.UI.Core;

namespace Socrat.References
{
    public partial class FxSquRangeEdit : FxBaseSimpleDialog
    {
        ButtonEditAssistent<Core.Entities.Division, FxDivisions, FxDivisionEdit> _divisionsButtonEditAssistant;

        public SquRange SquRange { get; set; }

        public FxSquRangeEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return SquRange;
        }

        protected override void SetEntity(IEntity value)
        {
            SquRange = value as SquRange;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName };
        }

        private void FxSquRangeEdit_Load(object sender, System.EventArgs e)
        {
            _divisionsButtonEditAssistant = new ButtonEditAssistent<Core.Entities.Division, FxDivisions, FxDivisionEdit>
                (beDivision, SquRange.Division, OnDialogOutput, eButtonsType.All);
            _divisionsButtonEditAssistant.BindProperty(SquRange, x => x.Division);
            BindEditor(teName, SquRange, x => x.Squ);

            beDivision.Enabled = (SquRange.Division == null);
        }
    }
}