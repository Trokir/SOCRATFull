namespace Socrat.Shape.Shproses
{
    public static class Shpros<T> where T : BaseShape
    {
        public static T ShapeTemplate { get; set; }
        public static T GetCurrentShape(T Value)
        {
            ShapeTemplate = Value;
            return ShapeTemplate;
        }
    }
}
