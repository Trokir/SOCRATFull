using System;
using System.ComponentModel.DataAnnotations.Schema;
using Socrat.Core.Entities;

namespace Socrat.Core.Added
{
    public class TriplexFilmItem : FormulaItem
    {
        public override double DrawThickness => GetDrawThickness();
        private double GetDrawThickness()
        {
            return Math.Max(MaterialNom?.Thickness * 2 ?? 0, 2);
        }
    }
}