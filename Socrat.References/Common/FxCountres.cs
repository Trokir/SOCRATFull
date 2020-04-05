using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Common
{
    public partial class FxCountres : FxGenericListTable<Country>
    {
        public FxCountres()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "AliasName", 200, 0);
            AddColumn("Наименование короткое", "ShortName", 200, 1);
            AddColumn("Наименование полное", "FullName", 200, 2);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxCountryEdit();
        }
    }
}