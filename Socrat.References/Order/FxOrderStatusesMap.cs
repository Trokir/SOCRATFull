using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Socrat.DataProvider;
using Socrat.Core.Added;
using Socrat.UI.Core;
using OrderStatus = Socrat.Core.Entities.OrderStatus;

namespace Socrat.References.Order
{
    public partial class FxOrderStatusesMap : FxBaseForm
    {
        private List<OrderStatus> _orderStatuses;
        private List<GridColumn> _gridColumns = new List<GridColumn>();
        private new List<dynamic> _data;


        public FxOrderStatusesMap()
        {
            InitializeComponent();
            Load += FxOrderStatusesMap_Load;
        }

        private void FxOrderStatusesMap_Load(object sender, System.EventArgs e)
        {
            _orderStatuses = DataHelper.GetAll<OrderStatus>().OrderBy(x => x.OrderNum).ToList();
            BuildMap();
            BuildSource();
        }

        private void BuildSource()
        {
            _data = new List<dynamic>();
            OrderStatusChangeMap _statusChangeMap;
            for (var i = 0; i < _orderStatuses.Count; i++)
            {
                _statusChangeMap = new OrderStatusChangeMap(_orderStatuses[i]);
                IDictionary<string, object> _item = new ExpandoObject();
                _item["F0"] =  $"{_orderStatuses[i].OrderNum} {_orderStatuses[i].Name}";
                for (int j = 1; j < _orderStatuses.Count + 1; j++)
                {
                    if (i == j-1)
                        _item[$"F{j}"] = -1;
                    else
                        _item[$"F{j}"] = _statusChangeMap.CanChangeToStatusState(_orderStatuses[j-1])
                            ? 1
                            : 0;
                }
                _data.Add(_item);
            }
            gridControl.DataSource = _data;
        }

        private void BuildMap()
        {
            _gridColumns.Clear();
            GridColumn _column;
            for (var i = 0; i < _orderStatuses.Count; i++)
            {
                _column = new DevExpress.XtraGrid.Columns.GridColumn();
                _column.Name = $"C{i + 1}";
                _column.ColumnEdit = ceCellCheck;
                _column.Caption = $"{_orderStatuses[i].OrderNum}\n{_orderStatuses[i].Name}";
                _column.FieldName = $"F{i+1}";
                _column.Width = 80;
                _column.VisibleIndex = i+1;
                _column.AppearanceHeader.BackColor = _orderStatuses[i].GetColor();
                _column.Visible = true;
                _column.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                gridView.Columns.Add(_column);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
           

            SaveChanges();
            Close();
        }

        private void SaveChanges()
        {
            DialogResult _dialogResult = XtraMessageBox.Show("Сохранить сделанные изменения?", "Сохранение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_dialogResult == DialogResult.Yes)
            {
                OrderStatusChangeMap _statusChangeMap;
                for (int i = 0; i < _orderStatuses.Count; i++)
                {
                    _statusChangeMap = new OrderStatusChangeMap(_orderStatuses[i]);
                    for (int j = 1; j < _orderStatuses.Count + 1; j++)
                    {
                        if (i == j -1)
                            continue;
                        IDictionary<string, object> _item = _data[i];
                        int _state = (int)_item[$"F{j}"];
                        bool _tmp = _state == 1;
                        _statusChangeMap.SetStatusState(_orderStatuses[j-1], _tmp);
                    }
                }

                DataHelper.SaveCollection(_orderStatuses);
            }
        }
    }
}