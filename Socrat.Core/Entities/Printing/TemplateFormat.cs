namespace Socrat.Core.Entities.Printing
{
    [EntityFormConfiguration("Форматы печати", "Формат печати: {Title}")]
    [PropertyVisualisation("Наименование", "Name", 250, 1)]
    [PropertyVisualisation("Ширина", "Width", 30, 2)]
    [PropertyVisualisation("Высота", "Height", 30, 3)]
    [PropertyVisualisation("М", "Multipage", 20, 4)]
    [PropertyVisualisation("L", "Landscape", 20, 5)]
    [PropertyVisualisation("Примечание", "Comments", 350, 6)]
    public class TemplateFormat : Entity
    {
        #region Locals

        private string _name;
        private int _width;
        private int _height;
        private bool _landscape;
        private bool _multipage;
        private string _comments;

        #endregion

        #region Properties

        public string Name { get => _name; set => SetField(ref _name, value, () => Name); }
        public int Width{ get => _width; set => SetField(ref _width, value, () => Width); }
        public int Height{ get => _height; set => SetField(ref _height, value, () => Height); }
        public bool Landscape { get => _landscape; set => SetField(ref _landscape, value, () => Landscape); }
        public bool Multipage { get => _multipage; set => SetField(ref _multipage, value, () => Multipage); }
        public string Comments { get => _comments; set => SetField(ref _comments, value, () => Comments); }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
