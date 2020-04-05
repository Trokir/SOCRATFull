namespace Socrat.UI.Core
{
    partial class CxGenericListTable<T>
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
        private DevExpress.XtraBars.PopupMenu popupMenu;
        protected DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraLayout.LayoutControlItem lciAction;
        private DevExpress.XtraLayout.LayoutControlItem lciTable;
        private DevExpress.XtraLayout.EmptySpaceItem esiAction;
        private DevExpress.XtraLayout.LayoutControlItem lciButtons;
        private DevExpress.XtraLayout.EmptySpaceItem esiSelect;
        private DevExpress.XtraEditors.LabelControl lcFooter;
        private DevExpress.XtraLayout.LayoutControlItem lciFooter;
        private DevExpress.XtraEditors.PanelControl pcSelectButton;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectButton;
        private DevExpress.XtraEditors.PanelControl pcActionLabel;
        private DevExpress.XtraEditors.LabelControl lcActionLabel;
        private DevExpress.XtraLayout.LayoutControlItem lciActionLabel;
        private DevExpress.XtraEditors.PanelControl pcTitle;
        private DevExpress.XtraEditors.PanelControl pcTopControlsContainer;
        private DevExpress.XtraLayout.LayoutControlItem lciTopPane;
        private DevExpress.XtraEditors.GroupControl gcTitle;
        private DevExpress.XtraEditors.PanelControl pcTopActionContainer;
        private DevExpress.XtraEditors.DropDownButton btnActions;
        private DevExpress.XtraLayout.LayoutControlItem lciActionPane;
        private DevExpress.XtraEditors.SimpleButton sbSelect;
        private DevExpress.XtraEditors.SimpleButton sbResetFilter;
    }
}
