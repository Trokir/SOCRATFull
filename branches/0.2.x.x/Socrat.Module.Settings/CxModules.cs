using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.DataProvider;
using Socrat.Lib;
using Socrat.References;

namespace Socrat.Module.Settings
{
    public partial class CxModules : CxGenericListTable<Model.Users.Module>
    {
        private ObservableCollection<Model.Users.Module> _modules;

        public CxModules()
        {
            InitializeComponent();
            Load += CxModules_Load;
        }

        private void CxModules_Load(object sender, EventArgs e)
        {
            _modules = new ObservableCollection<Model.Users.Module>(Repository.GetAll());
            RefreshData();
        }

        protected override void InitColumns()
        {
            AddColumn("Имя модуля", "Name", 200, 0);
            AddColumn("Заголовок", "Title", 200, 1);
        }

        protected override ObservableCollection<Model.Users.Module> GetItems()
        {
            return _modules;
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxModuleEdit();
        }
    }
}
