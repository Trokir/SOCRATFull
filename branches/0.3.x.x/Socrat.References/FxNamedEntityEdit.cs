using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Lib;
using Socrat.UI.Core;
using INamedEntity = Socrat.Core.INamedEntity;

namespace Socrat.References
{
    public partial class FxNamedEntityEdit : FxBaseSimpleDialog
    {
        public INamedEntity NamedEntity { get; set; }

        public FxNamedEntityEdit(string entityTypeName)
        {
            InitializeComponent();
            Text = entityTypeName;
        }

        protected override void BindData()
        {
            base.BindData();
            teName.DataBindings.Clear();
            teName.DataBindings.Add("EditValue", NamedEntity, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected override void SetEntity(IEntity value)
        {
            if (!( value is INamedEntity))
                throw new Exception("Редактируемая сущность должна реализовывать INamedEntity");
            NamedEntity = value as INamedEntity;
        }

        protected override IEntity GetEntity()
        {
            return NamedEntity;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName };
        }

        protected override string GetTitle()
        {
            return NamedEntity?.Title;
        }
    }
}