using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;


namespace Socrat.References.Materials
{
    public partial class CxFieldValues : CxGenericListTable<FieldValue>
    {
        public Field Field { get; set; }

        public CxFieldValues()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Значение", x => x.Value, 250, 0);
        }

        protected override ObservableCollection<FieldValue> GetItems()
        {
            return Field?.FieldValues;
        }

        protected override FieldValue GetNewInstance()
        {
            return new FieldValue { Field = this.Field};
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxFieldValueEdit();
        }
    }
}
