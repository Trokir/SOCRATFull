using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.UI.Core;
using Socrat.Core;
using Socrat.DataProvider.Repos;
using Socrat.Core.Entities;


namespace Socrat.Shape.Forms
{
    public partial class FxElementsPack : FxBaseSimpleDialog
    {
        public event EventHandler CheckedElementTypePack;
        private List<string> itemsOrientationList;
        private List<string> itemsTypeList;
        // private FxShprosEditor _fxShprosEditor;
        private ShprosElement shprosElement;
        private FxAxis _fxAxis;
        public Guid MyId { get; private set; }

        public FxElementsPack(Guid? id)
        {
            MyId = id ?? Guid.Empty;
            InitializeComponent();
            //  _fxShprosEditor = new FxShprosEditor();
            Load += FxElementsPack_Load;
            pkbTarget.Click += PkbTarget_Click;
            pkbDirection.Click += PkbDirection_Click;
            txtLeftMargin.EditValueChanged += TxtLeftMargin_EditValueChanged;
            txtRightMargin.EditValueChanged += TxtRightMargin_EditValueChanged;
            txtCount.EditValueChanged += TxtCount_EditValueChanged;
            cmbType.EditValueChanged += CmbType_EditValueChanged;
           
        }

        private void TxtCount_EditValueChanged(object sender, EventArgs e)
        {
            IsCountVal = false;
            txtCount.KeyPress += (s, se) =>
            {
                if (se.KeyChar == (char)Keys.Enter)
                {
                    shprosElement.OrientationType = cmbOrientation.Text;
                    shprosElement.Location = BuildLocationString();
                    shprosElement.Name = BuildNameString();
                    shprosElement.TypeElement = cmbType.Text.Trim();
                    double.TryParse(txtLeftMargin.Text.Trim(), out double lm);
                    shprosElement.LeftMargin = lm;
                    double.TryParse(txtRightMargin.Text.Trim(), out double rm);
                    shprosElement.RightMargin = rm;
                    int.TryParse(txtCount.Text.Trim(), out int count);
                    shprosElement.Count = count;
                    shprosElement.SelectorFlag = 2;
                    IsCountVal = true;
                }
                else
                { return; }
            };
        }
        private void OnCheckedElementType()
        {
            CheckedElementTypePack?.Invoke(this, EventArgs.Empty);
        }
        private void CmbType_EditValueChanged(object sender, EventArgs e)
        {
            shprosElement.Flag = true;
            switch (cmbType.Text)
            {
                case "Прямая":
                    layoutLeft.Text = "Отступ в мм";
                    layoutRight.Text = "Отступ в мм";
                    cmbOrientation.Enabled = true;
                   
                    break;
                case "Дуга":
                    shprosElement.TypeElement = cmbType.Text;
                    OnCheckedElementType();
                    cmbOrientation.Enabled = false;
                    layoutLeft.Text = "Отступ в мм";
                    layoutRight.Text = "Отступ в мм";
                  
                    break;
                case "Луч":
                    shprosElement.TypeElement = cmbType.Text;
                    OnCheckedElementType();
                    cmbOrientation.Enabled = false;
                    layoutLeft.Text = "Отступ в °";
                    layoutRight.Text = "Отступ в °";
                 
                    break;
                default:
                 
                    break;
            }
        }
        private void TxtRightMargin_EditValueChanged(object sender, EventArgs e)
        {
            IsRightVal = false;
            txtRightMargin.KeyPress += (s, se) =>
            {
                if (se.KeyChar == (char)Keys.Enter)
                {
                        shprosElement.OrientationType = cmbOrientation.Text;
                        shprosElement.Location = BuildLocationString();
                        shprosElement.Name = BuildNameString();
                        shprosElement.TypeElement = cmbType.Text.Trim();
                        double.TryParse(txtLeftMargin.Text.Trim(), out double lm);
                        shprosElement.LeftMargin = lm;
                        double.TryParse(txtRightMargin.Text.Trim(), out double rm);
                        shprosElement.RightMargin = rm;
                        int.TryParse(txtCount.Text.Trim(), out int count);
                        shprosElement.Count = count;
                        shprosElement.SelectorFlag = 2;
                        IsRightVal = true;
                }
                else
                { return; }
            };
        }
        public bool IsLeftVal { get; set; }
        public bool IsRightVal { get; set; }
        public bool IsCountVal { get; internal set; }

        private void TxtLeftMargin_EditValueChanged(object sender, EventArgs e)
        {
            IsLeftVal = false;
            txtLeftMargin.KeyPress += (s, se) =>
            {
                if (se.KeyChar == (char)Keys.Enter)
                {
                    if (shprosElement.SideVector == null&&(cmbType.Text=="Дуга"|| cmbType.Text == "Луч"))
                    {
                        XtraMessageBox.Show("Нажмите на пиктограмму с мишенью и выберите направление  привязки", "Внимание",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        shprosElement.OrientationType = cmbOrientation.Text;
                        shprosElement.Location = BuildLocationString();
                        shprosElement.Name = BuildNameString();
                        shprosElement.TypeElement = cmbType.Text.Trim();
                        double.TryParse(txtLeftMargin.Text.Trim(), out double lm);
                        shprosElement.LeftMargin = lm;
                        double.TryParse(txtRightMargin.Text.Trim(), out double rm);
                        shprosElement.RightMargin = rm;
                        int.TryParse(txtCount.Text.Trim(), out int count);
                        shprosElement.Count = count;
                        shprosElement.SelectorFlag = 2;
                        IsLeftVal = true;
                    }
                }
                else
                { return; }
            };



        }
        private void PkbDirection_Click(object sender, EventArgs e)
        {
            if (txtRightMargin.Enabled == true)
            {
                txtRightMargin.Enabled = false;
                txtLeftMargin.Focus();
            }
            else
            {
                txtRightMargin.Enabled = true;
                txtRightMargin.Focus();
            }
        }
        private void PkbTarget_Click(object sender, EventArgs e)
        {
            if (shprosElement.SideDirectionForAxisPack != null && !(cmbType.EditValue is null))
            {
                _fxAxis = new FxAxis();
                _fxAxis.ShprosElement = shprosElement;
                _fxAxis.SaveButtonClick += (s, se) =>
                {
                    var value = shprosElement;
                };
                _fxAxis.DialogOutput += _fxAxis_DialogOutput;
                OnDialogOutput(_fxAxis, DialogOutputType.Dialog);
            }
            else
            {
                XtraMessageBox.Show("Не выбрано направление на поле редактирования !!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void _fxAxis_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e.NewTab, e.OutputType);
        }

        protected override void BindData()
        {
           base.BindData();
            if (!(shprosElement is null))
            {
                cmbType.EditValue = shprosElement.TypeElement;
                cmbOrientation.EditValue = shprosElement.OrientationType;
                txtCount.EditValue = shprosElement.Count;
                txtLeftMargin.EditValue = shprosElement.LeftMargin;
                txtRightMargin.EditValue = shprosElement.RightMargin;
                BindEditor(txtCount, shprosElement, x => x.Count);
                BindEditor(cmbType, shprosElement, x => x.TypeElement);
                BindEditor(cmbOrientation, shprosElement, x => x.OrientationType);
                BindEditor(txtLeftMargin, shprosElement, x => x.LeftMargin);
                BindEditor(txtRightMargin, shprosElement, x => x.RightMargin);
            }
        }
       

        private void FxElementsPack_Load(object sender, EventArgs e)
        {
            cmbOrientation.Properties.NullText = "";
            cmbType.Properties.NullText = "";
            itemsOrientationList = new List<string> { "Вертикаль", "Горизонталь" };
            itemsTypeList = new List<string> { "Прямая", "Дуга", "Луч" };
            cmbOrientation.Properties.DataSource = itemsOrientationList;
            cmbOrientation.Properties.DropDownRows = itemsOrientationList.Count;
            cmbType.Properties.DataSource = itemsTypeList;
            cmbType.Properties.DropDownRows = itemsTypeList.Count;
            txtRightMargin.Enabled = false;
        }
        protected override IEntity GetEntity()
        {
            return shprosElement;
        }
        protected override void SetEntity(IEntity value)
        {
            shprosElement = value as ShprosElement;
        }
        private string BuildNameString()
        {
            using (ShprosElementRepository shprosElement = new ShprosElementRepository())
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Набор");
                if (cmbType.Text == "Дуга")
                {
                    stringBuilder.Append(" (Дуга)");
                }
                return stringBuilder.ToString();
            }
        }
        private string BuildLocationString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(txtCount.Text.Trim());
            stringBuilder.Append(" шт - ");
            stringBuilder.Append(txtLeftMargin.Text.Trim());
            stringBuilder.Append(" / ");
            stringBuilder.Append(txtRightMargin.Text.Trim());
            if (cmbType.Text == "Дуга") { stringBuilder.Append($"  / {shprosElement.SideDirectionForAxisPack} "); }
            stringBuilder.Append("    мм");
            return stringBuilder.ToString();
        }
        public override bool Validate()
        {
            return true;
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> {/* txtCount, txtLeftMargin, cmbType, txtRightMargin, cmbOrientation */};
        }
        protected override void OnSaveButtonClick()
        {
            if (shprosElement != null)
            {
                shprosElement.SelectorFlag = 2;
                int.TryParse(txtCount.Text.Trim(), out int num);
                shprosElement.Count = num;
                shprosElement.OrientationType = (cmbType.Text == "Прямая") ? cmbOrientation.Text : $"Ось ({shprosElement.SideDirectionForAxisPack})";
                shprosElement.Location = BuildLocationString();
                shprosElement.Name = BuildNameString();
            }
            base.OnSaveButtonClick();
        }

       
    }
}
