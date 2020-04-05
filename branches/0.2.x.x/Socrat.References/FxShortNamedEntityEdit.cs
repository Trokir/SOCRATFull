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
using Socrat.Lib;
using Socrat.UI.Core;

namespace Socrat.References
{
    public partial class FxShortNamedEntityEdit : FxBaseSimpleDialog
    {
        public IShortNamedEntity ShortNamedEntity { get; set; }

        public FxShortNamedEntityEdit(string entityTypeName)
        {
            InitializeComponent();
            Text = entityTypeName;
        }

        protected override void BindData()
        {
            base.BindData();
            teShortName.DataBindings.Clear();
            teShortName.DataBindings.Add("EditValue", ShortNamedEntity, "ShortName", false, DataSourceUpdateMode.OnPropertyChanged);
            teName.DataBindings.Clear();
            teName.DataBindings.Add("EditValue", ShortNamedEntity, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected override void SetEntity(IEntity value)
        {
            ShortNamedEntity = value as IShortNamedEntity;
        }

        protected override IEntity GetEntity()
        {
            return ShortNamedEntity;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teShortName, teName };
        }
    }
}