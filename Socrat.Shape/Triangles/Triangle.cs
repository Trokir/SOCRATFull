/* Для фигур 43,44, 20,62*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;
namespace Socrat.Shape
{

    /// <summary>
    /// Класс треугольник
    /// </summary>
    public partial class Triangle : BaseShape
    {
        private double _SetMoveByTopSideValue;
        private double _SetBottomSideValue;
        private double _SetLeftSideValue;
        private double _SetRightSideValue;
        private bool _IsDrawTriangleByAngleValue;
        private double _SetA_angleValue;
        private bool _IsBottomSideHorizontal;
        private double _SemiCircle;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="Core.Entities.ShapePoints">The custom points.</param>
        /// <ePointXception cref="ArgumentEPointXception">Заданные координаты не должны совпадать</ePointXception>
        public Triangle(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

            ShapePoint[] points = new ShapePoint[] { A = GetNewPoint(), B = GetNewPoint(), C = GetNewPoint() };
           // SelectedSides = new int[] { 0, 0, 0 };

            try
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].PointX =(float) ShapePoints[i].PointX;
                    points[i].PointY = (float)ShapePoints[i].PointY;
                    points[i].PointRadius = ShapePoints[i].PointRadius ?? 0F;
                }
            }
            catch (Exception)
            {
                // throw new EPointXception("Нет данных");
            }

            /*Init points*/


            /*Init lines*/
            A_line = new Line(A, B);
            B_line = new Line(B, C);
            C_line = new Line(A, C);
            SetA_radius = A.PointRadius??0;
            SetB_radius = B.PointRadius??0;
            SetC_radius = C.PointRadius??0;
            A_Check_Line = GetNewLine(ACheck, BCheck);
            B_Check_Line = GetNewLine(BCheck, CCheck);
            C_Check_Line = GetNewLine(CCheck, ACheck);
            GetCurrentParameters(currentShapeParametersList);
        }


        #region Perimeter Area Moving

        public override void SelectClickedSide(int xCoord, int yCoord, bool flag)
        {
            System.Drawing.Point point = new System.Drawing.Point(xCoord, yCoord);
            if (ThicknessPath(A, B).IsVisible(point))
            {
                if (flag) { ColorMarker1 = "rowCheckCut1"; SelectedSides.SetValue(1, 0);
                    ClickedSelectSide = 1;
                    SelectedSidesLength += A_line.Length;
                }
                else { ColorMarker1 = ""; SelectedSides.SetValue(0, 0); ClickedSelectSide = 0; SelectedSidesLength -= A_line.Length; }
            }
            if (ThicknessPath(B, C).IsVisible(point))
            {
                if (flag) { ColorMarker2 = "rowCheckCut2"; SelectedSides.SetValue(2, 1); ClickedSelectSide = 2; SelectedSidesLength += B_line.Length; }
                else { ColorMarker2 = ""; SelectedSides.SetValue(0, 1); ClickedSelectSide = 0; SelectedSidesLength -= B_line.Length; }
            }
            if (ThicknessPath(C, A).IsVisible(point))
            {
                if (flag) { ColorMarker3 = "rowCheckCut3"; SelectedSides.SetValue(3, 2); ClickedSelectSide = 3; SelectedSidesLength += C_line.Length; }
                else { ColorMarker3 = ""; SelectedSides.SetValue(0, 2); ClickedSelectSide = 0; SelectedSidesLength -= C_line.Length; }
            }
           
            else return;
        }

        public override void CalculateSelectedSideLength(List<int> sideNums)
        {
            SelectedSidesLength=0;
            foreach (int sideNum in sideNums)
            {
                     if (sideNum == 1) { SelectedSidesLength += A_line.Length; }
                else if (sideNum == 2) { SelectedSidesLength += B_line.Length; }
                else if (sideNum == 3) { SelectedSidesLength += C_line.Length; }
            }
        }




        /// <summary>
        ///   Площадь
        /// </summary>
        public override double Area
        {
            get
            {
                Line ura = GetNewLine(C1, C);
                Line urb = GetNewLine(C2, C);
                Line urc = GetNewLine(C1, C2);
                double CAngle = (CalculateAngle(B, C, A) <= 90 ? CalculateAngle(B, C, A) : 180 - CalculateAngle(B, C, A)) / 180;
                double urTriangle = Math.Round(Math.Sqrt(((ura.Length + urb.Length + urc.Length) / 2) *
                    (((ura.Length + urb.Length + urc.Length) / 2) - ura.Length) *
                    (((ura.Length + urb.Length + urc.Length) / 2) - urb.Length) *
                    (((ura.Length + urb.Length + urc.Length) / 2) - urc.Length)), 2) -
                     ((Math.Pow(SetC_radius, 2) / 2) * (Math.PI * CAngle * Math.PI / 180 - Math.Sin(CAngle * Math.PI / 180)));
                Line ula = GetNewLine(B2, B);
                Line ulb = GetNewLine(B1, B);
                Line ulc = GetNewLine(B1, B2);
                double BAngle = (CalculateAngle(A, B, C) <= 90 ? CalculateAngle(A, B, C) : 180 - CalculateAngle(A, B, C)) / 180;
                double ulTriangle = Math.Round(Math.Sqrt(((ula.Length + ulb.Length + ulc.Length) / 2) *
                   (((ula.Length + ulb.Length + ulc.Length) / 2) - ula.Length) *
                   (((ula.Length + ulb.Length + ulc.Length) / 2) - ulb.Length) *
                   (((ula.Length + ulb.Length + ulc.Length) / 2) - ulc.Length)), 2) -
                   (Math.Pow(SetB_radius, 2) / 2) * (Math.PI * BAngle * Math.PI / 180 -
                    Math.Sin(BAngle * Math.PI / 180));
                Line lla = GetNewLine(A2, A);
                Line llb = GetNewLine(A1, A);
                Line llc = GetNewLine(A1, A2);
                double llTriangle = Math.Round(Math.Sqrt(((lla.Length + llb.Length + llc.Length) / 2) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - lla.Length) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - llb.Length) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - llc.Length)), 2) -
                  (Math.Pow(SetA_radius, 2) / 2) * (Math.PI *
                  ((CalculateAngle(C, A, B) <= 90 ? (CalculateAngle(C, A, B) * Math.PI / 180) : 180 - CalculateAngle(C, A, B) * Math.PI / 180) / 180) -
                  Math.Sin((CalculateAngle(C, A, B) * Math.PI / 180)));
                double p = (A_line.Length + B_line.Length + C_line.Length) / 2;
                double baseSquare = 0.5 * Math.Abs((A.PointX * B.PointY + B.PointX * C.PointY + C.PointX * A.PointY) - (B.PointX * A.PointY + C.PointX * B.PointY + A.PointX * C.PointY));
                return Math.Round((baseSquare - Math.Abs(ulTriangle) - Math.Abs(urTriangle) - Math.Abs(llTriangle)) / 1000000,3);
            }
        }
        public override double TrueArea
        {
            get
            {

                double baseSquare = 0.5 * Math.Abs((ACheck.PointX * BCheck.PointY + BCheck.PointX * CCheck.PointY + CCheck.PointX * ACheck.PointY) - 
                    (BCheck.PointX * ACheck.PointY + CCheck.PointX * BCheck.PointY + ACheck.PointX * CCheck.PointY));

                return Math.Round(baseSquare / 1000000,3);
            }
        }

        /// <summary>
        /// Периметр
        /// </summary>
        public override double Perimeter
        {
            get
            {
                Line a = GetNewLine(A1, B2);
                Line b = GetNewLine(B1, C1);
                Line c = GetNewLine(C2, A1);
                double upperLeftArc = SetB_radius * Math.PI * (CalculateAngle(A, B, C) <= 90 ? CalculateAngle(A, B, C) : 180 - CalculateAngle(A, B, C)) / 180;
                double upperRightArc = SetC_radius * Math.PI * (CalculateAngle(B, C, A) <= 90 ? CalculateAngle(B, C, A) : 180 - CalculateAngle(B, C, A)) / 180;
                double lowerLeftArc = SetA_radius * Math.PI * (CalculateAngle(C, A, B) <= 90 ? CalculateAngle(C, A, B) : 180 - CalculateAngle(C, A, B)) / 180;
                return Math.Round((upperLeftArc + upperRightArc + lowerLeftArc + a.Length + b.Length + c.Length)/ 1000, 3);
            }
        }

        #region Heights        

        /// <summary>
        /// Gets the height a.
        /// </summary>
        /// <value>
        /// The height a.
        /// </value>

        [Browsable(false)]
        public virtual double HeightA
        {
            get
            {
                double p = (A_line.Length + B_line.Length + C_line.Length) / 2;
                return Math.Round(((2 * Math.Sqrt(p * (p - A_line.Length) * (p - B_line.Length) * (p - C_line.Length))) / A_line.Length), 2);
            }
            set { }
        }
        /// <summary>
        /// Gets the height b.
        /// </summary>
        /// <value>
        /// The height b.
        /// </value>

        [Browsable(false)]
        public virtual double HeightB
        {
            get
            {
                double p = (A_line.Length + B_line.Length + C_line.Length) / 2;
                return Math.Round(((2 * Math.Sqrt(p * (p - A_line.Length) * (p - B_line.Length) * (p - C_line.Length))) / B_line.Length), 2);
            }
        }
        /// <summary>
        /// Gets the height c.
        /// </summary>
        /// <value>
        /// The height c.
        /// </value>
        [Browsable(false)]
        public virtual double HeightC
        {
            get
            {
                double p = (A_line.Length + B_line.Length + C_line.Length) / 2;
                return Math.Round(((2 * Math.Sqrt(p * (p - A_line.Length) * (p - B_line.Length) * (p - C_line.Length))) / C_line.Length), 2);
            }
        }

        #endregion

        /// <summary>
        /// Перемещение фигуры по форме
        /// </summary>
        /// <param name="PointX"></param>
        /// <param name="y"></param>
        public override void Move(double x = 0, double y = 0)
        {
            //Move to PointX coord
            A.PointX += x;
            B.PointX += x;
            C.PointX += x;
           
            //Move to Y coord
            A.PointY += y;
            B.PointY += y;
            C.PointY += y;
           

        }
     
       
        /// <summary>
        /// Масштабирование(по умолчанию 10%)
        /// </summary>
        /// <param name="factor"></param>
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

          

        }

        /// <summary>
        /// Вращение вокруг центра тяжести
        /// </summary>
        public override void Rotate()
        {

            double angle = Math.Abs(CalculateAngle(B, C, A));
            ShapePoint[] points = new ShapePoint[] { A, B, C };

            CenterPoint.PointX = (A.PointX + B.PointX + C.PointX) / 3;
            CenterPoint.PointY = (A.PointY + B.PointY + C.PointY) / 3;

            #region Change koord
            TempPoint.PointX = A.PointX;
            TempPoint.PointY = A.PointY;
            A.PointX = C.PointX;
            A.PointY = C.PointY;
            C.PointX = TempPoint.PointX;
            C.PointY = TempPoint.PointY;


            TempPoint.PointX = B.PointX;
            TempPoint.PointY = B.PointY;
            B.PointX = C.PointX;
            B.PointY = C.PointY;
            C.PointX = TempPoint.PointX;
            C.PointY = TempPoint.PointY;
            #endregion

            foreach (ShapePoint point in points)
            {
                double newPointX = (point.PointX - CenterPoint.PointX) * Math.Cos(((180 - angle) * Math.PI / 180)) - (point.PointY - CenterPoint.PointY) * Math.Sin(((180 - angle) * Math.PI / 180)) + CenterPoint.PointX;
                double newY = (point.PointX - CenterPoint.PointX) * Math.Sin(((180 - angle) * Math.PI / 180)) + (point.PointY - CenterPoint.PointY) * Math.Cos(((180 - angle) * Math.PI / 180)) + CenterPoint.PointY;
                point.PointX = newPointX;
                point.PointY = newY;
            }
        }

        /// <summary>
        /// Gets or sets the set move by top side value.
        /// </summary>
        /// <value>
        /// The set move by top side value.
        /// </value>
        [DisplayName("L1")]
        [Category("Size")]
        [Display(GroupName = "Установка размеров")]
        public double SetMoveByTopSideValue
        {
            get { return _SetMoveByTopSideValue; }
            set
            {
                SetField(ref _SetMoveByTopSideValue, value, () => SetMoveByTopSideValue);

                B.PointX += _SetMoveByTopSideValue;
            }
        }

        /// <summary>
        /// Gets or sets the set bottom side value.
        /// </summary>
        /// <value>
        /// The set bottom side value.
        /// </value>
        [DisplayName("CA -L")]
        [Category("Size")]
        [Display(GroupName = "Установка размеров")]
        public double SetBottomSideValue
        {
            get { return Math.Round(C_line.Length, 0); }
            set
            {
                SetField(ref _SetBottomSideValue, value, () => SetBottomSideValue);
                C.PointX = SetCurrentLineLength(A, C, _SetBottomSideValue).PointX;
                C.PointY = SetCurrentLineLength(A, C, _SetBottomSideValue).PointY;
            }
        }


        /// <summary>
        /// Gets or sets the set left side value.
        /// </summary>
        /// <value>
        /// The set left side value.
        /// </value>
        [DisplayName("AB -H")]
        [Category("Size")]
        [Display(GroupName = "Установка размеров")]
        public double SetLeftSideValue
        {
            get { return Math.Round(A_line.Length, 0); }
            set
            {
                SetField(ref _SetLeftSideValue, value, () => SetLeftSideValue);
                double a = Math.Pow(_SetLeftSideValue, 2);
                double c = Math.Pow(C_line.Length, 2);
                double b = Math.Pow(B_line.Length, 2);
                double re = 2 * _SetLeftSideValue * C_line.Length;
                double alpha = Math.Acos((a + c - b) / re);
                if (_SetRightSideValue >= B_line.Length + C_line.Length)
                {
                    _SetRightSideValue = B_line.Length + C_line.Length;
                }
                else
                {
                    B.PointX = (C.PointX - A.PointX) * Math.Cos(-alpha) + (C.PointY - A.PointY) * Math.Sin(-alpha) + A.PointX;
                    B.PointY = (C.PointX - A.PointX) * Math.Sin(-alpha) - (C.PointY - A.PointY) * Math.Cos(-alpha) + A.PointY;
                    B.PointX = SetCurrentLineLength(A, B, _SetLeftSideValue).PointX;
                    B.PointY = SetCurrentLineLength(A, B, _SetLeftSideValue).PointY;
                }




            }
        }


        /// <summary>
        /// Gets or sets the set right side value.
        /// </summary>
        /// <value>
        /// The set right side value.
        /// </value>
        [DisplayName("BC -H")]
        [Category("Size")]
        [Display(GroupName = "Установка размеров")]
        public double SetRightSideValue
        {
            get { return Math.Round(B_line.Length, 0); }
            set
            {
                SetField(ref _SetRightSideValue, value, () => SetRightSideValue);
                double a = Math.Pow(A_line.Length, 2);
                double c = Math.Pow(C_line.Length, 2);
                double b = Math.Pow(_SetRightSideValue, 2);
                double re = 2 * _SetRightSideValue * C_line.Length;
                double alpha = Math.Acos((b + c - a) / re);

                if (_SetRightSideValue >= A_line.Length + C_line.Length)
                {
                    _SetRightSideValue = A_line.Length + C_line.Length;
                }
                else
                {

                    B.PointX = (A.PointX - C.PointX) * Math.Cos(alpha) + (A.PointY - C.PointY) * Math.Sin(alpha) + C.PointX;
                    B.PointY = (A.PointX - C.PointX) * Math.Sin(alpha) - (A.PointY - C.PointY) * Math.Cos(alpha) + C.PointY;
                    B.PointX = SetCurrentLineLength(C, B, _SetRightSideValue).PointX;
                    B.PointY = SetCurrentLineLength(C, B, _SetRightSideValue).PointY;
                }


            }
        }

        /// <summary>
        /// Gets or sets the set a angle value.
        /// </summary>
        /// <value>
        /// The set a angle value.
        /// </value>

        [DisplayName("Угол А")]
        [Category("По углам")]
        public double SetA_angleValue
        {
            get
            {

                return CalculateAngle(C, A, B);
            }
            set
            {
                if (_SetA_angleValue <= 0 && _SetA_angleValue >= 180)
                {
                    throw new Exception("Угол некорректный");
                }
                SetField(ref _SetA_angleValue, value, () => _SetA_angleValue);
                B.PointX = (C.PointX - A.PointX) * Math.Cos(-_SetA_angleValue * Math.PI / 180) - (C.PointY - A.PointY) * Math.Sin(-_SetA_angleValue * Math.PI / 180) + A.PointX;
                B.PointY = (C.PointX - A.PointX) * Math.Sin(-_SetA_angleValue * Math.PI / 180) + (C.PointY - A.PointY) * Math.Cos(-_SetA_angleValue * Math.PI / 180) + A.PointY;
            }
        }

        /// <summary>
        /// Gets or sets the set draw triangle by angle value.
        /// </summary>
        /// <value>
        /// The set draw triangle by angle value.
        /// </value>
        [DisplayName("Правильная фигура")]
        [Category("Size")]
        [Display(GroupName = "Установка размеров")]
        public bool IsDrawTriangleByAngleValue
        {
            get { return _IsDrawTriangleByAngleValue; }
            set
            {
                SetField(ref _IsDrawTriangleByAngleValue, value, () => IsDrawTriangleByAngleValue);
                if (!IsDrawTriangleByAngleValue) return;
                else
                {
                    C.PointX = SetCurrentLineLength(A, C, C_line.Length).PointX;
                    C.PointY = SetCurrentLineLength(A, C, C_line.Length).PointY;
                    B.PointX = (C.PointX - A.PointX) * Math.Cos(-1.0472) - (C.PointY - A.PointY) * Math.Sin(-1.0472) + A.PointX;
                    B.PointY = (C.PointX - A.PointX) * Math.Sin(-1.0472) + (C.PointY - A.PointY) * Math.Cos(-1.0472) + A.PointY;
                    IsDrawTriangleByAngleValue = false;
                }
            }
        }



        /// <summary>
        /// Gets or sets a value indicating whether this instance is semicircle.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is semicircle; otherwise, <c>false</c>.
        /// </value>

        [DisplayName("Полуокружность")]
        [Category("Size")]
        [Display(GroupName = "Установка размеров")]
        public double SemiCircle
        {
            get
            {
                return C_line.Length;
            }
            set
            {
                SetField(ref _SemiCircle, value, () => SemiCircle);

                B.PointX = (C.PointX - A.PointX) * Math.Cos(-0.7854) - (C.PointY - A.PointY) * Math.Sin(-0.7854) + A.PointX;
                B.PointY = (C.PointX - A.PointX) * Math.Sin(-0.7854) + (C.PointY - A.PointY) * Math.Cos(-0.7854) + A.PointY;

                TempPoint.PointX = A.PointX + (C.PointX - A.PointX) * (_SemiCircle / Math.Sqrt(Math.Pow((C.PointX - A.PointX), 2) + Math.Pow((C.PointY - A.PointY), 2)));
                TempPoint.PointY = A.PointY + (C.PointY - A.PointY) * (_SemiCircle / Math.Sqrt(Math.Pow((C.PointX - A.PointX), 2) + Math.Pow((C.PointY - A.PointY), 2)));
                C.PointX = SetCurrentLineLength(A, C, _SemiCircle).PointX;
                C.PointY = SetCurrentLineLength(A, C, _SemiCircle).PointY;
                double diag = Math.Sqrt(Math.Pow(C_line.Length, 2) / 2);
                TempPoint.PointX = A.PointX + (B.PointX - A.PointX) * (diag / Math.Sqrt(Math.Pow((B.PointX - A.PointX), 2) + Math.Pow((B.PointY - A.PointY), 2)));
                TempPoint.PointY = A.PointY + (B.PointY - A.PointY) * (diag / Math.Sqrt(Math.Pow((B.PointX - A.PointX), 2) + Math.Pow((B.PointY - A.PointY), 2)));
                B.PointX = SetCurrentLineLength(A, B, diag).PointX;
                B.PointY = SetCurrentLineLength(A, B, diag).PointY;




                SetB_radius = (float)B_line.Length / 2;


            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is bottom side horizontal.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is bottom side horizontal; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Горизонталь AC ")]
        [Category("Уст. сторон")]

        public bool IsBottomSideHorizontal
        {
            get { return _IsBottomSideHorizontal; }
            set
            {
                SetField(ref _IsBottomSideHorizontal, value, () => _IsBottomSideHorizontal);
                if (_IsBottomSideHorizontal)
                {
                    C.PointY = A.PointY;
                    _IsBottomSideHorizontal = false;
                }

            }
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

            }
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

            double diag1 = 0;
            double diag11 = 0;
            double diag2 = 0;
            double diag21 = 0;
            double diag3 = 0;
            double diag31 = 0;

            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == false && _CheckCut2 >= 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == false && _CheckCut3 >= 0) ? _CheckCut3 * (-1) : _CheckCut3;
          

            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == true && _CheckCut2 < 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == true && _CheckCut3 < 0) ? _CheckCut3 * (-1) : _CheckCut3;
          
            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(C, A, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(C, A, B)) * Math.PI / 180)));
            diag11 = (diag11 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));

            diag2 = (diag2 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut2 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag21 = (diag21 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(B, C, A) * Math.PI / 180) :
                (90 - ((180 - _CheckCut2 / Math.Sin(CalculateAngle(B, C, A)) * Math.PI / 180)));

            diag3 = (diag3 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(A, C, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut3 / Math.Sin(CalculateAngle(A, C, B)) * Math.PI / 180)));
            diag31 = (diag31 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(C, A, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut3 / Math.Sin(CalculateAngle(C, A, B)) * Math.PI / 180)));


            ACheck.PointY = SetCurrentLineLength(CCheck, ACheck, diag1 + C_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(CCheck, ACheck, diag1 + C_Check_Line.Length).PointX;
            BCheck.PointY = SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointX;

            BCheck.PointY = SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line.Length).PointX;
            CCheck.PointY = SetCurrentLineLength(ACheck, CCheck, diag21 + C_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(ACheck, CCheck, diag21 + C_Check_Line.Length).PointX;

            CCheck.PointY = SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointX;
            ACheck.PointY = SetCurrentLineLength(BCheck, ACheck, diag31 + A_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(BCheck, ACheck, diag31 + A_Check_Line.Length).PointX;

            PointF[] cutPoints = new PointF[] { ACheck, BCheck, CCheck};
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
                    graphicsShape.DrawLine(pen3, CCheck, ACheck);
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
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument/2))
                {
                    pen1.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen1, ACheck, BCheck);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument/2))
                {
                    pen2.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen2, BCheck, CCheck);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument/2))
                {
                    pen3.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen3, CCheck, ACheck);
                }
                IsToothVector = false;
            }
            GetExtremumPoints();
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

            List<ShapePoint> ShapePoints = new List<ShapePoint>() { A, B, C };
            return ShapePoints;
        }


        /// <summary>
        /// Customs the points list.
        /// </summary>
        /// <returns></returns>



        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string points = string.Format("A {0} , B {1} , C {2}  \n", A.ToString(), B.ToString(), C.ToString());
            string lines = string.Format(" AB ={0} ; BC={1} ; CA ={2} \n; ", A_line.Length, B_line.Length, C_line.Length);
            string otherParameters = string.Format("Периметр BAC = {0} ; Площадь = {1} \n", this.Perimeter, this.Area);
            string otherParameters1 = string.Format(" Угол CAB = {0} ; Угол ABC = {1} ; угол BCA ={2} \n",
               this.CalculateAngle(C, A, B), this.CalculateAngle(A, B, C), this.CalculateAngle(B, C, A));
            string heights = string.Format("Высота А ={0} Высота B ={1} Высота C ={2} \n", this.HeightA, this.HeightB, this.HeightC);

            return string.Format(points + lines + otherParameters + otherParameters1 + heights);
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
                e.Properties = filteredCollection;
            }
        }

    }
}
