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
     sealed class Shape_44 : Triangle
    {
        public Shape_44(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
        }
        public override double Perimeter
        {
            get
            {
                return Math.Round((A_line.Length + B_line.Length + C_line.Length) / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get
            {
                return Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length) / 1000, 3);
            }
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
                    graphicsShape.DrawLine(pen3, C, A);
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
                    graphicsShape.DrawLine(pen3, C, A);
                }
            }
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetBasePoints());
            MoveLines();
        }
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C };
        }
        protected override void CheckForeignBorders()
        {
            GetExtremumPoints();
            AllowanceProcessing();
        }

        private void MoveLines()
        {
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
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
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                pen.DashStyle = DashStyle.DashDot;
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

                ShapePoint b1s = GetNewCustomPoint(W_Base.PointX + SetB1, W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 20 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);


                ShapePoint b1s1 = GetNewCustomPoint(Z_Base.PointX - SetB1, W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                Line lb11 = GetNewLine(b1s1, b1e1);
                ShapePoint b11center = GetNewCustomPoint(Z_Base.PointX - (lb11.Length / 2), Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b11center, sf);

                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(C), Z_Base.PointY + 20 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetL, drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint l2s = GetNewPoint();
                ShapePoint l2e = GetNewPoint();
                l2s.PointX = SetPointCurrentType(C).PointX;
                l2s.PointY = SetPointCurrentType(C).PointY;
                l2s.PointX += 10 * LineBoundArgument;
                l2s.PointY -= 10 * LineBoundArgument;
                l2e.PointX = SetPointCurrentType(B).PointX;
                l2e.PointY = SetPointCurrentType(B).PointY;
                l2e.PointX += 10 * LineBoundArgument;
                l2e.PointY -= 10 * LineBoundArgument;
                Line ll2 = GetNewLine(l2s, l2e);
                ShapePoint l2center = GetNewCustomPoint(l2e.PointX + 50*LineBoundArgument , l2s.PointY - (ll2.Length / 2));
                graphicsShape.DrawLine(pen, l2s, l2e);
                graphicsShape.DrawString("L2=" + SetL2, drawFontBold, Brushes.Black, l2center, sf);


                ShapePoint l1s = GetNewPoint();
                ShapePoint l1e = GetNewPoint();
                l1s.PointX = SetPointCurrentType(A).PointX;
                l1s.PointY = SetPointCurrentType(A).PointY;
                l1s.PointX -= 10 * LineBoundArgument;
                l1s.PointY -= 10 * LineBoundArgument;
                l1e.PointX = SetPointCurrentType(B).PointX;
                l1e.PointY = SetPointCurrentType(B).PointY;
                l1e.PointX -= 10 * LineBoundArgument;
                l1e.PointY -= 10 * LineBoundArgument;
                Line ll1 = GetNewLine(l1s, l1e);
                ShapePoint l1center = GetNewCustomPoint(l1s.PointX + 50 * LineBoundArgument, l1s.PointY - ll1.Length / 2);
                graphicsShape.DrawLine(pen, l1s, l1e);
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                graphicsShape.DrawString("L1=" + SetL1, drawFontBold, Brushes.Black, l1center, sf);


                ShapePoint b2s = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY);
                ShapePoint b2e = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + SetB2);
                graphicsShape.DrawLine(pen, b2s, b2e);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);

                ShapePoint b2s1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY);
                ShapePoint b2e1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY - SetB2);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                Line b2h1 = GetNewLine(b2s1, b2e1);
                var b21scenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY - b2h1.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21scenter, sf);


                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX) / 3), ((A.PointY + B.PointY + C.PointY) / 3));
                Font drawNumbertBold = new Font("Tahoma", 40+ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("44", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (var pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        if (CalculateAngle(C,A,B)<=90)
                        {
                            var wer1 = GetNewCustomPoint(X_Base.PointX, SetPointCurrentValueY(B));
                            var wer2 = GetNewCustomPoint(SetPointCurrentValueX(A), X_Base.PointY);
                            var wer7 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                            var wer8 = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY);
                            graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(A));
                            graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(B));
                            graphicsShape.DrawLine(pen1, wer7, SetPointCurrentType(A));
                            graphicsShape.DrawLine(pen1, wer8, SetPointCurrentType(A));
                        }
                        else
                        {
                            var wer1 = GetNewCustomPoint(X_Base.PointX, SetPointCurrentValueY(B));
                            var wer2 = GetNewCustomPoint(SetPointCurrentValueX(B), X_Base.PointY);
                            var wer7 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                            var wer8 = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY);
                            graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(B));
                            graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(B));
                            graphicsShape.DrawLine(pen1, wer7, SetPointCurrentType(A));
                            graphicsShape.DrawLine(pen1, wer8, SetPointCurrentType(B));
                        }
                        if (CalculateAngle(A, C, B) <= 90)
                        {
                            var wer3 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(B));
                            var wer4 = GetNewCustomPoint(SetPointCurrentValueX(C), Y_Base.PointY);
                            var wer5 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(C));
                            var wer6 = GetNewCustomPoint(SetPointCurrentValueX(C), Z_Base.PointY);
                            graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(B));
                            graphicsShape.DrawLine(pen1, wer4, SetPointCurrentType(C));
                            graphicsShape.DrawLine(pen1, wer5, SetPointCurrentType(C));
                            graphicsShape.DrawLine(pen1, wer6, SetPointCurrentType(C));
                        }
                        else
                        {
                            var wer3 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(B));
                            var wer4 = GetNewCustomPoint(SetPointCurrentValueX(B), Y_Base.PointY);
                            var wer5 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(C));
                            var wer6 = GetNewCustomPoint(SetPointCurrentValueX(B), Z_Base.PointY);
                            graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(B));
                            graphicsShape.DrawLine(pen1, wer4, SetPointCurrentType(B));
                            graphicsShape.DrawLine(pen1, wer5, SetPointCurrentType(C));
                            graphicsShape.DrawLine(pen1, wer6, SetPointCurrentType(B));

                        }

                    }
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, l1s, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, l2s, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, l1e, SetPointCurrentType(B));
                    graphicsShape.DrawLine(pens, l2e, SetPointCurrentType(B));
                    graphicsShape.DrawLine(pens, b1e, W_Base);
                    graphicsShape.DrawLine(pens, b1e1, Z_Base);
                }
                #endregion
            }
        }
        public override double SetL { get => Math.Round(C_line.Length, 0); set => base.SetL = value; }
        public override double SetL1 { get => Math.Round(A_line.Length, 0); set => base.SetL1 = value; }
        public override double SetL2 { get => Math.Round(B_line.Length, 0); set => base.SetL2 = value; }
        public override double SetL_t
        {
            get => Math.Round(C_Check_Line.Length, 0);
        }
        public override double SetL1_t
        {
            get => Math.Round(A_Check_Line.Length, 0);
        }
        public override double SetL2_t
        {
            get => Math.Round(B_Check_Line.Length, 0);
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            TempPoint.PointX = C.PointX;
            TempPoint.PointY = C.PointY;
            TempPoint.PointX = SetCurrentLineLength(A, C, _SetL ).PointX;
            TempPoint.PointY = SetCurrentLineLength(A, C, _SetL ).PointY;
            var diff = TempPoint.PointX - C.PointX;
            B.PointX += diff;
            C.PointX = TempPoint.PointX;
            C.PointY = TempPoint.PointY;
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            base.SetL1Value();
            Move(y:_SetL1/2);
            var a = Math.Pow(_SetL1, 2);
            var c = Math.Pow(SetL, 2);
            var b = Math.Pow(SetL2, 2);
            var re = 2 * _SetL1 * SetL;
            var alpha = Math.Acos((a + c - b) / re);
            B.PointX = (C.PointX - A.PointX) * Math.Cos(-alpha) + (C.PointY - A.PointY) * Math.Sin(-alpha) + A.PointX;
            B.PointY = (C.PointX - A.PointX) * Math.Sin(-alpha) - (C.PointY - A.PointY) * Math.Cos(-alpha) + A.PointY;
            TempPoint.PointX = SetCurrentLineLength(A, B, _SetL1).PointX;
            TempPoint.PointY = SetCurrentLineLength(A, B, _SetL1).PointY;
            B.PointX = TempPoint.PointX;
            B.PointY = TempPoint.PointY;
            ValidValue = false;
        }
        protected override void SetL2Value()
        {
           base.SetL2Value();
           Move(y: _SetL2 / 2);
            var a = Math.Pow(A_line.Length, 2);
            var c = Math.Pow(C_line.Length, 2);
            var b = Math.Pow(_SetL2, 2);
            var re = 2 * _SetL2 * C_line.Length;
            var alpha = Math.Acos((b + c - a) / re);
            B.PointX = (A.PointX - C.PointX) * Math.Cos(alpha) + (A.PointY - C.PointY) * Math.Sin(alpha) + C.PointX;
            B.PointY = (A.PointX - C.PointX) * Math.Sin(alpha) - (A.PointY - C.PointY) * Math.Cos(alpha) + C.PointY;
            TempPoint.PointX = SetCurrentLineLength(C, B, _SetL2).PointX;
            TempPoint.PointY = SetCurrentLineLength(C, B, _SetL2).PointY;
            B.PointX = TempPoint.PointX;
            B.PointY = TempPoint.PointY;
            ValidValue = false;
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
            double diag = 0;
            diag = (diag <= 90)
                ? CheckCut1 / Math.Sin(CalculateAngle(C, A, B) * Math.PI / 180)
                : (90 - ((180 - CheckCut1 / Math.Sin(CalculateAngle(C, A, B)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            double diag1 = 0;
            diag1 = (diag1 <= 90)
                ? CheckCut2 / Math.Sin(CalculateAngle(B, C, A) * Math.PI / 180)
                : (90 - ((180 - CheckCut2 / Math.Sin(CalculateAngle(B, C, A)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            double diag2 = 0;
            diag2 = (diag2 <= 90)
                ? CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180)
                : (90 - ((180 - CheckCut1 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            diag1 = (!IsToothVector == true) ? 0 : diag1;
            diag2 = (!IsToothVector == true) ? 0 : diag2;

            var value3 = (IsToothVector == true) ? _CheckCut3 : 0;
            var li = _SetL1 * Math.Sin(CalculateAngle(B, A, C) * Math.PI / 180);
            var width = _SetL + _SetB1 * 2 + diag1 + diag;
            var height = li + SetB2 * 2 + value3 + diag2;

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
            //else if (_SetL2 < SetL - SetL1)
            //{
            //    ValidValue = true;
            //    ValidateSetSizeMessage("Значение 'L2' не может быть меньше L - L1");
            //}
            else if (_SetL2 > SetL + SetL1)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L2' не может быть больше L + L1");
            }
            //else if (_SetL1 < SetL - SetL2)
            //{
            //    ValidValue = true;
            //    ValidateSetSizeMessage("Значение 'L1' не может быть меньше L-L2");
            //}
            else if (_SetL1 > SetL + SetL2)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L1' не может быть больше L + L2");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL2");
              
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL2_t");
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