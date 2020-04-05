using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Lib.Users;
using Socrat.UI.Core;

namespace Socrat.Module.Settings
{
    public partial class FxAdUserList : FxBaseForm
    {
        private ActiveDirectoryWorker _adw = null;

        public FxAdUserList()
        {
            InitializeComponent();

            _adw = new ActiveDirectoryWorker();

            Load += FxADUserList_Load;
        }

        public User SelectedUser { get; set; }

        public List<User> Users { get; set; }

        private void FxADUserList_Load(object sender, System.EventArgs e)
        {
            lueDomain.Properties.DataSource = _adw.Domains;
            lueDomain.Text = _adw.CurrentDomain.FullName;
        }

        private void UpdateGrid()
        {
            gcUsers.DataSource = null;
            gcUsers.DataSource = Users;
        }

        private void lueDomain_EditValueChanged(object sender, System.EventArgs e)
        {
            Users = _adw.GetDomainUsers(lueDomain.EditValue.ToString());
            UpdateGrid();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (gvUsers.FocusedRowHandle > -1)
            {
                SelectedUser = Users[gvUsers.GetFocusedDataSourceRowIndex()];
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                XtraMessageBox.Show("Не выбран пользователь!", "Выбор пользователя", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
