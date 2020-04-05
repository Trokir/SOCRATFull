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

namespace Socrat.Shape.Octagons
{
     sealed class Shape_24 : Octagon
    {
        public Shape_24(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
            var Xdiff = B.PointX -150;
            var yDiff = D.PointY - 150;
            Move(-Xdiff, -yDiff);
       
        }
        public override double Perimeter
        {
            get
            {
                return Math.Round((A_line.Length + B_line.Length + C_line.Length +
                    D_line.Length + E_line.Length + F_line.Length + G_line.Length + H_line.Length) / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get
            {
                return Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length + D_Check_Line.Length +
                    E_Check_Line.Length + F_Check_Line.Length + G_Check_Line.Length + H_Check_Line.Length) / 1000, 3);
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
                    graphicsShape.DrawLine(pen7, G, H);
                }
                using (pen8 = new Pen(SelectMainLineColor8(), ThiсknessArgument / 2))
                {
                    pen8.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen8, H, A);
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
                    graphicsShape.DrawLine(pen7, G, H);
                }
                using (pen8 = new Pen(SelectMainLineColor8(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen8, H, A);
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

                MoveBorderRight(Z_Base, Y_Base, SetB1);
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB1);
                MoveBorderBottom(W_Base, Z_Base, SetB1);
            }
        }
      
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D, E, F, G, H };
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
                //B1 dl
                ShapePoint b1s = GetNewCustomPoint(W_Base.PointX + SetB1, W_Base.PointY + 40 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 40 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                //B1 dr
                ShapePoint b1s1 = GetNewCustomPoint(Z_Base.PointX - SetB1, W_Base.PointY + 40 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 40 * LineBoundArgument);
                Line lb11 = GetNewLine(b1s1, b1e1);
                ShapePoint b11center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), Z_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b11center, sf);

                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 40 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(H), W_Base.PointY + 40 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);
                //B1 ru
                ShapePoint b1s2 = GetNewCustomPoint(Y_Base.PointX + 15 * LineBoundArgument, X_Base.PointY + SetB1);
                ShapePoint b1e2 = GetNewCustomPoint(Y_Base.PointX +15 * LineBoundArgument, X_Base.PointY);
                Line lb12 = GetNewLine(b1s2, b1e2);
                ShapePoint b12center = GetNewCustomPoint(Y_Base.PointX+35 * LineBoundArgument, X_Base.PointY + (lb1.Length / 2));
                graphicsShape.DrawLine(pen, b1s2, b1e2);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b12center, sf);

                //B1 rd
                ShapePoint b1s3 = GetNewCustomPoint(Z_Base.PointX +15 * LineBoundArgument, W_Base.PointY - SetB1);
                ShapePoint b1e3 = GetNewCustomPoint(Z_Base.PointX +15 * LineBoundArgument, W_Base.PointY);
                Line lb13 = GetNewLine(b1s3, b1e3);
                ShapePoint b13center = GetNewCustomPoint(Z_Base.PointX +35 * LineBoundArgument, W_Base.PointY - (lb1.Length / 2));
                graphicsShape.DrawLine(pen, b1s3, b1e3);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b13center, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX + E.PointX + F.PointX + G.PointX + H.PointX) / 8), ((A.PointY + B.PointY + C.PointY + D.PointY + E.PointY + F.PointY + G.PointY + H.PointY) / 8));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    graphicsShape.DrawString("24", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    ShapePoint wer =  GetNewCustomPoint( W_Base.PointX, SetPointCurrentValueY(A));
                    ShapePoint wer1 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(H));
                    ShapePoint wer2 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(D));
                    ShapePoint wer3 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(E));
                    ShapePoint wer4 = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY);
                    ShapePoint wer5 = GetNewCustomPoint(SetPointCurrentValueX(C), X_Base.PointY);
                    ShapePoint wer6 = GetNewCustomPoint(SetPointCurrentValueX(F), X_Base.PointY);
                    ShapePoint wer7 = GetNewCustomPoint(SetPointCurrentValueX(G), W_Base.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer,  SetPointCurrentType(A));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(H));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(E));
                        graphicsShape.DrawLine(pen1, wer4, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer5, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer6, SetPointCurrentType(F));
                        graphicsShape.DrawLine(pen1, wer7, SetPointCurrentType(G));
                        graphicsShape.DrawLine(pens, ls,   SetPointCurrentType(A));
                        graphicsShape.DrawLine(pens, le,   SetPointCurrentType(H));
                        graphicsShape.DrawLine(pens, b1e, W_Base);
                        graphicsShape.DrawLine(pens, b1s, wer4);
                        graphicsShape.DrawLine(pens, b1e1, Z_Base);
                        graphicsShape.DrawLine(pens, b1s1, wer7);
                        graphicsShape.DrawLine(pens, b1e2, Y_Base);
                        graphicsShape.DrawLine(pens, b1s2, wer3);
                        graphicsShape.DrawLine(pens, b1e3, Z_Base);
                        graphicsShape.DrawLine(pens, b1s3, wer1);
                    }
                  

                }
                #endregion
            }
        }
        public override double SetL { get => Math.Round(H_line.Length, 0); set => base.SetL = value; }
        public override double SetL_t
        {
            get => Math.Round(H_line.Length, 0);
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            var Xp = GetNewPoint();
            var Yp = GetNewPoint();
            TempPoint.PointX = SetCurrentLineLength(A, H, _SetL).PointX;
            TempPoint.PointY = SetCurrentLineLength(A, H, _SetL).PointY;
            H.PointX = TempPoint.PointX;
            H.PointY = A.PointY;
            Xp.PointX = B.PointX;
            Yp.PointX = B.PointY;
            Yp.PointX = D.PointX;
            Yp.PointY = D.PointY;
            B.PointX = (H.PointX - A.PointX) * Math.Cos(-2.35619) - (H.PointY - A.PointY) * Math.Sin(-2.35619) + A.PointX;
            B.PointY = (H.PointX - A.PointX) * Math.Sin(-2.35619) + (H.PointY - A.PointY) * Math.Cos(-2.35619) + A.PointY;
            C.PointX = (A.PointX - B.PointX) * Math.Cos(-2.35619) - (A.PointY - B.PointY) * Math.Sin(-2.35619) + B.PointX;
            C.PointY = (A.PointX - B.PointX) * Math.Sin(-2.35619) + (A.PointY - B.PointY) * Math.Cos(-2.35619) + B.PointY;
            D.PointX = (B.PointX - C.PointX) * Math.Cos(-2.35619) - (B.PointY - C.PointY) * Math.Sin(-2.35619) + C.PointX;
            D.PointY = (B.PointX - C.PointX) * Math.Sin(-2.35619) + (B.PointY - C.PointY) * Math.Cos(-2.35619) + C.PointY;
            E.PointX = (C.PointX - D.PointX) * Math.Cos(-2.35619) - (C.PointY - D.PointY) * Math.Sin(-2.35619) + D.PointX;
            E.PointY = (C.PointX - D.PointX) * Math.Sin(-2.35619) + (C.PointY - D.PointY) * Math.Cos(-2.35619) + D.PointY;
            F.PointX = (D.PointX - E.PointX) * Math.Cos(-2.35619) - (D.PointY - E.PointY) * Math.Sin(-2.35619) + E.PointX;
            F.PointY = (D.PointX - E.PointX) * Math.Sin(-2.35619) + (D.PointY - E.PointY) * Math.Cos(-2.35619) + E.PointY;
            G.PointX = (E.PointX - F.PointX) * Math.Cos(-2.35619) - (E.PointY - F.PointY) * Math.Sin(-2.35619) + F.PointX;
            G.PointY = (E.PointX - F.PointX) * Math.Sin(-2.35619) + (E.PointY - F.PointY) * Math.Cos(-2.35619) + F.PointY;
            var Xdiff = Xp.PointX - B.PointX;
            var yDiff = Yp.PointY - D.PointY;
            Move(Xdiff,yDiff);
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, B, C, D, E, F, G, H, ACheck, BCheck, CCheck, DCheck, ECheck, FCheck, GCheck, HCheck };

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
            var value4 = (IsToothVector==true) ? _CheckCut4 : 0;
            var value5 = (IsToothVector==true) ? _CheckCut5 : 0;
            var value6 = (IsToothVector==true) ? _CheckCut6 : 0;
            var value7 = (IsToothVector==true) ? _CheckCut7 : 0;
            var value8 = (IsToothVector == true) ? _CheckCut8 : 0;

            var width = _SetL*2 + _SetB1 * 2 + value2 + value6;
            var height = width;

            if (_SetH < 0 || _SetH1 < 0 || _SetL < 0 || _SetL1 < 0 || _SetB1 < 0 || _SetB2 < 0)
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
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut8");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsCuttingGlass");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsBendingDistanceFrame");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsFormSealing");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsGasFillingForm");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsVertBendingMashineRobot");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsVertMashineEdgeMaking");
                e.Properties = filteredCollection;
            }
        }
    }
}
