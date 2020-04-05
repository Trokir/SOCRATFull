using System;

namespace Socrat.Core.Entities.Printing
{
    [EntityFormConfiguration("Отчеты", "Отчет: {Title}")]
    [PropertyVisualisation("Элемент меню", "TreeItem", 500, 0, true)]
    [PropertyVisualisation("Шаблон", "Template", 500, 1, true)]
    [PropertyVisualisation("Параметры", "Parameters", 500, 2)]
    public class TreeItemTemplate : Entity
    {
        public TreeItemTemplate() { }

        #region Locals

        private TreeItem _treeItem;
        private Template _template;
        private string _parameters;

        #endregion

        #region Properties
        [ParentItem]
        public virtual TreeItem TreeItem { get => _treeItem; set => SetField(ref _treeItem, value, () => TreeItem); }
        public virtual Template Template { get => _template; set => SetField(ref _template, value, () => Template); }
        public string Parameters { get => _parameters; set => SetField(ref _parameters, value, () => Parameters); }

        #endregion

        #region ForeignKeys
        public Guid TreeItemId { get; set; }
        public Guid TemplateId { get; set; }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"{TreeItem}:{Template}";
        }
        #endregion

        public static TreeItemTemplate Empty
        {
            get => new TreeItemTemplate() { TreeItem = null, Template = null, Parameters = string.Empty };
        }
    }
}
