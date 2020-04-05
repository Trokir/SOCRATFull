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
    sealed class Shape_62 : Triangle
    {
        private ShapePoint ApogeusPoint { get; set; }
        private ShapePoint ApogeusPointCheck { get; set; }
        private ShapePoint Apogeus { get; set; }
        private ShapePoint Perigeus { get; set; }
        private ShapePoint ApogeusCheck { get; set; }
        private ShapePoint PerigeusCheck { get; set; }
        private ShapePoint ApogeusLittle { get; set; }
        private ShapePoint PerigeusLittle { get; set; }
        private ShapePoint ApogeusLittleCheck { get; set; }
        private ShapePoint PerigeusLittleCheck { get; set; }
        public Shape_62(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

            ApogeusLittle = GetNewPoint();
            PerigeusLittle = GetNewPoint();
            ApogeusCheck = GetNewPoint();
            PerigeusCheck = GetNewPoint();
            ApogeusLittleCheck = GetNewPoint();
            PerigeusLittleCheck = GetNewPoint();
            B.PointX = SetCurrentLineLength(A, B, C_line.Length).PointX;
            B.PointY = SetCurrentLineLength(A, B, C_line.Length).PointY;
            var points = new ShapePoint[]
            {
                A = GetNewPoint(),
                B = GetNewPoint(),
                C = GetNewPoint(),
             A_double= GetNewPoint(),
            B_double= GetNewPoint(),
            ACheck= GetNewPoint(),
            BCheck= GetNewPoint(),
            CCheck= GetNewPoint(),
            DCheck= GetNewPoint(),
            ECheck= GetNewPoint()
            };
            ApogeusPoint = GetNewPoint();
            ApogeusPointCheck = GetNewPoint();
            try
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].PointX = ShapePoints[i].PointX;
                    points[i].PointY = ShapePoints[i].PointY;
                    points[i].PointRadius = ShapePoints[i].PointRadius ?? 0;
                }
            }
            catch (Exception)
            {
                // throw new EPointXception("Нет данных");
            }
        }
        public override List<ShapePoint> ShapePointsList()
        {
            A.PointName = "A";
            B.PointName = "B";
            C.PointName = "C";
            ACheck.PointName = "dCheck";
            BCheck.PointName = "eCheck";
            CCheck.PointName = "fCheck";
            DCheck.PointName = "gCheck";
            ECheck.PointName = "hCheck";
            A_double.PointName = "louble";
            B_double.PointName = "mouble";

            var ShapePoints = new List<ShapePoint>() { A, B, C, ACheck, BCheck, CCheck, DCheck, ECheck, A_double, B_double };
            return ShapePoints;
        }
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { B, C };
        }
        protected override void DrawMainLines()
        {
            var curvePoints = GetFigurePoints();
            var curveLittlePoints = GetFigureLittlePoints();
            if (IsToothVector == true)
            {
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument / 2))
                {
                    pen1.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawCurve(pen1, curveLittlePoints, 0F);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument / 2))
                {
                    pen2.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen2, B_double, B);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument / 2))
                {
                    pen3.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawCurve(pen3, curvePoints, 0F);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument / 2))
                {
                    pen4.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen4, C, A_double);
                }
              
               
                IsToothVector = true;
            }
            else
            {
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument))
                {
                    graphicsShape.DrawCurve(pen1, curveLittlePoints, 0F);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen2, B_double, B);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument))
                {
                    graphicsShape.DrawCurve(pen3, curvePoints, 0F);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen4, C, A_double);
                }
                IsToothVector = false;
            }

            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddCurve(curvePoints);
                myPath.AddCurve(curveLittlePoints);
                myPath.AddLine(B_double, B);
                myPath.AddLine(A_double, C);
                graphicsShape.FillPath(new SolidBrush(Color.FromArgb(30, Color.Blue)), myPath);
            }
            MoveLines();
        }
        
        protected override void CheckForeignBorders()
        {
             DrawMainLines();
                AllowanceProcessing();

        }

        private void MoveLines()
        {
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
               
                GetExtremumPoints();
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB3);
                MoveBorderRight(Y_Base, Z_Base, SetB2);
                MoveBorderBottom(W_Base, Z_Base, SetB2);
            }
        }

        public override void GetShapeComponents()
        {
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
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
                using (Pen pen3 = new Pen(Color.Black, SizeLineBoundArgument))
                {
                    pen3.StartCap = LineCap.RoundAnchor;
                    pen.EndCap = LineCap.RoundAnchor;
                    ShapePoint b1s = GetNewCustomPoint(W_Base.PointX + SetB1, W_Base.PointY + 20 * LineBoundArgument);
                    ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 20 * LineBoundArgument);
                    Line lb1 = GetNewLine(b1s, b1e);
                    ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                    graphicsShape.DrawLine(pen, b1s, b1e);
                    graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                    ShapePoint b1s1 = GetNewCustomPoint(Z_Base.PointX - SetB2, W_Base.PointY + 20 * LineBoundArgument);
                    ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                    Line lb11 = GetNewLine(b1s1, b1e1);
                    ShapePoint b11center = GetNewCustomPoint(Z_Base.PointX - (lb11.Length / 2), Z_Base.PointY + 20 * LineBoundArgument);
                    graphicsShape.DrawLine(pen, b1s1, b1e1);
                    graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b11center, sf);

                    ShapePoint b2s = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY);
                    ShapePoint b2e = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + SetB3);
                    graphicsShape.DrawLine(pen, b2s, b2e);
                    Line b2h = GetNewLine(b2s, b2e);
                    ShapePoint b2scenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + b2h.Length / 2);
                    graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b2scenter, sf);

                    if (IsToothVector == true)
                    {
                        graphicsShape.DrawLine(pen3, A, ACheck);
                        graphicsShape.DrawLine(pen3, A, BCheck);
                        var rss = GetNewCustomPoint(CCheck.PointX, CCheck.PointY);
                        var rse = GetNewCustomPoint(DCheck.PointX, DCheck.PointY);
                        var lA = GetNewLine(A, CCheck);
                        var lB = GetNewLine(CCheck, DCheck);
                        var lC = GetNewLine(DCheck, A);
                        rss = SetCurrentLineLength(A, CCheck, lA.Length + 30 * LineBoundArgument);
                        rse = SetCurrentLineLength(A, DCheck, lC.Length + 30 * LineBoundArgument);
                        var sizecenter = GetNewCustomPoint(CCheck.PointX + lB.Length / 2, DCheck.PointY - (lB.Length / 2));
                        graphicsShape.DrawString("R1=" + SetCurrentSize(SetRadius1), drawFontBold, Brushes.Black, sizecenter, sf);

                        var le = GetNewCustomPoint(DCheck.PointX, W_Base.PointY + 20 * LineBoundArgument);
                        var ls = GetNewCustomPoint(ACheck.PointX, W_Base.PointY + 20 * LineBoundArgument);
                        Line ll = GetNewLine(ls, le);
                        ShapePoint lcenter = GetNewCustomPoint(ACheck.PointX + (ll.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                        graphicsShape.DrawLine(pen, ls, le);
                        graphicsShape.DrawString("L=" + SetL_t, drawFontBold, Brushes.Black, lcenter, sf);

                        ShapePoint rs = GetNewCustomPoint(DCheck.PointX, W_Base.PointY + 40 * LineBoundArgument);
                        ShapePoint re = GetNewCustomPoint(ACheck.PointX, W_Base.PointY + 40 * LineBoundArgument);
                        re = SetCurrentLineLength(DCheck, ACheck, _SetRadius);
                        re.PointY = W_Base.PointY + 40 * LineBoundArgument;
                        Line lr = GetNewLine(rs, re);
                        ShapePoint rcenter = GetNewCustomPoint(A.PointX + (lr.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                        graphicsShape.DrawLine(pen, rs, re);
                        graphicsShape.DrawString("R=" + SetRadius_t, drawFontBold, Brushes.Black, rcenter, sf);

                        using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                        {
                            graphicsShape.DrawLine(pens, b1e, W_Base);
                            graphicsShape.DrawLine(pens, b1e1, Z_Base);
                            graphicsShape.DrawLine(pens, b2s, Y_Base);
                            graphicsShape.DrawLine(pens, b1s, SetRadius1 > 90 ? CCheck : BCheck);
                            graphicsShape.DrawLine(pens, b1s1, DCheck);
                            var point = GetNewCustomPoint(ApogeusPointCheck.PointX, ApogeusCheck.PointY);
                            graphicsShape.DrawLine(pens, b2e, SetRadius1 > 90 ? point : CCheck);
                        }

                    }
                    else
                    {
                        graphicsShape.DrawLine(pen3, A, A_double);
                        graphicsShape.DrawLine(pen3, A, B_double);
                        ShapePoint rss = GetNewCustomPoint(B.PointX, B.PointY);
                        ShapePoint rse = GetNewCustomPoint(C.PointX, C.PointY);
                        Line lA = GetNewLine(A, B);
                        Line lB = GetNewLine(B, C);
                        Line lC = GetNewLine(C, A);
                        rss = SetCurrentLineLength(A, B, lA.Length + 30);
                        rse = SetCurrentLineLength(A, C, lC.Length + 30);
                        ShapePoint sizecenter = GetNewCustomPoint(B.PointX + lB.Length / 2, C.PointY - (lB.Length / 2));
                        graphicsShape.DrawString("R1=" + SetCurrentSize(SetRadius1), drawFontBold, Brushes.Black, sizecenter, sf);




                        ShapePoint ls = GetNewCustomPoint(A_double.PointX, W_Base.PointY + 20 * LineBoundArgument);
                        ShapePoint le = GetNewCustomPoint(C.PointX, W_Base.PointY + 20 * LineBoundArgument);
                        Line ll = GetNewLine(ls, le);
                        ShapePoint lcenter = GetNewCustomPoint(A_double.PointX + (ll.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                        graphicsShape.DrawLine(pen, ls, le);
                        graphicsShape.DrawString("L=" + SetL, drawFontBold, Brushes.Black, lcenter, sf);

                        ShapePoint rs = GetNewCustomPoint(A_double.PointX, W_Base.PointY + 40 * LineBoundArgument);
                        ShapePoint re = GetNewCustomPoint(C.PointX, W_Base.PointY + 40 * LineBoundArgument);
                        rs = SetCurrentLineLength(C, A_double, _SetRadius);
                        rs.PointY = W_Base.PointY + 40 * LineBoundArgument;
                        Line lr = GetNewLine(rs, re);
                        ShapePoint rcenter = GetNewCustomPoint(A.PointX + (lr.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                        graphicsShape.DrawLine(pen, rs, re);
                        graphicsShape.DrawString("R=" + SetRadius, drawFontBold, Brushes.Black, rcenter, sf);



                        using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                        {
                            graphicsShape.DrawLine(pens, b1e, W_Base);
                            graphicsShape.DrawLine(pens, b1e1, Z_Base);
                            graphicsShape.DrawLine(pens, b2s, Y_Base);
                            graphicsShape.DrawLine(pens, b1s, SetRadius1 > 90 ? B : B_double);
                            graphicsShape.DrawLine(pens, b1s1, C);
                            var point = GetNewCustomPoint(ApogeusPoint.PointX, Apogeus.PointY);
                            graphicsShape.DrawLine(pens, b2e, SetRadius1 > 90 ? point : B);
                        }

                    }
                }



                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX) / 3), ((A.PointY + B.PointY + C.PointY) / 3));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiсknessArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("62", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }

            }
        }
        public override RectangleF GetShapeBorders()
        {
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddCurve(GetFigurePoints());
                myPath.AddCurve(GetFigureLittlePoints());
                myPath.AddLine(B_double, B);
                myPath.AddLine(A_double, C);
                Region myRegion = new Region(myPath);
                RectangleF boundsRect = myRegion.GetBounds(graphicsShape);
                //graphicsShape.DrawRectangle(Pens.Blue, new Rectangle((int)boundsRect.X,
                //(int)boundsRect.Y, (int)boundsRect.Width, (int)boundsRect.Height));
                graphicsShape.SetClip(myRegion, CombineMode.Replace);
                return boundsRect;
            }
        }
        public override void SelectClickedSide(int xCoord, int yCoord, bool flag)
        {
            Point point = new Point(xCoord, yCoord);
            if (CurvePath(GetFigureLittlePoints()).IsVisible(point))
            {
                if (flag) { ColorMarker1 = "rowCheckCut1"; SelectedSides.SetValue(1, 0); SelectedSidesLength += littleArc; }
                else { ColorMarker1 = ""; SelectedSides.SetValue(0, 1); SelectedSidesLength -= littleArc; }
            }
            if (ThicknessPath(B_double, B).IsVisible(point))
            {
                if (flag) { ColorMarker2 = "rowCheckCut2"; SelectedSides.SetValue(2, 1); SelectedSidesLength += GetNewLine(B_double, B).Length; }
                else { ColorMarker2 = ""; SelectedSides.SetValue(0, 1); SelectedSidesLength -= GetNewLine(B_double, B).Length; }
            }
            if (CurvePath(GetFigurePoints()).IsVisible(point))
            {
                if (flag) { ColorMarker3 = "rowCheckCut3"; SelectedSides.SetValue(3, 3); SelectedSidesLength += bigArc; }
                else { ColorMarker3 = ""; SelectedSides.SetValue(0, 3); SelectedSidesLength += bigArc; }
            }
            if (ThicknessPath(C, A_double).IsVisible(point))
            {
                if (flag) { ColorMarker4 = "rowCheckCut4"; SelectedSides.SetValue(4, 4); SelectedSidesLength += GetNewLine(C, A_double).Length; }
                else { ColorMarker4 = ""; SelectedSides.SetValue(0, 4); SelectedSidesLength -= GetNewLine(C, A_double).Length; }
            }

            else return;
        }
        protected override GraphicsPath GetShapeShprosBorders()
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddCurve(GetFigurePoints());
            myPath.AddCurve(GetFigureLittlePoints());
            myPath.AddLine(B_double, B);
            myPath.AddLine(A_double, C);
            return myPath;
        }
        public override double Area
        {
            get
            {
                var l = GetNewLine(A, A_double);
                var angleBetween = CalculateAngle(C, A, B);
                var littleLength = l.Length;
                var bigSegment = (0.5 * Math.Pow(SetRadius, 2)) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180));
                var littleSegment = (0.5 * Math.Pow(littleLength, 2)) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180));
                var baseSquare = 0.5 * Math.Abs((A_double.PointX * B_double.PointY + B_double.PointX * B.PointY + B.PointX * C.PointY + C.PointX * A_double.PointY) - (B_double.PointX * A_double.PointY + B.PointX * B_double.PointY + C.PointX * B.PointY + A_double.PointX * C.PointY));
                return Math.Round((baseSquare + bigSegment - littleSegment) / 1000000, 3);
            }
        }
        public override double TrueArea
        {
            get
            {
                Line l = GetNewLine(A, ACheck);
                double angleBetween = CalculateAngle(C, A, B);
                double littleLength = l.Length;
                double bigSegment = (0.5 * Math.Pow(SetRadius_t, 2)) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180));
                double littleSegment = (0.5 * Math.Pow(littleLength, 2)) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180));
                double baseSquare = 0.5 * Math.Abs((ACheck.PointX * BCheck.PointY + BCheck.PointX * CCheck.PointY + CCheck.PointX * DCheck.PointY + DCheck.PointX * ACheck.PointY) -
                    (BCheck.PointX * ACheck.PointY + CCheck.PointX * BCheck.PointY + DCheck.PointX * CCheck.PointY + ACheck.PointX * DCheck.PointY));


                return Math.Round((baseSquare + bigSegment - littleSegment) / 1000000, 3);
            }
        }
        public override double Perimeter
        {
            get
            {
                var angleBetween = CalculateAngle(C, A, B);
                var l = GetNewLine(A, A_double);
                var C_li = GetNewLine(A, B_double);
                var littleLength = l.Length;
                var downLength = C_li.Length - littleLength;
                 bigArc = (Math.PI * angleBetween * SetRadius) / 180;
                 littleArc = (Math.PI * angleBetween * littleLength) / 180;
                return Math.Round((downLength * 2 + bigArc + littleArc) / 1000, 3);
            }
        }
        public double bigArc { get; set; }
        public double littleArc { get; set; }
        public override double Perimeter_t
        {
            get
            {
                var angleBetween = CalculateAngle(C, A, B);
                var l = GetNewLine(A, ACheck);
                var C_li = GetNewLine(A, DCheck);
                var littleLength = l.Length;
                var downLength = C_li.Length - littleLength;
                var bigArc = (Math.PI * angleBetween * SetRadius_t) / 180;
                var littleArc = (Math.PI * angleBetween * littleLength) / 180;
                return Math.Round((downLength * 2 + bigArc + littleArc) / 1000, 3);
            }
        }
        public override void DrawSideNumbers()
        {
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Near;
            graphicsShape.DrawString("1",drawFontBold, Brushes.Black, B_double, sf);
            graphicsShape.DrawString("2",drawFontBold, Brushes.Black, B, sf);
            graphicsShape.DrawString("3",drawFontBold, Brushes.Black, C, sf);
            graphicsShape.DrawString("4", drawFontBold, Brushes.Black, A_double, sf);
        }
        public override double SetL { get => Math.Round(GetNewLine(A_double, C).Length, 0); set => base.SetL = value; }
        public override double SetRadius1 { get => CalculateAngle(B, A, C); set => base.SetRadius1 = value; }
        public override double SetL_t => Math.Round(GetNewLine(ACheck, DCheck).Length, 0);
        public override double SetRadius_t => Math.Round(GetNewLine(A, DCheck).Length, 0);
        public override double SetRadius1_t => CalculateAngle(BCheck, A, ACheck);
        protected override void SetRadius1Value()
        {
            base.SetRadius1Value();
            //  var dsdsd = Apogeus.PointY;
            var pX = A.PointX;
            var pY = A.PointY;
            if (Math.Abs(SetL - SetRadius) < 0.1) { SetL -= 10; }
            B.PointX = (C.PointX - A.PointX) * Math.Cos(-_SetRadius1 * Math.PI / 180) - (C.PointY - A.PointY) * Math.Sin(-_SetRadius1 * Math.PI / 180) + A.PointX;
            B.PointY = (C.PointX - A.PointX) * Math.Sin(-_SetRadius1 * Math.PI / 180) + (C.PointY - A.PointY) * Math.Cos(-_SetRadius1 * Math.PI / 180) + A.PointY;
            var xDiff = pX - A.PointX;
            var yDiff = pY - A.PointY;
            //  Move(xDiff, yDiff);
            if (_SetRadius1 >= 90)
            {
                // Move(x:SetL/2,y: SetL / 2);
            }
            ValidValue = false;
        }
        protected override void SetRadiusValue()
        {
            base.SetRadiusValue();
            var pX = C.PointX;
            var pY = C.PointY;
            var r = SetRadius1;
            TempPoint.PointX = C.PointX;
            TempPoint.PointY = C.PointY;
            B.PointX = SetCurrentLineLength(A, B, _SetRadius).PointX;
            B.PointY = SetCurrentLineLength(A, B, _SetRadius).PointY;
            TempPoint.PointX = SetCurrentLineLength(A, C, _SetRadius).PointX;
            TempPoint.PointY = SetCurrentLineLength(A, C, _SetRadius).PointY;
            var diff = TempPoint.PointX - C.PointX;
            A_double.PointX += diff;
            C.PointX = TempPoint.PointX;
            C.PointY = TempPoint.PointY;
            SetRadius1 = r;
            var xDiff = pX - C.PointX;
            var yDiff = pY - C.PointY;
            //  Move(xDiff, yDiff);
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            A_double.PointX = SetCurrentLineLength(C, A_double, _SetL).PointX;
            A_double.PointY = SetCurrentLineLength(C, A_double, _SetL).PointY;
            B_double.PointX = SetCurrentLineLength(B, B_double, _SetL).PointX;
            B_double.PointY = SetCurrentLineLength(B, B_double, _SetL).PointY;
            if (_SetL > SetRadius)
            {
                SetRadius = _SetL;
            }
            ValidValue = false;
        }
        public override Point[] GetFigurePoints()
        {
            Apogeus = GetNewPoint();
            Perigeus = GetNewPoint();

            double angleBetween = 0;
            angleBetween = CalculateAngle(B, A, C);
            var pointsList = new List<Point> { C };
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
            var PointXMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var xMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            Apogeus.PointX = xMin;
            Apogeus.PointY = yMin;
            Perigeus.PointX = PointXMax;
            Perigeus.PointY = yMax;
            var temp = points.FirstOrDefault(x => x.Y == Apogeus.PointY);
            ApogeusPoint.PointY = yMin;
            ApogeusPoint.PointX = temp.X;
            var Xdiff =(SetRadius1>=90)? B.PointX - 150: B_double.PointX - 150;
            var Ydiff = Apogeus.PointY - 150;

            Move(-Xdiff, -Ydiff);
            return points;
        }
        private Point[] GetFigureLittlePoints()
        {

            double angleBetween = 0;
            A_double.PointX = SetCurrentLineLength(C, A, SetL).PointX;
            A_double.PointY = SetCurrentLineLength(C, A, SetL).PointY;
            B_double.PointX = SetCurrentLineLength(B, A, SetL).PointX;
            B_double.PointY = SetCurrentLineLength(B, A, SetL).PointY;
            angleBetween = CalculateAngle(B, A, C);

            var pointsList = new List<Point> { A_double };
            double degree = 0;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (A_double.PointX - A.PointX) * Math.Cos(-degree * Math.PI / 180) - (A_double.PointY - A.PointY) * Math.Sin(-degree * Math.PI / 180) + A.PointX;
                CurvePoint.PointY = (A_double.PointX - A.PointX) * Math.Sin(-degree * Math.PI / 180) + (A_double.PointY - A.PointY) * Math.Cos(-degree * Math.PI / 180) + A.PointY;
                pointsList.Add(CurvePoint);
                degree += 0.1;
            }

            pointsList.Add(B_double);
            var points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var PointXMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var PointXMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            ApogeusLittle.PointX = PointXMin;
            ApogeusLittle.PointY = yMin;
            PerigeusLittle.PointX = PointXMax;
            PerigeusLittle.PointY = yMax;
            return points;
        }
        public override Point[] GetFigureToothPoints()
        {

            double angleBetween = 0;
            angleBetween = CalculateAngle(CCheck, A, DCheck);
            var pointsList = new List<Point> { DCheck };

            double degree = 0;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (DCheck.PointX - A.PointX) * Math.Cos(-degree * Math.PI / 180) - (DCheck.PointY - A.PointY) * Math.Sin(-degree * Math.PI / 180) + A.PointX;
                CurvePoint.PointY = (DCheck.PointX - A.PointX) * Math.Sin(-degree * Math.PI / 180) + (DCheck.PointY - A.PointY) * Math.Cos(-degree * Math.PI / 180) + A.PointY;
                pointsList.Add(CurvePoint);
                degree += 0.1;
            }
            //  pointsList.Add(CCheck);
            var points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var PointXMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var PointXMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);

            ApogeusCheck.PointX = PointXMin;
            ApogeusCheck.PointY = yMin;
            PerigeusCheck.PointX = PointXMax;
            PerigeusCheck.PointY = yMax;
            var temp = points.FirstOrDefault(x => x.Y == ApogeusCheck.PointY);
            ApogeusPointCheck.PointY = yMin;
            ApogeusPointCheck.PointX = temp.X;
            return points;
        }
        private Point[] GetFigureLittleToothPoints()
        {
            double angleBetween = 0;
            angleBetween = CalculateAngle(BCheck, A, ACheck);

            var pointsList = new List<Point> { ACheck };
            double degree = 0;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (ACheck.PointX - A.PointX) * Math.Cos(-degree * Math.PI / 180) - (ACheck.PointY - A.PointY) * Math.Sin(-degree * Math.PI / 180) + A.PointX;
                CurvePoint.PointY = (ACheck.PointX - A.PointX) * Math.Sin(-degree * Math.PI / 180) + (ACheck.PointY - A.PointY) * Math.Cos(-degree * Math.PI / 180) + A.PointY;
                pointsList.Add(CurvePoint);
                degree += 0.1;
            }

            // pointsList.Add(BCheck);
            var points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var PointXMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var PointXMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            ApogeusLittleCheck.PointX = PointXMin;
            ApogeusLittleCheck.PointY = yMin;
            PerigeusLittleCheck.PointX = PointXMax;
            PerigeusLittleCheck.PointY = yMax;
            return points;
        }
        public override void GetExtremumPoints()
        {

            var pointList = new List<ShapePoint>() { B, C, Apogeus, Perigeus, PerigeusLittle, ApogeusLittle,
            BCheck, CCheck, ApogeusCheck, PerigeusCheck, PerigeusLittleCheck, ApogeusLittleCheck,A_double,B_double};
            var PointXMax = pointList.Max(PointX => PointX.PointX);
            var yMax = pointList.Max(PointX => PointX.PointY);
            var PointXMin = pointList.Min(PointX => PointX.PointX);
            var yMin = pointList.Min(PointX => PointX.PointY);
            W_Base = new ShapePoint(PointXMin, yMax);
            X_Base = new ShapePoint(PointXMin, yMin);
            Y_Base = new ShapePoint(PointXMax, yMin);
            Z_Base = new ShapePoint(PointXMax, yMax);
        }
        public override void Move(double x = 0, double y = 0)
        {

            //Move to x coord
            A.PointX += x;
            B.PointX += x;
            C.PointX += x;
            A_double.PointX += x;
            B_double.PointX += x;

            //Move to Y coord
            A.PointY += y;
            B.PointY += y;
            C.PointY += y;
            A_double.PointY += y;
            B_double.PointY += y;

        }
        protected override void AllowanceProcessing()
        {
            A_Check_Line = GetNewLine(ACheck, BCheck);
            B_Check_Line = GetNewLine(BCheck, CCheck);
            C_Check_Line = GetNewLine(CCheck, DCheck);
            D_Check_Line = GetNewLine(DCheck, ACheck);


            ECheck.PointX = A.PointX;
            ECheck.PointY = A.PointY;
            ACheck.PointX = A_double.PointX;
            ACheck.PointY = A_double.PointY;
            BCheck.PointX = B_double.PointX;
            BCheck.PointY = B_double.PointY;
            CCheck.PointX = B.PointX;
            CCheck.PointY = B.PointY;
            DCheck.PointX = C.PointX;
            DCheck.PointY = C.PointY;


            double diag1 = 0;
            double diag11 = 0;
            double diag2 = 0;
            double diag21 = 0;
            double diag3 = 0;
            double diag31 = 0;
            double diag4 = 0;
            double diag41 = 0;

            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == false && _CheckCut2 >= 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == false && _CheckCut3 >= 0) ? _CheckCut3 * (-1) : _CheckCut3;
            _CheckCut4 = (IsToothVector == false && _CheckCut4 >= 0) ? _CheckCut4 * (-1) : _CheckCut4;

            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == true && _CheckCut2 < 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == true && _CheckCut3 < 0) ? _CheckCut3 * (-1) : _CheckCut3;
            _CheckCut4 = (IsToothVector == true && _CheckCut4 < 0) ? _CheckCut4 * (-1) : _CheckCut4;


            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(C, A_double, B_double) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(C, A_double, B_double)) * Math.PI / 180)));
            diag11 = (diag11 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(A_double, B_double, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(A_double, B_double, B)) * Math.PI / 180)));
            diag1 = (Double.IsNaN(diag1)) ? 0 : diag1;
            diag11 = (Double.IsNaN(diag11)) ? 0 : diag11;

            diag2 = (diag2 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(A_double, B_double, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut2 / Math.Sin(CalculateAngle(A_double, B_double, B)) * Math.PI / 180)));
            diag21 = (diag21 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(B_double, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut2 / Math.Sin(CalculateAngle(B_double, B, C)) * Math.PI / 180)));
            diag2 = (Double.IsNaN(diag2)) ? 0 : diag2;
            diag21 = (Double.IsNaN(diag21)) ? 0 : diag21;

            diag3 = (diag3 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(B_double, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut3 / Math.Sin(CalculateAngle(B_double, B, C)) * Math.PI / 180)));
            diag31 = (diag31 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(B, C, A_double) * Math.PI / 180) :
                (90 - ((180 - _CheckCut3 / Math.Sin(CalculateAngle(B, C, A_double)) * Math.PI / 180)));
            diag3 = (Double.IsNaN(diag3)) ? 0 : diag3;
            diag31 = (Double.IsNaN(diag31)) ? 0 : diag31;


            diag4 = (diag4 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(B, C, A_double) * Math.PI / 180) :
                (90 - ((180 - _CheckCut4 / Math.Sin(CalculateAngle(B, C, A_double)) * Math.PI / 180)));
            diag41 = (diag41 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(C, A_double, B_double) * Math.PI / 180) :
                (90 - ((180 - _CheckCut4 / Math.Sin(CalculateAngle(C, A_double, B_double)) * Math.PI / 180)));
            diag4 = (Double.IsNaN(diag4)) ? 0 : diag4;
            diag41 = (Double.IsNaN(diag41)) ? 0 : diag41;

            DCheck.PointY += CheckCut4;
            ACheck.PointY += CheckCut4;

            ACheck.PointX = SetCurrentLineLength(DCheck, ACheck, CheckCut1 + D_Check_Line.Length).PointX;
            ACheck.PointY = SetCurrentLineLength(DCheck, ACheck, CheckCut1 + D_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(CCheck, BCheck, CheckCut1 + B_Check_Line.Length).PointX;
            BCheck.PointY = SetCurrentLineLength(CCheck, BCheck, CheckCut1 + B_Check_Line.Length).PointY;

            CCheck.PointX = SetCurrentLineLength(BCheck, CCheck, CheckCut3 + B_Check_Line.Length).PointX;
            CCheck.PointY = SetCurrentLineLength(BCheck, CCheck, CheckCut3 + B_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(ACheck, DCheck, CheckCut3 + D_Check_Line.Length).PointX;
            DCheck.PointY = SetCurrentLineLength(ACheck, DCheck, CheckCut3 + D_Check_Line.Length).PointY;

            BCheck.PointX = SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line.Length).PointX;
            BCheck.PointY = SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(DCheck, CCheck, diag21 + C_Check_Line.Length).PointX;
            CCheck.PointY = SetCurrentLineLength(DCheck, CCheck, diag21 + C_Check_Line.Length).PointY;
            Point[] curvePoints = GetFigureToothPoints();
            Point[] curveLittlePoints = GetFigureLittleToothPoints();

            var itemLast = curvePoints.Last();
            double fdfd = CCheck.PointX;
            double fddffd = CCheck.PointY;
            if (itemLast.X != 0 && itemLast.Y != 0)
            {
                CCheck.PointX = itemLast.X;
                CCheck.PointY = itemLast.Y;
            }

            var itemLittleLast = curveLittlePoints.Last();
            double fdfd1 = CCheck.PointX;
            double fddffd1 = CCheck.PointY;
            if (itemLittleLast.X != 0 && itemLittleLast.Y != 0)
            {
                BCheck.PointX = itemLittleLast.X;
                BCheck.PointY = itemLittleLast.Y;
            }






            // PointF[] cutPoints = new PointF[] { ACheck, BCheck, CCheck };


            if (IsToothVector == true)
            {
                using (Pen penCut = new Pen(Color.Red, ThiсknessArgument))
                {
                    graphicsShape.DrawLine(penCut, CCheck, BCheck);
                    graphicsShape.DrawLine(penCut, DCheck, ACheck);
                    graphicsShape.DrawCurve(penCut, curveLittlePoints, 0F);
                    graphicsShape.DrawCurve(penCut, curvePoints, 0F);
                    IsToothVector = true;
                }
            }
            else
            {
                using (Pen penCut = new Pen(Color.Red, ThiсknessArgument / 2))
                {
                    penCut.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(penCut, CCheck, BCheck);
                    graphicsShape.DrawLine(penCut, DCheck, ACheck);
                    graphicsShape.DrawCurve(penCut, curveLittlePoints, 0F);
                    graphicsShape.DrawCurve(penCut, curvePoints, 0F);
                    IsToothVector = false;
                }
            }

            GetExtremumPoints();
        }
        public override bool CheckValidSize()
        {

            var value1 = (IsToothVector == true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector == true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector == true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var length = (_SetRadius >= _SetL) ? _SetRadius : _SetL;
            var line = GetNewLine(CCheck, GetNewCustomPoint(CCheck.PointX, ACheck.PointY));
            var heigthValue = (_SetRadius1 >= 90) ? _SetRadius : line.Length;
            var width = length + _SetB1 + _SetB2 + value1 + value3;
            var height = heigthValue + _SetB3 + value2 + value4;

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
            else if (_SetL > 0 && _SetL >= SetRadius)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L' не может превышать 'R'");
            }
            else if (_SetRadius1 > 0 && _SetRadius1 >= 180)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'R1' не может превышать '180'");
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
                var filteredCollection = new PropertyDescriptorCollection(null);
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius1");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius1_t");
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
