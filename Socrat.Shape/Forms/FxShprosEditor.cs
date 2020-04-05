using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.UI.Core;
using DevExpress.XtraEditors.Controls;
using Socrat.Shape.Shproses;
using Socrat.Shape.Components;
using Socrat.Core;
using Socrat.Core.Entities;
using System.Collections.Generic;
using Socrat.DataProvider.Repos;
using DevExpress.Utils;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;

namespace Socrat.Shape.Forms
{
    enum ElementType
    {
        Element,
        SetCurciut
    }
    public partial class FxShprosEditor : FxBaseSimpleDialog
    {
        #region Variables
        public event EventHandler GetTotalSizeParameters;
        private ElementType element;
        private Point cursor;
        private List<ShprosElement> _shprosElementsItems;
        private CxShprosElement cxShprosElement;
        private CxShprosBorder cxShprosBorder;
        private ShprosElement shprosElement;
        private ShprosCircuit shprosCircuit;
        private ShprosElementRepository Repository;
        private ShprosCircuitRepository ShprosCircuitRepository;
        private FxElementForm _ef;
        private FxElementsPack _ep;
        private readonly List<string> verticalItems = new List<string> { "Сверху", "Снизу", "Центр", };
        private readonly List<string> horizontalItems = new List<string> { "Слева", "Центр", "Справа" };
        public string Type { get; set; }
        private string Orientation { get; set; }
        private string Direction { get; set; }
        public double AxisMargin { get; set; }
        private float Indent { get; set; }
        private double LeftMargin { get; set; }
        private double RightMargin { get; set; }
        private int Count { get; set; }
        private int SelectorFlag { get; set; }
        private string PropName { get; set; }
        private ContextButton contextButton1 { get; set; }
        private ContextButton contextButton2 { get; set; }
        private ContextButton contextButton3 { get; set; }
        private ContextButton contextButton4 { get; set; }
        public Guid Id_ForOrder { get; set; }
        public BaseShape BShape { get; set; }
        public float XProp { get; private set; }
        public float YProp { get; private set; }
        public bool IsModifiedElement { get; set; }
        #endregion
        public FxShprosEditor(Guid id)
        {
            Id_ForOrder = id;
            InitializeComponent();
            cxShprosElement = new CxShprosElement();
            cxShprosBorder = new CxShprosBorder();
            Repository = new ShprosElementRepository();
            ShprosCircuitRepository = new ShprosCircuitRepository();
            cxShprosElement.CurrentId = Id_ForOrder;
            panelShprosComponent.Controls.Add(cxShprosElement);
            panelShprosBorder.Controls.Add(cxShprosBorder);
            cxShprosElement.Dock = DockStyle.Fill;
            cxShprosBorder.Dock = DockStyle.Fill;
            cxShprosElement.DialogOutput += CxShprosElement_DialogOutput;
            cxShprosElement.gvGrid.RowCellClick += GvGrid_RowCellClick;
            tglClickType.Toggled += TglClickType_Toggled;
            BShape = Shpros<BaseShape>.ShapeTemplate;
            pkbDraw.Properties.SizeMode = PictureSizeMode.Zoom;
            pkbDraw.Properties.ContextMenuStrip = new ContextMenuStrip();
            cxShprosElement.OnCheckCurrentForm += CxShprosElement_OnCheckCurrentForm;
            Load += FxShprosEditor_Load;
            if (_shprosElementsItems == null)
            {
                _shprosElementsItems = new List<ShprosElement>(Repository.GetAll().Where(x => x.ShapeId == Id_ForOrder));
                _shprosElementsItems = SortedCollection();
            }
            cxShprosElement.CheckContextMenuItem += CxShprosElement_CheckContextMenuItem;
            pkbDraw.MouseClick += PkbDraw_MouseClick;
            pkbDraw.MouseDoubleClick += PkbDraw_MouseDoubleClick;
            pkbDraw.MouseMove += (s, e) =>
            {
                ParseCoordinates(e);
            };
            cxShprosElement.DeleteAllItemsEvent += CxShprosElement_DeleteAllEvent;
            cxShprosElement.DeleteItemEvent += CxShprosElement_DeleteItemEvent;
        }

        private void CxShprosElement_DeleteItemEvent(object sender, ListItemEventArgs e)
        {
            if (_shprosElementsItems.Count < 1)
            {
                return;
            }
            else
            {
                if (_ReadyToDeleteItem == null)
                {
                    XtraMessageBox.Show("Не выделено ни одного элемента", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    BShape.OnDeleteItemId = _ReadyToDeleteItem.Id;
                    BShape.IsCanDeleteShprosItem = true;
                    RefreshBaseCollection();
                    BShape.GetAllShprosses = _shprosElementsItems;
                    BShape.IsRefreshColorShprosElement = true;
                    BShape.InitShape(pkbDraw);

                }
            }
        }

        private void CxShprosElement_DeleteAllEvent(object sender, EventArgs e)
        {
            RefreshBaseCollection();
            BShape.GetAllShprosses = _shprosElementsItems;
            BShape.MarkersList.Clear();
            BShape.IsRefreshColorShprosElement = true;
            BShape.InitShape(pkbDraw);
        }

        private void PkbDraw_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!(BShape.ClicklElement is null))
            {
                IsModifiedElement = true;
                ChangeSelectedItemParameters();
            }
            else return;
        }
        public Guid GetCurrentRowId()
        {
            Guid _id = Guid.Empty;
            if (cxShprosElement.gvGrid.GetFocusedRowCellValue("Id") != null)
                Guid.TryParse(cxShprosElement.gvGrid.GetFocusedRowCellValue("Id").ToString(), out _id);
            return _id;
        }
        /// <summary>
        /// Handles the OnCheckCurrentForm event of the CxShprosElement control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CxShprosElement_OnCheckCurrentForm(object sender, EventArgs e)
        {
            IsModifiedElement = true;
            ChangeSelectedItemParameters();
        }
        /// <summary>
        /// Changes the selected item parameters.
        /// </summary>
        private void ChangeSelectedItemParameters()
        {
            IsModifiedElement = true;
            _shprosElementsItems.Clear();
            if (_shprosElementsItems is null) return;
            _shprosElementsItems = new List<ShprosElement>(Repository.GetAll()
                .Where(x => x.ShapeId == Id_ForOrder)
                    .OrderBy(x => x.LeftMargin)
                .OrderBy(x => x.OrientationType)
                .OrderBy(x => x.SideVector));
            var item = _shprosElementsItems.FirstOrDefault(x => x.Id == GetCurrentRowId());
            IEntityEditor _fx = null;
            if (item.Name.Contains("Элемент"))
            {
                element = ElementType.Element;
                _fx = null;
                _fx = GetEditor();
                _ef = _fx as FxElementForm;
                _fx.Entity = item;
                if (_ef != null)
                {
                    _ef.txtMargin.EditValueChanged += TxtMargin_EditValueChanged;
                    _ef.CheckedElementType += (o, args) => CheckAxisForArcElement();
                }
            }
            if (item.Name.Contains("Набор"))
            {
                element = ElementType.SetCurciut;
                _fx = null;
                _fx = GetEditor();
                _ep = _fx as FxElementsPack;
                _fx.Entity = item;
                if (_ep != null)
                {
                    _ep.CheckedElementTypePack += (o, args) => CheckAxisForArcElementPack();
                    _ep.txtLeftMargin.EditValueChanged += TxtLeftMargin_EditValueChanged;
                    _ep.txtRightMargin.EditValueChanged += TxtRightMargin_EditValueChanged;
                    _ep.txtCount.EditValueChanged += TxtCount_EditValueChanged;
                }
            }
            _fx.SaveButtonClick += (_sender, args) =>
            {
                if (!_fx.Entity?.Changed ?? false)
                    return;
                DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (_dialogResult)
                {
                    case DialogResult.Yes:
                        Repository.Save(item);
                        if (!cxShprosElement.Items.Contains(item))
                            cxShprosElement.Items.Add(item);
                        cxShprosElement.gvGrid.RefreshData();
                        break;
                    case DialogResult.No:
                        if (shprosElement.Flag == true)
                        {
                            InitTempComponent();
                            if (_shprosElementsItems.Count == 0) { return; }
                            BShape.IsRefreshColorShprosElement = true;
                            BShape.InitShape(pkbDraw);
                        }
                        else return;

                        break;
                }
                Shpros<BaseShape>.ShapeTemplate.ShprosFlag = true;

            };
            _fx.StartPosition = FormStartPosition.Manual;
            _fx.DialogOutput += _fx_DialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
            ReloadShprossAxisLines();
        }

      

        private void TglClickType_Toggled(object sender, EventArgs e)
        {
            if (!tglClickType.IsOn)
            {
                BShape.IsDrawSideMarkers = false;
                BShape.IsDeleteAllMarkers = true;
                ReloadShprossAxisLines();
            }
            else
            {
                cxShprosElement.SetFocusedRow(Guid.Empty);
                _shprosElementsItems.Clear();
                _shprosElementsItems = new List<ShprosElement>(Repository.GetAll()
              .Where(x => x.ShapeId == Id_ForOrder));
                _shprosElementsItems = SortedCollection();
                foreach (var item in _shprosElementsItems)
                {
                    item.IsSelectedColor = false;
                    _ClickedItem = item;
                    _ReadyToDeleteItem = item;
                }
                BShape.GetAllShprosses.Clear();
                BShape.GetAllShprosses = _shprosElementsItems;
                BShape.IsRefreshColorShprosElement = true;
                BShape.InitShape(pkbDraw);
            }
        }
        private void ParseCoordinates(MouseEventArgs e)
        {
       
            var x = e.X;
            var y = e.Y;
            YProp = e.Y;
            XProp = e.X;
            var pkbDrawW = pkbDraw.Image.Width;
            var pkbDrawH = pkbDraw.Image.Height;

            var pkbDrawWs = pkbDraw.ClientSize.Width;
            var pkbDrawHs = pkbDraw.ClientSize.Height;

            float pic_aspect = (pkbDrawWs) / (float)(pkbDrawHs);
            float img_aspect = pkbDrawW / (float)pkbDrawH;
            if (pic_aspect > img_aspect)
            {
                YProp = (int)((float)pkbDrawH * y / (float)pkbDrawHs);
                float scaled_width = pkbDrawW * pkbDrawHs / pkbDrawH;
                float dx = (pkbDrawWs - scaled_width) / 2;
                XProp = (int)((x - dx) * pkbDrawH / (float)pkbDrawHs);
            }
            else
            {
                XProp = (int)(pkbDrawW * x / (float)pkbDrawWs);
                float scaled_height = pkbDrawH * pkbDrawWs / pkbDrawW;
                float dy = (pkbDrawHs - scaled_height) / 2;
                YProp = (int)((y - dy) * pkbDrawW / pkbDrawWs);
            }
            labelControl1.Text = $"X = {XProp} ,  Y = {YProp}";
            cursor.X = (int)XProp;
            cursor.Y = (int)YProp;
        }
        private void PkbDraw_MouseClick(object sender, MouseEventArgs e)
        {
            if (!tglClickType.IsOn)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        BShape.IsMarkerInsideAxis = true;
                        var point = BShape.CursorPoint;
                        point.PointX = XProp;
                        point.PointY = YProp;
                        ReloadShprossAxisLines();
                        if (!(BShape.ClicklElement is null))
                        {
                            cxShprosElement.SetFocusedRow(BShape.ClicklElement.Id);
                        }
                        ReloadShprossAxisLines();
                        break;
                }
            }
            else
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        BShape.IsDrawSideMarkers = true;
                        var point = BShape.CursorPoint;
                        point.PointX = XProp;
                        point.PointY = YProp;
                        ReloadShprossAxisLines();
                        break;

                    case MouseButtons.Right:
                        BShape.IsDrawSideMarkers = false;
                        BShape.IsDeleteLastMarker = true;
                        ReloadShprossAxisLines();
                        break;
                    case MouseButtons.Middle:
                        BShape.IsDrawSideMarkers = false;
                        BShape.IsDeleteAllMarkers = true;
                        ReloadShprossAxisLines();
                        break;
                    default:
                        break;
                }
            }

        }
        private void FxShprosEditor_Load(object sender, EventArgs e)
        {
            if (BShape != null)
            {
                BShape.InitShape(pkbDraw);
                BShape.IsLoadDefaultShpros = true;
                _shprosElementsItems = SortedCollection();
                BShape.GetAllShprosses = _shprosElementsItems;

                BShape.IsDrawPictureToAnotherWindows = true;
                BShape.Move();
                BShape.InitShape(pkbDraw);
                if (_shprosElementsItems.Count > 0)
                {
                    var itemId = _shprosElementsItems.Where(x => x.SelectorFlag == 1).FirstOrDefault();
                    if (!(itemId is null))
                    {
                        cxShprosElement.SetFocusedRow(itemId.Id);
                    }
                }
            }
        }
        private double LineLength(ShapePoint StartPoint, ShapePoint EndPoint)
        {

            return Math.Round(Math.Sqrt((StartPoint.PointX - EndPoint.PointX) * (StartPoint.PointX - EndPoint.PointX)
                + (StartPoint.PointY - EndPoint.PointY) * (StartPoint.PointY - EndPoint.PointY)), 0); //округленное до двух знаков
        }

        private void CxShprosElement_CheckContextMenuItem(object sender, EventArgs e)
        {
            IsModifiedElement = false;
            SelectMenuItemClick();
        }


        protected ShprosElement _ReadyToDeleteItem { get; set; }
        protected ShprosElement _ClickedItem { get; set; }
        private double _currentMaxMarginValue { get; set; }
        private void GvGrid_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            ReloadShprossAxisLines();
        }
        private void ReloadShprossAxisLines()
        {
            RefreshBaseCollection();
            foreach (var item in _shprosElementsItems)
            {
                var i = GetCurrentRowId();
                if (item.Id == cxShprosElement.GetCurrentRowId())
                {
                    item.IsSelectedColor = true;
                    _ClickedItem = item;
                    _ReadyToDeleteItem = item;
                }
                else { item.IsSelectedColor = false; }
            }
            BShape.GetAllShprosses = _shprosElementsItems;
            BShape.IsRefreshColorShprosElement = true;
            BShape.InitShape(pkbDraw);
        }

        private void RefreshBaseCollection()
        {
            _shprosElementsItems = new List<ShprosElement>(Repository.GetAll().Where(x => x.ShapeId == Id_ForOrder));
            _shprosElementsItems = SortedCollection();
        }

        private void SelectMenuItemClick()
        {

            IEntityEditor _fx = null;
            switch (cxShprosElement.ShprosTypeSelector)
            {
                case "Элемент":
                    element = ElementType.Element;
                    _fx = null;
                    _fx = GetEditor();
                    _ef = _fx as FxElementForm;
                    if (_ef != null)
                    {
                        _ef.txtMargin.EditValueChanged -= TxtMargin_EditValueChanged;
                        _ef.txtMargin.EditValueChanged += TxtMargin_EditValueChanged;
                    }
                    _ef.CheckedElementType += (o, args) => CheckAxisForArcElement();
                    _fx.Entity = SelectEntity();
                    shprosElement.ShapeId = Id_ForOrder;
                    break;
                case "Набор":
                    element = ElementType.SetCurciut;
                    _fx = null;
                    _fx = GetEditor();
                    _ep = _fx as FxElementsPack;
                    if (_ep != null)
                    {
                        _ep.txtLeftMargin.EditValueChanged -= TxtLeftMargin_EditValueChanged;
                        _ep.txtRightMargin.EditValueChanged -= TxtRightMargin_EditValueChanged;
                        _ep.txtCount.EditValueChanged -= TxtCount_EditValueChanged;
                        _ep.txtLeftMargin.EditValueChanged += TxtLeftMargin_EditValueChanged;
                        _ep.txtRightMargin.EditValueChanged += TxtRightMargin_EditValueChanged;
                        _ep.txtCount.EditValueChanged += TxtCount_EditValueChanged;
                        _ep.CheckedElementTypePack += (o, args) => CheckAxisForArcElementPack();
                    }
                    _fx.Entity = SelectEntity();
                    shprosElement.ShapeId = Id_ForOrder;
                    break;
            }
            _fx.SaveButtonClick += (_sender, args) =>
            {
                if (!_fx.Entity?.Changed ?? false)
                    return;
                DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (_dialogResult)
                {
                    case DialogResult.Yes:
                        switch (element)
                        {
                            case ElementType.Element:
                                if (IsOneOrManyElements)
                                {

                                    Repository.Save(shprosElement);
                                    if (!cxShprosElement.Items.Contains(shprosElement))
                                        cxShprosElement.Items.Add(shprosElement);
                                }
                                else
                                {
                                    foreach (var item in TempShprossesElementsList)
                                    {
                                        Debug.WriteLine($"ID = {item.Id}  ShprosId = {item.ShprosId}");
                                    }
                                    Repository.Save(TempShprossesElementsList);
                                    foreach (var item in TempShprossesElementsList)
                                    {
                                        if (!cxShprosElement.Items.Contains(item))
                                            cxShprosElement.Items.Add(item);
                                    }
                                   
                                }
                                TempShprossesElementsList.Clear();
                                BShape.TempShprossesListElements.Clear();
                                pkbDraw.Refresh();
                                cxShprosElement.gvGrid.RefreshData();
                                break;
                            case ElementType.SetCurciut:
                                Repository.Save(shprosElement);
                                if (!cxShprosElement.Items.Contains(shprosElement))
                                    cxShprosElement.Items.Add(shprosElement);
                                cxShprosElement.gvGrid.RefreshData();
                                break;
                            default:
                                break;
                        }
                        break;
                    case DialogResult.No:
                        if (shprosElement.Flag == true)
                        {
                            InitTempComponent();
                            if (_shprosElementsItems.Count == 0)
                            {
                                BShape.TempShprossesListElements.Clear();
                            }
                            else
                            {

                                BShape.RemoveLastItemFromObservableCollection();
                            }
                            BShape.TempShprossesListElements.Clear();
                            RefreshBaseCollection();
                            BShape.GetAllShprosses = _shprosElementsItems;
                            BShape.IsRefreshColorShprosElement = true;
                            BShape.InitShape(pkbDraw);
                        }
                        else return;

                        break;
                    default:
                        break;
                }
                Shpros<BaseShape>.ShapeTemplate.ShprosFlag = true;

            };
            _fx.StartPosition = FormStartPosition.Manual;
            _fx.DialogOutput += _fx_DialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }
        private void CheckAxisForArcElement()
        {

            Type = _ef.CmbTypeValue;
            if (Type == "Дуга")
            {
                DialogResult _dialogResult = XtraMessageBox.Show("По умолчанию выбрана нижняя сторона. \n" +
                    " Если хотите изменить сторону, выберите соответствующую кнопку на изображении. \n " +
                    "Изменить?", "Выбор стороны",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    BShape.IsDrawPictureEditButtons = true;
                    DrawAdwansedPictureEditButtons();
                    contextButton1.Click += ContextButton1_Click;
                    contextButton2.Click += ContextButton1_Click;
                    contextButton3.Click += ContextButton1_Click;
                    contextButton4.Click += ContextButton1_Click;
                }
                if (_dialogResult == DialogResult.No)
                {
                    shprosElement.ComboItems = horizontalItems;
                    shprosElement.SideDirectionForAxisPack = "Снизу";
                    BShape.TempSideVector = "Снизу";
                }

            }
            else
            {
                BShape.IsDrawPictureEditButtons = false;
                if (pkbDraw.Properties.ContextButtons.Count > 0)
                {
                    DisposeContextButtons();
                }
            }
        }
        private void CheckAxisForArcElementPack()
        {

            Type = shprosElement.TypeElement;
            if (Type == "Дуга" || Type == "Луч")
            {
                DialogResult _dialogResult = XtraMessageBox.Show("По умолчанию выбрана нижняя сторона. \n" +
                    " Если хотите изменить сторону, выберите соответствующую кнопку на изображении. \n " +
                    "Изменить?", "Выбор стороны",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    BShape.IsDrawPictureEditButtons = true;
                    DrawAdwansedPictureEditButtons();
                    contextButton1.Click += ContextButton1_Click;
                    contextButton2.Click += ContextButton1_Click;
                    contextButton3.Click += ContextButton1_Click;
                    contextButton4.Click += ContextButton1_Click;
                }
                if (_dialogResult == DialogResult.No)
                {
                    shprosElement.ComboItems = horizontalItems;
                    shprosElement.SideDirectionForAxisPack = "Снизу";
                    BShape.TempSideVector = "Снизу";
                }

            }
            else
            {
                BShape.IsDrawPictureEditButtons = false;
                if (pkbDraw.Properties.ContextButtons.Count > 0)
                {
                    DisposeContextButtons();
                }
            }
        }
        private double GetMarginIfIsCenter()
        {
            double value = 0;
            if (!(_ClickedItem is null) && _ClickedItem.IsCenter is true)
            {
                switch (_ClickedItem.OrientationType)
                {
                    case "Горизонталь":
                        value = BShape.SelectedRect.Height / 2;
                        break;
                    case "Вертикаль":
                        value = BShape.SelectedRect.Width / 2;
                        break;
                }
            }
            return value;
        }

        private void TxtCount_EditValueChanged(object sender, EventArgs e)
        {
            _ep.txtCount.KeyPress -= TxtCount_KeyPress;
            _ep.txtCount.KeyPress += TxtCount_KeyPress;
        }
        private void TxtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_ep.IsCountVal)
            {
                EventForControlsGroup();
            }
        }
        private void TxtRightMargin_EditValueChanged(object sender, EventArgs e)
        {
            _ep.txtRightMargin.KeyPress -= TxtRightMargin_KeyPress;
            _ep.txtRightMargin.KeyPress += TxtRightMargin_KeyPress;
        }
        private void TxtRightMargin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_ep.IsRightVal)
            {
                EventForControlsGroup();
            }
        }
        private void TxtLeftMargin_EditValueChanged(object sender, EventArgs e)
        {
            _ep.txtLeftMargin.KeyPress -= TxtLeftMargin_KeyPress;
            _ep.txtLeftMargin.KeyPress += TxtLeftMargin_KeyPress;
        }
        private void TxtLeftMargin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_ep.IsLeftVal)
            {
                EventForControlsGroup();

            }
        }

        private void EventForControlsGroup()
        {
            BShape.ClickedElement = _shprosElementsItems.Where(x => x.ShapeId == Id_ForOrder &&
            x.Id == GetCurrentRowId()).SingleOrDefault();
            BShape.IsId = Id_ForOrder;
            InitTempComponent();
            RefreshBaseCollection();
            BShape.GetAllShprosses = _shprosElementsItems;
            BShape.DrawTempShprosElement();
            BShape.IsRefreshColorShprosElement = true;
            BShape.InitShape(pkbDraw);
        }

        /// <summary>
        /// Нажатие Enter
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TxtMargin_EditValueChanged(object sender, EventArgs e)
        {
            _ef.txtMargin.KeyPress -= TxtMargin_KeyPress;
            _ef.txtMargin.KeyPress += TxtMargin_KeyPress;
        }

        private void TxtMargin_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {

                if (!(_ClickedItem is null))
                {
                    _ef.ClickedItem = _ClickedItem;
                    if (!IsModifiedElement)
                    {
                        _ef.CurrentMaxMarginValueIfCenter = GetMarginIfIsCenter();
                    }
                }
                _ef.IsModifiedElement = IsModifiedElement;
                _ef.ShprosElementsItems = _shprosElementsItems;


                _ef.EnterPress(e);

                if (!IsModifiedElement)
                {
                    double.TryParse(_ef.txtMargin.Text.Trim(), out double val);
                    if ((val > 0 && shprosElement.IsCenter == false)||(val == 0&& shprosElement.IsCenter == true))
                    {
                        EventForControls();
                    }
                    else
                    {
                        XtraMessageBox.Show("Значение отступа не должно быть 0", "Внимание !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                  _ef.txtMargin.EditValue = 0;
                }
                else
                {
                    EventsForChangedControls();
                }
            }
        }

        private void EventsForChangedControls()
        {
            _ef.ChangeRelativeMargins();
            _shprosElementsItems = SortedCollection();
            BShape.GetAllShprosses = _shprosElementsItems;
            BShape.IsRefreshColorShprosElement = true;
            BShape.InitShape(pkbDraw);
        }
        public List<ShprosElement> TempShprossesElementsList { get; set; }
       = new List<ShprosElement>();
        private void EventForControls()
        {
            BShape.ClickedElement = _shprosElementsItems.Where(x => x.ShapeId == Id_ForOrder &&
            x.Id == GetCurrentRowId()).SingleOrDefault();
            BShape.IsId = Id_ForOrder;
            IsOneOrManyElements = _ef.IsOneOrManyElements;
            InitTempComponent();


            if (IsOneOrManyElements)
            {
                RefreshBaseCollection();
                BShape.GetAllShprosses = _shprosElementsItems;
                BShape.DrawTempShprosElement();
            }
            else
            {
                RefreshBaseCollection();
                BShape.DrawTempShprossesListElements();
                TempShprossesElementsList = BShape.TempShprossesListElements;
            }

            BShape.IsRefreshColorShprosElement = true;
            BShape.InitShape(pkbDraw);
        }
        public void InitTempComponent()
        {
            BShape.IsDrawPictureToAnotherWindows = true;
            switch (element)
            {
                case ElementType.Element:
                    if (shprosElement.OrientationType != null)
                    {
                        Orientation = shprosElement.OrientationType;
                        Type = shprosElement.TypeElement;
                        LeftMargin = shprosElement.LeftMargin ?? 0.0;
                        SelectorFlag = shprosElement.SelectorFlag.Value;
                        Direction = shprosElement.SideVector;
                        AxisMargin = shprosElement.Margin ?? 0.0;
                        IsRelativeMargin = shprosElement.IsRelativeMargin ?? false;
                    }
                    if (Orientation != null)
                    {
                        BShape.Direction = Direction;
                        BShape.Orientation = Orientation;
                        BShape.Type = Type;
                        BShape.SelectorFlag = SelectorFlag;
                        BShape.LeftMargin = LeftMargin;
                        BShape.IsCenter = shprosElement.IsCenter;
                        BShape.AxisMargin = AxisMargin;
                        BShape.IsRelativeMargin = IsRelativeMargin;
                        BShape.RelativeValue = shprosElement.RelativeMargin ?? 0;
                    }
                    break;
                case ElementType.SetCurciut:
                    Orientation = shprosElement.OrientationType;
                    Type = shprosElement.TypeElement;
                    LeftMargin = shprosElement.LeftMargin ?? 0.0;
                    RightMargin = shprosElement.RightMargin ?? 0.0;
                    Count = shprosElement.Count ?? 0;
                    SelectorFlag = shprosElement.SelectorFlag ?? 0;
                    AxisMargin = shprosElement.Margin ?? 0.0;
                    Direction = shprosElement.SideVector;

                    if (Orientation != null)
                    {
                        BShape.Direction = Direction;
                        BShape.Type = Type;
                        BShape.Orientation = Orientation;
                        BShape.Count = Count;
                        BShape.LeftMargin = LeftMargin;
                        BShape.RightMargin = RightMargin;
                        BShape.SelectorFlag = SelectorFlag;
                        BShape.AxisMargin = AxisMargin;
                    }
                    break;
            }
        }

        /// <summary>
        ///Указывает тип отступа
        /// </summary>
        public bool IsRelativeMargin { get; set; }
        /// <summary>
        ///Выбор ввода одного или нескольких элементов
        /// </summary>
        public bool IsOneOrManyElements { get; private set; }
        private List<ShprosElement> SortedCollection()
        {
            var list = new List<ShprosElement>();
            foreach (var item in _shprosElementsItems)
            {
                list.Add(item);
            }
            var shprosesList = list.OrderBy(x => x.LeftMargin)
                .OrderBy(x => x.OrientationType).OrderBy(x => x.SideVector);
            return new List<ShprosElement>(shprosesList);
        }
        private void CxShprosElement_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, ta.OutputType);
        }
        public void SavePicture(PictureEdit edit)
        {
            Image image = pkbDraw.Image.Clone() as Image;
            edit.Properties.SizeMode = PictureSizeMode.Squeeze;
            edit.Image.Dispose();
            edit.Image = image;
        }
        private IEntityEditor GetEditor()
        {
            IEntityEditor obj = null;
            switch (element)
            {
                case ElementType.Element:
                    obj = new FxElementForm(Id_ForOrder);
                    break;
                case ElementType.SetCurciut:
                    obj = new FxElementsPack(Id_ForOrder);
                    break;
            }
            return obj;
        }
        private IEntity SelectEntity()
        {
            IEntity obj = null;
            switch (element)
            {
                case ElementType.Element:
                    shprosElement = new ShprosElement();
                    obj = shprosElement;
                    break;
                case ElementType.SetCurciut:
                    shprosElement = new ShprosElement();
                    obj = shprosElement;
                    break;
            }
            return obj;
        }
        public override bool Validate()
        {
            return true;
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>() { };
        }
        protected override IEntity GetEntity()
        {
            return SelectEntity();
        }
        protected override void SetEntity(IEntity value)
        {
            IEntity obj = null;
            switch (element)
            {
                case ElementType.Element:
                    shprosElement = new ShprosElement();
                    obj = shprosElement;
                    obj = value as ShprosElement;
                    break;
                case ElementType.SetCurciut:
                    shprosCircuit = new ShprosCircuit();
                    obj = shprosCircuit;
                    obj = value as ShprosCircuit;
                    break;
            }
        }
        private void DisposeContextButtons()
        {
            pkbDraw.Properties.ContextButtons.Remove(contextButton1);
            pkbDraw.Properties.ContextButtons.Remove(contextButton2);
            pkbDraw.Properties.ContextButtons.Remove(contextButton3);
            pkbDraw.Properties.ContextButtons.Remove(contextButton4);
            pkbDraw.Properties.ContextButtons.Clear();
            contextButton1.Click -= ContextButton1_Click;
            contextButton2.Click -= ContextButton1_Click;
            contextButton3.Click -= ContextButton1_Click;
            contextButton4.Click -= ContextButton1_Click;
        }
        private void ContextButton1_Click(object sender, ContextItemClickEventArgs e)
        {
            EnableChoosingSide(sender);
        }
        private void EnableChoosingSide(object sender)
        {
            try
            {
                switch (((ContextButton)sender).Name)
                {
                    case "btnContextTop":
                        shprosElement.ComboItems.Clear();
                        shprosElement.ComboItems = horizontalItems;
                        shprosElement.SideDirectionForAxisPack = "Сверху";
                        BShape.TempSideVector = "Сверху";
                        DisposeContextButtons();
                        break;
                    case "btnContextBottom":
                        shprosElement.ComboItems.Clear();
                        shprosElement.ComboItems = horizontalItems;
                        shprosElement.SideDirectionForAxisPack = "Снизу";
                        BShape.TempSideVector = "Снизу";
                        DisposeContextButtons();
                        pkbDraw.Refresh();
                        break;
                    case "btnContextLeft":
                        shprosElement.ComboItems.Clear();
                        shprosElement.ComboItems = verticalItems;
                        shprosElement.SideDirectionForAxisPack = "Слева";
                        BShape.TempSideVector = "Слева";
                        DisposeContextButtons();
                        break;
                    case "btnContextRight":
                        shprosElement.ComboItems.Clear();
                        shprosElement.ComboItems = verticalItems;
                        shprosElement.SideDirectionForAxisPack = "Справа";
                        BShape.TempSideVector = "Справа";
                        DisposeContextButtons();
                        break;
                    default:
                        BShape.TempSideVector = null;
                        DisposeContextButtons();
                        break;
                }

                InitTempComponent();
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }
        private ContextButton GetNewContextButton() => new ContextButton();
        private void DrawAdwansedPictureEditButtons()
        {
            contextButton1 = GetNewContextButton();
            contextButton2 = GetNewContextButton();
            contextButton3 = GetNewContextButton();
            contextButton4 = GetNewContextButton();
            contextButton1.AlignmentOptions.Position = ContextItemPosition.Center;
            contextButton1.AppearanceHover.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            contextButton1.AppearanceHover.BackColor2 = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            contextButton1.AppearanceHover.BorderColor = Color.Black;
            contextButton1.AppearanceHover.Options.UseBackColor = true;
            contextButton1.AppearanceHover.Options.UseBorderColor = true;
            contextButton1.AppearanceHover.Options.UseTextOptions = true;
            contextButton1.AppearanceHover.TextOptions.HAlignment = HorzAlignment.Center;
            contextButton1.AppearanceHover.TextOptions.HotkeyPrefix = HKeyPrefix.Show;
            contextButton1.AppearanceHover.TextOptions.VAlignment = VertAlignment.Center;
            contextButton1.AppearanceHover.TextOptions.WordWrap = WordWrap.NoWrap;
            contextButton1.AppearanceNormal.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            contextButton1.AppearanceNormal.BackColor2 = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            contextButton1.AppearanceNormal.BorderColor = Color.Black;
            contextButton1.AppearanceNormal.ForeColor = Color.Black;
            contextButton1.AppearanceNormal.Options.UseBackColor = true;
            contextButton1.AppearanceNormal.Options.UseBorderColor = true;
            contextButton1.AppearanceNormal.Options.UseForeColor = true;
            contextButton1.AppearanceNormal.Options.UseTextOptions = true;
            contextButton1.AppearanceNormal.TextOptions.HAlignment = HorzAlignment.Center;
            contextButton1.AppearanceNormal.TextOptions.HotkeyPrefix = HKeyPrefix.Show;
            contextButton1.AppearanceNormal.TextOptions.VAlignment = VertAlignment.Center;
            contextButton1.AppearanceNormal.TextOptions.WordWrap = WordWrap.NoWrap;
            contextButton1.Caption = "Сверху";
            contextButton1.Height = 25;
            contextButton1.Id = new Guid("a18ae86d-c824-4196-9c06-02e4ca8a3749");
            contextButton1.Name = "btnContextTop";
            contextButton1.Width = 60;
            contextButton1.AppearanceNormal.Font = new System.Drawing.Font("Tahoma", 12F);
            contextButton2.AlignmentOptions.Panel = ContextItemPanel.Left;
            contextButton2.AlignmentOptions.Position = ContextItemPosition.Center;
            contextButton2.AnchorAlignment = AnchorAlignment.Left;
            contextButton2.AppearanceHover.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            contextButton2.AppearanceHover.BackColor2 = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            contextButton2.AppearanceHover.BorderColor = Color.Black;
            contextButton2.AppearanceHover.ForeColor = Color.Red;
            contextButton2.AppearanceHover.Options.UseBackColor = true;
            contextButton2.AppearanceHover.Options.UseBorderColor = true;
            contextButton2.AppearanceHover.Options.UseForeColor = true;
            contextButton2.AppearanceNormal.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            contextButton2.AppearanceNormal.BackColor2 = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            contextButton2.AppearanceNormal.BorderColor = Color.Black;
            contextButton2.AppearanceNormal.ForeColor = Color.Black;
            contextButton2.AppearanceNormal.Options.UseBackColor = true;
            contextButton2.AppearanceNormal.Options.UseBorderColor = true;
            contextButton2.AppearanceNormal.Options.UseForeColor = true;
            contextButton2.Caption = "Слева";
            contextButton2.Id = new Guid("f846b43f-57c9-46bd-81be-f0d7bc7b4cb7");
            contextButton2.Name = "btnContextLeft";
            contextButton2.Height = 60;
            contextButton2.Width = 25;
            contextButton2.AppearanceNormal.Font = new Font("Tahoma", 12F);
            contextButton3.AlignmentOptions.Panel = ContextItemPanel.Right;
            contextButton3.AlignmentOptions.Position = ContextItemPosition.Center;
            contextButton3.AppearanceHover.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            contextButton3.AppearanceHover.BackColor2 = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            contextButton3.AppearanceHover.BorderColor = Color.Black;
            contextButton3.AppearanceHover.ForeColor = Color.Red;
            contextButton3.AppearanceHover.Options.UseBackColor = true;
            contextButton3.AppearanceHover.Options.UseBorderColor = true;
            contextButton3.AppearanceHover.Options.UseForeColor = true;
            contextButton3.AppearanceNormal.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            contextButton3.AppearanceNormal.BackColor2 = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            contextButton3.AppearanceNormal.BorderColor = Color.Black;
            contextButton3.AppearanceNormal.ForeColor = Color.Black;
            contextButton3.AppearanceNormal.Options.UseBackColor = true;
            contextButton3.AppearanceNormal.Options.UseBorderColor = true;
            contextButton3.AppearanceNormal.Options.UseForeColor = true;
            contextButton3.Caption = "Справа";
            contextButton3.Height = 60;
            contextButton3.Id = new Guid("85ccb5ec-e7e6-49f6-b7e0-77f72f901b7c");
            contextButton3.Name = "btnContextRight";
            contextButton3.Width = 25;
            contextButton3.AppearanceNormal.Font = new Font("Tahoma", 12F);
            contextButton4.AlignmentOptions.Panel = ContextItemPanel.Bottom;
            contextButton4.AlignmentOptions.Position = ContextItemPosition.Center;
            contextButton4.AppearanceHover.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            contextButton4.AppearanceHover.BackColor2 = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            contextButton4.AppearanceHover.BorderColor = Color.Black;
            contextButton4.AppearanceHover.ForeColor = Color.Red;
            contextButton4.AppearanceHover.Options.UseBackColor = true;
            contextButton4.AppearanceHover.Options.UseBorderColor = true;
            contextButton4.AppearanceHover.Options.UseForeColor = true;
            contextButton4.AppearanceNormal.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            contextButton4.AppearanceNormal.BackColor2 = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            contextButton4.AppearanceNormal.BorderColor = Color.Black;
            contextButton4.AppearanceNormal.ForeColor = Color.Black;
            contextButton4.AppearanceNormal.Options.UseBackColor = true;
            contextButton4.AppearanceNormal.Options.UseBorderColor = true;
            contextButton4.AppearanceNormal.Options.UseForeColor = true;
            contextButton4.Caption = "Снизу";
            contextButton4.Height = 25;
            contextButton4.Id = new Guid("41df8106-374d-4c03-a462-8497299fdf76");
            contextButton4.Name = "btnContextBottom";
            contextButton4.Width = 60;
            contextButton4.AppearanceNormal.Font = new Font("Tahoma", 12F);
            pkbDraw.Properties.ContextButtons.Add(contextButton1);
            pkbDraw.Properties.ContextButtons.Add(contextButton2);
            pkbDraw.Properties.ContextButtons.Add(contextButton3);
            pkbDraw.Properties.ContextButtons.Add(contextButton4);

        }
        public double ShprosLengthValue { get; set; }
        protected override void OnSaveButtonClick()
        {
            DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. ", "Завершение",
                  MessageBoxButtons.OK, MessageBoxIcon.Question);
            switch (_dialogResult)
            {
                case DialogResult.OK:
                    GetTotalSizeParameters?.Invoke(this, EventArgs.Empty);
                    break;
            }


            base.OnSaveButtonClick();
        }
    }
}