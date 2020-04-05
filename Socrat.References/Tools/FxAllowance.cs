using DevExpress.XtraEditors;
using Socrat.Core.Added;
using Socrat.Core.BL.Planning;
using Socrat.Core.Entities;
using Socrat.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Socrat.References.Tools
{
    public class FxAllowance : FxBaseForm
    {
        public OrderRow OrderRow { get; private set; }
        private MethodInfo CuttingsCalculationMethod;
        private BufferedShape bufferedShape;
        public FxAllowance(OrderRow orderRow)
        {
            InitializeComponent();

            Assembly shapeAssy = Assembly.Load("Socrat.Shape");
            if (shapeAssy?.GetTypes().ToList()
                .Where(type =>
                    type.FullName == "Socrat.Shape.ShapeCutter")
                        .FirstOrDefault() is Type shapeCutter)
            {
                CuttingsCalculationMethod =
                    shapeCutter.GetRuntimeMethods().ToList()
                        .Where(method =>
                            method.Name == "GetCuttersParameters2")
                                .FirstOrDefault();

                if (CuttingsCalculationMethod != null)
                {
                    OrderRow = orderRow;
                    List<CalculationRow> rows1 = new List<CalculationRow>();
                    rows1.Add(new CalculationRow($"{orderRow.Title}", $"Фигура #{ orderRow.Shape.CatalogNumber}", new ShapeParameters(orderRow.Shape.ShapeParam), null));
                    try
                    {
                        List<GlassItem> glasses = OrderRow.Formula.RootItem.GetAllGlasses().OrderBy(x => x.Position).ToList();
                        if (glasses.Count > 0)
                        {
                            glasses.ForEach(glass =>
                            {
                                ShapeParameters shapeParams = null;
                                if (glass.DentExists)
                                    shapeParams = new ShapeParameters(orderRow.Shape.ShapeModifedParam);
                                else
                                    shapeParams = new ShapeParameters(orderRow.Shape.ShapeParam);

                            rows1.Add(new CalculationRow($"Стекло #{glass.Position}", $"{glass}", shapeParams, null));

                                if (glass.FormulaItemProcessings.Count > 0)
                                {
                                    glass.FormulaItemProcessings.ForEach(proc =>
                                    {
                                        if (bufferedShape == null)
                                            bufferedShape = new BufferedShape(OrderRow.Shape, glass.DentExists);

                                        bufferedShape = GetAllowances(OrderRow.Shape, bufferedShape, proc);

                                        rows1.Add(new CalculationRow(string.Empty, proc.ProcessingNom.Processing.Name, new ShapeParameters(bufferedShape, !glass.DentExists), proc));
                                    });
                                    bufferedShape = null;
                                }
                                tlGlasses.DataSource = rows1;
                            });
                        }
                        else
                        {
                            rows1.Add(new CalculationRow("", "Строка заказа не содержит стекол", null, null));
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }

            }
        }      

        private BufferedShape GetAllowances(Shape shape, BufferedShape bufferedShape, FormulaItemProcessing processing)
        {
            if (processing is SideProcessing sideProcessing)
            {
                object[] args = new object[12];
                int outcropSize = processing.ProcessingNom.Processing.OutcropSize ?? 0;
                args[0] = OrderRow.Shape.CatalogNumber.ToString();
                args[1] = (processing.Distance1 ?? 0) == 0 ? (GetSide(sideProcessing.SelectedSides, 1) ? outcropSize : 0) : processing.Distance1;
                args[2] = (processing.Distance2 ?? 0) == 0 ? (GetSide(sideProcessing.SelectedSides, 2) ? outcropSize : 0) : processing.Distance2;
                args[3] = (processing.Distance3 ?? 0) == 0 ? (GetSide(sideProcessing.SelectedSides, 3) ? outcropSize : 0) : processing.Distance3;
                args[4] = (processing.Distance4 ?? 0) == 0 ? (GetSide(sideProcessing.SelectedSides, 4) ? outcropSize : 0) : processing.Distance4;
                args[5] = (processing.Distance5 ?? 0) == 0 ? (GetSide(sideProcessing.SelectedSides, 5) ? outcropSize : 0) : processing.Distance5;
                args[6] = (processing.Distance6 ?? 0) == 0 ? (GetSide(sideProcessing.SelectedSides, 6) ? outcropSize : 0) : processing.Distance6;
                args[7] = (processing.Distance7 ?? 0) == 0 ? (GetSide(sideProcessing.SelectedSides, 7) ? outcropSize : 0) : processing.Distance7;
                args[8] = (processing.Distance8 ?? 0) == 0 ? (GetSide(sideProcessing.SelectedSides, 8) ? outcropSize : 0) : processing.Distance8;
                args[9] = shape;
                args[10] = bufferedShape;
                args[11] = shape.OrderRow.Formula.DentExists;
                if (CuttingsCalculationMethod.Invoke(null, args) is BufferedShape cuttedShape)
                    return cuttedShape;
            }
            return null;
        }

        public bool GetSide(int selectedSides, int sideNum)
        {
            return (selectedSides >> sideNum & 1) == 1;
        }

        #region Designer code

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraTreeList.TreeList tlGlasses;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn10;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn11;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn12;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn13;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn14;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn15;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn16;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn17;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn18;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn19;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn21;
        private DevExpress.XtraLayout.LayoutControlGroup Root;

        public FxAllowance()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxAllowance));
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.tlGlasses = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn10 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn11 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn12 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn13 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn14 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn15 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn16 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn17 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn18 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn19 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn20 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.treeListColumn21 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlGlasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.tlGlasses);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.Root;
            this.lcMain.Size = new System.Drawing.Size(889, 420);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // tlGlasses
            // 
            this.tlGlasses.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tlGlasses.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlGlasses.Appearance.Row.Options.UseTextOptions = true;
            this.tlGlasses.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlGlasses.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6,
            this.treeListColumn7,
            this.treeListColumn8,
            this.treeListColumn9,
            this.treeListColumn10,
            this.treeListColumn11,
            this.treeListColumn1,
            this.treeListColumn12,
            this.treeListColumn13,
            this.treeListColumn14,
            this.treeListColumn15,
            this.treeListColumn16,
            this.treeListColumn17,
            this.treeListColumn18,
            this.treeListColumn19,
            this.treeListColumn20,
            this.treeListColumn21});
            this.tlGlasses.Location = new System.Drawing.Point(12, 12);
            this.tlGlasses.Name = "tlGlasses";
            this.tlGlasses.Size = new System.Drawing.Size(865, 396);
            this.tlGlasses.TabIndex = 4;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = " ";
            this.treeListColumn2.FieldName = "Title";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 138;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "D1";
            this.treeListColumn3.FieldName = "D1";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 3;
            this.treeListColumn3.Width = 33;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "D2";
            this.treeListColumn4.FieldName = "D2";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 4;
            this.treeListColumn4.Width = 33;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "D3";
            this.treeListColumn5.FieldName = "D3";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 5;
            this.treeListColumn5.Width = 33;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "D4";
            this.treeListColumn6.FieldName = "D4";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 6;
            this.treeListColumn6.Width = 33;
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.Caption = "D5";
            this.treeListColumn7.FieldName = "D5";
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 7;
            this.treeListColumn7.Width = 34;
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.Caption = "D6";
            this.treeListColumn8.FieldName = "D6";
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.Visible = true;
            this.treeListColumn8.VisibleIndex = 8;
            this.treeListColumn8.Width = 34;
            // 
            // treeListColumn9
            // 
            this.treeListColumn9.Caption = "D7";
            this.treeListColumn9.FieldName = "D7";
            this.treeListColumn9.Name = "treeListColumn9";
            this.treeListColumn9.Visible = true;
            this.treeListColumn9.VisibleIndex = 9;
            this.treeListColumn9.Width = 34;
            // 
            // treeListColumn10
            // 
            this.treeListColumn10.Caption = "D8";
            this.treeListColumn10.FieldName = "D8";
            this.treeListColumn10.Name = "treeListColumn10";
            this.treeListColumn10.Visible = true;
            this.treeListColumn10.VisibleIndex = 10;
            this.treeListColumn10.Width = 34;
            // 
            // treeListColumn11
            // 
            this.treeListColumn11.Caption = "L";
            this.treeListColumn11.FieldName = "L";
            this.treeListColumn11.Name = "treeListColumn11";
            this.treeListColumn11.Visible = true;
            this.treeListColumn11.VisibleIndex = 11;
            this.treeListColumn11.Width = 30;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "L1";
            this.treeListColumn1.FieldName = "L1";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 12;
            this.treeListColumn1.Width = 29;
            // 
            // treeListColumn12
            // 
            this.treeListColumn12.Caption = "L2";
            this.treeListColumn12.FieldName = "L2";
            this.treeListColumn12.Name = "treeListColumn12";
            this.treeListColumn12.Visible = true;
            this.treeListColumn12.VisibleIndex = 13;
            this.treeListColumn12.Width = 35;
            // 
            // treeListColumn13
            // 
            this.treeListColumn13.Caption = "H";
            this.treeListColumn13.FieldName = "H";
            this.treeListColumn13.Name = "treeListColumn13";
            this.treeListColumn13.Visible = true;
            this.treeListColumn13.VisibleIndex = 14;
            this.treeListColumn13.Width = 23;
            // 
            // treeListColumn14
            // 
            this.treeListColumn14.Caption = "H1";
            this.treeListColumn14.FieldName = "H1";
            this.treeListColumn14.Name = "treeListColumn14";
            this.treeListColumn14.Visible = true;
            this.treeListColumn14.VisibleIndex = 15;
            this.treeListColumn14.Width = 39;
            // 
            // treeListColumn15
            // 
            this.treeListColumn15.Caption = "H2";
            this.treeListColumn15.FieldName = "H2";
            this.treeListColumn15.Name = "treeListColumn15";
            this.treeListColumn15.Visible = true;
            this.treeListColumn15.VisibleIndex = 16;
            this.treeListColumn15.Width = 35;
            // 
            // treeListColumn16
            // 
            this.treeListColumn16.Caption = "R";
            this.treeListColumn16.FieldName = "R";
            this.treeListColumn16.Name = "treeListColumn16";
            this.treeListColumn16.Visible = true;
            this.treeListColumn16.VisibleIndex = 17;
            this.treeListColumn16.Width = 39;
            // 
            // treeListColumn17
            // 
            this.treeListColumn17.Caption = "R1";
            this.treeListColumn17.FieldName = "R1";
            this.treeListColumn17.Name = "treeListColumn17";
            this.treeListColumn17.Visible = true;
            this.treeListColumn17.VisibleIndex = 18;
            this.treeListColumn17.Width = 34;
            // 
            // treeListColumn18
            // 
            this.treeListColumn18.Caption = "R2";
            this.treeListColumn18.FieldName = "R2";
            this.treeListColumn18.Name = "treeListColumn18";
            this.treeListColumn18.Visible = true;
            this.treeListColumn18.VisibleIndex = 19;
            this.treeListColumn18.Width = 22;
            // 
            // treeListColumn19
            // 
            this.treeListColumn19.Caption = "R3";
            this.treeListColumn19.FieldName = "R3";
            this.treeListColumn19.Name = "treeListColumn19";
            this.treeListColumn19.Visible = true;
            this.treeListColumn19.VisibleIndex = 20;
            this.treeListColumn19.Width = 27;
            // 
            // treeListColumn20
            // 
            this.treeListColumn20.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treeListColumn20.Caption = " #";
            this.treeListColumn20.FieldName = "Text";
            this.treeListColumn20.Name = "treeListColumn20";
            this.treeListColumn20.Visible = true;
            this.treeListColumn20.VisibleIndex = 0;
            this.treeListColumn20.Width = 104;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(889, 420);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tlGlasses;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(869, 400);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // treeListColumn21
            // 
            this.treeListColumn21.Caption = "D";
            this.treeListColumn21.FieldName = "DentExists";
            this.treeListColumn21.Name = "treeListColumn21";
            this.treeListColumn21.Visible = true;
            this.treeListColumn21.VisibleIndex = 2;
            this.treeListColumn21.Width = 24;
            // 
            // FxAllowance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(889, 420);
            this.Controls.Add(this.lcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxAllowance";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlGlasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
