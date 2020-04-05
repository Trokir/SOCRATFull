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
using Socrat.Module.Order.Processings;
using Socrat.References.Formula;
using Socrat.References.Materials;
using Socrat.References.Menu;
using Socrat.References.Params;
using Socrat.References.Processings;
using Socrat.Shape;
using Socrat.UI.Core;

namespace Socrat.Module.Order
{
    public partial class FxRowFormulaEdit : FxBaseSimpleDialog
    {
        public OrderRow Row { get; set; }
        public Core.Entities.Order Order { get; set; }
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
                if (Row != null && Row.Formula != null && Row.FormulaId != null && !FormulaReloaded)
                {
                    FormulaReloaded = false;
                }
                if (Row != null && Row.Formula == null && ! string.IsNullOrEmpty(Row.FormulaStr))
                {
                    Row.Formula = FormulaParser.Parse(Row.FormulaStr);
                }
                FormulaReloaded = false;
                Row.Formula.PropertyChanged -= _Formula_PropertyChanged;
                Row.Formula.PropertyChanged += _Formula_PropertyChanged;
                Row.Formula.FrameItemGazChanged -= Formula_FrameItemGazChanged;
                Row.Formula.FrameItemGazChanged += Formula_FrameItemGazChanged;

            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Ошибка формулы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Row.Formula;
        }

        private void Formula_FrameItemGazChanged(object sender, FrameItem e)
        {
            TreeListNode _node = GetFocusedNode(e.Id);
            var _colmn = tlFormula.Columns.FirstOrDefault();
            if (_node != null && _colmn != null)
            {
                tlFormula.SetRowCellValue(_node, _colmn, e.NodeCaption);
            }
            Order.OnRowChanged(Row);
        }

        private void _Formula_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateFig();
            if (Row != null)
                Row.Changed = true;
            if (Order != null)
                Order.Changed = true;
            if (e.PropertyName == "Gas")
            {
                UpdateTree();
                Order.OnRowChanged(Row);
            }
           
            teFormulaStr.EditValue = Formula.FormulaStr;
        }

        private FormulaItem _focusedFormulaItem;

        public FxRowFormulaEdit()
        {
            InitializeComponent();

            Load += FxFormulaEdit_Load;
            Activated += FxRowFormulaEdit_Activated;
        }

        private void FxRowFormulaEdit_Activated(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("FxRowFormulaEdit actived");
        }

        private void InitShapeEdit()
        {
            cxShapeEdit = new CxShapeEdit();
            if (Row != null)
            {
                cxShapeEdit.ShapeId = Row?.ShapeId;
                cxShapeEdit.Row = Row;
                if (Row.Shape != null && Row.Shape.ShapeParam != null)
                    Row.Shape.ShapeParam.SetSize(Row.OverallH ?? 1000, Row.OverallW ?? 1000);
                Row.Shape.IsAddAdwansedParams = true;
            }
            pcFig.Controls.Add(cxShapeEdit);
            cxShapeEdit.Dock = DockStyle.Fill;
            cxShapeEdit.DialogOutput += CxShapeEdit_DialogOutput;
            cxShapeEdit.ShapeChanged += CxShapeEdit_ShapeChanged;
        }

        private void CxShapeEdit_ShapeChanged(object sender, EventArgs e)
        {
            if (cxShprosEditor != null)
            {
                cxShprosEditor.ShapeId = Row.ShapeId;
                
                cxShprosEditor.RefreshPictureEdit();
            }
        }

        private void CxShapeEdit_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        protected override void BindData()
        {
            base.BindData();
            Text = GetTitle();
            teFormulaStr.EditValue = Formula.FormulaStr;
            //cxShapeEdit.GetShapeSize(Row.OverallH ?? 1000, Row.OverallW ?? 1000);
        }

        private void FxFormulaEdit_Load(object sender, EventArgs e)
        {
            tlFormula.PopupMenuShowing += TlFormula_PopupMenuShowing;
            UpdateTree();
            UpdateProperties();
            UpdateProcessings();
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
            treeFocusHendeling = true;
            TreeListNode _node =
                tlFormula.AppendNode(new object[] { item.NodeCaption }, parentNode, item.Id);
            foreach (FormulaItem formulaItem in item.FormulaItems.OrderBy(x => x.Position))
            {
                BuiltTreeNodes(formulaItem, _node);
            }
            treeFocusHendeling = false;
        }

        private void UpdateTree(bool skipDefaultFocus = false)
        {
            treeFocusHendeling = true;
            TreeListNode _focusedNode = tlFormula.FocusedNode;
            Guid _id = Guid.Empty;
            if (_focusedNode != null && _focusedNode.Tag != null)
                Guid.TryParse(_focusedNode.Tag.ToString(), out _id);

            tlFormula.BeginUnboundLoad();
            tlFormula.Nodes.Clear();

            TreeListNode _node = null;
            foreach (FormulaItem item in Formula.Items)
            {
                BuiltTreeNodes(item, _node);
            }
            tlFormula.Nodes.FirstOrDefault()?.ExpandAll();
            tlFormula.EndUnboundLoad();
            treeFocusHendeling = false;

            if (!skipDefaultFocus)
            {
                _focusedNode = GetFocusedNode(_id);
                if (_focusedNode == null)
                    _focusedNode = GetFocusedNode(Formula.RootItem.Id);
                if (_focusedNode != null)
                {
                    tlFormula.SetFocusedNode(_focusedNode);
                    tlFormula.SelectNode(_focusedNode);
                }
            }
        }

        private TreeListNode GetFocusedNode(Guid _id)
        {
            Guid _nodeId;
            return tlFormula.FindNode(x => x.Tag != null && Guid.TryParse(x.Tag.ToString(), out _nodeId) && _nodeId == _id);
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
            ParseFormula();
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

        private void ParseFormula()
        {
            try 
            {
                if (teFormulaStr.Text.Length > 0)
                {
                    if (!TestParse(teFormulaStr.Text))
                    {
                        teFormulaStr.Text = Formula.FormulaStr;
                        return;
                    }
                    FormulaParser.Parse(Formula, teFormulaStr.Text);
                    teFormulaStr.EditValue = Formula.FormulaStr;
                }
                UpdateView();
            }
            catch (Exception ex)
            {
                Logger.AddErrorMsgEx(ex.Message, ex);
            }
        }

        private void UpdateView()
        {
            UpdateFig();
            UpdateProperties();
            UpdateProcessings();
            UpdateTree();
        }

        private void UpdateProcessings()
        {
            pcDetails.SuspendLayout();
            pcDetails.Controls.Clear();

            if (FocusedFormulaItem != null)
            switch (FocusedFormulaItem.MaterialEnum)
            {
                case MaterialEnum.GU:
                case MaterialEnum.Triplex:
                case MaterialEnum.Glass:
                    if (_cxProcessings != null)
                        _cxProcessings.Dispose();
                    _cxProcessings = new CxProcessings();
                    _cxProcessings.OrderRow = Row;
                    _cxProcessings.DependedSaving = true;
                    _cxProcessings.FormulaItem = FocusedFormulaItem;
                    _cxProcessings.DeleteItemEvent += CxProcessingsOnDeleteItemEvent;
                    _cxProcessings.NeedViewUpdate += _cxProcessings_NeedViewUpdate;
                    SetDetails(_cxProcessings);
                    break;
                case MaterialEnum.Inset:
                    if (_cxInsetPosition != null)
                        _cxInsetPosition.Dispose();
                    _cxInsetPosition = new CxInsetPosition();
                    _cxInsetPosition.DependedSaving = true;
                    _cxInsetPosition.InsetItem = FocusedFormulaItem as InsetItem;
                    _cxInsetPosition.NeedViewUpdate += _cxInsetItemProperties_NeedUpdateParentView;
                    SetDetails(_cxInsetPosition);
                    break;
                case MaterialEnum.Frame:
                    if (cxShprosEditor != null)
                        cxShprosEditor.Dispose();
                    cxShprosEditor = new CxShprosEditor();
                    cxShprosEditor.ShapeId = Row.ShapeId;
                    cxShprosEditor.Row = Row;
                    SetDetails(cxShprosEditor);
                    break;
            }

            pcDetails.ResumeLayout();
        }

        private void _cxInsetItemProperties_NeedUpdateParentView(object sender, EventArgs e)
        {
            this.SuspendLayout();
            UpdateFig();
            UpdateTree();
            this.ResumeLayout();
        }

        private void _cxProcessings_NeedViewUpdate(object sender, EventArgs e)
        {
            UpdateFormulaStr();
            UpdateTree();
        }

        private void CxProcessingsOnDeleteItemEvent(object sender, ListItemEventArgs e)
        {
            UpdateFormulaStr();
            UpdateTree();
        }

        private void UpdateFormulaStr()
        {
            Formula.RebuildFormulaStr();
            teFormulaStr.Text = Formula.FormulaStr;
        }

        private void UpdateProperties()
        {
                pcProperties.SuspendLayout();
                pcProperties.Controls.Clear();

                InitShapeEdit();

                if (FocusedFormulaItem != null)
                    switch (FocusedFormulaItem.MaterialEnum)
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
                            _cxFrameItemProperies.OrderRow = Row;
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
                        case MaterialEnum.GU:
                            if (_cxItemProperties != null)
                                _cxItemProperties.Dispose();
                            _cxItemProperties = new CxItemProperties();
                            _cxItemProperties.OrderRow = Row;
                            _cxItemProperties.DialogOutput += (sender, args) => { OnDialogOutput(args);};
                            SetupProperties(_cxItemProperties);
                            break;
                    }
                pcProperties.ResumeLayout();
        }

        private void _cxFrameItemProperies_NeedUpdateTree(object sender, EventArgs e)
        {
            UpdateTree();
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
            propertiesControl.NeedUpdateParentView += PropertiesControlOnNeedUpdateParentView;
        }

        private void PropertiesControlOnNeedUpdateParentView(object sender, FormulaItem e)
        {
            UpdateAfterProperitesChanges(e);
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

        private bool treeFocusHendeling = false;
        private void tlFormula_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null)
                return;
            if (!treeFocusHendeling && tlFormula.FocusedNode != null)
            {
                treeFocusHendeling = true;
                try
                {
                    FormulaItem _item = GetNodeItem(tlFormula.FocusedNode);
                    Formula.ResetSelection();
                    if (_item != null)
                       _item.Selected = true;
                    UpdateProperties();
                    UpdateProcessings();
                }
                finally 
                {
                    treeFocusHendeling = false;
                }
            }
            UpdateFig();
        }

        private void teFormulaStr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ParseFormula();
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
            if (_focusedFormulaItem != null && _focusedFormulaItem.MaterialEnum == MaterialEnum.None)
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
                UpdateFig();
                UpdateProperties();
                UpdateProcessings();
                UpdateTree();
            };
            _fx.DialogOutput += FxOnDialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog, this);
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
            OnDialogOutput(ta);
        }

        private void BuildPopupMenu()
        {
            pmTree.ClearLinks();
            MaterialEnum[] _whatCanAppend = null;
            MaterialEnum[] _canChangeTo = null;
            MaterialEnum[] _canSwap = null;
            FormulaItemProcessingEnum[] _canProcess = null;

            if (tlFormula.FocusedNode != null && FocusedFormulaItem != null)
            {
                _whatCanAppend = FocusedFormulaItem.CanAppend;
                _canChangeTo = FocusedFormulaItem.CanChangeTo;
                _canProcess = FocusedFormulaItem.CanProcess;
                _canSwap = FocusedFormulaItem.CanSwap;

                BarButtonItem _SetItem = new BarButtonItem(barManager, "Выбрать");
                _SetItem.BindCommand(new MaterialAddCommand(SetupItem, FocusedFormulaItem.MaterialEnum));
                pmTree.AddItem(_SetItem);
            }
            else
            {
                _whatCanAppend = Formula.CanAppend;
                _canChangeTo = Formula.CanChangeTo;
                _canProcess = Formula.CanProcess;
            }

            if (_canSwap != null && _canSwap.Length > 0)
            {
                BarSubItem _subitem = new BarSubItem(barManager, "Заменить на");
                BarButtonItem _buttonItem = null;
                string _title = String.Empty;
                foreach (MaterialEnum materialEnum in _canSwap)
                {
                    
                    switch (materialEnum)
                    {
                        case MaterialEnum.GU:
                            _title = "Стеклопакет";
                            break;
                        case MaterialEnum.Triplex:
                            _title = "Триплекс";
                            break;
                        case MaterialEnum.Glass:
                            _title = "Стекло";
                            break;
                    }
                    if (!string.IsNullOrEmpty(_title))
                    {
                        _buttonItem = new BarButtonItem(barManager, _title);
                        _buttonItem.BindCommand(new FormulaSwapCommand(FormulaSwap, materialEnum));
                        _subitem.AddItem(_buttonItem);
                    }
                }
                pmTree.AddItem(_subitem);
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

            //добавить слой
            if (tlFormula.FocusedNode != null && FocusedFormulaItem != null
                && (FocusedFormulaItem.MaterialEnum == MaterialEnum.GU || FocusedFormulaItem.MaterialEnum == MaterialEnum.Triplex))
            {
                BarButtonItem _AppendLayer = new BarButtonItem(barManager, "Добавить слой");
                _AppendLayer.BindCommand(new MaterialAddCommand(AppenndLayer, FocusedFormulaItem.MaterialEnum));
                pmTree.AddItem(_AppendLayer);
                pmTree.ItemLinks.Last().BeginGroup = true;
            }


            if (tlFormula.FocusedNode != null && FocusedFormulaItem != null && FocusedFormulaItem.ParentItem != null
               && FocusedFormulaItem.ParentItem.MaterialEnum == MaterialEnum.Triplex)
            {
                BarButtonItem _AppendTiplexFilmLayer = new BarButtonItem(barManager, "Добавить слой пленки");
                _AppendTiplexFilmLayer.BindCommand(new MaterialAddCommand(AppendTiplexFilmLayer,
                    MaterialEnum.TriplexFilm));
                pmTree.AddItem(_AppendTiplexFilmLayer);
            }
        
                //операции
                //if (_canProcess != null && _canProcess.Length > 0)
                //{
                //    BarButtonItem _biProcessing = null;
                //    BarSubItem _processingsSubItem = new BarSubItem(barManager, "Добавить операцию");

                //    for (var _i = 0; _i < _canProcess.Length; _i++)
                //    {
                //        switch (_canProcess[_i])
                //        {
                //            case FormulaItemProcessingEnum.SurfaseProcessing:
                //                _biProcessing = new BarButtonItem(barManager, "Зашитное окрашивание");
                //                _biProcessing.BindCommand(new ProcessingAddCommand(AddProcessing, _canProcess[_i]));
                //                break;
                //        }        
                //    }
                //}

                //копировать в следующий слой
                //задать изделие по формуле
                //BarButtonItem _SetupFormula = new BarButtonItem(barManager, "Задать изделие по формуле");
                //_SetupFormula.BindCommand(new MaterialAddCommand(SetupByFormula, MaterialEnum.Glass));
                //pmTree.AddItem(_SetupFormula);
                //pmTree.ItemLinks.Last().BeginGroup = true;

            //удалить элемент
            if (FocusedFormulaItem != null && !FocusedFormulaItem.IsRoot && FocusedFormulaItem.ParentItem != null
                && FocusedFormulaItem.ParentItem.MaterialEnum != MaterialEnum.Triplex
                && (FocusedFormulaItem.MaterialEnum == MaterialEnum.Glass
                    || FocusedFormulaItem.MaterialEnum == MaterialEnum.Triplex))
            {
                BarButtonItem _DeleteItem = new BarButtonItem(barManager, "Удалить элемент");
                _DeleteItem.BindCommand(new MaterialAddCommand(DeleteFormulaItem, FocusedFormulaItem.MaterialEnum));
                pmTree.AddItem(_DeleteItem);
                pmTree.ItemLinks.Last().BeginGroup = true;
            }

            //удалить элемент пленку триплекса
            if (FocusedFormulaItem != null && !FocusedFormulaItem.IsRoot
                                           && FocusedFormulaItem.MaterialEnum == MaterialEnum.TriplexFilm)
            {
                BarButtonItem _DeleteItem = new BarButtonItem(barManager, "Удалить элемент");
                _DeleteItem.BindCommand(new MaterialAddCommand(DeleteTriplexFilmItem, FocusedFormulaItem.MaterialEnum));
                pmTree.AddItem(_DeleteItem);
                pmTree.ItemLinks.Last().BeginGroup = true;
            }

            //удалить элемент стекло триплекса
            if (FocusedFormulaItem != null && !FocusedFormulaItem.IsRoot 
                                           && FocusedFormulaItem.ParentItem != null
                                           && FocusedFormulaItem.ParentItem.MaterialEnum == MaterialEnum.Triplex
                                           && FocusedFormulaItem.MaterialEnum == MaterialEnum.Glass)
            {
                BarButtonItem _DeleteItem = new BarButtonItem(barManager, "Удалить элемент");
                _DeleteItem.BindCommand(new MaterialAddCommand(DeleteTriplexGlassItem, FocusedFormulaItem.MaterialEnum));
                pmTree.AddItem(_DeleteItem);
                pmTree.ItemLinks.Last().BeginGroup = true;
            }
        }

        private void AppendTiplexFilmLayer(MaterialEnum obj)
        {
            if (FocusedFormulaItem != null && FocusedFormulaItem.ParentItem != null
                && FocusedFormulaItem.ParentItem.MaterialEnum == MaterialEnum.Triplex)
            {
                TriplexItem _parentTriplex = FocusedFormulaItem.ParentItem as TriplexItem;
                TriplexFilmItem _triplexFilmItem = FormulaParser.GetDefaultTriplexFilm();
                if (FocusedFormulaItem.MaterialEnum == MaterialEnum.TriplexFilm)
                {
                    _parentTriplex.AppendNextItem(FocusedFormulaItem, _triplexFilmItem);
                }

                if (FocusedFormulaItem.MaterialEnum == MaterialEnum.Glass)
                {
                    if (_parentTriplex.Items.First().Id == FocusedFormulaItem.Id)
                        _parentTriplex.AppendNextItem(FocusedFormulaItem, _triplexFilmItem);
                    else
                        _parentTriplex.AppendBeforeItem(FocusedFormulaItem, _triplexFilmItem);
                }

                Formula.RebuildFormulaStr();
                teFormulaStr.Text = Formula.FormulaStr;
                UpdateTree(true);

                SetFocusToTreeItem(_triplexFilmItem);
            }
        }


        private void AppenndLayer(MaterialEnum obj)
        {
            if (FocusedFormulaItem != null)
            {
                FormulaItem _item = null;
                switch (FocusedFormulaItem.MaterialEnum)
                {
                    case MaterialEnum.GU:
                        FocusedFormulaItem.AppendItem(FormulaParser.GetDefaultFarme());
                        _item = FormulaParser.GetDefaultGlass();
                        FocusedFormulaItem.AppendItem(_item);
                        break;
                    case MaterialEnum.Triplex:
                        FocusedFormulaItem.AppendItem(FormulaParser.GetDefaultTriplexFilm());
                        _item = FormulaParser.GetDefaultGlass();
                        FocusedFormulaItem.AppendItem(_item);
                        break;
                }
                Formula.RebuildFormulaStr();
                teFormulaStr.Text = Formula.FormulaStr;
                //UpdateFig();
                UpdateTree(true);

                SetFocusToTreeItem(_item);
            }
        }

        private void SetupItem(MaterialEnum obj)
        {
            ChangeToMaterial(obj);
        }

        private void FormulaSwap(MaterialEnum obj)
        {
            switch (obj)
            {
                case MaterialEnum.GU:
                    FormulaParser.Parse(Formula, AppParams.Params[ParamAlias.DefaultSGU]);
                    break;
                case MaterialEnum.Triplex:
                    FormulaParser.Parse(Formula, AppParams.Params[ParamAlias.DefaultTriplex]);
                    break;
                case MaterialEnum.Glass:
                    FormulaParser.Parse(Formula, AppParams.Params[ParamAlias.DefaultItem]);
                    break;
            }
            UpdateFig();
            UpdateTree(true);
            SetFocusToTreeItem(Formula.RootItem);
        }

        private void ClearFormula(MaterialEnum obj)
        {
            DialogResult _dialogResult = XtraMessageBox.Show(
                $"Очистить формулу ?", "Удаление", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (_dialogResult == DialogResult.Yes)
            {
                FormulaParser.Parse(Formula, AppParams.Params[ParamAlias.DefaultItem]);
                UpdateAfterTreeChanges();
            }
        }

        private void DeleteTriplexGlassItem(MaterialEnum obj)
        {
            if (FocusedFormulaItem != null && FocusedFormulaItem.ParentItem != null
                                           && FocusedFormulaItem.ParentItem.MaterialEnum == MaterialEnum.Triplex)
            {
                TriplexItem _parentTriplex = FocusedFormulaItem.ParentItem as TriplexItem;

                //проверка возможности удаления
                int _cnt = _parentTriplex.FormulaItems.Count(x =>
                    x.MaterialEnum == MaterialEnum.Glass || x.MaterialEnum == MaterialEnum.Triplex);
                if (_cnt == 2)
                {
                    XtraMessageBox.Show("Удаление элемента отменено, поскольку нарушает целостность конструкции.", "Удаление",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool?  _selAfterDeleteFirst = null;
                List<FormulaItem> _listForDel = new List<FormulaItem>();
                if (_parentTriplex.Items.First().Id == FocusedFormulaItem.Id)
                {
                    for (var i = 1; i < _parentTriplex.Items.Count; i++)
                    {
                        if (_parentTriplex.Items[i].MaterialEnum == MaterialEnum.TriplexFilm)
                            _listForDel.Add(_parentTriplex.Items[i]);
                        else
                            break;
                    }

                    _selAfterDeleteFirst = true;
                }
                else
                {
                    for (var i = _parentTriplex.Items.IndexOf(FocusedFormulaItem) -1; i >= 0; i--)
                    {
                        if (_parentTriplex.Items[i].MaterialEnum == MaterialEnum.TriplexFilm)
                            _listForDel.Add(_parentTriplex.Items[i]);
                        else
                            break;
                    }
                    _selAfterDeleteFirst = false;
                }

                string _msg = $"Будут удалены элемент {FocusedFormulaItem.NodeCaption} { Environment.NewLine}" +
                              $" и свзанные с ним эементы { Environment.NewLine} {string.Join($",{ Environment.NewLine} ", _listForDel.Select(x => x.NodeCaption))}. { Environment.NewLine}Продолжить?";

                DialogResult _dialogResult = XtraMessageBox.Show(_msg, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    Formula.DeletedItem(FocusedFormulaItem);
                    for (int i = 0; i < _listForDel.Count; i++)
                        Formula.DeletedItem(_listForDel[i]);
                    _listForDel.Clear();

                    Formula.RebuildFormulaStr();
                    teFormulaStr.Text = Formula.FormulaStr;
                    UpdateTree(true);

                    if (_selAfterDeleteFirst == null)
                        SetFocusToTreeItem(_parentTriplex);
                    else if (_selAfterDeleteFirst ?? false)
                        SetFocusToTreeItem(_parentTriplex.Items.First());
                    else
                        SetFocusToTreeItem(_parentTriplex.Items.Last());
                            
                }
            }
        }

        private void DeleteTriplexFilmItem(MaterialEnum obj)
        {
            if (FocusedFormulaItem == null 
                || FocusedFormulaItem.ParentItem == null 
                || FocusedFormulaItem.MaterialEnum != MaterialEnum.TriplexFilm)
                return;

            FormulaItem _prevItem = FocusedFormulaItem.ParentItem.Items
                .Where(x => x.Position < FocusedFormulaItem.Position)
                .OrderBy(x => x.Position).LastOrDefault();

            FormulaItem _nextItem = FocusedFormulaItem.ParentItem.Items
                .Where(x => x.Position > FocusedFormulaItem.Position)
                .OrderBy(x => x.Position).FirstOrDefault();

            if (_prevItem != null && _nextItem != null &&
                (_prevItem.MaterialEnum == MaterialEnum.TriplexFilm
                || _nextItem.MaterialEnum == MaterialEnum.TriplexFilm))
            {
                Formula.DeletedItem(FocusedFormulaItem);
                Formula.RebuildFormulaStr();
                teFormulaStr.Text = Formula.FormulaStr;
                UpdateTree(true);
                SetFocusToTreeItem(_nextItem);
            }
            else
            {
                XtraMessageBox.Show("Удаление элемента отменено, поскольку нарушает целостность конструкции.", "Удаление",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteFormulaItem(MaterialEnum obj)
        {
            if (FocusedFormulaItem == null || FocusedFormulaItem.ParentItem == null)
                return;

            FormulaItem _selItem = FocusedFormulaItem.ParentItem;
            FormulaItem _sublingItem = FocusedFormulaItem.GetSubling();

            //проверка возможности удаления
            int _cnt = _selItem.FormulaItems.Count(x =>
                x.MaterialEnum == MaterialEnum.Glass || x.MaterialEnum == MaterialEnum.Triplex);
            if (_cnt == 2)
            {
                XtraMessageBox.Show("Удаление элемента отменено, поскольку нарушает целостность конструкции.", "Удаление", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isFirst = FocusedFormulaItem.ParentItem.Items.First().Id == FocusedFormulaItem.Id;

            if (_sublingItem == null)
                return;
            string _connrect = String.Empty;
            if (_sublingItem.Position > FocusedFormulaItem.Position)
                _connrect = "следующая";
            else
                _connrect = "предыдущая";
            string _msg = $"Будут удалены элементы {FocusedFormulaItem.NodeCaption} и {_connrect} {_sublingItem.NodeCaption}";

            DialogResult _dialogResult = XtraMessageBox.Show(_msg, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_dialogResult == DialogResult.Yes)
            {
                Formula.DeletedItem(FocusedFormulaItem);
                Formula.DeletedItem(_sublingItem);
                UpdateAfterTreeChanges();

                if (isFirst)
                {
                    SetFocusToTreeItem(_selItem.Items.First());
                    return;
                }

                if (_selItem != null)
                {
                    FormulaItem _lastItem = _selItem.FormulaItems.OrderBy(x => x.Position).Last();
                    if (_lastItem != null)
                        SetFocusToTreeItem(_lastItem);
                    else
                        SetFocusToTreeItem(_selItem);
                }
                else
                {
                    SetFocusToTreeItem(Formula.RootItem);
                }
            }
        }

        private void SetFocusToTreeItem(FormulaItem item)
        {
            if (item != null)
            {
                TreeListNode _focusedNode = GetFocusedNode(item.Id);
                if (_focusedNode != null)
                {
                    tlFormula.SetFocusedNode(_focusedNode);
                    UpdateProperties();
                    UpdateProcessings();
                }
            }
        }

        private void pmTree_BeforePopup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BuildPopupMenu();
        }



        private void UpdateAfterTreeChanges()
        {
            Formula.RebuildFormulaStr();
            teFormulaStr.Text = Formula.FormulaStr;
            UpdateFig();
            UpdateProperties();
            UpdateProcessings();
            UpdateTree();
        }

        private void UpdateAfterProperitesChanges(FormulaItem e)
        {
            TreeListNode _node = GetFocusedNode(e.Id);
            var _colmn = tlFormula.Columns.FirstOrDefault();
            if (_node != null && _colmn != null)
                tlFormula.SetRowCellValue(_node, _colmn, e.NodeCaption);

            if (Formula != null)
            {
                Formula.RebuildFormulaStr();
                teFormulaStr.Text = Formula.FormulaStr;
            }
            UpdateFig();
        }

        private void SetupTriplex(MaterialEnum materialEnum)
        {
            Formula.AddEmptyTriplex(GetMaterialByEnum(materialEnum));
            Formula.Valid = true;
            UpdateFig();
            UpdateProperties();
            UpdateProcessings();
            UpdateTree();
        }

        private void AddProcessing(FormulaItemProcessingEnum processingEnum)
        {
        }

        private void ChangeToMaterial(MaterialEnum materialEnum)
        {
            FxFilteredMaterialNoms _fx = new FxFilteredMaterialNoms();
            _fx.Material = GetMaterialByEnum(materialEnum);
            _fx.SetSingleSelectMode(FocusedFormulaItem?.MaterialNom);
            _fx.ItemSelected += (sender, args) =>
            {
                MaterialNom _nom = _fx.SelectedItem as MaterialNom;
                FormulaItem formulaItem = GetItemByEnum(materialEnum, _nom);
                if (FocusedFormulaItem != null)
                {
                    Formula.ReplaceFormulaItem(FocusedFormulaItem, formulaItem);

                    Formula.RebuildFormulaStr();
                    teFormulaStr.Text = Formula.FormulaStr;

                    UpdateFig();
                    UpdateTree(true);

                    SetFocusToTreeItem(formulaItem);
                }
            };
            _fx.DialogOutput += FxOnDialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog, this);
        }

        private void ChangeToTriplex(MaterialEnum materialEnum)
        {
            TriplexItem _triplexItem = FormulaParser.ParseTriplex(AppParams.Params[ParamAlias.DefaultTriplex]);
            Formula.ReplaceToEptyTriplex(FocusedFormulaItem, _triplexItem);

            Formula.RebuildFormulaStr();
            teFormulaStr.Text = Formula.FormulaStr;

            UpdateFig();
            UpdateTree(true);
            SetFocusToTreeItem(_triplexItem);
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
            bool res = Formula?.Valid ?? false;
            if (!res)
                XtraMessageBox.Show("Изделие введено не полностью и не может быть сохранено.", "Сохранение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            return res;
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