using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.References.Params;
using Socrat.UI.Core;

namespace Socrat.References.Parsers
{
    public partial class FxIndividualParserEdit : FxBaseSimpleDialog
    {
        public Core.Entities.Parsers.Parser Parser { get; set; }

        public FxIndividualParserEdit()
        {
            InitializeComponent();
            Load += FxIndividualParserEdit_Load;
        }

        private void FxIndividualParserEdit_Load(object sender, System.EventArgs e)
        {
            if (!Directory.Exists(GetParserDir()))
                Directory.CreateDirectory(GetParserDir());
            beFile.Text = Parser.DllPath;
            SaveButton.Enabled = true;
        }

        protected override void BindData()
        {
        }

        protected override IEntity GetEntity()
        {
            return Parser;
        }

        protected override void SetEntity(IEntity value)
        {
            Parser = value as Core.Entities.Parsers.Parser;
        }

        public string GetParserDir()
        {
            return Path.Combine(Socrat.Params.AppParams.Params[ParamAlias.ParsersDirectory], Parser.Division.Id.ToString());
        }

        private void beFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            XtraOpenFileDialog _dialog = new XtraOpenFileDialog();
            _dialog.Filter = "*.dll|*.dll";
            _dialog.InitialDirectory = GetParserDir();
            DialogResult _dialogResult = _dialog.ShowDialog(this);

            if (_dialogResult != DialogResult.Cancel)
            {
                string _filePath = _dialog.FileName;
                string _fileTarget = Path.Combine(GetParserDir(), Path.GetFileName(_filePath));
                if (_filePath != _fileTarget)
                {
                    File.Copy(_filePath, _fileTarget);
                }
                beFile.Text = _fileTarget;
                Parser.DllPath = _fileTarget;
            }
        }
    }
}