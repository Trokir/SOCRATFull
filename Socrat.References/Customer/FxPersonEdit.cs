using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Customer
{
    public partial class FxPersonEdit : FxBaseForm, ICustomerControl
    {
        public event EventHandler NeedFocus;

        public FxPersonEdit(Core.Entities.Customer customer, bool readOnly)
        {
            Customer = customer;
            ReadOnly = readOnly;

            InitializeComponent();

            Load += FxPersonEdit_Load;
        }


        private Person _person;
        private bool _readOnly;
        private Core.Entities.Customer _customer;

        public Person Person
        {
            get { return _person; }
            set { SetPersonal(value); }
        }

        private void SetPersonal(Person value)
        {
            _person = value;

            BindData();
            
            cxPersonContacts.Personal = _person;
            cxPersonContacts.ReadOnly = ReadOnly;
            

            Text = string.Format("Карточка персоны: {0} [{1}]", _person.TitleName, ""//_person?.Customer?.Alias
                                );
        }

        public List<Gender> Genders { get; set; }


        private void FxPersonEdit_Load(object sender, System.EventArgs e)
        {
            lueGender.Properties.DataSource = null;
            lueGender.Properties.DataSource = Genders;

            BindData();

            cxPersonContacts.Personal = _person;
            cxPersonContacts.ReadOnly = ReadOnly;
        }

        private void BindData()
        {
            teSurname.DataBindings.Clear();
            teSurname.DataBindings.Add("EditValue", _person, "Surname", true, DataSourceUpdateMode.OnPropertyChanged);
            teName.DataBindings.Clear();
            teName.DataBindings.Add("EditValue", _person, "Alias", true, DataSourceUpdateMode.OnPropertyChanged);
            tePatron.DataBindings.Clear();
            tePatron.DataBindings.Add("EditValue", _person, "Patronymic", true, DataSourceUpdateMode.OnPropertyChanged);
            lueGender.DataBindings.Clear();
            lueGender.DataBindings.Add("EditValue", _person, "GenderId", true, DataSourceUpdateMode.OnPropertyChanged);
        }


        private void lueGender_EditValueChanged(object sender, System.EventArgs e)
        {
            if (lueGender.EditValue != null && lueGender.EditValue != DBNull.Value)
            {
                Guid _id;
                if (Guid.TryParse(lueGender.EditValue.ToString(), out _id))
                {
                    _person.Gender = Genders.FirstOrDefault(x => x.Id == _id);
                }
            }
        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }


        public new bool ReadOnly
        {
            get => _readOnly;
            set => _readOnly = value;
        }

        public Core.Entities.Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }
    }
}