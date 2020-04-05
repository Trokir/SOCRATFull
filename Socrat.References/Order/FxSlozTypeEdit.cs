using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.Lib;
using Socrat.UI.Core;

namespace Socrat.References.Order
{
    public partial class FxSlozTypeEdit : FxBaseSimpleDialog
    {
        public SlozType SlozType { get; set; }
        private IDictionary<int, string> _slozEnums;

        public FxSlozTypeEdit()
        {
            InitializeComponent();
            Load += FxSlozTypeEdit_Load;
        }

        private void FxSlozTypeEdit_Load(object sender, System.EventArgs e)
        {
            _slozEnums = EnumHelper<SlozEnum>.GetLookUpSource(true);
            lueEnum.Properties.DataSource = null;
            lueEnum.Properties.DataSource = _slozEnums.OrderBy(x => x.Value);
        }

        protected override IEntity GetEntity()
        {
            return SlozType;
        }

        protected override void SetEntity(IEntity value)
        {
            SlozType = value as SlozType;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, SlozType, x => x.Name);
            BindEditor(teShortName, SlozType, x => x.ShortName);

            lueEnum.EditValue = (int)SlozType.Enumerator;
        }

        private void lueEnum_EditValueChanged(object sender, System.EventArgs e)
        {
            if (lueEnum.EditValue != null)
            {
                int _num = 0;
                if (int.TryParse(lueEnum.EditValue.ToString(), out _num))
                    SlozType.Enumerator = EnumHelper<SlozEnum>.FromNum(_num);
            }
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName, teShortName, lueEnum};
        }
    }
}