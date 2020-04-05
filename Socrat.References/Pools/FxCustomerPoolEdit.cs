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
using Socrat.Core;
using Socrat.Core.Entities.Pools;
using Socrat.UI.Core;

namespace Socrat.References.Pools
{
    public partial class FxCustomerPoolEdit : FxBaseSimpleDialog
    {
        public Pool Pool { get; set; }

        public FxCustomerPoolEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return Pool;
        }

        protected override void SetEntity(IEntity value)
        {
            Pool = value as Pool;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teNum, Pool, x => x.Num);
            BindEditor(teName, Pool, x => x.Name);
            BindEditor(deDate, Pool, x => x.PoolDate);
            BindEditor(teTime, Pool, x => x.PoolTime);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teNum, teName, deDate, teTime};
        }
    }
}