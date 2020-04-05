using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Core.Helpers;
using Socrat.References.Materials.Sub;

namespace Socrat.References.Materials
{
    public partial class CxSubMaterialNomProcessingComponent : CxGenericListTable<SubMaterialNomProcessingComponent>
    {
        public SubMaterialNomProcessing SubMaterialNomProcessing { get; set; }
        private SequencedCollectionHelper<SubMaterialNomProcessingComponent> _sequencedCollectionHelper;
        public CxSubMaterialNomProcessingComponent()
        {
            InitializeComponent();
            Load += CxSubMaterialNomProcessingComponent_Load;
        }

        private void CxSubMaterialNomProcessingComponent_Load(object sender, EventArgs e)
        {
            _sequencedCollectionHelper = 
                new SequencedCollectionHelper<SubMaterialNomProcessingComponent>(SubMaterialNomProcessing.Components);
        }

        protected override void InitColumns()
        {
            AddColumn("Последовательность", "Sequence", 40, 0);
            AddObjectColumn("Материал", "MaterialNom", 200, 1);
            AddColumn("Количество", "Qty", 40, 2);
            AddObjectColumn("Ед.изм.", "Measure", 40, 3);
        }

        protected override AttachedList<SubMaterialNomProcessingComponent> GetItems()
        {
            return SubMaterialNomProcessing.Components;
        }

        private short GetNextSequence()
        {
            if (Items.Count > 0)
                return (short)(Items.Max(x => x.Sequence ?? 0) + 1);
            return 1;
        }

        protected override SubMaterialNomProcessingComponent GetNewInstance()
        {
            return new SubMaterialNomProcessingComponent
            {
                Sequence = GetNextSequence(),
                SubMaterialNomProcessing = this.SubMaterialNomProcessing,
                Qty = 0,
                Loaded = true
            };
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxSubMaterialNomProcessingComponentEdit();
        }
    }
}
