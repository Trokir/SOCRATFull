using System;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Division
{
    [System.ComponentModel.DesignerCategory("")]
    public partial class FxCowokers : FxGenericListTable<Coworker>
    {
        public FxCowokers()
        {
            InitializeComponent();
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxCoworkerEdit();
        }

        protected override void InitColumns()
        {
            AddColumn("Фамилия", "LastName", 180, 0);
            AddColumn("Имя", "FirstName", 180, 1);
            AddColumn("Отчество", "MiddleName", 180, 2);
            AddObjectColumn("Производственная площадка", "Division", 180, 3);
            AddObjectColumn("Должность", "CoworkerPosition", 180, 4);
        }

        protected override string GetTitle()
        {
            return "Справочник сотрудников";
        }

        protected override Coworker GetNewInstance()
        {
            return new Coworker
            {
                BirthDay = DateTime.Now.AddYears(-30)
            };
        }
    }
}