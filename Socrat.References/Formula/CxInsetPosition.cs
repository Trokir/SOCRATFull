using System;
using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;

namespace Socrat.References.Formula
{
    public partial class CxInsetPosition : CxGenericListTable<InsetPosition>
    {
        public event EventHandler NeedViewUpdate;

        public InsetItem InsetItem { get; set; }

        public CxInsetPosition()
        {
            InitializeComponent();
        }

        protected override ObservableCollection<InsetPosition> GetItems()
        {
            return InsetItem?.InsetItemProperty?.InsetPositions;
        }

        protected override void InitColumns()
        {
            AddColumn("Список вставок", "NumTitle", 200, 0);
            AddColumn("Сторона", "SideTitle", 160, 1);
            AddColumn("Расположение", "Position", 160, 2);
        }

        protected override InsetPosition GetNewInstance()
        {
            return new InsetPosition { InsetItemProperty = this.InsetItem.InsetItemProperty };
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxInsetPositionEdit();
        }

        private void OnNeedViewUpdate()
        {
            NeedViewUpdate?.Invoke(this, EventArgs.Empty);
        }

        protected override void DeleteItem()
        {
            base.DeleteItem();
            OnNeedViewUpdate();
        }
    }
}
