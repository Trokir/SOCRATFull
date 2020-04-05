using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Document
{
    public partial class FxDocumentSignatureTypes : FxGenericListTable<DocumentSignatureType>
    {
        public FxDocumentSignatureTypes()
        {
            InitializeComponent();

            Text = "Справочник типов подписей";
        }

        protected override void InitColumns()
        {
           AddColumn("Наименование", "Name", 250, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxDocumentSignatureTypeEdit();
        }

        protected override string GetTitle()
        {
            return "Справочник типов подписей";
        }
    }
}