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
    sealed class Shape_31: Rectangular
    {
        public Shape_31(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
        protected override void DrawMainLines()
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
                MoveBorderLeft(W_Base, X_Base, SetB1);
            }
            using (Pen pen3 = new Pen(Color.Black, ThiсknessArgument))
            {
                graphicsShape.DrawLine(pen3, A_upFault, B_upFault);
                graphicsShape.DrawLine(pen3, A_downFault, B_downFault);
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
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;

                ShapePoint hs = GetNewCustomPoint(Z_Base.PointX +40 * LineBoundArgument, BCheck.PointY);
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX +40 * LineBoundArgument, ACheck.PointY);
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, ACheck.PointY - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                    graphicsShape.DrawString("H=" + SetH, drawFontBold, Brushes.Black, hcenter, sf);

                ShapePoint h2s = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, CCheck.PointY);
                ShapePoint h2e = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, B_downFault.PointY);
                graphicsShape.DrawLine(pen, h2s, h2e);
                Line h2h = GetNewLine(h2s, h2e);
                ShapePoint h2scenter = GetNewCustomPoint(Y_Base.PointX + 15 * LineBoundArgument, B_upFault.PointY - h2h.Length / 2);
                Line A_up = GetNewLine(C, B_upFault);
                graphicsShape.DrawString("H2=" + (C_line.Length - (C_line.Length - A_up.Length)), drawFontBold, Brushes.Black, h2scenter, sf);



                ShapePoint h1s = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, A_upFault.PointY);
                ShapePoint h1e = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, ACheck.PointY);
                Line lh1 = GetNewLine(h1s, h1e);
                ShapePoint h1center = GetNewCustomPoint(Z_Base.PointX +15 * LineBoundArgument, ACheck.PointY - (lh1.Length / 2));
                graphicsShape.DrawLine(pen, h1s, h1e);
                    Line B_up = GetNewLine(A, A_upFault);
                    graphicsShape.DrawString("H1=" + (A_line.Length - (A_line.Length - B_up.Length)), drawFontBold, Brushes.Black, h1center, sf);

                ShapePoint ls = GetNewCustomPoint(ACheck.PointX, ACheck.PointY + 20 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(DCheck.PointX, DCheck.PointY + 20 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(ACheck.PointX + (ll.Length / 2), ACheck.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetL, drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint b1s = GetNewCustomPoint(W_Base.PointX, ACheck.PointY + 20 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(ACheck.PointX, ACheck.PointY + 20 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), ACheck.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint b1s1 = GetNewCustomPoint(DCheck.PointX, DCheck.PointY + 20 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, ACheck.PointY + 20 * LineBoundArgument);
                Line lb11 = GetNewLine(b1s1, b1e1);
                ShapePoint b11center = GetNewCustomPoint(Z_Base.PointX - (lb11.Length / 2), ACheck.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b11center, sf);


                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40+ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("31", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    graphicsShape.DrawLine(pens, h2e, B_upFault);
                    graphicsShape.DrawLine(pens, he, DCheck);
                    graphicsShape.DrawLine(pens, hs, CCheck);
                    graphicsShape.DrawLine(pens, b1s, W_Base);
                    graphicsShape.DrawLine(pens, b1e, ACheck);
                    graphicsShape.DrawLine(pens, b1e1, Z_Base);
                    graphicsShape.DrawLine(pens, b1s1, DCheck);
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, h1s, A_downFault);
                    }
                }
            }
            #endregion
        }
        public override double Perimeter
        {
            get
            {
                return Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length)/ 1000, 0);
            }
        }
        public override double SetH { get => Math.Round(A_line.Length, 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(D_line.Length, 0); set => base.SetL = value; }
        public override double SetH2_FaultLine_To_RightSide
        {
            get
            {
                Line l = GetNewLine(C, B_downFault);
                return Math.Round(l.Length, 0);
            }
            set
            {
                TempValue = SetH2_FaultLine_To_RightSide;
                SetField(ref _SetH2_FaultLine_To_RightSide, value, () => SetH2_FaultLine_To_RightSide);
                if (!CheckValidSize()) SetH2Value();
                else
                {
                    SetH2_FaultLine_To_RightSide = TempValue;
                    return;
                }
            }
        }
        public override double SetH1_FaultLine_To_LeftSide
        {
            get
            {
                Line l = GetNewLine(A, A_downFault);
                return Math.Round(l.Length,0);
            }
            set
            {
                TempValue = SetH1_FaultLine_To_LeftSide;
                SetField(ref _SetH1_FaultLine_To_LeftSide, value, () => SetH1_FaultLine_To_LeftSide);
                if (!CheckValidSize()) SetH1Value();
                else
                {
                    SetH1_FaultLine_To_LeftSide = TempValue;
                    return;
                }
            }
        }
        protected override void SetHValue()
        {
            base.SetHValue();
            CurvePoint.PointX = A.PointX;
            CurvePoint.PointY = A.PointY;
            A.PointX = SetCurrentLineLength(B, A, _SetH).PointX;
            A.PointY = SetCurrentLineLength(B, A, _SetH).PointY;
            D.PointY = A.PointY;
            var diff = A.PointY - CurvePoint.PointY;
            A_downFault.PointY += diff;
            A_upFault.PointX = A_downFault.PointX;
            A_upFault.PointY = A_downFault.PointY;
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            A_upFault.PointX = SetCurrentLineLength(A, B, _SetH1_FaultLine_To_LeftSide).PointX;
            A_upFault.PointY = SetCurrentLineLength(A, B, _SetH1_FaultLine_To_LeftSide).PointY;
            A_downFault.PointX = SetCurrentLineLength(A, B, _SetH1_FaultLine_To_LeftSide).PointX;
            A_downFault.PointY = SetCurrentLineLength(A, B, _SetH1_FaultLine_To_LeftSide).PointY;
            ValidValue = false;
        }
        protected override void SetH2Value()
        {
            base.SetH2Value();
            CenterPoint.PointX = D.PointX;
            CenterPoint.PointY = D.PointY;
            B_upFault.PointX = SetCurrentLineLength(C, CenterPoint, _SetH2_FaultLine_To_RightSide).PointX;
            B_upFault.PointY = SetCurrentLineLength(C, CenterPoint, _SetH2_FaultLine_To_RightSide).PointY;
            B_downFault.PointX = SetCurrentLineLength(C, CenterPoint, _SetH2_FaultLine_To_RightSide).PointX;
            B_downFault.PointY = SetCurrentLineLength(C, CenterPoint, _SetH2_FaultLine_To_RightSide).PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            CurvePoint.PointX = D.PointX;
            CurvePoint.PointY = D.PointY;
            D.PointX = SetCurrentLineLength(A, D, _SetL).PointX;
            D.PointY = SetCurrentLineLength(A, D, _SetL).PointY;
            C.PointX = D.PointX;
            var diff = D.PointX - CurvePoint.PointX;
            B_downFault.PointX += diff;
            B_upFault.PointX = B_downFault.PointX;
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, B, C, D, ACheck, BCheck, CCheck, DCheck };

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
            var value1 = (IsToothVector==true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector==true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector==true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var width = _SetL + _SetB1 * 2 + value1 + value3;
            var height = _SetH + value2 + value4;

            if (_SetH < 0 || _SetH1 < 0 || _SetL < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0|| _SetH1_FaultLine_To_LeftSide<0|| _SetH2_FaultLine_To_RightSide<0)
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
            else if ((_SetH > 0) && _SetH < SetH2_FaultLine_To_RightSide)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H не может быть меньше H1");
            }
            else if ((_SetH2_FaultLine_To_RightSide > 0) && _SetH2_FaultLine_To_RightSide > SetH)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H1 не может быть больше H");
            }
            else if ((_SetH > 0) && _SetH < SetH1_FaultLine_To_LeftSide)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H не может быть меньше H2");
            }
            else if (_SetH <= 0 || _SetH >= SetH2_FaultLine_To_RightSide + SetH1_FaultLine_To_LeftSide)
            {
                if ((_SetH1_FaultLine_To_LeftSide > 0) && _SetH1_FaultLine_To_LeftSide > SetH)
                {
                    ValidValue = true;
                    ValidateSetSizeMessage(Text: "Значение H2 не может быть больше H");
                }

                else

                {
                    ValidValue = false;
                }
            }
            else
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение 'Н' не может быть меньше H1+H2");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH2_FaultLine_To_RightSide");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1_FaultLine_To_LeftSide");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB1");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKis");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKisPersent");
                AddIfPropertyExist(e.Properties, filteredCollection, "Area");
                AddIfPropertyExist(e.Properties, filteredCollection, "TrueArea");
                AddIfPropertyExist(e.Properties, filteredCollection, "BaseArea");
                AddIfPropertyExist(e.Properties, filteredCollection, "Perimeter");
                AddIfPropertyExist(e.Properties, filteredCollection, "Perimeter_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeHeightValue");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeWidthValue");
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