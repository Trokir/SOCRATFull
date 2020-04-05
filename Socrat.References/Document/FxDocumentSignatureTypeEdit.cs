using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Document
{
    public partial class FxDocumentSignatureTypeEdit : FxBaseSimpleDialog
    {
        public DocumentSignatureType DocumentSignatureType { get; set; }

        public FxDocumentSignatureTypeEdit()
        {
            InitializeComponent();
        }

        protected override void BindData()
        {
            base.BindData();
            teName.DataBindings.Clear();
            teName.DataBindings.Add("EditValue", DocumentSignatureType, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected override void SetEntity(IEntity value)
        {
            DocumentSignatureType = value as DocumentSignatureType;
        }

        protected override IEntity GetEntity()
        {
            return DocumentSignatureType;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName };
        }

        protected override string GetTitle()
        {
            return DocumentSignatureType.Title;
        }
    }
}