using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.DataProvider;
using Socrat.Lib;
using Socrat.Log;
using Socrat.Model.Users;
using Socrat.UI.Core;

namespace Socrat.Module.Settings
{
    public partial class FxUserEdit : FxBaseSimpleDialog
    {
        private Model.Users.User _user;
        private List<Model.Users.Role> _roles;

        public FxUserEdit()
        {
            InitializeComponent();

            using (EFDataFactory _factory = new EFDataFactory())
            {
                IRepository<Model.Users.Role> _repo = _factory.CreateRepository<IRepository<Model.Users.Role>>();
                _roles = _repo.GetAll().ToList();
            }

            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            lueRole.Properties.DataSource = _roles;
        }

        protected override IEntity GetEntity()
        {
            return _user;
        }

        protected override void SetEntity(IEntity value)
        {
            _user = value as Model.Users.User;
        }

        protected override void BindData()
        {
            base.BindData();

            teSurname.DataBindings.Clear();
            teSurname.DataBindings.Add("EditValue", _user, "Surname", false, DataSourceUpdateMode.OnPropertyChanged);
            teName.DataBindings.Clear();
            teName.DataBindings.Add("EditValue", _user, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            tePatron.DataBindings.Clear();
            tePatron.DataBindings.Add("EditValue", _user, "Patronimyc", false, DataSourceUpdateMode.OnPropertyChanged);
            teDomain.DataBindings.Clear();
            teDomain.DataBindings.Add("EditValue", _user, "Domain", false, DataSourceUpdateMode.OnPropertyChanged);
            teLogin.DataBindings.Clear();
            teLogin.DataBindings.Add("EditValue", _user, "Login", false, DataSourceUpdateMode.OnPropertyChanged);
            teMail.DataBindings.Clear();
            teMail.DataBindings.Add("EditValue", _user, "Mail", false, DataSourceUpdateMode.OnPropertyChanged);

            if (_user.Role != null)
                lueRole.EditValue = _user.Role.Id;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teSurname, teName, tePatron, teDomain, teLogin, teMail };
        }

        private void btnLoadFromAD_Click(object sender, EventArgs e)
        {
            try
            {
                FxADUserList frm = new FxADUserList();
                frm.StartPosition = FormStartPosition.CenterParent;
                DialogResult dlgRes = frm.ShowDialog(this);

                if (dlgRes == DialogResult.OK && frm.SelectedUser != null)
                {
                    _user.Surname = frm.SelectedUser.Surname;
                    _user.Name = frm.SelectedUser.Name;
                    _user.Patronimyc = frm.SelectedUser.Patronimyc;
                    _user.Domain = frm.SelectedUser.Domain;
                    _user.Login = frm.SelectedUser.Login;
                    _user.Mail = frm.SelectedUser.Mail;
                }
            }
            catch (Exception ex)
            {
                Logger.AddErrorMsgEx("tsbAddFromAD", ex);
            }
        }

        private void lueRole_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueRole.EditValue != null && Guid.TryParse(lueRole.EditValue.ToString(), out _id))
            {
                _user.Role = _roles.FirstOrDefault(x => x.Id == _id);
            }
        }
    }
}