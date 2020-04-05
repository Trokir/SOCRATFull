using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Materials;

namespace Socrat.References.Formula
{
    public partial class CxFormulaItemProperties : DevExpress.XtraEditors.XtraUserControl, ITabable
    {
        public event EventHandler<FormulaItem> NeedUpdateParentView;
        private List<Socrat.Core.Entities.Material> _materials;


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

        protected void OnNeedUpdateParentView(FormulaItem item)
        {
            NeedUpdateParentView?.Invoke(this, item);
        }

        public void BindLabel(LabelControl label, object obj, string propName)
        {
            label.DataBindings.Clear();
            label.DataBindings.Add("Text", obj, propName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void BindEditor(BaseEdit editor, object obj, string propName)
        {
            editor.DataBindings.Clear();
            editor.DataBindings.Add("EditValue", obj, propName, true, DataSourceUpdateMode.OnPropertyChanged);
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
            editor.DataBindings.Add("EditValue", obj, me.Member.Name, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void FxOnDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        public event EventHandler<WindowOutputEventArgs> DialogOutput;
        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outForm, OutputType = outputType });
        }
        public void OnDialogOutput(WindowOutputEventArgs ta)
        {
            DialogOutput?.Invoke(this, ta);
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

        private Guid _ModuleId;
        public Guid ModuleId
        {
            get => _ModuleId;
            set => _ModuleId = value;
        }

        protected virtual void UpdateComponent()
        {

        }

        protected void SetupMaterial(MaterialEnum materialEnum, FormulaItem item)
        {
            FxFilteredMaterialNoms _fx = new FxFilteredMaterialNoms();
            _fx.Material = GetMaterial(materialEnum);
            _fx.SetSingleSelectMode(item.MaterialNom);
            _fx.ItemSelected += (sender, args) =>
            {
                MaterialNom _nom = _fx.SelectedItem as MaterialNom;
                item.MaterialNom = _nom;
                UpdateComponent();
            };
            _fx.DialogOutput += FxOnDialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private Socrat.Core.Entities.Material GetMaterial(MaterialEnum materialEnum)
        {
            if (_materials == null || _materials.Count < 1)
            {
                using (Socrat.Core.IRepository<Socrat.Core.Entities.Material> _repo = DataHelper.GetRepository<Socrat.Core.Entities.Material>())
                {
                    _materials = _repo.GetAll().ToList();
                }
            }
            return _materials.FirstOrDefault(x => x.MaterialEnum == materialEnum);
        }
    }
}
