using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Shape.Pentagons
{
    sealed class Shape_7 : Pentagon
    {
        public Shape_7(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
        public override double Perimeter
        {
            get
            {
                return Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length + E_line.Length) / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get
            {
                return Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length +
                    D_Check_Line.Length + E_Check_Line.Length) / 1000, 3);
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
                    graphicsShape.DrawLine(pen4, D, E);
                }
                using (pen5 = new Pen(SelectMainLineColor5(), ThiсknessArgument / 2))
                {
                    pen5.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen5, E, A);
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
                    graphicsShape.DrawLine(pen4, D, E);
                }
                using (pen5 = new Pen(SelectMainLineColor5(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen5, E, A);
                }
                IsToothVector = false;
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
                MoveBorderTop(X_Base, Y_Base, SetB2);
                MoveBorderRight(Y_Base, Z_Base, SetB3);
                MoveBorderBottom(W_Base, Z_Base, SetB2);
            }
        }

        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D, E };
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
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;

                ShapePoint hs = GetNewCustomPoint(Y_Base.PointX + 25 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 25 * LineBoundArgument, SetPointCurrentValueY(E));
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Y_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(E) - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hcenter, sf);

                ShapePoint h1s = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(D));
                ShapePoint h1e = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(E));
                Line lh1 = GetNewLine(h1s, h1e);
                ShapePoint h1center = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(E) - (lh1.Length / 2));
                graphicsShape.DrawLine(pen, h1s, h1e);
                graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, h1center, sf);

                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 35 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(E), Z_Base.PointY + 35 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), Z_Base.PointY + 35 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                if (ll.Length > 8)
                {
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);
                }

                ShapePoint b2s1 = GetNewCustomPoint(Y_Base.PointX + 25 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint b2e1 = GetNewCustomPoint(Y_Base.PointX + 25 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                Line b2h1 = GetNewLine(b2s1, b2e1);
                ShapePoint b21scenter = new ShapePoint(Y_Base.PointX + 30 * LineBoundArgument, Y_Base.PointY + b2h1.Length / 2);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21scenter, sf);


                ShapePoint b2s = GetNewCustomPoint(Z_Base.PointX + 25 * LineBoundArgument, SetPointCurrentValueY(E));
                ShapePoint b2e = GetNewCustomPoint(Z_Base.PointX + 25 * LineBoundArgument, Z_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, Z_Base.PointY - b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);



                ShapePoint l1s = GetNewCustomPoint(SetPointCurrentValueX(C), W_Base.PointY + 7 * LineBoundArgument);
                ShapePoint l1e = GetNewCustomPoint(SetPointCurrentValueX(E), W_Base.PointY + 7 * LineBoundArgument);
                Line ll1 = GetNewLine(ls, le);
                ShapePoint l1center = GetNewCustomPoint(SetPointCurrentValueX(C), W_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l1s, l1e);
                graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l1center, sf);

                ShapePoint l2s = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 7 * LineBoundArgument);
                ShapePoint l2e = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + 7 * LineBoundArgument);
                Line ll2 = GetNewLine(ls, le);
                ShapePoint l2center = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l2s, l2e);
                graphicsShape.DrawString("L2=" + SetCurrentSize(SetL2), drawFontBold, Brushes.Black, l2center, sf);



                ShapePoint b1s = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 35 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 35 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 35 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint b3s = GetNewCustomPoint(SetPointCurrentValueX(E), Z_Base.PointY + 35 * LineBoundArgument);
                ShapePoint b3e = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 35 * LineBoundArgument);
                Line lb3 = GetNewLine(b3s, b3e);
                ShapePoint b3center = GetNewCustomPoint(Z_Base.PointX + (lb3.Length / 2), Z_Base.PointY + 35 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b3s, b3e);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b3center, sf);



                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX + E.PointX) / 5), ((A.PointY + B.PointY + C.PointY + D.PointY + E.PointY) / 5));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("7", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    ShapePoint wer = GetNewCustomPoint(Y_Base.PointX, SetPointCurrentValueY(C));
                    ShapePoint wer1 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(B));
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(B));
                    }
                    graphicsShape.DrawLine(pens, b2e1, Y_Base);
                    graphicsShape.DrawLine(pens, b2s1, wer);
                    graphicsShape.DrawLine(pens, b2e, Z_Base);
                    graphicsShape.DrawLine(pens, b2s, SetPointCurrentType(E));
                    graphicsShape.DrawLine(pens, b1e, W_Base);
                    graphicsShape.DrawLine(pens, b1s, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, b3e, Z_Base);
                    graphicsShape.DrawLine(pens, b3s, SetPointCurrentType(E));
                    graphicsShape.DrawLine(pens, h1s, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, l1e, SetPointCurrentType(E));
                    graphicsShape.DrawLine(pens, l2s, SetPointCurrentType(A));

                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, l1s, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pens1, l2e, SetPointCurrentType(B));
                    }
                }
            }

            #endregion
        }
        public override double SetH { get => Math.Round(GetNewLine(E, GetNewCustomPoint(E.PointX, C.PointY)).Length, 0); set => base.SetH = value; }
        public override double SetH1 { get => Math.Round(D_line.Length, 0); set => base.SetH1 = value; }
        public override double SetL { get => Math.Round(E_line.Length, 0); set => base.SetL = value; }
        public override double SetL1 { get => Math.Round(GetNewLine(C, GetNewCustomPoint(D.PointX, C.PointY)).Length, 0); set => base.SetL1 = value; }
        public override double SetL2 { get => Math.Round(GetNewLine(B, GetNewCustomPoint(A.PointX, B.PointY)).Length, 0); set => base.SetL2 = value; }
        protected override void SetHValue()
        {
            base.SetHValue();
            CurvePoint.PointX = A.PointX;
            CurvePoint.PointY = B.PointY;
            TempPoint.PointX = SetCurrentLineLength(CurvePoint, A, _SetH).PointX;
            TempPoint.PointY = SetCurrentLineLength(CurvePoint, A, _SetH).PointY;
            double diff = A.PointY - TempPoint.PointY;
            D.PointY -= diff;
            A.PointX = TempPoint.PointX;
            A.PointY = TempPoint.PointY;
            E.PointY = A.PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            double s = C.PointX;
            TempPoint.PointX = A.PointX + (E.PointX - A.PointX) * (_SetL / Math.Sqrt(Math.Pow((E.PointX - A.PointX), 2) + Math.Pow((E.PointY - A.PointY), 2)));
            TempPoint.PointY = A.PointY + (E.PointY - A.PointY) * (_SetL / Math.Sqrt(Math.Pow((E.PointX - A.PointX), 2) + Math.Pow((E.PointY - A.PointY), 2)));
            double diff = E.PointX - TempPoint.PointX;
            C.PointX -= diff;
            E.PointX = TempPoint.PointX;
            E.PointY = TempPoint.PointY;
            D.PointX = E.PointX;
            ValidValue = false;
        }
        protected override void SetL2Value()
        {
            CurvePoint.PointX = A.PointX;
            CurvePoint.PointY = B.PointY;
            B.PointX = SetCurrentLineLength(CurvePoint, B, _SetL2).PointX;
            B.PointY = SetCurrentLineLength(CurvePoint, B, _SetL2).PointY;
            C.PointY = B.PointY;
            if (B.PointX >= C.PointX)
            {
                B.PointX = C.PointX - 2;
            }
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            CurvePoint.PointX = D.PointX;
            CurvePoint.PointY = C.PointY;
            C.PointX = SetCurrentLineLength(CurvePoint, C, _SetL1).PointX;
            C.PointY = SetCurrentLineLength(CurvePoint, C, _SetL1).PointY;
            B.PointY = C.PointY;
            if (C.PointX <= B.PointX)
            {
                C.PointX = B.PointX + 2;
            }
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            D.PointX = E.PointX;
            D.PointX = SetCurrentLineLength(E, D, _SetH1).PointX;
            D.PointY = SetCurrentLineLength(E, D, _SetH1).PointY;
            ValidValue = false;
        }
        public override double SetH_t
        {
            get
            {
                ShapePoint Sh = GetNewCustomPoint(ECheck.PointX, CCheck.PointY);
                Line l = GetNewLine(ECheck, Sh);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetL_t { get => Math.Round(E_Check_Line.Length, 0); }
        public override double SetL1_t
        {
            get
            {
                CurvePoint.PointX = DCheck.PointX;
                CurvePoint.PointY = CCheck.PointY;
                Line l = new Line(CurvePoint, CCheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetL2_t
        {
            get
            {
                CurvePoint.PointX = ACheck.PointX;
                CurvePoint.PointY = BCheck.PointY;
                Line l = new Line(CurvePoint, BCheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetH1_t
        {
            get => Math.Round(D_Check_Line.Length, 0);
        }
        public override double SetB1
        {
            get => _SetB1;

            set
            {
                TempValue = SetB1;
                SetField(ref _SetB1, value, () => SetB1);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    SetB1 = TempValue;
                    return;
                }
            }
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, B, C, D, E, ACheck, BCheck, CCheck, DCheck, ECheck };

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
                ? CheckCut2 / Math.Sin(CalculateAngle(E, A, B) * Math.PI / 180)
                : (90 - ((180 - CheckCut2 / Math.Sin(CalculateAngle(E, A, B)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            var value1 = (IsToothVector == true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector == true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector == true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var value5 = (IsToothVector == true) ? _CheckCut5 : 0;
            var width = _SetL + diag + value4;
            var height = _SetH + _SetB1 + SetB2 + value5 + value2;

            if (_SetH < 0 || _SetH1 < 0 || _SetL < 0 || _SetL1 < 0 || _SetL2 < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0)
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
            else if ((_SetH > 0) && _SetH < SetH1)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H не может быть меньше H1");
            }
            else if ((_SetH1 > 0) && _SetH1 > SetH)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H1 не может быть больше H");
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
            if (Math.Abs(CheckCut3) > SetL1 || Math.Abs(CheckCut4) > SetL1)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Некорректное значение отступа");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL2_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsSelectSameAllowance");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut2");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut3");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut4");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut5");
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


