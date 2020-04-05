using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class FxMaterialNomDefaults : FxGenericListTable<MaterialNomDefault>
    {
        public FxMaterialNomDefaults()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Номенклатура", "MaterialNom", 200, 0);
            AddObjectColumn("Тип", "MaterialEnum", 200, 1);
            AddColumn("Описание", "Description", 200, 2);
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxMaterialNomDefaultEdit {OpenMode = openMode};
        }
    }
}