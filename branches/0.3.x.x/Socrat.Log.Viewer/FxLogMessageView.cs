using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Log.Models;
using Socrat.UI.Core;

namespace Socrat.Log.Viewer
{
    public partial class FxLogMessageView : FxBaseForm
    {
        public LogItem Item { get; set; }

        public FxLogMessageView()
        {
            InitializeComponent();
            Load += FxLogMessageView_Load;
        }

        private void FxLogMessageView_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
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

        private void BindData()
        {
            BindEditor(teDate, Item, x => x.Date);
            BindEditor(teUser, Item, x => x.User);
            BindEditor(teVersion, Item, x=> x.Version);
            BindEditor(teApp, Item, x => x.Application);
            BindEditor(teMashine, Item, x => x.MachineName);
            BindEditor(teHeader, Item, x => x.Header);
            BindEditor(meMessage, Item, x => x.Message);
            if (Item.Ex != null)
            {
                meErMessage.Text = Item.Ex.Message;
                meErrStack.Text = Item.Ex.StackTrace;
            }
            else
            {
                meErMessage.Hide();
                meErrStack.Hide();
            }
        }
    }
}