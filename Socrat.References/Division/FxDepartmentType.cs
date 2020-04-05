using System.Drawing;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Division
{
    public partial class FxDepartmentType : FxGenericListTable<DepartmentType>
    {
        public FxDepartmentType()
        {
            InitializeComponent();
            Text = "Справочник отделов";
            Size = new Size(600, 600);
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxDepartmentTypeEdit();
        }

        protected override string GetTitle()
        {
            return "Справочник отделов";
        }
    }
}
