using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;

namespace Socrat.Shape.Rectangles
{
    sealed class Shape_56 : Rectangular
    {
        private ShapePoint ACheck1 { get; set; }
        private ShapePoint ACheck2 { get; set; }
        private ShapePoint BCheck1 { get; set; }
        private ShapePoint BCheck2 { get; set; }
        private ShapePoint CCheck1 { get; set; }
        private ShapePoint CCheck2 { get; set; }
        private ShapePoint DCheck1 { get; set; }
        private ShapePoint DCheck2 { get; set; }
        public Shape_56(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
            ACheck1 = GetNewPoint();
            ACheck2 = GetNewPoint();
            BCheck1 = GetNewPoint();
            BCheck2 = GetNewPoint();
            CCheck1 = GetNewPoint();
            CCheck2 = GetNewPoint();
            DCheck1 = GetNewPoint();
            DCheck2 = GetNewPoint();
        }
        public override double Area
        {
            get
            {
                Line ura = GetNewLine(C1, C);
                double cSector = (Math.PI * Math.Pow(ura.Length, 2) * 90) / 360;
                Line ula = GetNewLine(B2, B);
                double bSector = (Math.PI * Math.Pow(ula.Length, 2) * 90) / 360;
                Line lla = GetNewLine(A2, A);
                double aSector = (Math.PI * Math.Pow(lla.Length, 2) * 90) / 360;
                Line lra = GetNewLine(D2, D);
                double dSector = (Math.PI * Math.Pow(lra.Length, 2) * 90) / 360;

                double baseSquare = 0.5 * Math.Abs((A.PointX * B.PointY + B.PointX * C.PointY + C.PointX * D.PointY + D.PointX * A.PointY) - (B.PointX * A.PointY + C.PointX * B.PointY + D.PointX * C.PointY + A.PointX * D.PointY));
                return Math.Round((baseSquare - Math.Abs(aSector) - Math.Abs(dSector) - Math.Abs(bSector) - 
                    Math.Abs(cSector)) / 1000000,3);
            }
        }
        public override double TrueArea
        {
            get
            {
                Line ura = GetNewLine(CCheck1, CCheck);
                double cSector = (Math.PI * Math.Pow(ura.Length, 2) * 90) / 360;
                Line ula = GetNewLine(BCheck2, BCheck);
                double bSector = (Math.PI * Math.Pow(ula.Length, 2) * 90) / 360;
                Line lla = GetNewLine(ACheck2, ACheck);
                double aSector = (Math.PI * Math.Pow(lla.Length, 2) * 90) / 360;
                Line lra = GetNewLine(DCheck2, DCheck);
                double dSector = (Math.PI * Math.Pow(lra.Length, 2) * 90) / 360;

                double baseSquare = 0.5 * Math.Abs((ACheck.PointX * BCheck.PointY + BCheck.PointX * CCheck.PointY + CCheck.PointX * DCheck.PointY + DCheck.PointX * ACheck.PointY) -
                    (BCheck.PointX * ACheck.PointY + CCheck.PointX * BCheck.PointY + DCheck.PointX * CCheck.PointY + ACheck.PointX * DCheck.PointY));
                return Math.Round((baseSquare - Math.Abs(aSector) - Math.Abs(dSector) - Math.Abs(bSector) - Math.Abs(cSector)) / 1000000,3);
            }
        }
        public override double Perimeter
        {
            get
            {
                double upperLeftArc = SetB_radius * Math.PI * (CalculateAngle(A, B, C) <= 90 ? CalculateAngle(A, B, C) : 180 - CalculateAngle(A, B, C)) / 180;
                double upperRightArc = SetC_radius * Math.PI * (CalculateAngle(B, C, D) <= 90 ? CalculateAngle(B, C, D) : 180 - CalculateAngle(B, C, D)) / 180;
                double lowerLeftArc = SetA_radius * Math.PI * (CalculateAngle(D, A, B) <= 90 ? CalculateAngle(D, A, B) : 180 - CalculateAngle(D, A, B)) / 180;
                double lowerRighttArc = SetD_radius * Math.PI * (CalculateAngle(C, D, A) <= 90 ? CalculateAngle(C, D, A) : 180 - CalculateAngle(C, D, A)) / 180;
                Line a = GetNewLine(A2, B1);
                Line b = GetNewLine(B2, C2);
                Line c = GetNewLine(C1, D2);
                Line d = GetNewLine(D1, A1);
                return Math.Round((upperLeftArc + upperRightArc + lowerLeftArc + lowerRighttArc + a.Length + b.Length + c.Length + d.Length) / 1000,3);
            }

        }
        public override double Perimeter_t
        {
            get
            {
                double upperLeftArc = (SetB_radius + CheckCut1) * Math.PI * (CalculateAngle(A, B, C) <= 90 ? CalculateAngle(A, B, C) : 180 - CalculateAngle(A, B, C)) / 180;
                double upperRightArc = (SetC_radius + CheckCut1) * Math.PI * (CalculateAngle(B, C, D) <= 90 ? CalculateAngle(B, C, D) : 180 - CalculateAngle(B, C, D)) / 180;
                double lowerLeftArc = (SetA_radius + CheckCut1) * Math.PI * (CalculateAngle(D, A, B) <= 90 ? CalculateAngle(D, A, B) : 180 - CalculateAngle(D, A, B)) / 180;
                double lowerRighttArc = (SetD_radius + CheckCut1) * Math.PI * (CalculateAngle(C, D, A) <= 90 ? CalculateAngle(C, D, A) : 180 - CalculateAngle(C, D, A)) / 180;
                Line a = GetNewLine(ACheck2, BCheck1);
                Line b = GetNewLine(BCheck2, CCheck2);
                Line c = GetNewLine(CCheck1, DCheck2);
                Line d = GetNewLine(DCheck1, ACheck1);
                return Math.Round((upperLeftArc + upperRightArc + lowerLeftArc + lowerRighttArc + a.Length + b.Length + c.Length + d.Length)/ 1000, 3);
            }

        }
        protected override void DrawMainLines()
        {
            if (IsToothVector == true)
            {
                using (Pen pensil = new Pen(Color.Red, ThiсknessArgument / 2))
                {
                    pensil.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawPath(pensil, MakeRoundCorner(A, B, C, SetB_radius));
                    graphicsShape.DrawPath(pensil, MakeRoundCorner(B, C, D, SetC_radius));
                    graphicsShape.DrawPath(pensil, MakeRoundCorner(C, D, A, SetD_radius));
                    graphicsShape.DrawPath(pensil, MakeRoundCorner(D, A, B, SetA_radius));
                    A.PointRadius = SetA_radius;
                    B.PointRadius = SetB_radius;
                    C.PointRadius = SetC_radius;
                    D.PointRadius = SetD_radius;
                }
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument / 2))
                {
                    pen1.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen1, A2, B1);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument / 2))
                {
                    pen2.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen2, B2, C2);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument / 2))
                {
                    pen3.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen3, C1, D2);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument / 2))
                {
                    pen4.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen4, D1, A1);
                }
                IsToothVector = true;
            }
            else
            {
                using (Pen pensil = new Pen(Color.Red, ThiсknessArgument))
                {
                    graphicsShape.DrawPath(pensil, MakeRoundCorner(A, B, C, SetB_radius));
                    graphicsShape.DrawPath(pensil, MakeRoundCorner(B, C, D, SetC_radius));
                    graphicsShape.DrawPath(pensil, MakeRoundCorner(C, D, A, SetD_radius));
                    graphicsShape.DrawPath(pensil, MakeRoundCorner(D, A, B, SetA_radius));
                    A.PointRadius = SetA_radius;
                    B.PointRadius = SetB_radius;
                    C.PointRadius = SetC_radius;
                    D.PointRadius = SetD_radius;
                }
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen1, A2, B1);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen2, B2, C2);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen3, C1, D2);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen4, D1, A1);
                }
                IsToothVector = false;
            }
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(A2, B1);
                myPath.AddPath(MakeRoundCorner(A, B, C, SetB_radius), true);
                myPath.AddLine(B2, C2);
                myPath.AddPath(MakeRoundCorner(B, C, D, SetC_radius), true);
                myPath.AddLine(C1, D2);
                myPath.AddPath(MakeRoundCorner(C, D, A, SetD_radius), true);
                myPath.AddLine(D1, A1);
                myPath.AddPath(MakeRoundCorner(D, A, B, SetA_radius), true);
                graphicsShape.FillPath(new SolidBrush(Color.FromArgb(30, Color.Blue)), myPath);
            }
            MoveLines();
        }
        protected override void CheckForeignBorders()
        {
           
            AllowanceProcessing();
            GetExtremumPoints();
        }

        private void MoveLines()
        {
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                
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
            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;

                ShapePoint ls = (IsToothVector == true) ? GetNewCustomPoint(ACheck2.PointX, W_Base.PointY + 20 * LineBoundArgument) :
                    GetNewCustomPoint(A2.PointX, W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint le = (IsToothVector == true) ? GetNewCustomPoint(DCheck2.PointX, W_Base.PointY + 20 * LineBoundArgument) :
                    GetNewCustomPoint(D2.PointX, W_Base.PointY + 20 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = (IsToothVector == true) ? GetNewCustomPoint(ACheck2.PointX + (ll.Length / 2), W_Base.PointY + 20 * LineBoundArgument) :
                    GetNewCustomPoint(A2.PointX + (ll.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetL, drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint b3s = (IsToothVector == true) ? GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, CCheck2.PointY) :
                     GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, C2.PointY);
                ShapePoint b3e = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY);
                Line lb3 = GetNewLine(b3s, b3e);
                ShapePoint b3center = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY + lb3.Length / 2);
                graphicsShape.DrawLine(pen, b3s, b3e);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b3center, sf);

                ShapePoint bs2 = (IsToothVector == true) ? GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, DCheck1.PointY) :
                    GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, D1.PointY);
                ShapePoint be2 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY);
                Line bl2 = GetNewLine(bs2, be2);
                ShapePoint b12center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY - (bl2.Length / 2));
                graphicsShape.DrawLine(pen, bs2, be2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b12center, sf);

                ShapePoint b12s11 = (IsToothVector == true) ? GetNewCustomPoint(ACheck2.PointX, W_Base.PointY + 20 * LineBoundArgument) :
                    GetNewCustomPoint(A2.PointX, W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b12e11 = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b12s11, b12e11);
                Line b221h = GetNewLine(b12s11, b12e11);
                ShapePoint b221scenter = GetNewCustomPoint(W_Base.PointX + b221h.Length / 2, W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b221scenter, sf);


                ShapePoint b12s1 = (IsToothVector == true) ? GetNewCustomPoint(DCheck2.PointX, Z_Base.PointY + 20 * LineBoundArgument) :
                    GetNewCustomPoint(D2.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b12e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b12s1, b12e1);
                Line b22h = GetNewLine(b12s1, b12e1);
                ShapePoint b22scenter = GetNewCustomPoint(Z_Base.PointX - b22h.Length / 2, Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b22scenter, sf);


                ShapePoint bsh = (IsToothVector == true) ? GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, DCheck1.PointY) :
                    GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, D1.PointY);
                ShapePoint beh = (IsToothVector == true) ? GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, CCheck2.PointY) :
                     GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, C2.PointY);
                Line blh = GetNewLine(bsh, beh);
                ShapePoint bhcenter = (IsToothVector == true) ? GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, DCheck1.PointY - (blh.Length / 2)) :
                   GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, D2.PointY - (blh.Length / 2));
                graphicsShape.DrawLine(pen, bsh, beh);
                graphicsShape.DrawString("H=" + SetH, drawFontBold, Brushes.Black, bhcenter, sf);

                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                graphicsShape.FillEllipse(Brushes.Black, ArF);
                graphicsShape.FillEllipse(Brushes.Black, BrF);
                graphicsShape.FillEllipse(Brushes.Black, CrF);
                graphicsShape.FillEllipse(Brushes.Black, DrF);
                graphicsShape.DrawString("R=" + SetA_radius, drawFontBold, Brushes.Green, ArF.Location);
                graphicsShape.DrawString("R1=" + SetB_radius, drawFontBold, Brushes.Green, BrF.Location);
                graphicsShape.DrawString("R2=" + SetC_radius, drawFontBold, Brushes.Green, CrF.Location, sf);
                graphicsShape.DrawString("R3=" + SetD_radius, drawFontBold, Brushes.Green, DrF.Location, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    
                    graphicsShape.DrawString("56", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    if (IsToothVector == true)
                    {
                        var wer1 = GetNewCustomPoint(W_Base.PointX, BCheck2.PointY);
                        var wer2 = GetNewCustomPoint(BCheck1.PointX, wer1.PointY);
                        var wer3 = GetNewCustomPoint(Z_Base.PointX, CCheck2.PointY);
                        var wer4 = GetNewCustomPoint(CCheck1.PointX, wer3.PointY);
                        var wer5 = GetNewCustomPoint(Z_Base.PointX, DCheck1.PointY);
                        var wer6 = GetNewCustomPoint(DCheck2.PointX, wer5.PointY);
                        var wer7 = GetNewCustomPoint(W_Base.PointX, ACheck1.PointY);
                        var wer8 = GetNewCustomPoint(ACheck2.PointX, wer7.PointY);
                        using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                        {
                            graphicsShape.DrawLine(pen1, wer1, BCheck2);
                            graphicsShape.DrawLine(pen1, wer2, BCheck1);
                            graphicsShape.DrawLine(pen1, wer3, CCheck2);
                            graphicsShape.DrawLine(pen1, wer4, CCheck1);
                            graphicsShape.DrawLine(pen1, wer5, DCheck1);
                            graphicsShape.DrawLine(pen1, wer6, DCheck2);
                            graphicsShape.DrawLine(pen1, wer7, ACheck1);
                            graphicsShape.DrawLine(pen1, wer8, ACheck2);
                        }
                        graphicsShape.DrawLine(pens, be2, Z_Base);
                        graphicsShape.DrawLine(pens, bs2, wer5);
                        graphicsShape.DrawLine(pens, b3e, Y_Base);
                        graphicsShape.DrawLine(pens, b3s, wer3);
                        graphicsShape.DrawLine(pens, b12s11, wer8);
                        graphicsShape.DrawLine(pens, b12e11, W_Base);
                        graphicsShape.DrawLine(pens, b12s1, wer6);
                        graphicsShape.DrawLine(pens, b12e1, Z_Base);

                    }
                    else
                    {
                        var wer1 = GetNewCustomPoint(W_Base.PointX, B2.PointY);
                        var wer2 = GetNewCustomPoint(B1.PointX, wer1.PointY);
                        var wer3 = GetNewCustomPoint(Z_Base.PointX, C2.PointY);
                        var wer4 = GetNewCustomPoint(C1.PointX, wer3.PointY);
                        var wer5 = GetNewCustomPoint(Z_Base.PointX, D1.PointY);
                        var wer6 = GetNewCustomPoint(D2.PointX, wer5.PointY);
                        var wer7 = GetNewCustomPoint(W_Base.PointX, A1.PointY);
                        var wer8 = GetNewCustomPoint(A2.PointX, wer7.PointY);
                        using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                        {
                            graphicsShape.DrawLine(pen1, wer1, B2);
                            graphicsShape.DrawLine(pen1, wer2, B1);
                            graphicsShape.DrawLine(pen1, wer3, C2);
                            graphicsShape.DrawLine(pen1, wer4, C1);
                            graphicsShape.DrawLine(pen1, wer5, D1);
                            graphicsShape.DrawLine(pen1, wer6, D2);
                            graphicsShape.DrawLine(pen1, wer7, A1);
                            graphicsShape.DrawLine(pen1, wer8, A2);
                        }
                        graphicsShape.DrawLine(pens, be2, Z_Base);
                        graphicsShape.DrawLine(pens, bs2, wer5);
                        graphicsShape.DrawLine(pens, b3e, Y_Base);
                        graphicsShape.DrawLine(pens, b3s, wer3);
                        graphicsShape.DrawLine(pens, b12s11, wer8);
                        graphicsShape.DrawLine(pens, b12e11, W_Base);
                        graphicsShape.DrawLine(pens, b12s1, wer6);
                        graphicsShape.DrawLine(pens, b12e1, Z_Base);

                    }
                    #endregion

                }
            }
        }
        public override RectangleF GetShapeBorders()
        {
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(A2, B1);
                myPath.AddPath(MakeRoundCorner(A, B, C, SetB_radius), true);
                myPath.AddLine(B2, C2);
                myPath.AddPath(MakeRoundCorner(B, C, D, SetC_radius), true);
                myPath.AddLine(C1, D2);
                myPath.AddPath(MakeRoundCorner(C, D, A, SetD_radius), true);
                myPath.AddLine(D1, A1);
                myPath.AddPath(MakeRoundCorner(D, A, B, SetA_radius), true);
                Region myRegion = new Region(myPath);
                RectangleF boundsRect = myRegion.GetBounds(graphicsShape);
               // graphicsShape.SetClip(myRegion, CombineMode.Replace);
                return boundsRect;
            }
        }
        protected override GraphicsPath GetShapeShprosBorders()
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(A2, B1);
            myPath.AddPath(MakeRoundCorner(A, B, C, SetB_radius), true);
            myPath.AddLine(B2, C2);
            myPath.AddPath(MakeRoundCorner(B, C, D, SetC_radius), true);
            myPath.AddLine(C1, D2);
            myPath.AddPath(MakeRoundCorner(C, D, A, SetD_radius), true);
            myPath.AddLine(D1, A1);
            myPath.AddPath(MakeRoundCorner(D, A, B, SetA_radius), true);
            return myPath;
        }
        public override double SetH { get => Math.Round(A_line.Length, 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(D_line.Length, 0); set => base.SetL = value; }
        public override double SetRadius { get => SetA_radius; set => base.SetRadius = value; }
        public override double SetRadius1 { get => SetB_radius; set => base.SetRadius1 = value; }
        public override double SetRadius2 { get => SetC_radius; set => base.SetRadius2 = value; }
        public override double SetRadius3 { get => SetD_radius; set => base.SetRadius3 = value; }
        public override double SetL_t { get => Math.Round(D_Check_Line.Length, 0); }
        public override double SetH_t { get => Math.Round(A_Check_Line.Length, 0); }
        public override double SetRadius_t
        {
            get => SetRadius + _CheckCut1;
        }
        public override double SetRadius1_t
        {
            get => SetRadius1 + _CheckCut1;
        }
        public override double SetRadius2_t
        {
            get => SetRadius2 + _CheckCut1;
        }
        public override double SetRadius3_t
        {
            get => SetRadius3 + _CheckCut1;
        }
        protected override void SetHValue()
        {
            base.SetHValue();
            A.PointX = SetCurrentLineLength(B, A, _SetH).PointX;
            A.PointY = SetCurrentLineLength(B, A, _SetH).PointY;
            D.PointY = A.PointY;
            ValidValue = false;
        }
        protected override void SetRadiusValue()
        {
            SetA_radius = (float)_SetRadius;
            ValidValue = false;
        }
        protected override void SetRadius1Value()
        {
            SetB_radius = (float)_SetRadius1;
            ValidValue = false;
        }
        protected override void SetRadius2Value()
        {
            SetC_radius = (float)_SetRadius2;
            ValidValue = false;
        }
        protected override void SetRadius3Value()
        {
            SetD_radius = (float)_SetRadius3;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            var p= A.PointX;
            CurvePoint.PointX = A.PointX + D_line.Length / 2;
            CurvePoint.PointY = A.PointY;
            A.PointX = SetCurrentLineLength(CurvePoint, A, _SetL / 2).PointX;
            A.PointY = SetCurrentLineLength(CurvePoint, A, _SetL / 2).PointY;
            D.PointX = SetCurrentLineLength(CurvePoint, D, _SetL / 2).PointX;
            D.PointY = SetCurrentLineLength(CurvePoint, D, _SetL / 2).PointY;
            B.PointX = A.PointX;
            C.PointX = D.PointX;
            var diff = p - A.PointX;
            Move(x: diff);
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {
            List<ShapePoint> pointList = new List<ShapePoint>() {A, B, C, D,
                ACheck1, BCheck1, CCheck1, DCheck1, ACheck2, BCheck2, CCheck2, DCheck2, ACheck, BCheck, CCheck, DCheck};
            var PointXMax = pointList.Max(PointX => PointX.PointX);
            var yMax = pointList.Max(PointX => PointX.PointY);
            var PointXMin = pointList.Min(PointX => PointX.PointX);
            var yMin = pointList.Min(PointX => PointX.PointY);
            W_Base = new ShapePoint(PointXMin, yMax);
            X_Base = new ShapePoint(PointXMin, yMin);
            Y_Base = new ShapePoint(PointXMax, yMin);
            Z_Base = new ShapePoint(PointXMax, yMax);

        }
        protected override GraphicsPath MakeRoundCorner(ShapePoint firstPoint, ShapePoint secondPoint, ShapePoint thirdPoint, double setRadius, double radius = 0.1)
        {
            radius += setRadius;

            PointF pt1, pt2;
            double angleBetween = 0;
            GraphicsPath retval = new GraphicsPath();

            Vector vectorBc = new Vector((firstPoint.PointX - secondPoint.PointX), (firstPoint.PointY - secondPoint.PointY));
            Vector vectorCd = new Vector((thirdPoint.PointX - secondPoint.PointX), (thirdPoint.PointY - secondPoint.PointY));
            radius = CorrectingRadiusForShapeAngles(firstPoint, secondPoint, thirdPoint, radius);
            Vector n1 = new Vector(), n2 = new Vector();
            angleBetween = Math.Abs(Vector.AngleBetween(vectorBc, vectorCd)) + 0.001F;

            //Размер прямоугольника, ограничивающего дугу сопряжения
            SizeF size = new SizeF(2 * (float)radius, 2 * (float)radius);
            //Центр сопряжения
            PointF center = new PointF();
            float sweepangle = (float)Vector.AngleBetween(vectorBc, vectorCd) + 0.001F;

            if (sweepangle < 0)
            {//переход от v1 к v2 по часовой
                n1 = new Vector(vectorBc.Y, -vectorBc.X);
                n2 = new Vector(-vectorCd.Y, vectorCd.X + 0.001F);
            }
            else
            {
                n1 = new Vector(-vectorBc.Y, vectorBc.X);
                n2 = new Vector(vectorCd.Y, -vectorCd.X + 0.001F);
            }
            //Нормирование векторов
            n1.Normalize(); n2.Normalize();
            n1 *= radius; n2 *= radius;
            pt1 = new PointF((float)(secondPoint.PointX - n1.X), (float)(secondPoint.PointY - n1.Y));
            //Точка на прямой, параллельной v2
            pt2 = new PointF((float)(secondPoint.PointX - n2.X), (float)(secondPoint.PointY - n2.Y));
            double m1 = vectorBc.Y / (vectorBc.X + 1), m2 = vectorCd.Y / (vectorCd.X + 1);
            center.X = (float)secondPoint.PointX;
            center.Y = (float)secondPoint.PointY;

            RectangleF rectPoint = new RectangleF(center.X - 1, center.Y - 1, 2, 2);
            //  n1.Negate(); n2.Negate();//Разворот нормалей
            PointF a = new PointF((float)(center.X + n1.X), (float)(center.Y + n1.Y));
            PointF b = new PointF((float)(center.X + n2.X), (float)(center.Y + n2.Y));

            CreatingAdvancedPoints(secondPoint, rectPoint, a, b);
            if (size.Width == 0) { size.Width += 0.2F; size.Height += 0.2F; }
            RectangleF rect = new RectangleF(new PointF(center.X - (float)radius, center.Y - (float)radius), size);
            sweepangle = (float)Vector.AngleBetween(n2, n1);
            sweepangle = (sweepangle == 180) ? 181 : sweepangle;
            retval.AddArc(rect, (float)Vector.AngleBetween(new Vector(1, 0), n2), sweepangle);

            return retval;
        }
        protected override void AllowanceProcessing()
        {

            ACheck.PointX = ACheck1.PointX = ACheck1.PointX = A.PointX;
            ACheck.PointY = ACheck1.PointY = ACheck2.PointY = A.PointY;
            BCheck.PointX = BCheck1.PointX = BCheck2.PointX = B.PointX;
            BCheck.PointY = BCheck1.PointY = BCheck2.PointY = B.PointY;
            CCheck.PointX = CCheck1.PointX = CCheck2.PointX = C.PointX;
            CCheck.PointY = CCheck1.PointY = CCheck2.PointY = C.PointY;
            DCheck.PointX = DCheck1.PointX = DCheck2.PointX = D.PointX;
            DCheck.PointY = DCheck1.PointY = DCheck2.PointY = D.PointY;
             

            double diag1 = 0;
            double diag11 = 0;

            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;


            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));
            diag11 = (diag11 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));

            ACheck.PointY = SetCurrentLineLength(DCheck, ACheck, diag1 + D_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(DCheck, ACheck, diag1 + D_Check_Line.Length).PointX;
            BCheck.PointY = SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointX;

            BCheck.PointY = SetCurrentLineLength(ACheck, BCheck, diag1 + A_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(ACheck, BCheck, diag1 + A_Check_Line.Length).PointX;
            CCheck.PointY = SetCurrentLineLength(DCheck, CCheck, diag11 + C_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(DCheck, CCheck, diag11 + C_Check_Line.Length).PointX;

            CCheck.PointY = SetCurrentLineLength(BCheck, CCheck, diag1 + B_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(BCheck, CCheck, diag1 + B_Check_Line.Length).PointX;
            DCheck.PointY = SetCurrentLineLength(ACheck, DCheck, diag11 + D_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(ACheck, DCheck, diag11 + D_Check_Line.Length).PointX;

            DCheck.PointY = SetCurrentLineLength(CCheck, DCheck, diag1 + C_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(CCheck, DCheck, diag1 + C_Check_Line.Length).PointX;
            ACheck.PointY = SetCurrentLineLength(BCheck, ACheck, diag11 + A_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(BCheck, ACheck, diag11 + A_Check_Line.Length).PointX;

           




            if (IsToothVector == true)
            {
                using (Pen penCut = new Pen(Color.Red, ThiсknessArgument))
                {
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(ACheck, BCheck, CCheck, SetB_radius /*+ _CheckCut1*/));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(BCheck, CCheck, DCheck, SetC_radius /*+ _CheckCut1*/));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(CCheck, DCheck, ACheck, SetD_radius /*+ _CheckCut1*/));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(DCheck, ACheck, BCheck, SetA_radius /*+ _CheckCut1*/));
                    graphicsShape.DrawLine(penCut, ACheck2, BCheck1);
                    graphicsShape.DrawLine(penCut, BCheck2, CCheck2);
                    graphicsShape.DrawLine(penCut, CCheck1, DCheck2);
                    graphicsShape.DrawLine(penCut, DCheck1, ACheck1);
                    IsToothVector = true;
                }
            }
            else
            {
                double r1 = 0;
                double r2 = 0;
                double r3 = 0;
                double r4 = 0;
                r1 = ((SetB_radius + _CheckCut1) < 0) ? 1 : SetB_radius + _CheckCut1;
                r2 = ((SetC_radius + _CheckCut1) < 0) ? 1 : SetC_radius + _CheckCut1;
                r3 = ((SetD_radius + _CheckCut1) < 0) ? 1 : SetD_radius + _CheckCut1;
                r4 = ((SetA_radius + _CheckCut1) < 0) ? 1 : SetA_radius + _CheckCut1;
                using (Pen penCut = new Pen(Color.Red, ThiсknessArgument / 2))
                {
                    penCut.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(ACheck, BCheck, CCheck, SetB_radius));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(BCheck, CCheck, DCheck, SetC_radius));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(CCheck, DCheck, ACheck, SetD_radius));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(DCheck, ACheck, BCheck, SetA_radius));
                    graphicsShape.DrawLine(penCut, ACheck2, BCheck1);
                    graphicsShape.DrawLine(penCut, BCheck2, CCheck2);
                    graphicsShape.DrawLine(penCut, CCheck1, DCheck2);
                    graphicsShape.DrawLine(penCut, DCheck1, ACheck1);
                    IsToothVector = false;
                }
            }
            GetExtremumPoints();
        }
        protected override void CreatingAdvancedPoints(ShapePoint secondPoint, RectangleF rectPoint, PointF a, PointF b)
        {
            base.CreatingAdvancedPoints(secondPoint, rectPoint, a, b);
            if (secondPoint == ACheck)
            {
                ACheck1 = b;
                ACheck2 = a;
                ArF = rectPoint;
            }
            if (secondPoint == BCheck)
            {
                BCheck1 = b;
                BCheck2 = a;
                BrF = rectPoint;
            }
            if (secondPoint == CCheck)
            {
                CCheck1 = a;
                CCheck2 = b;
                CrF = rectPoint;
            }

            if (secondPoint == DCheck)
            {
                DCheck1 = a;
                DCheck2 = b;
                DrF = rectPoint;
            }

        }
        public override bool CheckValidSize()
        {

            var value1 = (IsToothVector == true) ? _CheckCut1 : 0;
            var width = _SetL + _SetB4 + _SetB2 + value1 * 2;
            var height = _SetH + _SetB1 + _SetB3 + value1 * 2;
            double d = SetH / 2;
            double d1 = SetL / 2;
            if (_SetH < 0 || _SetH1 < 0 || _SetL < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0 || _SetB4 < 0)
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

            else if (_SetRadius > 0 && (SetH < SetL) && (_SetRadius > SetL / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R не может быть больше L/2");
            }
            else if (_SetRadius > 0 && (SetL < SetH) && (_SetRadius > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R не может быть больше H/2");
            }
            else if (_SetRadius > 0 && (SetL == SetH) && (_SetRadius > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R не может быть больше половины длины стороны");
            }
            else if (_SetRadius1 > 0 && (SetH < SetL) && (_SetRadius1 > SetL / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R1 не может быть больше L/2");
            }
            else if (_SetRadius1 > 0 && (SetL < SetH) && (_SetRadius1 > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R1 не может быть больше H/2");
            }
            else if (_SetRadius1 > 0 && (SetL == SetH) && (_SetRadius1 > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R не может быть больше половины длины стороны");
            }



            else if (_SetRadius2 > 0 && (SetH < SetL) && (_SetRadius2 > SetL / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R2 не может быть больше L/2");
            }
            else if (_SetRadius2 > 0 && (SetL < SetH) && (_SetRadius2 > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R2 не может быть больше H/2");
            }
            else if (_SetRadius2 > 0 && (SetL == SetH) && (_SetRadius2 > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R2 не может быть больше половины длины стороны");
            }


            else if (_SetRadius3 > 0 && (SetH < SetL) && (_SetRadius3 > SetL / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R3 не может быть больше L/2");
            }
            else if (_SetRadius3 > 0 && (SetL < SetH) && (_SetRadius3 > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R3 не может быть больше H/2");
            }
            else if (_SetRadius3 > 0 && (SetL == SetH) && (_SetRadius3 > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R3 не может быть больше половины длины стороны");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius2");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius3");
              
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRaduis_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRaduis1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRaduis2_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRaduis3_t");
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