using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows;

namespace Socrat.Shape
{





    /// <summary>
    /// Класс шестиугольник
    /// </summary>
    /// <seealso cref="BaseShape" />

    public partial class Hexagon : BaseShape
    {



        #region Sides

        private double _SetResizeABsideValue;
        private double _SetResizeBCsideValue;
        private double _SetResizeCDsideValue;
        private double _SetResizeDEsideValue;
        private double _SetResizeEFsideValue;
        private double _SetResizeBottomsideValue;
        private double _SetResize_AB_with_DE_Sides;
        private double _SetResize_BC_with_EF_Sides;
        private double _SetResize_AF_with_CD_Sides;
        private bool _IsDrawPentagonByAngleValue;
        private bool _IsABSideVertical;
        private bool _IsBCSideVertical;
        private bool _IsCDSideVertical;
        private bool _IsDESideVertical;
        private bool _IsEFSideVertical;
        private bool _IsAFSideVertical;
        private bool _IsABSideHorisontal;
        private bool _IsCDSideHorisontal;
        private bool _IsDESideHorisontal;
        private bool _IsAFSideHorisontal;

        #endregion

        //protected override double CalculateLowerLeftAngleForShpros()
        //{
        //    ShapePoint firstPoint = F;
        //    ShapePoint secondPoint = A;
        //    ShapePoint thirdPoint = B;
        //    double angleBetween = 0;
        //    Vector vector1 = new Vector((thirdPoint.PointX - secondPoint.PointX), (thirdPoint.PointY - secondPoint.PointY));
        //    Vector vector2 = new Vector((firstPoint.PointX - secondPoint.PointX), (firstPoint.PointY - secondPoint.PointY));
        //    angleBetween = Math.Abs(Vector.AngleBetween(vector1, vector2));
        //    return Math.Round(angleBetween, 1);
        //}
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
        /// Gets or sets the set f radius.
        /// </summary>
        /// <value>
        /// The set d radius.
        /// </value>
        [DisplayName("Радиус F")]
        [Category("Radius")]
        [Display(GroupName = "Скругления")]
        public float SetF_radius { get; set; }






        /// <summary>
        /// Initializes a new instance of the <see cref="Hexagon"/> class.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>

        public Hexagon(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
            ShapePoint[] points = new ShapePoint[] { A = GetNewPoint(), B = GetNewPoint(), C = GetNewPoint(), D = GetNewPoint(), E = GetNewPoint(), F = GetNewPoint() };
            try
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].PointX = ShapePoints[i].PointX;
                    points[i].PointY = ShapePoints[i].PointY;
                    points[i].PointRadius = ShapePoints[i].PointRadius ?? 0;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {

                //    throw new ArgumentOutOfRangeException("Нет данных");
            }

            A_line = new Line(A, B);
            B_line = new Line(B, C);
            C_line = new Line(C, D);
            D_line = new Line(D, E);
            E_line = new Line(E, F);
            F_line = new Line(F, A);
            A_Check_Line = GetNewLine(ACheck, BCheck);
            B_Check_Line = GetNewLine(BCheck, CCheck);
            C_Check_Line = GetNewLine(CCheck, DCheck);
            D_Check_Line = GetNewLine(DCheck, ECheck);
            E_Check_Line = GetNewLine(ECheck, FCheck);
            F_Check_Line = GetNewLine(FCheck, ACheck);
            SetA_radius = A.PointRadius??0;
            SetB_radius = B.PointRadius??0;
            SetC_radius = C.PointRadius??0;
            SetD_radius = D.PointRadius??0;
            SetE_radius = E.PointRadius??0;
            SetF_radius = F.PointRadius??0;
            GetCurrentParameters(currentShapeParametersList);
           
           
        }
       

        /// <summary>
        /// </summary>
        public override double Perimeter
        {
            get
            {

                double AArc = SetA_radius * (CalculateAngle(F, A, B) <= 90 ? CalculateAngle(F, A, B) : 180 - CalculateAngle(F, A, B)) / 180;
                double BArc = SetB_radius * Math.PI * (CalculateAngle(A, B, C) <= 90 ? CalculateAngle(A, B, C) : 180 - CalculateAngle(A, B, C)) / 180;
                double CArc = SetC_radius * Math.PI * (CalculateAngle(B, C, D) <= 90 ? CalculateAngle(B, C, D) : 180 - CalculateAngle(B, C, D)) / 180;
                double DArc = SetD_radius * Math.PI * (CalculateAngle(C, D, E) <= 90 ? CalculateAngle(C, D, E) : 180 - CalculateAngle(C, D, E)) / 180;
                double EArc = SetE_radius * Math.PI * (CalculateAngle(D, E, F) <= 90 ? CalculateAngle(D, E, F) : 180 - CalculateAngle(D, E, F)) / 180;
                double FArc = SetF_radius * Math.PI * (CalculateAngle(E, F, A) <= 90 ? CalculateAngle(E, F, A) : 180 - CalculateAngle(E, F, A)) / 180;
                Line a = GetNewLine(A1, B2);
                Line b = GetNewLine(B1, C1);
                Line c = GetNewLine(C2, D1);
                Line d = GetNewLine(D2, E1);
                Line e = GetNewLine(E2, F1);
                Line f = GetNewLine(F2, A2);
                return Math.Round((AArc + BArc + CArc + DArc + EArc + FArc + a.Length + b.Length + c.Length + d.Length + e.Length + f.Length) / 1000, 3);
            }
        }
        public override void SelectClickedSide(int xCoord, int yCoord, bool flag)
        {
            System.Drawing.Point point = new System.Drawing.Point(xCoord, yCoord);
            if (ThicknessPath(A, B).IsVisible(point))
            {
                if (flag) { ColorMarker1 = "rowCheckCut1"; SelectedSides.SetValue(1,0); ClickedSelectSide = 1; SelectedSidesLength += A_line.Length; }
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
           
            if (ThicknessPath(E, F).IsVisible(point))
            {
                if (flag) { ColorMarker5 = "rowCheckCut5"; SelectedSides.SetValue(5, 4); ClickedSelectSide = 5; SelectedSidesLength += E_line.Length; }
                else { ColorMarker5 = ""; SelectedSides.SetValue(0, 4); ClickedSelectSide = 0; SelectedSidesLength -= E_line.Length; }
            }
           
            if (ThicknessPath(F, A).IsVisible(point))
            {
                if (flag) { ColorMarker6 = "rowCheckCut6"; SelectedSides.SetValue(1, 5); ClickedSelectSide = 6; SelectedSidesLength += F_line.Length; }
                else { ColorMarker6 = ""; SelectedSides.SetValue(0, 5); ClickedSelectSide = 0; SelectedSidesLength -= F_line.Length; }
            }
          // else return;
             
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
                else if (sideNum == 6) { SelectedSidesLength += F_line.Length; }          
            }
        }





        int CurrentState(bool flag,int number)
        {
            number = (flag) ? number : 0;

            return number;
        }

      
           
       



            /// <summary>
        /// </summary>
        public override double Area
        {
            get
            {
                G_line = new Line(A, C);


                Line Aa = GetNewLine(A2, A);
                Line Ab = GetNewLine(A1, A);
                Line Ac = GetNewLine(A1, A2);
                double AAngle = (CalculateAngle(F, A, B) <= 90 ? CalculateAngle(F, A, B) : 180 - CalculateAngle(F, A, B)) / 180;
                double ATriangle = Math.Round(Math.Sqrt(((Aa.Length + Ab.Length + Ac.Length) / 2) *
                   (((Aa.Length + Ab.Length + Ac.Length) / 2) - Aa.Length) *
                   (((Aa.Length + Ab.Length + Ac.Length) / 2) - Ab.Length) *
                   (((Aa.Length + Ab.Length + Ac.Length) / 2) - Ac.Length)), 2) -
                  (Math.Pow(SetA_radius, 2) / 2) * (Math.PI * AAngle * Math.PI / 180 - Math.Sin(AAngle * Math.PI / 180));


                Line Ba = GetNewLine(B2, B);
                Line Bb = GetNewLine(B1, B);
                Line Bc = GetNewLine(B1, B2);
                double BAngle = (CalculateAngle(A, B, C) <= 90 ? CalculateAngle(A, B, C) : 180 - CalculateAngle(A, B, C)) / 180;
                double BTriangle = Math.Round(Math.Sqrt(((Ba.Length + Bb.Length + Bc.Length) / 2) *
                   (((Ba.Length + Bb.Length + Bc.Length) / 2) - Ba.Length) *
                   (((Ba.Length + Bb.Length + Bc.Length) / 2) - Bb.Length) *
                   (((Ba.Length + Bb.Length + Bc.Length) / 2) - Bc.Length)), 2) -
                   (Math.Pow(SetB_radius, 2) / 2) * (Math.PI * BAngle * Math.PI / 180 - Math.Sin(BAngle * Math.PI / 180));



                Line Ca = GetNewLine(C1, C);
                Line Cb = GetNewLine(C2, C);
                Line Cc = GetNewLine(C1, C2);
                double Cangle = (CalculateAngle(B, C, D) <= 90 ? CalculateAngle(B, C, D) : 180 - CalculateAngle(B, C, D)) / 180;
                double CTriangle = Math.Round(Math.Sqrt(((Ca.Length + Cb.Length + Cc.Length) / 2) *
                    (((Ca.Length + Cb.Length + Cc.Length) / 2) - Ca.Length) *
                    (((Ca.Length + Cb.Length + Cc.Length) / 2) - Cb.Length) *
                    (((Ca.Length + Cb.Length + Cc.Length) / 2) - Cc.Length)), 2) -
                     ((Math.Pow(SetC_radius, 2) / 2) * (Math.PI * Cangle * Math.PI / 180 - Math.Sin(Cangle * Math.PI / 180)));




                Line Da = GetNewLine(D2, D);
                Line Db = GetNewLine(D1, D);
                Line Dc = GetNewLine(D1, D2);
                double DAngle = (CalculateAngle(C, D, E) <= 90 ? CalculateAngle(C, D, E) : 180 - CalculateAngle(C, D, E)) / 180;
                double DTriangle = Math.Round(Math.Sqrt(((Da.Length + Db.Length + Dc.Length) / 2) *
                   (((Da.Length + Db.Length + Dc.Length) / 2) - Da.Length) *
                   (((Da.Length + Db.Length + Dc.Length) / 2) - Db.Length) *
                   (((Da.Length + Db.Length + Dc.Length) / 2) - Dc.Length)), 2) -
                 (Math.Pow(SetD_radius, 2) / 2) * (Math.PI * DAngle * Math.PI / 180 - Math.Sin(DAngle * Math.PI / 180));


                Line Ea = GetNewLine(E2, E);
                Line Eb = GetNewLine(E1, E);
                Line Ec = GetNewLine(E1, E2);
                double EAngle = (CalculateAngle(D, E, F) <= 90 ? CalculateAngle(D, E, F) : 180 - CalculateAngle(D, E, F)) / 180;
                double ETriangle = Math.Round(Math.Sqrt(((Ea.Length + Eb.Length + Ec.Length) / 2) *
                   (((Ea.Length + Eb.Length + Ec.Length) / 2) - Ea.Length) *
                   (((Ea.Length + Eb.Length + Ec.Length) / 2) - Eb.Length) *
                   (((Ea.Length + Eb.Length + Ec.Length) / 2) - Ec.Length)), 2) -
                 (Math.Pow(SetE_radius, 2) / 2) * (Math.PI * EAngle * Math.PI / 180 - Math.Sin(EAngle * Math.PI / 180));



                Line Fa = GetNewLine(E2, E);
                Line Fb = GetNewLine(E1, E);
                Line Fc = GetNewLine(E1, E2);
                double FAngle = (CalculateAngle(E, F, A) <= 90 ? CalculateAngle(E, F, A) : 180 - CalculateAngle(E, F, A)) / 180;
                double FTriangle = Math.Round(Math.Sqrt(((Fa.Length + Fb.Length + Fc.Length) / 2) *
                   (((Fa.Length + Fb.Length + Fc.Length) / 2) - Fa.Length) *
                   (((Fa.Length + Fb.Length + Fc.Length) / 2) - Fb.Length) *
                   (((Fa.Length + Fb.Length + Fc.Length) / 2) - Fc.Length)), 2) -
                 (Math.Pow(SetF_radius, 2) / 2) * (Math.PI * FAngle * Math.PI / 180 - Math.Sin(FAngle * Math.PI / 180));
                double baseSquare = 0.5 * Math.Abs((A.PointX * B.PointY + B.PointX * C.PointY + C.PointX * D.PointY + D.PointX * E.PointY + E.PointX * F.PointY + F.PointX * A.PointY) - (B.PointX * A.PointY + C.PointX * B.PointY + D.PointX * C.PointY + E.PointX * D.PointY + F.PointX * E.PointY + A.PointX * F.PointY));
                return Math.Round((baseSquare - Math.Abs(ATriangle) - Math.Abs(BTriangle)
                    - Math.Abs(CTriangle)
                    - Math.Abs(DTriangle) - Math.Abs(ETriangle) - Math.Abs(FTriangle)) / 1000000, 3);
            }
        }

        public override double TrueArea
        {
            get
            {

                double baseSquare = 0.5 * Math.Abs((ACheck.PointX * BCheck.PointY + BCheck.PointX * CCheck.PointY + CCheck.PointX * DCheck.PointY + DCheck.PointX * ECheck.PointY +
                    ECheck.PointX * FCheck.PointY + FCheck.PointX * ACheck.PointY) - (BCheck.PointX * ACheck.PointY + CCheck.PointX * BCheck.PointY + DCheck.PointX * CCheck.PointY +
                    ECheck.PointX * DCheck.PointY + FCheck.PointX * ECheck.PointY + ACheck.PointX * FCheck.PointY));

                return Math.Round((baseSquare) / 1000000, 3);
            }
        }

        /// <summary>
        /// Вращение вокруг центра тяжести
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Rotate()
        {
            double angle = Math.Abs(CalculateAngle(E, F, A));
            CenterPoint.PointX = (A.PointX + B.PointX + C.PointX + D.PointX + E.PointX + F.PointX) / 6;
            CenterPoint.PointY = (A.PointY + B.PointY + C.PointY + D.PointY + E.PointY + F.PointY) / 6;
            ShapePoint[] points = new ShapePoint[] { A, B, C, D, E, F };

            #region Change koord
            TempPoint.PointX = F.PointX;
            TempPoint.PointY = F.PointY;
            F.PointX = A.PointX;
            F.PointY = A.PointY;
            A.PointX = TempPoint.PointX;
            A.PointY = TempPoint.PointY;

            TempPoint.PointX = B.PointX;
            TempPoint.PointY = B.PointY;
            B.PointX = F.PointX;
            B.PointY = F.PointY;
            F.PointX = TempPoint.PointX;
            F.PointY = TempPoint.PointY;

            TempPoint.PointX = C.PointX;
            TempPoint.PointY = C.PointY;
            C.PointX = F.PointX;
            C.PointY = F.PointY;
            F.PointX = TempPoint.PointX;
            F.PointY = TempPoint.PointY;

            TempPoint.PointX = D.PointX;
            TempPoint.PointY = D.PointY;
            D.PointX = F.PointX;
            D.PointY = F.PointY;
            F.PointX = TempPoint.PointX;
            F.PointY = TempPoint.PointY;

            TempPoint.PointX = E.PointX;
            TempPoint.PointY = E.PointY;
            E.PointX = F.PointX;
            E.PointY = F.PointY;
            F.PointX = TempPoint.PointX;
            F.PointY = TempPoint.PointY;
            #endregion

            foreach (ShapePoint item in points)
            {
                double newX = (item.PointX - CenterPoint.PointX) * Math.Cos(((180 - angle) * Math.PI / 180)) - (item.PointY - CenterPoint.PointY) * Math.Sin(((180 - angle) * Math.PI / 180)) + CenterPoint.PointX;
                double newY = (item.PointX - CenterPoint.PointX) * Math.Sin(((180 - angle) * Math.PI / 180)) + (item.PointY - CenterPoint.PointY) * Math.Cos(((180 - angle) * Math.PI / 180)) + CenterPoint.PointY;
                item.PointX = newX;
                item.PointY = newY;
            }
        }



        /// <summary>
        /// Scales the specified factor.
        /// </summary>
        /// <param name="factor">The factor.</param>
        /// <exception cref="NotImplementedException"></exception>
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

            TempPoint.PointX = A.PointX + (F.PointX - A.PointX) * factor;
            TempPoint.PointY = A.PointY + (F.PointY - A.PointY) * factor;
            F.PointX = TempPoint.PointX;
            F.PointY = TempPoint.PointY;
        }


        #region Top Side Changes
        private double _SetRightDiffTopSide;
        private double _SetLeftDiffTopSide;

        [DisplayName("L1 ")]
        [Category("Верхняя сторона")]
        [Display(GroupName = "Изменение размеров верхней стороны")]
        public double SetLeftDiffTopSide
        {
            get
            {
                ShapePoint as1 = new ShapePoint(B.PointX, C.PointY);
                Line sq = new Line(as1, C);

                return sq.Length;
            }
            set
            {
                SetField(ref _SetLeftDiffTopSide, value, () => SetLeftDiffTopSide);
                CenterPoint.PointX = B.PointX;
                CenterPoint.PointY = C.PointY;
                C.PointX = SetCurrentLineLength(CenterPoint, C, (_SetLeftDiffTopSide + 0.000001)).PointX;
                C.PointY = SetCurrentLineLength(CenterPoint, C, (_SetLeftDiffTopSide + 0.000001)).PointY;
            }
        }


        [DisplayName("L2 ")]
        [Category("Верхняя сторона")]
        [Display(GroupName = "Изменение размеров верхней стороны")]
        public double SetRightDiffTopSide
        {

            get
            {
                ShapePoint as1 = new ShapePoint(E.PointX, D.PointY);
                Line aq = new Line(as1, D);

                return aq.Length;
            }
            set
            {
                SetField(ref _SetRightDiffTopSide, value, () => SetRightDiffTopSide);

                CenterPoint.PointX = E.PointX;
                CenterPoint.PointY = D.PointY;
                D.PointX = SetCurrentLineLength(CenterPoint, D, (_SetRightDiffTopSide + 0.00001)).PointX;
                D.PointY = SetCurrentLineLength(CenterPoint, D, (_SetRightDiffTopSide + 0.00001)).PointY;
            }
        }
        #endregion


        public override void Move(double x = 0, double y = 0)
        {
            //Move to X coord
            A.PointX += x;
            B.PointX += x;
            C.PointX += x;
            D.PointX += x;
            E.PointX += x;
            F.PointX += x;
            //Move to Y coord
            A.PointY += y;
            B.PointY += y;
            C.PointY += y;
            D.PointY += y;
            E.PointY += y;
            F.PointY += y;
        }
        #region Resizes


        /// <summary>
        /// Gets or sets the set resize a bside value.
        /// </summary>
        /// <value>
        /// The set resize a bside value.
        /// </value>     
        [DisplayName("Сторона AB -H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResizeABsideValue
        {
            get { return Math.Round(A_line.Length, 0); }
            set
            {
                SetField(ref _SetResizeABsideValue, value, () => SetResizeABsideValue);
                B.PointX = SetCurrentLineLength(A, B, _SetResizeABsideValue).PointX;
                B.PointY = SetCurrentLineLength(A, B, _SetResizeABsideValue).PointY;
            }
        }
        /// <summary>
        /// Gets or sets the set resize b cside value.
        /// </summary>
        /// <value>
        /// The set resize b cside value.
        /// </value>
        [DisplayName("Сторона BC -H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResizeBCsideValue
        {
            get { return Math.Round(B_line.Length, 0); }
            set
            {
                SetField(ref _SetResizeBCsideValue, value, () => SetResizeBCsideValue);
                B.PointX = SetCurrentLineLength(C, B, _SetResizeBCsideValue).PointX;
                B.PointY = SetCurrentLineLength(C, B, _SetResizeBCsideValue).PointY;
            }
        }


        /// <summary>
        /// Gets or sets the set resize c dside value.
        /// </summary>
        /// <value>
        /// The set resize c dside value.
        /// </value>
        [DisplayName("Сторона CD -H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResizeCDsideValue
        {
            get { return Math.Round(C_line.Length, 0); }
            set
            {
                SetField(ref _SetResizeCDsideValue, value, () => SetResizeCDsideValue);
                D.PointX = SetCurrentLineLength(C, D, _SetResizeCDsideValue).PointX;
                D.PointY = SetCurrentLineLength(C, D, _SetResizeCDsideValue).PointY;
            }
        }


        /// <summary>
        /// Gets or sets the set resize d eside value.
        /// </summary>
        /// <value>
        /// The set resize d eside value.
        /// </value>
        [DisplayName("Сторона DE -H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResizeDEsideValue
        {
            get { return Math.Round(D_line.Length, 0); }
            set
            {
                SetField(ref _SetResizeDEsideValue, value, () => SetResizeDEsideValue);
                E.PointX = SetCurrentLineLength(E, D, _SetResizeDEsideValue).PointX;
                E.PointY = SetCurrentLineLength(E, D, _SetResizeDEsideValue).PointY;
            }
        }


        /// <summary>
        /// Gets or sets the set resize e fside value.
        /// </summary>
        /// <value>
        /// The set resize e fside value.
        /// </value>
        [DisplayName("Сторона EF -H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResizeEFsideValue
        {
            get { return Math.Round(E_line.Length, 0); }
            set
            {
                SetField(ref _SetResizeEFsideValue, value, () => SetResizeEFsideValue);
                F.PointX = SetCurrentLineLength(E, F, _SetResizeEFsideValue).PointX;
                F.PointY = SetCurrentLineLength(E, F, _SetResizeEFsideValue).PointY;

            }
        }


        /// <summary>
        /// Gets or sets the set resize bottomside value.
        /// </summary>
        /// <value>
        /// The set resize bottomside value.
        /// </value>
        [DisplayName("Сторона FA -H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResizeBottomsideValue
        {
            get { return Math.Round(F_line.Length, 0); }
            set
            {
                SetField(ref _SetResizeBottomsideValue, value, () => SetResizeBottomsideValue);
                F.PointX = SetCurrentLineLength(A, F, _SetResizeBottomsideValue).PointX;
                F.PointY = SetCurrentLineLength(A, F, _SetResizeBottomsideValue).PointY;
            }
        }

        /// <summary>
        /// Gets or sets the resize a bwith de sides.
        /// </summary>
        /// <value>
        /// The resize a bwith de sides.
        /// </value>
        [DisplayName("Стороны AB и DE -H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResize_AB_with_DE_Sides
        {
            get { return _SetResize_AB_with_DE_Sides; }
            set
            {
                Line tLine = new Line(C, F);
                double oldDiag = tLine.Length;
                double oldLength = (A_line.Length + D_line.Length) / 2;
                SetField(ref _SetResize_AB_with_DE_Sides, value, () => SetResize_AB_with_DE_Sides);
                D.PointX = SetCurrentLineLength(E, D, _SetResize_AB_with_DE_Sides).PointX;
                D.PointY = SetCurrentLineLength(E, D, _SetResize_AB_with_DE_Sides).PointY;
                B.PointX = SetCurrentLineLength(A, B, _SetResize_AB_with_DE_Sides).PointX;
                B.PointY = SetCurrentLineLength(A, B, _SetResize_AB_with_DE_Sides).PointY;
                double newLength = (A_line.Length + D_line.Length) / 2;
                double newDiff = oldDiag + newLength - oldLength;
                C.PointX = SetCurrentLineLength(F, C, newDiff).PointX;
                C.PointY = SetCurrentLineLength(F, C, newDiff).PointY;
            }
        }

        /// <summary>
        /// Gets or sets the resize bc with ef sides.
        /// </summary>
        /// <value>
        /// The resize bc with ef sides.
        /// </value>
        [DisplayName("Стороны BC и EF -H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResize_BC_with_EF_Sides
        {
            get { return _SetResize_BC_with_EF_Sides; }
            set
            {
                Line tLine = new Line(A, D);
                double oldDiag = tLine.Length;
                double oldLength = (B_line.Length + E_line.Length) / 2;
                SetField(ref _SetResize_BC_with_EF_Sides, value, () => SetResize_BC_with_EF_Sides);
                C.PointX = SetCurrentLineLength(B, C, _SetResize_BC_with_EF_Sides).PointX;
                C.PointY = SetCurrentLineLength(B, C, _SetResize_BC_with_EF_Sides).PointY;
                E.PointX = SetCurrentLineLength(F, E, _SetResize_BC_with_EF_Sides).PointX;
                E.PointY = SetCurrentLineLength(F, E, _SetResize_BC_with_EF_Sides).PointY;
                double newLength = (B_line.Length + E_line.Length) / 2;
                double newDiff = oldDiag + newLength - oldLength;
                D.PointX = SetCurrentLineLength(A, D, newDiff).PointX;
                D.PointY = SetCurrentLineLength(A, D, newDiff).PointY;

            }
        }



        /// <summary>
        /// Gets or sets the set resize af with cd sides.
        /// </summary>
        /// <value>
        /// The set resize af with cd sides.
        /// </value>
        [DisplayName("Стороны AF и CD -H ")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]

        public double SetResize_AF_with_CD_Sides
        {
            get { return _SetResize_AF_with_CD_Sides; }
            set
            {
                Line tLine = new Line(B, E);
                double oldDiag = tLine.Length;
                double oldLength = (C_line.Length + F_line.Length) / 2;
                SetField(ref _SetResize_AF_with_CD_Sides, value, () => SetResize_AF_with_CD_Sides);
                D.PointX = SetCurrentLineLength(C, D, _SetResize_AF_with_CD_Sides).PointX;
                D.PointY = SetCurrentLineLength(C, D, _SetResize_AF_with_CD_Sides).PointY;
                F.PointX = SetCurrentLineLength(A, F, _SetResize_AF_with_CD_Sides).PointX;
                F.PointY = SetCurrentLineLength(A, F, _SetResize_AF_with_CD_Sides).PointY;
                double newLength = (C_line.Length + F_line.Length) / 2;
                double newDiff = oldDiag + newLength - oldLength;
                E.PointX = SetCurrentLineLength(B, E, newDiff).PointX;
                E.PointY = SetCurrentLineLength(B, E, newDiff).PointY;
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
                    F.PointY = A.PointY;
                    F.PointX = SetCurrentLineLength(A, F, F_line.Length).PointX;
                    F.PointY = SetCurrentLineLength(A, F, F_line.Length).PointY;
                    B.PointX = (F.PointX - A.PointX) * Math.Cos(-2.0944) - (F.PointY - A.PointY) * Math.Sin(-2.0944) + A.PointX;
                    B.PointY = (F.PointX - A.PointX) * Math.Sin(-2.0944) + (F.PointY - A.PointY) * Math.Cos(-2.0944) + A.PointY;
                    C.PointX = (A.PointX - B.PointX) * Math.Cos(-2.0944) - (A.PointY - B.PointY) * Math.Sin(-2.0944) + B.PointX;
                    C.PointY = (A.PointX - B.PointX) * Math.Sin(-2.0944) + (A.PointY - B.PointY) * Math.Cos(-2.0944) + B.PointY;
                    D.PointX = (B.PointX - C.PointX) * Math.Cos(-2.0944) - (B.PointY - C.PointY) * Math.Sin(-2.0944) + C.PointX;
                    D.PointY = (B.PointX - C.PointX) * Math.Sin(-2.0944) + (B.PointY - C.PointY) * Math.Cos(-2.0944) + C.PointY;
                    E.PointX = (C.PointX - D.PointX) * Math.Cos(-2.0944) - (C.PointY - D.PointY) * Math.Sin(-2.0944) + D.PointX;
                    E.PointY = (C.PointX - D.PointX) * Math.Sin(-2.0944) + (C.PointY - D.PointY) * Math.Cos(-2.0944) + D.PointY;
                    IsDrawPentagonByAngleValue = false;
                }
            }
        }

      

        /// <summary>
        /// Moves the point.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public override void MovePoint(float x, float y)
        {
            switch (SetPoint)
            {
                case SelectedPoint.A:

                    A.PointX = x;
                    A.PointY = y;
                    break;
                case SelectedPoint.B:
                    B.PointX = x;
                    B.PointY = y;
                    break;
                case SelectedPoint.C:
                    C.PointX = x;
                    C.PointY = y;
                    break;
                case SelectedPoint.D:
                    D.PointX = x;
                    D.PointY = y;
                    break;
                case SelectedPoint.E:
                    E.PointX = x;
                    E.PointY = y;
                    break;
                case SelectedPoint.F:
                    F.PointX = x;
                    F.PointY = y;
                    break;

            }
        }



        #region Vertical horisontal


        /// <summary>
        /// Gets or sets a value indicating whether this instance is ab side vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is ab side vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Вертикаль AB ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsABSideVertical
        {
            get { return _IsABSideVertical; }
            set
            {
                SetField(ref _IsABSideVertical, value, () => IsABSideVertical);
                if (IsABSideVertical)
                {
                    A.PointX = B.PointX;
                    IsABSideVertical = false;
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is bc side vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is bc side vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Вертикаль BC ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsBCSideVertical
        {
            get { return _IsBCSideVertical; }
            set
            {
                SetField(ref _IsBCSideVertical, value, () => IsBCSideVertical);
                if (IsBCSideVertical)
                {
                    C.PointX = B.PointX;
                    IsBCSideVertical = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is cd side vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is cd side vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Вертикаль CD ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsCDSideVertical
        {
            get { return _IsCDSideVertical; }
            set
            {
                SetField(ref _IsCDSideVertical, value, () => IsCDSideVertical);
                if (IsCDSideVertical)
                {
                    if (D.PointY != C.PointY)
                    {
                        C.PointX = D.PointX;
                    }

                    IsCDSideVertical = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is de side vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is de side vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Вертикаль DE ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsDESideVertical
        {
            get { return _IsDESideVertical; }
            set
            {
                SetField(ref _IsDESideVertical, value, () => IsDESideVertical);
                if (IsDESideVertical)
                {
                    if (D.PointY != E.PointY)
                    {
                        D.PointX = E.PointX;
                    }
                    IsDESideVertical = false;
                }
            }
        }
        ///<summary>
        /// Gets or sets a value indicating whether this instance is ef side vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is ef side vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Вертикаль EF ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsEFSideVertical
        {
            get { return _IsEFSideVertical; }
            set
            {
                SetField(ref _IsEFSideVertical, value, () => IsEFSideVertical);
                if (IsEFSideVertical)
                {
                    F.PointX = E.PointX;
                    IsEFSideVertical = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is af side vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is af side vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Вертикаль AF ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsAFSideVertical
        {
            get { return _IsEFSideVertical; }
            set
            {
                SetField(ref _IsAFSideVertical, value, () => IsAFSideVertical);
                if (IsAFSideVertical)
                {
                    A.PointX = F.PointX;
                    IsAFSideVertical = false;
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is ab side horisontal.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is ab side horisontal; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Горизонталь AB ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsABSideHorisontal
        {
            get { return _IsABSideHorisontal; }
            set
            {
                SetField(ref _IsABSideHorisontal, value, () => IsABSideHorisontal);
                if (IsABSideHorisontal)
                {
                    B.PointY = A.PointY;
                    IsABSideHorisontal = false;
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is de side horisontal.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is de side horisontal; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Горизонталь DE ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsDESideHorisontal
        {
            get { return _IsDESideHorisontal; }
            set
            {
                SetField(ref _IsDESideHorisontal, value, () => IsDESideHorisontal);
                if (IsDESideHorisontal)
                {
                    E.PointY = D.PointY;
                    IsDESideHorisontal = false;
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is cd side horisontal.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is cd side horisontal; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Горизонталь CD ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsCDSideHorisontal
        {
            get { return _IsCDSideHorisontal; }
            set
            {
                SetField(ref _IsCDSideHorisontal, value, () => IsCDSideHorisontal);
                if (IsCDSideHorisontal)
                {
                    C.PointY = D.PointY;
                    IsCDSideHorisontal = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is af side horisontal.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is af side horisontal; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Горизонталь AF ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsAFSideHorisontal
        {
            get { return _IsAFSideHorisontal; }
            set
            {
                SetField(ref _IsAFSideHorisontal, value, () => IsAFSideHorisontal);
                if (IsAFSideHorisontal)
                {
                    F.PointY = A.PointY;
                    IsAFSideHorisontal = false;
                }
            }
        }

        #endregion

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
            FCheck.PointX = F.PointX;
            FCheck.PointY = F.PointY;
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
            double diag6 = 0;
            double diag61 = 0;

            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == false && _CheckCut2 >= 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == false && _CheckCut3 >= 0) ? _CheckCut3 * (-1) : _CheckCut3;
            _CheckCut4 = (IsToothVector == false && _CheckCut4 >= 0) ? _CheckCut4 * (-1) : _CheckCut4;
            _CheckCut5 = (IsToothVector == false && _CheckCut5 >= 0) ? _CheckCut5 * (-1) : _CheckCut5;
            _CheckCut6 = (IsToothVector == false && _CheckCut6 >= 0) ? _CheckCut6 * (-1) : _CheckCut6;

            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == true && _CheckCut2 < 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == true && _CheckCut3 < 0) ? _CheckCut3 * (-1) : _CheckCut3;
            _CheckCut4 = (IsToothVector == true && _CheckCut4 < 0) ? _CheckCut4 * (-1) : _CheckCut4;
            _CheckCut5 = (IsToothVector == true && _CheckCut5 < 0) ? _CheckCut5 * (-1) : _CheckCut5;
            _CheckCut6 = (IsToothVector == true && _CheckCut6 < 0) ? _CheckCut6 * (-1) : _CheckCut6;

            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(F, A, B) * Math.PI / 180) :
               _CheckCut1 / (90 - ((180 - Math.Sin(CalculateAngle(F, A, B)) * Math.PI / 180)));
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
            diag41 = (diag41 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(D, E, F) * Math.PI / 180) :
               _CheckCut4 / (90 - ((180 - Math.Sin(CalculateAngle(D, E, F)) * Math.PI / 180)));

            diag5 = (diag5 <= 90) ? _CheckCut5 / Math.Sin(CalculateAngle(D, E, F) * Math.PI / 180) :
               _CheckCut5 / (90 - ((180 - Math.Sin(CalculateAngle(D, E, F)) * Math.PI / 180)));
            diag51 = (diag51 <= 90) ? _CheckCut5 / Math.Sin(CalculateAngle(E, F, A) * Math.PI / 180) :
             _CheckCut5 / (90 - ((180 - Math.Sin(CalculateAngle(E, F, A)) * Math.PI / 180)));

            diag6 = (diag6 <= 90) ? _CheckCut6 / Math.Sin(CalculateAngle(E, F, A) * Math.PI / 180) :
             _CheckCut6 / (90 - ((180 - Math.Sin(CalculateAngle(E, F, A)) * Math.PI / 180)));
            diag61 = (diag61 <= 90) ? _CheckCut6 / Math.Sin(CalculateAngle(F, A, B) * Math.PI / 180) :
              _CheckCut6 / (90 - ((180 - Math.Sin(CalculateAngle(F, A, B)) * Math.PI / 180)));
            /*1*/
            double F_Check_Line_Length = F_Check_Line.Length;
            double B_Check_Line_Length = B_Check_Line.Length;
            ACheck.PointY = SetCurrentLineLength(FCheck, A, diag1 + F_Check_Line_Length).PointY;
            ACheck.PointX = SetCurrentLineLength(FCheck, A, diag1 + F_Check_Line_Length).PointX;
            BCheck.PointY = SetCurrentLineLength(CCheck, B, diag11 + B_Check_Line_Length).PointY;
            BCheck.PointX = SetCurrentLineLength(CCheck, B, diag11 + B_Check_Line_Length).PointX;

            /*2*/
            double A_Check_Line_Length = A_Check_Line.Length;
            double C_Check_Line_Length = C_Check_Line.Length;
            BCheck.PointY = SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line_Length).PointY;
            BCheck.PointX = SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line_Length).PointX;
            CCheck.PointY = SetCurrentLineLength(DCheck, CCheck, diag21 + C_Check_Line_Length).PointY;
            CCheck.PointX = SetCurrentLineLength(DCheck, CCheck, diag21 + C_Check_Line_Length).PointX;


            /*4*/
            //double C_Check_Line_Length1 = C_Check_Line.Length;
            //double E_Check_Line_Length = E_Check_Line.Length;
            DCheck.PointY = SetCurrentLineLength(CCheck, DCheck, diag4 + C_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(CCheck, DCheck, diag4 + C_Check_Line.Length).PointX;
            ECheck.PointY = SetCurrentLineLength(FCheck, ECheck, diag41 + E_Check_Line.Length).PointY;
            ECheck.PointX = SetCurrentLineLength(FCheck, ECheck, diag41 + E_Check_Line.Length).PointX;





            /*5*/
            double D_Check_Line_Length1 = D_Check_Line.Length;
            double F_Check_Line_Length1 = F_Check_Line.Length;
            ECheck.PointX = SetCurrentLineLength(DCheck, ECheck, diag5 + D_Check_Line_Length1).PointX;
            ECheck.PointY = SetCurrentLineLength(DCheck, ECheck, diag5 + D_Check_Line_Length1).PointY;
            FCheck.PointX = SetCurrentLineLength(ACheck, FCheck, diag51 + F_Check_Line_Length1).PointX;
            FCheck.PointY = SetCurrentLineLength(ACheck, FCheck, diag51 + F_Check_Line_Length1).PointY;

            /*3*/
            double D_Check_Line_Length = D_Check_Line.Length;
            double B_Check_Line_Length1 = B_Check_Line.Length;
            CCheck.PointY = SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointX;
            DCheck.PointY = SetCurrentLineLength(ECheck, DCheck, diag31 + D_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(ECheck, DCheck, diag31 + D_Check_Line.Length).PointX;





            /*6*/
            //double E_Check_Line_Length1 = E_Check_Line.Length;
            //double A_Check_Line_Length1 = A_Check_Line.Length;
            FCheck.PointY = SetCurrentLineLength(ECheck, FCheck, diag6 + E_Check_Line.Length).PointY;
            FCheck.PointX = SetCurrentLineLength(ECheck, FCheck, diag6 + E_Check_Line.Length).PointX;
            ACheck.PointY = SetCurrentLineLength(BCheck, ACheck, diag61 + A_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(BCheck, ACheck, diag61 + A_Check_Line.Length).PointX;

            PointF[] cutPoints = new PointF[] { ACheck, BCheck, CCheck, DCheck, ECheck, FCheck };
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
                    graphicsShape.DrawLine(pen5, ECheck, FCheck);
                }
                using (pen6 = new Pen(SelectMainLineColor6(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen6, FCheck, ACheck);
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
                    graphicsShape.DrawLine(pen5, ECheck, FCheck);
                }
                using (pen6 = new Pen(SelectMainLineColor6(), ThiсknessArgument / 2))
                {
                    pen6.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen6, FCheck, ACheck);
                }
                IsToothVector = false;
            }
            GetExtremumPoints();
        }


        #endregion

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
            F.PointName = "F";
            List<ShapePoint> customPoints = new List<ShapePoint>() { A, B, C, D, E, F };
            return customPoints;
        }
        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string points = string.Format("A {0} , B {1} , C {2} , D {3},E{4} ,F{5}\n", A.ToString(), B.ToString(), C.ToString(), D.ToString(), E.ToString(), F.ToString());
            string lines = string.Format(" AB ={0} ; BC={1} ; CD ={2} ; DE={3} ; EF={4}; AF={5}\n ", A_line.Length, B_line.Length, C_line.Length, D_line.Length, E_line.Length, F_line.Length);
            string otherParameters = string.Format(" Периметр = {0} ; Площадь ={1}\n ", this.Perimeter, this.Area);
            string otherParameters1 = string.Format(" Угол FAB = {0},Угол ABC = {1},Угол BCD = {2},Угол CDE = {3} ,Угол DEF = {4} ,Угол EFA = {5}  \n ",
                CalculateAngle(F, A, B), CalculateAngle(A, B, C), CalculateAngle(B, C, D), CalculateAngle(C, D, E), CalculateAngle(D, E, F), CalculateAngle(E, F, A));
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
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut6");
                e.Properties = filteredCollection;
            }
        }

    }
}
