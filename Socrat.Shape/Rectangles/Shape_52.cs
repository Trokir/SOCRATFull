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
    sealed class Shape_52 : Rectangular
    {
        #region Variables
      private  ShapePoint Apogeus { get; set; }
        private ShapePoint Perigeus { get; set; }
        private ShapePoint ApogeusUp { get; set; }
        private ShapePoint PerigeusUp { get; set; }
        private ShapePoint ApogeusRight { get; set; }
        private ShapePoint PerigeusRight { get; set; }
        private ShapePoint ApogeusLeft { get; set; }
        private ShapePoint PerigeusLeft { get; set; }
        #endregion
        public Shape_52(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) :
            base(ShapePoints, currentShapeParametersList)
        { }
        private void CalculateBorders()
        {
            GetFigurePoints();
            GetFigureUpPoints();
            GetFigureRightPoints();
            GetFigureLeftPoints();
            GetExtremumPoints();
        }
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D };
        }
        protected override void DrawMainLines()
        {
            using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument))
            {
                var curveBottomPoints = GetFigurePoints();
                graphicsShape.DrawCurve(pen1, curveBottomPoints);
            }
            using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument))
            {
                var curveUpPoints = GetFigureUpPoints();
                graphicsShape.DrawCurve(pen2, curveUpPoints, 0F);
            }
            using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument))
            {
                Point[] curveRightPoints = GetFigureRightPoints();
                graphicsShape.DrawCurve(pen3, curveRightPoints, 0F);
            }
            using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument))
            {
                Point[] curveLeftPoints = GetFigureLeftPoints();
                graphicsShape.DrawCurve(pen4, curveLeftPoints, 0F);
            }
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetBasePoints());
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetFigurePoints());
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetFigureUpPoints());
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetFigureRightPoints());
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetFigureLeftPoints());
            MoveLines();
        }
        public override RectangleF GetShapeBorders()
        {
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddCurve(GetFigurePoints());
                myPath.AddCurve(GetFigureUpPoints());
                myPath.AddCurve(GetFigureRightPoints());
                myPath.AddCurve(GetFigureLeftPoints());
                Region myRegion = new Region(myPath);
                RectangleF boundsRect = myRegion.GetBounds(graphicsShape);
               // graphicsShape.SetClip(myRegion, CombineMode.Replace);
                return boundsRect;
            }
        }
        protected override GraphicsPath GetShapeShprosBorders()
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddCurve(GetFigurePoints());
            myPath.AddCurve(GetFigureUpPoints());
            myPath.AddCurve(GetFigureRightPoints());
            myPath.AddCurve(GetFigureLeftPoints());
            return myPath;
        }
        protected override void CheckForeignBorders()
        {
           
            GetExtremumPoints();
            DrawMainLines();
        }

        private void MoveLines()
        {
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
               
                GetExtremumPoints();
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB2);
                MoveBorderRight(Y_Base, Z_Base, SetB1);
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
            using (var pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;


                ShapePoint hs = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY + SetB2);
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY - SetB2);
                graphicsShape.DrawLine(pen, hs, he);
                Line h1 = GetNewLine(hs, he);
                ShapePoint hscenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, he.PointY - h1.Length / 2);
                graphicsShape.DrawString("H=" + SetH, drawFontBold, Brushes.Black, hscenter, sf);


                ShapePoint b2s = GetNewCustomPoint(he.PointX, W_Base.PointY);
                ShapePoint b2e = GetNewCustomPoint(he.PointX, W_Base.PointY + SetB2);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(he.PointX * LineBoundArgument, W_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);

                ShapePoint b2s1 = GetNewCustomPoint(he.PointX, Y_Base.PointY);
                ShapePoint b2e1 = GetNewCustomPoint(he.PointX, Y_Base.PointY - SetB2);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                Line b2h1 = GetNewLine(b2s1, b2e1);
                ShapePoint b21scenter = GetNewCustomPoint(he.PointX, Y_Base.PointY - b2h1.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21scenter, sf);

                ShapePoint b1s = GetNewCustomPoint(W_Base.PointX - SetB1, W_Base.PointY + 40 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 40 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);


                ShapePoint b1s1 = GetNewCustomPoint(Z_Base.PointX + SetB1, Z_Base.PointY + 40 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 40 * LineBoundArgument);
                Line lb11 = GetNewLine(b1s1, b1e1);
                ShapePoint b11center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), Z_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b11center, sf);

                ShapePoint ls = GetNewCustomPoint(ApogeusLeft.PointX, W_Base.PointY + 40 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(PerigeusRight.PointX, W_Base.PointY + 40 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(W_Base.PointX + (ll.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetL, drawFontBold, Brushes.Black, lcenter, sf);

                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    var customa = GetNewCustomPoint(Z_Base.PointX + SetB1, Z_Base.PointY + SetB2);
                    var customa1 = GetNewCustomPoint(Z_Base.PointX + SetB1, Y_Base.PointY - SetB2);
                    var customa2 = GetNewCustomPoint(W_Base.PointX - SetB1, W_Base.PointY - SetB2);
                    var customa3 = GetNewCustomPoint(Z_Base.PointX + SetB1, W_Base.PointY - SetB2);
                    graphicsShape.DrawLine(pens, b2e1, customa1);
                    graphicsShape.DrawLine(pens, b2e, customa);
                    graphicsShape.DrawLine(pens, b1s1, customa3);
                    graphicsShape.DrawLine(pens, b1s, customa2);
                }
                using (var penr = new Pen(Color.Blue, 1))
                {
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;

                    penr.StartCap = LineCap.RoundAnchor;
                    penr.EndCap = LineCap.ArrowAnchor;
                    penr.DashStyle = DashStyle.Solid;

                    ShapePoint rs = GetNewCustomPoint(W_Base.PointX + D_line.Length / 2 - 10 * LineBoundArgument, Z_Base.PointY + 20 * LineBoundArgument);
                    ShapePoint re = GetNewCustomPoint(X_Base.PointX + D_line.Length / 2 + 20 * LineBoundArgument, ApogeusUp.PointY);
                    Line lr = GetNewLine(rs, re);
                    ShapePoint brcenter = GetNewCustomPoint(W_Base.PointX + D_line.Length / 2, Z_Base.PointY - (lr.Length / 2));
                    graphicsShape.DrawLine(penr, rs, re);
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    graphicsShape.DrawString("R1=" + SetRadius1, drawFontBold, Brushes.Black, brcenter, sf);

                    Line lines = GetNewLine(Z_Base, Y_Base);
                    ShapePoint rs1 = GetNewCustomPoint(W_Base.PointX - 40 * LineBoundArgument, Z_Base.PointY - 40 * LineBoundArgument);
                    ShapePoint re1 = GetNewCustomPoint(PerigeusRight.PointX, Z_Base.PointY - lines.Length / 2);
                    Line lr1 = GetNewLine(rs1, re1);
                    ShapePoint br1center = GetNewCustomPoint(W_Base.PointX + 60 * LineBoundArgument, Z_Base.PointY - 20 * LineBoundArgument);
                    graphicsShape.DrawLine(penr, rs1, re1);
                    graphicsShape.DrawString("R=" + SetRadius, drawFontBold, Brushes.Black, br1center, sf);

                }





                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("52", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }

                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {


                    var line = GetNewLine(Z_Base, Y_Base);
                    var line1 = GetNewLine(W_Base, Z_Base);
                    var customr = GetNewCustomPoint(PerigeusRight.PointX, Z_Base.PointY - line.Length / 2);
                    var customl = GetNewCustomPoint(ApogeusLeft.PointX, Z_Base.PointY - line.Length / 2);
                    var customu = GetNewCustomPoint(W_Base.PointX + line1.Length / 2, hs.PointY);
                    var customd = GetNewCustomPoint(W_Base.PointX + line1.Length / 2, he.PointY);

                    graphicsShape.DrawLine(pens, ls, customl);
                    graphicsShape.DrawLine(pens, le, customr);
                    graphicsShape.DrawLine(pens, hs, customu);
                    graphicsShape.DrawLine(pens, he, customd);
                }
            }
            #endregion
        }
        public override double Area
        {
            get
            {

                var angleBetween = CalculateAngle(A, CenterPoint, D);

                var square = (0.5 * Math.Pow(SetRadius, 2)) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180));

                return Math.Round(square / 1000000, 3);
            }
        }
        public override double Perimeter
        {
            get
            {

                double angleBetween = CalculateAngle(A, CenterPoint, D);
                double perimeter = (Math.PI * angleBetween * SetRadius) / 180 + D_line.Length;
                return Math.Round(perimeter / 1000, 3);
            }
        }
        public override double SetL
        {
            get
            {
                CalculateBorders();
                return Math.Round(GetNewLine(W_Base, Z_Base).Length);
            }
            set => base.SetL = value;
        }
        public override double SetH
        {
            get
            {
                CalculateBorders();
                return Math.Round(GetNewLine(W_Base, X_Base).Length);
            }
            set => base.SetRadius = value;
        }
        public override double SetRadius
        {
            get => _SetRadius = (_SetRadius == 0) ? 222 : _SetRadius;
            set => base.SetRadius = value;
        }
        public override double SetRadius1
        {
            get => _SetRadius1 = (_SetRadius1 == 0) ? 333 : _SetRadius1;
            set => base.SetRadius1 = value;
        }
        protected override void SetHValue()
        {
            base.SetHValue();
            var height = SetRadius1 - Math.Sqrt(Math.Pow(SetRadius1, 2) - ((Math.Pow(D_line.Length, 2)) / 4));
            if (double.IsNaN(height))
            {
                height = 0;
            }
            CurvePoint.PointX = A.PointX;
            CurvePoint.PointY = A.PointY - A_line.Length / 2;
            A.PointY = SetCurrentLineLength(CurvePoint, A, _SetH / 2).PointY - height;
            D.PointY = A.PointY;
            B.PointY = SetCurrentLineLength(CurvePoint, B, _SetH / 2).PointY + height;
            C.PointY = B.PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            var height = SetRadius - Math.Sqrt(Math.Pow(SetRadius, 2) - ((Math.Pow(A_line.Length, 2)) / 4));
            if (double.IsNaN(height))
            {
                height = 0;
            }
            CurvePoint.PointX = A.PointX + D_line.Length / 2;
            CurvePoint.PointY = A.PointY;
            A.PointX = SetCurrentLineLength(CurvePoint, A, _SetL / 2).PointX + height;
            B.PointX = A.PointX;
            D.PointX = SetCurrentLineLength(CurvePoint, D, _SetL / 2).PointX - height;
            C.PointX = D.PointX;
            ValidValue = false;
        }
        protected override void SetRadiusValue()
        {
            base.SetRadiusValue();

            ValidValue = false;
        }
        protected override void SetRadius1Value()
        {
            base.SetRadius1Value();

            ValidValue = false;
        }
        public override double SetB1
        {
            get { return _SetB1; }
            set
            {
                SetField(ref _SetB1, value, () => SetB1);
                if (SetL + _SetB1 * 2 > 3210) { ValidateSetSizeMessage("Габаритный размер не может превышать 3210 мм"); _SetB1 = 0; }
                else if (_SetB1 < 0) { ValidateSetSizeMessage("Значение 'B1' не может быть отрицательным"); _SetB1 = 0; }
                else
                {
                    ValidValue = false;
                    Move(_SetB1, 0);
                }
            }
        }
        public override double SetB2
        {
            get { return _SetB2; }
            set
            {
                SetField(ref _SetB2, value, () => SetB2);
                if (SetH + _SetB2 + SetB3 > 6000) { ValidateSetSizeMessage("Габаритный размер не может превышать 6000 мм"); _SetB2 = 0; }
                else if (_SetB2 < 0) { ValidateSetSizeMessage("Значение 'B2' не может быть отрицательным"); _SetB2 = 0; }
                else
                {
                    ValidValue = false;
                    Move(0, _SetB2);
                }
            }
        }
        public override double SetB3
        {
            get { return _SetB3; }
            set
            {

                SetField(ref _SetB3, value, () => SetB3);
                if (SetH + _SetB3 + SetB2 > 6000) { ValidateSetSizeMessage("Габаритный размер не может превышать 6000 мм"); _SetB3 = 0; }
                else if (_SetB3 < 0) { ValidateSetSizeMessage("Значение 'B3' не может быть отрицательным"); _SetB3 = 0; }
                else
                {
                    ValidValue = false;
                }
            }
        }
        public override Point[] GetFigurePoints()
        {
            Apogeus = GetNewPoint();
            Perigeus = GetNewPoint();

            Apogeus.PointX = A.PointX;
            Perigeus.PointX = A.PointX;
            Apogeus.PointY = A.PointY;
            Perigeus.PointY = A.PointY;
            #region Получаем угол ВСА для определения длины дуги скругления стороны АВ и уравниваем AC и BC
            Line l = GetNewLine(A, D);
            TempPoint.PointX = SetCurrentLineLength(A, D, l.Length / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(A, D, l.Length / 2).PointY;

            double height = SetRadius1 - Math.Sqrt(Math.Pow(SetRadius1, 2) - ((Math.Pow(l.Length, 2)) / 4));
            double r = SetRadius1 - height;


            CenterPoint.PointX = TempPoint.PointX + 1;
            // CenterPoint.Y = TempPoint.Y - r;
            CenterPoint.PointY = TempPoint.PointY - r;


            CenterPoint = SetCurrentLineLength(TempPoint, CenterPoint, SetRadius1 - height);
            CenterPoint.PointX -= 1;

         

            double angleBetween = CalculateAngle(A, CenterPoint, D);

            #endregion
            List<Point> pointsList = new List<Point> { A };
            double degree = 0;
            //  angleBetween = (SetH > SetL / 2) ? 360 - angleBetween : angleBetween;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (A.PointX - CenterPoint.PointX) * Math.Cos(-degree * Math.PI / 180) - (A.PointY - CenterPoint.PointY) * Math.Sin(-degree * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (A.PointX - CenterPoint.PointX) * Math.Sin(-degree * Math.PI / 180) + (A.PointY - CenterPoint.PointY) * Math.Cos(-degree * Math.PI / 180) + CenterPoint.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(D);
            Point[] points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var PointXMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var PointXMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            Apogeus.PointX = PointXMin;
            Apogeus.PointY = yMin;
            Perigeus.PointX = PointXMax;
            Perigeus.PointY = yMax;
            return points;
        }
        private Point[] GetFigureUpPoints()
        {
            ApogeusUp = GetNewPoint();
            PerigeusUp = GetNewPoint();

            ApogeusUp.PointX = A.PointX;
            PerigeusUp.PointX = A.PointX;
            ApogeusUp.PointY = A.PointY;
            PerigeusUp.PointY = A.PointY;


            #region Получаем угол ВСА для определения длины дуги скругления стороны АВ и уравниваем AC и BC
            Line l = GetNewLine(A, D);

            TempPoint.PointX = SetCurrentLineLength(B, C, l.Length / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(B, C, l.Length / 2).PointY;

            double height = SetRadius1 - Math.Sqrt(Math.Pow(SetRadius1, 2) - ((Math.Pow(l.Length, 2)) / 4));
            double r = SetRadius1 - height;


            CenterPoint.PointX = TempPoint.PointX + 1;
            // CenterPoint.Y = TempPoint.Y - r;
            CenterPoint.PointY = TempPoint.PointY + r;


            CenterPoint = SetCurrentLineLength(TempPoint, CenterPoint, SetRadius1 - height);
            CenterPoint.PointX -= 1;
            double angleBetween = CalculateAngle(B, CenterPoint, C);

            #endregion
            List<Point> pointsList = new List<Point> { B };
            double degree = 0;
            //  angleBetween = (SetH > SetL / 2) ? 360 - angleBetween : angleBetween;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (B.PointX - CenterPoint.PointX) * Math.Cos(degree * Math.PI / 180) - (B.PointY - CenterPoint.PointY) * Math.Sin(degree * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (B.PointX - CenterPoint.PointX) * Math.Sin(degree * Math.PI / 180) + (B.PointY - CenterPoint.PointY) * Math.Cos(degree * Math.PI / 180) + CenterPoint.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(C);
            Point[] points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var PointXMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var PointXMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            ApogeusUp.PointX = PointXMin;
            ApogeusUp.PointY = yMin;
            PerigeusUp.PointX = PointXMax;
            PerigeusUp.PointY = yMax;

            return points;
        }
        private Point[] GetFigureRightPoints()
        {
            ApogeusRight = GetNewPoint();
            PerigeusRight = GetNewPoint();

            ApogeusRight.PointX = A.PointX;
            PerigeusRight.PointX = A.PointX;
            ApogeusRight.PointY = A.PointY;
            PerigeusRight.PointY = A.PointY;

            #region Получаем угол ВСА для определения длины дуги скругления стороны АВ и уравниваем AC и BC
            Line l = GetNewLine(C, D);

            TempPoint.PointX = SetCurrentLineLength(D, C, l.Length / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(D, C, l.Length / 2).PointY;
            double dsd = Math.Sqrt(Math.Pow(SetRadius, 2) - ((Math.Pow(l.Length, 2)) / 4));
            double height = SetRadius - Math.Sqrt(Math.Pow(SetRadius, 2) - ((Math.Pow(l.Length, 2)) / 4));
            double r = SetRadius - height;


            CenterPoint.PointX = TempPoint.PointX - r - 0.01;
            // CenterPoint.Y = TempPoint.Y - r;
            CenterPoint.PointY = TempPoint.PointY;


            CenterPoint.PointX = SetCurrentLineLength(TempPoint, CenterPoint, SetRadius - height).PointX + 0.01;
            CenterPoint.PointY = SetCurrentLineLength(TempPoint, CenterPoint, SetRadius - height).PointY;




            //CenterPoint.PointX = TempPoint.PointX - r + 1;
            //// CenterPoint.Y = TempPoint.Y - r;
            //CenterPoint.Y = TempPoint.Y;


            //CenterPoint = SetCurrentLineLength(TempPoint, CenterPoint, SetRadius - height);
            //CenterPoint.PointX -= 1;
            double angleBetween = CalculateAngle(D, CenterPoint, C);

            #endregion
            List<Point> pointsList = new List<Point> { C };
            double degree = 0;
            //  angleBetween = (SetH > SetL / 2) ? 360 - angleBetween : angleBetween;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (C.PointX - CenterPoint.PointX) * Math.Cos(degree * Math.PI / 180) - (C.PointY - CenterPoint.PointY) * Math.Sin(degree * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (C.PointX - CenterPoint.PointX) * Math.Sin(degree * Math.PI / 180) + (C.PointY - CenterPoint.PointY) * Math.Cos(degree * Math.PI / 180) + CenterPoint.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(D);
            Point[] points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var PointXMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var PointXMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            ApogeusRight.PointX = PointXMin;
            ApogeusRight.PointY = yMin;
            PerigeusRight.PointX = PointXMax;
            PerigeusRight.PointY = yMax;


            return points;
        }
        private Point[] GetFigureLeftPoints()
        {
            ApogeusLeft = GetNewPoint();
            PerigeusLeft = GetNewPoint();
            ApogeusLeft.PointX = A.PointX;
            PerigeusLeft.PointX = A.PointX;
            ApogeusLeft.PointY = A.PointY;
            PerigeusLeft.PointY = A.PointY;

            #region Получаем угол ВСА для определения длины дуги скругления стороны АВ и уравниваем AC и BC
            Line l = GetNewLine(A, B);

            TempPoint.PointX = SetCurrentLineLength(A, B, l.Length / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(A, B, l.Length / 2).PointY;
            double dsd = Math.Sqrt(Math.Pow(SetRadius, 2) - ((Math.Pow(l.Length, 2)) / 4));
            double height = SetRadius - Math.Sqrt(Math.Pow(SetRadius, 2) - ((Math.Pow(l.Length, 2)) / 4));
            double r = SetRadius - height;


            CenterPoint.PointX = TempPoint.PointX + r + 0.01;
            // CenterPoint.Y = TempPoint.Y - r;
            CenterPoint.PointY = TempPoint.PointY;


            CenterPoint.PointX = SetCurrentLineLength(TempPoint, CenterPoint, SetRadius - height).PointX - 0.01;
            CenterPoint.PointY = SetCurrentLineLength(TempPoint, CenterPoint, SetRadius - height).PointY;

            double angleBetween = CalculateAngle(A, CenterPoint, B);

            #endregion
            List<Point> pointsList = new List<Point> { A };
            double degree = 0;
            //  angleBetween = (SetH > SetL / 2) ? 360 - angleBetween : angleBetween;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (A.PointX - CenterPoint.PointX) * Math.Cos(degree * Math.PI / 180) - (A.PointY - CenterPoint.PointY) * Math.Sin(degree * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (A.PointX - CenterPoint.PointX) * Math.Sin(degree * Math.PI / 180) + (A.PointY - CenterPoint.PointY) * Math.Cos(degree * Math.PI / 180) + CenterPoint.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(B);
            Point[] points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var PointXMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var PointXMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            ApogeusLeft.PointX = PointXMin;
            ApogeusLeft.PointY = yMin;
            PerigeusLeft.PointX = PointXMax;
            PerigeusLeft.PointY = yMax;
            return points;
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, D, Apogeus, Perigeus, ApogeusLeft, ApogeusRight, ApogeusUp, PerigeusLeft, PerigeusRight, PerigeusUp };

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
            var height = _SetH + _SetB2 * 2 + value2 + value4;

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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB2");
                AddIfPropertyExist(e.Properties, filteredCollection, "Area");
                AddIfPropertyExist(e.Properties, filteredCollection, "BaseArea");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKis");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKisPersent");
                AddIfPropertyExist(e.Properties, filteredCollection, "Perimeter");
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
