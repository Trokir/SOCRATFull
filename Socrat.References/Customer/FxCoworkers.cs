using Socrat.Core;
using Socrat.Lib.Interfaces;
using Socrat.UI.Core;
using System;
using System.Linq.Expressions;

namespace Socrat.References.Customer
{
    public class FxCoworkers : FxBaseForm, ISelectionDialogFilterable<Core.Entities.Coworker>
    {
        private CxCoworkers cxCoworkers;

        public FxCoworkers()
        {
            InitializeComponent();
        }

        public Expression<Func<Core.Entities.Coworker, bool>> ExternalFilterExp
        {
            get => cxCoworkers.ExternalFilterExp;
            set => cxCoworkers.ExternalFilterExp = value;
        }

        public Expression<Func<Core.Entities.Coworker, bool>> ExternalPostFilterExp
        {
            get => cxCoworkers.ExternalFilterExp2;
            set => cxCoworkers.ExternalFilterExp2 = value;
        }

        public IEntity SelectedItem => cxCoworkers.SelectedItem;

        public event EventHandler ItemSelected;

        public void SetSingleSelectMode(IEntity selectedItem)
        {
            if (selectedItem is Core.Entities.Coworker coworker)
                cxCoworkers.SetSingleSelectMode(coworker);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxCustomerAddresses));
            this.cxCoworkers = new CxCoworkers();
            this.SuspendLayout();
            // 
            // cxCustomerAddresses
            // 
            this.cxCoworkers.ActionPaneVisible = false;
            this.cxCoworkers.BottomPaneVisible = true;
            this.cxCoworkers.CanAdd = true;
            this.cxCoworkers.CanDelete = true;
            this.cxCoworkers.CanOpen = true;
            this.cxCoworkers.DependedSaving = false;
            this.cxCoworkers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cxCoworkers.ExternalFilterExp = null;
            this.cxCoworkers.ExternalFilterExp2 = null;
            this.cxCoworkers.FilterVisible = false;
            this.cxCoworkers.FocusedEntity = null;
            this.cxCoworkers.GroupPaneVisible = false;
            this.cxCoworkers.HeaderText = "Табличная форма";
            this.cxCoworkers.Location = new System.Drawing.Point(0, 0);
            this.cxCoworkers.ModuleId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cxCoworkers.MultiSelect = false;
            this.cxCoworkers.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            this.cxCoworkers.Name = "cxCustomerAddresses";
            this.cxCoworkers.ReadOnly = false;
            this.cxCoworkers.RestoreUserGridSettings = false;
            this.cxCoworkers.RightPaneVisible = true;
            this.cxCoworkers.RowHighlightingExp = null;
            this.cxCoworkers.SearchPaneVisible = false;
            this.cxCoworkers.SelectedItem = null;
            this.cxCoworkers.Size = new System.Drawing.Size(697, 400);
            this.cxCoworkers.SourceItems = null;
            this.cxCoworkers.TabIndex = 0;
            this.cxCoworkers.TopPaneVisible = false;
            // 
            // FxCustomerAddresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(697, 400);
            this.Controls.Add(this.cxCoworkers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxCoworkers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Персоналии";
            this.ResumeLayout(false);

        }
    }
}
