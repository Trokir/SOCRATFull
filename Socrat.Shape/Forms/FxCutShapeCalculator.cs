using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.UI.Core;
using Socrat.Shape.Factory;

namespace Socrat.Shape.Forms
{
    public partial class FxCutShapeCalculator :FxBaseForm
    {
        private readonly CurrentUserShape shape = new CurrentUserShape();
        PictureEdit pkbDraw = new PictureEdit();
        IEnumerable<Core.Entities.Shape> templates = null;
        bool flag = false;
        public FxCutShapeCalculator()
        {
            InitializeComponent();
        }

        private void btnWithOutTooth_Click(object sender, EventArgs e)
        {
            flag = false;
            if (txtShape.Text == "") return;
            txtParameters.Text = string.Empty;
            txtParameters.Text = ShapeCutter.GetWithOutToothParameters(catalogNumber: txtShape.Text,isDent: flag);
        }

        private void btnWithTooth_Click(object sender, EventArgs e)
        {
            flag = true;
            if (txtShape.Text == "") return;
            txtParameters.Text = string.Empty;
            txtParameters.Text = ShapeCutter.GetWithToothParameters(catalogNumber: txtShape.Text, isDent: flag);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            memoEdit1.Text = "";
           memoEdit1.Text = ShapeCutter.GetCuttersParameters(catalogNumber: txtShape.Text,paramtersList:txtParameters.Text,cutInputString:txtSidesCuts.Text, isDent: flag);
        }
    }
}