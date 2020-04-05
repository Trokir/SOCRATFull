

using Socrat.Core;

namespace Socrat.References.Bank
{
    public partial class FxBanks : FxGenericListTable<Core.Entities.Bank>
    {
        public FxBanks()
        {
            InitializeComponent();

            if (null != Site && Site.DesignMode)
                return;

            Text = "Справочник банков";
        }

        protected override void InitColumns()
        {
            AddColumn("БИК", "Bik", 100, 0);
            AddColumn("Кр. наименование", "Alias", 150, 1);
            AddColumn("Филиал / Отделение", "Filial", 250, 2);
            AddColumn("Кор.счет", "Ks", 150, 3);
            AddColumn("Описание", "Comment", 150, 3);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxBankEdit();
        }

        protected override string GetTitle()
        {
            return "Справочник банков";
        }
    }
}