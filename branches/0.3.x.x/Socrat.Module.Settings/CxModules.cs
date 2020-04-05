using System;
using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.DataProvider;
using Socrat.References;

namespace Socrat.Module.Settings
{
    public partial class CxModules : CxGenericListTable<Core.Entities.Module>
    {
        public CxModules()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Имя модуля", "Name", 200, 0);
            AddColumn("Заголовок", "Title", 200, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxModuleEdit();
        }

        protected override Core.Entities.Module GetNewInstance()
        {
            return new Core.Entities.Module();
        }

        protected override ObservableCollection<Core.Entities.Module> GetItems()
        {
            return new ObservableCollection<Core.Entities.Module>(DataHelper.GetAll<Core.Entities.Module>());
        }
    }
}
