using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.DataProcessing;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities.Parsers;
using Socrat.DataProvider;
using Socrat.Parser;
using Socrat.UI.Core;

namespace Socrat.References.Parsers
{
    public partial class FxUniversalParserEditor : FxBaseDialog
    {
        public Core.Entities.Parsers.Parser Parser { get; set; }
        private CxParserConfigurator cxParserConfigurator;

        public FxUniversalParserEditor()
        {
            InitializeComponent();
            Load += FxUniversalParserEditor_Load;
        }

       
        private void FxUniversalParserEditor_Load(object sender, System.EventArgs e)
        {
            InitControls();
            InitParser();
            SaveButton.Enabled = true;
        }

        private void InitParser()
        {
            ParserConfig _parserConfig = null;
            if (string.IsNullOrEmpty(Parser.XMLData))
            {
                _parserConfig = GetDefaultConfig();
                if (_parserConfig != null)
                {
                    _parserConfig.UniqueStr = Parser.Name;
                    _parserConfig.Alias = Parser.CustomerAlias;
                }
            }
            else
            {
                _parserConfig = PraseManager.GetParserConfig(Parser.XMLData);
                if (_parserConfig == null)
                {
                    _parserConfig = GetDefaultConfig();
                    if (_parserConfig != null)
                    {
                        _parserConfig.UniqueStr = Parser.Name;
                        _parserConfig.Alias = Parser.CustomerAlias;
                    }
                }
            }

            if (_parserConfig == null)
            {
                XtraMessageBox.Show(
                    "Необходимо задать настройки парсера по-умолчанию. Обратитесь к администратору программы",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cxParserConfigurator.Source = Parser.XMLData;
            cxParserConfigurator.CurrentParserConfig = _parserConfig;
        }

        private ParserConfig GetDefaultConfig()
        {
            ParserConfig _parserConfig = null;
            using (IRepository<Core.Entities.Parsers.Parser> _repository =
                DataHelper.GetRepository<Core.Entities.Parsers.Parser>())
            {
                var _defaultParser = _repository.GetItem(x => x.Name == "1");
                if (_defaultParser != null)
                {
                    _parserConfig = PraseManager.GetParserConfig(_defaultParser.XMLData);
                }
                else
                {
                    XtraMessageBox.Show(
                        "Необходимо задать настройки парсера по-умолчанию. Обратитесь к администратору программы",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }
            return _parserConfig;
        }

        private void InitControls()
        {
            List<ParseField> _parseFields = DataHelper.GetAll<ParseField>();

            List<HeaderField> _headerFields = new List<HeaderField>();
            HeaderField headerField;
            foreach (ParseField field in _parseFields.Where(x => x.ParseFieldType == ParseFieldType.Header).Distinct().OrderBy(x =>x.Num))
            {
                headerField = new HeaderField
                {
                    Name = field.Name,
                    MaxLength = field.MaxLength.ToString(),
                    Description = field.Description
                };
                if (!_headerFields.Exists(x => x.Name == headerField.Name 
                                               && x.MaxLength == headerField.MaxLength 
                                               && x.Description == headerField.Description))
                _headerFields.Add(headerField);
            }

            List<BodyField> _bodyFields = new List<BodyField>();
            BodyField _bodyField;
            foreach (ParseField field in _parseFields.Where(x => x.ParseFieldType == ParseFieldType.Row).Distinct().OrderBy(x => x.Num))
            {
                _bodyField = new BodyField
                {
                    Name = field.Name,
                    MaxLength = field.MaxLength.ToString(),
                    Description = field.Description
                };
                if (!_bodyFields.Exists(x => x.Name == _bodyField.Name 
                                             && x.MaxLength == _bodyField.MaxLength 
                                             && x.Description == _bodyField.Description))
                _bodyFields.Add(_bodyField);
            }

            cxParserConfigurator = new CxParserConfigurator();
            cxParserConfigurator.HeaderFields = _headerFields;
            cxParserConfigurator.BodyFields = _bodyFields;
            this.Controls.Add(cxParserConfigurator);
            cxParserConfigurator.Dock = DockStyle.Fill;
        }

        protected override void SaveButtonClicked()
        {
            XmlParser<ParserConfig> _xmlParser = new XmlParser<ParserConfig>();
            string _xml = _xmlParser.ToXml(cxParserConfigurator.CurrentParserConfig);

            bool cancel = false;
            if (!_xml.Equals(Parser.XMLData))
            {
                // XXXXX ?????
                //cancel = XtraMessageBox.Show($"Сохранить парсер {Parser.Name}?", "Сохранение",
                //             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
                //if (!cancel)
                    Parser.XMLData = _xml;
            }
            OnSaveButtonClick(ref cancel, true);
            Close();
        }

        public override bool Validate()
        {
            return true;
        }
    }
}