using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Socrat.Parser;
using Socrat.UI.Core;

namespace Socrat.References.Parsers
{
    public partial class CxParserConfigurator : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly List<object> _resList = new List<object>();
        private string _source = string.Empty;
        //private RootConfig _config;
        private XDocument _xmlDocument;
        private ParserConfig _currentParserConfig;
        private BodyItem _currentBodyItem;
        private HeaderItem _currentHeaderItem;
        private List<HeaderField> _headerFields;
        private List<BodyField> _bodyFields;

        public Action<FxBaseForm> OnOpenTab { get; set; }

        public ParserConfig CurrentParserConfig
        {
            get { return _currentParserConfig; }
            set { SetCurrentParserConfig(value); }
        }

        private void SetCurrentParserConfig(ParserConfig value)
        {
            _currentParserConfig = value;
            UpdateView();
        }

        //public RootConfig Config
        //{
        //    get { return _config; }
        //    set { _config = value; }
        //}

        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        public List<HeaderField> HeaderFields
        {
            get { return _headerFields; }
            set { _headerFields = value; }
        }

        public List<BodyField> BodyFields
        {
            get { return _bodyFields; }
            set { _bodyFields = value; }
        }

        public CxParserConfigurator()
        {
            InitializeComponent();
        }

        private void UpdateView()
        {
            meXML.Text = Source;
            gcBodyItemDetails.DataSource = null;
            gcBodyItemDetails.DataSource = CurrentParserConfig.Body;
            lcTitle.Text = CurrentParserConfig.UniqueStr;
            LoadHeaderFields();
            LoadBodyFields();
            BindHeaderControls();
            BindBodyControls();
        }

        private void BindBodyControls()
        {
            seFistRowNum.EditValue = CurrentParserConfig.Body.StartLine;
            seRowsPerLine.EditValue = CurrentParserConfig.Body.LinesPerRecord;
            teStopStr.EditValue = CurrentParserConfig.Body.StopLine;
        }

        private void LoadBodyFields()
        {
            tlBodyFields.DataSource = null;
            tlBodyFields.DataSource = BodyFields;
        }

        private void LoadHeaderFields()
        {
            tlHeaderFields.DataSource = null;
            tlHeaderFields.DataSource = HeaderFields;
        }

        private void BindHeaderControls()
        {
            teGPSVersion.DataBindings.Clear();
            if (CurrentParserConfig?.Common == null)
                return;
            teGPSVersion.DataBindings.Add("EditValue", CurrentParserConfig.Common, "GPSVersion", false,
                DataSourceUpdateMode.OnPropertyChanged);
            teItemMinSize.DataBindings.Clear();
            teItemMinSize.DataBindings.Add("EditValue", CurrentParserConfig.Common, "MinSize", false,
                DataSourceUpdateMode.OnPropertyChanged);
            rgXMLSavingType.DataBindings.Clear();
            rgXMLSavingType.DataBindings.Add("EditValue", CurrentParserConfig.Common, "SaveToFormul", true,
                DataSourceUpdateMode.OnPropertyChanged);

        }

        private void gvHeaders_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView master = sender as GridView;
            GridView detail = master.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            detail.DoubleClick += gvOperations_DoubleClick;
        }

        private void gvOperations_DoubleClick(object sender, EventArgs e)
        {
            GridView gridView = sender as GridView;
            int indx = gvHeaders.GetFocusedDataSourceRowIndex();
            HeaderItem _headerItem = CurrentParserConfig.Headers[indx];
            indx = gridView.GetFocusedDataSourceRowIndex();
            ParseItem _parseItem = _headerItem.Parse[indx];

            FxParseItemEdit _fx = new FxParseItemEdit();
            _fx.ParseItem = _parseItem;
            _fx.ShowDialog(this);
        }

        private void gvRows_MasterRowGetLevelDefaultView(object sender, MasterRowGetLevelDefaultViewEventArgs e)
        {
            switch (e.RelationIndex)
            {
                case 0:
                    e.DefaultView = gvRowDetail;
                    break;
                case 1:
                    e.DefaultView = gvRowParse;
                    break;
            }
        }

        private void tlHeaderFields_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            var data = tlHeaderFields.GetDataRecordByNode(e.Node);
            HeaderField _headerField = data as HeaderField;
            if (_headerField == null || CurrentParserConfig == null)
                return;

            _currentHeaderItem = CurrentParserConfig.Headers.FirstOrDefault(x => x.Name == _headerField.Name);
            if (_currentHeaderItem == null)
                return;

            BindHeaderFieldSettings(_currentHeaderItem);
        }

        private void BindHeaderFieldSettings(HeaderItem headerItem)
        {
            cbeFixedValue.DataBindings.Clear();
            cbeFixedValue.DataBindings.Add("EditValue", headerItem, "ConstValue", false,
                DataSourceUpdateMode.OnPropertyChanged);

            seHeaderColumnNum.DataBindings.Clear();
            seHeaderColumnNum.DataBindings.Add("EditValue", headerItem, "CellColumn", false,
                DataSourceUpdateMode.OnPropertyChanged);

            seHeaderRowNum.DataBindings.Clear();
            seHeaderRowNum.DataBindings.Add("EditValue", headerItem, "CellRow", false,
                DataSourceUpdateMode.OnPropertyChanged);

            gcHeders.DataSource = null;
            gcHeders.DataSource = headerItem.Parse;
        }

        private void seFistRowNum_EditValueChanged(object sender, EventArgs e)
        {
            int _tmp = 0;
            if (seFistRowNum.EditValue != null && int.TryParse(seFistRowNum.EditValue.ToString(), out _tmp))
            {
                CurrentParserConfig.Body.StartLine = _tmp;
            }
        }

        private void seRowsPerLine_EditValueChanged(object sender, EventArgs e)
        {
            int _tmp = 0;
            if (seRowsPerLine.EditValue != null && int.TryParse(seRowsPerLine.EditValue.ToString(), out _tmp))
            {
                CurrentParserConfig.Body.LinesPerRecord = _tmp;
            }
        }

        private void teStopStr_EditValueChanged(object sender, EventArgs e)
        {
            if (seRowsPerLine.EditValue != null)
                CurrentParserConfig.Body.StopLine = seRowsPerLine.EditValue.ToString();

        }

        private void tlBodyFields_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            var Data = tlBodyFields.GetDataRecordByNode(e.Node);
            BodyField _bodyField = Data as BodyField;
            if (_bodyField == null)
                return;
            _currentBodyItem = CurrentParserConfig.Body.BodyItems.FirstOrDefault(x => x.Name == _bodyField.Name);
            LoadBodyItem(_currentBodyItem);
        }

        private void LoadBodyItem(BodyItem bodyItem)
        {
            teJoinFormula.EditValue = bodyItem.Details.Formula;

            gcBodyItemDetails.DataSource = null;
            gcBodyItemDetails.DataSource = bodyItem.Details.DetailItems;

            gcBodyItemParseItems.DataSource = null;
            gcBodyItemParseItems.DataSource = bodyItem.Parses;
        }

        private void gcBodyItemParseItems_DoubleClick(object sender, EventArgs e)
        {
            int indx = gvBodyItemParseItems.GetFocusedDataSourceRowIndex();
            if (indx < 0)
                return;

            FxParseItemEdit _fx = new FxParseItemEdit();
            _fx.ParseItem = _currentBodyItem.Parses[indx];
            _fx.StartPosition = FormStartPosition.CenterParent;
            _fx.ShowDialog(this);
        }
        
        private void gvHeaders_DoubleClick(object sender, System.EventArgs e)
        {
            int indx = gvHeaders.GetFocusedDataSourceRowIndex();
            if (indx < 0)
                return;

            FxParseItemEdit _fx = new FxParseItemEdit();
            _fx.ParseItem = _currentHeaderItem.Parse[indx];
            _fx.StartPosition = FormStartPosition.CenterParent;
            _fx.ShowDialog(this);
        }

        private void btnAddHeaderParseItem_Click(object sender, EventArgs e)
        {
            ParseItem parseItem = new ParseItem();
            parseItem.Order = _currentHeaderItem.GetNextNum();
            FxParseItemEdit _fx = new FxParseItemEdit();
            _fx.ParseItem = parseItem;
            if (_fx.ShowDialog(this) != DialogResult.Cancel)
            {
                _currentHeaderItem.Parse.Add(parseItem);
                gvHeaders.RefreshData();
            }
        }

        private void btnDelHeaderParseItem_Click(object sender, EventArgs e)
        {
            ParseItem _parseItem = gvHeaders.GetFocusedRow() as ParseItem;
            if (_parseItem != null)
            {
                DialogResult _dialogResult = XtraMessageBox.Show($"Удалить обработку №{_parseItem.Order}?", "Удаление",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    _currentHeaderItem.Parse.RemoveAll(x => x.Order == _parseItem.Order);
                    _currentHeaderItem.ReorderItems();
                    gvHeaders.RefreshData();
                }
            }
        }

        private void btnAddBobyParser_Click(object sender, EventArgs e)
        {
            ParseItem parseItem = new ParseItem();
            parseItem.Order = _currentBodyItem.GetNextDetailNum();
            FxParseItemEdit _fx = new FxParseItemEdit();
            _fx.ParseItem = parseItem;
            if (_fx.ShowDialog(this) != DialogResult.Cancel)
            {
                _currentBodyItem.Parses.Add(parseItem);
                gvBodyItemParseItems.RefreshData();
            }
        }

        private void btnBobyParserDel_Click(object sender, EventArgs e)
        {
            ParseItem _parseItem = gvBodyItemParseItems.GetFocusedRow() as ParseItem;
            if (_parseItem != null)
            {
                DialogResult _dialogResult = XtraMessageBox.Show($"Удалить обработку №{_parseItem.Order}?", "Удаление",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    _currentBodyItem.Parses.RemoveAll(x => x.Order == _parseItem.Order);
                    _currentBodyItem.ReorderItems();
                    gvHeaders.RefreshData();
                }
            }
        }

        private void btnDeleteBodyDetail_Click(object sender, EventArgs e)
        {
            Detail detail = gvBodyItemDetails.GetFocusedRow() as Detail;
            if (detail != null)
            {
                DialogResult _dialogResult = XtraMessageBox.Show($"Удалить ячейку №{detail.Name}?", "Удаление",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    _currentBodyItem.Details.DetailItems.Remove(detail);
                    _currentBodyItem.Details.ReorderItem();
                }
            }
        }

        private void btnAddBodyDetail_Click(object sender, EventArgs e)
        {
            Detail detail = new Detail();
            detail.Name = _currentBodyItem.GetNextDetailNum().ToString();
            detail.CellColumn = 0;
            detail.DeltaRow = 0;
            detail.LabelString = string.Empty;

            FxDetailEdit _fx = new FxDetailEdit();
            _fx.Detail = detail;
            if (_fx.ShowDialog(this) == DialogResult.OK)
            {
                _currentBodyItem.Details.DetailItems.Add(detail);
                gvRowDetail.RefreshData();
            }
        }

        private void gcBodyItemDetails_DoubleClick(object sender, EventArgs e)
        {
            Detail detail = gvBodyItemDetails.GetFocusedRow() as Detail;
            if (detail != null)
            {
                FxDetailEdit _fx = new FxDetailEdit();
                _fx.Detail = detail;
                if (_fx.ShowDialog(this) == DialogResult.OK)
                {
                    _currentBodyItem.Details.DetailItems.Add(detail);
                    gvRowDetail.RefreshData();
                }
            }
        }

        private void btnTestHederParseItem_Click(object sender, EventArgs e)
        {
            FxParsingTester _fx = new FxParsingTester();
            _fx.ParserItems = _currentHeaderItem.Parse;
            _fx.ShowDialog(this);
        }

        private void OpenTab(FxBaseForm fx)
        {
            OnOpenTab?.Invoke(fx);
        }

        private void btnBodyParsersTest_Click(object sender, EventArgs e)
        {
            FxParsingTester _fx = new FxParsingTester();
            _fx.ParserItems = _currentBodyItem.Parses;
            _fx.ShowDialog(this);
        }
    }
}