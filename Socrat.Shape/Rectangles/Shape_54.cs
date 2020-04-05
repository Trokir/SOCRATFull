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
    sealed class Shape_54 : Rectangular
    {
       private GraphicsPath graphicsPathUL { get; set; }
        private GraphicsPath graphicsPathLL { get; set; }
        private GraphicsPath graphicsPathUR { get; set; }
        private GraphicsPath graphicsPathLR { get; set; }
        private Rectangle upperLeftRect { get; set; }
        private Rectangle lowerLeftRect { get; set; }
        private Rectangle upperRightRect { get; set; }
        private Rectangle lowerRightRect { get; set; }
        private ShapePoint Apogeus { get; set; }
        private ShapePoint Perigeus { get; set; }
        private GraphicsPath graphicsPathUL_t { get; set; }
        private GraphicsPath graphicsPathLL_t { get; set; }
        private GraphicsPath graphicsPathUR_t { get; set; }
        private GraphicsPath graphicsPathLR_t { get; set; }
        private Rectangle upperLeftRect_t { get; set; }
        private Rectangle lowerLeftRect_t { get; set; }
        private Rectangle upperRightRect_t { get; set; }
        private Rectangle lowerRightRect_t { get; set; }
        private ShapePoint ApogeusCheck { get; set; }
        private ShapePoint PerigeusCheck { get; set; }
       // private Region myRegion { get; set; }
        
        public Shape_54(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) :
            base(ShapePoints, currentShapeParametersList)
        {
            Apogeus = GetNewPoint();
            Perigeus = GetNewPoint();
            ApogeusCheck = GetNewPoint();
            PerigeusCheck = GetNewPoint();
            tempPath = new GraphicsPath();
            Move(x: SetL1);
        }
        protected override void GetCurrentParameters(List<dynamic> currentShapeParametersList)
        {
            base.GetCurrentParameters(currentShapeParametersList);
            SetL1 = currentShapeParametersList[25];
            SetL2 = currentShapeParametersList[26];
            SetH1 = currentShapeParametersList[27];
            SetH2 = currentShapeParametersList[28];
        }
        protected override void DrawMainLines()
        {
            MoveLines();
        }
        protected override void CheckForeignBorders()
        {
           
            GetExtremumPoints();
            AllowanceProcessing();
        }

        private void MoveLines()
        {
            DrawEllipseRectangle();
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
               
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB2);
                MoveBorderRight(Y_Base, Z_Base, SetB1);
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
                sf.FormatFlags = StringFormatFlags.LineLimit;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                ShapePoint bs2 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY);
                ShapePoint be2 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY - SetB2);
                Line b2h = GetNewLine(bs2, be2);
                ShapePoint b2center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY - b2h.Length / 2);
                graphicsShape.DrawLine(pen, bs2, be2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2center, sf);

                ShapePoint bs21 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY);
                ShapePoint be21 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY + SetB2);
                Line b2h1 = GetNewLine(bs21, be21);
                ShapePoint b21center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY + b2h1.Length / 2);
                graphicsShape.DrawLine(pen, bs21, be21);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21center, sf);

                ShapePoint bs1 = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint be1 = GetNewCustomPoint(W_Base.PointX + SetB1, W_Base.PointY + 30 * LineBoundArgument);
                Line b1h = GetNewLine(bs1, be1);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + b1h.Length / 2,
                    W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, bs1, be1);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint bs11 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 30 * LineBoundArgument);
                ShapePoint be11 = GetNewCustomPoint(Z_Base.PointX - SetB1, Z_Base.PointY + 30 * LineBoundArgument);
                Line b1h1 = GetNewLine(bs11, be11);
                ShapePoint b11center = GetNewCustomPoint(Z_Base.PointX - b1h1.Length / 2, Z_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, bs11, be11);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b11center, sf);

                ShapePoint hs2 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, be21.PointY);
                ShapePoint he2 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, upperLeftRect.Y + upperLeftRect.Height / 2);
                Line lh2 = GetNewLine(hs2, he2);
                ShapePoint h2center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, be21.PointY + lh2.Length / 2);
                graphicsShape.DrawLine(pen, hs2, he2);
                graphicsShape.DrawString("H2=" + SetCurrentSize(SetH2), drawFontBold, Brushes.Black, h2center, sf);

                ShapePoint hs1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, be2.PointY);
                ShapePoint he1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, he2.PointY);
                Line lh1 = GetNewLine(hs1, he1);
                ShapePoint h1center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, be2.PointY - lh1.Length / 2);
                graphicsShape.DrawLine(pen, hs1, he1);
                graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, h1center, sf);

                ShapePoint ls1 = GetNewCustomPoint(W_Base.PointX + SetB1, Z_Base.PointY + 30 * LineBoundArgument);
                ShapePoint le1 = GetNewCustomPoint(lowerLeftRect.X + lowerLeftRect.Width / 2, Z_Base.PointY + 30 * LineBoundArgument);
                Line ll1 = GetNewLine(ls1, le1);
                ShapePoint l1center = GetNewCustomPoint(W_Base.PointX + ll1.Length / 2, Z_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls1, le1);
                graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l1center, sf);

                ShapePoint ls2 = GetNewCustomPoint(Z_Base.PointX - SetB1 - SetCurrentSize(SetL2), Z_Base.PointY + 30 * LineBoundArgument);
                ShapePoint le2 = GetNewCustomPoint(Z_Base.PointX - SetB1, Z_Base.PointY + 30 * LineBoundArgument);
                Line ll2 = GetNewLine(ls2, le2);
                ShapePoint l2center = GetNewCustomPoint(le2.PointX - ll2.Length / 2, Z_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls2, le2);
                graphicsShape.DrawString("L2=" + SetCurrentSize(SetL2), drawFontBold, Brushes.Black, l2center, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((X_Base.PointX + Y_Base.PointX + W_Base.PointX + Z_Base.PointX) / 4),
                ((X_Base.PointY + Y_Base.PointY + W_Base.PointY + Z_Base.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("54", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }

                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                   var downCenterPoint = GetNewCustomPoint(le1.PointX, Z_Base.PointY - SetB2);
                   var upPoint = GetNewCustomPoint(downCenterPoint.PointX, Y_Base.PointY + SetB2);
                   var downPoint = GetNewCustomPoint(downCenterPoint.PointX, Z_Base.PointY - SetB2);
                   var leftPoint = GetNewCustomPoint(W_Base.PointX + SetB1, W_Base.PointY - SetB2 - SetCurrentSize(SetH1));
                   var rightPoint = GetNewCustomPoint(Z_Base.PointX - SetB1, W_Base.PointY - SetB2 - SetCurrentSize(SetH1));
                    graphicsShape.DrawLine(pens, hs2, upPoint);
                    graphicsShape.DrawLine(pens, hs1, downPoint);
                    graphicsShape.DrawLine(pens, bs21, Y_Base);
                    graphicsShape.DrawLine(pens, bs2, Z_Base);
                    graphicsShape.DrawLine(pens, bs1, W_Base);
                    graphicsShape.DrawLine(pens, be1, leftPoint);
                    graphicsShape.DrawLine(pens, bs11, Z_Base);
                    graphicsShape.DrawLine(pens, be11, rightPoint);
                    graphicsShape.DrawLine(pens, le1, downCenterPoint);
                    graphicsShape.DrawLine(pens, he2, rightPoint);
                }
            }
        }
        public override RectangleF GetShapeBorders()
        {
            Region myRegion = new Region(tempPath);
            RectangleF boundsRect = myRegion.GetBounds(graphicsShape);
                graphicsShape.SetClip(myRegion, CombineMode.Replace);
               return boundsRect;
        }
        protected override GraphicsPath GetShapeShprosBorders()
        {
            return tempPath;
        }
        private GraphicsPath tempPath { get; set; }
        public override double Area
        {
            get
            {
                double upperLeftsquare = (Math.PI * SetH2 * SetL1) / 4;
                double upperRightsquare = (Math.PI * SetH2 * SetL2) / 4;
                double lowerLeftsquare = (Math.PI * SetH1 * SetL1) / 4;
                double lowerRightsquare = (Math.PI * SetH2 * SetL1) / 4;
                double square = upperLeftsquare + upperRightsquare + lowerLeftsquare + lowerRightsquare;
                return Math.Round(square/ 1000000, 3) ;
            }
        }
        public override double TrueArea
        {
            get
            {
                double upperLeftsquare = (Math.PI * (SetH2 + CheckCut1) * (SetL1 + CheckCut1)) / 4;
                double upperRightsquare = (Math.PI * (SetH2 + CheckCut1) * (SetL2 + CheckCut1)) / 4;
                double lowerLeftsquare = (Math.PI * (SetH1 + CheckCut1) * (SetL1 + CheckCut1)) / 4;
                double lowerRightsquare = (Math.PI * (SetH2 + CheckCut1) * (SetL1 + CheckCut1)) / 4;
                double square = upperLeftsquare + upperRightsquare + lowerLeftsquare + lowerRightsquare;
                return Math.Round(square / 1000000, 3);
            }
        }
        public override double Perimeter
        {
            get
            {
                double arg = Math.Log(2) / Math.Log(Math.PI / 2);
                double upperLeftperimeter = 4 * Math.Pow((Math.Pow((SetH2), arg)
                    + Math.Pow((SetL1), arg)), 1 / arg) / 4;
                double upperRightperimeter = 4 * Math.Pow((Math.Pow((SetH2), arg)
                   + Math.Pow((SetL2), arg)), 1 / arg) / 4;
                double lowerLeftPerimeter = 4 * Math.Pow((Math.Pow((SetH1), arg)
                  + Math.Pow((SetL1), arg)), 1 / arg) / 4;
                double lowerRightPerimeter = 4 * Math.Pow((Math.Pow((SetH1), arg)
                  + Math.Pow((SetL2), arg)), 1 / arg) / 4;
                double perimeter = upperLeftperimeter + upperRightperimeter + lowerLeftPerimeter + lowerRightPerimeter;
                return Math.Round(perimeter/ 1000,3) ;
            }
        }
        public override double Perimeter_t
        {
            get
            {
                double arg = Math.Log(2) / Math.Log(Math.PI / 2);
                double upperLeftperimeter = 4 * Math.Pow((Math.Pow((SetH2 + CheckCut1), arg)
                    + Math.Pow((SetL1 + CheckCut1), arg)), 1 / arg) / 4;
                double upperRightperimeter = 4 * Math.Pow((Math.Pow((SetH2 + CheckCut1), arg)
                   + Math.Pow((SetL2 + CheckCut1), arg)), 1 / arg) / 4;
                double lowerLeftPerimeter = 4 * Math.Pow((Math.Pow((SetH1 + CheckCut1), arg)
                  + Math.Pow((SetL1 + CheckCut1), arg)), 1 / arg) / 4;
                double lowerRightPerimeter = 4 * Math.Pow((Math.Pow((SetH1 + CheckCut1), arg)
                  + Math.Pow((SetL2 + CheckCut1), arg)), 1 / arg) / 4;
                double perimeter = upperLeftperimeter + upperRightperimeter + lowerLeftPerimeter + lowerRightPerimeter;
                return Math.Round(perimeter/ 1000, 3) ;
            }
        }
        public override double SetH1
        {
            get => _SetH1 = (_SetH1 == 0) ? 362 : _SetH1;
            set => base.SetH1 = value;
        }
        public override double SetH2
        {
            get => _SetH2 = (_SetH2 == 0) ? 362 : _SetH2;
            set => base.SetH2 = value;
        }
        public override double SetL1
        {
            get => _SetL1 = (_SetL1 == 0) ? 242 : _SetL1;
            set => base.SetL1 = value;
        }
        public override double SetL2
        {

            get => _SetL2 = (_SetL2 == 0) ? 342 : _SetL2;
            set => base.SetL2 = value;
        }
        private void DrawEllipseRectangle()
        {
            Pen pen;
            using (pen = new Pen(Color.Red))
            {

                using (graphicsPathUL = new GraphicsPath())
                {
                    using (graphicsPathLL = new GraphicsPath())
                    {
                        using (graphicsPathUR = new GraphicsPath())
                        {
                            using (graphicsPathLR = new GraphicsPath())
                            {

                                upperLeftRect = new Rectangle((int)B.PointX, (int)B.PointY, (int)SetL1 * 2, (int)SetH2 * 2);
                                graphicsPathUL.AddArc(upperLeftRect, 180, 90);
                                graphicsShape.DrawPath(pen, graphicsPathUL);
                                lowerLeftRect = new Rectangle((int)B.PointX, (int)B.PointY + upperLeftRect.Height / 2 - (int)SetH1, (int)SetL1 * 2, (int)SetH1 * 2);
                                graphicsPathLL.AddArc(lowerLeftRect, 90, 90);
                                graphicsShape.DrawPath(pen, graphicsPathLL);
                                upperRightRect = new Rectangle((int)B.PointX + upperLeftRect.Width / 2 - (int)SetL2, (int)B.PointY, (int)SetL2 * 2, (int)SetH2 * 2);
                                graphicsPathUR.AddArc(upperRightRect, 270, 90);
                                graphicsShape.DrawPath(pen, graphicsPathUR);
                                C.PointX = B.PointX + upperLeftRect.Width / 2 - SetL2 + SetL2;
                                D.PointX = C.PointX;
                                A.PointY = B.PointY + upperLeftRect.Height / 2 - SetH1 + SetH1;
                                D.PointY = A.PointY;
                                lowerRightRect = new Rectangle((int)B.PointX + upperLeftRect.Width / 2 - (int)SetL2,
                                    (int)B.PointY + upperLeftRect.Height / 2 - (int)SetH1, (int)SetL2 * 2, (int)SetH1 * 2);
                                graphicsPathLR.AddArc(lowerRightRect, 0, 90);
                                graphicsShape.DrawPath(pen, graphicsPathLR);
                                var myPath = new GraphicsPath();
                                    myPath.AddPath(graphicsPathUL, true);
                                    myPath.AddPath(graphicsPathUR, true);
                                    myPath.AddPath(graphicsPathLR, true);
                                    myPath.AddPath(graphicsPathLL, true);
                                    tempPath = myPath;
                                    graphicsShape.FillPath(new SolidBrush(Color.FromArgb(30, Color.Blue)), myPath);
                                
                            }
                        }
                    }
                }
                if (IsToothVector == true)
                {
                    pen.DashStyle = DashStyle.DashDot;
                    pen.Width = ThiсknessArgument / 2;
                    IsToothVector = true;
                }
                else
                {
                    pen.Width = ThiсknessArgument;
                    IsToothVector = false;
                }
            }



        }
        public override double SetH1_t { get => Math.Round(SetH1 + CheckCut1, 0); }
        public override double SetH2_t { get => Math.Round(SetH2 + CheckCut1, 0); }
        public override double SetL1_t { get => Math.Round(SetL1 + CheckCut1, 0); }
        public override double SetL2_t { get => Math.Round(SetL2 + CheckCut1, 0); }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            //Move(0, SetH1);
            A.PointX = SetCurrentLineLength(B, A, SetH2 + _SetL1).PointX;
            A.PointY = SetCurrentLineLength(B, A, SetH2 + _SetL1).PointY;
            D.PointY = A.PointY;
            ValidValue = false;
        }
        protected override void SetH2Value()
        {
            base.SetH2Value();
            Move(y: _SetH2);
            B.PointX = SetCurrentLineLength(A, B, _SetH2 + SetL1).PointX;
            B.PointY = SetCurrentLineLength(A, B, _SetH2 + SetL1).PointY;
            C.PointY = B.PointY;
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            base.SetL1Value();
            Move(x:_SetL1);
            B.PointX = SetCurrentLineLength(C, B, _SetL1 + SetL2).PointX;
            B.PointY = SetCurrentLineLength(C, B, _SetL1 + SetL2).PointY;
            A.PointX = B.PointX;
            ValidValue = false;
        }
        protected override void SetL2Value()
        {
            base.SetL2Value();
            C.PointX = SetCurrentLineLength(B, C, _SetL2 + SetL1).PointX;
            C.PointY = SetCurrentLineLength(B, C, _SetL2 + SetL1).PointY;
            D.PointX = C.PointX;
            ValidValue = false;
        }
        protected override void AllowanceProcessing()
        {
            Pen pen;
            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;
            using (pen = new Pen(Color.Red))
            {

                using (graphicsPathUL_t = new GraphicsPath())
                {
                    using (graphicsPathLL_t = new GraphicsPath())
                    {
                        using (graphicsPathUR_t = new GraphicsPath())
                        {
                            using (graphicsPathLR_t = new GraphicsPath())
                            {
                                upperLeftRect_t = new Rectangle((int)B.PointX - (int)CheckCut1, (int)B.PointY - (int)CheckCut1, (int)SetL1 * 2 + (int)CheckCut1,
                                    (int)SetH2 * 2 + (int)CheckCut1);
                                graphicsPathUL_t.AddArc(upperLeftRect_t, 180, 90);
                                graphicsShape.DrawPath(pen, graphicsPathUL_t);


                                lowerLeftRect_t = new Rectangle(
                                     (int)B.PointX - (int)CheckCut1,
                                     (int)B.PointY + upperLeftRect_t.Height / 2 - (int)SetH1 - (int)CheckCut1 / 2,
                                     (int)SetL1 * 2 + (int)CheckCut1,
                                     (int)SetH1 * 2 + (int)CheckCut1
                                     );
                                graphicsPathLL_t.AddArc(lowerLeftRect_t, 90, 90);
                                graphicsShape.DrawPath(pen, graphicsPathLL_t);


                                upperRightRect_t = new Rectangle(
                                     (int)B.PointX - (int)CheckCut1 / 2 + upperLeftRect_t.Width / 2 - (int)SetL2,
                                     (int)B.PointY - (int)CheckCut1,
                                     (int)SetL2 * 2 + (int)CheckCut1,
                                     (int)SetH2 * 2 + (int)CheckCut1);
                                graphicsPathUR_t.AddArc(upperRightRect_t, 270, 90);
                                graphicsShape.DrawPath(pen, graphicsPathUR_t);
                                C.PointX = B.PointX + upperLeftRect_t.Width / 2 - SetL2 + SetL2;
                                D.PointX = C.PointX;
                                A.PointY = B.PointY + upperLeftRect_t.Height / 2 - SetH1 + SetH1;
                                D.PointY = A.PointY;
                                lowerRightRect_t = new Rectangle(
                                    (int)B.PointX - (int)CheckCut1 / 2 + upperLeftRect_t.Width / 2 - (int)SetL2,
                                    (int)B.PointY - (int)CheckCut1 / 2 + upperLeftRect_t.Height / 2 - (int)SetH1,
                                    (int)SetL2 * 2 + (int)CheckCut1,
                                    (int)SetH1 * 2 + (int)CheckCut1);
                                graphicsPathLR_t.AddArc(lowerRightRect_t, 0, 90);
                                graphicsShape.DrawPath(pen, graphicsPathLR_t);

                            }
                        }
                    }
                }
                if (IsToothVector == true)
                {

                    pen.Width = ThiсknessArgument;
                    IsToothVector = true;
                }
                else
                {
                    pen.DashStyle = DashStyle.DashDot;
                    pen.Width = ThiсknessArgument / 2;
                    IsToothVector = false;
                }
            }



            GetExtremumPoints();
        }
        public override void GetExtremumPoints()
        {
            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;
            Apogeus.PointX = A.PointX;
            Apogeus.PointY = lowerLeftRect.Y + lowerLeftRect.Height;
            Perigeus.PointX = upperRightRect.X + upperRightRect.Width;
            Perigeus.PointY = B.PointY;


            BCheck.PointX = B.PointX - CheckCut1;
            BCheck.PointY = B.PointY - CheckCut1;

            ApogeusCheck.PointX = A.PointX + CheckCut1;
            ApogeusCheck.PointY = lowerLeftRect_t.Y + lowerLeftRect_t.Height;
            PerigeusCheck.PointX = upperRightRect_t.X + upperRightRect_t.Width;
            PerigeusCheck.PointY = B.PointY + CheckCut1;

            List<ShapePoint> pointList = new List<ShapePoint>() { B, C, A, D, Apogeus, Perigeus, BCheck };
            if (IsToothVector == true)
            {
                pointList.Add(ApogeusCheck);
                pointList.Add(PerigeusCheck);
            }
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
            var value1 = (IsToothVector == true) ? _CheckCut1 : 0;
           
            var width = _SetL1+_SetL2 + _SetB1*2  + value1*2;
            var height = _SetH1+_SetH2+  _SetB2*2 + value1*2;

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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH2");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL2");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH2_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL2_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
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
