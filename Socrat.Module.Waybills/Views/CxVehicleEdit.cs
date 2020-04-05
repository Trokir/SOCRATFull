using Socrat.Core.Entities.WayBills;
using Socrat.UI.Core;


namespace Socrat.Module.Waybills.Views
{
    public class CxVehicleEdit : TabableUserControl
    {
        public Vehicle Vehicle { get; set; }

        public CxVehicleEdit()
        {
            InitializeComponent();
        }

        protected override void BindingData()
        {
            base.BindingData();
            if (Vehicle != null)
            {
                FxBaseDialog.BindEditor(teName, Vehicle, p => p.Name);
                FxBaseDialog.BindEditor(teNumber, Vehicle, p => p.Number);
            }
        }

        #region Designer code

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit teNumber;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;

        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.teNumber = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.teNumber);
            this.layoutControl1.Controls.Add(this.teName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(225, 109);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(225, 109);
            this.Root.TextVisible = false;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(14, 30);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(197, 20);
            this.teName.StyleController = this.layoutControl1;
            this.teName.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.teName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(205, 44);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "Марка автомобиля";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(95, 13);
            // 
            // teNumber
            // 
            this.teNumber.Location = new System.Drawing.Point(14, 74);
            this.teNumber.Name = "teNumber";
            this.teNumber.Properties.Mask.EditMask = "[АВЕКМНОРСТХУ]ddd[АВЕКМНОРСТХУ]{3}";
            this.teNumber.Size = new System.Drawing.Size(197, 20);
            this.teNumber.StyleController = this.layoutControl1;
            this.teNumber.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.teNumber;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 44);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(205, 45);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "Гос.номер";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(95, 13);
            // 
            // CxVehicleEdit
            // 
            this.Controls.Add(this.layoutControl1);
            this.MinimumSize = new System.Drawing.Size(174, 109);
            this.Name = "CxVehicleEdit";
            this.Size = new System.Drawing.Size(225, 109);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
