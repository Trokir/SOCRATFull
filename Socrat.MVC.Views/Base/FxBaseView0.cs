using DevExpress.XtraEditors;
using Socrat.Common.Interfaces.MVC;
using Socrat.Common.UI;
using System;
using System.ComponentModel;

namespace Socrat.MVC.Views
{
    public class FxBaseView : XtraForm, IView, ITabable, IBaseForm
    {
        #region Locals

        private IViewModel _viewModel;

        #endregion

        #region Events

        /// <summary>
        /// Вызывается у подписчиков, когда происходит обращение к свойству ViewModel, а оно равно null
        /// </summary>
        public event EventHandler<IViewModel> ViewModelEmpty;

        #endregion

        #region Methods

        /// <summary>
        /// Обертка для вызова подписки ViewModelEmpty
        /// </summary>
        protected virtual void OnViewModelEmpty(IViewModel viewModel)
        {
            ViewModelEmpty?.Invoke(this, viewModel);
        }

        #endregion

        #region IVIew implementation

        public IViewModel ViewModel
        {
            get => GetViewModel(_viewModel);
            set => _viewModel = value;
        }

        public virtual IViewModel GetViewModel(IViewModel viewModel = null)
        {
            if (_viewModel == null)
                OnViewModelEmpty(viewModel);
            return _viewModel;
        }

        #endregion

        #region ITabable implementation

        public event EventHandler<WindowOutputEventArgs> DialogOutput;
        public string Title { get; set; } = "Базовое окно View";
        public DialogOutputType WindowOutputType { get; set; }
        public void ResetDialogOutputSubscribers()
        {
            DialogOutput = null;
        }

        public bool ReadOnly { get; set; } = false;
        public Guid ModuleId { get; set; } = new Guid("00000000-0000-0000-0000-000000000000");
        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType)
        {
            WindowOutputType = outputType;
            DialogOutput?.Invoke(this, new WindowOutputEventArgs(outForm, outputType, this));
        }
        public void OnDialogOutput(WindowOutputEventArgs ta)
        {
            WindowOutputType = ta.OutputType;
            DialogOutput?.Invoke(this, ta);
        }

        #endregion

        public IBaseForm TabParent { get; set; }

        [Bindable(true)]
        public object Selection { get; set; }
        public object Data { get; protected set; }
    }
}
