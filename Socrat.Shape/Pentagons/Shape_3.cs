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
    sealed class Shape_3 : Pentagon
    {
        public Shape_3(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
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
                 AllowanceProcessing();
                MoveBorderRight(Z_Base, Y_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB2);
               
            }
        }
      
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D, E };
        }
        public override void GetShapeComponents()
        {
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
                ShapePoint hs = GetNewCustomPoint(Y_Base.PointX + (20 * LineBoundArgument), SetPointCurrentValueY(B));
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + (20 * LineBoundArgument), SetPointCurrentValueY(A));
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Y_Base.PointX + (20 * LineBoundArgument), SetPointCurrentValueY(A) - (lh.Length / 2));
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                if (lh.Length > 8)
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hcenter, sf);
                }

                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), SetPointCurrentValueY(A) + (30 * LineBoundArgument));
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(E), SetPointCurrentValueY(E) + (30 * LineBoundArgument));
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(ACheck.PointX + (ll.Length / 2), ACheck.PointY + (30 * LineBoundArgument));
                graphicsShape.DrawLine(pen, ls, le);
                if (ll.Length > 8)
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);
                }

                ShapePoint l1s = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + (20 * LineBoundArgument));
                ShapePoint l1e = GetNewCustomPoint(SetPointCurrentValueX(C), W_Base.PointY + (20 * LineBoundArgument));
                Line ll1 = GetNewLine(l1s, l1e);
                ShapePoint l1center = GetNewCustomPoint(SetPointCurrentValueX(B) + (ll1.Length / 4), W_Base.PointY + (5 * LineBoundArgument));
                graphicsShape.DrawLine(pen, l1s, l1e);
                if (ll1.Length > 8)
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l1center, sf);
                }

                ShapePoint h1s = GetNewCustomPoint(Y_Base.PointX + (10 * LineBoundArgument), SetPointCurrentValueY(D));
                ShapePoint h1e = GetNewCustomPoint(Z_Base.PointX + (10 * LineBoundArgument), SetPointCurrentValueY(E));
                Line lh1 = GetNewLine(h1s, h1e);
                ShapePoint h1center = GetNewCustomPoint(Z_Base.PointX + (10 * LineBoundArgument), SetPointCurrentValueY(E) - (lh1.Length / 1.5));
                graphicsShape.DrawLine(pen, h1s, h1e);
                if (lh1.Length > 8)
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, h1center, sf);
                }
                ShapePoint b2s = GetNewCustomPoint(Y_Base.PointX + (20 * LineBoundArgument), SetPointCurrentValueY(B));
                ShapePoint b2e = GetNewCustomPoint(Y_Base.PointX + (20 * LineBoundArgument), X_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                ShapePoint b2scenter = GetNewCustomPoint(Y_Base.PointX + (20 * LineBoundArgument), X_Base.PointY + (b2h.Length / 2));
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);


                ShapePoint b1s = GetNewCustomPoint(SetPointCurrentValueX(E), SetPointCurrentValueY(E) + (30 * LineBoundArgument));
                ShapePoint b1e = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(E) + (30 * LineBoundArgument));
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), SetPointCurrentValueY(E) + (30 * LineBoundArgument));
                graphicsShape.DrawLine(pen, b1s, b1e);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX + E.PointX) / 5), ((A.PointY + B.PointY + C.PointY + D.PointY + E.PointY) / 5));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("3", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    ShapePoint wer = GetNewCustomPoint(Y_Base.PointX, SetPointCurrentValueY(C));
                    ShapePoint wer1 = GetNewCustomPoint(SetPointCurrentValueX(D), Y_Base.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(D));
                    }
                    graphicsShape.DrawLine(pens, b2s, wer);
                    graphicsShape.DrawLine(pens, b2e, wer1);
                    graphicsShape.DrawLine(pens, he, SetPointCurrentType(E));
                    graphicsShape.DrawLine(pens, h1s, SetPointCurrentType(D));

                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(E));
                    graphicsShape.DrawLine(pens, b1e, Z_Base);
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, l1e, SetPointCurrentType(C));
                    }
                }
            }
          
        }
        public override double SetH { get => Math.Round(A_line.Length, 0); set => base.SetH = value; }
        public override double SetH1 { get => Math.Round(D_line.Length, 0); set => base.SetH1 = value; }
        public override double SetL { get => Math.Round(E_line.Length, 0); set => base.SetL = value; }
        public override double SetL1 { get => Math.Round(B_line.Length, 0); set => base.SetL1 = value; }
        public override double SetH_t { get => Math.Round(A_Check_Line.Length, 0); }
        public override double SetL1_t { get => Math.Round(B_Check_Line.Length, 0);}
        public override double SetH1_t { get => Math.Round(D_Check_Line.Length, 0); }
        public override double SetL_t { get => Math.Round(E_Check_Line.Length, 0); }
        protected override void SetL1Value()
        {
            base.SetL1Value();
            C.PointX = SetCurrentLineLength(B, C, _SetL1).PointX;
            C.PointY = SetCurrentLineLength(B, C, _SetL1).PointY;
            C.PointY = B.PointY;
            ValidValue = false;
        }
        protected override void SetHValue()
        {
            base.SetHValue();
            TempPoint.PointX = SetCurrentLineLength(B, A, _SetH).PointX;
            TempPoint.PointY = SetCurrentLineLength(B, A, _SetH).PointY;
            double diff = A.PointY - TempPoint.PointY;
            D.PointY -= diff;
            A.PointX = TempPoint.PointX;
            A.PointY = TempPoint.PointY;
            E.PointY = A.PointY;
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
        protected override void SetLValue()
        {
            base.SetLValue();
            E.PointX = SetCurrentLineLength(A, E, _SetL).PointX;
            E.PointY = SetCurrentLineLength(A, E, _SetL).PointY;
            D.PointX = E.PointX;
            ValidValue = false;
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
                ? CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180)
                : (90 - ((180 - (CheckCut2 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180))));
            diag = (!IsToothVector == true) ? 0 : diag;
            var value1 = (IsToothVector==true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector==true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector==true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector==true) ? _CheckCut4 : 0;
            var value5 = (IsToothVector == true) ? _CheckCut5 : 0;
            var width = _SetL + _SetB1  + value1 + value4;
            var height = _SetH +_SetB2 + value2;

            if (_SetH < 0 || _SetH1 < 0 || _SetL < 0 || _SetL1 < 0 || _SetB1 < 0 || _SetB2 < 0 )
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
            else if ((_SetL > 0) && _SetL < SetL1)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L не может быть меньше L1");
            }
            else if ((_SetL1 > 0) && _SetL1 > SetL)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L1 не может быть больше L");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1_t");
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
