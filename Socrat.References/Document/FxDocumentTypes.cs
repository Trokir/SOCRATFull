using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Document
{
    public partial class FxDocumentTypes : FxGenericListTable<DocumentType>
    {
        public FxDocumentTypes()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
            AddColumn("Код", "Code", 160, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxDocumentTypeEdit();
        }

        protected override string GetTitle()
        {
            return "Справочник типов документов";
        }
    }
}