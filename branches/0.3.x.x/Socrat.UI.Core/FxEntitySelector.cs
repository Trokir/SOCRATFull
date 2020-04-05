using System;
using System.Windows.Forms;
using Socrat.Core;


namespace Socrat.UI.Core
{
    /// <summary>
    /// Форма-хостинг для контрола списка
    /// Чтобы не создавать с уже созданому табличному контролу
    /// такую же по фукционалу форму-список - просто динамически задаем эту форму
    /// и распологаем на ней готовый контрол.
    /// </summary>
    public partial class FxEntitySelector : FxBaseForm, IEntitySelector
    {
        public event EventHandler ItemSelected;

        private IEntitySelector _TableLictControlHost;

        public IEntitySelector TableLictControlHost
        {
            get { return _TableLictControlHost;}
            set { SetLictControl(value); }
        }

        private string _finalTitle = String.Empty;
        public FxEntitySelector(string title)
        {
            InitializeComponent();
            _finalTitle = title;
            this.Text = title;
        }

        private void SetLictControl(IEntitySelector value)
        {
            _TableLictControlHost = value;
            _TableLictControlHost.ItemSelected += _TableLictControlHost_ItemSelected;
            ((ITabable) _TableLictControlHost).DialogOutput += (sender, ta) =>
            {
                OnDialogOutput(ta.NewTab, ta.OutputType);
            };
            this.Controls.Add((Control)_TableLictControlHost);
            ((Control) _TableLictControlHost).Dock = DockStyle.Fill;
        }

        private void _TableLictControlHost_ItemSelected(object sender, EventArgs e)
        {
            OnItemSelected();
        }

        public IEntity SelectedItem
        {
            get => TableLictControlHost.SelectedItem;
        }

        private void OnItemSelected()
        {
            ItemSelected?.Invoke(this, EventArgs.Empty);
            Close();
        }

        protected override string GetTitle()
        {
            return _finalTitle;
        }
    }
}