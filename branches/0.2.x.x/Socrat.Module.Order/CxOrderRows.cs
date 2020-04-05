using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Socrat.DataProvider;
using Socrat.Lib;
using Socrat.Model;
using Socrat.References;
using Socrat.UI.Core;

namespace Socrat.Module.Order
{
    public partial class CxOrderRows : CxTableList
    {
        private Model.Order _order;
        public Model.Order Order
        {
            get => _order;
            set => SetOrder(value);
        }

        private void SetOrder(Model.Order value)
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

        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit _beFormula;

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

            AddColumn("Изделие", "Formula", 100, 5);
            DevExpress.XtraGrid.Columns.GridColumn _column = gvGrid.Columns.Last();
            _beFormula = new RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this._beFormula)).BeginInit();
            _beFormula.AutoHeight = false;
            _beFormula.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] 
                { new DevExpress.XtraEditors.Controls.EditorButton()});
            _beFormula.Name = "beFormula";
            _beFormula.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beFormula_ButtonClick);
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
            FxFormulaEdit _fx = new FxFormulaEdit();
            _fx.Row = Order.OrderRows[gvGrid.GetFocusedDataSourceRowIndex()];
            _fx.DialogOutput += _fx_DialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
            gvGrid.RefreshRow(gvGrid.FocusedRowHandle);
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, DialogOutputType.Dialog);
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
            Model.OrderRow row = new Model.OrderRow {Order = this.Order};
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
            Model.OrderRow row = Order.OrderRows.FirstOrDefault(x => x.Num == _num);
            DialogResult dlgRes = XtraMessageBox.Show(string.Format("Удалить строку {0}?", row.Num), 
                "Удаление", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
            if (dlgRes == DialogResult.Yes)
            {
                Order.DeletedRows.Add(row);
                Order.OrderRows.Remove(row);
                Order.Changed = true;
                RefreshData();
            }
        }

        public new bool Validate()
        {
            return true;
        }
    }
}
