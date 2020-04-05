using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.References.Order;
using Socrat.DataProvider;
using DevExpress.XtraBars;

namespace Socrat.References.Statuses
{
    public partial class CxWorkQueuesItemsTree : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler<WorkQueue> WorkQueueChanged;
        public event EventHandler<Core.Entities.Order> SelectedOrderChanged;
        public event EventHandler<IEnumerable<OrderRowItem>> NeedSetStatus;
        public event EventHandler<IEnumerable<OrderRowItem>> NeedSetCutters;
        public event EventHandler<IEnumerable<OrderRowItem>> NeedSetAssembliers;
        public event EventHandler<IEnumerable<OrderRowItem>> NeedSetDateDone;       
        public event EventHandler<IEnumerable<OrderRowItem>> NeedSetDefect;
        public event EventHandler LineSet;

        private WorkQueueAssignment _wqa;

        private WorkQueueSetList _workQueueSets;
        public WorkQueueSetList WorkQueueSets
        {
            get => _workQueueSets;
            set => SetWorkQueueSets(value);
        }

        private void SetWorkQueueSets(WorkQueueSetList value)
        {
            _workQueueSets = value;
            UpdateView();
        }

        private void UpdateView()
        {
            tlTree.DataSource = null;
            tlTree.DataSource = WorkQueueSets.WorkItems;
        }

        public CxWorkQueuesItemsTree()
        {
            InitializeComponent();
            Load += CxWorkQueuesItemsTree_Load;            
        }

        private void CxWorkQueuesItemsTree_Load(object sender, EventArgs e)
        {            
            _wqa = DataHelper.GetItem<WorkQueueAssignment>(t => t.Division.Id == Constants.CurrentDivision.Id
                                                                && (t.Disabled == null || t.Disabled == false) && t.Name == "Сборка");

            rideDone.MinValue = DateTime.Today.AddDays(-7);
            rideDone.MaxValue = DateTime.Today.AddDays(1).AddSeconds(-1);

            bsiSetLine.GetItemData += BsiSetLine_GetItemData;
        }

        private void BsiSetLine_GetItemData(object sender, EventArgs e)
        {
            List<Core.Entities.Machines.MachineNom> machines = DataHelper.GetAll<Core.Entities.Machines.MachineNom>
                (t =>
                    t.Division.Id == Constants.CurrentDivision.Id
                    && t.VendorMachineNom.MachineType.WorkQueueAssignment != null
                    && t.VendorMachineNom.MachineType.WorkQueueAssignment.Id == _wqa.Id
                  )
                  //.Where(m => m.WorkShifts.Count(ws => ws.WorkDate >= onDate && ws.WorkDate < nextDate && ws.ShiftDuration > 0) > 0)
                  .OrderBy(m => m.AliasName)
                  .ToList();



            bsiSetLine.ClearLinks();
            foreach (var m in machines)
            {
                BarButtonItem biM = new BarButtonItem(this.barManager, m.AliasName);
                biM.Tag = m;
                biM.ItemClick += biM_ItemClick;
                bsiSetLine.AddItem(biM);
            }
        }

        private void biM_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selected = GetSelectedItems();
            var ques = selected.Select(x => x?.OrderRow?.Order?.WorkQueue).Distinct();
          
            if ( ques == null ||  ques.Count() == 0)
            {
                XtraMessageBox.Show("Не выбраны очереди", "Установка оборудования", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            
            Core.Entities.Machines.MachineNom machine = e.Item.Tag as Core.Entities.Machines.MachineNom;
            if (machine != null)
            {  
                var repo = DataHelper.GetRepository<WorkQueue>();
                foreach (WorkQueue workQueue in ques)
                {
                    workQueue.MachineNom = machine;
                }

                repo.Save2(ques, null);     
                
                ClearSelection();

                LineSet?.Invoke(this, EventArgs.Empty);
            }
        }

        private TreeListNode _displayedNode = null;
        private void tlTree_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            var _data = tlTree.GetDataRecordByNode(e.Node);

            if (_data is WorkQueueSet || _data is WorkQueue || _data is Socrat.Core.Entities.Order || _data is OrderRow)
                e.Node.ChildrenCheckBoxStyle = NodeCheckBoxStyle.Check;
            else
                e.Node.ChildrenCheckBoxStyle = NodeCheckBoxStyle.None;
            _displayedNode = e.Node;
        }

        private void SetCheckedChildNodes(TreeListNodes nodes, bool state)
        {
            foreach (TreeListNode node in nodes)
            {
                node.Checked = state;
                SetCheckedChildNodes(node.Nodes, state);
            }
        }

        private void tlTree_AfterCheckNode(object sender, NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node.Nodes, e.Node.Checked);
        }

        private void tlTree_AfterExpand(object sender, NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node.Nodes, e.Node.Checked);
        }

        public List<OrderRowItem> GetSelectedItems()
        {
            List<OrderRowItem> _items = new AttachedList<OrderRowItem>();

            foreach (TreeListNode node in tlTree.GetAllCheckedNodes())
            {
                var _data = tlTree.GetDataRecordByNode(node);
                if (_data is WorkQueue _queue)
                {
                    if (!node.Expanded)
                        _items.AddRange(GetItemsFromQueue(_queue));
                }
                else if (_data is Core.Entities.Order _order)
                {
                    if (!node.Expanded)
                        _items.AddRange(GetItemsFromOrder(_order));
                }
                else if (_data is OrderRow _row)
                {
                    if (!node.Expanded)
                        _items.AddRange(GetItemsFromOrderRow(_row));
                }
                else if (_data is OrderRowItem _item)
                {
                    _items.Add(_item);
                }
            }
            return _items.Distinct().ToList();
        }
        
        private IEnumerable<OrderRowItem> GetItemsFromOrderRow(OrderRow row)
        {
            return row.OrderRowItems;
        }

        private IEnumerable<OrderRowItem> GetItemsFromOrder(Core.Entities.Order order)
        {
            return order.OrderRows.SelectMany(x => x.OrderRowItems);
        }

        private IEnumerable<OrderRowItem> GetItemsFromQueue(WorkQueue queue)
        {
            return queue.Orders.SelectMany(x => x.OrderRows).SelectMany(y => y.OrderRowItems);
        }

        private void htlTitle_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            //RepositoryItemHypertextLabel _htmlLabel = sender as RepositoryItemHypertextLabel;
            //if (_htmlLabel != null && _displayedNode != null)
            //{
            //    var data = tlTree.GetDataRecordByNode(_displayedNode);
            //    string _pref = String.Empty;
            //    if (data is OrderRowItem _item)
            //        _pref = $"Изделие {_item.Num} строка {_item.OrderRow.Num} заказ {_item.OrderRow.Order.Num}";
            //    if (data is OrderRow row)
            //        _pref = $"строка {row.Num} заказ {row.Order.Num}";
            //    if (data is Core.Entities.Order order)
            //        _pref = $"заказ {order.Num} очередь {order.WorkQueue.Num}";
            //    if (data is WorkQueue workQueue)
            //        _pref = $"очередь {workQueue.Num} от {workQueue.WorkDate}";
            //    e.DisplayText = "<image=bo_vendor><image=bo_vendor> <s>" + e.DisplayText + "</s> " + _pref;
            //}
            e.DisplayText = e.DisplayText;

        }

        private void tlTree_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            e.DisplayText = e.DisplayText;
        }

        private void tlTree_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            TreeListHitInfo hitInfo = tlTree.CalcHitInfo(e.Point);
            if (hitInfo.Node == null)
                return;
            tlTree.SetFocusedNode(hitInfo.Node);
            popupMenu.ShowPopup(tlTree.PointToScreen(e.Point));
        }

        private void bbiColapseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tlTree.CollapseAll();
        }

        private void bbiExpandAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tlTree.ExpandAll();
        }

        private void btnColapseWorkQueues_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tlTree.CollapseToLevel(1);
        }

        private void bbiWorkQueuesExpand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tlTree.ExpandToLevel(0);
        }

        private void bbiColapseToOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tlTree.CollapseToLevel(2);
        }

        private void bbiExpandToOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tlTree.ExpandToLevel(1);
        }

        private void bbiClearSelection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearSelection();
        }

        private void bbiSetStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var _selected = GetSelectedItems();
            if (_selected.Count < 1)
                return;

            NeedSetStatus?.Invoke(this, _selected);
        }

        private void bbiSetAsseblers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var _selected = GetSelectedItems();
            if (_selected.Count < 1)
                return;

            NeedSetAssembliers?.Invoke(this, _selected);
        }

        private void bdeDateDone_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void rideDone_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var _selected = GetSelectedItems();
            if (_selected.Count < 1)
                return;

            DateEdit _dateEdit = sender as DateEdit;
            
            if (_dateEdit != null)
                NeedSetDateDone?.Invoke(_dateEdit.EditValue, _selected);

        }

        private void bbiSetCutters_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var _selected = GetSelectedItems();
            if (_selected.Count < 1)
                return;

            NeedSetCutters?.Invoke(this, _selected);
        }        

        public void SetFocusById(Guid id)
        {
            //TreeListNode _node = FindNodeByFieldId2(tlTree.Nodes, id);
            TreeListNode _node = tlTree.FindNode(x => x["WorkTitle"].ToString() == id.ToString());
            if (_node == null)
            {
                XtraMessageBox.Show("Не надено!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tlTree.SetFocusedNode(_node);
        }

        private bool _FocusedIgnore = false;
        public void SetFocusByOrder(Core.Entities.Order order)
        {
            if (_FocusedIgnore)
                return;
            _FocusedIgnore = true;
            tlTree.ClearSelection();

            TreeListNode _workQueueNode = tlTree.FindNodeByFieldValue("Id", order.WorkQueue.Id);
            if (_workQueueNode == null)
                tlTree.ExpandToLevel(1);
            else
                _workQueueNode.Expand();

            TreeListNode _node = tlTree.FindNode(x => x["WorkTitle"].ToString().Contains(order.Num));
            
            if (_node == null)
            {
                XtraMessageBox.Show("Не надено!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tlTree.SetFocusedNode(_node);
            tlTree.SelectNode(_node);
            _FocusedIgnore = false;
        }

        private void tlTree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (_FocusedIgnore)
                return;
            var _data = tlTree.GetDataRecordByNode(e.Node);
            if (_data != null)
            {
                _FocusedIgnore = true;
                if (_data is WorkQueue workQueue)
                {
                   WorkQueueChanged?.Invoke(this, workQueue);
                }
                else if (_data is Core.Entities.Order order)
                {
                    WorkQueueChanged?.Invoke(this, order.WorkQueue);
                    SelectedOrderChanged?.Invoke(this, order);
                }
                else if (_data is OrderRow orderRow)
                {
                    WorkQueueChanged?.Invoke(this, orderRow.Order?.WorkQueue);
                }
                else if (_data is OrderRowItem orderRowItem)
                {
                    WorkQueueChanged?.Invoke(this, orderRowItem.OrderRow?.Order?.WorkQueue);
                }
                _FocusedIgnore = false;
            }
        }

        public void ExpandToLevel(int i)
        {
            tlTree.ExpandToLevel(i);
        }

        private void bbiSetDefect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var _selected = GetSelectedItems();
            if (_selected.Count < 1)
                return;

            NeedSetDefect?.Invoke(this, _selected);
        }

        public void ClearSelection()
        {
            tlTree.GetAllCheckedNodes().ForEach(x => x.Checked = false);
        }
    }
}
