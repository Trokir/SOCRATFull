using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Customer
{
    public partial class FxPersonContact : FxBaseForm
    {
        public FxPersonContact()
        {
            InitializeComponent();
            Load += FxPersonContact_Load;
        }

        private void FxPersonContact_Load(object sender, System.EventArgs e)
        {
            lueField.Properties.DataSource = null;
            lueField.Properties.DataSource = _contactTypes;
            lueTemp.Properties.DataSource = null;
            lueTemp.Properties.DataSource = _ranges;

            BindData();
        }

        private void BindData()
        {
            lueField.DataBindings.Clear();
            lueField.DataBindings.Add("EditValue", _contact, "ContactTypeId", true, DataSourceUpdateMode.OnPropertyChanged);
            lueTemp.DataBindings.Clear();
            lueTemp.DataBindings.Add("EditValue", _contact, "DateTimeRangeId", true, DataSourceUpdateMode.OnPropertyChanged);
            teValue.DataBindings.Clear();
            teValue.DataBindings.Add("EditValue", _contact, "ContactValue", true, DataSourceUpdateMode.OnPropertyChanged);
            teComment.DataBindings.Clear();
            teComment.DataBindings.Add("EditValue", _contact, "ContactComment", true, DataSourceUpdateMode.OnPropertyChanged);
            teFrom.DataBindings.Clear();
            teFrom.DataBindings.Add("EditValue", _contact, "TimeStart", true, DataSourceUpdateMode.OnPropertyChanged);
            teTo.DataBindings.Clear();
            teTo.DataBindings.Add("EditValue", _contact, "TimeEnd", true, DataSourceUpdateMode.OnPropertyChanged);

            Text = string.Format("Карточка персоны: {0} [{1}]", "",//_contact.Person.TitleName,
                Customer.FullName);
        }

        private Socrat.Core.Entities.CustomerContact _contact;
        public CustomerContact Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        private List<ContactType> _contactTypes;
        public List<ContactType> ContactTypes
        {
            get { return _contactTypes; }
            set { _contactTypes = value; }
        }

        private List<DateTimeRange> _ranges;
        public List<DateTimeRange> Ranges
        {
            get { return _ranges; }
            set { _ranges = value; }
        }

        public Core.Entities.Customer Customer { get; set; }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void lueTemp_EditValueChanged(object sender, System.EventArgs e)
        {
            if (lueTemp.EditValue != null)
            {
                Guid _id;
                if (Guid.TryParse(lueTemp.EditValue.ToString(), out _id))
                {
                    //DateTimeRange _range = _ranges.FirstOrDefault(x => x.Id == _id);
                    //if (_range != null)
                    //{
                    //    _contact.DateTimeRange_Id = _id;
                    //    _contact.DateTimeRange = _range;
                    //}
                }
            }
        }
    }
}