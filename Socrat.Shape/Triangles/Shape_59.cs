using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;

namespace Socrat.Shape.Triangles
{
    sealed class Shape_59 : Triangle
    {
        Rectangle rect { get; set; }
        Pen blackPen { get; set; }
        public Shape_59(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
            blackPen = new Pen(Color.Green, 1);

        }
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C };
        }
        protected override void DrawMainLines()
        {
            Point[] curvePoints = GetFigurePoints();
            if (IsToothVector == true)
            {
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument / 2))
                {
                    pen1.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen1, A, B);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument / 2))
                {
                    pen2.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawCurve(pen2, curvePoints, 0F);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument / 2))
                {
                    pen2.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen3, A, C);
                }

                IsToothVector = true;
            }
            else
            {
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen1, A, B);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument))
                {
                    graphicsShape.DrawCurve(pen2, curvePoints, 0F);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen3, A, C);
                }

                IsToothVector = false;
            }
            using (var myPath = new GraphicsPath())
            {
                myPath.AddLine(A, C);
                myPath.AddCurve(curvePoints);
                myPath.AddLine(A, B);
                graphicsShape.FillPath(new SolidBrush(Color.FromArgb(30, Color.Blue)), myPath);
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
                MoveBorderRight(Y_Base, Z_Base, SetB2);
                MoveBorderBottom(W_Base, Z_Base, SetB1);
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

                /*dl*/
                ShapePoint b1s = GetNewCustomPoint(W_Base.PointX + SetB1, W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 20 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                /*dp*/
                ShapePoint b1s1 = GetNewCustomPoint(Z_Base.PointX - SetB2, W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                Line lb11 = GetNewLine(b1s1, b1e1);
                ShapePoint b11center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b11center, sf);

                /*pd*/
                ShapePoint b1s2 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY);
                ShapePoint b1e2 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY - SetB1);
                Line lb12 = GetNewLine(b1s2, b1e2);
                ShapePoint b12center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY - (lb12.Length / 2));
                graphicsShape.DrawLine(pen, b1s2, b1e2);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b12center, sf);

                /*ru*/
                ShapePoint b2s = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY);
                ShapePoint b2e = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + SetB2);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);


                ShapePoint hs = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(A));
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(B));
                Line hl = GetNewLine(hs, he);
                ShapePoint hlcenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY - (hl.Length / 2));
                graphicsShape.DrawLine(pen, hs, he);
                graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hlcenter, sf);


                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX) / 3), ((A.PointY + B.PointY + C.PointY) / 3));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {

                    graphicsShape.DrawString("59", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    ShapePoint wer1 = GetNewCustomPoint(SetPointCurrentValueX(B), Y_Base.PointY);
                    ShapePoint wer2 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(C));
                    ShapePoint wer3 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(A));
                    }

                    graphicsShape.DrawLine(pens, b2s, Y_Base);
                    graphicsShape.DrawLine(pens, b2e, SetPointCurrentType(B));
                    graphicsShape.DrawLine(pens, b1s2, Z_Base);
                    graphicsShape.DrawLine(pens, b1e2, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, b1e, W_Base);
                    graphicsShape.DrawLine(pens, b1s, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, b1e1, Z_Base);
                    graphicsShape.DrawLine(pens, b1s1, SetPointCurrentType(C));
                }

                #endregion
            }
        }
        public override RectangleF GetShapeBorders()
        {
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(A, B);
                myPath.AddLine(A, C);
                myPath.AddCurve(GetFigurePoints());
                Region myRegion = new Region(myPath);
                RectangleF boundsRect = myRegion.GetBounds(graphicsShape);
                graphicsShape.DrawRectangle(Pens.Blue, new Rectangle((int)boundsRect.X,
           (int)boundsRect.Y, (int)boundsRect.Width, (int)boundsRect.Height));
                // graphicsShape.SetClip(myRegion, CombineMode.Replace);
                return boundsRect;
            }
        }

        public override void SelectClickedSide(int xCoord, int yCoord, bool flag)
        {
            Point point = new Point(xCoord, yCoord);
            if (ThicknessPath(A, B).IsVisible(point))
            {
                if (flag) { ColorMarker1 = "rowCheckCut1"; SelectedSides.SetValue(1, 0); SelectedSidesLength += A_line.Length; }
                else { ColorMarker1 = ""; SelectedSides.SetValue(0, 0); SelectedSidesLength -= A_line.Length; }
            }
            if (CurvePath(GetFigurePoints()).IsVisible(point))
            {
                if (flag) { ColorMarker2 = "rowCheckCut2"; SelectedSides.SetValue(2, 1); SelectedSidesLength += arcLength; }
                else { ColorMarker2 = ""; SelectedSides.SetValue(0, 1); SelectedSidesLength -= arcLength; }
            }
            if (ThicknessPath(A, C).IsVisible(point))
            {
                if (flag) { ColorMarker3 = "rowCheckCut3"; SelectedSides.SetValue(3, 2); SelectedSidesLength += C_line.Length; }
                else { ColorMarker3 = ""; SelectedSides.SetValue(0, 2); SelectedSidesLength -= C_line.Length; }
            }
            else return;
        }
        protected override GraphicsPath GetShapeShprosBorders()
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(A, B);
            myPath.AddLine(A, C);
            myPath.AddCurve(GetFigurePoints());
            return myPath;
        }
        public override double Area => Math.Round((Math.PI * Math.Pow(A_line.Length, 2) / 4) / 1000000, 3);
        public override double TrueArea => Math.Round((Math.PI * Math.Pow(A_Check_Line.Length, 2) / 4) / 1000000, 3);
        public override double Perimeter
        {
            get
            {
                var arcLength = (2 * Math.PI * A_line.Length) / 4;
                return Math.Round((A_line.Length + C_line.Length + arcLength) / 1000, 3);
            }
        }
        public double arcLength { get; set; }
        public override double Perimeter_t
        {
            get
            {
                var arc = (2 * Math.PI * A_Check_Line.Length) / 4;
                return Math.Round((A_Check_Line.Length + C_Check_Line.Length + arc / 1000), 3);
            }
        }
        public override double SetH
        {
            get => Math.Round(A_line.Length, 0);
            set => base.SetH = value;
        }
        public override double SetH_t => Math.Round(A_Check_Line.Length, 0);
        protected override void SetHValue()
        {
            base.SetHValue();
            A.PointY = SetCurrentLineLength(B, A, _SetH).PointY;
            C.PointY = A.PointY;
            C.PointX = SetCurrentLineLength(A, C, _SetH).PointX;
            ValidValue = false;
        }
        public override Point[] GetFigurePoints()
        {
            #region Получаем угол ВСА для определения длины дуги скругления стороны АВ и уравниваем AC и BC
            double angleBetween = 0;

            angleBetween = 90;
            #endregion
            var pointsList = new List<Point>();
            pointsList.Add(C);
            double degree = 0;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (C.PointX - A.PointX) * Math.Cos(-degree * Math.PI / 180) - (C.PointY - A.PointY) * Math.Sin(-degree * Math.PI / 180) + A.PointX;
                CurvePoint.PointY = (C.PointX - A.PointX) * Math.Sin(-degree * Math.PI / 180) + (C.PointY - A.PointY) * Math.Cos(-degree * Math.PI / 180) + A.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(B);
            var points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            return points;
        }
        public override Point[] GetFigureToothPoints()
        {
            #region Получаем угол ВСА для определения длины дуги скругления стороны АВ и уравниваем AC и BC
            double angleBetween = (IsToothVector == true) ? 90 : 80;
            #endregion
            var pointsList = new List<Point>();
            double degree = 0;
            TempPoint.PointX = ACheck.PointX + CheckCut1;
            TempPoint.PointY = ACheck.PointY - CheckCut3;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (CCheck.PointX - TempPoint.PointX) * Math.Cos(-degree * Math.PI / 180) -
               (CCheck.PointY - TempPoint.PointY) * Math.Sin(-degree * Math.PI / 180) + TempPoint.PointX;
                CurvePoint.PointY = (CCheck.PointX - TempPoint.PointX) * Math.Sin(-degree * Math.PI / 180) +
                (CCheck.PointY - TempPoint.PointY) * Math.Cos(-degree * Math.PI / 180) + TempPoint.PointY;
                pointsList.Add(CurvePoint);
                degree += 2;
            }
            pointsList.Add(BCheck);
            var points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            return points;
        }
        protected override void AllowanceProcessing()
        {
            ACheck.PointX = A.PointX;
            ACheck.PointY = A.PointY;
            BCheck.PointX = B.PointX;
            BCheck.PointY = B.PointY;
            CCheck.PointX = C.PointX;
            CCheck.PointY = C.PointY;


            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == false && _CheckCut2 >= 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == false && _CheckCut3 >= 0) ? _CheckCut3 * (-1) : _CheckCut3;
            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == true && _CheckCut2 < 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == true && _CheckCut3 < 0) ? _CheckCut3 * (-1) : _CheckCut3;


            CCheck.PointY += CheckCut3;
            ACheck.PointY += CheckCut3;
            BCheck.PointX -= CheckCut1;
            ACheck.PointX -= CheckCut1;


            BCheck.PointY = SetCurrentLineLength(ACheck, BCheck, _CheckCut2 + A_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(ACheck, BCheck, _CheckCut2 + A_Check_Line.Length).PointX;
            CCheck.PointY = SetCurrentLineLength(ACheck, CCheck, _CheckCut2 + C_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(ACheck, CCheck, _CheckCut2 + C_Check_Line.Length).PointX;




            if (IsToothVector == true)
            {

                using (var penCut = new Pen(Color.Red, ThiсknessArgument))
                {
                    var curvePoints = GetFigureToothPoints();
                    graphicsShape.DrawCurve(penCut, curvePoints, 0F);
                    graphicsShape.DrawLine(penCut, ACheck, BCheck);
                    graphicsShape.DrawLine(penCut, ACheck, CCheck);

                    IsToothVector = true;
                }
            }
            else
            {

                using (var penCut = new Pen(Color.Red, ThiсknessArgument / 2))
                {
                    var curvePoints = GetFigureToothPoints();
                    penCut.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawCurve(penCut, curvePoints, 0F);
                    graphicsShape.DrawLine(penCut, ACheck, BCheck);
                    graphicsShape.DrawLine(penCut, ACheck, CCheck);
                    IsToothVector = false;
                }
            }
            GetExtremumPoints();
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, B, C, ACheck, BCheck, CCheck };

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
            var value2 = (IsToothVector == true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector == true) ? _CheckCut3 : 0;
            var li = (IsToothVector == true) ? A_Check_Line.Length : A_line.Length;
            var width = _SetH + _SetB1 + _SetB2 + value1 + value2;
            var height = width + value3;

            if (_SetL < 0 || _SetB1 < 0 || _SetB2 < 0)
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
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsSelectSameAllowance");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut2");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut3");
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
