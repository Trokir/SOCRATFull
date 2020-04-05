using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class Processing : Entity
    {
        public Guid? ProcessingTypeId { get; set; }
        private ProcessingType _processingType;
        public virtual ProcessingType ProcessingType
        {
            get { return _processingType; }
            set { SetField(ref _processingType, value, () => ProcessingType); }
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
        private short? _Step;
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
            get { return _Color?.ToArgb(); }
            set
            {
                _ColorRGB = value;
                if (_Color != null && value != null)
                    _Color = System.Drawing.Color.FromArgb(value.Value);
                SetField(ref _ColorRGB, value, () => ColorRGB, () => Color);
            }
        }

        public Guid? SlozTypeId { get; set; }
        private SlozType _SlozType;
        public virtual SlozType SlozType
        {
            get { return _SlozType; }
            set { SetField(ref _SlozType, value, () => SlozType); }
        }

        private int? _OutcropType;
        /// <summary>
        /// отступ аплекалка (внешний зуб), прошитые значения:
        ///0 - отсутствует
        ///1 - постоянное значение(см.OUTCROP_SIZE)
        ///2 - вычисляется по формуле от толщины стекла
        /// </summary>
        public int? OutcropType
        {
            get { return _OutcropType; }
            set { SetField(ref _OutcropType, value, () => OutcropType); }
        }

        private int? _OutcropSize;
        public int? OutcropSize
        {
            get { return _OutcropSize; }
            set { SetField(ref _OutcropSize, value, () => OutcropSize); }
        }

        public Guid? MaterialId
        {
            get { return Material?.Id; }
        }

        [NotMapped]
        public Material Material
        {
            get { return ProcessingType?.Material; }
        }

        public virtual ICollection<PriceProcessing> PriceProcessings { get; set; } = new HashSet<PriceProcessing>();
        public virtual ICollection<FormulaItemProcessing> FormulaItemProcessings { get; set; } = new HashSet<FormulaItemProcessing>();

        protected override string GetTitle()
        {
            return !string.IsNullOrEmpty(Name) ? Name : "Операция";
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
