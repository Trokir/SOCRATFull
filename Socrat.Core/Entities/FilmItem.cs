using System.ComponentModel.DataAnnotations.Schema;
using Socrat.Core.Entities;

namespace Socrat.Core.Added
{
    public class FilmItem : FormulaItem
    {
        public override double DrawThickness => GetDrawThickness();
        private double GetDrawThickness()
        {
            return MaterialNom?.Thickness * 2 ?? 0;
        }
    }
}