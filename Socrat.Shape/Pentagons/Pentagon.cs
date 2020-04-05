using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Socrat.Shape
{
    /// <summary>
    /// Пятиугольник
    /// </summary>
    public partial class Pentagon : BaseShape
    {


        public Pentagon(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
            ShapePoint[] points = new ShapePoint[] { A = GetNewPoint(), B = GetNewPoint(), C = GetNewPoint(), D = GetNewPoint(), E = GetNewPoint() };
        //    SelectedSides = new int[] { 0, 0, 0, 0,0 };
            try
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].PointX = (float)ShapePoints[i].PointX;
                    points[i].PointY = (float)ShapePoints[i].PointY;
                    points[i].PointRadius = ShapePoints[i].PointRadius ?? 0;
                }
            }
            catch (Exception)
            {

                //  throw new EPointXception("Нет данных");
            }
            A_line = new Line(A, B);
            B_line = new Line(B, C);
            C_line = new Line(C, D);
            D_line = new Line(D, E);
            E_line = new Line(A, E);
            A_Check_Line = GetNewLine(ACheck, BCheck);
            B_Check_Line = GetNewLine(BCheck, CCheck);
            C_Check_Line = GetNewLine(CCheck, DCheck);
            D_Check_Line = GetNewLine(DCheck, ECheck);
            E_Check_Line = GetNewLine(ECheck, ACheck);
            SetA_radius = A.PointRadius??0;
            SetB_radius = B.PointRadius??0;
            SetC_radius = C.PointRadius??0;
            SetD_radius = D.PointRadius??0;
            SetE_radius = E.PointRadius??0;
            GetCurrentParameters(currentShapeParametersList);

        }
        //protected override double CalculateLowerLeftAngleForShpros()
        //{
        //    ShapePoint firstPoint = E;
        //    ShapePoint secondPoint = A;
        //    ShapePoint thirdPoint = B;
        //    double angleBetween = 0;
        //    Vector vector1 = new Vector((thirdPoint.PointX - secondPoint.PointX), (thirdPoint.PointY - secondPoint.PointY));
        //    Vector vector2 = new Vector((firstPoint.PointX - secondPoint.PointX), (firstPoint.PointY - secondPoint.PointY));
        //    angleBetween = Math.Abs(Vector.AngleBetween(vector1, vector2));
        //    return Math.Round(angleBetween, 1);
        //}

        public override void SelectClickedSide(int xCoord, int yCoord, bool flag)
        {
            System.Drawing.Point point = new System.Drawing.Point(xCoord, yCoord);
            if (ThicknessPath(A, B).IsVisible(point))
            {
                if (flag) { ColorMarker1 = "rowCheckCut1"; SelectedSides.SetValue(1, 0); ClickedSelectSide = 1; SelectedSidesLength += A_line.Length; }
                else { ColorMarker1 = ""; SelectedSides.SetValue(0, 0); ClickedSelectSide = 0; SelectedSidesLength -= A_line.Length; }
            }
            if (ThicknessPath(B, C).IsVisible(point))
            {
                if (flag) { ColorMarker2 = "rowCheckCut2"; SelectedSides.SetValue(2, 1); ClickedSelectSide = 2; SelectedSidesLength += B_line.Length; }
                else { ColorMarker2 = ""; SelectedSides.SetValue(0, 1); ClickedSelectSide = 0; SelectedSidesLength -= B_line.Length; }
            }
            if (ThicknessPath(C, D).IsVisible(point))
            {
                if (flag) { ColorMarker3 = "rowCheckCut3"; SelectedSides.SetValue(3, 2); ClickedSelectSide = 3; SelectedSidesLength += C_line.Length; }
                else { ColorMarker3 = ""; SelectedSides.SetValue(0, 2); ClickedSelectSide = 0; SelectedSidesLength -= C_line.Length; }
            }
            if (ThicknessPath(D, E).IsVisible(point))
            {
                if (flag) { ColorMarker4 = "rowCheckCut4"; SelectedSides.SetValue(4, 3); ClickedSelectSide = 4; SelectedSidesLength += D_line.Length; }
                else { ColorMarker4 = ""; SelectedSides.SetValue(0, 3); ClickedSelectSide = 0; SelectedSidesLength -= D_line.Length; }
            }
            if (ThicknessPath(E, A).IsVisible(point))
            {
                if (flag) { ColorMarker5 = "rowCheckCut5"; SelectedSides.SetValue(5, 4); ClickedSelectSide = 5; SelectedSidesLength += E_line.Length; }
                else { ColorMarker5 = ""; SelectedSides.SetValue(0, 4); ClickedSelectSide = 0; SelectedSidesLength -= E_line.Length; }
            }
            else return;
        }

        public override void CalculateSelectedSideLength(List<int> sideNums)
        {
            SelectedSidesLength = 0;
            foreach (int sideNum in sideNums)
            {
                     if (sideNum == 1) { SelectedSidesLength += A_line.Length; }
                else if (sideNum == 2) { SelectedSidesLength += B_line.Length; }
                else if (sideNum == 3) { SelectedSidesLength += C_line.Length; }
                else if (sideNum == 4) { SelectedSidesLength += D_line.Length; }
                else if (sideNum == 5) { SelectedSidesLength += E_line.Length; }
            }
        }
        /// <summary>
        /// Return Pentagon perimeter
        /// </summary>
        public override double Perimeter
        {
            get
            {


                double AArc = SetA_radius * Math.PI * (CalculateAngle(E, A, B) <= 90 ? CalculateAngle(E, A, B) : 180 - CalculateAngle(E, A, B)) / 180;
                double BArc = SetB_radius * Math.PI * (CalculateAngle(A, B, C) <= 90 ? CalculateAngle(A, B, C) : 180 - CalculateAngle(A, B, C)) / 180;
                double CArc = SetC_radius * Math.PI * (CalculateAngle(B, C, D) <= 90 ? CalculateAngle(B, C, D) : 180 - CalculateAngle(B, C, D)) / 180;
                double DArc = SetD_radius * Math.PI * (CalculateAngle(C, D, E) <= 90 ? CalculateAngle(C, D, E) : 180 - CalculateAngle(C, D, E)) / 180;
                double EArc = SetE_radius * Math.PI * (CalculateAngle(D, E, A) <= 90 ? CalculateAngle(D, E, A) : 180 - CalculateAngle(D, E, A)) / 180;
                Line a = new Line(A1, B2);
                Line b = new Line(B1, C1);
                Line c = new Line(C2, D1);
                Line d = new Line(D2, E1);
                Line e = new Line(E2, A2);
                return Math.Round((AArc + BArc + CArc + DArc + EArc + a.Length + b.Length + c.Length + d.Length + e.Length) / 1000, 3);
            }
        }
        /// <summary>
        /// Return area
        /// </summary>
        public override double Area
        {
            get
            {
                G_line = new Line(A, C);
                F_line = new Line(B, D);

                Line Aa = new Line(A2, A);
                Line Ab = new Line(A1, A);
                Line Ac = new Line(A1, A2);
                double AAngle = (CalculateAngle(E, A, B) <= 90 ? CalculateAngle(E, A, B) : 180 - CalculateAngle(E, A, B)) / 180;
                double ATriangle = Math.Round(Math.Sqrt(((Aa.Length + Ab.Length + Ac.Length) / 2) *
                   (((Aa.Length + Ab.Length + Ac.Length) / 2) - Aa.Length) *
                   (((Aa.Length + Ab.Length + Ac.Length) / 2) - Ab.Length) *
                   (((Aa.Length + Ab.Length + Ac.Length) / 2) - Ac.Length)), 2) -
                  (Math.Pow(SetA_radius, 2) / 2) * (Math.PI * AAngle * Math.PI / 180 - Math.Sin(AAngle * Math.PI / 180));


                Line Ba = new Line(B2, B);
                Line Bb = new Line(B1, B);
                Line Bc = new Line(B1, B2);
                double BAngle = (CalculateAngle(A, B, C) <= 90 ? CalculateAngle(A, B, C) : 180 - CalculateAngle(A, B, C)) / 180;
                double BTriangle = Math.Round(Math.Sqrt(((Ba.Length + Bb.Length + Bc.Length) / 2) *
                   (((Ba.Length + Bb.Length + Bc.Length) / 2) - Ba.Length) *
                   (((Ba.Length + Bb.Length + Bc.Length) / 2) - Bb.Length) *
                   (((Ba.Length + Bb.Length + Bc.Length) / 2) - Bc.Length)), 2) -
                   (Math.Pow(SetB_radius, 2) / 2) * (Math.PI * BAngle * Math.PI / 180 - Math.Sin(BAngle * Math.PI / 180));




                Line Ca = new Line(C1, C);
                Line Cb = new Line(C2, C);
                Line Cc = new Line(C1, C2);
                double CAngle = (CalculateAngle(B, C, D) <= 90 ? CalculateAngle(B, C, D) : 180 - CalculateAngle(B, C, D)) / 180;
                double CTriangle = Math.Round(Math.Sqrt(((Ca.Length + Cb.Length + Cc.Length) / 2) *
                    (((Ca.Length + Cb.Length + Cc.Length) / 2) - Ca.Length) *
                    (((Ca.Length + Cb.Length + Cc.Length) / 2) - Cb.Length) *
                    (((Ca.Length + Cb.Length + Cc.Length) / 2) - Cc.Length)), 2) -
                     ((Math.Pow(SetC_radius, 2) / 2) * (Math.PI * CAngle * Math.PI / 180 -
                     Math.Sin(CAngle * Math.PI / 180)));



                Line Da = new Line(D2, D);
                Line Db = new Line(D1, D);
                Line Dc = new Line(D1, D2);
                double DAngle = (CalculateAngle(C, D, E) <= 90 ? CalculateAngle(C, D, E) : 180 - CalculateAngle(C, D, E)) / 180;
                double DTriangle = Math.Round(Math.Sqrt(((Da.Length + Db.Length + Dc.Length) / 2) *
                   (((Da.Length + Db.Length + Dc.Length) / 2) - Da.Length) *
                   (((Da.Length + Db.Length + Dc.Length) / 2) - Db.Length) *
                   (((Da.Length + Db.Length + Dc.Length) / 2) - Dc.Length)), 2) -
                 (Math.Pow(SetD_radius, 2) / 2) * (Math.PI * DAngle * Math.PI / 180 - Math.Sin(DAngle * Math.PI / 180));


                Line Ea = new Line(E2, E);
                Line Eb = new Line(E1, E);
                Line Ec = new Line(E1, E2);
                double EAngle = (CalculateAngle(D, E, A) <= 90 ? CalculateAngle(D, E, A) : 180 - CalculateAngle(D, E, A)) / 180;
                double ETriangle = Math.Round(Math.Sqrt(((Ea.Length + Eb.Length + Ec.Length) / 2) *
                   (((Ea.Length + Eb.Length + Ec.Length) / 2) - Ea.Length) *
                   (((Ea.Length + Eb.Length + Ec.Length) / 2) - Eb.Length) *
                   (((Ea.Length + Eb.Length + Ec.Length) / 2) - Ec.Length)), 2) -
                 (Math.Pow(SetE_radius, 2) / 2) * (Math.PI * EAngle * Math.PI / 180 - Math.Sin(EAngle * Math.PI / 180));

                double baseSquare = 0.5 * Math.Abs((A.PointX * B.PointY + B.PointX * C.PointY + C.PointX * D.PointY + D.PointX * E.PointY + E.PointX * A.PointY) - (B.PointX * A.PointY + C.PointX * B.PointY + D.PointX * C.PointY + E.PointX * D.PointY + A.PointX * E.PointY));
                return Math.Round((baseSquare - Math.Abs(ATriangle) - Math.Abs(BTriangle) - Math.Abs(CTriangle) - Math.Abs(DTriangle) - Math.Abs(ETriangle)) / 1000000,3);
            }
        }

        public override double TrueArea
        {
            get
            {

                double baseSquare = 0.5 * Math.Abs((ACheck.PointX * BCheck.PointY + BCheck.PointX * CCheck.PointY + CCheck.PointX * DCheck.PointY + DCheck.PointX * ECheck.PointY + ECheck.PointX * ACheck.PointY) -
                    (BCheck.PointX * ACheck.PointY + CCheck.PointX * BCheck.PointY + DCheck.PointX * CCheck.PointY + ECheck.PointX * DCheck.PointY + ACheck.PointX * ECheck.PointY));
                return Math.Round(baseSquare / 1000000,3);
            }
        }


        private double _SetWidthValue;
        private double _SetHeightValue;
        private double _SetResize_AB_SideValue;
        private double _SetResize_BC_SideValue;
        private double _SetResize_CD_SideValue;
        private double _SetResize_DE_SideValue;
        private double _SetResizeBottomSideValue;
        private bool _IsDrawPentagonByAngleValue;
        private bool _IsLeftSideVertical;
        private bool _IsRightSideVertical;
        private bool _IsTopLeftSideHorizontal;
        private bool _IsTopRightSideHorizontal;
        private bool _IsBothSidesHorizontal;
        private double _SetMove_C_Side_Value;
        private bool _IsBottomSideHorisontal;
        private double _SetRightDiffTopSide;
        private double _SetLeftDiffTopSide;
        private double _SetRightDiffTopSideMirrow;
        private double _SetLeftDiffTopSideMirrow;
        private double _SetResize_AB_DE_SideValue;
        private double _SetResize_BC_CD_SideValue;


        #region SetSizes
        /// <summary>
        /// Gets or sets the set d radius.
        /// </summary>
        /// <value>
        /// The set d radius.
        /// </value>
        [DisplayName("Радиус D")]
        [Category("Radius")]
        [Display(GroupName = "Скругления")]
        public float SetD_radius { get; set; }
        /// <summary>
        /// Gets or sets the set e radius.
        /// </summary>
        /// <value>
        /// The set d radius.
        /// </value>
        [DisplayName("Радиус E")]
        [Category("Radius")]
        [Display(GroupName = "Скругления")]
        public float SetE_radius { get; set; }

        /// <summary>
        /// Gets or sets the set width value.
        /// </summary>
        /// <value>
        /// The set height value.
        /// </value>
        [DisplayName("Габаритная ширина - L ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetWidthValue
        {
            get
            {
                Line n = new Line(D, B);
                return n.Length;
            }
            set
            {
                SetField(ref _SetWidthValue, value, () => SetWidthValue);
                CenterPoint.PointX = (B.PointX + D.PointX) / 2;
                CenterPoint.PointY = (B.PointY + D.PointY) / 2;

                TempPoint.PointX = CenterPoint.PointX + (D.PointX - CenterPoint.PointX) * (_SetWidthValue / 2 / Math.Sqrt(Math.Pow((D.PointX - CenterPoint.PointX), 2) + Math.Pow((D.PointY - CenterPoint.PointY), 2)));
                TempPoint.PointY = CenterPoint.PointY + (D.PointY - CenterPoint.PointY) * (_SetWidthValue / 2 / Math.Sqrt(Math.Pow((D.PointX - CenterPoint.PointX), 2) + Math.Pow((D.PointY - CenterPoint.PointY), 2)));
                D.PointX = TempPoint.PointX;
                D.PointY = TempPoint.PointY;
                TempPoint.PointX = CenterPoint.PointX + (B.PointX - CenterPoint.PointX) * (_SetWidthValue / 2 / Math.Sqrt(Math.Pow((B.PointX - CenterPoint.PointX), 2) + Math.Pow((B.PointY - CenterPoint.PointY), 2)));
                TempPoint.PointY = CenterPoint.PointY + (B.PointY - CenterPoint.PointY) * (_SetWidthValue / 2 / Math.Sqrt(Math.Pow((B.PointX - CenterPoint.PointX), 2) + Math.Pow((B.PointY - CenterPoint.PointY), 2)));
                B.PointX = TempPoint.PointX;
                B.PointY = TempPoint.PointY;
            }
        }



        /// <summary>
        /// Gets or sets the set height value.
        /// </summary>
        /// <value>
        /// The set height value.
        /// </value>
        /// 
        [DisplayName("Габаритная высота - H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]

        public double SetHeightValue
        {
            get
            {
                ShapePoint FP = new ShapePoint(C.PointX, A.PointY);
                Line n = new Line(C, FP);
                return n.Length;
            }
            set
            {
                SetField(ref _SetHeightValue, value, () => SetHeightValue);
                ShapePoint FP = new ShapePoint(C.PointX, A.PointY);
                Line n = new Line(C, FP);
                TempPoint.PointX = FP.PointX + (C.PointX - FP.PointX) * (_SetHeightValue / Math.Sqrt(Math.Pow((C.PointX - FP.PointX), 2) + Math.Pow((C.PointY - FP.PointY), 2)));
                TempPoint.PointY = FP.PointY + (C.PointY - FP.PointY) * (_SetHeightValue / Math.Sqrt(Math.Pow((C.PointX - FP.PointX), 2) + Math.Pow((C.PointY - FP.PointY), 2)));
                C.PointX = TempPoint.PointX;
                C.PointY = TempPoint.PointY;
            }
        }


        /// <summary>
        /// Gets or sets the set resize ab side value.
        /// </summary>
        /// <value>
        /// The set resize ab side value.
        /// </value>

        [DisplayName("СторонаAB  - H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResize_AB_SideValue
        {
            get { return A_line.Length; }
            set
            {
                SetField(ref _SetResize_AB_SideValue, value, () => SetResize_AB_SideValue);
                B.PointX = SetCurrentLineLength(A, B, _SetResize_AB_SideValue).PointX;
                B.PointY = SetCurrentLineLength(A, B, _SetResize_AB_SideValue).PointY;
            }
        }



        [DisplayName("Стороны AB и DE  - H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResize_AB_DE_SideValue
        {
            get { return A_line.Length; }
            set
            {
                SetField(ref _SetResize_AB_DE_SideValue, value, () => SetResize_AB_DE_SideValue);

                TempPoint.PointX = A.PointX + (B.PointX - A.PointX) * (_SetResize_AB_DE_SideValue / Math.Sqrt(Math.Pow((B.PointX - A.PointX), 2) + Math.Pow((B.PointY - A.PointY), 2)));
                TempPoint.PointY = A.PointY + (B.PointY - A.PointY) * (_SetResize_AB_DE_SideValue / Math.Sqrt(Math.Pow((B.PointX - A.PointX), 2) + Math.Pow((B.PointY - A.PointY), 2)));
                B.PointX = SetCurrentLineLength(A, B, _SetResize_AB_DE_SideValue).PointX;
                B.PointY = SetCurrentLineLength(A, B, _SetResize_AB_DE_SideValue).PointY;

                SetField(ref _SetResize_DE_SideValue, value, () => SetResize_DE_SideValue);
                TempPoint.PointX = E.PointX + (D.PointX - E.PointX) * (_SetResize_AB_DE_SideValue / Math.Sqrt(Math.Pow((D.PointX - E.PointX), 2) + Math.Pow((D.PointY - E.PointY), 2)));
                TempPoint.PointY = E.PointY + (D.PointY - E.PointY) * (_SetResize_AB_DE_SideValue / Math.Sqrt(Math.Pow((D.PointX - E.PointX), 2) + Math.Pow((D.PointY - E.PointY), 2)));
                D.PointX = SetCurrentLineLength(E, D, _SetResize_AB_DE_SideValue).PointX;
                D.PointY = SetCurrentLineLength(E, D, _SetResize_AB_DE_SideValue).PointY;

            }
        }




        [DisplayName("Стороны BC и CD  - H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResize_BC_CD_SideValue
        {
            get { return B_line.Length; }
            set
            {
                SetField(ref _SetResize_BC_CD_SideValue, value, () => SetResize_BC_CD_SideValue); ;
                B.PointX = SetCurrentLineLength(C, B, _SetResize_BC_CD_SideValue).PointX;
                B.PointY = SetCurrentLineLength(C, B, _SetResize_BC_CD_SideValue).PointY;
                D.PointX = SetCurrentLineLength(C, D, _SetResize_BC_CD_SideValue).PointX;
                D.PointY = SetCurrentLineLength(C, D, _SetResize_BC_CD_SideValue).PointY;

            }
        }



        /// <summary>
        /// Gets or sets the set resize bc side value.
        /// </summary>
        /// <value>
        /// The set resize bc side value.
        /// </value>
        [DisplayName("СторонаBC - H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResize_BC_SideValue
        {
            get { return B_line.Length; }
            set
            {
                SetField(ref _SetResize_BC_SideValue, value, () => SetResize_BC_SideValue);
                B.PointX = SetCurrentLineLength(C, B, _SetResize_BC_SideValue).PointX;
                B.PointY = SetCurrentLineLength(C, B, _SetResize_BC_SideValue).PointY;

            }
        }


        /// <summary>
        /// Gets or sets the set resize cd side value.
        /// </summary>
        /// <value>
        /// The set resize cd side value.
        /// </value>
        [DisplayName("СторонаCD  - H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResize_CD_SideValue
        {
            get { return C_line.Length; }
            set
            {
                SetField(ref _SetResize_CD_SideValue, value, () => SetResize_CD_SideValue);
                D.PointX = SetCurrentLineLength(C, D, _SetResize_CD_SideValue).PointX;
                D.PointY = SetCurrentLineLength(C, D, _SetResize_CD_SideValue).PointY;
            }
        }



        /// <summary>
        /// Gets or sets the set resize de side value.
        /// </summary>
        /// <value>
        /// The set resize de side value.
        /// </value>
        [DisplayName("СторонаDE  - H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResize_DE_SideValue
        {
            get { return D_line.Length; }
            set
            {
                SetField(ref _SetResize_DE_SideValue, value, () => SetResize_DE_SideValue);
                D.PointX = SetCurrentLineLength(E, D, _SetResize_DE_SideValue).PointX;
                D.PointY = SetCurrentLineLength(E, D, _SetResize_DE_SideValue).PointY;
            }
        }



        /// <summary>
        /// Gets or sets the set resize bottom side valuie value.
        /// </summary>
        /// <value>
        /// The set resize bottom side valuie value.
        /// </value>
        [DisplayName("СторонаEA - L ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResizeBottomSideValue
        {
            get { return E_line.Length; }
            set
            {
                SetField(ref _SetResizeBottomSideValue, value, () => SetResizeBottomSideValue); ;
                E.PointX = SetCurrentLineLength(A, E, _SetResizeBottomSideValue).PointX;
                E.PointY = SetCurrentLineLength(A, E, _SetResizeBottomSideValue).PointY;
            }
        }

        /// <summary>
        /// Gets or sets the set move c side value.
        /// </summary>
        /// <value>
        /// The set move c side value.
        /// </value>
        [DisplayName("Cдвиг С - L1 L2 ")]
        [Category("Correcting")]
        [Display(GroupName = "Изменение размеров верхней стороны")]
        public double SetMove_C_Side_Value
        {
            get
            {
                TempPoint.PointX = B.PointX;
                TempPoint.PointY = C.PointY;
                Line line = GetNewLine(TempPoint, C);

                return line.Length;
            }
            set
            {
                SetField(ref _SetMove_C_Side_Value, value, () => SetMove_C_Side_Value);
                // C.PointX += _SetMove_C_Side_Value;
                TempPoint.PointX = B.PointX;
                TempPoint.PointY = C.PointY;

                TempPoint.PointX = TempPoint.PointX + (C.PointX - TempPoint.PointX) * (_SetMove_C_Side_Value / Math.Sqrt(Math.Pow((C.PointX - TempPoint.PointX), 2) + Math.Pow((C.PointY - TempPoint.PointY), 2)));
                TempPoint.PointY = TempPoint.PointY + (C.PointY - TempPoint.PointY) * (_SetMove_C_Side_Value / Math.Sqrt(Math.Pow((C.PointX - TempPoint.PointX), 2) + Math.Pow((C.PointY - TempPoint.PointY), 2)));
                C.PointX = SetCurrentLineLength(TempPoint, C, _SetMove_C_Side_Value).PointX;
                C.PointY = SetCurrentLineLength(TempPoint, C, _SetMove_C_Side_Value).PointY;
            }
        }



        /// <summary>
        /// Gets or sets a value indicating whether this instance is draw pentagon by angle value.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is draw pentagon by angle value; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Правильная фигура ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsDrawPentagonByAngleValue
        {
            get { return _IsDrawPentagonByAngleValue; }
            set
            {
                SetField(ref _IsDrawPentagonByAngleValue, value, () => IsDrawPentagonByAngleValue);
                if (!IsDrawPentagonByAngleValue) return;
                else
                {
                    E.PointY = A.PointY;
                    E.PointX = SetCurrentLineLength(A, E, E_line.Length).PointX;
                    E.PointY = SetCurrentLineLength(A, E, E_line.Length).PointY;
                    double g = E_line.Length;
                    B.PointX = (E.PointX - A.PointX) * Math.Cos(-1.88496) - (E.PointY - A.PointY) * Math.Sin(-1.88496) + A.PointX;
                    B.PointY = (E.PointX - A.PointX) * Math.Sin(-1.88496) + (E.PointY - A.PointY) * Math.Cos(-1.88496) + A.PointY;
                    C.PointX = (A.PointX - B.PointX) * Math.Cos(-1.88496) - (A.PointY - B.PointY) * Math.Sin(-1.88496) + B.PointX;
                    C.PointY = (A.PointX - B.PointX) * Math.Sin(-1.88496) + (A.PointY - B.PointY) * Math.Cos(-1.88496) + B.PointY;
                    D.PointX = (B.PointX - C.PointX) * Math.Cos(-1.88496) - (B.PointY - C.PointY) * Math.Sin(-1.88496) + C.PointX;
                    D.PointY = (B.PointX - C.PointX) * Math.Sin(-1.88496) + (B.PointY - C.PointY) * Math.Cos(-1.88496) + C.PointY;
                    IsDrawPentagonByAngleValue = false;
                }
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is left side vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is left side vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Вертикаль AB ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsLeftSideVertical
        {
            get { return _IsLeftSideVertical; }
            set
            {
                SetField(ref _IsLeftSideVertical, value, () => IsLeftSideVertical);
                if (IsLeftSideVertical)
                {
                    B.PointX = A.PointX;
                    IsLeftSideVertical = false;
                }
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is right side vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is right side vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Вертикаль DE ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsRightSideVertical
        {
            get { return _IsRightSideVertical; }
            set
            {
                SetField(ref _IsRightSideVertical, value, () => IsRightSideVertical);
                if (IsRightSideVertical)
                {
                    D.PointX = E.PointX;
                    IsRightSideVertical = false;
                }
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is top left side vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is top left side vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Горизонталь BC ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsTopLeftSideHorizontal
        {
            get { return _IsTopLeftSideHorizontal; }
            set
            {
                SetField(ref _IsTopLeftSideHorizontal, value, () => IsTopLeftSideHorizontal);
                if (IsTopLeftSideHorizontal)
                {
                    C.PointY = B.PointY;
                    IsTopLeftSideHorizontal = false;
                }
            }
        }


        [DisplayName("Горизонталь AE ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsBottomSideHorisontal
        {
            get { return _IsBottomSideHorisontal; }
            set
            {
                SetField(ref _IsBottomSideHorisontal, value, () => IsBottomSideHorisontal);
                if (IsBottomSideHorisontal)
                {
                    E.PointY = A.PointY;
                    IsBottomSideHorisontal = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is top right side vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is top right side vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Горизонталь CD ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsTopRightSideHorizontal
        {
            get { return _IsTopRightSideHorizontal; }
            set
            {
                SetField(ref _IsTopRightSideHorizontal, value, () => IsTopRightSideHorizontal);
                if (IsTopRightSideHorizontal)
                {
                    D.PointY = C.PointY;
                    IsTopRightSideHorizontal = false;
                }

            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is both sides vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is both sides vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Вертикали AB и DE ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsBothSidesHorizontal
        {
            get { return _IsBothSidesHorizontal; }
            set
            {
                SetField(ref _IsBothSidesHorizontal, value, () => IsBothSidesHorizontal);
                ShapePoint p = GetNewCustomPoint(E.PointX, D.PointY);
                ShapePoint p1 = GetNewCustomPoint(A.PointX, B.PointY);
                if (IsBothSidesHorizontal)
                {
                    B.PointX = SetCurrentLineLength(p1, B, 0).PointX;
                    B.PointY = SetCurrentLineLength(p1, B, 0).PointY;
                    IsLeftSideVertical = false;
                    D.PointX = SetCurrentLineLength(p, D, 0).PointX;
                    D.PointY = SetCurrentLineLength(p, D, 0).PointY;
                    IsBothSidesHorizontal = false;
                }

            }
        }

        #region Top Side Changes
        [DisplayName("L1 - Справа ")]
        [Category("Верхняя сторона")]
        [Display(GroupName = "Изменение размеров верхней стороны")]
        public double SetLeftDiffTopSide
        {
            get
            {
                ShapePoint as1 = new ShapePoint(A.PointX, B.PointY);
                Line sq = new Line(as1, B);

                return sq.Length;
            }
            set
            {
                SetField(ref _SetLeftDiffTopSide, value, () => SetLeftDiffTopSide);
                CenterPoint.PointX = A.PointX;
                CenterPoint.PointY = B.PointY;
                B.PointX = SetCurrentLineLength(CenterPoint, B, (_SetLeftDiffTopSide + 0.000001)).PointX;
                B.PointY = SetCurrentLineLength(CenterPoint, B, (_SetLeftDiffTopSide + 0.000001)).PointY;
            }
        }


        [DisplayName("L1 - Слева для фигуры 8")]
        [Category("Верхняя сторона")]
        [Display(GroupName = "Изменение размеров верхней стороны")]
        public double SetLeftDiffTopSideMirrow
        {
            get
            {
                ShapePoint as1 = new ShapePoint(B.PointX, C.PointY);
                Line sq = new Line(as1, C);

                return sq.Length;
            }
            set
            {
                SetField(ref _SetLeftDiffTopSideMirrow, value, () => SetLeftDiffTopSideMirrow);
                CenterPoint.PointX = B.PointX;
                CenterPoint.PointY = C.PointY;
                C.PointX = SetCurrentLineLength(CenterPoint, C, (_SetLeftDiffTopSideMirrow + 0.00001)).PointX;
                C.PointY = SetCurrentLineLength(CenterPoint, C, (_SetLeftDiffTopSideMirrow + 0.00001)).PointY;
            }
        }



        [DisplayName("L2 - Справа для фигуры 8 ")]
        [Category("Верхняя сторона")]
        [Display(GroupName = "Изменение размеров верхней стороны")]
        public double SetRightDiffTopSideMirrow
        {

            get
            {
                ShapePoint as1 = GetNewCustomPoint(E.PointX, D.PointY);
                Line aq = GetNewLine(as1, D);

                return aq.Length;
            }
            set
            {
                SetField(ref _SetRightDiffTopSideMirrow, value, () => SetRightDiffTopSideMirrow);

                CenterPoint.PointX = E.PointX;
                CenterPoint.PointY = D.PointY;
                TempPoint.PointX = CenterPoint.PointX + (D.PointX - CenterPoint.PointX) * ((_SetRightDiffTopSideMirrow) / (Math.Sqrt(Math.Pow((D.PointX - CenterPoint.PointX), 2) + Math.Pow((D.PointY - CenterPoint.PointY), 2)) + 0.001));
                TempPoint.PointY = CenterPoint.PointY + (D.PointY - CenterPoint.PointY) * ((_SetRightDiffTopSideMirrow) / (Math.Sqrt(Math.Pow((D.PointX - CenterPoint.PointX), 2) + Math.Pow((D.PointY - CenterPoint.PointY), 2)) + 0.001));
                D.PointX = SetCurrentLineLength(CenterPoint, D, _SetRightDiffTopSideMirrow).PointX;
                D.PointY = SetCurrentLineLength(CenterPoint, D, _SetRightDiffTopSideMirrow).PointY;
            }
        }

        [DisplayName("L2 - Слева ")]
        [Category("Верхняя сторона")]
        [Display(GroupName = "Изменение размеров верхней стороны")]
        public double SetRightDiffTopSide
        {

            get
            {
                ShapePoint as1 = new ShapePoint(D.PointX, C.PointY);
                Line aq = new Line(as1, C);

                return aq.Length;
            }
            set
            {
                SetField(ref _SetRightDiffTopSide, value, () => SetRightDiffTopSide);

                CenterPoint.PointX = D.PointX;
                CenterPoint.PointY = C.PointY;
                C.PointX = SetCurrentLineLength(CenterPoint, C, (_SetRightDiffTopSide + 0.00001)).PointX;
                C.PointY = SetCurrentLineLength(CenterPoint, C, (_SetRightDiffTopSide + 0.00001)).PointY;
            }
        }
        #endregion

        #endregion
        /// <summary>
        /// Moves the specified PointX.
        /// </summary>
        /// <param name="PointX">The PointX.</param>
        /// <param name="y">The y.</param>
        public override void Move(double x = 0, double y = 0)
        {
            //Move to PointX coord
            A.PointX += x;
            B.PointX += x;
            C.PointX += x;
            D.PointX += x;
            E.PointX += x;
           
            ACheck.PointX += x;
            BCheck.PointX += x;
            CCheck.PointX += x;
            DCheck.PointX += x;
            ECheck.PointX += x;
            //Move to Y coord
            A.PointY += y;
            B.PointY += y;
            C.PointY += y;
            D.PointY += y;
            E.PointY += y;
           
            ACheck.PointY += y;
            BCheck.PointY += y;
            CCheck.PointY += y;
            DCheck.PointY += y;
            ECheck.PointY += y;
        }



        /// <summary>
        /// Вращение вокруг центра тяжести
        /// </summary>
        /// <ePointXception cref="NotImplementedEPointXception"></ePointXception>
        public override void Rotate()
        {

            double angle = Math.Abs(CalculateAngle(D, E, A));
            CenterPoint.PointX = (A.PointX + B.PointX + C.PointX + D.PointX + E.PointX) / 5;
            CenterPoint.PointY = (A.PointY + B.PointY + C.PointY + D.PointY + E.PointY) / 5;
            #region Rotate Base shape
            ShapePoint[] points = new ShapePoint[] { A, B, C, D, E };

            #region Change koord

            TempPoint.PointX = E.PointX;
            TempPoint.PointY = E.PointY;
            E.PointX = A.PointX;
            E.PointY = A.PointY;
            A.PointX = TempPoint.PointX;
            A.PointY = TempPoint.PointY;

            TempPoint.PointX = B.PointX;
            TempPoint.PointY = B.PointY;
            B.PointX = E.PointX;
            B.PointY = E.PointY;
            E.PointX = TempPoint.PointX;
            E.PointY = TempPoint.PointY;

            TempPoint.PointX = C.PointX;
            TempPoint.PointY = C.PointY;
            C.PointX = E.PointX;
            C.PointY = E.PointY;
            E.PointX = TempPoint.PointX;
            E.PointY = TempPoint.PointY;

            TempPoint.PointX = D.PointX;
            TempPoint.PointY = D.PointY;
            D.PointX = E.PointX;
            D.PointY = E.PointY;
            E.PointX = TempPoint.PointX;
            E.PointY = TempPoint.PointY;

            #endregion

            foreach (ShapePoint item in points)
            {
                double newPointX = (item.PointX - CenterPoint.PointX) * Math.Cos(((180 - angle) * Math.PI / 180)) - (item.PointY - CenterPoint.PointY) * Math.Sin(((180 - angle) * Math.PI / 180)) + CenterPoint.PointX;
                double newY = (item.PointX - CenterPoint.PointX) * Math.Sin(((180 - angle) * Math.PI / 180)) + (item.PointY - CenterPoint.PointY) * Math.Cos(((180 - angle) * Math.PI / 180)) + CenterPoint.PointY;
                item.PointX = newPointX;
                item.PointY = newY;
            }
        }

        #endregion


        /// <summary>
        /// Scales the specified factor.
        /// </summary>
        /// <param name="factor">The factor.</param>
        /// <ePointXception cref="NotImplementedEPointXception"></ePointXception>
        public override void Scale(double factor = 1.1)
        {

            TempPoint.PointX = A.PointX + (B.PointX - A.PointX) * factor;
            TempPoint.PointY = A.PointY + (B.PointY - A.PointY) * factor;
            B.PointX = TempPoint.PointX;
            B.PointY = TempPoint.PointY;

            TempPoint.PointX = A.PointX + (C.PointX - A.PointX) * factor;
            TempPoint.PointY = A.PointY + (C.PointY - A.PointY) * factor;
            C.PointX = TempPoint.PointX;
            C.PointY = TempPoint.PointY;

            TempPoint.PointX = A.PointX + (D.PointX - A.PointX) * factor;
            TempPoint.PointY = A.PointY + (D.PointY - A.PointY) * factor;
            D.PointX = TempPoint.PointX;
            D.PointY = TempPoint.PointY;
            TempPoint.PointX = A.PointX + (E.PointX - A.PointX) * factor;
            TempPoint.PointY = A.PointY + (E.PointY - A.PointY) * factor;
            E.PointX = TempPoint.PointX;
            E.PointY = TempPoint.PointY;
        }


        /// <summary>
        /// Расчет углов
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <param name="thirdPoint"></param>
        /// <returns></returns>
        public override double CalculateAngle(ShapePoint firstPoint, ShapePoint secondPoint, ShapePoint thirdPoint)
        {
            return base.CalculateAngle(firstPoint, secondPoint, thirdPoint);
        }
        /// <summary>
        /// Отрисовка припуска под обработку
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
            ECheck.PointX = E.PointX;
            ECheck.PointY = E.PointY;
            double diag1 = 0;
            double diag11 = 0;
            double diag2 = 0;
            double diag21 = 0;
            double diag3 = 0;
            double diag31 = 0;
            double diag4 = 0;
            double diag41 = 0;
            double diag5 = 0;
            double diag51 = 0;

            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == false && _CheckCut2 >= 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == false && _CheckCut3 >= 0) ? _CheckCut3 * (-1) : _CheckCut3;
            _CheckCut4 = (IsToothVector == false && _CheckCut4 >= 0) ? _CheckCut4 * (-1) : _CheckCut4;
            _CheckCut5 = (IsToothVector == false && _CheckCut5 >= 0) ? _CheckCut5 * (-1) : _CheckCut5;

            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == true && _CheckCut2 < 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == true && _CheckCut3 < 0) ? _CheckCut3 * (-1) : _CheckCut3;
            _CheckCut4 = (IsToothVector == true && _CheckCut4 < 0) ? _CheckCut4 * (-1) : _CheckCut4;
            _CheckCut5 = (IsToothVector == true && _CheckCut5 < 0) ? _CheckCut5 * (-1) : _CheckCut5;


            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(E, A, B) * Math.PI / 180) :
                 _CheckCut1 / (90 - ((180 - Math.Sin(CalculateAngle(E, A, B)) * Math.PI / 180)));
            diag11 = (diag11 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
               _CheckCut1 / (90 - ((180 - Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));

            diag2 = (diag2 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
               _CheckCut2 / (90 - ((180 - Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag21 = (diag21 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180) :
                _CheckCut2 / (90 - ((180 - Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));

            diag3 = (diag3 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180) :
                  _CheckCut3 / (90 - ((180 - Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));
            diag31 = (diag31 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(C, D, E) * Math.PI / 180) :
               _CheckCut3 / (90 - ((180 - Math.Sin(CalculateAngle(C, D, E)) * Math.PI / 180)));

            diag4 = (diag4 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(C, D, E) * Math.PI / 180) :
                _CheckCut4 / (90 - ((180 - Math.Sin(CalculateAngle(C, D, E)) * Math.PI / 180)));
            diag41 = (diag41 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(D, E, A) * Math.PI / 180) :
               _CheckCut4 / (90 - ((180 - Math.Sin(CalculateAngle(D, E, A)) * Math.PI / 180)));

            diag5 = (diag5 <= 90) ? _CheckCut5 / Math.Sin(CalculateAngle(D, E, A) * Math.PI / 180) :
              _CheckCut5 / (90 - ((180 - Math.Sin(CalculateAngle(D, E, A)) * Math.PI / 180)));
            diag51 = (diag51 <= 90) ? _CheckCut5 / Math.Sin(CalculateAngle(E, A, B) * Math.PI / 180) :
             _CheckCut5 / (90 - ((180 - Math.Sin(CalculateAngle(E, A, B)) * Math.PI / 180)));
            /*1*/
            ACheck.PointX = Math.Round(SetCurrentLineLength(ECheck, ACheck, diag1 + E_Check_Line.Length).PointX,0);
            ACheck.PointY = Math.Round(SetCurrentLineLength(ECheck, ACheck, diag1 + E_Check_Line.Length).PointY, 0);
            BCheck.PointX = Math.Round(SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointX, 0);
            BCheck.PointY = Math.Round(SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointY, 0);


            /*3*/

            double B_Check_Line_Length1 = B_Check_Line.Length;
            double D_Check_Line_Length = D_Check_Line.Length;
            CCheck.PointX = Math.Round(SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointX, 0);
            CCheck.PointY = Math.Round(SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointY, 0);
            DCheck.PointX = Math.Round(SetCurrentLineLength(ECheck, DCheck, diag31 + D_Check_Line_Length).PointX, 0);
            DCheck.PointY = Math.Round(SetCurrentLineLength(ECheck, DCheck, diag31 + D_Check_Line_Length).PointY, 0);



            /*2*/
            double C_Check_Line_Length1 = C_Check_Line.Length;
            double A_Check_Line_Length = A_Check_Line.Length;


            BCheck.PointX = Math.Round(SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line.Length).PointX, 0);
            BCheck.PointY = Math.Round(SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line.Length).PointY, 0);
            CCheck.PointY = Math.Round(SetCurrentLineLength(DCheck, CCheck, diag21 + C_Check_Line.Length).PointY, 0);
            CCheck.PointX = Math.Round(SetCurrentLineLength(DCheck, CCheck, diag21 + C_Check_Line.Length).PointX, 0);

            /*5*/
            ECheck.PointX = Math.Round(SetCurrentLineLength(DCheck, ECheck, diag5 + D_Check_Line.Length).PointX, 0);
            ECheck.PointY = Math.Round(SetCurrentLineLength(DCheck, ECheck, diag5 + D_Check_Line.Length).PointY, 0);
            ACheck.PointX = Math.Round(SetCurrentLineLength(BCheck, ACheck, diag51 + A_Check_Line.Length).PointX, 0);
            ACheck.PointY = Math.Round(SetCurrentLineLength(BCheck, ACheck, diag51 + A_Check_Line.Length).PointY, 0);



            /*4*/
            double C_Check_Line_Length = C_Check_Line.Length;
            double E_Check_Line_Length = E_Check_Line.Length;
            DCheck.PointX = Math.Round(SetCurrentLineLength(CCheck, DCheck, diag4 + C_Check_Line_Length).PointX, 0);
            DCheck.PointY =Math.Round( SetCurrentLineLength(CCheck, DCheck, diag4 + C_Check_Line_Length).PointY, 0);
            ECheck.PointX =Math.Round( SetCurrentLineLength(ACheck, ECheck, diag41 + E_Check_Line_Length).PointX, 0);
            ECheck.PointY =Math.Round( SetCurrentLineLength(ACheck, ECheck, diag41 + E_Check_Line_Length).PointY, 0);

            PointF[] cutPoints = new PointF[] { ACheck, BCheck, CCheck, DCheck, ECheck };
            if (IsToothVector == true)
            {
                //using (Pen penCut = new Pen(Color.Red, ThiсknessArgument))
                //{
                //    graphicsShape.DrawPolygon(penCut, cutPoints);
                //    IsToothVector = true;
                //}
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen1, ACheck, BCheck);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen2, BCheck, CCheck);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen3, CCheck, DCheck);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen4, DCheck, ECheck);
                }
                using (pen5 = new Pen(SelectMainLineColor5(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen5, ECheck, ACheck);
                }
                IsToothVector = true;
            }
            else
            {
                //using (Pen penCut = new Pen(Color.Red, ThiсknessArgument / 2))
                //{
                //    penCut.DashStyle = DashStyle.DashDot;
                //    graphicsShape.DrawPolygon(penCut, cutPoints);
                //    IsToothVector = false;
                //}
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument / 2))
                {
                    pen1.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen1, ACheck, BCheck);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument / 2))
                {
                    pen2.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen2, BCheck, CCheck);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument / 2))
                {
                    pen3.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen3, CCheck, DCheck);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument / 2))
                {
                    pen4.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen4, DCheck, ECheck);
                }
                using (pen5 = new Pen(SelectMainLineColor5(), ThiсknessArgument / 2))
                {
                    pen5.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen5, ECheck, ACheck);
                }
                IsToothVector = false;
            }
            GetExtremumPoints();
        }


        /// <summary>
        /// Moves the point.
        /// </summary>
        /// <param name="PointX">The PointX.</param>
        /// <param name="y">The y.</param>
        public override void MovePoint(float PointX, float y)
        {
            switch (SetPoint)
            {
                case SelectedPoint.A:

                    A.PointX = PointX;
                    A.PointY = y;
                    break;
                case SelectedPoint.B:
                    B.PointX = PointX;
                    B.PointY = y;
                    break;
                case SelectedPoint.C:
                    C.PointX = PointX;
                    C.PointY = y;
                    break;
                case SelectedPoint.D:
                    D.PointX = PointX;
                    D.PointY = y;
                    break;
                case SelectedPoint.E:
                    E.PointX = PointX;
                    E.PointY = y;
                    break;


            }
        }

        /// <summary>
        /// Customs the points list.
        /// </summary>
        /// <returns></returns>
        public override List<ShapePoint> ShapePointsList()
        {

            A.PointName = "A";
            B.PointName = "B";
            C.PointName = "C";
            D.PointName = "D";
            E.PointName = "E";

            List<ShapePoint> ShapePoints = new List<ShapePoint>() { A, B, C, D, E };
            return ShapePoints;
        }



        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string points = string.Format("A {0} , B {1} , C {2} , D {3},E{4} \n", A.ToString(), B.ToString(), C.ToString(), D.ToString(), E.ToString());
            string lines = string.Format(" AB ={0} ; BC={1} ; CD ={2} ; DE={3} ; EA={4}\n ", A_line.Length, B_line.Length, C_line.Length, D_line.Length, E_line.Length);
            string otherParameters = string.Format(" Периметр = {0} ; Площадь ={1}\n ", this.Perimeter, this.Area);
            string otherParameters1 = string.Format(" Угол EAB = {0},Угол ABC = {1},Угол BCD = {2},Угол CDE = {3} ,Угол DEA = {4} \n ",
                CalculateAngle(E, A, B), CalculateAngle(A, B, C), CalculateAngle(B, C, D), CalculateAngle(C, D, E), CalculateAngle(D, E, A));

            return string.Format(points + lines + otherParameters + otherParameters1);
        }
        public override void AddCustomParametersProperties (object sender, CustomPropertyDescriptorsEventArgs e)
        {
            if (e.Context.PropertyDescriptor == null)
            {
                PropertyDescriptorCollection filteredCollection = new PropertyDescriptorCollection(null);

                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKis");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKisPersent");
                AddIfPropertyExist(e.Properties, filteredCollection, "Area");
                AddIfPropertyExist(e.Properties, filteredCollection, "TrueArea");
                AddIfPropertyExist(e.Properties, filteredCollection, "BaseArea");
                AddIfPropertyExist(e.Properties, filteredCollection, "Perimeter");
                AddIfPropertyExist(e.Properties, filteredCollection, "Perimeter_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeHeightValue");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeWidthValue");
                //AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                //AddIfPropertyExist(e.Properties, filteredCollection, "IsSelectSameAllowance");
               
                e.Properties = filteredCollection;
            }
        }
        public override void AddCustomToothProperties(object sender, CustomPropertyDescriptorsEventArgs e)
        {
            if (e.Context.PropertyDescriptor == null)
            {
                PropertyDescriptorCollection filteredCollection = new PropertyDescriptorCollection(null);
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut2");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut3");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut4");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut5");
                e.Properties = filteredCollection;
            }
        }
    }
}
