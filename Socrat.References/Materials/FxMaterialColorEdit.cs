using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Lib;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxMaterialColorEdit : FxBaseSimpleDialog
    {
        public Model.MaterialColor MaterialColor { get; set; }

        public FxMaterialColorEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return MaterialColor;
        }

        protected override void SetEntity(IEntity value)
        {
            MaterialColor = value as Model.MaterialColor;
        }

        private void ceRGB_EditValueChanged(object sender, EventArgs e)
        {
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(ceRGB, MaterialColor, x => x.Color);
            BindEditor(seRGB, MaterialColor, x => x.Color);
            BindEditor(seR, MaterialColor, x => x.R);
            BindEditor(seG, MaterialColor, x => x.G);
            BindEditor(seB, MaterialColor, x => x.B);
            BindEditor(seRGB, MaterialColor, x=> x.RGB);
            BindEditor(seTransparency, MaterialColor, x => x.Transparency);
            BindEditor(teRAL, MaterialColor, x => x.RAL);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>
            {
                ceRGB, seRGB, seR, seG, seB, teRAL, seTransparency
            };
        }
    }
}