using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Socrat.Shape.Pentagons
{
    public sealed class Shape_22 : Hexagon
    {
        public Shape_22(List<Core.Entities.ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
        public override double Perimeter
        {
            get
            {
                return Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length + E_line.Length + F_line.Length) / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get => Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length + D_Check_Line.Length +
                E_Check_Line.Length + F_Check_Line.Length) / 1000, 3);

        }
        protected override void DrawMainLines()
        {
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
                    graphicsShape.DrawLine(pen4, D, E);
                }
                using (pen5 = new Pen(SelectMainLineColor5(), ThiсknessArgument / 2))
                {
                    pen5.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen5, E, F);
                }
                using (pen6 = new Pen(SelectMainLineColor6(), ThiсknessArgument / 2))
                {
                    pen6.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen6, F, A);
                }
            }
            else
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
                    graphicsShape.DrawLine(pen4, D, E);
                }
                using (pen5 = new Pen(SelectMainLineColor5(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen5, E, F);
                }
                using (pen6 = new Pen(SelectMainLineColor6(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen6, F, A);
                }
            }
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetBasePoints());
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
                MoveBorderTop(X_Base, Y_Base, SetB1);
                MoveBorderRight(Y_Base, Z_Base, SetB1);
                MoveBorderBottom(W_Base, Z_Base, SetB1);
            }
        }

        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D, E, F };
        }
        public override void GetShapeComponents()
        {
            #region BasePath
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                pen.DashStyle = DashStyle.DashDot;
                MoveInternalLineFromLeft(graphicsShape, W_Base, X_Base, First_B_Some_Size_Point, Second_B_Some_Size_Point, SetB1, SetB2);
                MoveInternalLineFromRight(graphicsShape, Y_Base, Z_Base, First_B_Some_Size_Point, Second_B_Some_Size_Point, SetB1, SetB2);
                FindPointDrawLine(SetPointCurrentType(C), SetPointCurrentType(B), SetB1, SetB2, 0);
                FindPointDrawLine(SetPointCurrentType(A), SetPointCurrentType(B), SetB1, SetB2, 0);
                FindPointDrawLine1(SetPointCurrentType(D), SetPointCurrentType(E), SetB1, SetB2, 0);
                FindPointDrawLine1(SetPointCurrentType(F), SetPointCurrentType(E), SetB1, SetB2, 0);
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


                Core.Entities.ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 30 * LineBoundArgument);
                Core.Entities.ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(F), W_Base.PointY + 30 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                Core.Entities.ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                Core.Entities.ShapePoint bs12 = GetNewCustomPoint(SetPointCurrentValueX(E), Z_Base.PointY + 30 * LineBoundArgument);
                Core.Entities.ShapePoint be12 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 30 * LineBoundArgument);
                Line bl12 = GetNewLine(bs12, be12);
                Core.Entities.ShapePoint b12center = GetNewCustomPoint(SetPointCurrentValueX(E) + (bl12.Length / 2), Z_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, bs12, be12);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b12center, sf);

                //B1 вп
                Core.Entities.ShapePoint b1s1 = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(C));
                Core.Entities.ShapePoint b1e1 = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                Line b12h = GetNewLine(b1s1, b1e1);
                Core.Entities.ShapePoint b12scenter = GetNewCustomPoint(Y_Base.PointX + 15 * LineBoundArgument, Y_Base.PointY + b12h.Length / 2);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b12scenter, sf);
                //B1 нп
                Core.Entities.ShapePoint b12s1 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(F));
                Core.Entities.ShapePoint b12e1 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, Z_Base.PointY);
                graphicsShape.DrawLine(pen, b12s1, b12e1);
                Line b22h = GetNewLine(b12s1, b12e1);
                Core.Entities.ShapePoint b22scenter = GetNewCustomPoint(Z_Base.PointX + 15 * LineBoundArgument, Z_Base.PointY - b22h.Length / 2);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b22scenter, sf);
                //B1 нл
                Core.Entities.ShapePoint b12s11 = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + 30 * LineBoundArgument);
                Core.Entities.ShapePoint b12e11 = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b12s11, b12e11);
                Line b221h = GetNewLine(b12s11, b12e11);
                Core.Entities.ShapePoint b221scenter = GetNewCustomPoint(W_Base.PointX + b221h.Length / 2, W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b221scenter, sf);
                //B2 нл
                Core.Entities.ShapePoint b2s = GetNewCustomPoint(X_Base.PointX, W_Base.PointY + 10 * LineBoundArgument);
                Core.Entities.ShapePoint b2e = GetNewCustomPoint(X_Base.PointX + SetB2, W_Base.PointY + 10 * LineBoundArgument);
                Line lb2 = GetNewLine(b2s, b2e);
                Core.Entities.ShapePoint b2center = GetNewCustomPoint(X_Base.PointX + (lb2.Length / 2), Z_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b2s, b2e);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2center, sf);

                //B2 нп
                Core.Entities.ShapePoint b2s1 = GetNewCustomPoint(Y_Base.PointX, W_Base.PointY + 10 * LineBoundArgument);
                Core.Entities.ShapePoint b2e1 = GetNewCustomPoint(Y_Base.PointX - SetB2, W_Base.PointY + 10 * LineBoundArgument);
                Line lb21 = GetNewLine(b2s1, b2e1);
                Core.Entities.ShapePoint b21center = GetNewCustomPoint(Y_Base.PointX - (lb21.Length / 2), W_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21center, sf);

                Core.Entities.ShapePoint shapeCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX + E.PointX + F.PointX) / 6), ((A.PointY + B.PointY + C.PointY + D.PointY + E.PointY + F.PointY) / 6));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("22", drawNumbertBold, Brushes.Black, shapeCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    Core.Entities.ShapePoint wer = GetNewCustomPoint(Y_Base.PointX, SetPointCurrentValueY(D));
                    Core.Entities.ShapePoint wer1 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(C));
                    Core.Entities.ShapePoint wer2 = GetNewCustomPoint(Y_Base.PointX, SetPointCurrentValueY(F));
                    Core.Entities.ShapePoint wer3 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                    Core.Entities.ShapePoint wer4 = GetNewCustomPoint(W_Base.PointX + SetB2, W_Base.PointY);
                    Core.Entities.ShapePoint wer5 = GetNewCustomPoint(Z_Base.PointX - SetB2, Z_Base.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(F));
                        graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(A));
                    }
                    graphicsShape.DrawLine(pens, b12e1, Z_Base);
                    graphicsShape.DrawLine(pens, b12s1, SetPointCurrentType(F));
                    graphicsShape.DrawLine(pens, b12e11, W_Base);
                    graphicsShape.DrawLine(pens, b12s11, SetPointCurrentType(B));
                    graphicsShape.DrawLine(pens, b1e1, Y_Base);
                    graphicsShape.DrawLine(pens, b1s1, wer);
                    graphicsShape.DrawLine(pens, bs12, SetPointCurrentType(E));
                    graphicsShape.DrawLine(pens, be12, Z_Base);
                    graphicsShape.DrawLine(pens, b2e, wer4);
                    graphicsShape.DrawLine(pens, b2e1, wer5);
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(F));
                }
            }
            #endregion
        }
        protected override void FindPointDrawLine(Core.Entities.ShapePoint firsrPoint, Core.Entities.ShapePoint secondPoint, double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;
            Core.Entities.ShapePoint point = GetNewCustomPoint((firsrPoint.PointX- anotherFactor + factor), (firsrPoint.PointY));
            Line fdfLine = GetNewLine(point, firsrPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = (180 - CalculateAngle(B, C, D)) / 2;
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            Core.Entities.ShapePoint customPoint = GetNewPoint();
            customPoint = SetCurrentLineLength(firsrPoint, secondPoint, length);
            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                graphicsShape.DrawLine(pen, secondPoint, customPoint);
            }

        }
        private void FindPointDrawLine1(Core.Entities.ShapePoint firsrPoint, Core.Entities.ShapePoint secondPoint, double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;
            Core.Entities.ShapePoint point = GetNewCustomPoint((firsrPoint.PointX + anotherFactor - factor), (firsrPoint.PointY));
            Line fdfLine = GetNewLine(point, firsrPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = (180 - CalculateAngle(B, C, D)) / 2;
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            Core.Entities.ShapePoint customPoint = GetNewPoint();
            customPoint = SetCurrentLineLength(firsrPoint, secondPoint, length);
            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                graphicsShape.DrawLine(pen, secondPoint, customPoint);
            }

        }
        public override double SetL { get => Math.Round(F_line.Length, 0); set => base.SetL = value; }
        public override double SetL_t { get => Math.Round(F_line.Length, 0); }
        protected override void SetLValue()
        {
            base.SetLValue();
            TempPoint.PointX = SetCurrentLineLength(A, F, _SetL).PointX;
            TempPoint.PointY = SetCurrentLineLength(A, F, _SetL).PointY;
            F.PointX = TempPoint.PointX;
            F.PointY = A.PointY;
            var Xp = GetNewPoint();
            var Yp = GetNewPoint();
            Xp.PointX = B.PointX;
            Yp.PointX = B.PointY;
            Yp.PointX = C.PointX;
            Yp.PointY = C.PointY;
            B.PointX = (F.PointX - A.PointX) * Math.Cos(-2.0944) - (F.PointY - A.PointY) * Math.Sin(-2.0944) + A.PointX;
            B.PointY = (F.PointX - A.PointX) * Math.Sin(-2.0944) + (F.PointY - A.PointY) * Math.Cos(-2.0944) + A.PointY;
            C.PointX = (A.PointX - B.PointX) * Math.Cos(-2.0944) - (A.PointY - B.PointY) * Math.Sin(-2.0944) + B.PointX;
            C.PointY = (A.PointX - B.PointX) * Math.Sin(-2.0944) + (A.PointY - B.PointY) * Math.Cos(-2.0944) + B.PointY;
            D.PointX = (B.PointX - C.PointX) * Math.Cos(-2.0944) - (B.PointY - C.PointY) * Math.Sin(-2.0944) + C.PointX;
            D.PointY = (B.PointX - C.PointX) * Math.Sin(-2.0944) + (B.PointY - C.PointY) * Math.Cos(-2.0944) + C.PointY;
            E.PointX = (C.PointX - D.PointX) * Math.Cos(-2.0944) - (C.PointY - D.PointY) * Math.Sin(-2.0944) + D.PointX;
            E.PointY = (C.PointX - D.PointX) * Math.Sin(-2.0944) + (C.PointY - D.PointY) * Math.Cos(-2.0944) + D.PointY;
            var Xdiff = Xp.PointX - B.PointX;
            var Ydiff = Yp.PointY - C.PointY;
            Move(Xdiff, Ydiff);
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {

            List<Core.Entities.ShapePoint> pointList = new List<Core.Entities.ShapePoint>() { A, B, C, D, E, F, ACheck, BCheck, CCheck, DCheck, ECheck, FCheck };

            var PointXMax = pointList.Max(PointX => PointX.PointX);
            var yMax = pointList.Max(PointX => PointX.PointY);
            var PointXMin = pointList.Min(PointX => PointX.PointX);
            var yMin = pointList.Min(PointX => PointX.PointY);
            W_Base = new Core.Entities.ShapePoint(PointXMin, yMax);
            X_Base = new Core.Entities.ShapePoint(PointXMin, yMin);
            Y_Base = new Core.Entities.ShapePoint(PointXMax, yMin);
            Z_Base = new Core.Entities.ShapePoint(PointXMax, yMax);

        }
        public override bool CheckValidSize()
        {
            double diag1 = 0;
            double diag2 = 0;
            double diag3 = 0;
            double diag4 = 0;

            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
               _CheckCut1 / (90 - ((180 - Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag2 = (diag2 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                _CheckCut2 / (90 - ((180 - Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag3 = (diag3 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(D,E,F) * Math.PI / 180) :
                 _CheckCut4 / (90 - ((180 - Math.Sin(CalculateAngle(D, E, F)) * Math.PI / 180)));
            diag4 = (diag4 <= 90) ? _CheckCut5 / Math.Sin(CalculateAngle(D, E, F) * Math.PI / 180) :
               _CheckCut5 / (90 - ((180 - Math.Sin(CalculateAngle(D, E, F)) * Math.PI / 180)));

            diag1 = (!IsToothVector==true) ? 0 : diag1;
            diag2 = (!IsToothVector==true) ? 0 : diag2;
            diag3 = (!IsToothVector==true) ? 0 : diag3;
            diag4 = (!IsToothVector == true) ? 0 : diag4;

            var value1 = (IsToothVector==true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector==true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector==true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector==true) ? _CheckCut4 : 0;
            var value5 = (IsToothVector==true) ? _CheckCut5 : 0;
            var value6 = (IsToothVector == true) ? _CheckCut6 : 0;

            var width = _SetL*2  + SetB1*2 + diag1+ diag2+diag3+diag4;
            var height = width/0.8;

            if (_SetH < 0 || _SetH1 < 0 || _SetH2 < 0 || _SetL < 0 || _SetL1 < 0 || _SetL2 < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0)
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsSelectSameAllowance");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut2");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut3");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut4");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut5");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut6");
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


