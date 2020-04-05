using Socrat.Services.Price;
using System;
using System.Collections.Generic;
using System.Drawing;
using Socrat.MVC.ViewModels.Price;
using Socrat.Common.Interfaces.MVC;

namespace Socrat.MVC.Views.Price
{
    public class OrderRowSpecicificationView : BaseDialogView
    {
        public OrderRowSpecicificationView(object data, IViewModel viewModel)
            :this()
        {
            Data = data;
            ViewModel = viewModel;
            treeList.DataSource = (viewModel as OrderRowSpecificationTreeListItems).Items;
        }

        #region Local event processing
        private void TreeList_CustomColumnDisplayText(object sender, DevExpress.XtraTreeList.CustomColumnDisplayTextEventArgs e)
        {
            if (double.TryParse(e.Value?.ToString(), out double value))
            {
                if (value == 0)
                    e.DisplayText = string.Empty;
            }
            else if (e.Value?.ToString().Trim() == "x")
            {
                e.DisplayText = string.Empty;
            }
            else if (e.Value?.ToString().Trim() == "=")
            {
                e.DisplayText = string.Empty;
            }
            else if (e.Value?.ToString() == ("0,00 ₽"))
            {
                e.DisplayText = string.Empty;
            }
        }

        private void TreeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (treeList.GetDataRecordByNode(e.Node) is OrderRowSpecificationTreeListItem item)
            {
                if (item.Style == OrderRowSpecificationTreeListItem.RowStyles.Root)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
                else if (item.Style == OrderRowSpecificationTreeListItem.RowStyles.Topic)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    e.Appearance.BackColor = Color.LightGray;
                }
                else if (item.Style == OrderRowSpecificationTreeListItem.RowStyles.SubTopic)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    e.Appearance.BackColor = Color.FromArgb(230, 230, 230);
                }
                else if (item.Style == OrderRowSpecificationTreeListItem.RowStyles.Summary)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    e.Appearance.BackColor = Color.LightSlateGray;
                }
                else if (item.Style == OrderRowSpecificationTreeListItem.RowStyles.Warning)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                else if (item.Style == OrderRowSpecificationTreeListItem.RowStyles.Error)
                {
                    e.Appearance.BackColor = Color.FromArgb(250, 200, 200);
                }

                if (item.PriceValue != 0 && item.QuantityValue != 0 && item.SumValue != 0)
                {
                    if (Math.Round(item.PriceValue * item.QuantityValue, 2) != Math.Round(item.SumValue, 2)
                        && Math.Round(item.PriceValue * item.Factor ?? 1 * item.QuantityValue, 2) != Math.Round(item.SumValue, 2))
                    {
                        e.Appearance.ForeColor = Color.Red;
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    }
                }
            }
        }
        #endregion

        #region Designer code

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraLayout.LayoutControlItem lciMaterialNoms;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;

        public OrderRowSpecicificationView()
        {
            InitializeComponent();
            treeList.NodeCellStyle += TreeList_NodeCellStyle;
            treeList.CustomColumnDisplayText += TreeList_CustomColumnDisplayText;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderRowSpecicificationView));
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciMaterialNoms = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMaterialNoms)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.treeList);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.Root;
            this.lcMain.Size = new System.Drawing.Size(1119, 722);
            this.lcMain.TabIndex = 6;
            this.lcMain.Text = "layoutControl1";
            // 
            // treeList
            // 
            this.treeList.Caption = "Материалы";
            this.treeList.ChildListFieldName = "Items";
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6});
            this.treeList.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList.Location = new System.Drawing.Point(15, 15);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.ReadOnly = true;
            this.treeList.ParentFieldName = "Parent";
            this.treeList.Size = new System.Drawing.Size(1089, 692);
            this.treeList.TabIndex = 4;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = " ";
            this.treeListColumn1.FieldName = "Text";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.ReadOnly = true;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 530;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treeListColumn2.Caption = "Цена ед.изм.";
            this.treeListColumn2.FieldName = "Price";
            this.treeListColumn2.Format.FormatString = "c2";
            this.treeListColumn2.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.ReadOnly = true;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 3;
            this.treeListColumn2.Width = 100;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.Caption = "Кол-во";
            this.treeListColumn3.FieldName = "Quantity";
            this.treeListColumn3.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Right;
            this.treeListColumn3.Format.FormatString = "f3";
            this.treeListColumn3.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.OptionsColumn.ReadOnly = true;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 4;
            this.treeListColumn3.Width = 69;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treeListColumn4.Caption = "Сумма";
            this.treeListColumn4.FieldName = "SumText";
            this.treeListColumn4.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Right;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            this.treeListColumn4.OptionsColumn.ReadOnly = true;
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 5;
            this.treeListColumn4.Width = 155;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn5.Caption = "Коэффициент";
            this.treeListColumn5.FieldName = "FactorText";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 2;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn6.Caption = "Ед.изм";
            this.treeListColumn6.FieldName = "MeasurementUnit";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 1;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciMaterialNoms});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1119, 722);
            this.Root.TextVisible = false;
            // 
            // lciMaterialNoms
            // 
            this.lciMaterialNoms.Control = this.treeList;
            this.lciMaterialNoms.Location = new System.Drawing.Point(0, 0);
            this.lciMaterialNoms.Name = "lciMaterialNoms";
            this.lciMaterialNoms.Size = new System.Drawing.Size(1099, 702);
            this.lciMaterialNoms.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lciMaterialNoms.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciMaterialNoms.TextSize = new System.Drawing.Size(0, 0);
            this.lciMaterialNoms.TextVisible = false;
            // 
            // FxOrderRowSpecView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1119, 759);
            this.Controls.Add(this.lcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxOrderRowSpecView2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Спецификация строки заказа";
            this.Controls.SetChildIndex(this.lcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMaterialNoms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        public void RefreshData(CalculationResult result)
        {
            List<OrderRowSpecificationTreeListItem> items = new List<OrderRowSpecificationTreeListItem>();

            OrderRowSpecificationTreeListItem tliRoot = new OrderRowSpecificationTreeListItem(null, OrderRowSpecificationTreeListItem.Formats.Title, $"{result}", OrderRowSpecificationTreeListItem.RowStyles.Root);

            OrderRowSpecificationTreeListItem tliTopic0 = new OrderRowSpecificationTreeListItem(tliRoot, OrderRowSpecificationTreeListItem.Formats.Money, "Раздел 1. Расчет базовой цены", OrderRowSpecificationTreeListItem.RowStyles.Topic);
            OrderRowSpecificationTreeListItem tliTopicA = new OrderRowSpecificationTreeListItem(tliTopic0, OrderRowSpecificationTreeListItem.Formats.Money, "Раздел А. Основные материалы изделия", OrderRowSpecificationTreeListItem.RowStyles.SubTopic);
            

            OrderRowSpecificationTreeListItem tliTopicB = new OrderRowSpecificationTreeListItem(tliTopic0, OrderRowSpecificationTreeListItem.Formats.FactorTotal, "Раздел B. Фактор геометрии", OrderRowSpecificationTreeListItem.RowStyles.SubTopic);
            OrderRowSpecificationTreeListItem tliTopicC = new OrderRowSpecificationTreeListItem(tliTopic0, OrderRowSpecificationTreeListItem.Formats.Money, "Раздел C. Дополнительные наценки на ед.измерения", OrderRowSpecificationTreeListItem.RowStyles.SubTopic);
            OrderRowSpecificationTreeListItem tliTopicD = new OrderRowSpecificationTreeListItem(null, OrderRowSpecificationTreeListItem.Formats.Money, "Базовая цена", OrderRowSpecificationTreeListItem.RowStyles.Summary);

            OrderRowSpecificationTreeListItem tliTopicE = new OrderRowSpecificationTreeListItem(tliRoot, OrderRowSpecificationTreeListItem.Formats.Money, "Раздел 2. Наценки на изделие", OrderRowSpecificationTreeListItem.RowStyles.Topic);
            OrderRowSpecificationTreeListItem tliTopicF = new OrderRowSpecificationTreeListItem(tliTopicE, OrderRowSpecificationTreeListItem.Formats.FactorTotal, "Раздел F. Сложности", OrderRowSpecificationTreeListItem.RowStyles.SubTopic);
            OrderRowSpecificationTreeListItem tliTopicG = new OrderRowSpecificationTreeListItem(tliTopicE, OrderRowSpecificationTreeListItem.Formats.Money, "Раздел G. Дополнительные наценки на изделие", OrderRowSpecificationTreeListItem.RowStyles.SubTopic);
            OrderRowSpecificationTreeListItem tliTopicAdditionalMaterialsPerItem = new OrderRowSpecificationTreeListItem(tliTopicE, OrderRowSpecificationTreeListItem.Formats.Money, "Раздел H. Дополнительные материалы", OrderRowSpecificationTreeListItem.RowStyles.SubTopic);
            OrderRowSpecificationTreeListItem tliTopicPricePerItem = new OrderRowSpecificationTreeListItem(null, OrderRowSpecificationTreeListItem.Formats.Money, "Итого за изделие", OrderRowSpecificationTreeListItem.RowStyles.Summary);
            OrderRowSpecificationTreeListItem tliTopicPricePerItemRounded = new OrderRowSpecificationTreeListItem(null, OrderRowSpecificationTreeListItem.Formats.Money, "Итого за изделие, с округлением", OrderRowSpecificationTreeListItem.RowStyles.Summary);
            OrderRowSpecificationTreeListItem tliTopicPricePerorderRow = new OrderRowSpecificationTreeListItem(null, OrderRowSpecificationTreeListItem.Formats.Money, "Итого за строку заказа", OrderRowSpecificationTreeListItem.RowStyles.Summary);
            OrderRowSpecificationTreeListItem tliTopicFactor = new OrderRowSpecificationTreeListItem(null, OrderRowSpecificationTreeListItem.Formats.FactorTotal, "Итоговый фактор сложности", OrderRowSpecificationTreeListItem.RowStyles.Summary);

            OrderRowSpecificationTreeListItem tliTopicJ = new OrderRowSpecificationTreeListItem(tliTopicA, OrderRowSpecificationTreeListItem.Formats.Money, "Раздел J. Материалы без цены", OrderRowSpecificationTreeListItem.RowStyles.Warning);
            OrderRowSpecificationTreeListItem tliTopicK = new OrderRowSpecificationTreeListItem(tliTopicA, OrderRowSpecificationTreeListItem.Formats.Money, "Раздел K. Наценки, сложности и операции без цен", OrderRowSpecificationTreeListItem.RowStyles.Warning);

            tliRoot.Items.Add(tliTopic0);
            tliTopic0.Items.Add(tliTopicA);
            tliTopic0.Items.Add(tliTopicC);
            tliTopic0.Items.Add(tliTopicB);
            tliRoot.Items.Add(tliTopicD);
            tliRoot.Items.Add(tliTopicE);
            tliTopicE.Items.Add(tliTopicF);
            tliTopicE.Items.Add(tliTopicG);
            tliTopicE.Items.Add(tliTopicAdditionalMaterialsPerItem);
            tliRoot.Items.Add(tliTopicPricePerItem);
            tliRoot.Items.Add(tliTopicPricePerItemRounded);
            tliRoot.Items.Add(tliTopicPricePerorderRow);
            tliRoot.Items.Add(tliTopicFactor);
            tliRoot.Items.Add(tliTopicJ);
            tliRoot.Items.Add(tliTopicK);
            items.Add(tliRoot);

            result.BaseMaterials.ForEach(replacement =>
                tliTopicA.Items.Add(
                    new OrderRowSpecificationTreeListItem(
                        tliTopicA,
                        OrderRowSpecificationTreeListItem.Formats.Money,
                        $"{replacement}",
                        OrderRowSpecificationTreeListItem.RowStyles.Default,
                        replacement.Price,
                        result.QuantityPerItem,
                        Math.Round(replacement.Price * result.QuantityPerItem, 2),
                        null,
                        $"{replacement.PriceValue?.MeasurementUnit?.ShortName}"
                        )));

            tliTopicA.Price = result.BaseMaterialsPricePerMeasurementUnit;
            tliTopicA.Sum = result.BaseMaterialsPricePerItem;
            tliTopicA.Quantity = result.QuantityPerItem;

            result.PerMeasurementUnitAdditionalValues.ForEach(modificator =>
                tliTopicC.Items.Add(
                    new OrderRowSpecificationTreeListItem(
                        tliTopicA,
                        OrderRowSpecificationTreeListItem.Formats.Money,
                        $"{modificator}",
                        OrderRowSpecificationTreeListItem.RowStyles.Default,
                        modificator.Value,
                        null,
                        modificator.Value
                        )));

            tliTopicC.Price = result.PerMeasurementUnitAdditionalValue;
            tliTopicC.Sum = Math.Round(result.PerMeasurementUnitAdditionalValue * result.QuantityPerItem, 2);
            tliTopicC.Quantity = result.QuantityPerItem;

            result.PerMeasurementUnitFactors.ForEach(modificator =>
                tliTopicB.Items.Add(
                    new OrderRowSpecificationTreeListItem(
                        tliTopicA,
                        OrderRowSpecificationTreeListItem.Formats.Factor,
                        $"{modificator}",
                        OrderRowSpecificationTreeListItem.RowStyles.Default,
                        null,
                        null,
                        null,
                        modificator.Value
                        )));

            tliTopicB.Factor = result.PerMeasurementUnitFactor;


            result.UnpricedReplacements.ForEach(replacement =>
            {
                tliTopicJ.Items.Add(
                    new OrderRowSpecificationTreeListItem(
                        tliTopicJ,
                        OrderRowSpecificationTreeListItem.Formats.Money,
                        $"{replacement}",
                        OrderRowSpecificationTreeListItem.RowStyles.Error,
                        null,
                        null,
                        null,
                        null,
                        $"{replacement.PriceValue?.MeasurementUnit?.ShortName}"
                        ));
            });

            result.UnpricedModificators.ForEach(modificator =>
            {
                tliTopicK.Items.Add(
                    new OrderRowSpecificationTreeListItem(
                        tliTopicK,
                        OrderRowSpecificationTreeListItem.Formats.Factor,
                        $"{modificator}",
                        OrderRowSpecificationTreeListItem.RowStyles.Error,
                        null,
                        null,
                        null
                        ));
            });

            tliTopicD.Price = result.BasePricePerMeasurementItem;
            tliTopicD.Quantity = result.QuantityPerItem;
            tliTopicD.Sum = result.BasePricePerItem;

            result.PerItemFactors.ForEach(modificator =>
            {
                tliTopicF.Items.Add(
                    new OrderRowSpecificationTreeListItem(
                        tliTopicC,
                        OrderRowSpecificationTreeListItem.Formats.Factor,
                        $"{modificator}",
                        OrderRowSpecificationTreeListItem.RowStyles.Default,
                        null,
                        null,
                        null,
                        modificator.Value
                        ));
            });

            tliTopicF.Factor = result.PerItemFactor;

            result.PerItemAdditionalValues.ForEach(modificator =>
            {
                tliTopicG.Items.Add(
                    new OrderRowSpecificationTreeListItem(
                        tliTopicC,
                        OrderRowSpecificationTreeListItem.Formats.Money,
                        $"{modificator}",
                        OrderRowSpecificationTreeListItem.RowStyles.Default,
                        null,
                        null,
                        modificator.Value
                        ));
            });

            result.ComponentMaterials.ForEach(replacement =>
            {
                double quantity = replacement.Quantity != 0 ? replacement.Quantity : result.QuantityPerItem;

                tliTopicAdditionalMaterialsPerItem.Items.Add(
                    new OrderRowSpecificationTreeListItem(
                        tliTopicC,
                        OrderRowSpecificationTreeListItem.Formats.Money,
                        $"{replacement}",
                        OrderRowSpecificationTreeListItem.RowStyles.Default,
                        replacement.Price,
                         quantity,
                        Math.Round(replacement.Price * quantity, 2),
                        null,
                        $"{replacement.PriceValue?.MeasurementUnit?.ShortName}"
                        ));
            });

            tliTopicAdditionalMaterialsPerItem.Price = result.AdditionalMaterialsPricePerMeasurementUnit;
            tliTopicAdditionalMaterialsPerItem.Quantity = result.QuantityPerItem;
            tliTopicAdditionalMaterialsPerItem.Sum = result.AdditionalMaterialsPricePerItem;

            tliTopicPricePerItem.Price = result.PricePerMeasurementUnit;
            tliTopicPricePerItem.Quantity = result.QuantityPerItem;
            tliTopicPricePerItem.Sum = result.PricePerItem;

            tliTopicPricePerItemRounded.Price = result.RoundedPricePerMeasurementUnit;
            tliTopicPricePerItemRounded.Quantity = result.QuantityPerItem;
            tliTopicPricePerItemRounded.Sum = result.RoundedPricePerItem;

            tliTopicPricePerorderRow.Price = result.RoundedPricePerItem;
            tliTopicPricePerorderRow.Quantity = Math.Round(result.ItemsQuantity);
            tliTopicPricePerorderRow.Sum = Math.Round(result.RoundedPricePerItem * result.ItemsQuantity, result.PricePrecision);

            tliTopicFactor.Factor = Math.Round(result.PerMeasurementUnitFactor * result.PerItemFactor, 3);

            tliTopicG.Sum = result.PerItemAdditionalValue;

            treeList.DataSource = items;
            treeList.ExpandAll();

        }          
        
    }
}
