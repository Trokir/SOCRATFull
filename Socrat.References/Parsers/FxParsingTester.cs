using System.Collections.Generic;
using Socrat.Parser;
using Socrat.UI.Core;

namespace Socrat.References.Parsers
{
    public partial class FxParsingTester : FxBaseForm
    {
        public List<ParseItem> ParserItems { get; set; }

        public FxParsingTester()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, System.EventArgs e)
        {
            if (teTestValue.EditValue != null)
            {
                TestParser _testParser = new TestParser();
                _testParser.ParseItems = ParserItems;
                _testParser.Test(teTestValue.Text);

                gridControl.DataSource = null;
                gridControl.DataSource = _testParser.TestResults;
            }
        }
    }
}