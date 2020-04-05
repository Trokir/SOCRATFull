using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Core.Helpers;
using Socrat.References.Materials.Sub;

namespace Socrat.References.Materials
{
    public partial class CxSubMaterialNomProcessing : CxGenericListTable<SubMaterialNomProcessing>
    {
        public SubMaterialNom SubMaterialNom { get; set; }    
        private SequencedCollectionHelper<SubMaterialNomProcessing> _sequencedCollectionHelper;
        public CxSubMaterialNomProcessing()
        {
            InitializeComponent();
            Load += CxSubMaterialNomProcessing_Load;
        }

        private void CxSubMaterialNomProcessing_Load(object sender, EventArgs e)
        {
            _sequencedCollectionHelper = new SequencedCollectionHelper<SubMaterialNomProcessing>(Items);
        }

        protected override void InitColumns()
        {
            AddColumn("№ п/п", "Sequence", 40, 0);
            AddColumn("Операция", "ProcessingNom", 200, 1);
        }

        protected override AttachedList<SubMaterialNomProcessing> GetItems()
        {
            var _list = SubMaterialNom.Processings;
            _list.Sort((x, y) => Comparer<int>.Default.Compare(x.Sequence, y.Sequence));
            return _list;
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxSubMaterialNomProcessingEdit {OpenMode = openMode};
        }

        private short GetNextSequence()
        {
            if (Items.Count >0 )
                return (short)(Items.Max(x => x.Sequence) + 1);
            return 1;
        }

        protected override SubMaterialNomProcessing GetNewInstance()
        {
            return new SubMaterialNomProcessing
            {
                Sequence = GetNextSequence(),
                SubMaterialNom = this.SubMaterialNom,
                Loaded = true
            };
        }
    }
}
