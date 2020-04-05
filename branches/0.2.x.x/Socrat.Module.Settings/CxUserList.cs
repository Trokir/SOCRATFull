using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Lib;
using Socrat.Log;
using Socrat.Model.Users;
using Socrat.References;

namespace Socrat.Module.Settings
{
    public partial class CxUserList : CxGenericListTable<Model.Users.User>
    {
        private ObservableCollection<Model.Users.User> _users;

        public CxUserList()
        {
            InitializeComponent();
            Load += CxUserList_Load;
        }

        protected override void InitColumns()
        {
            AddColumn("Фамилия", "Surname", 120, 0);
            AddColumn("Имя", "Name", 120, 1);
            AddColumn("Отчество", "Patronimyc", 120, 2);
            AddColumn("Логин", "Login", 120, 0); 
            AddColumn("Домен", "Domain", 120, 0);
            AddColumn("E-mail", "Mail", 120, 0);
            AddColumn("Роль", "Role", 120, 0);
        }

        private void CxUserList_Load(object sender, EventArgs e)
        {
            _users = new ObservableCollection<User>(Repository.GetAll());
            RefreshData();
        }

        protected override ObservableCollection<User> GetItems()
        {
            return _users;
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxUserEdit();
        }
    }
}
