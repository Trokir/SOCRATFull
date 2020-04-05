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
    sealed class Shape_47 : Rectangular
    {
        public Shape_47(List<Core.Entities.ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
        public override double Perimeter => Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length) / 1000, 3);
        public override double Perimeter_t => Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length + D_Check_Line.Length) / 1000, 3);
        protected override void DrawMainLines()
        {
            if (IsToothVector == true)
            {

                using (pen1 = new Pen(SelectMainLineColor1(), width: ThiсknessArgument / 2))
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
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
              
                MoveBorderRight(Z_Base, Y_Base, SetB1);
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB3);
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
                FindPointDrawLine(SetPointCurrentType(B), SetPointCurrentType(C), SetB1, SetB1, 0);
                FindPointDrawLine1(SetPointCurrentType(A), SetPointCurrentType(B), SetB3, SetB1, 0);
            }
            using (var pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;

                Core.Entities.ShapePoint hs = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(A));
                Core.Entities.ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(B));
                Line lh = GetNewLine(hs, he);
                Core.Entities.ShapePoint hcenter = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(B) + lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                    graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hcenter, sf);

                Core.Entities.ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 30 * LineBoundArgument);
                Core.Entities.ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 30 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                Core.Entities.ShapePoint lcenter = GetNewCustomPoint(W_Base.PointX + (ll.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                Core.Entities.ShapePoint b1s = GetNewCustomPoint(SetPointCurrentValueX(A), Z_Base.PointY + 30 * LineBoundArgument);
                Core.Entities.ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                Core.Entities.ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);


                Core.Entities.ShapePoint b1s1 = GetNewCustomPoint(SetPointCurrentValueX(D), Z_Base.PointY + 30 * LineBoundArgument);
                Core.Entities.ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                Line b1h1 = GetNewLine(b1s1, b1e1);
                Core.Entities.ShapePoint b11scenter = GetNewCustomPoint(SetPointCurrentValueX(D) + b1h1.Length / 2, W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b11scenter, sf);



                Core.Entities.ShapePoint b3s1 = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(B));
                Core.Entities.ShapePoint b3e1 = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, X_Base.PointY);
                graphicsShape.DrawLine(pen, b3s1, b3e1);
                Line b31h = GetNewLine(b3s1, b3e1);
                Core.Entities.ShapePoint b31scenter = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, X_Base.PointY + b31h.Length / 2);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b31scenter, sf);


                Core.Entities.ShapePoint b2s = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(A));
                Core.Entities.ShapePoint b2e = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, W_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                Core.Entities.ShapePoint b2scenter = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, W_Base.PointY - b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);

                Core.Entities.ShapePoint h1s = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(C));
                Core.Entities.ShapePoint h1e = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(D));
                graphicsShape.DrawLine(pen, h1s, h1e);
                Line h1h = GetNewLine(h1s, h1e);
                Core.Entities.ShapePoint h1scenter = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, W_Base.PointY - h1h.Length / 2);
                graphicsShape.DrawString("H1=" + SetH1, drawFontBold, Brushes.Black, h1scenter, sf);


                Core.Entities.ShapePoint l1s = GetNewCustomPoint(SetPointCurrentValueX(A), Z_Base.PointY +15 * LineBoundArgument);
                Core.Entities.ShapePoint l1e = GetNewCustomPoint(SetPointCurrentValueX(B), Z_Base.PointY + 15 * LineBoundArgument);
                Line ll1 = GetNewLine(l1s, l1e);
                Core.Entities.ShapePoint l1center = GetNewCustomPoint(l1s.PointX + (ll1.Length / 2), Z_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l1s, l1e);
                graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l1center, sf);


                Core.Entities.ShapePoint l2s = GetNewCustomPoint(SetPointCurrentValueX(C), Z_Base.PointY +15 * LineBoundArgument);
                Core.Entities.ShapePoint l2e = GetNewCustomPoint(SetPointCurrentValueX(D), Z_Base.PointY +15 * LineBoundArgument);
                Line ll2 = GetNewLine(l2s, l2e);                                       
                Core.Entities.ShapePoint l2center = GetNewCustomPoint(l2s.PointX + ll2.Length / 2, Z_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l2s, l2e);
                graphicsShape.DrawString("L2=" + SetCurrentSize(SetL2), drawFontBold, Brushes.Black, l2center, sf);



                Core.Entities.ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("47", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }

                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    Core.Entities.ShapePoint wer1 = GetNewCustomPoint(W_Base.PointX,SetPointCurrentValueY(A));
                    Core.Entities.ShapePoint wer2 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(D));

                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(A));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(D));
                       
                    }
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, b1e1, Z_Base);
                    graphicsShape.DrawLine(pens, b1e, W_Base);
                    graphicsShape.DrawLine(pens, he, SetPointCurrentType(B));
                    graphicsShape.DrawLine(pens, hs, wer2);
                    graphicsShape.DrawLine(pens, b2e, Z_Base);
                    graphicsShape.DrawLine(pens, b3e1, Y_Base);
                    graphicsShape.DrawLine(pens, h1s, SetPointCurrentType(C));
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, l1e, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pens1, l2s, SetPointCurrentType(C));
                    }
                }
            }

            #endregion
        }
        protected override void FindPointDrawLine(Core.Entities.ShapePoint firsrPoint, Core.Entities.ShapePoint secondPoint, double factor = 0,
            double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;

            Core.Entities.ShapePoint point = GetNewPoint();
            point.PointX = D.PointX + factor;
            point.PointY = secondPoint.PointY;
            Line fdfLine = GetNewLine(point, secondPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = 180 - CalculateAngle(A, B, C);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            Core.Entities.ShapePoint ePoint = GetNewPoint();
            ePoint = SetCurrentLineLength(firsrPoint, secondPoint, length);

            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                graphicsShape.DrawLine(pen, secondPoint, ePoint);
            }

        }
        private void FindPointDrawLine1(Core.Entities.ShapePoint firsrPoint, Core.Entities.ShapePoint secondPoint, double factor = 0,
            double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;

            Core.Entities.ShapePoint point = GetNewPoint();
            point.PointX = secondPoint.PointX;
            point.PointY = B.PointY - factor;
            Line fdfLine = GetNewLine(point, secondPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = CalculateAngle(A, B, C);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            Core.Entities.ShapePoint ePoint = GetNewPoint();
            ePoint = SetCurrentLineLength(firsrPoint, secondPoint, length);

            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                graphicsShape.DrawLine(pen, secondPoint, ePoint);
            }

        }
        public override double SetH
        {
            get=> Math.Round(GetNewLine(GetNewCustomPoint(B.PointX, A.PointY), B).Length, 0);
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
        public override double SetH1
        {
            get=>Math.Round(GetNewLine(GetNewCustomPoint(C.PointX, D.PointY), C).Length, 0);
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
        public override double SetL1
        {
            get=> Math.Round(GetNewLine(GetNewCustomPoint(A.PointX, B.PointY), B).Length, 0);
            set
            {
                TempValue = SetL1;
                SetField(ref _SetL1, value, () => SetL1);
                if (!CheckValidSize()) SetL1Value();
                else
                {
                    _SetL1 = TempValue;
                    return;
                }
            }
        }
        public override double SetL2
        {
            get=>Math.Round(GetNewLine(GetNewCustomPoint(D.PointX, C.PointY), C).Length, 0);
            set
            {
                TempValue = SetL2;
                SetField(ref _SetL2, value, () => SetL2);
                if (!CheckValidSize()) SetL2Value();
                else
                {
                    _SetL2 = TempValue;
                    return;
                }
            }
        }
        public override double SetH_t
        {
            get
            {
                Core.Entities.ShapePoint p = GetNewCustomPoint(BCheck.PointX, ACheck.PointY);
                Line l = GetNewLine(p, BCheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetL_t { get => Math.Round(D_Check_Line.Length, 0); }
        public override double SetH1_t
        {
            get
            {
                Core.Entities.ShapePoint p = GetNewCustomPoint(CCheck.PointX, DCheck.PointY);
                Line l = GetNewLine(p, CCheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetL1_t
        {
            get
            {
                Core.Entities.ShapePoint p = GetNewCustomPoint(ACheck.PointX, BCheck.PointY);
                Line l = GetNewLine(p, BCheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetL2_t
        {
            get
            {
                Core.Entities.ShapePoint p = GetNewCustomPoint(DCheck.PointX, CCheck.PointY);
                Line l = GetNewLine(p, CCheck);
                return Math.Round(l.Length, 0);
            }
        }
        protected override void SetHValue()
        {
            base.SetHValue();
            var p = GetNewCustomPoint(A.PointX, B.PointY);
            TempPoint.PointX = A.PointX;
            TempPoint.PointY = A.PointY;
            TempPoint.PointY = SetCurrentLineLength(p, A, _SetH).PointY;
            var diff = TempPoint.PointY - A.PointY;
            C.PointY += diff;
            A.PointY = TempPoint.PointY;
            A.PointX = TempPoint.PointX;
            D.PointY = A.PointY;
          
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            TempPoint.PointX = SetCurrentLineLength(A, D, _SetL).PointX;
            double diff = D.PointX - TempPoint.PointX;
            C.PointX -= diff;
            D.PointX = TempPoint.PointX;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            Core.Entities.ShapePoint p = GetNewCustomPoint(C.PointX, D.PointY);
            C.PointY = SetCurrentLineLength(p, C, _SetH1).PointY;
        }
        protected override void SetL1Value()
        {
            Core.Entities.ShapePoint p = GetNewCustomPoint(A.PointX - 1, B.PointY);
            B.PointX = SetCurrentLineLength(p, B, _SetL1).PointX + 1;
        }
        protected override void SetL2Value()
        {
            base.SetL2Value();
            Core.Entities.ShapePoint p = GetNewCustomPoint(D.PointX + 1, C.PointY);
            C.PointX = SetCurrentLineLength(p, C, _SetL2).PointX - 1;
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
                    if (IsToothVector == true)
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
                ? CheckCut3 / Math.Sin(CalculateAngle(C, D, A) * Math.PI / 180)
                : (90 - ((180 - CheckCut3 / Math.Sin(CalculateAngle(C, D, A)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            double diag1 = 0;
            diag1 = (diag1 <= 90)
                ? CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180)
                : (90 - ((180 - CheckCut2 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag1 = (!IsToothVector == true) ? 0 : diag1;
            double diag2 = 0;
            diag2 = (diag2 <= 90)
                ? CheckCut1 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180)
                : (90 - ((180 - CheckCut1 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));
            diag2 = (!IsToothVector == true) ? 0 : diag2;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;

            var width = _SetL + _SetB1*2  + diag + diag2;
            var height = _SetH  + diag1 + _SetB2 + _SetB3 + value4;

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
            else if (_SetL>0&&_SetL < SetL1 + SetL2)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L' не может быть меньше 'L2+L1'");
            }
            else if (_SetL > 0 && (SetH - SetH1) / (_SetL - (SetL1 + SetL2)) > SetH1 / SetL2)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L' не может быть меньше 'L2+L1'");
            }
            else if (_SetL2 > 0 && SetL < SetL1 + _SetL2)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L' не может быть меньше 'L2+L1'");
            }
            else if (_SetL1 > 0&&SetL < _SetL1 + SetL2)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L' не может быть меньше 'L2+L1'");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1_t");
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
