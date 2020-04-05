using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References.Materials;
using Socrat.Common.UI;

namespace Socrat.References.Processings
{
    public partial class CxProcessingTypesMaterials : CxGenericListTable<ProcessingTypeMaterial>//XXXX own
    {
        public ProcessingType ProcessingType { get; set; }

        public CxProcessingTypesMaterials()
        {
            InitializeComponent();
        }

        protected override IEntity GetOwner()
        {
            return ProcessingType;
        }
        protected override AttachedList<ProcessingTypeMaterial> GetItems()
        {
            return ProcessingType.ProcessingTypeMaterials;
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Материал", "Material", 200, 1);
        }

        protected override void AddItem()
        {
            FxMaterials _fx = new FxMaterials();
            _fx.SetSingleSelectMode(null);
            _fx.ItemSelected += (sender, args) =>
            {
                Material _material = _fx.SelectedItem as Material;
                if (ProcessingType.ProcessingTypeMaterials.Count(x => x.Material.Id == _material.Id) < 1)
                {
                    Items.Add(
                        new ProcessingTypeMaterial
                        {
                            ProcessingType = this.ProcessingType,
                            Material = _material,
                            Loaded = true
                        });
                }
                gvGrid.RefreshData();
            };
            _fx.ItemMultiSelected += (sender, args) =>
            {
                List<Material> _materials = _fx.SelectedItems;
                foreach (Material material in _materials)
                {
                    if (Items.Count(x => x.Material.Id == material.Id) < 1)
                    {
                        Items.Add(
                            new ProcessingTypeMaterial
                            {
                                ProcessingType = this.ProcessingType,
                                Material = material,
                                Loaded = true
                            });
                    }
                }
                gvGrid.RefreshData();
            };
            _fx.DialogOutput += (sender, args) => { OnDialogOutput(args);};
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        protected override void OpenItem()
        {
            Guid _id = GetCurrentRowId();
            Material _material = Items.FirstOrDefault(x => x.Id == _id)?.Material;
            FxMaterialEdit _fx = new FxMaterialEdit();
            _fx.Material = _material;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }
    }
}
