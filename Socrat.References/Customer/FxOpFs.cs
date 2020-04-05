using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Customer
{
    public partial class FxOpFs : FxGenericListTable<Opf>
    {
        public FxOpFs()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Алиас", "Alias", 200, 0);
            AddColumn("Наименование", "Name", 200, 1);
            AddColumn("Комментарий", "Comment", 200, 2);
            AddColumn("ИП", "IsIP", 30, 3);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxOpfEdit();
        }

        protected override string GetTitle()
        {
            return "Организационно-правовая форма";
        }
    }
}