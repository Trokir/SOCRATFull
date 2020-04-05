using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Mvvm.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;

namespace Socrat.Shape.Rectangles
{
    sealed class Shape_1 : Rectangular
    {
        public Shape_1(List<Core.Entities.ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
        protected override void DrawMainLines()
        {
            if (IsToothVector)
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

        private void MoveLines()
        {
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                pen.DashStyle = DashStyle.DashDot;
                MoveBorderRight(Z_Base, Y_Base, SetB1);
                MoveBorderLeft(W_Base, X_Base, SetB3);
                MoveBorderTop(X_Base, Y_Base, SetB2);
            }
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
        public override void GetShapeComponents()
        {
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                graphicsShape.DrawLine(pen, W_Base, X_Base);
                graphicsShape.DrawLine(pen, X_Base, Y_Base);
                graphicsShape.DrawLine(pen, Y_Base, Z_Base);
                graphicsShape.DrawLine(pen, Z_Base, W_Base);
            }
            #region BasePath

            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                Core.Entities.ShapePoint hs = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(B));
                Core.Entities.ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(A));
                Line lh = GetNewLine(hs, he);
                Core.Entities.ShapePoint hcenter = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(A) - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hcenter, sf);
                Core.Entities.ShapePoint b2s = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(B));
                Core.Entities.ShapePoint b2e = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                Core.Entities.ShapePoint b2scenter = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);

                Core.Entities.ShapePoint h1s = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(C));
                Core.Entities.ShapePoint h1e = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(D));
                Line lh1 = GetNewLine(h1s, h1e);
                Core.Entities.ShapePoint h1center = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(D) - (lh1.Length / 2));
                graphicsShape.DrawLine(pen, h1s, h1e);
                graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, h1center, sf);


                Core.Entities.ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 10 * LineBoundArgument);
                Core.Entities.ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 10 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                Core.Entities.ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), W_Base.PointY + 12 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                Core.Entities.ShapePoint b3s = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 10 * LineBoundArgument);
                Core.Entities.ShapePoint b3e = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 10 * LineBoundArgument);
                Line lb3 = GetNewLine(b3s, b3e);
                Core.Entities.ShapePoint b3center = GetNewCustomPoint(SetPointCurrentValueX(A) - (lb3.Length / 2), W_Base.PointY + 25 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b3s, b3e);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b3center, sf);

                Core.Entities.ShapePoint b1s = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 10 * LineBoundArgument);
                Core.Entities.ShapePoint b1e = GetNewCustomPoint(Z_Base.PointX, W_Base.PointY + 10 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                Core.Entities.ShapePoint b1center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), W_Base.PointY + 25 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                Core.Entities.ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("1", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    Core.Entities.ShapePoint wer = GetNewCustomPoint(SetPointCurrentValueX(B), Y_Base.PointY);
                    Core.Entities.ShapePoint wer1 = GetNewCustomPoint(SetPointCurrentValueX(C), Y_Base.PointY);
                    graphicsShape.DrawLine(pens, Y_Base, b2e);
                    graphicsShape.DrawLine(pens, SetPointCurrentType(B), b2s);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(C));
                    }
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, h1s, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, he, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, b3e, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, b3s, W_Base);
                    graphicsShape.DrawLine(pens, b1s, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, b1e, Z_Base);

                }
            }


            #endregion
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
        public override double SetH
        {
            get => Math.Round(A_line.Length, 0);
            set
            {
                TempValue = SetH;
                SetField(ref _SetH, value, () => SetH);
                if (!CheckValidSize()) SetHValue();
                else
                {
                    _SetH = TempValue;
                    return;
                }
            }
        }
        public override double SetH1
        {
            get => Math.Round(C_line.Length, 0);
            set
            {
                TempValue = SetH1;
                SetField(ref _SetH1, value, () => SetH1);
                if (!CheckValidSize()) SetH1Value();
                else
                {
                    _SetH1 = TempValue;
                    return;
                }
            }
        }
        public override double SetL
        {
            get => Math.Round(D_line.Length, 0);
            set
            {
                TempValue = SetL;
                SetField(ref _SetL, value, () => SetL);
                if (!CheckValidSize()) SetLValue();
                else
                {
                    _SetL = TempValue;
                    return;
                }
            }
        }
        public override double SetH_t => Math.Round(A_Check_Line.Length, 0);
        public override double SetH1_t => Math.Round(C_Check_Line.Length, 0);
        public override double SetL_t => Math.Round(D_Check_Line.Length, 0);
        protected override void SetHValue()
        {

            base.SetHValue();
            TempPoint.PointX = SetCurrentLineLength(B, A, _SetH).PointX;
            TempPoint.PointY = SetCurrentLineLength(B, A, _SetH).PointY;
            var diff = A.PointY - TempPoint.PointY;
            C.PointY -= diff;
            A.PointX = TempPoint.PointX;
            A.PointY = TempPoint.PointY;
            D.PointY = A.PointY;
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            //  if (IsToothVector) { SetZeroChecCutValue(); }
            C.PointX = D.PointX;
            C.PointX = SetCurrentLineLength(D, C, _SetH1).PointX;
            C.PointY = SetCurrentLineLength(D, C, _SetH1).PointY;
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
        public override double SetB2
        {
            get => _SetB2;

            set
            {
                TempValue = SetB2;
                SetField(ref _SetB2, value, () => SetB2);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    SetB2 = TempValue;
                    return;
                }
            }
        }
        public override double SetB3
        {
            get => _SetB3;

            set
            {
                TempValue = SetB3;
                SetField(ref _SetB3, value, () => SetB3);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    SetB3 = TempValue;
                    return;
                }
            }
        }
        public override double CheckCut1
        {
            get => _CheckCut1;

            set
            {
                TempValue = CheckCut1;
                SetField(ref _CheckCut1, value, () => CheckCut1);
                if (!CheckValidSize())
                {
                    if (IsSelectSameAllowance)
                    {
                        CheckCut2 = _CheckCut1;
                        CheckCut3 = _CheckCut1;
                        CheckCut4 = _CheckCut1;
                        IsSelectSameAllowance = false;
                    }
                    else { return; }
                    if (IsToothVector)
                    {
                        Move(CheckCut1, 0);
                    }
                    ValidValue = false;
                }
                else
                {
                    CheckCut1 = TempValue;
                    return;
                }
            }
        }
        public override double CheckCut2
        {
            get => _CheckCut2;
            set
            {
                TempValue = CheckCut2;
                SetField(ref _CheckCut2, value, () => CheckCut2);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    CheckCut2 = TempValue;
                    return;
                }
            }
        }
        public override double CheckCut3
        {
            get => _CheckCut3;
            set
            {
                TempValue = CheckCut3;
                SetField(ref _CheckCut3, value, () => CheckCut3);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    CheckCut3 = TempValue;
                    return;
                }
            }
        }
        public override double CheckCut4
        {
            get => _CheckCut4;
            set
            {
                TempValue = CheckCut4;
                SetField(ref _CheckCut4, value, () => CheckCut4);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    CheckCut4 = TempValue;
                    return;
                }
            }
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
            diag = (diag <= 90)
                ? CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180)
                : (90 - ((180 - CheckCut2 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag = (!IsToothVector) ? 0 : diag;
            var value1 = (IsToothVector) ? _CheckCut1 : 0;
            var value2 = (IsToothVector) ? _CheckCut2 : 0;
            var value3 = (IsToothVector) ? _CheckCut3 : 0;
            var value4 = (IsToothVector) ? _CheckCut4 : 0;
            var width = _SetL + _SetB1 + _SetB3 + value1 + value3;
            var height = _SetH + diag + _SetB2 + value4;

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
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsSelectSameAllowance");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut2");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut3");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut4");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsCuttingGlass");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsBendingDistanceFrame");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsFormSealing");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsGasFillingForm");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsVertBendingMashineRobot");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsVertMashineEdgeMaking");

                e.Properties = filteredCollection;
            }
        }
    }
}
