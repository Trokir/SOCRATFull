using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;

namespace Socrat.Shape.Rectangles
{
    sealed class Shape_55 : Rectangular
    {
        private ShapePoint ACheck1 { get; set; }
        private ShapePoint ACheck2 { get; set; }
        private ShapePoint BCheck1 { get; set; }
        private ShapePoint BCheck2 { get; set; }
        private ShapePoint CCheck1 { get; set; }
        private ShapePoint CCheck2 { get; set; }
        private ShapePoint DCheck1 { get; set; }
        private ShapePoint DCheck2 { get; set; }
        public Shape_55(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
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
        public override double TrueArea
        {
            get
            {
                E_line = GetNewLine(ACheck, CCheck);
                F_line = GetNewLine(BCheck, DCheck);
                Line ura = GetNewLine(CCheck1, CCheck);
                Line urb = GetNewLine(CCheck2, CCheck);
                Line urc = GetNewLine(CCheck1, CCheck2);
                double AAngle = (CalculateAngle(BCheck, CCheck, DCheck) <= 90 ? CalculateAngle(BCheck, CCheck, DCheck) : 180 - CalculateAngle(BCheck, CCheck, DCheck)) / 180;
                double urTriangle = Math.Round(Math.Sqrt(((ura.Length + urb.Length + urc.Length) / 2) *
                    (((ura.Length + urb.Length + urc.Length) / 2) - ura.Length) *
                    (((ura.Length + urb.Length + urc.Length) / 2) - urb.Length) *
                    (((ura.Length + urb.Length + urc.Length) / 2) - urc.Length)), 2) -
                     ((Math.Pow(SetC_radius, 2) / 2) * (Math.PI * AAngle * Math.PI / 180 - Math.Sin(AAngle * Math.PI / 180)));


                Line ula = GetNewLine(BCheck2, BCheck);
                Line ulb = GetNewLine(BCheck1, BCheck);
                Line ulc = GetNewLine(BCheck1, BCheck2);
                double BAngle = (CalculateAngle(ACheck, BCheck, CCheck) <= 90 ? CalculateAngle(A, B, C) : 180 - CalculateAngle(ACheck, BCheck, CCheck)) / 180;
                double ulTriangle = Math.Round(Math.Sqrt(((ula.Length + ulb.Length + ulc.Length) / 2) *
                   (((ula.Length + ulb.Length + ulc.Length) / 2) - ula.Length) *
                   (((ula.Length + ulb.Length + ulc.Length) / 2) - ulb.Length) *
                   (((ula.Length + ulb.Length + ulc.Length) / 2) - ulc.Length)), 2) -
                   (Math.Pow(SetB_radius, 2) / 2) * (Math.PI * BAngle * Math.PI / 180 - Math.Sin(BAngle * Math.PI / 180));



                Line lla = GetNewLine(ACheck2, ACheck);
                Line llb = GetNewLine(ACheck1, ACheck);
                Line llc = GetNewLine(ACheck1, ACheck2);
                double AAnglle = (CalculateAngle(DCheck, ACheck, BCheck) <= 90 ? CalculateAngle(DCheck, ACheck, BCheck) : 180 - CalculateAngle(DCheck, ACheck, BCheck)) / 180;
                double llTriangle = Math.Round(Math.Sqrt(((lla.Length + llb.Length + llc.Length) / 2) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - lla.Length) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - llb.Length) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - llc.Length)), 2) -
                  (Math.Pow(SetA_radius, 2) / 2) * (Math.PI * AAnglle * Math.PI / 180 - Math.Sin(AAnglle * Math.PI / 180));



                Line lra = GetNewLine(DCheck2, DCheck);
                Line lrb = GetNewLine(DCheck1, DCheck);
                Line lrc = GetNewLine(DCheck1, DCheck2);
                double DAngle = (CalculateAngle(CCheck, DCheck, ACheck) <= 90 ? CalculateAngle(CCheck, DCheck, ACheck) : 180 - CalculateAngle(CCheck, DCheck, ACheck)) / 180;
                double lrTriangle = Math.Round(Math.Sqrt(((lra.Length + lrb.Length + lrc.Length) / 2) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lra.Length) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lrb.Length) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lrc.Length)), 2) -
                 (Math.Pow(SetD_radius, 2) / 2) * (Math.PI * DAngle * Math.PI / 180 - Math.Sin(DAngle * Math.PI / 180));
                double baseSquare = 0.5 * Math.Abs((ACheck.PointX * BCheck.PointY + BCheck.PointX * CCheck.PointY + CCheck.PointX * DCheck.PointY
                    + DCheck.PointX * ACheck.PointY) - (BCheck.PointX * ACheck.PointY + CCheck.PointX * BCheck.PointY + DCheck.PointX * CCheck.PointY + ACheck.PointX * DCheck.PointY));
                return Math.Round((baseSquare - Math.Abs(ulTriangle) - Math.Abs(urTriangle) - Math.Abs(llTriangle) - Math.Abs(lrTriangle)) / 1000000, 3);
            }
        }
        public override double Perimeter_t
        {
            get
            {
                double upperLeftArc = SetB_radius * Math.PI * (CalculateAngle(A, B, C) <= 90 ? CalculateAngle(A, B, C) : 180 - CalculateAngle(A, B, C)) / 180;
                double upperRightArc = SetC_radius * Math.PI * (CalculateAngle(B, C, D) <= 90 ? CalculateAngle(B, C, D) : 180 - CalculateAngle(B, C, D)) / 180;
                double lowerLeftArc = SetA_radius * Math.PI * (CalculateAngle(D, A, B) <= 90 ? CalculateAngle(D, A, B) : 180 - CalculateAngle(D, A, B)) / 180;
                double lowerRighttArc = SetD_radius * Math.PI * (CalculateAngle(C, D, A) <= 90 ? CalculateAngle(C, D, A) : 180 - CalculateAngle(C, D, A)) / 180;
                Line a = GetNewLine(ACheck1, BCheck2);
                Line b = GetNewLine(BCheck1, CCheck1);
                Line c = GetNewLine(CCheck2, DCheck1);
                Line d = GetNewLine(DCheck2, ACheck2);
                return Math.Round((upperLeftArc + upperRightArc + lowerLeftArc + lowerRighttArc + a.Length + b.Length + c.Length + d.Length) / 1000, 3);
            }
        }
        protected override void DrawMainLines()
        {
            if (IsToothVector == true)
            {
                using (var pensil = new Pen(Color.Red, ThiсknessArgument / 2))
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
                    graphicsShape.DrawLine(pen1, A1, B2);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument / 2))
                {
                    pen2.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen2, B1, C1);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument / 2))
                {
                    pen3.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen3, C2, D1);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument / 2))
                {
                    pen4.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen4, D2, A2);
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
                    graphicsShape.DrawLine(pen1, A1, B2);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen2, B1, C1);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen3, C2, D1);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen4, D2, A2);
                }
                IsToothVector = false;
            }
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(A1, B2);
                myPath.AddPath(MakeRoundCorner(A, B, C, SetB_radius), true);
                myPath.AddLine(B1, C1);
                myPath.AddPath(MakeRoundCorner(B, C, D, SetC_radius), true);
                myPath.AddLine(C2, D1);
                myPath.AddPath(MakeRoundCorner(C, D, A, SetD_radius), true);
                myPath.AddLine(D2, A2);
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
                
                MoveBorderLeft(W_Base, X_Base, SetB4);
                MoveBorderTop(X_Base, Y_Base, SetB3);
                MoveBorderRight(Y_Base, Z_Base, SetB2);
                MoveBorderBottom(W_Base, Z_Base, SetB1);
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
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 20 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint b3s = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint b3e = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY);
                Line lb3 = GetNewLine(b3s, b3e);
                ShapePoint b3center = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY + lb3.Length / 2);
                graphicsShape.DrawLine(pen, b3s, b3e);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b3center, sf);

                ShapePoint bs2 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(D));
                ShapePoint be2 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY);
                Line bl2 = GetNewLine(bs2, be2);
                ShapePoint b12center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY - (bl2.Length / 2));
                graphicsShape.DrawLine(pen, bs2, be2);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b12center, sf);

                ShapePoint b12s11 = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b12e11 = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b12s11, b12e11);
                Line b221h = GetNewLine(b12s11, b12e11);
                ShapePoint b221scenter = GetNewCustomPoint(W_Base.PointX + b221h.Length / 2, W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawString("B4=" + SetB4, drawFontBold, Brushes.Black, b221scenter, sf);


                ShapePoint b12s1 = GetNewCustomPoint(SetPointCurrentValueX(D), Z_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b12e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b12s1, b12e1);
                Line b22h = GetNewLine(b12s1, b12e1);
                ShapePoint b22scenter = GetNewCustomPoint(Z_Base.PointX - b22h.Length / 2, Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b22scenter, sf);


                ShapePoint bsh = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(D));
                ShapePoint beh = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(C));
                Line blh = GetNewLine(bsh, beh);
                ShapePoint bhcenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY - (blh.Length / 2));
                graphicsShape.DrawLine(pen, bsh, beh);
                graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, bhcenter, sf);

                graphicsShape.FillEllipse(Brushes.Black, ArF);
                graphicsShape.FillEllipse(Brushes.Black, BrF);
                graphicsShape.FillEllipse(Brushes.Black, CrF);
                graphicsShape.FillEllipse(Brushes.Black, DrF);
                graphicsShape.DrawString("R=" + SetA_radius, drawFontBold, Brushes.Green, ArF.Location);
                graphicsShape.DrawString("R1=" + SetB_radius, drawFontBold, Brushes.Green, BrF.Location);
                graphicsShape.DrawString("R2=" + SetC_radius, drawFontBold, Brushes.Green, CrF.Location, sf);
                graphicsShape.DrawString("R3=" + SetD_radius, drawFontBold, Brushes.Green, DrF.Location, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiсknessArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("55", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {


                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, b12e1, Z_Base);
                    graphicsShape.DrawLine(pens, b12e11, W_Base);
                    graphicsShape.DrawLine(pens, be2, Z_Base);
                    graphicsShape.DrawLine(pens, b3e, Y_Base);
                    if (IsToothVector == true)
                    {
                        graphicsShape.DrawLine(pens, b12s1, DCheck1);
                        graphicsShape.DrawLine(pens, b12s11, ACheck1);
                        graphicsShape.DrawLine(pens, b3s, CCheck1);
                        graphicsShape.DrawLine(pens, bs2, DCheck2);
                    }
                    else
                    {
                        graphicsShape.DrawLine(pens, b12s1, D1);
                        graphicsShape.DrawLine(pens, b12s11, A1);
                        graphicsShape.DrawLine(pens, b3s, C1);
                        graphicsShape.DrawLine(pens, bs2, D2);
                    }
                }
            }
            #endregion
        }
        public override RectangleF GetShapeBorders()
        {
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(A1, B2);
                myPath.AddPath(MakeRoundCorner(A, B, C, SetB_radius), true);
                myPath.AddLine(B1, C1);
                myPath.AddPath(MakeRoundCorner(B, C, D, SetC_radius), true);
                myPath.AddLine(C2, D1);
                myPath.AddPath(MakeRoundCorner(C, D, A, SetD_radius), true);
                myPath.AddLine(D2, A2);
                myPath.AddPath(MakeRoundCorner(D, A, B, SetA_radius), true);
                Region myRegion = new Region(myPath);
                RectangleF boundsRect = myRegion.GetBounds(graphicsShape);
                graphicsShape.DrawRectangle(Pens.Blue, new Rectangle((int)boundsRect.X,
                 (int)boundsRect.Y, (int)boundsRect.Width, (int)boundsRect.Height));
                // graphicsShape.SetClip(myRegion, CombineMode.Replace);
                return boundsRect;
            }
        }
        protected override GraphicsPath GetShapeShprosBorders()
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(A1, B2);
            myPath.AddPath(MakeRoundCorner(A, B, C, SetB_radius), true);
            myPath.AddLine(B1, C1);
            myPath.AddPath(MakeRoundCorner(B, C, D, SetC_radius), true);
            myPath.AddLine(C2, D1);
            myPath.AddPath(MakeRoundCorner(C, D, A, SetD_radius), true);
            myPath.AddLine(D2, A2);
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
            var p = A.PointX;
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
        /// <summary>
        /// Allowances the processing.
        /// </summary>
        protected override void AllowanceProcessing()
        {
            ACheck.PointX = A.PointX;
            ACheck.PointY = A.PointY;
            BCheck.PointX = B.PointX;
            BCheck.PointY = B.PointY;
            CCheck.PointX = C.PointX;
            CCheck.PointY = C.PointY;
            DCheck.PointX = D.PointX;
            DCheck.PointY = D.PointY;

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
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(ACheck, BCheck, CCheck, SetB_radius + _CheckCut1));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(BCheck, CCheck, DCheck, SetC_radius + _CheckCut1));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(CCheck, DCheck, ACheck, SetD_radius + _CheckCut1));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(DCheck, ACheck, BCheck, SetA_radius + _CheckCut1));
                    graphicsShape.DrawLine(penCut, ACheck1, BCheck2);
                    graphicsShape.DrawLine(penCut, BCheck1, CCheck1);
                    graphicsShape.DrawLine(penCut, CCheck2, DCheck1);
                    graphicsShape.DrawLine(penCut, DCheck2, ACheck2);
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
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(ACheck, BCheck, CCheck, r1));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(BCheck, CCheck, DCheck, r2));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(CCheck, DCheck, ACheck, r3));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(DCheck, ACheck, BCheck, r4));
                    graphicsShape.DrawLine(penCut, ACheck1, BCheck2);
                    graphicsShape.DrawLine(penCut, BCheck1, CCheck1);
                    graphicsShape.DrawLine(penCut, CCheck2, DCheck1);
                    graphicsShape.DrawLine(penCut, DCheck2, ACheck2);
                    IsToothVector = false;
                }
            }
            GetExtremumPoints();
        }
        /// <summary>
        /// Gets the ePointXtremum points.
        /// </summary>
        /// <returns></returns>
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB3");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB4");
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