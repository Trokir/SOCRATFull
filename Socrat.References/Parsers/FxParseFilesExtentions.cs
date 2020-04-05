using Socrat.Core;
using Socrat.Core.Entities.Parsers;

namespace Socrat.References.Parsers
{
    public partial class FxParseFilesExtentions : FxGenericListTable<ParseFileExtention>
    {
        public FxParseFilesExtentions()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
            AddColumn("Коментарий", "Comment", 300, 1);
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxParseFileExtentionEdit() {OpenMode =  openMode};
        }
    }
}