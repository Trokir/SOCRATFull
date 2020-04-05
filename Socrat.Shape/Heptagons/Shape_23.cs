using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using DevExpress.XtraVerticalGrid.Events;

namespace Socrat.Shape.Heptagons
{
    sealed class Shape_23 : Heptagon
    {
        public Shape_23(List<Core.Entities.ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
        public override double Perimeter
        {
            get
            {
                return Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length + E_line.Length + F_line.Length + G_line.Length) / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get => Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length + D_Check_Line.Length +
                E_Check_Line.Length + F_Check_Line.Length + G_Check_Line.Length) / 1000, 3);
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
                    graphicsShape.DrawLine(pen6, F, G);
                }
                using (pen7 = new Pen(SelectMainLineColor7(), ThiсknessArgument / 2))
                {
                    pen7.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen7, G, A);
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
                    graphicsShape.DrawLine(pen6, F, G);
                }
                using (pen7 = new Pen(SelectMainLineColor7(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen7, G, A);
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
            return new PointF[] { A, B, C, D, E, F, G };
        }
        public override void GetShapeComponents()
        {
            #region BasePath
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                MoveInternalLineFromLeft(graphicsShape, W_Base, X_Base, First_B_Some_Size_Point, Second_B_Some_Size_Point, SetB1, SetB2);
                MoveInternalLineFromRight(graphicsShape, Y_Base, Z_Base, First_B_Some_Size_Point, Second_B_Some_Size_Point, SetB1, SetB2);
                MoveInternalLineFromTop(graphicsShape, X_Base, Y_Base, First_B_Some_Size_Point, Second_B_Some_Size_Point, SetB1, SetB2);
                FindPointDrawLine(SetPointCurrentType(D), SetPointCurrentType(C), SetB1, SetB2, 0);
                FindPointDrawLine1(SetPointCurrentType(C), SetPointCurrentType(D), SetB1, SetB2, 0);
                FindPointDrawLine3(SetPointCurrentType(F), SetPointCurrentType(E), SetB1, SetB2, 0);
                FindPointDrawLine2(SetPointCurrentType(A), SetPointCurrentType(B), SetB1, SetB2, 0);
                FindPointDrawLine4(SetPointCurrentType(E), SetPointCurrentType(F), SetB1, SetB2, 0);
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


                Core.Entities.ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 30 * LineBoundArgument);
                Core.Entities.ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(G), W_Base.PointY + 30 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                Core.Entities.ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);
                //B1 ul
                Core.Entities.ShapePoint bs1 = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + 30 * LineBoundArgument);
                Core.Entities.ShapePoint be1 = GetNewCustomPoint(X_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line bl1 = GetNewLine(bs1, be1);
                Core.Entities.ShapePoint b1center = GetNewCustomPoint(X_Base.PointX + (bl1.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, bs1, be1);
                    graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);
                //B1 ur
                Core.Entities.ShapePoint bs12 = GetNewCustomPoint(SetPointCurrentValueX(F), W_Base.PointY + 30 * LineBoundArgument);
                Core.Entities.ShapePoint be12 = GetNewCustomPoint(Y_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line bl12 = GetNewLine(bs12, be12);
                Core.Entities.ShapePoint b12center = GetNewCustomPoint(SetPointCurrentValueX(F) + (bl12.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, bs12, be12);
                    graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b12center, sf);

                //B2 dl
                Core.Entities.ShapePoint b2s = GetNewCustomPoint(W_Base.PointX + SetB2, W_Base.PointY + 10 * LineBoundArgument);
                Core.Entities.ShapePoint b2e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 10 * LineBoundArgument);
                Line lb2 = GetNewLine(b2s, b2e);
                Core.Entities.ShapePoint b2center = GetNewCustomPoint(W_Base.PointX + (lb2.Length / 2), W_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b2s, b2e);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2center, sf);

                //B2 dr
                Core.Entities.ShapePoint b2s1 = GetNewCustomPoint(Z_Base.PointX - SetB2, Z_Base.PointY + 10 * LineBoundArgument);
                Core.Entities.ShapePoint b2e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 10 * LineBoundArgument);
                Line lb21 = GetNewLine(b2s1, b2e1);
                Core.Entities.ShapePoint b21center = GetNewCustomPoint(Z_Base.PointX - (lb21.Length / 2), Z_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21center, sf);

                //B2 ull
                Core.Entities.ShapePoint b2s3 = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, X_Base.PointY);
                Core.Entities.ShapePoint b2e3 = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, X_Base.PointY + SetB2);
                Line lb23 = GetNewLine(b2s3, b2e3);
                Core.Entities.ShapePoint b23center = GetNewCustomPoint(Y_Base.PointX + 12 * LineBoundArgument, X_Base.PointY + (lb23.Length / 2));
                graphicsShape.DrawLine(pen, b2s3, b2e3);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b23center, sf);

                //B1 ull
                Core.Entities.ShapePoint b1s1 = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(D));
                Core.Entities.ShapePoint b1e1 = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                Line b12h = GetNewLine(b1s1, b1e1);
                Core.Entities.ShapePoint b12scenter = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, Y_Base.PointY + b12h.Length / 2);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b12scenter, sf);

                //B1 dll
                Core.Entities.ShapePoint b12s1 = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(G));
                Core.Entities.ShapePoint b12e1 = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, Z_Base.PointY);
                graphicsShape.DrawLine(pen, b12s1, b12e1);
                Line b22h = GetNewLine(b12s1, b12e1);
                Core.Entities.ShapePoint b22scenter = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, Z_Base.PointY - b22h.Length / 2);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b22scenter, sf);

                Core.Entities.ShapePoint shapeCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX + E.PointX + F.PointX + G.PointX) / 7), ((A.PointY + B.PointY + C.PointY + D.PointY + E.PointY + F.PointY + G.PointY) / 7));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("23", drawNumbertBold, Brushes.Black, shapeCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    Core.Entities.ShapePoint wer = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                    Core.Entities.ShapePoint wer1 = GetNewCustomPoint(Y_Base.PointX, SetPointCurrentValueY(G));
                    Core.Entities.ShapePoint wer2 = GetNewCustomPoint(Y_Base.PointX, Y_Base.PointY + SetB2);
                    Core.Entities.ShapePoint wer3 = GetNewCustomPoint(W_Base.PointX + SetB2, W_Base.PointY);
                    Core.Entities.ShapePoint wer4 = GetNewCustomPoint(Z_Base.PointX - SetB2, W_Base.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(A));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(G));

                    }
                    graphicsShape.DrawLine(pens, b12e1, Z_Base);
                    graphicsShape.DrawLine(pens, b12s1, SetPointCurrentType(G));
                    graphicsShape.DrawLine(pens, b1e1, Y_Base);
                    graphicsShape.DrawLine(pens, b1s1, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, b12e1, Z_Base);
                    graphicsShape.DrawLine(pens, b12s1, wer1);
                    graphicsShape.DrawLine(pens, b2e3, wer2);
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(G));
                    graphicsShape.DrawLine(pens, be1, W_Base);
                    graphicsShape.DrawLine(pens, bs1, SetPointCurrentType(B));
                    graphicsShape.DrawLine(pens, b2s, wer3);
                    graphicsShape.DrawLine(pens, bs12, SetPointCurrentType(F));
                    graphicsShape.DrawLine(pens, be12, Z_Base);
                    graphicsShape.DrawLine(pens, b2s1, wer4);

                }
            }
            #endregion


        }
        #region add Lines
        protected override void FindPointDrawLine(Core.Entities.ShapePoint firsrPoint, Core.Entities.ShapePoint secondPoint, double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;
            CurvePoint.PointX = C.PointX;
            CurvePoint.PointY = D.PointY;
            Core.Entities.ShapePoint point = GetNewPoint();
            point.PointX = B.PointX + anotherFactor - factor;
            point.PointY = secondPoint.PointY;
            Line fdfLine = GetNewLine(point, secondPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = CalculateAngle(CurvePoint, C, D);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            Core.Entities.ShapePoint ePoint = GetNewPoint();
            ePoint = SetCurrentLineLength(firsrPoint, secondPoint, length);
            if (SetB1 > 0)
            {
                using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
                {
                    graphicsShape.DrawLine(pen, secondPoint, ePoint);
                }
            }


        }
        private void FindPointDrawLine1(Core.Entities.ShapePoint firsrPoint, Core.Entities.ShapePoint secondPoint, double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;
            CurvePoint.PointX = C.PointX;
            CurvePoint.PointY = D.PointY;
            Core.Entities.ShapePoint point = GetNewPoint();
            point.PointX = secondPoint.PointX;
            point.PointY = secondPoint.PointY - anotherFactor + factor;
            Line fdfLine = GetNewLine(point, secondPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = CalculateAngle(CurvePoint, D, C);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            Core.Entities.ShapePoint ePoint = GetNewPoint();
            ePoint = SetCurrentLineLength(firsrPoint, secondPoint, length);
            if (SetB1 > 0)
            {
                using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
                {
                    graphicsShape.DrawLine(pen, secondPoint, ePoint);
                }
            }


        }
        private void FindPointDrawLine3(Core.Entities.ShapePoint firsrPoint, Core.Entities.ShapePoint secondPoint, double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;
            CurvePoint.PointX = F.PointX;
            CurvePoint.PointY = E.PointY;


            Core.Entities.ShapePoint point = GetNewPoint();
            point.PointX = secondPoint.PointX;
            point.PointY = D.PointY + anotherFactor - factor;
            Line fdfLine = GetNewLine(point, secondPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = CalculateAngle(CurvePoint, E, F);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            Core.Entities.ShapePoint ePoint = GetNewPoint();
            ePoint = SetCurrentLineLength(firsrPoint, secondPoint, length);
            if (SetB1 > 0)
            {
                using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
                {
                    graphicsShape.DrawLine(pen, secondPoint, ePoint);
                }
            }


        }
        private void FindPointDrawLine4(Core.Entities.ShapePoint firsrPoint, Core.Entities.ShapePoint secondPoint, double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;
            CurvePoint.PointX = F.PointX;
            CurvePoint.PointY = E.PointY;


            Core.Entities.ShapePoint point = GetNewPoint();
            point.PointX = secondPoint.PointX - anotherFactor + factor;
            point.PointY = secondPoint.PointY;
            Line fdfLine = GetNewLine(point, secondPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = CalculateAngle(CurvePoint, E, F);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            Core.Entities.ShapePoint ePoint = GetNewPoint();
            ePoint = SetCurrentLineLength(firsrPoint, secondPoint, length);
            if (SetB1 > 0)
            {
                using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
                {
                    graphicsShape.DrawLine(pen, secondPoint, ePoint);
                }
            }


        }
        private void FindPointDrawLine2(Core.Entities.ShapePoint firsrPoint, Core.Entities.ShapePoint secondPoint, double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;
            CurvePoint.PointX = A.PointX;
            CurvePoint.PointY = B.PointY;
            Core.Entities.ShapePoint point = GetNewPoint();
            point.PointX = B.PointX + anotherFactor - factor;
            point.PointY = secondPoint.PointY;
            Line fdfLine = GetNewLine(point, secondPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = CalculateAngle(CurvePoint, A, B);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            Core.Entities.ShapePoint ePoint = GetNewPoint();
            ePoint = SetCurrentLineLength(firsrPoint, secondPoint, length);
            if (SetB1 > 0)
            {
                using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
                {
                    graphicsShape.DrawLine(pen, secondPoint, ePoint);
                }
            }

        }
        #endregion
        public override void MoveBorderLeft(Core.Entities.ShapePoint fPoint, Core.Entities.ShapePoint sPoint, double factor = 0)
        {
            if (SetB2 > SetB1)
            {
                SetB1 = SetB2;
                MoveBorderLeft(X_Base, W_Base, SetB1);
            }
            base.MoveBorderLeft(fPoint, sPoint, factor);
        }
        public override void MoveBorderRight(Core.Entities.ShapePoint fPoint, Core.Entities.ShapePoint sPoint, double factor = 0)
        {
            if (SetB2 > SetB1)
            {
                SetB1 = SetB2;
                MoveBorderRight(Y_Base, Z_Base, SetB1);
            }
            base.MoveBorderRight(fPoint, sPoint, factor);
        }
        protected override void MoveBorderTop(Core.Entities.ShapePoint fPoint, Core.Entities.ShapePoint sPoint, double factor = 0)
        {
            if (SetB2 > SetB1)
            {
                SetB1 = SetB2;
                MoveBorderTop(X_Base, Y_Base, SetB1);
            }
            base.MoveBorderTop(fPoint, sPoint, factor);
        }
        public override double SetL { get => Math.Round(G_line.Length, 0); set => base.SetL = value; }
        public override double SetL_t { get => Math.Round(G_line.Length, 0); }
        protected override void SetLValue()
        {
            base.SetLValue();
            TempPoint.PointX = SetCurrentLineLength(A, G, _SetL).PointX;
            TempPoint.PointY = SetCurrentLineLength(A, G, _SetL).PointY;
            G.PointX = TempPoint.PointX;
            G.PointY = A.PointY;
            var Xp = GetNewPoint();
            var Yp = GetNewPoint();
            Xp.PointX = B.PointX;
            Yp.PointX = B.PointY;
            Yp.PointX = D.PointX;
            Yp.PointY = D.PointY;
            B.PointX = (G.PointX - A.PointX) * Math.Cos(-2.25147) - (G.PointY - A.PointY) * Math.Sin(-2.25147) + A.PointX;
            B.PointY = (G.PointX - A.PointX) * Math.Sin(-2.25147) + (G.PointY - A.PointY) * Math.Cos(-2.25147) + A.PointY;
            C.PointX = (A.PointX - B.PointX) * Math.Cos(-2.25147) - (A.PointY - B.PointY) * Math.Sin(-2.25147) + B.PointX;
            C.PointY = (A.PointX - B.PointX) * Math.Sin(-2.25147) + (A.PointY - B.PointY) * Math.Cos(-2.25147) + B.PointY;
            D.PointX = (B.PointX - C.PointX) * Math.Cos(-2.25147) - (B.PointY - C.PointY) * Math.Sin(-2.25147) + C.PointX;
            D.PointY = (B.PointX - C.PointX) * Math.Sin(-2.25147) + (B.PointY - C.PointY) * Math.Cos(-2.25147) + C.PointY;
            E.PointX = (C.PointX - D.PointX) * Math.Cos(-2.25147) - (C.PointY - D.PointY) * Math.Sin(-2.25147) + D.PointX;
            E.PointY = (C.PointX - D.PointX) * Math.Sin(-2.25147) + (C.PointY - D.PointY) * Math.Cos(-2.25147) + D.PointY;
            F.PointX = (D.PointX - E.PointX) * Math.Cos(-2.25147) - (D.PointY - E.PointY) * Math.Sin(-2.25147) + E.PointX;
            F.PointY = (D.PointX - E.PointX) * Math.Sin(-2.25147) + (D.PointY - E.PointY) * Math.Cos(-2.25147) + E.PointY;
            var Xdiff = Xp.PointX - B.PointX;
            var Ydiff = Yp.PointY - D.PointY;
            Move(Xdiff, Ydiff);
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {

            List<Core.Entities.ShapePoint> pointList = new List<Core.Entities.ShapePoint>() { A, B, C, D, E, F, ACheck, BCheck, CCheck, DCheck, ECheck, FCheck, GCheck };

            var xMax = pointList.Max(x => x.PointX);
            var yMax = pointList.Max(x => x.PointY);
            var xMin = pointList.Min(x => x.PointX);
            var yMin = pointList.Min(x => x.PointY);
            W_Base = new Core.Entities.ShapePoint(xMin, yMax);
            X_Base = new Core.Entities.ShapePoint(xMin, yMin);
            Y_Base = new Core.Entities.ShapePoint(xMax, yMin);
            Z_Base = new Core.Entities.ShapePoint(xMax, yMax);

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
            diag3 = (diag3 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(E, F, G) * Math.PI / 180) :
                 _CheckCut4 / (90 - ((180 - Math.Sin(CalculateAngle(E, F, G)) * Math.PI / 180)));
            diag4 = (diag4 <= 90) ? _CheckCut5 / Math.Sin(CalculateAngle(E, F, G) * Math.PI / 180) :
               _CheckCut5 / (90 - ((180 - Math.Sin(CalculateAngle(E, F, G)) * Math.PI / 180)));

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

            var width = _SetL * 2 + SetB2 * 2 + diag1 + diag2 + diag3 + diag4;
            var height = width / 1.2;

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
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut7");
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
