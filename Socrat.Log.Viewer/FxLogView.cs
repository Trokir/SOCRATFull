using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Lib.Users;
using Socrat.Log.Models;
using Socrat.UI.Core;

namespace Socrat.Log.Viewer
{
    public partial class FxLogView : FxBaseForm
    {
        public FxLogView()
        {
            InitializeComponent();
            Load += FxLogView_Load;
        }

        public Filter Filter = new Filter();
        public LogList Log = new LogList();

        private void FxLogView_Load(object sender, EventArgs e)
        {
            GetData();
            deStart.EditValue = Filter.DateFrom;
            deFinish.EditValue = Filter.DateTo;
            cbMsgType.SelectedIndex = Filter.MessageType;
        }

        private void GetData()
        {
            Log.Clear();
            Socrat.Log.Core.Common.ReadLog(Filter, Log);
            gcLog.DataSource = null;
            gcLog.DataSource = Log.OrderByDescending(x => x.DateT);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void deStart_EditValueChanged(object sender, EventArgs e)
        {
            Filter.DateFrom = deStart.DateTime;
            GetData();
        }

        private void deFinish_EditValueChanged(object sender, EventArgs e)
        {
            Filter.DateTo = deFinish.DateTime;
            GetData();
        }

        private void cbMsgType_EditValueChanged(object sender, EventArgs e)
        {
            Filter.MessageType = cbMsgType.SelectedIndex;
            GetData();
        }

        private void btnRequery_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void FxLogView_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
        }

        private void gvLog_DoubleClick(object sender, EventArgs e)
        {
            var tmp = gvLog.GetFocusedRowCellValue("Id");
            if (tmp == null)
                return;
            int _i = -1;
            if (!int.TryParse(tmp.ToString(), out _i))
                return;

            FxLogMessageView _fx = new FxLogMessageView();
            _fx.Item = Log.FirstOrDefault(x => x.Id == _i);
            _fx.ShowDialog(this);
        }
    }
}
