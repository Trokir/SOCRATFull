using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Socrat.Shape.Pentagons
{
    sealed class Shape_41 : Pentagon
    {
        public Shape_41(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
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
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D, E };
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

                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(E), W_Base.PointY + 20 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint b2s = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b2e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 20 * LineBoundArgument);
                Line lb2 = GetNewLine(b2s, b2e);
                ShapePoint b2center = GetNewCustomPoint(W_Base.PointX + (lb2.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b2center, sf);


                ShapePoint b2s1 = GetNewCustomPoint(SetPointCurrentValueX(D), Z_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b2e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                Line lb21 = GetNewLine(b2s1, b2e1);
                ShapePoint b21center = GetNewCustomPoint(Z_Base.PointX - (lb21.Length / 2), Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b21center, sf);


                ShapePoint b1s1 = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint b1e1 = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                Line b12h = GetNewLine(b1s1, b1e1);
                ShapePoint b12scenter = GetNewCustomPoint(Y_Base.PointX + 30 * LineBoundArgument, Y_Base.PointY + b12h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b12scenter, sf);


                ShapePoint l2s = GetNewCustomPoint(SetPointCurrentValueX(B), SetPointCurrentValueY(B) - 10 * LineBoundArgument);
                ShapePoint l2e = GetNewCustomPoint(SetPointCurrentValueX(C), SetPointCurrentValueY(C) - 10 * LineBoundArgument);
                Line ll2 = GetNewLine(l2s, l2e);
                ShapePoint l2center = GetNewCustomPoint(l2s.PointX + (ll2.Length / 3), l2s.PointY - 35);
                graphicsShape.DrawLine(pen, l2s, l2e);
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                graphicsShape.DrawString("L2=" + SetCurrentSize(SetL2), drawFontBold, Brushes.Black, l2center, sf);


                ShapePoint l1s = GetNewCustomPoint(SetPointCurrentValueX(D) + 10 * LineBoundArgument, SetPointCurrentValueY(D));
                ShapePoint l1e = GetNewCustomPoint(SetPointCurrentValueX(E) + 10 * LineBoundArgument, SetPointCurrentValueY(E) + 5 * LineBoundArgument);
                Line ll1 = GetNewLine(l1s, l1e);
                ShapePoint l1center = GetNewCustomPoint(l1e.PointX +25 * LineBoundArgument, l1e.PointY - ll1.Length/2);
                graphicsShape.DrawLine(pen, l1s, l1e);
                graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l1center, sf);


                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX + E.PointX) / 5), ((A.PointY + B.PointY + C.PointY + D.PointY + E.PointY) / 5));
                Font drawNumbertBold = new Font("Tahoma", 40+ThiknessFontArgument);
                if (Area > 0.012)
                {

                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("41", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                   var wer1 = GetNewCustomPoint(X_Base.PointX, SetPointCurrentValueY(C));
                   var wer2 = GetNewCustomPoint(SetPointCurrentValueX(B), Y_Base.PointY);
                   var wer3 = GetNewCustomPoint(Y_Base.PointX, SetPointCurrentValueY(C));
                   var wer4 = GetNewCustomPoint(SetPointCurrentValueX(D), Y_Base.PointY);
                   var wer5 = GetNewCustomPoint(Y_Base.PointX, SetPointCurrentValueY(E));
                   var wer6 = GetNewCustomPoint(SetPointCurrentValueX(D), Z_Base.PointY);
                   var wer7 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                   var wer8 = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer4, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer5, SetPointCurrentType(E));
                        graphicsShape.DrawLine(pen1, wer6, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer7, SetPointCurrentType(A));
                        graphicsShape.DrawLine(pen1, wer8, SetPointCurrentType(B));
                    }
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(E));
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, b2s, wer8);
                    graphicsShape.DrawLine(pens, b2e, W_Base);
                    graphicsShape.DrawLine(pens, b2s1, wer6);
                    graphicsShape.DrawLine(pens, b2e1, Z_Base);
                    graphicsShape.DrawLine(pens, b1s1, wer3);
                    graphicsShape.DrawLine(pens, b1e1, Y_Base);
                }
            }

            #endregion
        }
        public override double SetH { get => Math.Round(GetSomeLineLength(A.PointX, C.PointY, A), 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(E_line.Length, 0); set => base.SetL = value; }
        public override double SetL1 { get => Math.Round(D_line.Length, 0); set => base.SetL1 = value; }
        public override double SetL2 { get => Math.Round(B_line.Length, 0); set => base.SetL2 = value; }
        public override double SetH_t {
            get
            {
                ShapePoint LP = GetNewCustomPoint(ACheck.PointX, CCheck.PointY);
                Line line = GetNewLine(LP, ACheck);
                return Math.Round(line.Length, 0);
            }
        }
        public override double SetL_t { get => Math.Round(E_Check_Line.Length, 0); }
        public override double SetL1_t { get => Math.Round(D_Check_Line.Length, 0); }
        public override double SetL2_t { get => Math.Round(B_Check_Line.Length, 0); }
        protected override void SetHValue()
        {
            base.SetHValue();
            var p = C.PointY;
            ShapePoint LP = GetNewCustomPoint(A.PointX + E_line.Length / 2, A.PointY);
            TempPoint.PointY = SetCurrentLineLength(LP, C, _SetH).PointY;
            var diff = C.PointY - TempPoint.PointY;
            C.PointY = TempPoint.PointY;
            B.PointY -= diff;
            D.PointY -= diff;
            var diffr = p - C.PointY;
            Move(y: diffr);
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            var pds = B.PointX;
            E.PointY = A.PointY;
            CurvePoint.PointX = A.PointX + E_line.Length / 2;
            CurvePoint.PointY = A.PointY;
            TempPoint.PointX = SetCurrentLineLength(CurvePoint, E, _SetL / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(CurvePoint, E, _SetL / 2).PointY;
            var diff = TempPoint.PointX - E.PointX;
            D.PointX += diff;
            E.PointX = TempPoint.PointX;
            E.PointY = TempPoint.PointY;
            TempPoint.PointX = SetCurrentLineLength(CurvePoint, A, _SetL / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(CurvePoint, A, _SetL / 2).PointY;
            B.PointX -= diff;
            A.PointX = TempPoint.PointX;
            A.PointY = TempPoint.PointY;
            var diffr = pds - B.PointX;
            Move(x: diffr);
            ValidValue = false;
        }
        protected override void SetL2Value()
        {
            base.SetL2Value();
            Move(_SetL2, 0);
           var oneLine = GetNewLine(A, C);
           var twoLine = GetNewLine(E, C);
           var a = Math.Pow(A_line.Length, 2);
           var c = Math.Pow(oneLine.Length, 2);
           var b = Math.Pow(_SetL2, 2);
           var re = 2 * _SetL2 * oneLine.Length;
           var alpha = Math.Acos((b + c - a) / re);

            if (_SetL2 >= SetL1 + twoLine.Length) { _SetL2 = SetL1 + twoLine.Length; }
            if (_SetL2 <= twoLine.Length - SetL1) { _SetL2 = twoLine.Length - SetL1; }
            else
            {
                B.PointX = (A.PointX - C.PointX) * Math.Cos(alpha) - (A.PointY - C.PointY) * Math.Sin(alpha) + C.PointX;
                B.PointY = (A.PointX - C.PointX) * Math.Sin(alpha) + (A.PointY - C.PointY) * Math.Cos(alpha) + C.PointY;
                TempPoint.PointX = SetCurrentLineLength(C, B, _SetL2).PointX;
                TempPoint.PointY = SetCurrentLineLength(C, B, _SetL2).PointY;
                B.PointX = TempPoint.PointX;
                B.PointY = TempPoint.PointY;
                D.PointX = (E.PointX - C.PointX) * Math.Cos(-alpha) - (E.PointY - C.PointY) * Math.Sin(-alpha) + C.PointX;
                D.PointY = (E.PointX - C.PointX) * Math.Sin(-alpha) + (E.PointY - C.PointY) * Math.Cos(-alpha) + C.PointY;
                TempPoint.PointX = SetCurrentLineLength(C, D, _SetL2).PointX;
                TempPoint.PointY = SetCurrentLineLength(C, D, _SetL2).PointY;
                D.PointX = TempPoint.PointX;
                D.PointY = TempPoint.PointY;
                var df = oneLine.Length;
                ValidValue = false;
            }
        }
        protected override void SetL1Value()
        {
            base.SetL1Value();
         //   Move(_SetL1, 0);
            var oneLine = GetNewLine(A, C);
            var twoLine = GetNewLine(E, C);
            var a = Math.Pow(_SetL1, 2);
            var c = Math.Pow(oneLine.Length, 2);
            var b = Math.Pow(B_line.Length, 2);
            var re = 2 * _SetL1 * oneLine.Length;
            var alpha = Math.Acos((a + c - b) / re);

            if (_SetL1 >= SetL2 + twoLine.Length) { _SetL1 = SetL2 + twoLine.Length; }
            if (_SetL1 <= twoLine.Length - SetL2) { _SetL1 = twoLine.Length - SetL2; }
            else
            {
                B.PointX = (C.PointX - A.PointX) * Math.Cos(-alpha) - (C.PointY - A.PointY) * Math.Sin(-alpha) + A.PointX;
                B.PointY = (C.PointX - A.PointX) * Math.Sin(-alpha) + (C.PointY - A.PointY) * Math.Cos(-alpha) + A.PointY;
                TempPoint.PointX = SetCurrentLineLength(A, B, _SetL1).PointX;
                TempPoint.PointY = SetCurrentLineLength(A, B, _SetL1).PointY;
                B.PointX = TempPoint.PointX;
                B.PointY = TempPoint.PointY;

                D.PointX = (C.PointX - E.PointX) * Math.Cos(alpha) - (C.PointY - E.PointY) * Math.Sin(alpha) + E.PointX;
                D.PointY = (C.PointX - E.PointX) * Math.Sin(alpha) + (C.PointY - E.PointY) * Math.Cos(alpha) + E.PointY;
                TempPoint.PointX = SetCurrentLineLength(E, D, _SetL1).PointX;
                TempPoint.PointY = SetCurrentLineLength(E, D, _SetL1).PointY;
                D.PointX = TempPoint.PointX;
                D.PointY = TempPoint.PointY;
                var df = oneLine.Length;
                ValidValue = false;
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
            var angle = CalculateAngle(E, A, B) - 90;
            var katet = A_line.Length * Math.Cos(angle * Math.PI / 180);
            var hLine = Math.Abs(SetL1 * Math.Cos(180 - (CalculateAngle(D, E, A)) * Math.PI / 180));
            double diag1 = 0;
            double diag2 = 0;
            double diag3 = 0;
            double diag4 = 0;
            double diag5 = 0;

            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                _CheckCut1 / (90 - ((180 - Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));


            diag2 = (diag2 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
               _CheckCut2 / (90 - ((180 - Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));

            diag3 = (diag3 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(C, D, E) * Math.PI / 180) :
                  _CheckCut3 / (90 - ((180 - Math.Sin(CalculateAngle(C, D, E)) * Math.PI / 180)));

            diag4 = (diag4 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(C, D, E) * Math.PI / 180) :
                _CheckCut4 / (90 - ((180 - Math.Sin(CalculateAngle(C, D, E)) * Math.PI / 180)));

            diag5 = (diag5 <= 90) ? _CheckCut5 / Math.Sin(CalculateAngle(D, E, A) * Math.PI / 180) :
              _CheckCut5 / (90 - ((180 - Math.Sin(CalculateAngle(D, E, A)) * Math.PI / 180)));
            diag1 = (IsToothVector==true) ? 0 : diag1;
            diag2 = (IsToothVector==true) ? 0 : diag2;
            diag3 = (IsToothVector==true) ? 0 : diag3;
            diag4 = (IsToothVector==true) ? 0 : diag4;
            diag5 = (IsToothVector == true) ? 0 : diag5;
           
            var value5 = (IsToothVector == true) ? _CheckCut5 : 0;
            var width = hLine+_SetL + _SetB1+_SetB3 + diag2 + diag1+diag3+diag4;
            var height = _SetH + _SetB2 + _SetB3 + diag3+ diag2 + value5;

            if (_SetH < 0 || _SetH1 < 0 || _SetH2 < 0 || _SetL < 0 || _SetL1 < 0 ||
                _SetL2 < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0)
            {
                var message = $"Значение  не может быть отрицательным";
                ValidateSetSizeMessage(Text: message);
                ValidValue = true;
            }

            else if (width > 3210 && height > 3210)
            {    
                     var message1 =
                         $"Габаритная ширина = {width} превышает 3210 и Габаритная высота = {height} превышает 3210";
                     ValidateSetSizeMessage(Text: message1);
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

            else if (_SetL2 > 0 && SetH <= 0.0 + _SetL1 * Math.Sin((Math.Atan((2.0 * SetH) / SetL)) +
             2.0 * Math.Asin(Math.Sqrt((_SetL1 + SetL2 - Math.Sqrt(  (SetH * SetH) +
              (SetL * SetL) / 4.0)) / 2.0 * ((Math.Sqrt((SetH * SetH) + ((SetL * SetL) / 4.0 )) + SetL2 -
              _SetL1) / 2.0) / ((Math.Sqrt((SetH * SetH) + ((SetL * SetL) / 4.0))) * _SetL1)))))
            {
                ValidateSetSizeMessage("Значение 'L1' некорректно");
                ValidValue = true;
            }
           
           
            else if ((_SetH>0) &&_SetH < katet)
            {
                ValidateSetSizeMessage("Значение 'H' за пределами допустимых значений");
                ValidValue = true;
            }

            else if ((_SetL2 > 0) && 0 >= 0.0 + SetL1 * Math.Sin(Math.Atan(2.0 * SetH / SetL) +
                   2.0 * Math.Asin(Math.Sqrt((SetL1 + _SetL2 - Math.Sqrt( SetH * SetH + (SetL * SetL) / 4.0)) / 2.0 *
                   ((Math.Sqrt((SetH * SetH) + SetL * SetL / 4.0) + _SetL2 - SetL1) / 2.0) / (Math.Sqrt(SetH * SetH +
                   SetL * SetL / 4.0) * SetL1)))))
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L2' некорректно");
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