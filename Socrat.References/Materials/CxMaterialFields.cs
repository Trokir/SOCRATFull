using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace Socrat.References.Materials
{
    public partial class CxMaterialFields : CxGenericListTable<MaterialField>
    {
        public Material Material { get; set; }

        public CxMaterialFields()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", x => x.Name, 200, 0);
            AddColumn("Списком", x => x.IsFixed, 50, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxMaterialFieldEdit();
        }

        protected override ObservableCollection<MaterialField> GetItems()
        {
            return Material?.MaterialFields;
        }

        protected override MaterialField GetNewInstance()
        {
            return new MaterialField { Material = this.Material, Field = new Field()};
        }
    }
}
