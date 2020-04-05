using System.Linq;
using Socrat.Common.UI;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References.Materials;

namespace Socrat.References.Processings
{
    public partial class CxProcessingsComponentsMaterialMarkTypes : CxGenericListTable<ProcessingComponentMaterialsMarkType>//XXXX own
    {
        public Processing Processing { get; set; }

        public CxProcessingsComponentsMaterialMarkTypes()
        {
            InitializeComponent();
        }

        protected override IEntity GetOwner()
        {
            return Processing;
        }       

        protected override void InitColumns()
        {
            AddObjectColumn("Материал", "Material", 120, 0);
            AddObjectColumn("Тип материала по ГОСТ и назначению", "MaterialMarkType", 200, 1);
            GroupByColumn("Material");
        }

        protected override AttachedList<ProcessingComponentMaterialsMarkType> GetItems()
        {
            return Processing.ComponentMaterialsMarkTypes;
        }

        protected override ProcessingComponentMaterialsMarkType GetNewInstance()
        {
            return new ProcessingComponentMaterialsMarkType { Processing = this.Processing };
        }

        protected override void AddItem()
        {
            FxMaterialMarkTypes _fx = new FxMaterialMarkTypes();
            _fx.SetSingleSelectMode(null);
            _fx.DialogOutput += _fx_DialogOutput;
            _fx.ItemSelected += (sender, args) =>
            {
                MaterialMarkType _materialMarkType = _fx.SelectedItem as MaterialMarkType;
                if (_materialMarkType != null)
                {
                    Processing.ComponentMaterialsMarkTypes.Add(new ProcessingComponentMaterialsMarkType
                    {
                        Processing = this.Processing,
                        MaterialMarkType = _materialMarkType
                    });
                }
                RefreshData();
            };
            _fx.ItemMultiSelected += (sender, args) =>
            {
                if (_fx.SelectedItems != null && _fx.SelectedItems.Count > 0)
                {
                    foreach (var item in _fx.SelectedItems)
                    {
                        Processing.ComponentMaterialsMarkTypes.Add(new ProcessingComponentMaterialsMarkType
                        {
                            Processing = this.Processing,
                            MaterialMarkType = item
                        });
                    }
                }
                RefreshData();
            };
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        protected override void OpenItem()
        {
            if (Items == null)
                return;
            ProcessingComponentMaterialsMarkType _entity = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());
            if (_entity != null)
            {
                FxMaterialMarkTypeEdit _fx = new FxMaterialMarkTypeEdit();
                _fx.ReadOnly = true;
                _fx.Entity = _entity.MaterialMarkType;
                _fx.DialogOutput += (sender, args) => { OnDialogOutput(args); };
                OnDialogOutput(_fx, DialogOutputType.Dialog);
            }
        }
    }
}
