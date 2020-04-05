using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Division
{
    public partial class CxDivisionSignatures : CxGenericListTable<DivisionSignature>
    {
        public Core.Entities.Division Division { get; set; }

        public CxDivisionSignatures()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Юрю лицо", "Customer", 200, 0);
            AddColumn("Документ", "DocumentType", 200, 0);
            AddColumn("Должность", "DocCoworkerPosition", 200, 0);
            AddColumn("ФИО", "Coworker", 200, 0);
        }

        protected override DivisionSignature GetNewInstance()
        {
            return new DivisionSignature
            {
                Division = Division
            };
        }

        protected override ObservableCollection<DivisionSignature> GetItems()
        {
            return Division?.DivisionSignatures;
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxDivisionSignatureEdit();
        }
    }
}
