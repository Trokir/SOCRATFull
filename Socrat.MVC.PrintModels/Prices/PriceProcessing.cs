namespace Socrat.MVC.PrintModels
{
    public class PriceProcessing
    {
        public string DisplayName { get; set; }
        public double MultiplyPriceFactor { get; set; }
        public double AddValuePrice { get; set; }

        public PriceProcessing(){}

        public PriceProcessing(Core.Entities.PricePeriodProcessingNom pricePeriodProcessingNom)
        {
            DisplayName = pricePeriodProcessingNom.Processing.Name;
            MultiplyPriceFactor = pricePeriodProcessingNom.MultiplyPriceFactor;
            AddValuePrice = pricePeriodProcessingNom.AdditionalPriceValue;
        }
    }
}
