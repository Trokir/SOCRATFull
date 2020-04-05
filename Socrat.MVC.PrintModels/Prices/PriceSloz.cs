namespace Socrat.MVC.PrintModels
{
    public class PriceSloz
    {
        public string SlozName { get; set; }
        public double SquareAddValue { get; set; }
        public double SquareFactor { get; set; }
        public double ItemAddValue { get; set; }
        public PriceSloz(){}

        public PriceSloz(Core.Entities.PriceSloz priceSloz)
        {
            SlozName = priceSloz.DisplayName;
            SquareAddValue = priceSloz.AddValueToMeasurementItem;
            SquareFactor = priceSloz.MultiplyValueToEntireItem;
            ItemAddValue = priceSloz.AddValueToEntireItem;
        }
        public PriceSloz(string slozName, double squareAddValue, double squareFactor, double itemAddValue)
        {
            SlozName = slozName;
            SquareAddValue = squareAddValue;
            SquareFactor = squareFactor;
            ItemAddValue = itemAddValue;
        }
    }
}
