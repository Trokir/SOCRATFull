using System;

namespace Socrat.References.Customer
{
    public partial class CxCustomerContacts : CxCustomerControl
    {
        public CxCustomerContacts()
        {
            InitializeComponent();

            if (Site != null && Site.DesignMode)
                return;

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            Load += СxCustomerContacts_Load;
        }

        private void СxCustomerContacts_Load(object sender, EventArgs e)
        {

            cxCustomerPersonal.ReadOnly = ReadOnly;
            cxCustomerPersonal.Customer = Customer;
            cxCustomerPersonal.ListChanged += CxCustomerPersonalOnListChanged;

            UpadetLookUpsData();

            BindData();
        }

        private void CxCustomerPersonalOnListChanged(object sender, EventArgs e)
        {
            UpadetLookUpsData();
        }

        private void UpadetLookUpsData()
        {
            /*
            lueManager.Properties.DataSource = null;
            lueManager.Properties.DataSource = Entities.Personals.Where(x => x.Customer.IsOurCompany == true).ToList();

            lueBuhgalter.Properties.DataSource = null;
            lueBuhgalter.Properties.DataSource = Entities.Personals.Where(x => x.Customer.Id == Customer.Id).ToList();

            lueDirector.Properties.DataSource = null;
            lueDirector.Properties.DataSource = Entities.Personals.Where(x => x.Customer.Id == Customer.Id).ToList();
            */
        }

        private void BindData()
        {
            lueManager.DataBindings.Clear();
            //lueManager.DataBindings.Add("EditValue", Customer, "Manager_Id");

            lueDirector.DataBindings.Clear();
            //lueDirector.DataBindings.Add("EditValue", Customer, "Director_Id");

            lueBuhgalter.DataBindings.Clear();
            //lueBuhgalter.DataBindings.Add("EditValue", Customer, "Accountant_Id");

            lcManagerTel.DataBindings.Clear();
            lcManagerTel.DataBindings.Add("Text", Customer, "ManagerPhone");

            lcDirectorTel.DataBindings.Clear();
            lcDirectorTel.DataBindings.Add("Text", Customer, "DirectorPhone");

            lcBuhgalterTel.DataBindings.Clear();
            lcBuhgalterTel.DataBindings.Add("Text", Customer, "AccounterPhone");

            teBuhgalterBase.DataBindings.Clear();
            //teBuhgalterBase.DataBindings.Add("EditValue", Customer, "AccountantNote");

            teDirectorBase.DataBindings.Clear();
            //teDirectorBase.DataBindings.Add("EditValue", Customer, "DirectorNote");
        }
        /*
        private Person GetPersonalFromLookup(LookUpEdit lookUpEdit)
        {
            Person _personal = null;

            if (lookUpEdit.EditValue != null)
            {
                Guid _id;
                if (Guid.TryParse(lookUpEdit.EditValue.ToString(), out _id))
                {
                    _personal = Entities.Personals.FirstOrDefault(x => x.Id == _id);
                }
            }

            return _personal;
        }

        private void lueManager_EditValueChanged(object sender, EventArgs e)
        {
            Person _personal = GetPersonalFromLookup(lueManager);
            if (_personal != null)
            {
                //Customer.Manager = _personal;
                Customer.Manager_Id = _personal.Id;
            }
        }

        private void lueDirector_EditValueChanged(object sender, EventArgs e)
        {
            Person _personal = GetPersonalFromLookup(lueDirector);
            if (_personal != null)
            {
                Customer.Director_Id = _personal.Id;
            }
        }

        private void lueBuhgalter_EditValueChanged(object sender, EventArgs e)
        {
            Person _personal = GetPersonalFromLookup(lueBuhgalter);
            if (_personal != null)
            {
                Customer.Accountant_Id = _personal.Id;
            }
        }
        */
    }
}
