using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Socrat.DataProvider;
using Socrat.Model.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.DirectXPaint;
using DevExpress.XtraEditors;
using TreeItem = Socrat.Model.Users.TreeItem;

namespace Socrat.Module.Settings
{
    public partial class CxMenuTree : DevExpress.XtraEditors.XtraUserControl
    {
        public MenuTree MenuTree { get; set; }
        TreeListHitInfo hitInfo = null;

        public CxMenuTree()
        {
            InitializeComponent();
            Load += CxMainMenuEditor_Load;
        }

        private void CxMainMenuEditor_Load(object sender, EventArgs e)
        {
            using (TreeItemRepository _repo = new TreeItemRepository())
            {
                MenuTree = new MenuTree(_repo.GetAll().ToList());
            }

            InitNodes(null, MenuTree.ToList());
        }

        private void tlMenuTree_MouseDown(object sender, MouseEventArgs e)
        {
            hitInfo = tlMenuTree.CalcHitInfo(new Point(e.X, e.Y));
        }

        private void tlMenuTree_MouseMove(object sender, MouseEventArgs e)
        {
            if (hitInfo == null) return;
            if (e.Button != MouseButtons.Left) return;
            Rectangle dragRect = new Rectangle(new Point(
                hitInfo.MousePoint.X - SystemInformation.DragSize.Width / 2,
                hitInfo.MousePoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
            if (!dragRect.Contains(new Point(e.X, e.Y)))
            {
                Object data = hitInfo?.Node?.Tag;
                if (null != data)
                    tlMenuTree.DoDragDrop(data, DragDropEffects.Move);
            }
        }

        private void tlMenuTree_DragEnter(object sender, DragEventArgs e)
        {
            DXDragEventArgs args = tlMenuTree.GetDXDragEventArgs(e);
            TreeListNode node = args.TargetNode;
            TreeItem targetItem = node?.Tag as Model.Users.TreeItem;
            TreeItem item = args.Node?.Tag as Model.Users.TreeItem;
            if (targetItem != null && 
                (targetItem.TreeItemType.Enum == TreeItemTypeEnum.Form
                || targetItem.TreeItemType.Enum == TreeItemTypeEnum.Module
                ||  (item != null && targetItem.ItemExists(item.Id))))
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
            
            TreeItem targetItem = targetNode?.Tag as Model.Users.TreeItem;
            Model.Users.TreeItem sourceItem = args.Data.GetData(typeof(Model.Users.TreeItem)) as Model.Users.TreeItem;
            TreeListNode sourceNode = tlMenuTree.GetNodeAt(hitInfo.MousePoint);
            if (targetNode == null && sourceItem != null && sourceItem.TreeItemType.Enum == TreeItemTypeEnum.Folder)
            {
                tlMenuTree.MoveNode(sourceNode, null);
                if (sourceItem.ParentTreeItem != null)
                    sourceItem.ParentTreeItem.TreeItems.Remove(sourceItem);
                sourceItem.ParentTreeItem = null;
            }
            else
            {
                if (sourceItem.ParentTreeItem != null)
                    sourceItem.ParentTreeItem.TreeItems.Remove(sourceItem);
                sourceItem.ParentTreeItem = targetItem;
                if (position == DragInsertPosition.AsChild && targetItem?.TreeItemType.Enum == TreeItemTypeEnum.Folder)
                {
                    if (!targetNode.Nodes.Contains(sourceNode))
                        tlMenuTree.MoveNode(sourceNode, targetNode);
                    targetItem.TreeItems.Add(sourceItem);
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
                    targetItem.TreeItems.Insert(targetPosition, sourceItem);
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

        private void InitNodes(TreeListNode pareNode, List<Model.Users.TreeItem> items)
        {
            tlMenuTree.BeginUnboundLoad();
            TreeListNode _node;
            foreach (TreeItem treeItem in items)
            {
                _node = tlMenuTree.AppendNode(
                    new object[] { treeItem.TreeItemType.Name, treeItem.Name, treeItem.Module?.Name, treeItem.Id, treeItem.SortNum }, pareNode, treeItem);
                _node.HasChildren = treeItem.TreeItems?.Count() > 0;
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

        private void tlMenuTree_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            if (null != e.Node.Tag)
            {
                Model.Users.TreeItem _item = e.Node.Tag as Model.Users.TreeItem;
                if (null != _item)
                {
                    InitNodes(e.Node, _item.TreeItems.ToList());
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
                        new object[] {_item.TreeItemType.Name, _item.Name, _item.Module?.Name, _item.Id, _item.SortNum }, null, _item);
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
            TreeItem _item = tlMenuTree.Selection.First()?.Tag as TreeItem;
            if (_item != null)
            {
                EditItem(_item);
            }
        }

        private void EditItem(TreeItem item)
        {
            FxMenuTreeItemEdit _fx = new FxMenuTreeItemEdit();
            _fx.TreeItem = item;
            _fx.SaveButtonClick += (o, args) =>
            {
                TreeListNode _node = tlMenuTree.FindNodeByFieldValue("Id", item.Id);
                switch (item.TreeItemType.Enum)
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
                _node.SetValue("SortNum", item.SortNum);
            };
            _fx.ShowDialog(this);
        }

        private void tlMenuTree_DoubleClick(object sender, EventArgs e)
        {
            TreeListNode _node = tlMenuTree.GetNodeAt(hitInfo.MousePoint);
            if (null != _node)
            {
                Model.Users.TreeItem _treeItem = _node.Tag as Model.Users.TreeItem;
                if (_treeItem != null)
                {
                    EditItem(_treeItem);
                }
            }
        }

        private void biDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeItem _item = tlMenuTree.Selection.First()?.Tag as TreeItem;
            if (_item != null)
            {
                if (_item.TreeItems != null && _item.TreeItems.Count > 0)
                {
                    XtraMessageBox.Show("Удаление не возможно - пункт меню имеет  подчиненые пункты." +
                                        "Необходимо сначала удалить их", "Отмена", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult _dialogResult = XtraMessageBox.Show($"Удалить пункт меню {_item.Name}({_item.Id})?",
                    "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    TreeListNode _node = tlMenuTree.Selection.First();
                    //удаляем из визуального дерева
                    tlMenuTree.DeleteNode(_node);
                    //удаляем из базы
                    using (TreeItemRepository _repo = new TreeItemRepository())
                        _repo.Delete(_item.Id);
                    //удаляем из объектного дерева
                    MenuTree.DeleteMenuItem(x =>
                            x.Id == _item.Id && x.Name == _item.Name && x.TreeItemType_Id == x.TreeItemType_Id);
                }
            }
        }

        private void biSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _wasChanges = false;
            List<TreeItem> _items = MenuTree.GetAllItemsList()?.Where(x => x.Changed)?.ToList();
            using (TreeItemRepository _repo = new TreeItemRepository())
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
                InitNodes(null, MenuTree.ToList());
            }

        }
    }
}
