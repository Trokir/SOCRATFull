using Socrat.Core.Entities.Parsers;
using Socrat.UI.Core;

namespace Socrat.References.Parsers
{
    public partial class FxParsers : FxGenericListTable<Core.Entities.Parsers.Parser>
    {
        public FxParsers()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Площадка", "Division", 120, 0);
            AddColumn("Наименование", "Name", 140, 1);
            AddColumn("Заказчик", "CustomerAlias", 120, 2);
            AddColumn("Коментарий", "Comment", 140, 3);
            AddObjectColumn("Тип файла", "Extention", 40, 4);
            AddColumn("Тип парсера", "ParserType", 80, 5);
        }

        
    }
}