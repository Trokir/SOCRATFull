using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Socrat.Core;
using Socrat.References;
using Socrat.Shape.Factory;
using Socrat.Shape.Forms;

namespace Socrat.Shape
{
    public partial class CxShapeOrderEditor : CxGenericListTable<Core.Entities.Shape>
    {

        ObservableCollection<Core.Entities.Shape> _items;
     

        public CxShapeOrderEditor()
        {
            InitializeComponent();
        }
        protected override void InitColumns()
        {
            AddColumn("Название фигуры", "CatalogNumber", 200, 0);
        }
        protected override IEntityEditor GetEditor()
        {
            return new FxShapeEditor(Items.FirstOrDefault(PointX => PointX.Id == GetCurrentRowId()).Id);
        }
        protected override ObservableCollection<Core.Entities.Shape> GetItems()
        {
            if (_items == null)
                _items = new ObservableCollection<Core.Entities.Shape>(Repository.GetAll());
            return _items;
        }



        protected override void OpenItem()
        {
            if (Items == null)
                return;

            var _entity = Items.FirstOrDefault(PointX => PointX.Id == GetCurrentRowId()).Id;
            long _l;
            long.TryParse(_entity.ToString(), out _l);
          

            base.OpenItem();
        }

    }
}