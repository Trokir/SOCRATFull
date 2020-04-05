using System;
using Socrat.UI.Core;
using Socrat.Core;
using System.Collections.Generic;
using Socrat.DataProvider.Repos;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Socrat.Core.Entities;
using System.Linq;
using System.Collections.ObjectModel;

namespace Socrat.Shape.Forms
{
    public partial class FxElementForm : FxBaseSimpleDialog
    {
        public event EventHandler CheckedElementType;

        private const string SHPROSS_TYPE = "Прямая";
        private List<string> itemsOrientationList;
        private List<string> itemsTypeList;
        private List<string> itemsHorsontalDirectionList;
        private List<string> itemsVerticalDirectionList;
        private double TempLeftMarginValue { get; set; }
        private ShprosElementRepository Repository;
        internal List<ShprosElement> ShprosElementsItems { get; set; }
        public bool IsModifiedElement { get; set; }
        private string MarginType { get; set; }
        private string BaseMarginType { get; set; }
        public double CurrentMaxMarginValue { get; set; }
        public double RelativeMargin { get; set; }
        public double CurrentMaxMarginValueIfCenter { get; set; }
        public ShprosElement ClickedItem { get; set; }
        public Guid MyId { get; private set; }
        private FxAxis _fxAxis;
        private bool Flag { get; set; }
        public string CmbTypeValue { get; set; }
        public bool IsOneOrManyElements { get;  set; }
        ShprosElement shprosElement;
        public FxElementForm(Guid? id)
        {
            InitializeComponent();
            MyId = id ?? Guid.Empty;
            Repository = new ShprosElementRepository();
            Load += FxElementForm_Load;
            cmbType.EditValueChanged += CmbType_EditValueChanged;
            cmbOrientation.EditValueChanged += CmbOrientation_EditValueChanged;
            chkbCenter.CheckedChanged += ChkbCenter_CheckedChanged;
            pkbTarget.Click += PkbTarget_Click;
            tglMarginType.Toggled += TglMarginType_Toggled;
            cmbVektor.Enabled = false;
            cmbOrientation.Enabled = false;
            chkbCenter.Enabled = false;
            txtMargin.Enabled = false;
            tglMarginType.Enabled = false;
            IsOneOrManyElements = true;
            chkbButInputType.CheckedChanged += ChkbButInputType_CheckedChanged;
        }

        private void ChkbButInputType_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkbButInputType.Checked)
            {
                IsOneOrManyElements = false;
                chkbButInputType.Text = "Несколько элементов";
            }
            else
            {
                IsOneOrManyElements = true;
                chkbButInputType.Text = "Один элемент";
            }
        }
        private void FxElementForm_Load(object sender, EventArgs e)
        {
            cmbOrientation.Properties.NullText = "";
            cmbType.Properties.NullText = "";
            cmbVektor.Properties.NullText = "";
            itemsOrientationList = new List<string> { "Вертикаль", "Горизонталь" };
            itemsTypeList = new List<string> { "Прямая", "Дуга" };
            cmbOrientation.Properties.DataSource = itemsOrientationList;
            cmbOrientation.Properties.DropDownRows = itemsOrientationList.Count;
            cmbType.Properties.DataSource = itemsTypeList;
            cmbType.Properties.DropDownRows = itemsTypeList.Count;
        }
        private void TglMarginType_Toggled(object sender, EventArgs e)
        {
            if (tglMarginType.IsOn)
            {
                MarginType = "(Абс)";
                shprosElement.IsRelativeMargin = false;
                if (cmbType.Text == "Прямая")
                {
                    cmbOrientation.Enabled = true;
                    cmbVektor.Enabled = true;
                    chkbCenter.Enabled = true;
                }
            }
            else
            {
                MarginType = "(Отн)";
                shprosElement.IsRelativeMargin = true;
                if (cmbType.Text == "Прямая")
                {
                    cmbOrientation.Enabled = false;
                    cmbVektor.Enabled = false;
                    chkbCenter.Enabled = false;
                }
            }
            layoutCheck.Text = $"{BaseMarginType} {MarginType}";
        }
        private void OnCheckedElementType()
        {
            CheckedElementType?.Invoke(this, EventArgs.Empty);
        }
        private void ChkbCenter_CheckedChanged(object sender, EventArgs e)
        {
            switch (chkbCenter.CheckState)
            {
                case CheckState.Checked:
                    shprosElement.IsCenter = true;
                    txtMargin.EditValue = "";
                    break;
                case CheckState.Indeterminate:
                    break;
                case CheckState.Unchecked:
                    shprosElement.IsCenter = false;
                    break;
            }
        }
        private void PkbTarget_Click(object sender, EventArgs e)
        {
            if ((string)cmbType.EditValue != null)
            {
                if (shprosElement.SideDirectionForAxisPack != null)
                {
                    _fxAxis = new FxAxis();
                    _fxAxis.ShprosElement = shprosElement;
                    _fxAxis.SaveButtonClick += (s, se) =>
                    {
                        var value = shprosElement;
                        switch (cmbType.EditValue)
                        {
                            case "Прямая":
                                cmbOrientation.EditValue = "Горизонталь";
                                if (!itemsHorsontalDirectionList.Contains("Центр"))
                                {
                                    itemsHorsontalDirectionList.Add("Центр");
                                }
                                // cmbVektor.EditValue = value.SideVector;
                                itemsHorsontalDirectionList.Remove("Центр");
                                // txtMargin.EditValue = value.LeftMargin;
                                break;
                            case "Дуга":
                                // txtMargin.EditValue = value.LeftMargin;
                                break;
                        }
                    };
                    _fxAxis.DialogOutput += _fxAxis_DialogOutput;
                    OnDialogOutput(_fxAxis, DialogOutputType.Dialog);
                }
                else
                {
                    XtraMessageBox.Show("Не выбрано напрвление", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("Не выбран тип", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public bool IsVal { get; set; }
        public void EnterPress(KeyPressEventArgs es)
        {
                IsVal = true;
                if (es.KeyChar == (char)Keys.Enter)
                {
                    if (cmbType.Text == "Дуга" && shprosElement.SideVector == null)
                    {
                        IsVal = false;
                        XtraMessageBox.Show("Нажмите на пиктограмму с мишенью и выберите направление", "Внимание",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (!IsModifiedElement)
                        {
                            ObservableMarginValue();
                        }
                        IsVal = true;
                    }
                }
                else { return; }
        }
        protected override void BindData()
        {

            if (shprosElement.IsRelativeMargin is null) { return; }
            else
            {
                if (shprosElement.IsRelativeMargin == true)
                { tglMarginType.IsOn = false; }
                else { tglMarginType.IsOn = true; }
                cmbVektor.Enabled = true;
                cmbOrientation.Enabled = true;
                chkbCenter.Enabled = true;
                txtMargin.Enabled = true;
                tglMarginType.Enabled = true;
                txtMargin.EditValue = (shprosElement.IsRelativeMargin is false) ? shprosElement.LeftMargin : shprosElement.RelativeMargin;
                cmbType.EditValue = shprosElement.TypeElement;
                cmbOrientation.EditValue = shprosElement.OrientationType;
                cmbVektor.EditValue = shprosElement.SideVector;
            }
        }
        #region Ввод и изменение данных
        internal void ChangeRelativeMargins()
        {
            if (ShprosElementsItems is null) { return; }
            var _itemsLineList = ShprosElementsItems.Where(x => x.TypeElement == SHPROSS_TYPE && x.SelectorFlag == 1).ToList();
            var _tempItems = _itemsLineList.Where(t => t.ShprosId == ClickedItem.ChildShprosId).ToList();
            double.TryParse(txtMargin.Text.Trim(), out double val);
            foreach (var item in _itemsLineList)
            {
                var v = CurrentMaxMarginValue;
                TempLeftMarginValue = (item.IsRelativeMargin == true) ? item.RelativeMargin.Value : item.LeftMargin.Value;
                if (item.Id == ClickedItem.Id)
                {
                    if (item.IsRelativeMargin == true)
                    {
                        item.LeftMargin += (val - TempLeftMarginValue);
                        item.RelativeMargin = val;
                    }
                    else
                    {
                        item.LeftMargin = val;
                        item.RelativeMargin = 0.0;
                    }
                    item.Location = BuildLocationChangedString(item.IsRelativeMargin, item.LeftMargin ?? 0, item.RelativeMargin ?? 0);
                    item.Name = BuildNameString();
                    CalculateAllShprossMargins(_itemsLineList, val, item);
                }
            }
        }
        private void CalculateAllShprossMargins(List<ShprosElement> _itemsLineList, double val, ShprosElement item)
        {
            var _subsubIempItems = _itemsLineList.Where(t => t.ShprosId == item.ChildShprosId && t.SideVector == item.SideVector).ToList();
            if (_subsubIempItems.Count > 0)
            {
                foreach (var subItem in _subsubIempItems)
                {
                    subItem.LeftMargin += (val - TempLeftMarginValue);
                    subItem.Location = BuildLocationChangedString(subItem.IsRelativeMargin,
                    subItem.LeftMargin ?? 0, subItem.RelativeMargin ?? 0);
                    subItem.Name = BuildNameString();
                    CalculateAllShprossMargins(_itemsLineList, val, subItem);
                }
            }
        }
        private void ObservableMarginValue()
        {
            shprosElement.SelectorFlag = 1;
            if (tglMarginType.IsOn)
            {

                if (txtMargin.EditValue is null) { return; }
                shprosElement.TypeElement = cmbType.Text.Trim();
                shprosElement.OrientationType = cmbOrientation.Text;
                CurrentMaxMarginValue = Convert.ToDouble(txtMargin.Text.Trim());
                shprosElement.LeftMargin = CurrentMaxMarginValue;
                shprosElement.ShprosId = Guid.Empty;
            }
            else
            {
                if (ClickedItem is null)
                {
                    CurrentMaxMarginValue = Repository.GetMaxMarginOfDirection(cmbVektor.Text.Trim()) +
                                               Convert.ToDouble(txtMargin.Text.Trim());
                    shprosElement.LeftMargin = CurrentMaxMarginValue;
                }
                else
                {
                    if (ClickedItem.IsCenter)
                    {
                        CurrentMaxMarginValue = CurrentMaxMarginValueIfCenter + Convert.ToDouble(txtMargin.Text.Trim());
                    }
                    else
                    {
                        CurrentMaxMarginValue = ClickedItem.LeftMargin.Value + Convert.ToDouble(txtMargin.Text.Trim());
                    }
                    shprosElement.TypeElement = ClickedItem.TypeElement;
                    shprosElement.OrientationType = ClickedItem.OrientationType;
                    shprosElement.LeftMargin = CurrentMaxMarginValue;
                    RelativeMargin = Convert.ToDouble(txtMargin.Text.Trim());
                    shprosElement.RelativeMargin = RelativeMargin;
                    cmbVektor.EditValue = ClickedItem.SideVector;
                    cmbType.EditValue = ClickedItem.TypeElement;
                    cmbOrientation.EditValue = ClickedItem.OrientationType;
                    shprosElement.ShprosId = ClickedItem.ChildShprosId;
                    shprosElement.Location = BuildLocationString();
                    shprosElement.Name = BuildNameString();
                }
            }
            if (cmbType.Text != "Дуга")
            {
                shprosElement.SideVector = cmbVektor.Text.Trim();
            }
            shprosElement.Location = BuildLocationString();
            shprosElement.Name = BuildNameString();
            shprosElement.LeftMargin = CurrentMaxMarginValue;
        }
        #endregion
        private void CmbType_EditValueChanged(object sender, EventArgs e)
        {
            shprosElement.Flag = true;
            switch (cmbType.Text)
            {
                case "Дуга":
                    MarginType = (tglMarginType.IsOn) ? "(Абс)" : "(Отн)";
                    BaseMarginType = "Диаметр в мм.";
                    layoutCheck.Text = $"{BaseMarginType} {MarginType}";
                    CmbTypeValue = cmbType.Text;
                    if (CheckedElementType is null) ;
                    {
                        OnCheckedElementType();
                    }

                    cmbVektor.EditValue = null;
                    cmbVektor.Enabled = false;
                    cmbOrientation.EditValue = null;
                    chkbCenter.Enabled = false;
                    cmbOrientation.Enabled = false;
                    tglMarginType.Enabled = false;
                    txtMargin.Enabled = true;
                    break;
                case "Прямая":
                    MarginType = (tglMarginType.IsOn) ? "(Абс)" : "(Отн)";
                    BaseMarginType = "Отступ в мм.";
                    layoutCheck.Text = $"{BaseMarginType} {MarginType}";
                    cmbVektor.Enabled = true;
                    cmbOrientation.Enabled = true;
                    txtMargin.Enabled = true;
                    chkbCenter.Enabled = true;
                    tglMarginType.Enabled = true;
                    // ChooseDropDownItems();
                    break;
            }
        }
        private void CmbOrientation_EditValueChanged(object sender, EventArgs e)
        {
            ChooseDropDownItems();
        }
        private string BuildNameString()
        {

            using (ShprosElementRepository shprosElement = new ShprosElementRepository())
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Элемент ");
                if (cmbType.Text == "Дуга")
                {
                    stringBuilder.Append(" (Дуга)");
                }
                return stringBuilder.ToString();
            }
        }
        private string BuildLocationChangedString(bool? flag, double marginValue, double relativeValue)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (cmbType.Text == "Прямая")
            {
                switch (cmbVektor.Text)
                {
                    case "Слева":
                        stringBuilder.Append("Л- ");
                        break;
                    case "Справа":
                        stringBuilder.Append("П- ");
                        break;
                    case "Сверху":
                        stringBuilder.Append("В- ");
                        break;
                    case "Снизу":
                        stringBuilder.Append("Н- ");
                        break;
                    case "Центр":
                        stringBuilder.Append("Ц- ");
                        break;
                }
                if (shprosElement.IsCenter == true)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append("Центр ");
                }
                else
                {

                    if (flag == false)
                    {
                        stringBuilder.Append(marginValue);
                        stringBuilder.Append("(Абс)");
                        MarginType = "(Абс)";
                    }
                    else
                    {
                        stringBuilder.Append(marginValue);
                        stringBuilder.Append("(Абс) , ");
                        stringBuilder.Append(relativeValue);
                        stringBuilder.Append("(Отн)");
                    }
                    stringBuilder.Append("    мм");
                }
            }
            else if (cmbType.Text == "Дуга")
            {
                stringBuilder.Append("Ц- ");
                stringBuilder.Append(marginValue);
                stringBuilder.Append($"  / {shprosElement.SideDirectionForAxisPack} ");
                stringBuilder.Append("    мм");
            }
            return stringBuilder.ToString();
        }

        private string BuildLocationString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (cmbType.Text == "Прямая")
            {
                switch (cmbVektor.Text)
                {
                    case "Слева":
                        stringBuilder.Append("Л- ");
                        break;
                    case "Справа":
                        stringBuilder.Append("П- ");
                        break;
                    case "Сверху":
                        stringBuilder.Append("В- ");
                        break;
                    case "Снизу":
                        stringBuilder.Append("Н- ");
                        break;
                    case "Центр":
                        stringBuilder.Append("Ц- ");
                        break;
                }
                if (shprosElement.IsCenter == true)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append("Центр ");
                }
                else
                {

                    if (tglMarginType.IsOn)
                    {
                        stringBuilder.Append(CurrentMaxMarginValue);
                        stringBuilder.Append("(Абс)");
                        MarginType = "(Абс)";
                    }
                    else
                    {
                        stringBuilder.Append(CurrentMaxMarginValue);
                        stringBuilder.Append("(Абс) , ");
                        stringBuilder.Append(txtMargin.Text.Trim());
                        stringBuilder.Append("(Отн)");
                    }
                    stringBuilder.Append("    мм");
                }


            }
            else if (cmbType.Text == "Дуга")
            {
                stringBuilder.Append("Ц- ");
                stringBuilder.Append(txtMargin.Text.Trim());
                stringBuilder.Append($"  / {shprosElement.SideDirectionForAxisPack} ");
                stringBuilder.Append("    мм");
            }

            return stringBuilder.ToString();
        }
        protected override IEntity GetEntity()
        {
            return shprosElement;
        }
        protected override void SetEntity(IEntity value)
        {
            shprosElement = value as ShprosElement;
        }
   
        private void ChooseDropDownItems()
        {
            var value = (cmbOrientation.EditValue is null) ? shprosElement.OrientationType : cmbOrientation.EditValue;
            switch (value)
            {
                case "Вертикаль":
                    itemsVerticalDirectionList = new List<string> { "Слева", "Справа" };
                    cmbVektor.Properties.DataSource = itemsVerticalDirectionList;
                    cmbVektor.Properties.DropDownRows = itemsVerticalDirectionList.Count;
                    break;
                case "Горизонталь":
                    itemsHorsontalDirectionList = new List<string> { "Сверху", "Снизу" };
                    cmbVektor.Properties.DataSource = itemsHorsontalDirectionList;
                    cmbVektor.Properties.DropDownRows = itemsHorsontalDirectionList.Count;
                    break;
            }
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { txtMargin };
        }
        private void _fxAxis_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e.NewTab, e.OutputType);
        }
        protected override void OnSaveButtonClick()
        {
            if (shprosElement != null)
            {
                shprosElement.SelectorFlag = 1;
                if (cmbType.Text != "Дуга")
                {
                    shprosElement.SideVector = cmbVektor.Text.Trim();

                }
                shprosElement.TypeElement = cmbType.Text.Trim();
                shprosElement.OrientationType = (cmbType.Text == "Дуга") ? "Ось" : cmbOrientation.Text.Trim();
                shprosElement.IsCenter = (chkbCenter.Checked) ? true : false;
                shprosElement.IsRelativeMargin = (tglMarginType.IsOn) ? false : true;
                shprosElement.ChildShprosId = Guid.NewGuid();
            }
            base.OnSaveButtonClick();
        }

        public override string ToString()
        {
            return $"Редактор элемента";
        }
    }
}