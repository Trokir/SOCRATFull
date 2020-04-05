namespace Socrat.UI.Core.Templates
{
    partial class TxTableList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        protected DevExpress.XtraEditors.SimpleButton btnRefresh;
        protected DevExpress.XtraEditors.SimpleButton btnOpen;
        protected DevExpress.XtraEditors.SimpleButton btnAddItem;
        protected DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.DropDownButton btnActions;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGrid;
        private System.Windows.Forms.ContextMenuStrip cmsGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem biRefresh;
        private DevExpress.XtraBars.BarButtonItem biOpen;
        private DevExpress.XtraBars.BarButtonItem biEdit;
        private DevExpress.XtraBars.BarButtonItem biAddItem;
        private DevExpress.XtraBars.BarButtonItem biDelete;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
