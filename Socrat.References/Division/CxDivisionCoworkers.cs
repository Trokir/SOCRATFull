using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;


namespace Socrat.References.Division
{
    [System.ComponentModel.DesignerCategory("")]
    public partial class CxDivisionCoworkers : CxGenericListTable<CoworkerPosition>
    {
        public Core.Entities.Division Division { get; set; }

        public CxDivisionCoworkers()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Должность", "WorkPosition", 160, 0);
            AddColumn("Фамилия Имя Отчество", "CoworkerFullName", 160, 0);
            AddColumn("Рабочий телефон", "CoworkerWorkPhone", 160, 0);
            AddColumn("Внутренний телефон", "CoworkerInternalPhone", 160, 0);
            AddColumn("Мобильный телефон", "CoworkerMobilePhone", 160, 0);
            AddColumn("По умолчанию", "Default", 160, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxDivisionCoworkerEdit();
        }

        protected override CoworkerPosition GetNewInstance()
        {
            return new CoworkerPosition() { Division = this.Division};
        }

        protected override ObservableCollection<CoworkerPosition> GetItems()
        {
            return Division.CoworkerPositions;
        }
    }
}
