using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;

namespace Socrat.Shape.Rectangles
{
   sealed class Shape_0 : Rectangular
    {
        public Shape_0(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
        }
        protected override void DrawMainLines()
        {
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument / 2))
                {
                    pen1.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen1, A, B);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument / 2))
                {
                    pen2.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen2, B, C);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument / 2))
                {
                    pen3.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen3, C, D);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument / 2))
                {
                    pen4.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen4, D, A);
                }

            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetBasePoints());
        }
        protected override void DrawInvertedMainLines()
        {
           
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen1, A, B);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen2, B, C);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument))
                {

                    graphicsShape.DrawLine(pen3, C, D);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen4, D, A);
                }
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetBasePoints());
        }
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D };
        }
        protected override void CheckForeignBorders()
        {
           
                GetExtremumPoints();
            if (IsHasTooth)
            {
                AllowanceProcessing();
            }
            else
            {
                AllowanceInvertedProcessing();
            }
            MoveBorderRight(Z_Base, Y_Base, SetB1);
                MoveBorderLeft(W_Base, X_Base, SetB3);
                MoveBorderTop(X_Base, Y_Base, SetB2);
        }
        public override void GetShapeComponents()
        {
            #region BasePath

            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                ShapePoint hs = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, B.PointY);
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, A.PointY);
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, A.PointY - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                    graphicsShape.DrawString("H=" + SetCurrentSize("SetH"), drawFontBold, Brushes.Black, hcenter, sf);

                ShapePoint ls = GetNewCustomPoint(A.PointX, W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(D.PointX, W_Base.PointY + 20 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(A.PointX + (ll.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetCurrentSize("SetL"), drawFontBold, Brushes.Black, lcenter, sf);
               
                using (Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument))
                {
                    ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));

                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("0", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
               
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    graphicsShape.DrawLine(pens, le,D);
                    graphicsShape.DrawLine(pens, ls,A);             
                    graphicsShape.DrawLine(pens, he,D);
                    graphicsShape.DrawLine(pens, hs,C);
                }
            }

            #endregion
        }
        public override double Perimeter
        {
            get=> Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length) / 1000, 3);
        }
        public override double Perimeter_t
        {
            get
            {
                return Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length + D_Check_Line.Length) / 1000, 3);
            }
        }

        public override double SetH { get => A_line.Length; set => base.SetH = value; }
        public override double SetL { get => D_line.Length; set => base.SetL = value; }
        public override double SetH_t => A_Check_Line.Length;
        public override double SetL_t => D_Check_Line.Length;
        protected override void SetHValue()
        {
            base.SetHValue();
         
            A.PointX = SetCurrentLineLength(B, A, _SetH).PointX;
            A.PointY = SetCurrentLineLength(B, A, _SetH).PointY;
            D.PointY = A.PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            D.PointX = SetCurrentLineLength(A, D, _SetL).PointX;
            D.PointY = SetCurrentLineLength(A, D, _SetL).PointY;
            C.PointX = D.PointX;
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint> { A, B, C, D,ACheck,BCheck,CCheck,DCheck};

            var xMax = pointList.Max(x => x.PointX);
            var yMax = pointList.Max(x => x.PointY);
            var xMin = pointList.Min(x => x.PointX);
            var yMin = pointList.Min(x => x.PointY);
            W_Base = new ShapePoint(xMin, yMax);
            X_Base = new ShapePoint(xMin, yMin);
            Y_Base = new ShapePoint(xMax, yMin);
            Z_Base = new ShapePoint(xMax, yMax);

        }
        public override bool CheckValidSize()
        {
           
            var width = _SetL;
            var height = _SetH;

            if (_SetH < 0 || _SetH1 < 0 || _SetL < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0)
            {
                
                var message = "Значение  не может быть отрицательным";
                ValidateSetSizeMessage(Text: message);
                ValidValue = true;
            }
            else if (width > 6000 || height > 6000)
            {
                var message2 = (width > 6000)
                    ? $"Габаритная ширина = {width} превышает 6000"
                    : $"Габаритная высота = {height} превышает 6000";
                ValidateSetSizeMessage(Text: message2);
                ValidValue = true;
            }
            else if (width > 3210 && height > 3210)
            {
                var message1 =
                    $"Габаритная ширина = {width} превышает 3210 и Габаритная высота = {height} превышает 3210";
                ValidateSetSizeMessage(Text: message1);
                ValidValue = true;
            }
            else
            {
                ValidValue = false;
            }
            return ValidValue;
        }
        public override void AddCustomProperties(object sender, CustomPropertyDescriptorsEventArgs e)
        {

            if (e.Context.PropertyDescriptor == null)
            {
                PropertyDescriptorCollection filteredCollection = new PropertyDescriptorCollection(null);
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKis");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKisPersent");
                AddIfPropertyExist(e.Properties, filteredCollection, "Area");
                AddIfPropertyExist(e.Properties, filteredCollection, "TrueArea");
                AddIfPropertyExist(e.Properties, filteredCollection, "BaseArea");
                AddIfPropertyExist(e.Properties, filteredCollection, "Perimeter");
                AddIfPropertyExist(e.Properties, filteredCollection, "Perimeter_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeHeightValue");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeWidthValue");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsSelectSameAllowance");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut2");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut3");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut4");
                if (!IsAddAdwansedParams)
                {
                    AddIfPropertyExist(e.Properties, filteredCollection, "IsCuttingGlass");
                    AddIfPropertyExist(e.Properties, filteredCollection, "IsBendingDistanceFrame");
                    AddIfPropertyExist(e.Properties, filteredCollection, "IsFormSealing");
                    AddIfPropertyExist(e.Properties, filteredCollection, "IsGasFillingForm");
                    AddIfPropertyExist(e.Properties, filteredCollection, "IsVertBendingMashineRobot");
                    AddIfPropertyExist(e.Properties, filteredCollection, "IsVertMashineEdgeMaking");
                }
                e.Properties = filteredCollection;
            }
        }


    }
}
