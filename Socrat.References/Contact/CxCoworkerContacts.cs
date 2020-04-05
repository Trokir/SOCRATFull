using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Contact
{
    [System.ComponentModel.DesignerCategory("")]
    public partial class CxCoworkerContacts : CxGenericListTable<CoworkerContact>
    {
        private Coworker _coworker;
        public Coworker Coworker
        {
            get { return _coworker; }
            set { _coworker = value; }
        }

        public CxCoworkerContacts()
        {
            InitializeComponent();
        }
        
        protected override void InitColumns()
        {
            AddObjectColumn("Тип контакта", "ContactType", 200, 0);
            AddColumn("Значение", "Value", 200, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxCoworkerContactEdit();
        }

        protected override CoworkerContact GetNewInstance()
        {
            return new CoworkerContact() { Coworker = _coworker };
        }

        protected override ObservableCollection<CoworkerContact> GetItems()
        {
            return _coworker.CoworkerContacts;
        }
    }
}
