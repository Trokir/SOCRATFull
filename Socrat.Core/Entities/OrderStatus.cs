using System;
using System.Collections.Generic;
using System.Drawing;

namespace Socrat.Core.Entities
{
    public class OrderStatus : Entity
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name); }
        }

        private int _OrderNum;

        public int OrderNum
        {
            get { return _OrderNum; }
            set { SetField(ref _OrderNum, value, () => OrderNum); }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { SetField(ref _Description, value, () => Description); }
        }

        private string _CustomerMessage;

        public string CustomerMessage
        {
            get { return _CustomerMessage; }
            set { SetField(ref _CustomerMessage, value, () => CustomerMessage); }
        }

        private Color _Color;
        public Color Color
        {
            get { return _Color; }
            set
            {
                SetField(ref _Color, value, () => Color);
                _ColorRGB = _Color.ToArgb();
            }
        }

        public Color ColorAdjustBrightness(float factor)
        {
            float red = (float) _Color.R;
            float green = (float) _Color.G;
            float blue = (float) _Color.B;

            if (factor < 0)
            {
                factor = 1 + factor;
                red *= factor;
                green *= factor;
                blue *= factor;
            }
            else
            {
                red = (255 - red) * factor + red;
                green = (255 - green) * factor + green;
                blue = (255 - blue) * factor + blue;
            }

            return Color.FromArgb(_Color.A, (int) red, (int) green, (int) blue);
        }


        private int _ChangeMap;

        /// <summary>
        /// Карта перехода статуса (битовая маска)
        /// </summary>
        public int ChangeMap
        {
            get { return _ChangeMap; }
            set { SetField(ref _ChangeMap, value, () => ChangeMap); }
        }


        private int _ColorRGB;
        public int ColorRGB
        {
            get { return Color.ToArgb(); }
            set { SetColorRGB(value); }
        }

        private void SetColorRGB(int value)
        {
            _ColorRGB = value;
            Color = Color.FromArgb(value);
        }

        protected override string GetTitle()
        {
            return "Статус заявки";
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new HashSet<OrderStatusHistory>();

        public Color GetColor()
        {
            return _Color;
        }

        public void SetColor(System.Drawing.Color color)
        {
            _Color = color;
        }
    }
}
