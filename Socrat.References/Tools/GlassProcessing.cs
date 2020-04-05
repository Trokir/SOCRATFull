using Socrat.Core.Entities;

namespace Socrat.References.Tools
{
    public class GlassProcessing
    {
        public int Sequence { get; private set; }
        public int Position { get; private set; }
        public string Title { get; set; }
        public double CommonOutCropSize { get; private set; }
        public int CommonOutCropType { get; private set; }
        public double Distance1 { get; set; }
        public double Distance2 { get; set; }
        public double Distance3 { get; set; }
        public double Distance4 { get; set; }
        public double Distance5 { get; set; }
        public double Distance6 { get; set; }
        public double Distance7 { get; set; }
        public double Distance8 { get; set; }

        public GlassProcessing() { }

        public GlassProcessing(FormulaItemProcessing processing, int position = -1)
        {
            Position = position;
            Sequence = processing.Sequence ?? 0;
            CommonOutCropSize = processing.ProcessingNom.Processing.OutcropSize ?? 0;
            CommonOutCropType = processing.ProcessingNom.Processing.OutcropType ?? 0;
            Distance1 = processing.Distance1 ?? 0;
            Distance2 = processing.Distance2 ?? 0;
            Distance3 = processing.Distance3 ?? 0;
            Distance4 = processing.Distance4 ?? 0;
            Distance5 = processing.Distance5 ?? 0;
            Distance6 = processing.Distance6 ?? 0;
            Distance7 = processing.Distance7 ?? 0;
            Distance8 = processing.Distance8 ?? 0;
        }
    }
}
