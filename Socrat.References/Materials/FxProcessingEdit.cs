using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxProcessingEdit : FxBaseSimpleDialog
    {
        public Processing Processing { get; set; }
        private List<Material> _materialTypes;

        public FxProcessingEdit()
        {
            InitializeComponent();
            Load += FxProcessingEdit_Load;
        }

        private void FxProcessingEdit_Load(object sender, System.EventArgs e)
        {
            _materialTypes = DataHelper.GetAll<Material>();
            lueMatrialType.Properties.DataSource = _materialTypes;
        }

        protected override IEntity GetEntity()
        {
            return Processing;
        }

        protected override void SetEntity(IEntity value)
        {
            Processing = value as Processing;
        }

        protected override void BindData()
        {
            base.BindData();
          //  BindEditor(lueMatrialType, Processing, x => x.Material.Id);
            BindEditor(teName, Processing, x => x.Name);
           // BindEditor(teCode, Processing, x => x.Code);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { lueMatrialType, teName, teCode };
        }

        private void lueMatrialType_EditValueChanged(object sender, System.EventArgs e)
        {
            Guid _id;
            if (_materialTypes != null && lueMatrialType.EditValue != null &&
                Guid.TryParse(lueMatrialType.EditValue.ToString(), out _id))
            {
               // Processing.Material = _materialTypes.FirstOrDefault(x => x.Id == _id);
            }
        }
    }
}