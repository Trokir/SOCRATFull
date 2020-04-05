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
using Socrat.Lib.Commands;
using Socrat.Model.Users;
using Socrat.References;
using Socrat.References.Order;

namespace Socrat.Module.Settings
{
    public partial class CxRoles : CxGenericListTable<Model.Users.Role>
    {
        private ObservableCollection<Model.Users.Role> _roles;

        public CxRoles()
        {
            InitializeComponent();
            Load += CxRoles_Load;
        }

        private void CxRoles_Load(object sender, EventArgs e)
        {
           _roles = new ObservableCollection<Role>(Repository.GetAll());
            RefreshData();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 250, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxNamedEntityEdit("Роль пользователя");
        }

        protected override ObservableCollection<Role> GetItems()
        {
            return _roles;
        }

        protected override void InitCommamds()
        {
            base.InitCommamds();
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Назначить права", SetAccesRights, null)
                { Image = Properties.Resources.editrangepermission_16x16});
        }

        private void SetAccesRights(object obj)
        {
            Guid _id = GetCurrentRowId();
            if (_id != Guid.Empty)
            {
                FxRoleTreeItemGroupEdit _fx = new FxRoleTreeItemGroupEdit();
                _fx.Role = _roles.FirstOrDefault(x => x.Id == _id);
                _fx.ShowDialog(this);
            }
        }
    }
}
