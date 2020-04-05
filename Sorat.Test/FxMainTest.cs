using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraEditors;
using Socrat.Parser;
using Socrat.UI.Core;

namespace Sorat.Test
{
    public partial class FxMainTest : FxBaseEditForm
    {
        List<object> _resList = new List<object>();
        List<string> _source = new List<string>();

        public FxMainTest()
        {
            InitializeComponent();

            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            List<string> _list = new List<string> {"1", "2", "3", "4"};
        }

        private void biLoadFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.xml|*.xml";
            DialogResult _dialogResult = openFileDialog.ShowDialog(this);
            if (_dialogResult != DialogResult.Cancel)
            {
                _source.Clear();
                _source = File.ReadAllLines(openFileDialog.FileName, Encoding.Default).ToList();

                XmlSerializer serializer = new XmlSerializer(typeof(ParserConfig));
                serializer.UnknownNode += new
                    XmlNodeEventHandler(serializer_UnknownNode);
                serializer.UnknownAttribute += new
                    XmlAttributeEventHandler(serializer_UnknownAttribute);

                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                ParserConfig _config;
                _config = (ParserConfig)serializer.Deserialize(fs);

                if (_resList.Count > 0)
                    gridControl.DataSource = _resList;
                else
                    gridControl.DataSource = _config.Customer;
            }
        }

        private void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            _resList.Add( new {
                msg = $"Нераспарсенные атрибуты: {e.LineNumber}:{e.LinePosition} {e.ExpectedAttributes}",
                src = _source[e.LineNumber]});

        }

        private void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            _resList.Add(new {
                msg = $"Нераспарсенные узлы: {e.LineNumber}:{e.LinePosition} {e.LocalName} {e.Name}",
                src = _source[e.LineNumber]});
        }
    }
}