using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class ProcessingType : Entity
    {
        public Guid? MaterialId { get; set; }
        private Material _material;
        public virtual Material Material
        {
            get { return _material; }
            set { SetField(ref _material, value, () => Material); }
        }

        private string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set { SetField(ref _ShortName, value, () => ShortName); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        private short? _Step = 0;
        public short? Step
        {
            get { return _Step; }
            set { SetField(ref _Step, value, () => Step); }
        }

        private Color? _Color;
        public Color? Color
        {
            get { return _Color; }
            set
            {
                if (value != null)
                {
                    _Color = value;
                    ColorRGB = value.Value.ToArgb();
                }
            }
        }

        private int? _ColorRGB;
        public int? ColorRGB
        {
            get { return  _Color?.ToArgb(); }
            set
            {
                _ColorRGB = value;
                if (_Color != null && value != null)
                    _Color = System.Drawing.Color.FromArgb(value.Value);
                SetField(ref _ColorRGB, value, () => ColorRGB, () => Color);
            }
        }

        public Guid? MeasureId { get; set; }
        private Measure _Measure;
        public virtual  Measure Measure
        {
            get { return _Measure; }
            set { SetField(ref _Measure, value, () => Measure); }
        }

        public virtual ICollection<Processing> Processings { get; set; } = new HashSet<Processing>();

        public FormulaItemProcessingEnum Enumerator { get; set; } = FormulaItemProcessingEnum.СomponentsProcessing;

        protected override string GetTitle()
        {
            return $"Тип операции: {Name}";
        }

        public override string ToString()
        {
            return $"{Material?.Name}: {Name}";
        }
    }
}