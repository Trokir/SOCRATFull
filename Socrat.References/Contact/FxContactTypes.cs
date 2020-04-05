using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Contact
{
    public partial class FxContactTypes : FxGenericListTable<ContactType>
    {
        public FxContactTypes()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
            AddColumn("Маска ввода (Regexp)", "RegexMask", 200, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxContactTypeEdit();
        }

        protected override string GetTitle()
        {
            return "Типы контактов";
        }
    }
}