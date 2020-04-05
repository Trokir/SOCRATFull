using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.References.Formula;
using Socrat.References.Params;
using Socrat.UI.Core;

namespace Socrat.Module.Order
{
    public partial class CxOrderRows : CxTableList
    {
        private Core.Entities.Order _order;
        public Core.Entities.Order Order
        {
            get => _order;
            set => SetOrder(value);
        }

        private void SetOrder(Core.Entities.Order value)
        {
            _order = value;
            RefreshData();
        }

        public CxOrderRows()
        {
            InitializeComponent();
            SetEditable(true);
            HideOpenButton();
            HideExportExcelButton();
        }

        private RepositoryItemButtonEdit _beFormula;

        protected override void InitColumns()
        {
            gvGrid.Columns.Clear();
            AddColumn("№", "Num", 40, 0);
            AddColumn("Ширина", "OverallW", FormatType.Numeric, "N0", 70, 1);
            AddColumn("Высота", "OverallH", FormatType.Numeric, "N0", 70, 2);
            AddColumn("S м2", "Square", 50, 3);
            AddColumnSummary("Square", "N2");
            AddColumn("Количество", "Qty", FormatType.Numeric, "N0", 50, 4);
            AddColumnSummary("Qty", "N0");

            AddObjectColumn("Изделие", "FormulaStr", 100, 5);
            DevExpress.XtraGrid.Columns.GridColumn _column = gvGrid.Columns.Last();
            _beFormula = new RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this._beFormula)).BeginInit();
            _beFormula.AutoHeight = false;
            _beFormula.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] 
                { new DevExpress.XtraEditors.Controls.EditorButton()});
            _beFormula.Name = "beFormula";
            _beFormula.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beFormula_ButtonClick);
            _beFormula.Buttons.FirstOrDefault().Kind = ButtonPredefines.Ellipsis;
            gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                    this._beFormula});
            _column.ColumnEdit = _beFormula;
            _column.ColumnEdit.Enter += ColumnEdit_Enter;
            ((System.ComponentModel.ISupportInitialize)(this._beFormula)).EndInit();
            
            AddColumn("Форма", "Fig", 60, 6);
            AddColumn("Сложность", "Sloz", 60, 7);
            AddColumn("Цена", "PriceRatio", FormatType.Numeric, "N2", 60, 8);
            AddColumn("Коэф", "Koef", 60, 9);
            AddColumn("Цена за шт.", "PriceItem", FormatType.Numeric, "N2", 60, 10);
            AddColumn("Сумма", "PriceRow", FormatType.Numeric, "N2", 60, 11);
            AddColumnSummary("PriceRow", "N2");
            AddColumn("Примечание", "Comment", 80, 12);
            AddColumn("Маркировка", "Mark", 100, 13);
            AddColumn("Штрих-код", "Barcode", 100, 14);
        }

        private void ColumnEdit_Enter(object sender, EventArgs e)
        {
            gcGrid.Update();
        }

        private void beFormula_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            gvGrid.PostEditor();
            FxRowFormulaEdit _fxRow = new FxRowFormulaEdit();
            _fxRow.Row = Order.OrderRows[gvGrid.GetFocusedDataSourceRowIndex()];
            if (_fxRow.Row.Formula != null &&_fxRow.Row.Formula.FormulaStr != _fxRow.Row.FormulaStr)
            {
                //if (_fxRow.Row.Formula.Items.Count < 1)
                //    LoadFormulaItems(_fxRow.Row.Formula);
                FormulaParser.Parse(_fxRow.Row.Formula, _fxRow.Row.FormulaStr);
            }
            _fxRow.DialogOutput += _fx_DialogOutput;
            _fxRow.Closed += (o, args) =>
            {
                if (_fxRow.Row.Formula != null)
                    _fxRow.Row.Formula.Changed = _fxRow.FormulaChanged;
            };
            OnDialogOutput(_fxRow, DialogOutputType.Dialog);
            gvGrid.RefreshRow(gvGrid.FocusedRowHandle);
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, ta.OutputType);
            gvGrid.RefreshData();
            gcGrid.Update();
        }

        protected override void RefreshData()
        {
            gcGrid.DataSource = null;
            gcGrid.DataSource = Order?.OrderRows;
            OnRefreshButtonClick();
        }

        protected override void AddItem()
        {
            OrderRow row = 
                new OrderRow
                {
                    Order = this.Order,
                    OverallW = 1000,
                    OverallH = 1000,
                    Qty = 1,
                    Formula = FormulaParser.Parse(AppParams.Params[ParamAlias.DefaultItem])
                };
            row.Num = Order.MaxRowNum + 1;
            Order.OrderRows.Add(row);
            Order.Changed = true;
            gcGrid.DataSource = Order?.OrderRows;
            gvGrid.MoveLast();
        }

        public long GetCurrentRowNum()
        {
            long _id = -1;
            if (gvGrid.GetFocusedRowCellValue("Num") != null)
                long.TryParse(gvGrid.GetFocusedRowCellValue("Num").ToString(), out _id);
            return _id;
        }

        protected override void DeleteItem()
        {
            long _num = GetCurrentRowNum();
            OrderRow row = Order.OrderRows.FirstOrDefault(x => x.Num == _num);
            DialogResult dlgRes = XtraMessageBox.Show(string.Format("Удалить строку {0}?", row.Num), 
                "Удаление", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
            if (dlgRes == DialogResult.Yes)
            {
                Order.OrderRows.Remove(row);
                Order.Changed = true;
                RefreshData();
            }
        }

        public new bool Validate()
        {
            return true;
        }

        protected override void Init()
        {
            base.Init();
            gvGrid.CellValueChanged += GvGrid_CellValueChanged;
        }

        private void GvGrid_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "FormulaStr" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                OrderRow row = Order.OrderRows[gvGrid.GetFocusedDataSourceRowIndex()];
                FormulaParser.Parse(row.Formula, e.Value.ToString());
            }
        }
    }
}
