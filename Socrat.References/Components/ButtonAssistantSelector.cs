using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Lib.Interfaces;
using Socrat.UI.Core;
using System.ComponentModel;

namespace Socrat.References.Components
{
    public class ButtonAssistantSelector<T1, T2, T3> : TabableUserControl, INotifyPropertyChanged
        where T1 : Entity, IEntity, new()
        where T2 : class, ISelectionDialogFilterable<T1>, new()
        where T3 : class, IEntityEditor, new()
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected ButtonEdit Button { get; set; } = new ButtonEdit();
        public eButtonsType ButtonsType { get; set; } = eButtonsType.All;
        protected  ButtonEditAssistent<T1, T2, T3> Assistant { get; private set; }
        public T1 SelectorEntity { get; set; }
        public new IEntity Entity { get => SelectorEntity; set => SelectorEntity = value as T1; }

        public ButtonAssistantSelector()
        {
            InitializeComponent();
        }

        protected override void BindingData()
        {
            base.BindingData();
            Entity = GetEntity();
            Assistant = GetAssistant();
            Assistant.BindProperty(this, x => x.SelectorEntity);
        }

        protected virtual T1 GetEntity()
        {
            return null;
        }

        protected virtual ButtonEditAssistent<T1, T2, T3> GetAssistant()
        {
            return new ButtonEditAssistent<T1, T2, T3>(Button, SelectorEntity, OnDialogOutput, ButtonsType, ReadOnly);
        }


        #region Designer

        private void InitializeComponent()
        {
            this.Button = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Button.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Button
            // 
            this.Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button.Location = new System.Drawing.Point(0, 0);
            this.Button.Name = "Button";
            this.Button.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Button.Size = new System.Drawing.Size(287, 20);
            this.Button.TabIndex = 0;
            // 
            // DivisionSelector
            // 
            this.Controls.Add(this.Button);
            this.Name = "DivisionSelector";
            this.Size = new System.Drawing.Size(287, 20);
            ((System.ComponentModel.ISupportInitialize)(this.Button.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
