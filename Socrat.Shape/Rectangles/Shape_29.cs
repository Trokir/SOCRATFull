using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;

namespace Socrat.Shape.Rectangles
{
    sealed class Shape_29 : Rectangular
    {
        private ShapePoint ACheck1 { get; set; }
        private ShapePoint ACheck2 { get; set; }
        private ShapePoint BCheck1 { get; set; }
        private ShapePoint BCheck2 { get; set; }
        private ShapePoint CCheck1 { get; set; }
        private ShapePoint CCheck2 { get; set; }
        private ShapePoint DCheck1 { get; set; }
        private ShapePoint DCheck2 { get; set; }
        public Shape_29(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
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
                return Math.Round((Math.PI * Math.Pow(SetRadius, 2)) / 1000000, 3);
            }
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
        public override double Perimeter
        {
            get
            {
                return Math.Round((Math.PI * SetRadius * 2) / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get
            {
                return Math.Round((Math.PI * (SetRadius + CheckCut1) * 2) / 1000, 3);
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
            GetExtremumPoints();
            AllowanceProcessing();
        }
        private void MoveLines()
        {
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                MoveBorderTop(X_Base, Y_Base, SetB1);
            }
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
        protected override PointF[] GetBasePoints() { return new PointF[] { A, B, C, D }; }
       
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

                var b1s = GetNewCustomPoint(SetPointCurrentValueX(C) + 20 * LineBoundArgument, SetPointCurrentValueY(C));
                var b1e = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b1s, b1e);
                Line b1h = GetNewLine(b1s, b1e);
                ShapePoint b1scenter = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY + b1h.Length / 2);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1scenter, sf);

                var brs = GetNewCustomPoint(SetPointCurrentValueX(C) + 20 * LineBoundArgument, SetPointCurrentValueY(C));
                var bre = (IsToothVector == true) ? GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, CCheck2.PointY) :
                     GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, C2.PointY);
                graphicsShape.DrawLine(pen, brs, bre);
                Line brh = GetNewLine(brs, bre);
                ShapePoint brscenter = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(C) + brh.Length / 2);
                graphicsShape.DrawString("R=" + SetCurrentSize(SetRadius), drawFontBold, Brushes.Black, brscenter, sf);


                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("29", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    graphicsShape.DrawLine(pens, b1e, Y_Base);
                    if (IsToothVector == true)
                    {
                        graphicsShape.DrawLine(pens, b1s, BCheck1);
                    }
                    else { graphicsShape.DrawLine(pens, b1s, B1); }
                    graphicsShape.DrawLine(pens, bre, CCheck2);
                }
            }
            #endregion
        }
        public override double SetRadius { get => _SetRadius = (_SetRadius == 0) ? SetB_radius : _SetRadius; set => base.SetRadius = value; }
        public override double SetRadius_t { get => SetRadius + CheckCut1; }
        protected override void SetRadiusValue()
        {
            base.SetRadiusValue();
            D.PointY = A.PointY;
            D.PointX = SetCurrentLineLength(A, D, SetRadius * 2).PointX;
            D.PointY = SetCurrentLineLength(A, D, SetRadius * 2).PointY;
            B.PointX = (D.PointX - A.PointX) * Math.Cos(-1.5708) - (D.PointY - A.PointY) * Math.Sin(-1.5708) + A.PointX;
            B.PointY = (D.PointX - A.PointX) * Math.Sin(-1.5708) + (D.PointY - A.PointY) * Math.Cos(-1.5708) + A.PointY;
            C.PointX = (A.PointX - B.PointX) * Math.Cos(-1.5708) - (A.PointY - B.PointY) * Math.Sin(-1.5708) + B.PointX;
            C.PointY = (A.PointX - B.PointX) * Math.Sin(-1.5708) + (A.PointY - B.PointY) * Math.Cos(-1.5708) + B.PointY;
            SetA_radius = (float)_SetRadius;
            SetB_radius = (float)_SetRadius;
            SetC_radius = (float)_SetRadius;
            SetD_radius = (float)_SetRadius;
            var Xdiff = B.PointX - 150;
            var yDiff = B.PointY - 150;
            Move(-Xdiff, -yDiff);
            ValidValue = false;
        }
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
                using (Pen penCut = new Pen(Color.Red, ThiсknessArgument / 2))
                {
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(ACheck, BCheck, CCheck, SetB_radius + _CheckCut1));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(BCheck, CCheck, DCheck, SetC_radius + _CheckCut1));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(CCheck, DCheck, ACheck, SetD_radius + _CheckCut1));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(DCheck, ACheck, BCheck, SetA_radius + _CheckCut1));
                    graphicsShape.DrawLine(penCut, ACheck1, BCheck2);
                    graphicsShape.DrawLine(penCut, BCheck1, CCheck1);
                    graphicsShape.DrawLine(penCut, CCheck2, DCheck1);
                    graphicsShape.DrawLine(penCut, DCheck2, ACheck2);
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
            var width = _SetRadius * 2 + _SetB1 + value1 * 2;
            var height = width;

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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius");

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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius_t");
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
