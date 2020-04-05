using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Log;

namespace Socrat.Module.Settings
{
    public partial class CxMenuTree : DevExpress.XtraEditors.XtraUserControl
    {
        public MenuTree MenuTree { get; set; }
        TreeListHitInfo _hitInfo = null;

        public CxMenuTree()
        {
            InitializeComponent();
            Load += CxMainMenuEditor_Load;
        }

        private void CxMainMenuEditor_Load(object sender, EventArgs e)
        {
            var _tmp = DataHelper.GetAll<TreeItem>();
            _tmp.ForEach(item => DataHelper.ReloadCollection(item, "RoleTreeItems"));
            MenuTree = new MenuTree(_tmp.ToList());

            InitNodes(null, MenuTree.OrderBy(x => x.SortNum).ToList());
        }

        private void tlMenuTree_MouseDown(object sender, MouseEventArgs e)
        {
            _hitInfo = tlMenuTree.CalcHitInfo(new Point(e.X, e.Y));
        }

        private void tlMenuTree_MouseMove(object sender, MouseEventArgs e)
        {
            if (_hitInfo == null) return;
            if (e.Button != MouseButtons.Left) return;
            Rectangle dragRect = new Rectangle(new Point(
                _hitInfo.MousePoint.X - SystemInformation.DragSize.Width / 2,
                _hitInfo.MousePoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
            if (!dragRect.Contains(new Point(e.X, e.Y)))
            {
                Object data = _hitInfo?.Node?.Tag;
                if (null != data)
                    tlMenuTree.DoDragDrop(data, DragDropEffects.Move);
            }
        }

        private void tlMenuTree_DragEnter(object sender, DragEventArgs e)
        {
            DXDragEventArgs args = tlMenuTree.GetDXDragEventArgs(e);
            TreeListNode node = args.TargetNode;
            TreeItem targetItem = GetNodeItem(node);
            TreeItem item = GetNodeItem(args.Node);
            if (targetItem != null &&
                (targetItem.TreeItemType.Enum == TreeItemTypeEnum.Form
                || targetItem.TreeItemType.Enum == TreeItemTypeEnum.Module
                || (item != null && targetItem.ItemExists(item.Id))))
            {
                e.Effect = DragDropEffects.None;
            }
            e.Effect = DragDropEffects.Move;
        }

        private void tlMenuTree_DragDrop(object sender, DragEventArgs e)
        {
            DXDragEventArgs args = tlMenuTree.GetDXDragEventArgs(e);
            DragInsertPosition position = args.DragInsertPosition;
            if (position == null) return;
            TreeListNode targetNode = args.TargetNode;

            TreeItem targetItem = GetNodeItem(targetNode);
            TreeItem sourceItem = MenuTree.GetItem((Guid)args.Data.GetData(typeof(Guid)));
            TreeListNode sourceNode = tlMenuTree.GetNodeAt(_hitInfo.MousePoint);
            if (targetNode == null && sourceItem != null && sourceItem.TreeItemType.Enum == TreeItemTypeEnum.Folder)
            {
                tlMenuTree.MoveNode(sourceNode, null);
                if (sourceItem.ParentTreeItem != null)
                    sourceItem.ParentTreeItem.TreeItems.Remove(sourceItem);
                sourceItem.ParentTreeItem = null;
            }
            else
            {
                if (sourceItem != null && sourceItem.ParentTreeItem != null)
                    sourceItem.ParentTreeItem.TreeItems.Remove(sourceItem);
                sourceItem.ParentTreeItem = targetItem;
                if (position == DragInsertPosition.AsChild && targetItem?.TreeItemType.Enum == TreeItemTypeEnum.Folder)
                {
                    if (!targetNode.Nodes.Contains(sourceNode))
                        tlMenuTree.MoveNode(sourceNode, targetNode);
                    //targetItem.TreeItems.Add(sourceItem);
                }
                if (position == DragInsertPosition.Before
                    && !targetItem.ItemExists(sourceItem.Id))
                {
                    if (!targetNode.Nodes.Contains(sourceNode))
                        tlMenuTree.MoveNode(sourceNode, targetNode.ParentNode);
                    int targetPosition;
                    if (targetNode.ParentNode == null)
                        targetPosition = tlMenuTree.Nodes.IndexOf(targetNode);
                    else
                        targetPosition = targetNode.ParentNode.Nodes.IndexOf(targetNode);
                    tlMenuTree.SetNodeIndex(sourceNode, targetPosition);
                    if (targetItem.TreeItems.Count > targetPosition)
                        targetItem.TreeItems.Insert(targetPosition, sourceItem);
                    else
                        targetItem.TreeItems.Add(sourceItem);
                }

                if (null != targetNode)
                    targetNode.Expanded = true;
            }
            if (targetItem != null)
                targetItem.Changed = true;
            if (sourceItem != null)
                sourceItem.Changed = true;

            MenuTree.BuildTree();
        }

        private void InitNodes(TreeListNode pareNode, List<TreeItem> items)
        {
            tlMenuTree.BeginUnboundLoad();
            TreeListNode _node;
            foreach (TreeItem treeItem in items.OrderBy(x => x.SortNum))
            {
                //if (treeItem.NodeInited)
                //    break;
                _node = tlMenuTree.AppendNode(
                    new object[] { treeItem.TreeItemType.Name, treeItem.Name, treeItem.Module?.Name, treeItem.SortNum }, pareNode, treeItem.Id);
                _node.HasChildren = treeItem.TreeItems?.Count() > 0;
                treeItem.NodeInited = true;
                switch (treeItem.TreeItemType.Enum)
                {
                    case TreeItemTypeEnum.Folder:
                        _node.ImageIndex = 0;
                        _node.SelectImageIndex = 0;
                        break;
                    default:
                        _node.ImageIndex = 1;
                        _node.SelectImageIndex = 1;
                        break;
                }
            }
            tlMenuTree.EndUnboundLoad();
        }

        private TreeItem GetNodeItem(TreeListNode node)
        {
            TreeItem _item = null;
            Guid _id;
            if (node != null && node.Tag != null && Guid.TryParse(node.Tag.ToString(), out _id))
            {
                _item = MenuTree.GetItem(_id);
            }
            return _item;
        }

        private void tlMenuTree_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            if (null != e.Node.Tag)
            {
                TreeItem _item = GetNodeItem(e.Node);
                if (null != _item)
                {
                    InitNodes(e.Node, _item.TreeItems.OrderBy(x => x.SortNum).ToList());
                }
            }
        }

        private void biAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeItem _item = new TreeItem();
            FxMenuTreeItemEdit _fx = new FxMenuTreeItemEdit();
            _fx.TreeItem = _item;
            _fx.SaveButtonClick += (o, args) =>
            {
                TreeListNode _node = null;
                if (!MenuTree.CheckMenuItemExists(_item))
                {
                    MenuTree.Add(_item);
                    _node = tlMenuTree.AppendNode(
                        new object[] { _item.TreeItemType.Name, _item.Name, _item.Module?.Name, _item.SortNum }, null, _item.Id);
                }
                if (_node != null)
                    switch (_item.TreeItemType.Enum)
                    {
                        case TreeItemTypeEnum.Folder:
                            _node.ImageIndex = 0;
                            _node.SelectImageIndex = 0;
                            break;
                        default:
                            _node.ImageIndex = 1;
                            _node.SelectImageIndex = 1;
                            break;
                    }
            };
            _fx.ShowDialog(this);
        }

        private void biEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeItem _item = GetNodeItem(tlMenuTree.Selection.First());
            if (_item != null)
            {
                EditItem(_item, tlMenuTree.Selection.First());
            }
        }

        private void EditItem(TreeItem item, TreeListNode node)
        {
            FxMenuTreeItemEdit _fx = new FxMenuTreeItemEdit();
            _fx.TreeItem = item;
            _fx.SaveButtonClick += (o, args) =>
            {
                try
                {
                    switch (item.TreeItemType.Enum)
                    {
                        case TreeItemTypeEnum.Folder:
                            node.ImageIndex = 0;
                            node.SelectImageIndex = 0;
                            break;
                        default:
                            node.ImageIndex = 1;
                            node.SelectImageIndex = 1;
                            break;

                    }

                    node.SetValue("SortNum", item.SortNum);
                }
                catch (Exception ex)
                {
                    Logger.AddErrorEx("EditItem", ex);
                }
            };
            _fx.ShowDialog(this);
        }

        private void tlMenuTree_DoubleClick(object sender, EventArgs e)
        {
            TreeListNode _node = tlMenuTree.GetNodeAt(_hitInfo.MousePoint);
            if (null != _node)
            {
                TreeItem _treeItem = GetNodeItem(_node);
                if (_treeItem != null)
                {
                    EditItem(_treeItem, _node);
                }
            }
        }

        private void biDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeItem _item = GetNodeItem(tlMenuTree.Selection.First());
            if (_item != null)
            {
                if (_item.TreeItems != null && _item.TreeItems.Count > 0)
                {
                    XtraMessageBox.Show("Удаление не возможно - пункт меню имеет  подчиненые пункты." +
                                        "Необходимо сначала удалить их", "Отмена", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult _dialogResult = XtraMessageBox.Show($"Удалить пункт меню {_item.Name}?",
                    "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    TreeListNode _node = tlMenuTree.Selection.First();
                    //удаляем из визуального дерева
                    tlMenuTree.DeleteNode(_node);
                    Guid _id = _item.Id;
                    //удаляем из объектного дерева
                    MenuTree.DeleteMenuItem(x => x.Id == _id);
                    //удаляем из базы
                    using (IRepository<TreeItem> _repo = DataHelper.GetRepository<TreeItem>())
                        _repo.Delete(_id);
                }
            }
        }

        private void biSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _wasChanges = false;
            List<TreeItem> _items = MenuTree.GetAllItemsList()?.Where(x => x.Changed)?.ToList();
            using (IRepository<TreeItem> _repo = DataHelper.GetRepository<TreeItem>())
            {
                foreach (TreeItem treeItem in _items)
                {
                    _wasChanges = true;
                    _repo.Save(treeItem);
                }
            }

            if (_wasChanges)
            {
                tlMenuTree.ClearNodes();
                InitNodes(null, MenuTree.OrderBy(x => x.SortNum).ToList());
            }

        }
    }
}
