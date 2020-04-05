using System;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Shape.Factory;
using Socrat.UI.Core;
using System.Windows.Forms;
using System.Linq;

namespace Socrat.Module.Order.Processings
{
    public partial class FxMail : FxBaseSimpleDialog
    {
        public FxMail()
        {
            InitializeComponent();
            Load += FxSideProcessing_Load;
        }



        public EMail EMail { get; set; }
        public OrderRow Row { get; set; }

        private void FxSideProcessing_Load(object sender, EventArgs e)
        {
        }

        protected override void BindData()
        {
            base.BindData();
            //BindEditor(seSequence, EMail, x => x.Body);
        }

        protected override IEntity GetEntity()
        {
            return EMail;
        }

        protected override void SetEntity(IEntity value)
        {
            EMail = value as EMail;
        }
        private void repositoryItemCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            //gvSides.PostEditor();
        }

        public override bool Validate()
        {
            return true;
        }
    }
}