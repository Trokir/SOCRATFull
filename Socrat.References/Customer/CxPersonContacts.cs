using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.Log;

namespace Socrat.References.Customer
{
    /// <summary>
    /// Шаблон табличного списка (справочника)
    /// </summary>
    public partial class CxPersonContacts : CxCustomerTableList
    {

        private Person _personal;
        public Person Personal
        {
            get { return _personal; }
            set { SetPersonal(value); }
        }

        private void SetPersonal(Person value)
        {
            _personal = value;
            if (_personal == null)
                return;
            RefreshData();
        }

        #region Реализация

        protected override void RefreshData()
        {
            if (_personal == null || _personal.Contacts == null)
                return;
            gcGrid.DataSource = null;
            gcGrid.DataSource = _personal.Contacts.ToList();
        }

        protected override void AddItem()
        {
            CustomerContact _contact = new CustomerContact();

            FxPersonContact _fx = new FxPersonContact();
            _fx.Contact = _contact;
            _fx.Customer = Customer;
            _fx.StartPosition = FormStartPosition.CenterParent;
            DialogResult dlgRes = _fx.ShowDialog(this);

            if (dlgRes != DialogResult.Cancel)
            {
                //Entities.PersonalContacts.Add(_contact);
                //Entities.SafetySaveChanges();
                RefreshData();
            }
        }
        protected override void DeleteItem()
        {
            var tmp = gvGrid.GetFocusedRowCellValue("Id");
            if (tmp != null)
            {
                Guid _id;
                if (Guid.TryParse(tmp.ToString(), out _id))
                {
                    CustomerContact _contact = null;// = Entities.PersonalContacts.FirstOrDefault(x => x.Id == _id);
                    if (_contact != null)
                    {
                        DialogResult dlgRes = XtraMessageBox.Show(string.Format("Удалить контакт {0} {1}?", _contact.ContactType.Name,
                            _contact.Value), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dlgRes == DialogResult.Yes)
                        {
                            //Entities.PersonalContacts.Remove(_contact);
                            //Entities.SafetySaveChanges();
                            RefreshData();
                        }
                    }
                }
            }
        }

        protected override void OpenItem()
        {
            var tmp = gvGrid.GetFocusedRowCellValue("Id");
            if (tmp != null)
            {
                Guid _id;
                if (Guid.TryParse(tmp.ToString(), out _id))
                {
                    CustomerContact _contact = null;// = Entities.PersonalContacts.FirstOrDefault(x => x.Id == _id);
                    try
                    {
                        FxPersonContact _fx = new FxPersonContact();
                        _fx.Contact = _contact;
                        //_fx.ContactTypes = Entities.ContactTypes.ToList();
                        //_fx.Ranges = Entities.DateTimeRanges.ToList();
                        _fx.Customer = Customer;
                        _fx.StartPosition = FormStartPosition.CenterParent;
                        DialogResult dlgRes = _fx.ShowDialog(this);

                        if (dlgRes != DialogResult.Cancel)
                        {
                            // if (Entities.ChangeTracker.HasChanges())
                            //     Entities.SafetySaveChanges();
                        }
                        else
                        {
                            //Entities.DiscardEntityChanges(_contact);
                        }

                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        Logger.AddErrorMsgEx("OpenItem", ex);
                    }
                }
            }
        }

        protected override void InitColumns()
        {
            AddColumn("Тип", "ContactType", 120, 0);
            AddColumn("Значение", "ContactValue", 120, 0);
        }

        #endregion

    }
}
