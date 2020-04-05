using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using DevExpress.XtraVerticalGrid.Events;


namespace Socrat.Shape.Rectangles
{
    sealed class Shape_6 : Rectangular
    {
        public Shape_6(List<Core.Entities.ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
        }
        public override double Perimeter
        {
            get
            {
                return Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length) / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get
            {
                return Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length + D_Check_Line.Length) / 1000, 3);
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
                    graphicsShape.DrawLine(pen3, C, D);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument / 2))
                {
                    pen4.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen4, D, A);
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
                IsToothVector = false;
            }
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetBasePoints());
            MoveLines();
        }
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D };
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
                MoveBorderRight(Z_Base, Y_Base, SetB1);
                MoveBorderLeft(W_Base, X_Base, SetB3);
                MoveBorderTop(X_Base, Y_Base, SetB2);
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
            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;

                Core.Entities.ShapePoint hs = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(C));
                Core.Entities.ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(D));
                Line lh = GetNewLine(hs, he);
                Core.Entities.ShapePoint hcenter = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(D) - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                if (lh.Length > 8)
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    graphicsShape.DrawString("H=" + SetH, drawFontBold, Brushes.Black, hcenter, sf);
                }

                Core.Entities.ShapePoint b2s = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(C));
                Core.Entities.ShapePoint b2e = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                Core.Entities.ShapePoint b2scenter = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY + b2h.Length / 2);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);

                Core.Entities.ShapePoint b2s1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(D));
                Core.Entities.ShapePoint b2e1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                Line b2h1 = GetNewLine(b2s1, b2e1);
                Core.Entities.ShapePoint b21scenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY - b2h1.Length / 2);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21scenter, sf);

                Core.Entities.ShapePoint l1s = GetNewCustomPoint(SetPointCurrentValueX(C), W_Base.PointY + 10 * LineBoundArgument);
                Core.Entities.ShapePoint l1e = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 10 * LineBoundArgument);
                Line ll1 = GetNewLine(l1s, l1e);
                Core.Entities.ShapePoint l1center = GetNewCustomPoint(Y_Base.PointX - (ll1.Length / 2), W_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l1s, l1e);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                graphicsShape.DrawString("L2=" + SetL2, drawFontBold, Brushes.Black, l1center, sf);

                Core.Entities.ShapePoint l2s = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 10 * LineBoundArgument);
                Core.Entities.ShapePoint l2e = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + 10 * LineBoundArgument);
                Line ll2 = GetNewLine(l2s, l2e);
                Core.Entities.ShapePoint l2center = GetNewCustomPoint(X_Base.PointX + (ll2.Length / 2), W_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l2s, l2e);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                graphicsShape.DrawString("L1=" + SetL1, drawFontBold, Brushes.Black, l2center, sf);

                Core.Entities.ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 30 * LineBoundArgument);
                Core.Entities.ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(D), Z_Base.PointY + 30 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                Core.Entities.ShapePoint lcenter = GetNewCustomPoint(ACheck.PointX + (ll.Length / 2), Z_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                if (ll.Length > 8)
                {
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    graphicsShape.DrawString("L=" + SetL, drawFontBold, Brushes.Black, lcenter, sf);
                }
                Core.Entities.ShapePoint b1s = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Core.Entities.ShapePoint b1e = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 30 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                Core.Entities.ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b1center, sf);

                Core.Entities.ShapePoint b3s = GetNewCustomPoint(SetPointCurrentValueX(D), Z_Base.PointY + 30 * LineBoundArgument);
                Core.Entities.ShapePoint b3e = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 30 * LineBoundArgument);
                Line lb3 = GetNewLine(b3s, b3e);
                Core.Entities.ShapePoint b3center = GetNewCustomPoint(Z_Base.PointX - (lb3.Length / 2), Z_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b3s, b3e);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b3center, sf);


                Core.Entities.ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("6", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    Core.Entities.ShapePoint wer = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(C));
                    Core.Entities.ShapePoint wer1 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(B));
                    Core.Entities.ShapePoint wer2 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(D));
                    Core.Entities.ShapePoint wer3 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));

                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(A));
                    }
                    graphicsShape.DrawLine(pens, b1s, W_Base);
                    graphicsShape.DrawLine(pens, b1e, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, b3s, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, b3e, Z_Base);
                    graphicsShape.DrawLine(pens, SetPointCurrentType(C), b2s);
                    graphicsShape.DrawLine(pens, l1e, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, l2s, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, b2e1, Z_Base);
                    graphicsShape.DrawLine(pens, b2s1, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, b2e, Y_Base);
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, l1s, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pens1, l2e, SetPointCurrentType(B));
                    }
                }

            }


            #endregion
        }
        public override double SetH { get => Math.Round(GetNewLine(A, GetNewCustomPoint(A.PointX, B.PointY)).Length, 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(D_line.Length, 0); set => base.SetL = value; }
        public override double SetL1 { get => Math.Round(GetNewLine(B, GetNewCustomPoint(A.PointX, B.PointY)).Length, 0); set => base.SetL1 = value; }
        public override double SetL2 { get => Math.Round(GetNewLine(C, GetNewCustomPoint(D.PointX, C.PointY)).Length, 0); set => base.SetL2 = value; }
        public override double SetH_t
        {
            get
            {
                CurvePoint.PointX = ACheck.PointX;
                CurvePoint.PointY = BCheck.PointY;
                Line cu = GetNewLine(ACheck, CurvePoint);
                return Math.Round(cu.Length, 0);
            }
        }
        public override double SetL1_t
        {
            get
            {
                CurvePoint.PointX = ACheck.PointX;
                CurvePoint.PointY = BCheck.PointY;
                Line cu = GetNewLine(BCheck, CurvePoint);
                return Math.Round(cu.Length, 0);
            }
        }
        public override double SetL2_t
        {
            get
            {
                CurvePoint.PointX = DCheck.PointX;
                CurvePoint.PointY = CCheck.PointY;
                Line cu = GetNewLine(CCheck, CurvePoint);
                return Math.Round(cu.Length, 0);
            }

        }
        public override double SetL_t { get => Math.Round(D_Check_Line.Length, 0); }
        protected override void SetHValue()
        {
            base.SetHValue();
            C.PointY = B.PointY;
            CurvePoint.PointX = A.PointX;
            CurvePoint.PointY = B.PointY;
            A.PointY = SetCurrentLineLength(CurvePoint, A, _SetH).PointY;
            D.PointY = A.PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            if ((B_line.Length) > 2)
            {
                CurvePoint.PointX = SetCurrentLineLength(A, D, _SetL).PointX - D.PointX;
                Core.Entities.ShapePoint ePoint = GetNewPoint();
                C.PointX += CurvePoint.PointX;
                ePoint.PointX = C.PointX - B.PointX;
                if (ePoint.PointX < 0) { C.PointX = B.PointX + 0.1; }
                D.PointX = SetCurrentLineLength(A, D, _SetL).PointX;
                D.PointY = SetCurrentLineLength(A, D, _SetL).PointY;
            }
            else return;
            ValidValue = false;
        }
        protected override void SetL2Value()
        {
            CurvePoint.PointX = D.PointX;
            CurvePoint.PointY = C.PointY;
            C.PointX = SetCurrentLineLength(CurvePoint, C, _SetL2).PointX;
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            CurvePoint.PointX = A.PointX;
            CurvePoint.PointY = B.PointY;
            B.PointX = SetCurrentLineLength(CurvePoint, B, _SetL1).PointX;
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            B.PointX = A.PointX;
            B.PointX = SetCurrentLineLength(A, B, _SetH1).PointX;
            B.PointY = SetCurrentLineLength(A, B, _SetH1).PointY;
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {

            List<Core.Entities.ShapePoint> pointList = new List<Core.Entities.ShapePoint>() { A, B, C, D, ACheck, BCheck, CCheck, DCheck };

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
            double diag = 0;
            double diag1 = 0;
            diag = (diag <= 90)
                ? CheckCut1 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180)
                : (90 - ((180 - CheckCut1 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));
            diag1 = (diag1 <= 90)
               ? CheckCut3 / Math.Sin(CalculateAngle(C, D, A) * Math.PI / 180)
               : (90 - ((180 - CheckCut3 / Math.Sin(CalculateAngle(C, D, A)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            diag1 = (!IsToothVector == true) ? 0 : diag1;
            var value1 = (IsToothVector==true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector==true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector==true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var width = _SetL + _SetB1 + _SetB3 + diag + diag1;
            var height = _SetH + _SetB2 * 2 + value4 + value2;

            if (_SetH < 0 || _SetL < 0 || _SetL1 < 0 || _SetL2 < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0)
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
            else if ((_SetL1 > 0) && _SetL1 > SetL - SetL2)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L не может быть меньше L-L2");
            }
            else if ((_SetL2 > 0) && _SetL2 > SetL - SetL1)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L не может быть меньше L-L2");
            }
            else if ((_SetL > 0) && _SetL < SetL1 + SetL2)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L не может быть меньше L1+L2");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL2");

                AddIfPropertyExist(e.Properties, filteredCollection, "SetB1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB2");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB3");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL2_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
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
