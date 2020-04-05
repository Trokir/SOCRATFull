using System;
using System.Collections.Generic;
using System.Linq;
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

        public Filter _Filter = new Filter();
        public LogList _Log = new LogList();

        private void FxLogView_Load(object sender, EventArgs e)
        {
            this.RestoreGridsSettings();

            GetData();
            deStart.EditValue = _Filter.DateFrom;
            deFinish.EditValue = _Filter.DateTo;
            cbMsgType.SelectedIndex = _Filter.MessageType;
        }

        private void GetData()
        {
            _Log.Clear();
            Log.Core.Common.ReadLog(_Filter, _Log);
            gcLog.DataSource = null;
            gcLog.DataSource = _Log.OrderByDescending(x => x.DateT);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void deStart_EditValueChanged(object sender, EventArgs e)
        {
            _Filter.DateFrom = deStart.DateTime;
            GetData();
        }

        private void deFinish_EditValueChanged(object sender, EventArgs e)
        {
            _Filter.DateTo = deFinish.DateTime;
            GetData();
        }

        private void cbMsgType_EditValueChanged(object sender, EventArgs e)
        {
            _Filter.MessageType = cbMsgType.SelectedIndex;
            GetData();
        }

        private void btnRequery_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void FxLogView_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
           this.SaveGridsSettings();
        }

    }
}
