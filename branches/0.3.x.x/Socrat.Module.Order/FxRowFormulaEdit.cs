using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Lib;
using Socrat.Log;
using Socrat.References.Formula;
using Socrat.References.Materials;
using Socrat.References.Menu;
using Socrat.References.Processings;
using Socrat.Shape;
using Socrat.UI.Core;

namespace Socrat.Module.Order
{
    public partial class FxRowFormulaEdit : FxBaseSimpleDialog
    {
        public OrderRow Row { get; set; }
        TreeListNode treeClickedNode = null;
        private CxGlassItemProperties cxGlassItemProperties;
        private CxFrameItemProperies _cxFrameItemProperies;
        private CxInsetItemProperties _cxInsetItemProperties;
        private CxInsetPosition _cxInsetPosition;
        private CxItemProperties _cxItemProperties;
        private CxProcessings _cxProcessings;
        private List<Material> _Materials;
        private CxShapeEdit cxShapeEdit;
        private CxShprosEditor cxShprosEditor;
        public bool FormulaChanged { get; set; } = false;
        private bool FormulaReloaded = false;      

        public Formula Formula
        {
            get { return GetFormula(); }
        }

        public FormulaItem FocusedFormulaItem { get => GetFocusedFormulaItem(); set => _focusedFormulaItem = value; }

        private Formula GetFormula()
        {
            try
            {
                if (Row != null && Row.Formula != null && !FormulaReloaded)
                {
                    ReloadFormulaItems();
                    FormulaReloaded = true;
                }

                if (Row != null && Row.Formula == null && ! string.IsNullOrEmpty(Row.FormulaStr))
                {
                    Row.Formula = FormulaParser.Parse(Row.FormulaStr);
                }

                Row.Formula.PropertyChanged -= _Formula_PropertyChanged;
                Row.Formula.PropertyChanged -= _Formula_PropertyChanged;

            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Ошибка формулы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Row.Formula;
        }

        private void ReloadFormulaItems()
        {
            DataHelper.ReloadCollection(Row.Formula, "FormulaItems");
            LoadPropertyItems<GlassItem, GlassItemProperty>();
            LoadPropertyItems<FrameItem, FrameItemProperty>();
            LoadPropertyItems<InsetItem, InsetItemProperty>();
            LoadPropertyItems<TriplexItem, TriplexFilmItem>();
            foreach (var _formulaItem in Row.Formula.FormulaItems)
            {
                if (_formulaItem.Formula == null)
                    _formulaItem.Formula = Row.Formula;
            }
        }

        private void LoadPropertyItems<T1, T2>()
        {
            var formulaItems = Row.Formula.FormulaItems.OfType<T1>();
            if (formulaItems != null)
                foreach (T1 _item in formulaItems)
                {
                    _item.GetType().GetProperty("OnProperiesLoading").SetValue(_item, true);
                    DataHelper.LoadProperty(_item as FormulaItem, typeof(T2).Name);
                    _item.GetType().GetProperty("OnProperiesLoading").SetValue(_item, false);
                }
        }

        private void _Formula_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateFig();
        }

        private FormulaItem _focusedFormulaItem;

        public FxRowFormulaEdit()
        {
            InitializeComponent();

            Load += FxFormulaEdit_Load;
        }

        private void InitShapeEdit()
        {
            cxShapeEdit = new CxShapeEdit();
            if (Row != null)
            {
                cxShapeEdit.ShapeId = Row?.ShapeId;
                cxShapeEdit.Row = Row;
            }
            pcFig.Controls.Add(cxShapeEdit);
            cxShapeEdit.Dock = DockStyle.Fill;
            cxShapeEdit.DialogOutput += CxShapeEdit_DialogOutput;
            cxShapeEdit.ShapeSelected += CxShapeEditOnShapeSelected;
        }

        private void CxShapeEditOnShapeSelected(object sender, EventArgs e)
        {
            Row.ShapeId = cxShapeEdit.ShapeId;
            if (cxShprosEditor != null)
            {
                cxShprosEditor.ShapeId = cxShapeEdit.ShapeId;
            }
            Row.OverallH = (int)(cxShapeEdit.Shape_H ?? 0);
            Row.OverallW = (int)(cxShapeEdit.Shape_L ?? 0);
        }

        private void CxShapeEdit_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, ta.OutputType);
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teFormulaStr, Formula, x => x.FormulaStr);
            Text = GetTitle();
            //cxShapeEdit.GetShapeSize(Row.OverallH ?? 1000, Row.OverallW ?? 1000);
        }

        private void FxFormulaEdit_Load(object sender, EventArgs e)
        {
            tlFormula.PopupMenuShowing += TlFormula_PopupMenuShowing;
            UpdateTree();
            tlFormula.FocusedNode = tlFormula?.Nodes.FirstNode;
        }

        private void TlFormula_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
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
                tlFormula.AppendNode(new object[] { item.NodeCaption }, parentNode, item.Id);
            foreach (FormulaItem formulaItem in item.FormulaItems)
            {
                //DataHelper.LoadProperty(item, "Material");
                BuiltTreeNodes(formulaItem, _node);
            }
        }

        private void UpdateTree()
        {
            tlFormula.Nodes.Clear();
            tlFormula.BeginUnboundLoad();
            TreeListNode _node;
            _node = tlFormula.AppendNode(new object[] { "Изделие" }, null, Formula.GetFakeItem().Id);
            foreach (FormulaItem item in Formula.Items)
            {
                //DataHelper.LoadProperty(item, "Material");
                BuiltTreeNodes(item, _node);
            }
            _node.ExpandAll();
            tlFormula.EndUnboundLoad();

        }

        protected override IEntity GetEntity()
        {
            return Formula;
        }

        protected override void SetEntity(IEntity value)
        {
            XtraMessageBox.Show("Попытка ввода формулы!");
        }

        private void btnParseFormula_Click(object sender, EventArgs e)
        {
            try
            {
                if (teFormulaStr.Text.Length > 0)
                    FormulaParser.Parse(Formula, teFormulaStr.Text);
                UpdateView();
            }
            catch (Exception ex)
            {
                Logger.AddErrorMsgEx(ex.Message, ex);
            }
        }

        private void UpdateView()
        {
            UpdateTree();
            UpdateFig();
            UpdateProperties();
            UpdateProcessings();
        }

        private void UpdateProcessings()
        {
            pcDetails.SuspendLayout();
            pcDetails.Controls.Clear();

            //if (_cxInsetPosition != null)
            //{
            //    _cxInsetPosition.Hide();
            //    _cxInsetPosition.Dispose();
            //    pcDetails.Controls.Clear();
            //}

            MaterialEnum _material = MaterialEnum.None;
            if (FocusedFormulaItem != null && FocusedFormulaItem.Material != null)
                _material = FocusedFormulaItem.Material.MaterialEnum;

            switch (_material)
            {
                case MaterialEnum.Triplex:
                case MaterialEnum.Glass:
                    if (_cxProcessings != null)
                        _cxProcessings.Dispose();
                    _cxProcessings = new CxProcessings();
                    _cxProcessings.DependedSaving = true;
                    _cxProcessings.FormulaItem = FocusedFormulaItem;
                    SetDetails(_cxProcessings);
                    break;
                case MaterialEnum.Inset:
                    if (_cxInsetPosition != null)
                        _cxInsetPosition.Dispose();
                    _cxInsetPosition = new CxInsetPosition();
                    _cxInsetPosition.DependedSaving = true;
                    _cxInsetPosition.InsetItem = FocusedFormulaItem as InsetItem;
                    SetDetails(_cxInsetPosition);
                    break;
                case MaterialEnum.Frame:
                    if (cxShprosEditor != null)
                        cxShprosEditor.Dispose();
                    cxShprosEditor = new CxShprosEditor();
                    cxShprosEditor.ShapeId = Row.ShapeId;
                    SetDetails(cxShprosEditor);
                    break;
            }

            pcDetails.ResumeLayout();
        }

        private void UpdateProperties()
        {
            
                pcProperties.SuspendLayout();
                pcProperties.Controls.Clear();

                InitShapeEdit();

                MaterialEnum _material = MaterialEnum.None;
                if (FocusedFormulaItem != null && FocusedFormulaItem.Material != null)
                    _material = FocusedFormulaItem.Material.MaterialEnum;

                switch (_material)
                {
                    case MaterialEnum.Glass:
                        if (cxGlassItemProperties != null)
                            cxGlassItemProperties.Dispose();
                        cxGlassItemProperties = new CxGlassItemProperties();
                        cxGlassItemProperties.GlassItem = FocusedFormulaItem as GlassItem;
                        SetupPropertiesControl(cxGlassItemProperties);
                        break;
                    case MaterialEnum.Frame:
                        if (_cxFrameItemProperies != null)
                            _cxFrameItemProperies.Dispose();
                        _cxFrameItemProperies = new CxFrameItemProperies();
                        _cxFrameItemProperies.FrameItem = FocusedFormulaItem as FrameItem;
                        SetupPropertiesControl(_cxFrameItemProperies);
                        break;
                    case MaterialEnum.Inset:
                        if (_cxInsetItemProperties != null)
                            _cxInsetItemProperties.Dispose();
                        _cxInsetItemProperties = new CxInsetItemProperties();
                        _cxInsetItemProperties.InsetItem = FocusedFormulaItem as InsetItem;
                        SetupPropertiesControl(_cxInsetItemProperties);
                        break;
                    case MaterialEnum.None:
                        if (_cxItemProperties != null)
                            _cxItemProperties.Dispose();
                        _cxItemProperties = new CxItemProperties();
                        _cxItemProperties.OrderRow = Row;
                        SetupProperties(_cxItemProperties);
                        break;
                }

                pcProperties.ResumeLayout();
            
        }

        private void SetupProperties(XtraUserControl control)
        {
            pcProperties.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void SetDetails(XtraUserControl control)
        {
            pcDetails.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            ((ITabable)control).DialogOutput += FxOnDialogOutput;
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
            UpdateAfterProperitesChanges();
        }

        private void UpdateFig()
        {
            if (!Formula.Valid)
                return;
            Image img = new Bitmap(peFig.ClientRectangle.Width, peFig.ClientRectangle.Height);
            using(Graphics graph = Graphics.FromImage(img))
            try
            {
                FormulaDrawer.Draw(Formula, graph);
            }
            catch (Exception e)
            {
               Logger.AddErrorEx("UpdateFig", e);
            }
            peFig.Image = img;
            //cxShapeEdit.RefreshImage();
        }

        private FormulaItem GetNodeItem(TreeListNode node)
        {
            if (node.Tag == null)
                return null;
            Guid _id;
            Guid.TryParse(node.Tag.ToString(), out _id);
            return Formula.FindItem(_id);
        }

        private void tlFormula_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (tlFormula.FocusedNode != null)
            {
                FormulaItem _item = GetNodeItem(tlFormula.FocusedNode);
                Formula.ResetSelection();
                if (_item != null)
                   _item.Selected = true;
                UpdateProperties();
                UpdateProcessings();
            }
            UpdateFig();
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

        private void biSetMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            SetNewItem();
        }

        private void SetNewItem()
        {

        }

        private FormulaItem GetFocusedFormulaItem()
        {
            if (tlFormula.FocusedNode != null)
                _focusedFormulaItem = GetNodeItem(tlFormula.FocusedNode);
            if (_focusedFormulaItem != null 
                && _focusedFormulaItem.Material != null 
                && _focusedFormulaItem.Material.MaterialEnum == MaterialEnum.None)
                _focusedFormulaItem = null;
            return _focusedFormulaItem;
        }


        private void SetupMaterial(MaterialEnum materialEnum)
        {
            FxFilteredMaterialNoms _fx = new FxFilteredMaterialNoms();
            _fx.Material = GetMaterialByEnum(materialEnum);
            _fx.SetSingleSelectMode(_fx.Material);
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
                UpdateProcessings();
            };
            _fx.DialogOutput += FxOnDialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private Material GetMaterialByEnum(MaterialEnum materialEnum)
        {
            if (_Materials == null || _Materials.Count < 1)
            {
                using (IRepository<Material> _repo = DataHelper.GetRepository<Material>())
                {
                    _Materials = _repo.GetAll().ToList();
                }
            }
            return _Materials.FirstOrDefault(x => x.MaterialEnum == materialEnum);
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
            ProcessingEnum[] _canProcess = null;


            if (tlFormula.FocusedNode != null && FocusedFormulaItem != null)
            {
                _whatCanAppend = FocusedFormulaItem.CanAppend;
                _canChangeTo = FocusedFormulaItem.CanChangeTo;
                _canProcess = FocusedFormulaItem.CanProcess;
            }
            else
            {
                _whatCanAppend = Formula.CanAppend;
                _canChangeTo = Formula.CanChangeTo;
                _canProcess = Formula.CanProcess;
            }
            
            //ПМ добавить
            if (_whatCanAppend != null && _whatCanAppend.Length > 0)
            {
                BarSubItem _subitem = new BarSubItem(barManager, "Добавить");
                BarButtonItem _buttonItem = null;
                string _title = string.Empty;
                for (int i = 0; i < _whatCanAppend.Length; i++)
                {
                    MaterialEnum _material = _whatCanAppend[i];
                    switch (_whatCanAppend[i])
                    {
                        case MaterialEnum.Glass:
                            _title = "Стекло";
                            break;
                        case MaterialEnum.Frame:
                            _title = "Рамка";
                            break;
                        case MaterialEnum.Film:
                            _title = "Пленка";
                            break;
                        case MaterialEnum.Triplex:
                            _title = "Триплекс";
                            break;
                        case MaterialEnum.TriplexFilm:
                            _title = "Межстекольная пленка";
                            break;
                        case MaterialEnum.Inset:
                            _title = "Вставка";
                            break;
                    }

                    if (!string.IsNullOrEmpty(_title))
                    {
                        _buttonItem = new BarButtonItem(barManager, _title);
                        if (_whatCanAppend[i] != MaterialEnum.Triplex)
                        {
                            _buttonItem.BindCommand(new MaterialAddCommand(SetupMaterial, _material));
                        }
                        else
                        {
                            _buttonItem.BindCommand(new MaterialAddCommand(SetupTriplex, _material));
                        }
                        _subitem.AddItem(_buttonItem);
                    }
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
                            _biChangeTo.BindCommand(new MaterialAddCommand(ChangeToMaterial, materialEnum));
                            break;
                        case MaterialEnum.Frame:
                            _biChangeTo = new BarButtonItem(barManager, "Рамка");
                            _biChangeTo.BindCommand(new MaterialAddCommand(ChangeToMaterial, materialEnum));
                            break;

                        case MaterialEnum.Film:
                            _biChangeTo = new BarButtonItem(barManager, "Пленка");
                            _biChangeTo.BindCommand(new MaterialAddCommand(ChangeToMaterial, materialEnum));
                            break;
                        case MaterialEnum.Triplex:
                            _biChangeTo = new BarButtonItem(barManager, "Триплекс");
                            _biChangeTo.BindCommand(new MaterialAddCommand(ChangeToTriplex, materialEnum));
                            break;
                        case MaterialEnum.TriplexFilm:
                            _biChangeTo = new BarButtonItem(barManager, "Межстекольная пленка");
                            _biChangeTo.BindCommand(new MaterialAddCommand(ChangeToMaterial, materialEnum));
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

            //операции
            if (_canProcess != null && _canProcess.Length > 0)
            {
                BarButtonItem _biProcessing = null;
                BarSubItem _processingsSubItem = new BarSubItem(barManager, "Добавить операцию");

                for (var _i = 0; _i < _canProcess.Length; _i++)
                {
                    switch (_canProcess[_i])
                    {
                        case ProcessingEnum.SurfaceCoverProtection:
                            _biProcessing = new BarButtonItem(barManager, "Зашитное окрашивание");
                            _biProcessing.BindCommand(new ProcessingAddCommand(AddProcessing, _canProcess[_i]));
                            break;
                    }        
                }
            }

            //копировать в следующий слой

            //задать изделие по формуле
            BarButtonItem _SetupFormula = new BarButtonItem(barManager, "Задать изделие по формуле");
            _SetupFormula.BindCommand(new MaterialAddCommand(SetupByFormula, MaterialEnum.Glass));
            pmTree.AddItem(_SetupFormula);
            pmTree.ItemLinks.Last().BeginGroup = true;

            //удалить элемент
            if (FocusedFormulaItem != null)
            {
                BarButtonItem _DeleteItem = new BarButtonItem(barManager, "Удалить");
                _DeleteItem.BindCommand(new MaterialAddCommand(DeleteFormulaItem, MaterialEnum.Glass));
                pmTree.AddItem(_DeleteItem);
                pmTree.ItemLinks.Last().BeginGroup = true;
            }
            else
            {
                BarButtonItem _ClearFormula = new BarButtonItem(barManager, "Очистить");
                _ClearFormula.BindCommand(new MaterialAddCommand(ClearFormula, MaterialEnum.Glass));
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
                //if (Formula.Items.Count < 1)
                //    LoadFormulaItems(Formula);
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
            UpdateProcessings();
        }

        private void UpdateAfterProperitesChanges()
        {
            Formula.RebuildFormulaStr();
            teFormulaStr.Text = Formula.FormulaStr;
            UpdateFig();
        }

        private void SetupTriplex(MaterialEnum materialEnum)
        {
            Formula.AddEmptyTriplex(GetMaterialByEnum(materialEnum));
            Formula.Valid = true;
            UpdateTree();
            UpdateFig();
            UpdateProperties();
            UpdateProcessings();
        }

        private void AddProcessing(ProcessingEnum processingEnum)
        {
        }

        private void ChangeToMaterial(MaterialEnum materialEnum)
        {
            FxFilteredMaterialNoms _fx = new FxFilteredMaterialNoms();
            _fx.Material = GetMaterialByEnum(materialEnum);
            _fx.SetSingleSelectMode(_fx.Material);
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
                    UpdateProcessings();
                }
            };
            _fx.DialogOutput += FxOnDialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private FormulaItem GetItemByEnum(MaterialEnum materialEnum, MaterialNom nom)
        {
            Material _material = GetMaterialByEnum(materialEnum);
            switch (materialEnum)
            {
                case MaterialEnum.Glass:
                    return new GlassItem { Material = _material, ItemStr = nom .Code, MaterialNom = nom};
                case MaterialEnum.Frame:
                    return new FrameItem { Material = _material, ItemStr = nom.Code, MaterialNom = nom };
                case MaterialEnum.TriplexFilm:
                    return new TriplexFilmItem { Material = _material, ItemStr = nom.Code, MaterialNom = nom };
                case MaterialEnum.Triplex:
                    return new TriplexItem { ItemStr = nom.Code, MaterialNom = nom, Formula = this.Formula};
                case MaterialEnum.Film:
                    return new FilmItem { Material = _material, ItemStr = nom.Code, MaterialNom = nom };
                case MaterialEnum.Inset:
                    return new InsetItem { Material = _material, ItemStr = nom.Code, MaterialNom = nom };
            }

            return null;
        }

        public override bool Validate()
        {
            return true;
        }

        protected override void OnSaveButtonClick()
        {
            if (!Entity.Changed || ReadOnly)
            {
                return;
            }

            DialogResult _dialogResult = XtraMessageBox.Show("Были внесены изменения. Сохранить?", "Сохранение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (_dialogResult == DialogResult.Yes)
            {
                FormulaChanged = true;
                Row.Formula.Changed = false;
            }
        }


        //private void LoadFormulaItems(Formula formula)
        //{
        //    this.ShowSplashScreen();
        //    using (Socrat.Core.IRepository<FormulaItem> _repo = DataHelper.GetRepository<FormulaItem>())
        //    {
        //        var _items = _repo.GetAll(x => x.FormulaId == formula.Id);
        //        formula.LoadFormulaItems(_items);
        //    }
        //    this.HideSplashScreen();
        //}

        protected override string GetTitle()
        {
            return $"Изделие {Row.Num} (Заказ {Row.Order?.Num})";
        }

        private void peFig_SizeChanged(object sender, EventArgs e)
        {
            UpdateFig();
        }
    }
}