namespace Socrat.UI.Core
{
    partial class CxTableList
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
        private DevExpress.XtraEditors.DropDownButton btnActions;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem biRefresh;
        private DevExpress.XtraBars.BarButtonItem biOpen;
        private DevExpress.XtraBars.BarButtonItem biEdit;
        private DevExpress.XtraBars.BarButtonItem biAddItem;
        private DevExpress.XtraBars.BarButtonItem biDelete;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem biExportToExcel;
        private DevExpress.XtraBars.BarButtonItem biFilterByCellValue;
        private DevExpress.XtraBars.BarButtonItem biResetFilterByCell;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        protected DevExpress.XtraEditors.SimpleButton btnRefresh;
        protected DevExpress.XtraEditors.SimpleButton btnOpen;
        protected DevExpress.XtraEditors.SimpleButton btnAddItem;
        protected DevExpress.XtraEditors.SimpleButton btnRemove;
        protected DevExpress.XtraEditors.SimpleButton btnExcelExport;
        private DevExpress.XtraGrid.GridControl _gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView _gvGrid;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraLayout.LayoutControlItem lciAction;
        private DevExpress.XtraLayout.LayoutControlItem lciTable;
        private DevExpress.XtraLayout.EmptySpaceItem esiAction;
        private DevExpress.XtraLayout.LayoutControlItem lciButtons;
        private DevExpress.XtraEditors.LabelControl lcFooter;
        private DevExpress.XtraLayout.LayoutControlItem lciFooter;
        private DevExpress.XtraEditors.PanelControl pcSelectButton;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectButton;
        private DevExpress.XtraEditors.PanelControl pcActionLabel;
        private DevExpress.XtraEditors.LabelControl lcActionLabel;
        private DevExpress.XtraLayout.LayoutControlItem lciActionLabel;
    }
}
