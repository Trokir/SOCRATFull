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
    sealed class Shape_53 : Rectangular
    {
        ShapePoint Apogeus { get; set; }
        ShapePoint Perigeus { get; set; }
        public Shape_53(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
            Apogeus = GetNewPoint();
            Perigeus = GetNewPoint();
        }
        protected override void DrawMainLines()
        {

            if (ValidValue == false)
            {
                DrawEllipseRectangle();
            }
            MoveLines();
        }
        protected override void CheckForeignBorders()
        {
           
            GetExtremumPoints();
            AllowanceProcessing();
        }

        private void MoveLines()
        {
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
               
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB2);
                MoveBorderRight(Y_Base, Z_Base, SetB1);
                MoveBorderBottom(W_Base, Z_Base, SetB2);
            }
        }

        public override void GetShapeComponents()
        {
            #region BasePath
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                pen.DashStyle = DashStyle.DashDot;
                graphicsShape.DrawLine(pen, W_Base, X_Base);
                graphicsShape.DrawLine(pen, X_Base, Y_Base);
                graphicsShape.DrawLine(pen, Y_Base, Z_Base);
                graphicsShape.DrawLine(pen, Z_Base, W_Base);
            }
            using (var pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                ShapePoint hs = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY - SetB2);
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + SetB2);
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY - SetB2 - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hcenter, sf);


                ShapePoint b2s = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(A));
                ShapePoint b2e = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Z_Base.PointX + 20, W_Base.PointY - b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);


                ShapePoint b2s1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + SetB2);
                ShapePoint b2e1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY);
                Line lb21 = GetNewLine(b2s1, b2e1);
                ShapePoint b31center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + (lb21.Length / 2));
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b31center, sf);



                ShapePoint b1s = GetNewCustomPoint(W_Base.PointX + SetB1, W_Base.PointY + 40 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 40 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint b1s1 = GetNewCustomPoint(Z_Base.PointX - SetB1, Z_Base.PointY + 40 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 40 * LineBoundArgument);
                Line lb11 = GetNewLine(b1s1, b1e1);
                ShapePoint b11center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), Z_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b11center, sf);


                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 40 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 40 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(W_Base.PointX + (ll.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("53", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }

                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    var hor = GetNewLine(Z_Base, W_Base);
                    var ver = GetNewLine(Z_Base, Y_Base);

                    var upPoint = GetNewCustomPoint(X_Base.PointX + hor.Length / 2, X_Base.PointY + SetB2);
                    var downPoint = GetNewCustomPoint(X_Base.PointX + hor.Length / 2, Z_Base.PointY - SetB2);
                    var leftPoint = GetNewCustomPoint(W_Base.PointX + SetB1, W_Base.PointY - ver.Length / 2);
                    var rightPoint = GetNewCustomPoint(Z_Base.PointX - SetB1, W_Base.PointY - ver.Length / 2);
                    graphicsShape.DrawLine(pens, hs, downPoint);
                    graphicsShape.DrawLine(pens, he, upPoint);
                    graphicsShape.DrawLine(pens, ls, leftPoint);
                    graphicsShape.DrawLine(pens, le, rightPoint);
                    graphicsShape.DrawLine(pens, b1e, W_Base);
                    graphicsShape.DrawLine(pens, b1e1, Z_Base);
                    graphicsShape.DrawLine(pens, b2e, Z_Base);
                    graphicsShape.DrawLine(pens, b2e1, X_Base);
                }


            }
            #endregion
        }
        public override RectangleF GetShapeBorders()
        {
            using (GraphicsPath myPath = new GraphicsPath())
            {
                Size size = new Size((int)SetL, (int)SetH);
                Rectangle rect = new Rectangle(B, size);
                myPath.AddEllipse(rect);
                Region myRegion = new Region(myPath);
                RectangleF boundsRect = myRegion.GetBounds(graphicsShape);
               // graphicsShape.SetClip(myRegion, CombineMode.Replace);
                return boundsRect;
            }
        }
        protected override GraphicsPath GetShapeShprosBorders()
        {
            GraphicsPath myPath = new GraphicsPath();
            Size size = new Size((int)SetL, (int)SetH);
            Rectangle rect = new Rectangle(B, size);
            myPath.AddEllipse(rect);
            return myPath;
        }
        public override double Area
        {
            get
            {
                var square = Math.PI * A_line.Length / 2 * D_line.Length / 2;
                return Math.Round(square / 1000000, 3);
            }
        }
        public override double TrueArea
        {
            get
            {
                var square = Math.PI * A_Check_Line.Length / 2 * D_Check_Line.Length / 2;
                return Math.Round(square / 1000000, 3);
            }
        }
        public override double Perimeter
        {
            get
            {

                var arg = Math.Log(2) / Math.Log(Math.PI / 2);
                var perimeter = 4 * Math.Pow((Math.Pow((A_line.Length / 2), arg) + Math.Pow((D_line.Length / 2), arg)), 1 / arg);
                return Math.Round(perimeter / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get
            {

                var arg = Math.Log(2) / Math.Log(Math.PI / 2);
                var perimeter = 4 * Math.Pow((Math.Pow((A_Check_Line.Length / 2), arg) + Math.Pow((D_Check_Line.Length / 2), arg)), 1 / arg);
                return Math.Round(perimeter / 1000, 3);
            }
        }
        public override double SetL { get => Math.Round(D_line.Length, 0); set => base.SetL = value; }
        public override double SetH { get => Math.Round(A_line.Length, 0); set => base.SetH = value; }
        private void DrawEllipseRectangle()
        {
            if (IsToothVector == true)
            {
                using (Pen pen = new Pen(Color.Red, ThiсknessArgument /2))
                {
                    pen.DashStyle = DashStyle.DashDot;
                    Size size = new Size((int)SetL, (int)SetH);
                    Rectangle rect = new Rectangle(B, size);
                    graphicsShape.DrawEllipse(pen, rect);
                    graphicsShape.FillEllipse(new SolidBrush(Color.FromArgb(30, Color.Blue)), rect);
                    IsToothVector = true;
                }

            }
            else
            {
                using (Pen pen = new Pen(Color.Red, ThiсknessArgument ))
                {

                    Size size = new Size((int)SetL, (int)SetH);
                    Rectangle rect = new Rectangle(B, size);
                    graphicsShape.DrawEllipse(pen, rect);
                    graphicsShape.FillEllipse(new SolidBrush(Color.FromArgb(30, Color.Blue)), rect);
                    IsToothVector = false;
                }


            }

        }
        public override double SetH_t { get => Math.Round(A_Check_Line.Length, 0); }
        public override double SetL_t { get => Math.Round(D_Check_Line.Length, 0); }
        protected override void SetHValue()
        {
            base.SetHValue();
            var p = B.PointY;
            CurvePoint.PointX = A.PointX;
            CurvePoint.PointY = A.PointY - A_line.Length / 2;
            A.PointY = SetCurrentLineLength(CurvePoint, A, _SetH / 2).PointY;
            D.PointY = A.PointY;
            B.PointY = SetCurrentLineLength(CurvePoint, B, _SetH / 2).PointY;
            C.PointY = B.PointY;
            var diff = p - B.PointY;
            Move(y: diff);
           
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            var p = A.PointX;
            CurvePoint.PointX = A.PointX + D_line.Length / 2;
            CurvePoint.PointY = A.PointY;
            A.PointX = SetCurrentLineLength(CurvePoint, A, _SetL / 2).PointX;
            A.PointY = SetCurrentLineLength(CurvePoint, A, _SetL / 2).PointY;
            B.PointX = A.PointX;
            D.PointX = SetCurrentLineLength(CurvePoint, D, _SetL / 2).PointX;
            D.PointY = SetCurrentLineLength(CurvePoint, D, _SetL / 2).PointY;
            C.PointX = D.PointX;
            var diff = p - A.PointX;
            Move(x: diff);
            ValidValue = false;
        }
        protected override void AllowanceProcessing()
        {
            ACheck.PointX = A.PointX;
            ACheck.PointY = A.PointY;
            BCheck.PointX = B.PointX;
            BCheck.PointY = B.PointY;
            CCheck.PointX = C.PointX;
            CCheck.PointY = C.PointY;
            DCheck.PointX = D.PointX;
            DCheck.PointY = D.PointY;
            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;


            ACheck.PointY = SetCurrentLineLength(DCheck, ACheck, CheckCut1 + D_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(DCheck, ACheck, CheckCut1 + D_Check_Line.Length).PointX;
            BCheck.PointY = SetCurrentLineLength(CCheck, BCheck, CheckCut1 + B_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(CCheck, BCheck, CheckCut1 + B_Check_Line.Length).PointX;

            BCheck.PointY = SetCurrentLineLength(ACheck, BCheck, CheckCut1 + A_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(ACheck, BCheck, CheckCut1 + A_Check_Line.Length).PointX;
            CCheck.PointY = SetCurrentLineLength(DCheck, CCheck, CheckCut1 + C_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(DCheck, CCheck, CheckCut1 + C_Check_Line.Length).PointX;

            CCheck.PointY = SetCurrentLineLength(BCheck, CCheck, CheckCut1 + B_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(BCheck, CCheck, CheckCut1 + B_Check_Line.Length).PointX;
            DCheck.PointY = SetCurrentLineLength(ACheck, DCheck, CheckCut1 + D_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(ACheck, DCheck, CheckCut1 + D_Check_Line.Length).PointX;

            DCheck.PointY = SetCurrentLineLength(CCheck, DCheck, CheckCut1 + C_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(CCheck, DCheck, CheckCut1 + C_Check_Line.Length).PointX;
            ACheck.PointY = SetCurrentLineLength(BCheck, ACheck, CheckCut1 + A_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(BCheck, ACheck, CheckCut1 + A_Check_Line.Length).PointX;





            if (IsToothVector == true)
            {
                //BCheck.PointX -= CheckCut1;
                //BCheck.Y -= CheckCut1;
                using (Pen pen = new Pen(Color.Red, ThiсknessArgument))
                {
                    Size size = new Size((int)SetL_t, (int)SetH_t);
                    Rectangle rect = new Rectangle(BCheck, size);
                    graphicsShape.DrawEllipse(pen, rect);
                    graphicsShape.FillEllipse(new SolidBrush(Color.FromArgb(30, Color.Blue)), rect);
                    IsToothVector = true;
                }
            }
            else
            {
                //BCheck.PointX += CheckCut1;
                //BCheck.Y += CheckCut1;
                using (Pen pen = new Pen(Color.Red, ThiсknessArgument / 2))
                {
                    pen.DashStyle = DashStyle.DashDot;
                    Size size = new Size((int)SetL_t, (int)SetH_t);
                    Rectangle rect = new Rectangle(BCheck, size);
                    graphicsShape.DrawEllipse(pen, rect);
                    graphicsShape.FillEllipse(new SolidBrush(Color.FromArgb(30, Color.Blue)), rect);
                    IsToothVector = false;
                }
            }


            GetExtremumPoints();
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, D, B, C, ACheck, BCheck, CCheck, DCheck };

            var PointXMax = pointList.Max(PointX => PointX.PointX);
            var yMax = pointList.Max(PointX => PointX.PointY);
            var PointXMin = pointList.Min(PointX => PointX.PointX);
            var yMin = pointList.Min(PointX => PointX.PointY);
            W_Base = new ShapePoint(PointXMin, yMax);
            X_Base = new ShapePoint(PointXMin, yMin);
            Y_Base = new ShapePoint(PointXMax, yMin);
            Z_Base = new ShapePoint(PointXMax, yMax);

        }
        public override bool CheckValidSize()
        {
            var value1 = (IsToothVector == true) ? _CheckCut1 : 0;
            var width = _SetL + _SetB1*2 +  value1*2;
            var height = _SetH +  _SetB2*2 +value1*2;

            if (_SetH < 0 || _SetH1 < 0 || _SetL < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0)
            {
                var message = $"Значение  не может быть отрицательным";
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
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
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