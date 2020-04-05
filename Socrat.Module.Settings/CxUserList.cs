using System;
using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References;

namespace Socrat.Module.Settings
{
    public partial class CxUserList : CxGenericListTable<User>
    {
        private ObservableCollection<User> _users;

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
