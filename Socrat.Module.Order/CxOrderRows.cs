using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.DataProvider.Repos;
using Socrat.References.Formula;
using Socrat.References.Order;
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

        private bool _simpleInput;
        /// <summary>
        /// Упрощенный ввод
        /// </summary>
        public bool SimpleInput
        {
            get => _simpleInput;
            set => SetSimpleInput(value);
        }

        private void SetSimpleInput(bool value)
        {
            _simpleInput = value;
            if (_simpleInput)
                SetSimpleInputSetts();
            else
                SetExtendedInputSetts();
        }

        public CxOrderRows()
        {
            InitializeComponent();
            SetEditable(true);
            HideOpenButton();
            HideExportExcelButton();
            gcGrid.EditorKeyUp += GcGrid_EditorKeyUp;
            gvGrid.OptionsNavigation.EnterMoveNextColumn = true;
            gvGrid.ValidatingEditor += GvGrid_ValidatingEditor;
        }

        private PointFloat _lastCell;       
        private void GcGrid_EditorKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    _lastCell = new PointFloat(gvGrid.FocusedColumn.AbsoluteIndex, gvGrid.FocusedRowHandle);
                    break;
                case Keys.Enter:
                    PointFloat _currentPoint = new PointFloat(gvGrid.FocusedColumn.VisibleIndex, gvGrid.FocusedRowHandle);
                    int _maxEditColumn = gvGrid.Columns.Where(x => x.OptionsColumn.AllowEdit).Max(x => x.VisibleIndex);
                    if (_lastCell.Equals(_currentPoint) && _lastCell.Y == (gvGrid.RowCount -1) && _lastCell.X == _maxEditColumn)
                        AddItem();
                    else
                        _lastCell = new PointFloat(gvGrid.FocusedColumn.VisibleIndex, gvGrid.FocusedRowHandle);
                    break;
            }
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
            
            AddColumn("Форма", "ShapeTitle", 60, 6);
            AddColumn("Сложность", "SlozStr", 60, 7);
            AddColumn("Цена", "PriceRatio", FormatType.Numeric, "N2", 60, 8);
            AddColumn("Коэф", "Koef", 60, 9);
            AddColumn("Цена за шт.", "PriceItem", FormatType.Numeric, "N2", 60, 10);
            AddColumn("Сумма", "PriceRow", FormatType.Numeric, "N2", 60, 11);
            AddColumnSummary("PriceRow", "N2");
            AddColumn("Маркировка", "Mark", 100, 12);
            AddColumn("Штрих-код", "Barcode", 100, 13);
            AddColumn("Примечание", "Comment", 80, 14);
            SortByColumn("Num");
            SetSimpleInputSetts();
        }


        private void SetNotEditableColumns(string[] fieldNames)
        {
            foreach (GridColumn gvGridColumn in gvGrid.Columns)
            {
                if (fieldNames.Contains(gvGridColumn.FieldName))
                {
                    gvGridColumn.OptionsColumn.AllowEdit = false;
                    gvGridColumn.OptionsColumn.AllowFocus = false;
                }
                else
                {
                    gvGridColumn.OptionsColumn.AllowEdit = true;
                    gvGridColumn.OptionsColumn.AllowFocus = true;
                }
            }
        }

        private void SetSimpleInputSetts()
        {
            SetNotEditableColumns(new string[] { "Num", "Square", "ShapeTitle", "Sloz", "PriceRatio",
                "Koef", "PriceItem", "PriceRow", "PriceRow", "Comment", "Mark", "Barcode" });
        }

        private void SetExtendedInputSetts()
        {
            SetNotEditableColumns(new string[] { "Num", "Square", "ShapeTitle", "Sloz", "PriceRatio",
                "Koef", "PriceItem", "PriceRow", "PriceRow" });
        }

        private void ColumnEdit_Enter(object sender, EventArgs e)
        {
            gcGrid.Update();
        }


        private bool TestParse(string formula)
        {
            using (Formula testFormula = new Formula())
            {
                if (!FormulaParser.Parse(testFormula, formula))
                    return false;
                if (!testFormula.Valid)
                {
                    XtraMessageBox.Show(
                        $"Формула {formula} введена не полностью или с ошибками. Проверьте правильность ввода.",
                        "Ошибка ввода формулы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                    return true;

            }
            return false;
        }

        private void beFormula_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (!gvGrid.PostEditor())
                return;

            FxRowFormulaEdit _fxRow = new FxRowFormulaEdit();
            _fxRow.Order = Order;
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
            OnDialogOutput(new WindowOutputEventArgs(_fxRow, DialogOutputType.Dialog, null));
            gvGrid.RefreshRow(gvGrid.FocusedRowHandle);
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
            gvGrid.RefreshData();
            gcGrid.Update();
        }

        protected override void RefreshData()
        {
            gcGrid.DataSource = null;
            gcGrid.DataSource = Order?.OrderRows;
            OnRefreshButtonClick();
        }

        //ObjectCopier _copier = new ObjectCopier();
        protected override void AddItem()
        {
            OrderRow row = null;
            if (Order.OrderRows.Count < 1)
            {
                row = 
                new OrderRow
                {
                    Order = this.Order,
                    OverallW = 1000,
                    OverallH = 1000,
                    Qty = 1,
                    Formula = FormulaParser.Parse(AppParams.Params[ParamAlias.DefaultItem])
                };
            }
            else
            {
                OrderRow _lastRow = Order.GetLastRow();
                row =
                    new OrderRow
                    {
                        Order = this.Order,
                        OverallW = _lastRow.OverallW,
                        OverallH = _lastRow.OverallH,
                        Qty = _lastRow.Qty,
                        Formula = FormulaCopier.Copy(_lastRow.Formula), //_lastRow.Formula,//.GetCopy(),//_copier.Clone(_lastRow.Formula),
                        Shape = _lastRow.Shape,
                        ShapeId = _lastRow.ShapeId,
                        Mark = _lastRow.Mark,
                        Barcode = _lastRow.Barcode
                    };

                //if (_lastRow.OrderRowSlozs != null && _lastRow.OrderRowSlozs.Count > 0)
                //{
                //    SlozType _slozType = null;
                //    foreach (var sloz in _lastRow.OrderRowSlozs)
                //    {
                //        _slozType = DataHelper.UnProxy<SlozType>(sloz.SlozType);
                //        if (_slozType != null)
                //            row.AppendSloz(sloz.SlozType);
                //    }
                //}
            }
        

            if (row.Shape == null && row.ShapeId == null)
                using (var _shapeRepo = DataHelper.GetRepository<Core.Entities.Shape>())
                {
                    row.Shape = ((ShapeRepository) _shapeRepo).GetDefaultShape();
                    row.ShapeId = row.Shape.Id;
                }
            
            row.Num = Order.MaxRowNum + 1;
            Order.OrderRows.Add(row);
            Order.Changed = true;
            //Order.OnRowChanged(row);
            gcGrid.DataSource = Order?.OrderRows;
            gvGrid.MoveLast();
            int _c = gvGrid.Columns.Where(x => x.OptionsColumn.AllowEdit).Min(x => x.AbsoluteIndex);
            gvGrid.FocusedColumn = gvGrid.Columns[_c];
            gvGrid.RefreshData();
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
                Order.UpdateNums();
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

        private void GvGrid_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            if (view.FocusedColumn.FieldName == "FormulaStr")

            {
                if (e.Value != null)
                    e.Valid = TestParse(e.Value.ToString());
            }
        }
    }
}
