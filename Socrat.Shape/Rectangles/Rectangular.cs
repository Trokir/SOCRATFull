using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows;
using System.Windows.Forms;

namespace Socrat.Shape
{
    /// <summary>
    /// Прямоугольник
    /// </summary>
    public partial class Rectangular : BaseShape
    {
        private bool _IsLeftSideVertical;
        private bool _IsRightSideVertical;
        private double _SetTopSideValue;
        private double _SetBottomSideValue;
        private double _SetLeftSideValue;
        private double _SetRightSideValue;
        private double _SetResizeFigureWidthValue;
        private double _SetMoveTopSideValue;
        private bool _IsDrawRectangleByAngleValue;
        private double _SetHeightValue;
        private double _SetWidthValue;
        private bool _IsBottomSideHorisontal;
        private bool _IsTopSideHorisontal;
        private double _SetRightDiffTopSide;
        private double _SetLeftDiffTopSide;
        private bool _IsHasFaultLine;
        private double _SetDiffBetwenA_B;
        protected bool _IsVerticalFaultLine;
        private bool _IsDrawFaultLine;

        public Rectangular(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
            ShapePoint[] points;
            //SelectedSides = new int[] { 0, 0, 0,0 };
            if (ShapePoints.Count > 4)
            {
                IsHasFaultLine = true;
                points = new ShapePoint[] { A = GetNewPoint(), B = GetNewPoint(),
                C = GetNewPoint(), D = GetNewPoint(),A_upFault =GetNewPoint(),A_downFault=GetNewPoint(),
                    B_upFault=GetNewPoint(),B_downFault=GetNewPoint()};
            }
            else
            {
                IsHasFaultLine = false;
                points = new ShapePoint[] { A = GetNewPoint(), B = GetNewPoint(),
                C = GetNewPoint(), D = GetNewPoint() };
            }

            try
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].PointX = (float)ShapePoints[i].PointX;
                    points[i].PointY = (float)ShapePoints[i].PointY;
                    points[i].PointRadius = ShapePoints[i].PointRadius;
                }
            }
            catch (Exception)
            {

                //  throw new EPointXception("Нет данных");
            }

            A_line = GetNewLine(A, B);
            B_line = GetNewLine(B, C);
            C_line = GetNewLine(C, D);
            D_line = GetNewLine(D, A);
            E_line = GetNewLine(A, C);
            A_Check_Line = GetNewLine(ACheck, BCheck);
            B_Check_Line = GetNewLine(BCheck, CCheck);
            C_Check_Line = GetNewLine(CCheck, DCheck);
            D_Check_Line = GetNewLine(DCheck, ACheck);
            SetA_radius = A.PointRadius ?? 0;
            SetB_radius = B.PointRadius ?? 0;
            SetC_radius = C.PointRadius ?? 0;
            SetD_radius = D.PointRadius ?? 0;
            GetCurrentParameters(currentShapeParametersList);

        }

      

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
            if (ThicknessPath(D, A).IsVisible(point))
            {
                if (flag) { ColorMarker4 = "rowCheckCut4"; SelectedSides.SetValue(4, 3); ClickedSelectSide = 4; SelectedSidesLength += D_line.Length; }
                else { ColorMarker4 = ""; SelectedSides.SetValue(0, 3); ClickedSelectSide = 0; SelectedSidesLength -= D_line.Length; }
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
            }
        }

        #region SetSizes

        /// <summary>
        /// Gets or sets a up fault.
        /// </summary>
        /// <value>
        /// a up fault.
        /// </value>
        [Browsable(false)]
        public ShapePoint A_upFault { get; set; }



        /// <summary>
        /// Gets or sets a down fault.
        /// </summary>
        /// <value>
        /// a down fault.
        /// </value>
        [Browsable(false)]
        public ShapePoint A_downFault { get; set; }
        /// <summary>
        /// Gets or sets the b up fault.
        /// </summary>
        /// <value>
        /// The b up fault.
        /// </value>
        [Browsable(false)]
        public ShapePoint B_upFault { get; set; }
        /// <summary>
        /// Gets or sets the b down fault.
        /// </summary>
        /// <value>
        /// The b down fault.
        /// </value>

        [Browsable(false)]
        public ShapePoint B_downFault { get; set; }
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
        /// Gets or sets a value indicating whether this instance is left side vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is left side vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Вертикаль_AB - H")]
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



        [DisplayName("Горизонталь_AD ")]
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
                    D.PointY = A.PointY;
                    IsBottomSideHorisontal = false;
                }
            }
        }




        [DisplayName("Горизонталь_BC ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsTopSideHorisontal
        {
            get { return _IsTopSideHorisontal; }
            set
            {
                SetField(ref _IsTopSideHorisontal, value, () => IsTopSideHorisontal);
                if (IsTopSideHorisontal)
                {
                    C.PointY = B.PointY;
                    IsTopSideHorisontal = false;
                }
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is right side vertical.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is right side vertical; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Вертикаль_CD - H")]
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
                    C.PointX = D.PointX;
                    IsRightSideVertical = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is draw rectangle by angle value.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is draw rectangle by angle value; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Правильная фигура ")]
        [Category("Correcting")]
        [Display(GroupName = "Установка вертикалей или горизонталей")]
        public bool IsDrawRectangleByAngleValue
        {
            get { return _IsDrawRectangleByAngleValue; }
            set
            {
                SetField(ref _IsDrawRectangleByAngleValue, value, () => IsDrawRectangleByAngleValue);
                if (!IsDrawRectangleByAngleValue) return;
                else
                {
                    D.PointY = A.PointY;
                    D.PointX = SetCurrentLineLength(A, D, D_line.Length).PointX;
                    D.PointY = SetCurrentLineLength(A, D, D_line.Length).PointY;
                    B.PointX = (D.PointX - A.PointX) * Math.Cos(-1.5708) - (D.PointY - A.PointY) * Math.Sin(-1.5708) + A.PointX;
                    B.PointY = (D.PointX - A.PointX) * Math.Sin(-1.5708) + (D.PointY - A.PointY) * Math.Cos(-1.5708) + A.PointY;
                    C.PointX = (A.PointX - B.PointX) * Math.Cos(-1.5708) - (A.PointY - B.PointY) * Math.Sin(-1.5708) + B.PointX;
                    C.PointY = (A.PointX - B.PointX) * Math.Sin(-1.5708) + (A.PointY - B.PointY) * Math.Cos(-1.5708) + B.PointY;

                    IsDrawRectangleByAngleValue = false;
                }
            }
        }


        /// <summary>
        /// Gets or sets the set move by top side value.
        /// </summary>
        /// <value>
        /// The set move by top side value.
        /// </value>
        [DisplayName("BC -L ")]
        [Category("Верхняя сторона")]
        [Display(GroupName = "Изменение размеров верхней стороны")]
        public double SetTopSideValue
        {
            get { return B_line.Length; }
            set
            {
                SetField(ref _SetTopSideValue, value, () => SetTopSideValue);
                if (!IsTopChangeVectorResizeValue)
                {
                    TempPoint.PointX = B.PointX + (C.PointX - B.PointX) * (_SetTopSideValue / Math.Sqrt(Math.Pow((C.PointX - B.PointX), 2) + Math.Pow((C.PointY - B.PointY), 2)));
                    TempPoint.PointY = B.PointY + (C.PointY - B.PointY) * (_SetTopSideValue / Math.Sqrt(Math.Pow((C.PointX - B.PointX), 2) + Math.Pow((C.PointY - B.PointY), 2)));
                    C.PointX = SetCurrentLineLength(B, C, _SetTopSideValue).PointX;
                    C.PointY = SetCurrentLineLength(B, C, _SetTopSideValue).PointY;
                }
                else
                {
                    ResizeTopFromRightSide(_SetTopSideValue);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is top change vector resize value.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is top change vector resize value; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Верх направление - H")]
        [Category("Верхняя сторона")]
        [Display(GroupName = "Изменение размеров верхней стороны")]
        public bool IsTopChangeVectorResizeValue { get; set; }

        [DisplayName("L1 - Слева ")]
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




        [DisplayName("L2 - Справа ")]
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
                B.PointX = SetCurrentLineLength(CenterPoint, C, (_SetRightDiffTopSide + 0.00001)).PointX;
                B.PointY = SetCurrentLineLength(CenterPoint, C, (_SetRightDiffTopSide + 0.00001)).PointY;
            }
        }



        /// <summary>
        /// Gets or sets the set height value.
        /// </summary>
        /// <value>
        /// The set height value.
        /// </value>
        [DisplayName("AB и CD -H")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetHeightValue
        {
            get { return A_line.Length; }
            set
            {
                SetField(ref _SetHeightValue, value, () => SetHeightValue);
                A.PointX = SetCurrentLineLength(B, A, _SetHeightValue).PointX;
                A.PointY = SetCurrentLineLength(B, A, _SetHeightValue).PointY;
                D.PointX = SetCurrentLineLength(C, D, _SetHeightValue).PointX;
                D.PointY = SetCurrentLineLength(C, D, _SetHeightValue).PointY;

            }
        }


        /// <summary>
        /// Gets or sets the set width value.
        /// </summary>
        /// <value>
        /// The set width value.
        /// </value>
        [DisplayName("AD и BC -L")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetWidthValue
        {
            get { return B_line.Length; }
            set
            {
                SetField(ref _SetWidthValue, value, () => SetWidthValue);
                C.PointX = SetCurrentLineLength(B, C, _SetWidthValue).PointX;
                C.PointY = SetCurrentLineLength(B, C, _SetWidthValue).PointY;
                D.PointX = SetCurrentLineLength(A, D, _SetWidthValue).PointX;
                D.PointY = SetCurrentLineLength(A, D, _SetWidthValue).PointY;

            }
        }

        /// <summary>
        /// Задание размера верхней стороны от правой стороны L1 по GPS
        /// </summary>
        /// <param name="factor">The factor.</param>
        /// <ePointXception cref="EPointXception">Некорректное значение</ePointXception>
        /// <summary>
        /// Задание размера верхней стороны от правой стороны L1 по GPS
        /// </summary>  
        /// <ePointXception cref="EPointXception">Некорректное значение</ePointXception>
        private void ResizeTopFromRightSide(double factor)
        {
            if (factor > 0 && factor < 4000)
            {
                B.PointX = SetCurrentLineLength(C, B, factor).PointX;
                B.PointY = SetCurrentLineLength(C, B, factor).PointY;

            }
        }




        /// <summary>
        /// Gets or sets the set bottom side value.
        /// </summary>
        /// <value>
        /// The set bottom side value.
        /// </value>
        [DisplayName("DA -H")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetBottomSideValue
        {
            get { return D_line.Length; }
            set
            {
                SetField(ref _SetBottomSideValue, value, () => SetBottomSideValue);
                if (_SetBottomSideValue > 0 && _SetBottomSideValue < 4000)
                {
                    D.PointX = SetCurrentLineLength(A, D, _SetBottomSideValue).PointX;
                    D.PointY = SetCurrentLineLength(A, D, _SetBottomSideValue).PointY;
                }
                else throw new Exception("Некорректное значение");

            }
        }


        /// <summary>
        /// Gets or sets the set left side value.
        /// </summary>
        /// <value>
        /// The set left side value.
        /// </value>
        [DisplayName("AB -H")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetLeftSideValue
        {
            get { return A_line.Length; }
            set
            {
                SetField(ref _SetLeftSideValue, value, () => SetLeftSideValue);
                B.PointX = SetCurrentLineLength(A, B, _SetLeftSideValue).PointX;
                B.PointY = SetCurrentLineLength(A, B, _SetLeftSideValue).PointY;
            }
        }



        /// <summary>
        /// Gets or sets the set right side value.
        /// </summary>
        /// <value>
        /// The set right side value.
        /// </value>
        [DisplayName("CD - H")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetRightSideValue
        {
            get { return C_line.Length; }
            set
            {
                SetField(ref _SetRightSideValue, value, () => SetRightSideValue);
                C.PointX = SetCurrentLineLength(D, C, _SetRightSideValue).PointX;
                C.PointY = SetCurrentLineLength(D, C, _SetRightSideValue).PointY;
            }
        }


        /// <summary>
        /// Gets or sets the width of the set resize figure.
        /// </summary>
        /// <value>
        /// The width of the set resize figure.
        /// </value>
        [DisplayName("Габаритный размер - H")]
        [Category("Стороны")]
        [Display(GroupName = "Изменение  размеров ")]
        public double SetResizeFigureWidthValue
        {
            get
            {
                ShapePoint habPoint = new ShapePoint(C.PointX, A.PointY);
                Line G_line = new Line(A, habPoint);

                return G_line.Length;
            }
            set
            {
                SetField(ref _SetResizeFigureWidthValue, value, () => SetResizeFigureWidthValue);
                ShapePoint habPoint = GetNewCustomPoint(C.PointX, A.PointY);
                Line G_line = GetNewLine(A, habPoint);
                TempPoint.PointX = A.PointX + (D.PointX - A.PointX) * (_SetResizeFigureWidthValue / Math.Sqrt(Math.Pow((D.PointX - A.PointX), 2) + Math.Pow((D.PointY - A.PointY), 2)));
                TempPoint.PointY = A.PointY;
                habPoint.PointX = TempPoint.PointX;
                habPoint.PointY = TempPoint.PointY;


                TempPoint.PointX = C.PointX;
                if (G_line.Length >= B_line.Length)
                {
                    C.PointX = habPoint.PointX;
                    B.PointX += (habPoint.PointX - TempPoint.PointX);
                }
                else
                {
                    MessageBox.Show("Размер должен быть больше текущей ширины.", "Error");
                    return;
                }
            }
        }

        /// <summary>
        /// Gets or sets the set move top side value.
        /// </summary>
        /// <value>
        /// The set move top side value.
        /// </value>
        [DisplayName("Сдвиг верхней стороны полностью (Лево-право) - L1")]
        [Category("Верхняя сторона")]
        [Display(GroupName = "Изменение размеров верхней стороны")]
        public double SetMoveTopSideValue
        {
            get { return _SetMoveTopSideValue; }
            set
            {
                SetField(ref _SetMoveTopSideValue, value, () => SetMoveTopSideValue);
                if (SetMoveTopSideValue > 0)
                {
                    B.PointX += _SetMoveTopSideValue;
                    C.PointX += _SetMoveTopSideValue;
                }
                else if (SetMoveTopSideValue < 0)
                {
                    MoveTopSideLeft(_SetMoveTopSideValue);
                }
                else return;
            }
        }





        /// <summary>
        /// Изменение ширины прямоугольника по координатам
        /// </summary>
        /// <param name="newWidth"></param>
        public virtual void ChangeWidth(double newWidth)
        {
            C.PointX = newWidth + B.PointX;
            D.PointX = newWidth + B.PointX;

        }


        /// <summary>
        /// Изменение длины прямоугольника по координатам
        /// </summary>
        /// <param name="newHeight"></param>
        public virtual void ChangeHeight(double newHeight)
        {
            B.PointY = newHeight;
            C.PointY = newHeight;

        }


        /// <summary>
        /// Задание L1 для фигуры 38 сдвиг влево
        /// </summary>
        /// <param name="factor"></param>
        private void MoveTopSideLeft(double factor)
        {

            B.PointX += factor;
            C.PointX += factor;

        }

        #region Линия разлома
        /// <summary>
        /// Есть ли линия разлома
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is has fault line; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool IsHasFaultLine
        {
            get { return _IsHasFaultLine; }
            set
            {
                SetField(ref _IsHasFaultLine, value, () => IsHasFaultLine);
            }
        }


        [DisplayName("Создать вертикальную линию разлома")]
        [Category("Разлом")]
        public virtual bool IsVerticalFaultLine
        {
            get { return _IsVerticalFaultLine; }
            set
            {
                SetField(ref _IsVerticalFaultLine, value, () => IsVerticalFaultLine);
                // IsDrawFaultLine = false;
                IsHasFaultLine = true;
                A_upFault = null;
                A_downFault = null;
                B_upFault = null;
                B_downFault = null;
                A_upFault = GetNewPoint();
                A_downFault = GetNewPoint();
                B_upFault = GetNewPoint();
                B_downFault = GetNewPoint();
                A_upFault.PointX = A.PointX + D_line.Length / 2;
                A_upFault.PointY = A.PointY;
                A_downFault.PointX = A_upFault.PointX;
                A_downFault.PointY = A_upFault.PointY;
                B_upFault.PointX = B.PointX + D_line.Length / 2;
                B_upFault.PointY = B.PointY;
                B_downFault.PointX = B_upFault.PointX;
                B_downFault.PointY = B_upFault.PointY;
            }
        }



        [DisplayName("Создать горизонтальную линию разлома")]
        [Category("Разлом")]

        public bool IsDrawFaultLine
        {
            get { return _IsDrawFaultLine; }
            set
            {
                SetField(ref _IsDrawFaultLine, value, () => IsDrawFaultLine);
                // IsVerticalFaultLine = false;
                IsHasFaultLine = true;
                A_upFault = null;
                A_downFault = null;
                B_upFault = null;
                B_downFault = null;
                A_upFault = GetNewPoint();
                A_downFault = GetNewPoint();
                B_upFault = GetNewPoint();
                B_downFault = GetNewPoint();
                A_upFault.PointX = A.PointX;
                A_upFault.PointY = A.PointY;
                A_downFault.PointX = A.PointX;
                A_downFault.PointY = A.PointY;
                B_upFault.PointX = D.PointX;
                B_upFault.PointY = D.PointY;
                B_downFault.PointX = D.PointX;
                B_downFault.PointY = D.PointY;

            }
        }



        protected double _SetH1_FaultLine_To_LeftSide;
        [DisplayName("H1 ")]
        [Category("Разлом")]

        public virtual double SetH1_FaultLine_To_LeftSide
        {
            get
            {

                //   _SetH1_FaultLine_To_LeftSide = A_line.Length - SetH2_FaultLine_To_LeftSide;
                return _SetH1_FaultLine_To_LeftSide;
            }
            set
            {
                //if (IsDrawFaultLine == true)
                //{
                SetField(ref _SetH1_FaultLine_To_LeftSide, value, () => SetH1_FaultLine_To_LeftSide);
                A_upFault.PointX = SetCurrentLineLength(A, B, _SetH1_FaultLine_To_LeftSide).PointX;
                A_upFault.PointY = SetCurrentLineLength(A, B, _SetH1_FaultLine_To_LeftSide).PointY;
                A_downFault.PointX = SetCurrentLineLength(A, B, _SetH1_FaultLine_To_LeftSide).PointX;
                A_downFault.PointY = SetCurrentLineLength(A, B, _SetH1_FaultLine_To_LeftSide).PointY;
                // }
            }
        }

        protected double _SetH1_FaultLine_To_RightSide;
        [DisplayName("H1 ")]
        [Category("Разлом")]

        public virtual double SetH1_FaultLine_To_RightSide
        {
            get { return _SetH1_FaultLine_To_RightSide; }
            set
            {
                //if (IsDrawFaultLine == true)
                //{
                SetField(ref _SetH1_FaultLine_To_RightSide, value, () => SetH1_FaultLine_To_RightSide);
                B_upFault.PointX = SetCurrentLineLength(D, C, _SetH1_FaultLine_To_RightSide).PointX;
                B_upFault.PointY = SetCurrentLineLength(D, C, _SetH1_FaultLine_To_RightSide).PointY;
                B_downFault.PointX = SetCurrentLineLength(D, C, _SetH1_FaultLine_To_RightSide).PointX;
                B_downFault.PointY = SetCurrentLineLength(D, C, _SetH1_FaultLine_To_RightSide).PointY;
                //  }
            }
        }


        protected double _SetH2_FaultLine_To_LeftSide;
        [DisplayName("H2 ")]
        [Category("Разлом")]

        public virtual double SetH2_FaultLine_To_LeftSide
        {
            get
            {
                //    _SetH2_FaultLine_To_LeftSide = A_line.Length - SetH1_FaultLine_To_LeftSide;
                return _SetH2_FaultLine_To_LeftSide;

            }
            set
            {
                //if (IsDrawFaultLine == true)
                //{
                CenterPoint.PointX = A.PointX;
                CenterPoint.PointY = A.PointY;
                SetField(ref _SetH2_FaultLine_To_LeftSide, value, () => SetH2_FaultLine_To_LeftSide);
                A_upFault.PointX = SetCurrentLineLength(B, CenterPoint, _SetH2_FaultLine_To_LeftSide).PointX;
                A_upFault.PointY = SetCurrentLineLength(B, CenterPoint, _SetH2_FaultLine_To_LeftSide).PointY;
                A_downFault.PointX = SetCurrentLineLength(B, CenterPoint, _SetH2_FaultLine_To_LeftSide).PointX;
                A_downFault.PointY = SetCurrentLineLength(B, CenterPoint, _SetH2_FaultLine_To_LeftSide).PointY;
                //  }
            }
        }
        protected double _SetH2_FaultLine_To_RightSide;
        [DisplayName("H2 ")]
        [Category("Разлом")]

        public virtual double SetH2_FaultLine_To_RightSide
        {
            get
            {
                //    _SetH2_FaultLine_To_LeftSide = A_line.Length - SetH1_FaultLine_To_LeftSide;
                return _SetH2_FaultLine_To_RightSide;

            }
            set
            {
                //if (IsDrawFaultLine == true)
                //{
                CenterPoint.PointX = D.PointX;
                CenterPoint.PointY = D.PointY;
                SetField(ref _SetH2_FaultLine_To_RightSide, value, () => SetH2_FaultLine_To_RightSide);
                B_upFault.PointX = SetCurrentLineLength(C, CenterPoint, _SetH2_FaultLine_To_RightSide).PointX;
                B_upFault.PointY = SetCurrentLineLength(C, CenterPoint, _SetH2_FaultLine_To_RightSide).PointY;
                B_downFault.PointX = SetCurrentLineLength(C, CenterPoint, _SetH2_FaultLine_To_RightSide).PointX;
                B_downFault.PointY = SetCurrentLineLength(C, CenterPoint, _SetH2_FaultLine_To_RightSide).PointY;
                // }
            }
        }



        [DisplayName("Создать разрыв")]
        // [Category("Разлом")]
        [Display(GroupName = "Разлом")]
        public virtual double SetDiffBetwenA_B
        {
            get { return _SetDiffBetwenA_B; }
            set { SetField(ref _SetDiffBetwenA_B, value, () => SetDiffBetwenA_B); }
        }



        #endregion

        #endregion






        #region Methods
        /// <summary>
        /// Расчет периметра прямоугольника
        /// </summary>
        public override double Perimeter
        {
            get
            {


                double upperLeftArc = SetB_radius * Math.PI * (CalculateAngle(A, B, C) <= 90 ? CalculateAngle(A, B, C) : 180 - CalculateAngle(A, B, C)) / 180;
                double upperRightArc = SetC_radius * Math.PI * (CalculateAngle(B, C, D) <= 90 ? CalculateAngle(B, C, D) : 180 - CalculateAngle(B, C, D)) / 180;
                double lowerLeftArc = SetA_radius * Math.PI * (CalculateAngle(D, A, B) <= 90 ? CalculateAngle(D, A, B) : 180 - CalculateAngle(D, A, B)) / 180;
                double lowerRighttArc = SetD_radius * Math.PI * (CalculateAngle(C, D, A) <= 90 ? CalculateAngle(C, D, A) : 180 - CalculateAngle(C, D, A)) / 180;
                Line a = GetNewLine(A1, B2);
                Line b = GetNewLine(B1, C1);
                Line c = GetNewLine(C2, D1);
                Line d = GetNewLine(D2, A2);
                return Math.Round((upperLeftArc + upperRightArc + lowerLeftArc + lowerRighttArc + a.Length + b.Length + c.Length + d.Length) / 1000, 3);
            }

        }

        //protected override double CalculateLowerLeftAngleForShpros()
        //{
        //    ShapePoint firstPoint = D;
        //    ShapePoint secondPoint = A;
        //    ShapePoint thirdPoint = B;
        //    double angleBetween = 0;
        //    Vector vector1 = new Vector((thirdPoint.PointX - secondPoint.PointX), (thirdPoint.PointY - secondPoint.PointY));
        //    Vector vector2 = new Vector((firstPoint.PointX - secondPoint.PointX), (firstPoint.PointY - secondPoint.PointY));
        //    angleBetween = Math.Abs(Vector.AngleBetween(vector1, vector2));
        //    return Math.Round(angleBetween, 1);
        //}

        /// <summary>
        /// Расчет площади прямоугольника
        /// </summary>
        public override double Area
        {
            get
            {

                E_line = GetNewLine(A, C);
                F_line = GetNewLine(B, D);
                Line ura = GetNewLine(C1, C);
                Line urb = GetNewLine(C2, C);
                Line urc = GetNewLine(C1, C2);
                double AAngle = (CalculateAngle(B, C, D) <= 90 ? CalculateAngle(B, C, D) : 180 - CalculateAngle(B, C, D)) / 180;
                double urTriangle = Math.Round(Math.Sqrt(((ura.Length + urb.Length + urc.Length) / 2) *
                    (((ura.Length + urb.Length + urc.Length) / 2) - ura.Length) *
                    (((ura.Length + urb.Length + urc.Length) / 2) - urb.Length) *
                    (((ura.Length + urb.Length + urc.Length) / 2) - urc.Length)), 2) -
                     ((Math.Pow(SetC_radius, 2) / 2) * (Math.PI * AAngle * Math.PI / 180 - Math.Sin(AAngle * Math.PI / 180)));


                Line ula = GetNewLine(B2, B);
                Line ulb = GetNewLine(B1, B);
                Line ulc = GetNewLine(B1, B2);
                double BAngle = (CalculateAngle(A, B, C) <= 90 ? CalculateAngle(A, B, C) : 180 - CalculateAngle(A, B, C)) / 180;
                double ulTriangle = Math.Round(Math.Sqrt(((ula.Length + ulb.Length + ulc.Length) / 2) *
                   (((ula.Length + ulb.Length + ulc.Length) / 2) - ula.Length) *
                   (((ula.Length + ulb.Length + ulc.Length) / 2) - ulb.Length) *
                   (((ula.Length + ulb.Length + ulc.Length) / 2) - ulc.Length)), 2) -
                   (Math.Pow(SetB_radius, 2) / 2) * (Math.PI * BAngle * Math.PI / 180 - Math.Sin(BAngle * Math.PI / 180));



                Line lla = GetNewLine(A2, A);
                Line llb = GetNewLine(A1, A);
                Line llc = GetNewLine(A1, A2);
                double AAnglle = (CalculateAngle(D, A, B) <= 90 ? CalculateAngle(D, A, B) : 180 - CalculateAngle(D, A, B)) / 180;
                double llTriangle = Math.Round(Math.Sqrt(((lla.Length + llb.Length + llc.Length) / 2) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - lla.Length) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - llb.Length) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - llc.Length)), 2) -
                  (Math.Pow(SetA_radius, 2) / 2) * (Math.PI * AAnglle * Math.PI / 180 - Math.Sin(AAnglle * Math.PI / 180));



                Line lra = GetNewLine(D2, D);
                Line lrb = GetNewLine(D1, D);
                Line lrc = GetNewLine(D1, D2);
                double DAngle = (CalculateAngle(C, D, A) <= 90 ? CalculateAngle(C, D, A) : 180 - CalculateAngle(C, D, A)) / 180;
                double lrTriangle = Math.Round(Math.Sqrt(((lra.Length + lrb.Length + lrc.Length) / 2) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lra.Length) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lrb.Length) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lrc.Length)), 2) -
                 (Math.Pow(SetD_radius, 2) / 2) * (Math.PI * DAngle * Math.PI / 180 - Math.Sin(DAngle * Math.PI / 180));
                double baseSquare = 0.5 * Math.Abs((A.PointX * B.PointY + B.PointX * C.PointY + C.PointX * D.PointY + D.PointX * A.PointY) - (B.PointX * A.PointY + C.PointX * B.PointY + D.PointX * C.PointY + A.PointX * D.PointY));
                return Math.Round((baseSquare - Math.Abs(ulTriangle) - Math.Abs(urTriangle) - Math.Abs(llTriangle) - Math.Abs(lrTriangle)) / 1000000, 3);
            }
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

        public override double TrueArea
        {
            get
            {

                double baseSquare = 0.5 * Math.Abs((ACheck.PointX * BCheck.PointY + BCheck.PointX * CCheck.PointY + CCheck.PointX * DCheck.PointY + DCheck.PointX * ACheck.PointY) -
                    (BCheck.PointX * ACheck.PointY + CCheck.PointX * BCheck.PointY + DCheck.PointX * CCheck.PointY + ACheck.PointX * DCheck.PointY));
                return Math.Round(baseSquare / 1000000, 3);
            }
        }



        /// <summary>
        /// Перемещение прямоугольника по оси Х или Y или по обеим осям
        /// </summary>
        /// <param name="PointX"></param>
        /// <param name="y"></param>
        public override void Move(double x = 0, double y = 0)
        {
            //Move to PointX coord
            A.PointX += x;
            B.PointX += x;
            C.PointX += x;
            D.PointX += x;

            ACheck.PointX += x;
            BCheck.PointX += x;
            CCheck.PointX += x;
            DCheck.PointX += x;
            //Move to Y coord
            A.PointY += y;
            B.PointY += y;
            C.PointY += y;
            D.PointY += y;

            ACheck.PointY += y;
            BCheck.PointY += y;
            CCheck.PointY += y;
            DCheck.PointY += y;
            if (IsHasFaultLine == true)
            {
                A_upFault.PointX += x;
                A_downFault.PointX += x;
                B_upFault.PointX += x;
                B_downFault.PointX += x;

                A_upFault.PointY += y;
                A_downFault.PointY += y;
                B_upFault.PointY += y;
                B_downFault.PointY += y;
            }
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

            TempPoint.PointX = A.PointX + (D.PointX - A.PointX) * factor;
            TempPoint.PointY = A.PointY + (D.PointY - A.PointY) * factor;
            D.PointX = TempPoint.PointX;
            D.PointY = TempPoint.PointY;
            if (IsHasFaultLine == true)
            {

                TempPoint.PointX = A.PointX + (A_downFault.PointX - A.PointX) * factor;
                TempPoint.PointY = A.PointY + (A_downFault.PointY - A.PointY) * factor;
                A_downFault.PointX = TempPoint.PointX;
                A_downFault.PointY = TempPoint.PointY;

                TempPoint.PointX = A.PointX + (B_downFault.PointX - A.PointX) * factor;
                TempPoint.PointY = A.PointY + (B_downFault.PointY - A.PointY) * factor;
                B_downFault.PointX = TempPoint.PointX;
                B_downFault.PointY = TempPoint.PointY;

                TempPoint.PointX = A.PointX + (A_upFault.PointX - A.PointX) * factor;
                TempPoint.PointY = A.PointY + (A_upFault.PointY - A.PointY) * factor;
                A_upFault.PointX = TempPoint.PointX;
                A_upFault.PointY = TempPoint.PointY;

                TempPoint.PointX = A.PointX + (B_upFault.PointX - A.PointX) * factor;
                TempPoint.PointY = A.PointY + (B_upFault.PointY - A.PointY) * factor;
                B_upFault.PointX = TempPoint.PointX;
                B_upFault.PointY = TempPoint.PointY;
            }
            #region Hz
            //TempPoint.PointX = A.PointX + (B.PointX - A.PointX) *
            //  (factor * A_line.Length / Math.Sqrt(Math.Pow((B.PointX - A.PointX), 2)
            //  + Math.Pow((B.Y - A.Y), 2)));

            //TempPoint.Y = A.Y + (B.Y - A.Y) *
            //    (factor * A_line.Length / Math.Sqrt(Math.Pow((B.PointX - A.PointX), 2)
            //    + Math.Pow((B.Y - A.Y), 2)));
            //B.PointX = TempPoint.PointX;
            //B.Y = TempPoint.Y;

            //TempPoint.PointX = A.PointX + (D.PointX - A.PointX) *
            //    (factor * D_line.Length / Math.Sqrt(Math.Pow((D.PointX - A.PointX), 2)
            //    + Math.Pow((D.Y - A.Y), 2)));

            //TempPoint.Y = A.Y + (D.Y - A.Y) *
            //    (factor * D_line.Length / Math.Sqrt(Math.Pow((D.PointX - A.PointX), 2)
            //    + Math.Pow((D.Y - A.Y), 2)));
            //D.PointX = TempPoint.PointX;
            //D.Y = TempPoint.Y;


            //TempPoint.PointX = B.PointX + (C.PointX - B.PointX) *
            //   (factor * B_line.Length / Math.Sqrt(Math.Pow((C.PointX - B.PointX), 2)
            //   + Math.Pow((C.Y - B.Y), 2)));

            //TempPoint.Y = D.Y + (C.Y - D.Y) *
            //    (factor * C_line.Length / Math.Sqrt(Math.Pow((C.PointX - D.PointX), 2)
            //    + Math.Pow((C.Y - D.Y), 2)));

            //C.PointX = TempPoint.PointX;
            //C.Y = TempPoint.Y;
            //#region Внутренний рез
            //if (IsHasFaultLine == true)
            //{

            //    Line a_upLine = GetNewLine(A, A_upFault);
            //    TempPoint.PointX = A.PointX + (A_upFault.PointX - A.PointX) *
            //     (factor * a_upLine.Length / Math.Sqrt(Math.Pow((A_upFault.PointX - A.PointX), 2)
            //     + Math.Pow((A_upFault.Y - A.Y), 2)));

            //    TempPoint.Y = A.Y + (A_upFault.Y - A.Y) *
            //        (factor * a_upLine.Length / Math.Sqrt(Math.Pow((A_upFault.PointX - A.PointX), 2)
            //        + Math.Pow((A_upFault.Y - A.Y), 2)));
            //    A_upFault.PointX = TempPoint.PointX;
            //    A_upFault.Y = TempPoint.Y;

            //    A_downFault.PointX = A_upFault.PointX;
            //    A_downFault.Y = A_upFault.Y + SetDiffBetwenA_B;
            //    TempPoint.PointX = D.PointX + (C.PointX - D.PointX) *
            //     (SetH1_FaultLine_To_RightSide / Math.Sqrt(Math.Pow((C.PointX - D.PointX), 2)
            //     + Math.Pow((C.Y - D.Y), 2)));

            //    TempPoint.Y = D.Y + (C.Y - D.Y) *
            //        (SetH1_FaultLine_To_RightSide / Math.Sqrt(Math.Pow((C.PointX - D.PointX), 2)
            //        + Math.Pow((C.Y - D.Y), 2)));

            //    B_upFault.PointX = TempPoint.PointX;
            //    B_upFault.Y = TempPoint.Y;

            //    B_downFault.PointX = B_upFault.PointX;
            //    B_downFault.Y = B_upFault.Y + SetDiffBetwenA_B;

            //}
            //#endregion
            #endregion
        }

        /// <summary>
        /// Поворот фигуры на текущий угол по часовой стрелке
        /// </summary>     
        public override void Rotate()
        {
            double angle = CalculateAngle(C, D, A);
            CenterPoint.PointX = (A.PointX + B.PointX + C.PointX + D.PointX) / 4;
            CenterPoint.PointY = (A.PointY + B.PointY + C.PointY + D.PointY) / 4;
            #region Rotate Base shape

            ShapePoint[] points = new ShapePoint[] { A, B, C, D };
            #region Change koord
            //  IsCanRotate = true;



            TempPoint.PointX = D.PointX;
            TempPoint.PointY = D.PointY;
            D.PointX = A.PointX;
            D.PointY = A.PointY;
            A.PointX = TempPoint.PointX;
            A.PointY = TempPoint.PointY;

            TempPoint.PointX = B.PointX;
            TempPoint.PointY = B.PointY;
            B.PointX = D.PointX;
            B.PointY = D.PointY;
            D.PointX = TempPoint.PointX;
            D.PointY = TempPoint.PointY;

            TempPoint.PointX = C.PointX;
            TempPoint.PointY = C.PointY;
            C.PointX = D.PointX;
            C.PointY = D.PointY;
            D.PointX = TempPoint.PointX;
            D.PointY = TempPoint.PointY;


            #endregion
            foreach (ShapePoint point in points)
            {
                double newPointX = (point.PointX - CenterPoint.PointX) * Math.Cos(((180 - angle) * Math.PI / 180)) - (point.PointY - CenterPoint.PointY) * Math.Sin(((180 - angle) * Math.PI / 180)) + CenterPoint.PointX;
                double newY = (point.PointX - CenterPoint.PointX) * Math.Sin(((180 - angle) * Math.PI / 180)) + (point.PointY - CenterPoint.PointY) * Math.Cos(((180 - angle) * Math.PI / 180)) + CenterPoint.PointY;
                point.PointX = newPointX;
                point.PointY = newY;
            }
            #endregion

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
            double diag2 = 0;
            double diag21 = 0;
            double diag3 = 0;
            double diag31 = 0;
            double diag4 = 0;
            double diag41 = 0;

            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == false && _CheckCut2 >= 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == false && _CheckCut3 >= 0) ? _CheckCut3 * (-1) : _CheckCut3;
            _CheckCut4 = (IsToothVector == false && _CheckCut4 >= 0) ? _CheckCut4 * (-1) : _CheckCut4;

            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == true && _CheckCut2 < 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == true && _CheckCut3 < 0) ? _CheckCut3 * (-1) : _CheckCut3;
            _CheckCut4 = (IsToothVector == true && _CheckCut4 < 0) ? _CheckCut4 * (-1) : _CheckCut4;


            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));
            diag11 = (diag11 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag2 = (diag2 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut2 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag21 = (diag21 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180) :
                (90 - ((180 - _CheckCut2 / Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));
            diag3 = (diag3 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180) :
                (90 - ((180 - _CheckCut3 / Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));
            diag31 = (diag31 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(C, D, A) * Math.PI / 180) :
                (90 - ((180 - _CheckCut3 / Math.Sin(CalculateAngle(C, D, A)) * Math.PI / 180)));
            diag4 = (diag4 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(C, D, A) * Math.PI / 180) :
                (90 - ((180 - _CheckCut4 / Math.Sin(CalculateAngle(C, D, A)) * Math.PI / 180)));
            diag41 = (diag41 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut4 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));

            ACheck.PointY = SetCurrentLineLength(DCheck, ACheck, diag1 + D_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(DCheck, ACheck, diag1 + D_Check_Line.Length).PointX;
            BCheck.PointY = SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointX;

            BCheck.PointY = SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line.Length).PointX;
            CCheck.PointY = SetCurrentLineLength(DCheck, CCheck, diag21 + C_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(DCheck, CCheck, diag21 + C_Check_Line.Length).PointX;

            CCheck.PointY = SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointX;
            DCheck.PointY = SetCurrentLineLength(ACheck, DCheck, diag31 + D_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(ACheck, DCheck, diag31 + D_Check_Line.Length).PointX;

            DCheck.PointY = SetCurrentLineLength(CCheck, DCheck, diag4 + C_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(CCheck, DCheck, diag4 + C_Check_Line.Length).PointX;
            ACheck.PointY = SetCurrentLineLength(BCheck, ACheck, diag41 + A_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(BCheck, ACheck, diag41 + A_Check_Line.Length).PointX;
            PointF[] cutPoints = new PointF[] { ACheck, BCheck, CCheck, DCheck };
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
                    graphicsShape.DrawLine(pen4, DCheck, ACheck);
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
                    graphicsShape.DrawLine(pen4, DCheck, ACheck);
                }
                IsToothVector = false;
            }

            GetExtremumPoints();
        }



        /// <summary>
        /// Gets the figure points.
        /// </summary>
        /// <returns></returns>
        public override System.Drawing.Point[] GetFigurePoints()
        {
            return new System.Drawing.Point[] { A, B, C, D };
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

            List<ShapePoint> ShapePoints;
            if (IsHasFaultLine == true)
            {
                A_upFault.PointName = "E1";
                A_downFault.PointName = "F1";
                B_upFault.PointName = "G1";
                B_downFault.PointName = "H1";

                ShapePoints = new List<ShapePoint>() { A, B, C, D, A_upFault, A_downFault, B_upFault, B_downFault };
            }
            else
            {

                ShapePoints = new List<ShapePoint>() { A, B, C, D };
            }
            /**/
            return ShapePoints;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string points = string.Format("A {0} , B {1} , C {2} , D {3} \n", A.ToString(), B.ToString(), C.ToString(), D.ToString());
            string lines = string.Format(" AB ={0} ; BC={1} ; CD ={2} ; DA ={3}\n ", A_line.Length, B_line.Length, C_line.Length, D_line.Length);
            string otherParameters = string.Format(" Периметр = {0} ; Площадь ={1}\n ", this.Perimeter, this.Area);
            string otherParameters1 = string.Format(" Угол DAC = {0},Угол ABC = {1},Угол BCD = {2},Угол CDA = {3} \n ",
                CalculateAngle(C, B, A), CalculateAngle(B, C, D), CalculateAngle(A, D, C), CalculateAngle(D, A, B));

            return string.Format(points + lines + otherParameters + otherParameters1);
        }
        public override void AddCustomParametersProperties(object sender, CustomPropertyDescriptorsEventArgs e)
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
                e.Properties = filteredCollection;
            }

        }

    }
}