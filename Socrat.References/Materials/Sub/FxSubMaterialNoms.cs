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
    public partial class FxSubMaterialNoms : FxGenericListTable<SubMaterialNom>
    {
        public MaterialNom MaterialNom { get; set; }
        public FxSubMaterialNoms()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Номинальная номенклатура", "ParMaterialNom", 200, 0);
            AddObjectColumn("Базовая номенклатура", "BaseMaterialNom", 200, 1);
            AddColumn("Обработки", "ProcessingsStr", 260, 2);
            //AddColumn("Кодовое представление", "TechStr", 260, 2);
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxSubNomeclatureEdit { OpenMode = openMode};
        }

        protected override List<SubMaterialNom> GetItems()
        {
            if (MaterialNom != null)
                return MaterialNom.SubMaterialNoms;
            return base.GetItems();
        }

        protected override SubMaterialNom GetNewInstance()
        {
            if (MaterialNom != null)
                return new SubMaterialNom { ParMaterialNom = MaterialNom, Loaded = true};
            return base.GetNewInstance();
        }
    }
}