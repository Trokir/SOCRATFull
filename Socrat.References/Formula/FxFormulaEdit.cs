using System;
using System.Collections.Generic;
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
using Socrat.Log;
using Socrat.References.Materials;
using Socrat.References.Menu;
using Socrat.References.Params;
using Socrat.UI.Core;
using FormulaItem = Socrat.Core.Entities.FormulaItem;
using GlassItem = Socrat.Core.Added.GlassItem;
using TriplexFilmItem = Socrat.Core.Added.TriplexFilmItem;
using TriplexItem = Socrat.Core.Added.TriplexItem;


namespace Socrat.References.Formula
{
    public partial class FxFormulaEdit : FxBaseSimpleDialog
    {
        TreeListNode _treeClickedNode = null;
        private CxGlassItemProperties _cxGlassItemProperties;
        private CxFrameItemProperies _cxFrameItemProperies;
        private List<Socrat.Core.Entities.Material> _materials;
        public bool FormulaChanged { get; set; } = false;

        private Core.Entities.Formula _Formula;
        public Core.Entities.Formula Formula
        {
            get { return GetFormula(); }
            set { SetFormula(value); }
        }

        private void SetFormula(Core.Entities.Formula value)
        {
            _Formula = value;
            if (_Formula != null)
            {
                _Formula.PropertyChanged -= _Formula_PropertyChanged;
                _Formula.PropertyChanged += _Formula_PropertyChanged;
            }
        }

        public FormulaItem FocusedFormulaItem { get => GetFocusedFormulaItem(); set => _focusedFormulaItem = value; }

        private Core.Entities.Formula GetFormula()
        {
            return _Formula;
        }

        private void _Formula_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateFig();
        }

        //private Graphics graphics;
        private FormulaItem _focusedFormulaItem;
        public FxFormulaEdit()
        {
            InitializeComponent();
            Load += FxFormulaEdit_Load;
        }

        private void CxShapeEdit_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
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
            //LoadFormulaItems(Formula);
            UpdateTree();
            tlFormula.FocusedNode = tlFormula?.Nodes.FirstNode;
        }

        private void TlFormula_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            var hitInfo = (sender as TreeList).CalcHitInfo(e.Point);

            if (hitInfo.HitInfoType == HitInfoType.RowIndicator)
            {
                _treeClickedNode = hitInfo.Node;
            }

            biChangeTo.Enabled = _treeClickedNode != null;
            biCopyToNextLayer.Enabled = _treeClickedNode != null;
            biDelete.Enabled = _treeClickedNode != null;

        }

        private void BuiltTreeNodes(FormulaItem item, TreeListNode parentNode)
        {
            TreeListNode _node =
                tlFormula.AppendNode(new object[] { item.NodeCaption }, parentNode, item);
            foreach (FormulaItem formulaItem in item.FormulaItems.OrderBy(x => x.Position))
            {
                BuiltTreeNodes(formulaItem, _node);
            }
        }

        private void UpdateTree()
        {
            tlFormula.Nodes.Clear();
            tlFormula.BeginUnboundLoad();
            TreeListNode _node = null;
            foreach (FormulaItem item in Formula.Items)
            {
                BuiltTreeNodes(item, _node);
            }
            tlFormula.Nodes.FirstOrDefault().ExpandAll();
            tlFormula.EndUnboundLoad();

        }

        protected override IEntity GetEntity()
        {
            return Formula;
        }

        protected override void SetEntity(IEntity value)
        {
            Formula = value as Socrat.Core.Entities.Formula;
        }

        private void btnParseFormula_Click(object sender, System.EventArgs e)
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
        }

        private void UpdateProperties()
        {
            if (FocusedFormulaItem != null)
            {
                pcProperties.SuspendLayout();
                pcProperties.Controls.Clear();
                MaterialEnum _material = FocusedFormulaItem.MaterialEnum;
                switch (_material)
                {
                    case MaterialEnum.Glass:
                        if (_cxGlassItemProperties != null)
                            _cxGlassItemProperties.Dispose();
                        _cxGlassItemProperties = new CxGlassItemProperties();
                        _cxGlassItemProperties.GlassItem = FocusedFormulaItem as GlassItem;
                        SetupPropertiesControl(_cxGlassItemProperties);
                        break;
                    case MaterialEnum.Frame:
                        if (_cxFrameItemProperies != null)
                            _cxFrameItemProperies.Dispose();
                        _cxFrameItemProperies = new CxFrameItemProperies();
                        _cxFrameItemProperies.FrameItem = FocusedFormulaItem as FrameItem;
                        SetupPropertiesControl(_cxFrameItemProperies);
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
            propertiesControl.NeedUpdateParentView += PropertiesControlOnNeedUpdateParentView;
        }

        private void PropertiesControlOnNeedUpdateParentView(object sender, FormulaItem e)
        {
            UpdateAfterTreeChanges();
        }

        private void UpdateFig()
        {
            if (!Formula.Valid)
                return;
            Image img = new Bitmap(peFig.ClientRectangle.Height, peFig.ClientRectangle.Width);
            using (Graphics graph = Graphics.FromImage(img))
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

        private void tlFormula_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (tlFormula.FocusedNode != null)
            {
                FormulaItem _item = tlFormula.FocusedNode.Tag as FormulaItem;
                Formula.ResetSelection();
                if (_item != null)
                    _item.Selected = true;
                UpdateProperties();
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
            };
            _fx.DialogOutput += FxOnDialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog, this);
        }

        private Socrat.Core.Entities.Material GetMaterialByEnum(MaterialEnum materialEnum)
        {
            if (_materials == null || _materials.Count < 1)
            {
                using (Socrat.Core.IRepository<Socrat.Core.Entities.Material> _repo = DataHelper.GetRepository<Socrat.Core.Entities.Material>())
                {
                    _materials = _repo.GetAll().ToList();
                }
            }
            return _materials.FirstOrDefault(x => x.MaterialEnum == materialEnum);

            return null;
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
                    }

                    if (!string.IsNullOrEmpty(_title))
                    {
                        _buttonItem = new BarButtonItem(barManager, _title);
                        _buttonItem.BindCommand(new MaterialAddCommand(SetupMaterial, _material));
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
                //if (Formula.RootItem.Items.Count < 1)
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
            Core.Entities.Formula _triplexFormula = FormulaParser.Parse(AppParams.Params[ParamAlias.DefaultTriplex]);
            Formula.ReplaceToEptyTriplex(FocusedFormulaItem, _triplexFormula.RootItem);
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
                }
            };
            _fx.DialogOutput += FxOnDialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog, this);
        }

        private FormulaItem GetItemByEnum(MaterialEnum materialEnum, MaterialNom nom)
        {
            Material _material = GetMaterialByEnum(materialEnum);
            switch (materialEnum)
            {
                case MaterialEnum.Glass:
                    return new GlassItem { Material = _material, ItemStr = nom.Code, MaterialNom = nom };
                case MaterialEnum.Frame:
                    return new FrameItem { Material = _material, ItemStr = nom.Code, MaterialNom = nom };
                case MaterialEnum.TriplexFilm:
                    return new TriplexFilmItem { Material = _material, ItemStr = nom.Code, MaterialNom = nom };
                case MaterialEnum.Triplex:
                    return new TriplexItem { ItemStr = nom.Code, MaterialNom = nom, Formula = this.Formula };
                case MaterialEnum.Film:
                    return new FilmItem { Material = _material, ItemStr = nom.Code, MaterialNom = nom };
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
                base.OnSaveButtonClick();
                FormulaChanged = true;
                _Formula.Changed = false;

            }
        }


        //private void LoadFormulaItems(Core.Entities.Formula formula)
        //{
            //this.ShowSplashScreen();
            //using (Socrat.Core.IRepository<Socrat.Core.Entities.FormulaItem> _repo = DataHelper.GetRepository<FormulaItem>())
            //{
            //    //var _items = _repo.GetIncludeAll<DataProvider.FormulaItem>(x => x.Formula.Id == formula.Id, s => s.Formula);
            //    var _items = _repo.GetAll(x => x.FormulaId == formula.Id);
            //    //formula.LoadFormulaItems(_items);
            //}
            //this.HideSplashScreen();
        //}

        protected override string GetTitle()
        {
            return $"Формула изделия {_Formula?.FormulaStr})";
        }

        private void peFig_Resize(object sender, EventArgs e)
        {
            UpdateFig();
        }
    }
}