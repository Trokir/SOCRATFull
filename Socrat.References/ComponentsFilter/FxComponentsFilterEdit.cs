using System;
using DevExpress.Xpo;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{

    public class FxComponentsFilterEdit : FxBaseSimpleDialog
    {
        private DevExpress.XtraLayout.LayoutControl Layout;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Components.CustomerSelector customerSelector;
        private Components.DivisionSelector divisionSelector;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private Components.MaterialNomSelector materialNomSelector1;
        private Components.MaterialSizeTypeSelector materialSizeTypeSelector1;
        private Components.MaterialMarkTypeSelector materialMarkTypeSelector1;
        private Components.MaterialSelector materialSelector1;
        private Components.MaterialTypeSelector materialTypeSelector1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxComponentsFilterEdit));
            this.Layout = new DevExpress.XtraLayout.LayoutControl();
            this.customerSelector = new Socrat.References.Components.CustomerSelector();
            this.divisionSelector = new Socrat.References.Components.DivisionSelector();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.materialTypeSelector1 = new Socrat.References.Components.MaterialTypeSelector();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.materialSelector1 = new Socrat.References.Components.MaterialSelector();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.materialMarkTypeSelector1 = new Socrat.References.Components.MaterialMarkTypeSelector();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.materialSizeTypeSelector1 = new Socrat.References.Components.MaterialSizeTypeSelector();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.materialNomSelector1 = new Socrat.References.Components.MaterialNomSelector();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Layout)).BeginInit();
            this.Layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // Layout
            // 
            this.Layout.Controls.Add(this.materialNomSelector1);
            this.Layout.Controls.Add(this.materialSizeTypeSelector1);
            this.Layout.Controls.Add(this.materialMarkTypeSelector1);
            this.Layout.Controls.Add(this.materialSelector1);
            this.Layout.Controls.Add(this.materialTypeSelector1);
            this.Layout.Controls.Add(this.customerSelector);
            this.Layout.Controls.Add(this.divisionSelector);
            this.Layout.Controls.Add(this.teName);
            this.Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Layout.Location = new System.Drawing.Point(0, 0);
            this.Layout.Name = "Layout";
            this.Layout.Root = this.Root;
            this.Layout.Size = new System.Drawing.Size(615, 619);
            this.Layout.TabIndex = 5;
            this.Layout.Text = "layoutControl1";
            // 
            // customerSelector
            // 
            this.customerSelector.ButtonsType = Socrat.References.eButtonsType.All;
            this.customerSelector.Customer = null;
            this.customerSelector.Entity = null;
            this.customerSelector.Location = new System.Drawing.Point(15, 136);
            this.customerSelector.ModuleId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.customerSelector.Name = "customerSelector";
            this.customerSelector.ReadOnly = false;
            this.customerSelector.SelectorEntity = null;
            this.customerSelector.Size = new System.Drawing.Size(585, 22);
            this.customerSelector.TabIndex = 6;
            this.customerSelector.Title = "";
            this.customerSelector.WindowOutputType = Socrat.Common.UI.DialogOutputType.Dialog;
            // 
            // divisionSelector
            // 
            this.divisionSelector.ButtonsType = Socrat.References.eButtonsType.All;
            this.divisionSelector.Division = null;
            this.divisionSelector.Entity = null;
            this.divisionSelector.Location = new System.Drawing.Point(15, 85);
            this.divisionSelector.ModuleId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.divisionSelector.Name = "divisionSelector";
            this.divisionSelector.ReadOnly = false;
            this.divisionSelector.SelectorEntity = null;
            this.divisionSelector.Size = new System.Drawing.Size(585, 22);
            this.divisionSelector.TabIndex = 5;
            this.divisionSelector.Title = "";
            this.divisionSelector.WindowOutputType = Socrat.Common.UI.DialogOutputType.Dialog;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(15, 34);
            this.teName.MenuManager = this.barManager;
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(585, 22);
            this.teName.StyleController = this.Layout;
            this.teName.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(615, 619);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.teName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(595, 51);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Название";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(199, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 330);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(595, 259);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.divisionSelector;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 51);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(595, 51);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "Для производственной площадки";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(199, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.customerSelector;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 102);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(595, 51);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "Для клиента";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(199, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 589);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(595, 10);
            this.emptySpaceItem2.Text = "emptySpaceItem1";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // materialTypeSelector1
            // 
            this.materialTypeSelector1.ButtonsType = Socrat.References.eButtonsType.All;
            this.materialTypeSelector1.Entity = null;
            this.materialTypeSelector1.Location = new System.Drawing.Point(226, 200);
            this.materialTypeSelector1.MaterialType = null;
            this.materialTypeSelector1.ModuleId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.materialTypeSelector1.Name = "materialTypeSelector1";
            this.materialTypeSelector1.ReadOnly = false;
            this.materialTypeSelector1.SelectorEntity = null;
            this.materialTypeSelector1.Size = new System.Drawing.Size(365, 22);
            this.materialTypeSelector1.TabIndex = 7;
            this.materialTypeSelector1.Title = "";
            this.materialTypeSelector1.WindowOutputType = Socrat.Common.UI.DialogOutputType.Dialog;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.materialTypeSelector1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(571, 26);
            this.layoutControlItem4.Text = "По типу";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(199, 16);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 153);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(595, 177);
            this.layoutControlGroup1.Text = "Фильтровать номенклатуру материалов";
            // 
            // materialSelector1
            // 
            this.materialSelector1.ButtonsType = Socrat.References.eButtonsType.All;
            this.materialSelector1.Entity = null;
            this.materialSelector1.Location = new System.Drawing.Point(226, 226);
            this.materialSelector1.Material = null;
            this.materialSelector1.ModuleId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.materialSelector1.Name = "materialSelector1";
            this.materialSelector1.ReadOnly = false;
            this.materialSelector1.SelectorEntity = null;
            this.materialSelector1.Size = new System.Drawing.Size(365, 22);
            this.materialSelector1.TabIndex = 8;
            this.materialSelector1.Title = "";
            this.materialSelector1.WindowOutputType = Socrat.Common.UI.DialogOutputType.Dialog;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.materialSelector1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(571, 26);
            this.layoutControlItem5.Text = "По группе";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(199, 16);
            // 
            // materialMarkTypeSelector1
            // 
            this.materialMarkTypeSelector1.ButtonsType = Socrat.References.eButtonsType.All;
            this.materialMarkTypeSelector1.Entity = null;
            this.materialMarkTypeSelector1.Location = new System.Drawing.Point(226, 252);
            this.materialMarkTypeSelector1.MaterialMarkType = null;
            this.materialMarkTypeSelector1.ModuleId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.materialMarkTypeSelector1.Name = "materialMarkTypeSelector1";
            this.materialMarkTypeSelector1.ReadOnly = false;
            this.materialMarkTypeSelector1.SelectorEntity = null;
            this.materialMarkTypeSelector1.Size = new System.Drawing.Size(365, 22);
            this.materialMarkTypeSelector1.TabIndex = 9;
            this.materialMarkTypeSelector1.Title = "";
            this.materialMarkTypeSelector1.WindowOutputType = Socrat.Common.UI.DialogOutputType.Dialog;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.materialMarkTypeSelector1;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(571, 26);
            this.layoutControlItem6.Text = "По ГОСТ и назначению";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(199, 16);
            // 
            // materialSizeTypeSelector1
            // 
            this.materialSizeTypeSelector1.ButtonsType = Socrat.References.eButtonsType.All;
            this.materialSizeTypeSelector1.Entity = null;
            this.materialSizeTypeSelector1.Location = new System.Drawing.Point(226, 278);
            this.materialSizeTypeSelector1.MaterialSizeType = null;
            this.materialSizeTypeSelector1.ModuleId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.materialSizeTypeSelector1.Name = "materialSizeTypeSelector1";
            this.materialSizeTypeSelector1.ReadOnly = false;
            this.materialSizeTypeSelector1.SelectorEntity = null;
            this.materialSizeTypeSelector1.Size = new System.Drawing.Size(365, 22);
            this.materialSizeTypeSelector1.TabIndex = 10;
            this.materialSizeTypeSelector1.Title = "";
            this.materialSizeTypeSelector1.WindowOutputType = Socrat.Common.UI.DialogOutputType.Dialog;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.materialSizeTypeSelector1;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(571, 26);
            this.layoutControlItem7.Text = "По типоразмеру";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(199, 16);
            // 
            // materialNomSelector1
            // 
            this.materialNomSelector1.ButtonsType = Socrat.References.eButtonsType.All;
            this.materialNomSelector1.Entity = null;
            this.materialNomSelector1.Location = new System.Drawing.Point(226, 304);
            this.materialNomSelector1.MaterialNom = null;
            this.materialNomSelector1.ModuleId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.materialNomSelector1.Name = "materialNomSelector1";
            this.materialNomSelector1.ReadOnly = false;
            this.materialNomSelector1.SelectorEntity = null;
            this.materialNomSelector1.Size = new System.Drawing.Size(365, 22);
            this.materialNomSelector1.TabIndex = 11;
            this.materialNomSelector1.Title = "";
            this.materialNomSelector1.WindowOutputType = Socrat.Common.UI.DialogOutputType.Dialog;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.materialNomSelector1;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(571, 26);
            this.layoutControlItem8.Text = "По номенклатурной единице";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(199, 16);
            // 
            // FxComponentsFilterEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ButtonsPanelVisible = true;
            this.ClientSize = new System.Drawing.Size(622, 672);
            this.Controls.Add(this.Layout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxComponentsFilterEdit";
            this.Controls.SetChildIndex(this.Layout, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Layout)).EndInit();
            this.Layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

}