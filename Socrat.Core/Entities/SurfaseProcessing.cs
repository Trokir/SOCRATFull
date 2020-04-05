using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Socrat.Core.Entities;

namespace Socrat.Core.Added
{
    /// <summary>
    /// Обработка поверхности
    /// </summary>
    public class SurfaseProcessing: FormulaItemProcessing
    {
        public SurfaseProcessing()
        {
            Enumerator = FormulaItemProcessingEnum.SurfaseProcessing;
        }

        public byte SelectedSurface { get; set; } = 0;
        public Rectangle FirstSurface { get; set; }
        public Rectangle SecondSurface { get; set; }

        public bool CheckSurfaceSelectedChanged(Point point)
        {
            bool _res = false;
            byte _surfaceNum = SelectedSurface;
            if (FirstSurface.Contains(point))
                _surfaceNum = 1;
            if (SecondSurface.Contains(point))
                _surfaceNum = 2;
            if (_surfaceNum != SelectedSurface)
            {
                SelectedSurface = _surfaceNum;
                _res = true;
                SurfaceTitle = $"Сторона: {SelectedSurface}";
            }
            return _res;
        }

        private string _surfaceTitle;
        [NotMapped]
        public string SurfaceTitle
        {
            get { return _surfaceTitle; }
            set { SetField(ref _surfaceTitle, value, () => SurfaceTitle); }
        }

        protected override string GetTitle()
        {
            return "Операция: Защитное окрашивание";
        }

       
    }
}