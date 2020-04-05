using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Division
{
    public partial class CxDivisionContacts : CxGenericListTable<DivisionContact>
    {
        public Core.Entities.Division Division { get; set; }

        public CxDivisionContacts()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Тип контакта", "ContactTypeTitle", 160, 0);
            AddColumn("Значение", "Value", 160, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxDivisionContactEdit();
        }

        protected override ObservableCollection<DivisionContact> GetItems()
        {
            return Division.DivisionContacts;
        }

        protected override DivisionContact GetNewInstance()
        {
            return new DivisionContact { Division = Division };
        }
    }
}
