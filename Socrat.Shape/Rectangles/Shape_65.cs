using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;

namespace Socrat.Shape.Rectangles
{
    sealed class Shape_65 : Rectangular
    {
        public Shape_65(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
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
            MoveLines();
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
            MoveLines();
        }

        private void MoveLines()
        {
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                pen.DashStyle = DashStyle.DashDot;
                MoveBorderRight(Z_Base, Y_Base, SetB2);
                MoveBorderLeft(W_Base, X_Base, SetB4);
                MoveBorderTop(X_Base, Y_Base, SetB3);
                MoveBorderBottom(W_Base, Z_Base, SetB1);
            }
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
        }
        public override void GetShapeComponents()
        {
            #region BasePath
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                graphicsShape.DrawLine(pen, W_Base, X_Base);
                graphicsShape.DrawLine(pen, X_Base, Y_Base);
                graphicsShape.DrawLine(pen, Y_Base, Z_Base);
                graphicsShape.DrawLine(pen, Z_Base, W_Base);
            }
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


                ShapePoint bs1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(D));
                ShapePoint be1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY);
                Line bl1 = GetNewLine(bs1, be1);
                ShapePoint b1center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY - (bl1.Length / 2));
                graphicsShape.DrawLine(pen, bs1, be1);
                if (SetB1 > 0)
                    graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);
                graphicsShape.DrawLine(pen, Z_Base, be1);


                ShapePoint b2s = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b2e = GetNewCustomPoint(Z_Base.PointX, W_Base.PointY + 20 * LineBoundArgument);
                Line lb2 = GetNewLine(b2s, b2e);
                ShapePoint b2center = GetNewCustomPoint(Z_Base.PointX - (lb2.Length / 2), W_Base.PointY + 25 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b2s, b2e);
                if (SetB2 > 0)
                    graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2center, sf);
                graphicsShape.DrawLine(pen, Z_Base, b2e);

                ShapePoint b3s = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(B));
                ShapePoint b3e = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b3s, b3e);
                Line b3h = GetNewLine(b3s, b3e);
                ShapePoint b3scenter = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY + b3h.Length / 2);
                if (SetB3 > 0)
                    graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b3scenter, sf);
                graphicsShape.DrawLine(pen, Y_Base, b3e);

                ShapePoint b4s = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b4e = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 20 * LineBoundArgument);
                Line lb4 = GetNewLine(b4s, b4e);
                ShapePoint b4center = GetNewCustomPoint(SetPointCurrentValueX(A) - (lb4.Length / 2), W_Base.PointY + 25 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b4s, b4e);
                if (SetB4 > 0)
                    graphicsShape.DrawString("B4=" + SetB4, drawFontBold, Brushes.Black, b4center, sf);
                graphicsShape.DrawLine(pen, W_Base, b4s);


                using (Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument))
                {
                    ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));

                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("65", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }

                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    graphicsShape.DrawLine(pens, le, D);
                    graphicsShape.DrawLine(pens, ls, A);
                    graphicsShape.DrawLine(pens, he, D);
                    graphicsShape.DrawLine(pens, hs, C);
                }
            }

            #endregion
        }
        public override double Perimeter
        {
            get => Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length) / 1000, 3);
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

            List<ShapePoint> pointList = new List<ShapePoint> { A, B, C, D, ACheck, BCheck, CCheck, DCheck };

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

            var width = _SetL+_SetB4+_SetB2;
            var height = _SetH + _SetB1 +_SetB3;

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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB2");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB3");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB4");
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
