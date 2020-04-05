using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Document
{
    public partial class FxDocumentTypeEdit : FxBaseSimpleDialog
    {
        public DocumentType DocumentType { get; set; }

        public FxDocumentTypeEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return DocumentType;
        }

        protected override void SetEntity(IEntity value)
        {
            DocumentType = value as DocumentType;
        }

        protected override void BindData()
        {
            base.BindData();
            teName.DataBindings.Clear();
            teName.DataBindings.Add("EditValue", DocumentType, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            teCode.DataBindings.Clear();
            teCode.DataBindings.Add("EditValue", DocumentType, "Code", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName, teCode };
        }
    }
}