using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.DataProvider.Repos;
using Socrat.Lib;
using Socrat.Model;
using Socrat.References.Materials;

namespace Socrat.Module.Order
{
    public partial class CxFormulaItemProperties : DevExpress.XtraEditors.XtraUserControl, ITabable
    {
        public event EventHandler NeedUpdateParentView;
        private List<Material> _Materials;

        public CxFormulaItemProperties()
        {
            InitializeComponent();
            Load += CxFigureItemProperties_Load;
        }

        private void CxFigureItemProperties_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public virtual void BindData()
        {
        }

        protected void OnNeedUpdateParentView()
        {
            NeedUpdateParentView?.Invoke(this, EventArgs.Empty);
        }

        public void BindLabel(LabelControl label, object obj, string propName)
        {
            label.DataBindings.Clear();
            label.DataBindings.Add("Text", obj, propName, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void BindEditor(BaseEdit editor, object obj, string propName)
        {
            editor.DataBindings.Clear();
            editor.DataBindings.Add("EditValue", obj, propName, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        /// <summary>
        /// Привязка данных через люмбда-синтаксис
        /// </summary>
        /// <typeparam name="T">тиб обякта данных</typeparam>
        /// <typeparam name="P">тип свойства объекта данных</typeparam>
        /// <param name="editor">редактор</param>
        /// <param name="obj">объект данных</param>
        /// <param name="selectorExpression">лямбда-селестор свойства объекта данных</param>
        public void BindEditor<T, P>(BaseEdit editor, T obj, Expression<Func<T, P>> selectorExpression) where T : class
        {
            if (selectorExpression == null)
                throw new ArgumentNullException("selectorExpression");
            var me = selectorExpression.Body as MemberExpression;

            //внутри функции могут быть вложены свойства равные null
            if (me == null)
            {
                var ue = selectorExpression.Body as UnaryExpression;
                if (ue != null)
                    me = ue.Operand as MemberExpression;
            }

            if (me == null)
                throw new ArgumentException("Тело должно содержать Выражение(Expression)");
            editor.DataBindings.Clear();
            editor.DataBindings.Add("EditValue", obj, me.Member.Name, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void FxOnDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, DialogOutputType.Dialog);
        }

        public event WindowOutputHandler DialogOutput;
        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outForm, OutputType = outputType });
        }

        public string Title
        {
            get => GetTitle();
        }

        private string GetTitle()
        {
            return string.Empty;
        }

        public bool ReadOnly { get; set; }

        protected void SetupMaterial(MaterialEnum materialEnum, FormulaItem item)
        {
            FxFilteredMaterialNoms _fx = new FxFilteredMaterialNoms();
            _fx.Material = GetMaterial(materialEnum);
            _fx.SetSingleSelectMode();
            _fx.ItemSelected += (sender, args) =>
            {
                MaterialNom _nom = _fx.SelectedItem as MaterialNom;
                item.MaterialNom = _nom;
                };
            _fx.DialogOutput += FxOnDialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private Material GetMaterial(MaterialEnum materialEnum)
        {
            if (_Materials == null && _Materials.Count < 1)
            {
                using (MaterialRepository _repo = new MaterialRepository())
                {
                    _Materials = _repo.GetAll().ToList();
                }
            }
            return _Materials.FirstOrDefault(x => x.MaterialEnum == materialEnum);
        }
    }
}
