using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using DevExpress.XtraEditors;
using Socrat.Core;

namespace Socrat.Shape.Factory
{
    public class CustomInputShape : Entity
    {
        PictureEdit pictureBox = new PictureEdit();
        StringFormat sf = new StringFormat();
        GraphicsPath p = new GraphicsPath();
        GraphicsPath p1 = new GraphicsPath();
       


        private List<PointF> _GetCustomInputPointsList;
        public List<PointF> GetCustomInputPointsList
        {
            get { return _GetCustomInputPointsList; }
            set { SetField(ref _GetCustomInputPointsList, value, () => GetCustomInputPointsList); }
        }

        public CustomInputShape()
        {
            _GetCustomInputPointsList = new List<PointF>();
        }
        public int pkbDrawW { get; set; }
        public int pkbDrawH { get; set; }
        public void OnPaint(PictureEdit pictureBox)
        {
            PointF[] customPoint = _GetCustomInputPointsList.ToArray();
            this.pictureBox = pictureBox;
            Bitmap bitmapShape = new Bitmap(pictureBox.Width, pictureBox.Height);
            pkbDrawW = bitmapShape.Width;
            pkbDrawH = bitmapShape.Height;
            if (!IsStartDrawCustomShapeElements){DrawCustomShape(pictureBox, customPoint, bitmapShape);}
        }
        public bool IsStartDrawCustomShapeElements { get; set; }
        private void DrawCustomShape(PictureEdit pictureBox, PointF[] customPoint, Bitmap bitmapShape)
        {
            using (Graphics graphicsShape = Graphics.FromImage(bitmapShape ))
            {
                graphicsShape.SmoothingMode = SmoothingMode.HighQuality;
                if (customPoint.Length == 2)
                {
                    graphicsShape.DrawLine(Pens.Blue, customPoint[0], customPoint[1]);
                    return;
                }
                else if (customPoint.Length < 2) return;
                graphicsShape.DrawPolygon(Pens.Blue, customPoint);//Исходный многоугольник
                pictureBox.Image = bitmapShape;
            }
        }
    }
}