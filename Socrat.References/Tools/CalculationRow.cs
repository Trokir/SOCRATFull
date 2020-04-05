using Socrat.Core.Entities;

namespace Socrat.References.Tools
{
    public class CalculationRow
    {
        public string Text { get; set; }
        public string Title { get; set; }

        public bool DentExists { get; set; }
        public double? D1 { get; set; }
        public double? D2 { get; set; }
        public double? D3 { get; set; }
        public double? D4 { get; set; }
        public double? D5 { get; set; }
        public double? D6 { get; set; }
        public double? D7 { get; set; }
        public double? D8 { get; set; }
        public int? OutCropType { get; set; }
        public int? OutCropSize { get; set; }
        public double? L { get; set; }
        public double? L1 { get; set; }
        public double? L2 { get; set; }
        public double? H { get; set; }
        public double? H1 { get; set; }
        public double? H2 { get; set; }
        public double? R { get; set; }
        public double? R1 { get; set; }
        public double? R2 { get; set; }
        public double? R3 { get; set; }
        public CalculationRow() {}
        public CalculationRow(string text, string title, ShapeParameters shapeParameters, FormulaItemProcessing processing)
        {
            Text = text;
            Title = title;

            DentExists = !shapeParameters.DentExists;
          
            L = shapeParameters?.L == 0 ? null : shapeParameters?.L;
            L1 = shapeParameters?.L1 == 0 ? null : shapeParameters?.L1;
            L2 = shapeParameters?.L2 == 0 ? null : shapeParameters?.L2;
            H = shapeParameters?.H == 0 ? null : shapeParameters?.H;
            H1 = shapeParameters?.H1 == 0 ? null : shapeParameters?.H1;
            H2 = shapeParameters?.H2 == 0 ? null : shapeParameters?.H2;
            R = shapeParameters?.R == 0 ? null : shapeParameters?.R;
            R1 = shapeParameters?.R1 == 0 ? null : shapeParameters?.R1;
            R2 = shapeParameters?.R2 == 0 ? null : shapeParameters?.R2;
            R3 = shapeParameters?.R3 == 0 ? null : shapeParameters?.R3;

            if (processing is SideProcessing sideproc)
            {
                OutCropType = processing.ProcessingNom.Processing.OutcropType;
                OutCropSize = processing.ProcessingNom.Processing.OutcropSize;

                if (GetSide(sideproc.SelectedSides, 1)) if ((sideproc?.Distance1) == null) D1 = OutCropSize; else D1 = (sideproc?.Distance1);
                if (GetSide(sideproc.SelectedSides, 2)) if ((sideproc?.Distance2) == null) D2 = OutCropSize; else D2 = (sideproc?.Distance2);
                if (GetSide(sideproc.SelectedSides, 3)) if ((sideproc?.Distance3) == null) D3 = OutCropSize; else D3 = (sideproc?.Distance3);
                if (GetSide(sideproc.SelectedSides, 4)) if ((sideproc?.Distance4) == null) D4 = OutCropSize; else D4 = (sideproc?.Distance4);
                if (GetSide(sideproc.SelectedSides, 5)) if ((sideproc?.Distance5) == null) D5 = OutCropSize; else D5 = (sideproc?.Distance5);
                if (GetSide(sideproc.SelectedSides, 6)) if ((sideproc?.Distance6) == null) D6 = OutCropSize; else D6 = (sideproc?.Distance6);
                if (GetSide(sideproc.SelectedSides, 7)) if ((sideproc?.Distance7) == null) D7 = OutCropSize; else D7 = (sideproc?.Distance7);
                if (GetSide(sideproc.SelectedSides, 8)) if ((sideproc?.Distance8) == null) D8 = OutCropSize; else D8 = (sideproc?.Distance8);
            }
        }

        public bool GetSide(int selectedSides, int sideNum)
        {
            return (selectedSides >> sideNum & 1) == 1;
        }
    }
}
