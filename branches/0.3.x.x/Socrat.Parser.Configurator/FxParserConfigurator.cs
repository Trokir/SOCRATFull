using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using DevExpress.XtraGrid.Views.Grid;
using Socrat.UI.Core;

namespace Socrat.Parser.Configurator
{
    public partial class FxParserConfigurator : FxBaseForm
    {
        private readonly List<object> _resList = new List<object>();
        private List<string> _source = new List<string>();
        private ParserConfig _config;
        private XDocument _xmlDocument;
        private Customer _currentCustomer;

        public FxParserConfigurator()
        {
            InitializeComponent();
        }

        private void biClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void biOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenConfig();
        }

        private void OpenConfig()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.xml|*.xml";
            DialogResult _dialogResult = openFileDialog.ShowDialog(this);
            if (_dialogResult != DialogResult.Cancel)
            {
                Text = $"Конфигуратор [{openFileDialog.FileName}]";

                _xmlDocument = XDocument.Load(openFileDialog.FileName);

                _source.Clear();
                _source = File.ReadAllLines(openFileDialog.FileName, Encoding.Default).ToList();

                XmlSerializer serializer = new XmlSerializer(typeof(ParserConfig));
                serializer.UnknownNode += new
                    XmlNodeEventHandler(serializer_UnknownNode);
                serializer.UnknownAttribute += new
                    XmlAttributeEventHandler(serializer_UnknownAttribute);

                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    _config = (ParserConfig) serializer.Deserialize(fs);
                }

                if (_resList.Count > 0)
                    gridControl.DataSource = _resList;
                else
                    gridControl.DataSource = _config.Customer;

                
            }
        }

        private void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            _resList.Add(new
            {
                msg = $"Нераспарсенные атрибуты: {e.LineNumber}:{e.LinePosition} {e.ExpectedAttributes}",
                src = _source[e.LineNumber]
            });

        }

        private void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            _resList.Add(new
            {
                msg = $"Нераспарсенные узлы: {e.LineNumber}:{e.LinePosition} {e.LocalName} {e.Name}",
                src = _source[e.LineNumber]
            });
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int indx = gridView.GetFocusedDataSourceRowIndex();
            _currentCustomer = _config.Customer[indx];
            XElement _node = _xmlDocument.Root.Elements()
                .FirstOrDefault(x => x.Name == "CUSTOMERS").Elements()
                .FirstOrDefault(x => x.Name == "CUSTOMER" && x.Attributes("UniqueStr").First().Value == _currentCustomer.UniqueStr);
            meXML.Text = _node.ToString();
            gcHeders.DataSource = _currentCustomer.Headers;
            lcTitle.Text = _currentCustomer.UniqueStr;
        }

        private void gvHeaders_MasterRowGetLevelDefaultView(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs e)
        {
            e.DefaultView = gvOperations;
        }

        private void gvHeaders_DoubleClick(object sender, System.EventArgs e)
        {
            int indx = gvHeaders.GetFocusedDataSourceRowIndex();
            HeaderItem _headerItem = _currentCustomer.Headers[indx];

            FxHeaderItemEdit _fx = new FxHeaderItemEdit();
            _fx.HeaderItem = _headerItem;
            _fx.ShowDialog(this);
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
            HeaderItem _headerItem = _currentCustomer.Headers[indx];
            indx = gridView.GetFocusedDataSourceRowIndex();
            ParseItem _parseItem = _headerItem.Parse[indx];

            FxParseItemEdit _fx = new FxParseItemEdit();
            _fx.ParseItem = _parseItem;
            _fx.ShowDialog(this);
        }
    }
}