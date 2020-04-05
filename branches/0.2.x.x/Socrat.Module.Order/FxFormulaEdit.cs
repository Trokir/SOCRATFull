using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Socrat.DataProvider.Repos;
using Socrat.Lib;
using Socrat.Lib.Commands;
using Socrat.Log;
using Socrat.Model;
using Socrat.Model.Users;
using Socrat.References.Materials;
using Socrat.UI.Core;
using Socrat.Module.Order.Menu;

namespace Socrat.Module.Order
{
    public partial class FxFormulaEdit : FxBaseSimpleDialog
    {
        public Model.OrderRow Row { get; set; }
        TreeListNode treeClickedNode = null;
        private CxGlassItemProperties cxGlassItemProperties;
        private CxFrameIteProperies cxFrameIteProperies;
        private List<Model.Material> _Materials;

        private Model.Formula _Formula;
        public Model.Formula Formula
        {
            get { return GetFormula(); }
            set { Row.Formula = value; }
        }

        public FormulaItem FocusedFormulaItem { get => GetFocusedFormulaItem(); set => _focusedFormulaItem = value; }

       private Model.Formula GetFormula()
        {
            try
            {
                if (null == _Formula)
                {
                    if (Row.Formula != null)
                        _Formula = Row.Formula;
                    else
                        _Formula = FormulaParser.Parse(Row?.FormulaStr);
                    _Formula.PropertyChanged += _Formula_PropertyChanged;
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Ошибка формулы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _Formula;
        }

        private void _Formula_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateFig();
        }

        private Graphics graphics;
        private FormulaItem _focusedFormulaItem;

        public FxFormulaEdit()
        {
            InitializeComponent();
            Load += FxFormulaEdit_Load;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teFormulaStr, Formula, x => x.FormulaStr);
            Text = GetTitle();
        }

        private void FxFormulaEdit_Load(object sender, System.EventArgs e)
        {
            tlFormula.PopupMenuShowing += TlFormula_PopupMenuShowing;

            UpdateTree();
            UpdateFig();
        }

        private void TlFormula_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            var hitInfo = (sender as TreeList).CalcHitInfo(e.Point);

            if (hitInfo.HitInfoType == HitInfoType.RowIndicator)
            {
                treeClickedNode = hitInfo.Node;
            }

            biChangeTo.Enabled = treeClickedNode != null;
            biCopyToNextLayer.Enabled = treeClickedNode != null;
            biDelete.Enabled = treeClickedNode != null;

        }

        private void BuiltTreeNodes(FormulaItem item, TreeListNode parentNode)
        {
            TreeListNode _node =
                tlFormula.AppendNode(new object[] { item.NodeCaption }, parentNode, item);
            foreach (FormulaItem formulaItem in item.Items)
            {
                BuiltTreeNodes(formulaItem, _node);
            }
        }

        private void UpdateTree()
        {
            tlFormula.Nodes.Clear();
            tlFormula.BeginUnboundLoad();
            TreeListNode _node;
            _node = tlFormula.AppendNode(new object[] { "Изделие" }, null);
            foreach (FormulaItem item in Formula.Items)
                BuiltTreeNodes(item, _node);
            _node.ExpandAll();
            tlFormula.EndUnboundLoad();

        }

        protected override IEntity GetEntity()
        {
            return Formula;
        }

        protected override void SetEntity(IEntity value)
        {
            Formula = value as Model.Formula;
        }

        private void btnParseFormula_Click(object sender, System.EventArgs e)
        {
            if (teFormulaStr.Text.Length > 0)
                FormulaParser.Parse(Formula, teFormulaStr.Text);
            UpdateView();
        }

        private void UpdateView()
        {
            UpdateTree();
            UpdateFig();
            UpdateProperties();
        }

        private void UpdateProperties()
        {
            if (FocusedFormulaItem != null)
            {
                pcProperties.SuspendLayout();
                pcProperties.Controls.Clear();
                MaterialEnum _material = FocusedFormulaItem.Material?.MaterialEnum
                                         ?? FocusedFormulaItem.Material?.MaterialEnum
                                         ?? MaterialEnum.None;
                switch (_material)
                {
                    case MaterialEnum.Glass:
                        if (cxGlassItemProperties != null)
                            cxGlassItemProperties.Dispose();
                        cxGlassItemProperties = new CxGlassItemProperties();
                        cxGlassItemProperties.GlassItem = FocusedFormulaItem as Model.GlassItem;
                        SetupPropertiesControl(cxGlassItemProperties);
                        break;
                    case MaterialEnum.Frame:
                        if (cxFrameIteProperies != null)
                            cxFrameIteProperies.Dispose();
                        cxFrameIteProperies = new CxFrameIteProperies();
                        cxFrameIteProperies.FrameItem = FocusedFormulaItem as Model.FrameItem;
                        SetupPropertiesControl(cxFrameIteProperies);
                        break;
                }
                pcProperties.ResumeLayout();
            }
        }

        private void SetupPropertiesControl(CxFormulaItemProperties propertiesControl)
        {
            pcProperties.Controls.Add(propertiesControl);
            propertiesControl.Dock = DockStyle.Fill;
            propertiesControl.DialogOutput += FxOnDialogOutput;
            propertiesControl.NeedUpdateParentView += NeedUpdateParentView;
        }

        private void NeedUpdateParentView(object sender, EventArgs e)
        {
            UpdateAfterTreeChanges();
        }

        private void UpdateFig()
        {
            if (!Formula.Valid)
                return;

            graphics = pcDrow.CreateGraphics();
            try
            {
                FormulaDrawer.Draw(Formula, graphics);
            }
            catch (Exception e)
            {
               Logger.AddErrorEx("UpdateFig", e);
            }
        }

        private void pcDrow_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                FormulaDrawer.Draw(Formula, graphics);
            }
            catch (Exception ex)
            {
                Logger.AddErrorEx("pcDrow_Paint", ex);
            }
        }

        private void tlFormula_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (tlFormula.FocusedNode != null)
            {
                FormulaItem _item = tlFormula.FocusedNode.Tag as FormulaItem;
                Formula.ResetSelection();
                if (_item != null)
                    _item.Selected = true;
                UpdateFig();
                UpdateProperties();
            }
        }

        private void teFormulaStr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateView();
            }
        }

        private void tlFormula_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var _hi = tlFormula.CalcHitInfo(tlFormula.PointToScreen(e.Location));
                pmTree.ShowPopup(_hi.MousePoint, tlFormula);
            }
        }

        private void biSetMaterial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetNewItem();
        }

        private void SetNewItem()
        {

        }

        private FormulaItem GetFocusedFormulaItem()
        {
            _focusedFormulaItem = tlFormula?.FocusedNode.Tag as FormulaItem;
            return _focusedFormulaItem;
        }


        private void SetupMaterial(MaterialEnum materialEnum)
        {
            FxFilteredMaterialNoms _fx = new FxFilteredMaterialNoms();
            _fx.Material = GetMaterialByEnum(materialEnum);
            _fx.SetSingleSelectMode();
            _fx.ItemSelected += (sender, args) =>
            {
                MaterialNom _nom = _fx.SelectedItem as MaterialNom;
                FormulaItem formulaItem = GetItemByEnum(materialEnum, _nom);
                if (FocusedFormulaItem != null)
                    FocusedFormulaItem.AppendItem(formulaItem);
                else
                    Formula.ApendItem(formulaItem);

                Formula.RebuildFormulaStr();
                teFormulaStr.Text = Formula.FormulaStr;

                Formula.Valid = true;
                UpdateTree();
                UpdateFig();
                UpdateProperties();
            };
            _fx.DialogOutput += FxOnDialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private Material GetMaterialByEnum(MaterialEnum materialEnum)
        {
            if (_Materials == null || _Materials.Count < 1)
            {
                using (MaterialRepository _repo = new MaterialRepository())
                {
                    _Materials = _repo.GetAll().ToList();
                }
            }
            else
                return _Materials.FirstOrDefault(x => x.MaterialEnum == materialEnum);

            return null;
        }

        private void FxOnDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, ta.OutputType);
        }

        private void BuildPopupMenu()
        {
            pmTree.ClearLinks();
            MaterialEnum[] _whatCanAppend = null;
            MaterialEnum[] _canChangeTo = null;


            if (tlFormula.FocusedNode != null && FocusedFormulaItem != null)
            {
                _whatCanAppend = FocusedFormulaItem.CanAppend;
                _canChangeTo = FocusedFormulaItem.CanChangeTo;
            }
            else
            {
                _whatCanAppend = Formula.CanAppend;
                _canChangeTo = Formula.CanChangeTo;
            }
            
            //ПМ добавить
            if (_whatCanAppend != null && _whatCanAppend.Length > 0)
            {
                BarSubItem _subitem = new BarSubItem(barManager, "Добавить");
                BarButtonItem _buttonItem = null;
                for (int i = 0; i < _whatCanAppend.Length; i++)
                {
                    MaterialEnum _material = _whatCanAppend[i];
                    switch (_whatCanAppend[i])
                    {
                        case MaterialEnum.Glass:
                            _buttonItem = new BarButtonItem(barManager, "Стекло");
                            _buttonItem.BindCommand(new MaterialCommand(SetupMaterial, _material));
                            break;
                        case MaterialEnum.Frame:
                            _buttonItem = new BarButtonItem(barManager, "Рамка");
                            _buttonItem.BindCommand(new MaterialCommand(SetupMaterial, _material));
                            break;

                        case MaterialEnum.Film:
                            _buttonItem = new BarButtonItem(barManager, "Пленка");
                            _buttonItem.BindCommand(new MaterialCommand(SetupMaterial, _material));
                            break;
                        case MaterialEnum.Triplex:
                            _buttonItem = new BarButtonItem(barManager, "Триплекс");
                            _buttonItem.BindCommand(new MaterialCommand(SetupTriplex, _material));
                            break;
                        case MaterialEnum.TriplexFilm:
                            _buttonItem = new BarButtonItem(barManager, "Межстекольная пленка");
                            _buttonItem.BindCommand(new MaterialCommand(SetupMaterial, _material));
                            break;
                    }

                    if (_buttonItem != null)
                        _subitem.AddItem(_buttonItem);
                }
                pmTree.AddItem(_subitem);
            }

            //ПМ заменить на
            if (_canChangeTo != null && _canChangeTo.Length > 0)
            {
                BarButtonItem _biChangeTo = null;
                BarSubItem _changeToSubItem = new BarSubItem(barManager, "Заменить на");

                _changeToSubItem = new BarSubItem(barManager, "Заменить на");
                foreach (MaterialEnum materialEnum in _canChangeTo)
                {
                    switch (materialEnum)
                    {
                        case MaterialEnum.Glass:
                            _biChangeTo = new BarButtonItem(barManager, "Стекло");
                            _biChangeTo.BindCommand(new MaterialCommand(ChangeToMaterial, materialEnum));
                            break;
                        case MaterialEnum.Frame:
                            _biChangeTo = new BarButtonItem(barManager, "Рамка");
                            _biChangeTo.BindCommand(new MaterialCommand(ChangeToMaterial, materialEnum));
                            break;

                        case MaterialEnum.Film:
                            _biChangeTo = new BarButtonItem(barManager, "Пленка");
                            _biChangeTo.BindCommand(new MaterialCommand(ChangeToMaterial, materialEnum));
                            break;
                        case MaterialEnum.Triplex:
                            _biChangeTo = new BarButtonItem(barManager, "Триплекс");
                            _biChangeTo.BindCommand(new MaterialCommand(ChangeToTriplex, materialEnum));
                            break;
                        case MaterialEnum.TriplexFilm:
                            _biChangeTo = new BarButtonItem(barManager, "Межстекольная пленка");
                            _biChangeTo.BindCommand(new MaterialCommand(ChangeToMaterial, materialEnum));
                            break;
                    }

                    if (_biChangeTo != null)
                    {
                        _changeToSubItem.AddItem(_biChangeTo);
                    }
                }
                if (_changeToSubItem != null)
                    pmTree.AddItem(_changeToSubItem);
            }

            //копировать в следующий слой

            //задать изделие по формуле
            BarButtonItem _SetupFormula = new BarButtonItem(barManager, "Задать изделие по формуле");
            _SetupFormula.BindCommand(new MaterialCommand(SetupByFormula, MaterialEnum.Glass));
            pmTree.AddItem(_SetupFormula);
            pmTree.ItemLinks.Last().BeginGroup = true;

            //удалить элемент
            if (FocusedFormulaItem != null)
            {
                BarButtonItem _DeleteItem = new BarButtonItem(barManager, "Удалить");
                _DeleteItem.BindCommand(new MaterialCommand(DeleteFormulaItem, MaterialEnum.Glass));
                pmTree.AddItem(_DeleteItem);
                pmTree.ItemLinks.Last().BeginGroup = true;
            }
            else
            {
                BarButtonItem _ClearFormula = new BarButtonItem(barManager, "Очистить");
                _ClearFormula.BindCommand(new MaterialCommand(ClearFormula, MaterialEnum.Glass));
                pmTree.AddItem(_ClearFormula);
                pmTree.ItemLinks.Last().BeginGroup = true;
            }
        }

        private void ClearFormula(MaterialEnum obj)
        {
            DialogResult _dialogResult = XtraMessageBox.Show(
                $"Очистить формулу ?", "Удаление", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (_dialogResult == DialogResult.Yes)
            {
                Formula.Clear();
                UpdateAfterTreeChanges();
            }
        }

        private void DeleteFormulaItem(MaterialEnum obj)
        {
            DialogResult _dialogResult = XtraMessageBox.Show(
                $"Удалить элемент {FocusedFormulaItem.ItemStr}?", "Удаление", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (_dialogResult == DialogResult.Yes)
            {
                Formula.DeletedItem(FocusedFormulaItem);
                UpdateAfterTreeChanges();
            }
        }

        private void SetupByFormula(MaterialEnum obj)
        {
            teFormulaStr.Focus();
        }

        private void pmTree_BeforePopup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BuildPopupMenu();
        }

        private void ChangeToTriplex(MaterialEnum materialEnum)
        {
            Formula.ReplaceToEptyTriplex(FocusedFormulaItem, GetMaterialByEnum(materialEnum));
            UpdateAfterTreeChanges();
        }

        private void UpdateAfterTreeChanges()
        {
            Formula.RebuildFormulaStr();
            teFormulaStr.Text = Formula.FormulaStr;
            UpdateTree();
            UpdateFig();
            UpdateProperties();
        }

        private void SetupTriplex(MaterialEnum materialEnum)
        {
            Formula.AddEmptyTriplex(GetMaterialByEnum(materialEnum));
            Formula.Valid = true;
            UpdateTree();
            UpdateFig();
            UpdateProperties();
        }

        private void ChangeToMaterial(MaterialEnum materialEnum)
        {
            FxFilteredMaterialNoms _fx = new FxFilteredMaterialNoms();
            _fx.Material = GetMaterialByEnum(materialEnum);
            _fx.SetSingleSelectMode();
            _fx.ItemSelected += (sender, args) =>
            {
                MaterialNom _nom = _fx.SelectedItem as MaterialNom;
                FormulaItem formulaItem = GetItemByEnum(materialEnum, _nom);
                if (FocusedFormulaItem != null)
                {
                    Formula.ReplaceFormulaItem(FocusedFormulaItem, formulaItem);

                    Formula.RebuildFormulaStr();
                    teFormulaStr.Text = Formula.FormulaStr;

                    UpdateTree();
                    UpdateFig();
                    UpdateProperties();
                }
            };
            _fx.DialogOutput += FxOnDialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private FormulaItem GetItemByEnum(MaterialEnum materialEnum, MaterialNom nom)
        {
            Model.Material _material = GetMaterialByEnum(materialEnum);
            switch (materialEnum)
            {
                case MaterialEnum.Glass:
                    return new GlassItem { Material = _material, ItemStr = nom .Code, MaterialNom = nom};
                case MaterialEnum.Frame:
                    return new FrameItem { Material = _material, ItemStr = nom.Code, MaterialNom = nom };
                case MaterialEnum.TriplexFilm:
                    return new TriplexFilmItem { Material = _material, ItemStr = nom.Code, MaterialNom = nom };
                case MaterialEnum.Triplex:
                    return new TriplexItem { Material = _material, ItemStr = nom.Code, MaterialNom = nom };
                case MaterialEnum.Film:
                    return new FilmItem { Material = _material, ItemStr = nom.Code, MaterialNom = nom };
            }

            return null;
        }

        public override bool Validate()
        {
            Row.FormulaStr = _Formula.FormulaStr;
            Row.Formula = _Formula;
            return true;
        }

        protected override void OnSaveButtonClick()
        {
            if (!Entity.Changed || ReadOnly)
                return;

            DialogResult _dialogResult = XtraMessageBox.Show("Были внесены изменения. Сохранить?", "Сохранение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (_dialogResult == DialogResult.Yes)
            {
                Row.FormulaStr = _Formula.FormulaStr;
                Row.Formula = _Formula;
            }
        }

        protected override string GetTitle()
        {
            return $"Изделие {Row.Num} (Заказ {Row.Order?.Num})";
        }
    }
}