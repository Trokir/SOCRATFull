using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.Shape
{
    #region Enum
    /// <summary>
    /// enum SelectedPoint
    /// </summary>
    public enum SelectedPoint
    {
        /// <summary>
        /// a
        /// </summary>
        [Description("A")]
        A,
        /// <summary>
        /// The b
        /// </summary>
        [Description("B")]
        B,
        /// <summary>
        /// The c
        /// </summary>
        [Description("C")]
        C,
        /// <summary>
        /// The d
        /// </summary>
        [Description("D")]
        D,
        /// <summary>
        /// The e
        /// </summary>
        [Description("E")]
        E,
        /// <summary>
        /// The f
        /// </summary>
        [Description("F")]
        F,
        /// <summary>
        /// The g
        /// </summary>
        [Description("G")]
        G,
        /// <summary>
        /// h
        /// </summary>
        [Description("H")]
        H
    }
    public enum Direction
    {
        Left,
        Right,
        Top,
        Bottom
    }
    public enum Orientation
    {
        Vertical,
        Horisontal
    }
    #endregion
    public abstract partial class BaseShape : PropertyChangedBase
    {
        #region Variables
        private SelectedPoint _SetPoint;
        protected double _SetB1;
        protected double _SetB2;
        protected double _SetB3;
        protected double _SetB4;
        protected double _SetH;
        protected double _SetH2;
        protected double _SetChord;
        protected double _SetL2;
        protected double _SetL1;
        protected double _SetL;
        protected double _SetH1;
        protected double _SetH_t;
        protected double _SetH1_t;
        protected double _SetH2_t;
        protected double _SetL_t;
        protected double _SetL1_t;
        protected double _SetL2_t;
        protected double _SetRadius;
        protected double _SetRadius1;
        protected double _SetRadius2;
        protected double _SetRadius3;
        protected double _SetRadius4;
        protected double _SetChord_t;
        protected double _SetRadius_t;
        protected double _SetRadius1_t;
        protected double _SetRadius2_t;
        protected double _SetRadius3_t;
        protected double _SetRadius4_t;
        protected bool _ValidValue;
        private bool _IsCuttingGlass;
        private bool _IsBendingDistanceFrame;
        private bool _IsFormSealing;
        private bool _IsGasFillingForm;
        private bool _IsVertBendingMashineRobot;
        private bool _IsVertMashineEdgeMaking;
        private string _TempSideVector;
        private string _Type;
        private string _Direction;
        private float _Factor;
        private string _Orientation;
        private double _TotalShprosLength;
        private double _ShprosChordHeight;
        private double _LeftMargin;
        private double _RightMargin;
        private int _Count;
        private int _SelectorFlag;
        private double _AxisMargin;
        private RectangleF _SelectedRect;
        private bool _IsDrawPictureEditButtons;
        private bool _IsShowSizeAttr;
        public double _CheckCut1;
        public double _CheckCut2;
        public double _CheckCut3;
        public double _CheckCut4;
        public double _CheckCut5;
        public double _CheckCut6;
        public double _CheckCut7;
        public double _CheckCut8;
        private bool _IsSelectSameAllowance = false;
        private int _HorisontalShprosCounter;
        private int _VerticalShprosCounter;
        private int _TobrazRetainer;
        private int _RetainerCounter;

        public bool IsShowSizeAttr
        {
            get { return _IsShowSizeAttr; }
            set { SetField(ref _IsShowSizeAttr, value, () => IsShowSizeAttr); }
        }
        public bool ValidValue
        {
            get { return _ValidValue; }
            set { SetField(ref _ValidValue, value, () => ValidValue); }
        }
        /// <summary>
        /// Gets or sets the set point.
        /// </summary>
        /// <value>
        /// The set point.
        /// </value>
        [DisplayName("Точка")]
        [Description("Выбор точки")]
        [ReadOnly(false)]
        [Category("Коррекция")]
        [TypeConverter(typeof(SelectingPointConverter))]
        public SelectedPoint SetPoint
        {
            get { return _SetPoint; }
            set { SetField(ref _SetPoint, value, () => SetPoint); }
        }
        private bool _IsScale;
        public bool IsScale
        {
            get { return _IsScale; }
            set { SetField(ref _IsScale, value, () => IsScale); }
        }

        private string _ColorMarker;
        private string _ColorMarker1;
        private string _ColorMarker2;
        private string _ColorMarker3;
        private string _ColorMarker4;
        private string _ColorMarker5;
        private string _ColorMarker6;
        private string _ColorMarker7;
        private string _ColorMarker8;
        public string ColorMarker
        {
            get { return _ColorMarker; }
            set { SetField(ref _ColorMarker, value, () => ColorMarker); }
        }
        public string ColorMarker1
        {
            get { return _ColorMarker1; }
            set { SetField(ref _ColorMarker1, value, () => ColorMarker1); }
        }
        public string ColorMarker2
        {
            get { return _ColorMarker2; }
            set { SetField(ref _ColorMarker2, value, () => ColorMarker2); }
        }
        public string ColorMarker3
        {
            get { return _ColorMarker3; }
            set { SetField(ref _ColorMarker3, value, () => ColorMarker3); }
        }
        public string ColorMarker4
        {
            get { return _ColorMarker4; }
            set { SetField(ref _ColorMarker4, value, () => ColorMarker4); }
        }
        public string ColorMarker5
        {
            get { return _ColorMarker5; }
            set { SetField(ref _ColorMarker5, value, () => ColorMarker5); }
        }
        public string ColorMarker6
        {
            get { return _ColorMarker6; }
            set { SetField(ref _ColorMarker6, value, () => ColorMarker6); }
        }
        public string ColorMarker7
        {
            get { return _ColorMarker7; }
            set { SetField(ref _ColorMarker7, value, () => ColorMarker7); }
        }
        public string ColorMarker8
        {
            get { return _ColorMarker8; }
            set { SetField(ref _ColorMarker8, value, () => ColorMarker8); }
        }
        private List<GraphicsPath> _ShprosCollection;
        public List<GraphicsPath> ShprosCollection
        {
            get { return _ShprosCollection; }
            set { SetField(ref _ShprosCollection, value, () => ShprosCollection); }
        }

        private List<GraphicsPath> _TempList;
        protected List<GraphicsPath> TempList
        {
            get { return _TempList; }
            set { SetField(ref _TempList, value, () => TempList); }
        }

        private bool _IsRefreshColorShprosElement;
        public bool IsRefreshColorShprosElement
        {
            get { return _IsRefreshColorShprosElement; }
            set { SetField(ref _IsRefreshColorShprosElement, value, () => IsRefreshColorShprosElement); }
        }
        #endregion
        #region UserSizes        
        /// <summary>
        /// Gets or sets the temporary value.
        /// </summary>
        /// <value>
        /// The temporary value.
        /// </value>
        protected double TempValue { get; set; }
        protected bool TempBoolValue { get; set; }

        /// <summary>
        /// Gets or sets the set b1.
        /// </summary>
        /// <value>
        /// The set b1.
        /// </value>
        [DisplayName("B1")]
        [Category("Кромка")]
        public virtual double SetB1
        {
            get => _SetB1;
            set
            {
                TempValue = SetB1;
                SetField(ref _SetB1, value, () => SetB1);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    SetB1 = TempValue;
                    return;
                }
            }
        }
        /// <summary>
        /// Gets or sets the set b2.
        /// </summary>
        /// <value>
        /// The set b2.
        /// </value>
        [DisplayName("B2")]
        [Category("Кромка")]
        public virtual double SetB2
        {
            get => _SetB2;
            set
            {
                TempValue = SetB2;
                SetField(ref _SetB2, value, () => SetB2);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    SetB2 = TempValue;
                    return;
                }
            }
        }
        /// <summary>
        /// Gets or sets the set b3.
        /// </summary>
        /// <value>
        /// The set b3.
        /// </value>
        [DisplayName("B3")]
        [Category("Кромка")]
        public virtual double SetB3
        {
            get => _SetB3;
            set
            {
                TempValue = SetB3;
                SetField(ref _SetB3, value, () => SetB3);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    SetB3 = TempValue;
                    return;
                }
            }
        }
        /// <summary>
        /// Gets or sets the set b4.
        /// </summary>
        /// <value>
        /// The set b4.
        /// </value>
        [DisplayName("B4")]
        [Category("Кромка")]
        public virtual double SetB4
        {
            get => _SetB4;
            set
            {
                TempValue = SetB4;
                SetField(ref _SetB4, value, () => SetB4);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    SetB4 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("H")]
        [Category(" Размеры")]
        public virtual double SetH
        {
            get => _SetH;
            set
            {
                TempValue = SetH;
                SetField(ref _SetH, value, () => SetH);
                if (!CheckValidSize()) SetHValue();
                else
                {
                    _SetH = TempValue;
                    return;
                }
            }
        }
        [DisplayName("H(зуб)")]
        [Category(" Размеры(c учетом зуба)")]
        public virtual double SetH_t
        {
            get { return _SetH_t; }
            //  set { SetField(ref _SetH_t, value, () => SetH_t); }
        }
        [DisplayName("H1")]
        [Category(" Размеры")]
        public virtual double SetH1
        {
            get => _SetH1;
            set
            {
                TempValue = SetH1;
                SetField(ref _SetH1, value, () => SetH1);
                if (!CheckValidSize()) SetH1Value();
                else
                {
                    _SetH1 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("H1(зуб)")]
        [Category(" Размеры(c учетом зуба)")]
        public virtual double SetH1_t
        {
            get { return _SetH1_t; }
            // set { SetField(ref _SetH1_t, value, () => SetH1_t); }
        }
        [DisplayName("H2")]
        [Category(" Размеры")]
        public virtual double SetH2
        {
            get { return _SetH2; }
            set
            {
                TempValue = SetH2;
                SetField(ref _SetH2, value, () => SetH2);
                if (!CheckValidSize()) SetH2Value();
                else
                {
                    _SetH2 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("H2(зуб)")]
        [Category(" Размеры(c учетом зуба)")]
        public virtual double SetH2_t
        {
            get { return _SetH2_t; }
            //  set { SetField(ref _SetH2_t, value, () => SetH2_t); }
        }
        [DisplayName("L")]
        [Category(" Размеры")]
        public virtual double SetL
        {
            get => _SetL;
            set
            {
                TempValue = SetL;
                SetField(ref _SetL, value, () => SetL);
                if (!CheckValidSize()) SetLValue();
                else
                {
                    _SetL = TempValue;
                    return;
                }
            }
        }
        [DisplayName("L(зуб)")]
        [Category(" Размеры(c учетом зуба)")]
        public virtual double SetL_t
        {
            get { return _SetL_t; }
            //  set { SetField(ref _SetL_t, value, () => SetL_t); }
        }
        [DisplayName("L1")]
        [Category(" Размеры")]
        public virtual double SetL1
        {
            get => _SetL1;
            set
            {
                TempValue = SetL1;
                SetField(ref _SetL1, value, () => SetL1);
                if (!CheckValidSize()) SetL1Value();
                else
                {
                    _SetL1 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("L1(зуб)")]
        [Category(" Размеры(c учетом зуба)")]
        public virtual double SetL1_t
        {
            get { return _SetL1_t; }
            //   set { SetField(ref _SetL1_t, value, () => SetL1_t); }
        }
        [DisplayName("L2")]
        [Category(" Размеры")]
        public virtual double SetL2
        {
            get => _SetL2;
            set
            {
                TempValue = SetL2;
                SetField(ref _SetL2, value, () => SetL2);
                if (!CheckValidSize()) SetL2Value();
                else
                {
                    _SetL2 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("L2(зуб)")]
        [Category(" Размеры(c учетом зуба)")]
        public virtual double SetL2_t
        {
            get { return _SetL2_t; }
            //   set { SetField(ref _SetL2_t, value, () => SetL2_t); }
        }
        [DisplayName("*R высота хорды")]
        [Category(" Размеры")]
        public virtual double SetChord
        {
            get { return _SetChord; }
            set
            {
                TempValue = SetChord;
                SetField(ref _SetChord, value, () => SetChord);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    _SetChord = TempValue;
                    return;
                }
            }
        }
        [DisplayName("*R высота хорды(зуб)")]
        [Category(" Размеры(c учетом зуба)")]
        public virtual double SetChord_t
        {
            get { return _SetChord_t; }
            //  set { SetField(ref _SetChord_t, value, () => SetChord_t); }
        }
        [DisplayName("Радиус")]
        [Category(" Размеры")]
        public virtual double SetRadius
        {
            get { return _SetRadius; }
            set
            {
                TempValue = SetRadius;
                SetField(ref _SetRadius, value, () => SetRadius);
                if (!CheckValidSize()) SetRadiusValue();
                else
                {
                    SetRadius = TempValue;
                    return;
                }
            }
        }
        [DisplayName("Радиус(зуб)")]
        [Category(" Размеры(c учетом зуба)")]
        public virtual double SetRadius_t
        {
            get { return _SetRadius_t; }
            //  set { SetField(ref _SetRaduis_t, value, () => SetRaduis_t); }
        }
        [DisplayName("Радиус1")]
        [Category(" Размеры")]
        public virtual double SetRadius1
        {
            get => _SetRadius1;
            set
            {
                TempValue = SetRadius1;
                SetField(ref _SetRadius1, value, () => SetRadius1);
                if (!CheckValidSize()) SetRadius1Value();
                else
                {
                    SetRadius1 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("Радиус1(зуб)")]
        [Category(" Размеры(c учетом зуба)")]
        public virtual double SetRadius1_t
        {
            get { return _SetRadius1_t; }
            // set { SetField(ref _SetRaduis1_t, value, () => SetRaduis1_t); }
        }
        [DisplayName("Радиус2")]
        [Category(" Размеры")]
        public virtual double SetRadius2
        {
            get => _SetRadius2;
            set
            {
                TempValue = SetRadius2;
                SetField(ref _SetRadius2, value, () => SetRadius2);
                if (!CheckValidSize()) SetRadius2Value();
                else
                {
                    SetRadius2 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("Радиус2(зуб)")]
        [Category("  Размеры(c учетом зуба)")]
        public virtual double SetRadius2_t
        {
            get { return _SetRadius2_t; }
            //   set { SetField(ref _SetRaduis2_t, value, () => SetRaduis2_t); }
        }
        [DisplayName("Радиус3")]
        [Category(" Размеры")]
        public virtual double SetRadius3
        {
            get => _SetRadius3;
            set
            {
                TempValue = SetRadius3;
                SetField(ref _SetRadius3, value, () => SetRadius3);
                if (!CheckValidSize()) SetRadius3Value();
                else
                {
                    SetRadius3 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("Радиус3(зуб)")]
        [Category(" Размеры(c учетом зуба)")]
        public virtual double SetRadius3_t
        {
            get { return _SetRadius3_t; }
            //  set { SetField(ref _SetRaduis3_t, value, () => SetRaduis3_t); }
        }
        [DisplayName("Радиус4")]
        [Category(" Размеры")]
        public virtual double SetRadius4
        {
            get => _SetRadius4;
            set { SetField(ref _SetRadius4, value, () => SetRadius4); }
        }
        [DisplayName("Радиус4(зуб)")]
        [Category(" Размеры(c учетом зуба)")]
        public virtual double SetRadius4_t
        {
            get { return _SetRadius4_t; }
            //  set { SetField(ref _SetRaduis4_t, value, () => SetRaduis4_t); }
        }
        [DisplayName("Высота H м")]
        [Category("Габаритные размеры")]
        public virtual double ShapeHeightValue
        {
            get
            {
                Line l = GetNewLine(Z_Base, Y_Base);
                return l.Length;
            }
        }
        [DisplayName("Ширина L м")]
        [Category("Габаритные размеры")]
        public virtual double ShapeWidthValue
        {
            get
            {
                Line l = GetNewLine(W_Base, Z_Base);
                return l.Length;
            }
        }




        #endregion
        #region BaseSizes
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public double Angle { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Периметр фигуры m")]
        [Category("Параметры")]
        public virtual double Perimeter { get; private set; }
        [DisplayName("Периметр фигуры с учетом припуска/зуба m")]
        [Category("Параметры")]
        public virtual double Perimeter_t { get; private set; }

        [DisplayName("Площадь отступа m²")]
        [Category("Параметры")]
        public double IdentSquare
        {
            get => TrueArea - Area;
        }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Площадь фигуры без припуска/зуба m²")]
        [Category("Параметры")]
        public virtual double Area { get; private set; }
        [DisplayName("Площадь фигуры с учетом припуска/зуба m²")]
        [Category("Параметры")]
        public virtual double TrueArea { get; private set; }
        /// <summary>
        /// Gets the base area.
        /// </summary>
        /// <value>
        /// The base area.
        /// </value>
        [DisplayName("Площадь заготовки m²")]
        [Category("Параметры")]
        public virtual double BaseArea
        {
            get
            {
                Line horisontalLine = new Line(W_Base, Z_Base);
                Line verticalLine = new Line(W_Base, X_Base);
                double vertLength = (verticalLine.Length <= 0) ? 1 : verticalLine.Length;
                double horLength = (horisontalLine.Length <= 0) ? 1 : horisontalLine.Length;
                return Math.Round(vertLength * horLength / 1000000, 3);
            }
        }
        [DisplayName("КИС фигуры в процентах")]
        [Category("Параметры")]
        public virtual string ShapeKisPersent
        {
            get
            {

                string s = (IsToothVector == true) ? Math.Round(TrueArea / BaseArea * 100, 0).ToString() + " %" : Math.Round(Area / BaseArea * 100, 0).ToString() + " %";
                return s;
            }
        }
        [DisplayName("КИС фигуры коэфициент")]
        [Category("Параметры")]
        public virtual double ShapeKis
        {
            get
            {
                double s = (IsToothVector == true) ? Math.Round(TrueArea / BaseArea, 2) : Math.Round(Area / BaseArea, 2);
                return s;
            }
        }
        [DisplayName("Резка стекла")]
        [Display(GroupName = "Дополнительные параметры")]
        public bool IsCuttingGlass
        {
            get { return _IsCuttingGlass; }
            set { SetField(ref _IsCuttingGlass, value, () => IsCuttingGlass); }
        }
        [DisplayName("Гнутье дистанционной рамки")]
        [Display(GroupName = "Дополнительные параметры")]
        public bool IsBendingDistanceFrame
        {
            get { return _IsBendingDistanceFrame; }
            set { SetField(ref _IsBendingDistanceFrame, value, () => IsBendingDistanceFrame); }
        }
        [DisplayName("Герметизация форм")]
        [Display(GroupName = "Дополнительные параметры")]
        public bool IsFormSealing
        {
            get { return _IsFormSealing; }
            set { SetField(ref _IsFormSealing, value, () => IsFormSealing); }
        }
        [DisplayName("Газозаполнение форм")]
        [Display(GroupName = "Дополнительные параметры")]
        public bool IsGasFillingForm
        {
            get { return _IsGasFillingForm; }
            set { SetField(ref _IsGasFillingForm, value, () => IsGasFillingForm); }
        }
        [DisplayName("Вертикальная гнутьевая машина - робот")]
        [Display(GroupName = "Дополнительные параметры")]
        public bool IsVertBendingMashineRobot
        {
            get { return _IsVertBendingMashineRobot; }
            set { SetField(ref _IsVertBendingMashineRobot, value, () => IsVertBendingMashineRobot); }
        }
        [DisplayName("Вертикальная машина обработки кромки")]
        [Display(GroupName = "Дополнительные параметры")]
        public bool IsVertMashineEdgeMaking
        {
            get { return _IsVertMashineEdgeMaking; }
            set { SetField(ref _IsVertMashineEdgeMaking, value, () => IsVertMashineEdgeMaking); }
        }
        #endregion
        #region rectangles
        /// <summary>
        /// Gets or sets the aRectangleF.
        /// </summary>
        /// <value>
        /// The br f.
        /// </value>
        [Browsable(false)]
        protected RectangleF ArF { get; set; }

        /// <summary>
        /// Gets or sets the bRectangleF.
        /// </summary>
        /// <value>
        /// The br f.
        /// </value>
        [Browsable(false)]
        protected RectangleF BrF { get; set; }
        /// <summary>
        /// Gets or sets the cRectangleF.
        /// </summary>
        /// <value>
        /// The br f.
        /// </value>
        [Browsable(false)]
        protected RectangleF CrF { get; set; }

        /// <summary>
        /// Gets or sets the dRectangleF.
        /// </summary>
        /// <value>
        /// The br f.
        /// </value>
        [Browsable(false)]
        protected RectangleF DrF { get; set; }
        /// <summary>
        /// Gets or sets the er e.
        /// </summary>
        /// <value>
        /// The er f.
        /// </value>
        [Browsable(false)]
        protected RectangleF ErF { get; set; }

        /// <summary>
        /// Gets or sets the er f.
        /// </summary>
        /// <value>
        /// The er f.
        /// </value>
        [Browsable(false)]
        protected RectangleF FrF { get; set; }
        /// <summary>
        /// Gets or sets the gr f.
        /// </summary>
        /// <value>
        /// The gr f.
        /// </value>
        [Browsable(false)]
        protected RectangleF GrF { get; set; }
        /// <summary>
        /// Gets or sets the hr f.
        /// </summary>
        /// <value>
        /// The hr f.
        /// </value>
        [Browsable(false)]
        protected RectangleF HrF { get; set; }

        #endregion
        #region Set radiuses
        /// <summary>
        /// Gets or sets the set a radius.
        /// </summary>
        /// <value>
        /// The set a radius.
        /// </value>
        [DisplayName("Радиус A")]
        [Category("Radius")]
        [Display(GroupName = "Скругления")]
        public float SetA_radius { get; set; }
        /// <summary>
        /// Gets or sets the set b radius.
        /// </summary>
        /// <value>
        /// The set b radius.
        /// </value>
        [DisplayName("Радиус B")]
        [Category("Radius")]
        [Display(GroupName = "Скругления")]
        public float SetB_radius { get; set; }
        /// <summary>
        /// Gets or sets the set c radius.
        /// </summary>
        /// <value>
        /// The set c radius.
        /// </value>
        [DisplayName("Радиус C")]
        [Category("Radius")]
        [Display(GroupName = "Скругления")]
        public float SetC_radius { get; set; }
        #endregion
        #region BasePoints        
        /// <summary>
        /// Gets or sets the w base.
        /// </summary>
        /// <value>
        /// The w base.
        /// </value>
        protected ShapePoint W_Base { get; set; }
        /// <summary>
        /// Gets or sets the PointX base.
        /// </summary>
        /// <value>
        /// The PointX base.
        /// </value>
        protected ShapePoint X_Base { get; set; }
        /// <summary>
        /// Gets or sets the y base.
        /// </summary>
        /// <value>
        /// The y base.
        /// </value>
        protected ShapePoint Y_Base { get; set; }
        /// <summary>
        /// Gets or sets the z base.
        /// </summary>
        /// <value>
        /// The z base.
        /// </value>
        protected ShapePoint Z_Base { get; set; }
        protected ShapePoint First_B_Some_Size_Point { get; set; }
        protected ShapePoint Second_B_Some_Size_Point { get; set; }
        #endregion
        #region CustomCheck
        [DisplayName("Сторона A отступ(зуб)")]
        [Category("Припуски и отступы")]
        public virtual double CheckCut1
        {
            get => _CheckCut1;
            set
            {
                TempValue = CheckCut1;
                SetField(ref _CheckCut1, value, () => CheckCut1);
                if (!CheckValidSize())
                {
                    if (IsSelectSameAllowance)
                    {
                        CheckCut2 = _CheckCut1;
                        CheckCut3 = _CheckCut1;
                        CheckCut4 = _CheckCut1;
                        CheckCut5 = _CheckCut1;
                        CheckCut6 = _CheckCut1;
                        CheckCut7 = _CheckCut1;
                        CheckCut8 = _CheckCut1;
                        IsSelectSameAllowance = false;
                    }
                    else { return; }
                    if (IsToothVector == true)
                    {
                        Move(CheckCut1, 0);
                    }
                    ValidValue = false;
                }
                else
                {
                    CheckCut1 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("Сторона Б отступ(зуб)")]
        [Category("Припуски и отступы")]
        public virtual double CheckCut2
        {
            get => _CheckCut2;
            set
            {
                TempValue = CheckCut2;
                SetField(ref _CheckCut2, value, () => CheckCut2);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    CheckCut2 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("Сторона В отступ(зуб)")]
        [Category("Припуски и отступы")]
        public virtual double CheckCut3
        {
            get => _CheckCut3;
            set
            {
                TempValue = CheckCut3;
                SetField(ref _CheckCut3, value, () => CheckCut3);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    CheckCut3 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("Сторона Г отступ(зуб)")]
        [Category("Припуски и отступы")]
        public virtual double CheckCut4
        {
            get => _CheckCut4;
            set
            {
                TempValue = CheckCut4;
                SetField(ref _CheckCut4, value, () => CheckCut4);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    CheckCut4 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("Сторона Д отступ(зуб)")]
        [Category("Припуски и отступы")]
        public virtual double CheckCut5
        {
            get => _CheckCut5;
            set
            {
                TempValue = CheckCut5;
                SetField(ref _CheckCut5, value, () => CheckCut5);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    CheckCut5 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("Сторона Е отступ(зуб)")]
        [Category("Припуски и отступы")]
        public virtual double CheckCut6
        {
            get => _CheckCut6;
            set
            {
                TempValue = CheckCut6;
                SetField(ref _CheckCut6, value, () => CheckCut6);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    CheckCut6 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("Сторона Ж отступ(зуб)")]
        [Category("Припуски и отступы")]
        public virtual double CheckCut7
        {
            get => _CheckCut7;
            set
            {
                TempValue = CheckCut7;
                SetField(ref _CheckCut7, value, () => CheckCut7);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    CheckCut7 = TempValue;
                    return;
                }
            }
        }
        [DisplayName("Сторона З отступ(зуб)")]
        [Category("Припуски и отступы")]
        public virtual double CheckCut8
        {
            get => _CheckCut8;
            set
            {
                TempValue = CheckCut8;
                SetField(ref _CheckCut8, value, () => CheckCut8);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    CheckCut8 = TempValue;
                    return;
                }
            }
        }

        /// <summary>
        /// Установка одинаковых припусков под обработку
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is select same allowance; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Везде одинаково по значению 'Сторона 1'  отступы(зуб)")]
        [Category("Припуски и отступы")]
        public virtual bool IsSelectSameAllowance
        {
            get { return _IsSelectSameAllowance; }
            set
            {

                SetField(ref _IsSelectSameAllowance, value, () => IsSelectSameAllowance);

                if (_IsSelectSameAllowance == false)
                {
                    return;
                }
                else
                {
                    CheckCut2 = _CheckCut1;
                    CheckCut3 = _CheckCut1;
                    CheckCut4 = _CheckCut1;
                    CheckCut5 = _CheckCut1;
                    CheckCut6 = _CheckCut1;
                    CheckCut7 = _CheckCut1;
                    CheckCut8 = _CheckCut1;
                }

                if (IsToothVector == true)
                {
                    Move(CheckCut1, CheckCut2);
                }

            }
        }
        private bool _IsToothVector;
        [DisplayName(" Зуб (внутрь-наружу)")]
        [Category("Припуски и отступы")]
        public bool IsToothVector
        {
            get { return _IsToothVector; }
            set { SetField(ref _IsToothVector, value, () => IsToothVector); }
        }
        #endregion
        #region Points  
        /// <summary>
        /// Gets or sets a.
        /// </summary>
        /// <value>
        /// a.
        /// </value>
        public ShapePoint A { get; set; }
        /// <summary>
        /// Gets or sets the b.
        /// </summary>
        /// <value>
        /// The b.
        /// </value>
        public ShapePoint B { get; set; }
        /// <summary>
        /// Gets or sets the c.
        /// </summary>
        /// <value>
        /// The c.
        /// </value>
        public ShapePoint C { get; set; }
        /// <summary>
        /// Gets or sets the d.
        /// </summary>
        /// <value>
        /// The d.
        /// </value>
        public ShapePoint D { get; set; }
        /// <summary>
        /// Gets or sets the e.
        /// </summary>
        /// <value>
        /// The e.
        /// </value>
        public ShapePoint E { get; set; }
        /// <summary>
        /// Gets or sets the f.
        /// </summary>
        /// <value>
        /// The f.
        /// </value>
        public ShapePoint F { get; set; }
        /// <summary>
        /// Gets or sets the g.
        /// </summary>
        /// <value>
        /// The g.
        /// </value>
        protected ShapePoint G { get; set; }
        /// <summary>
        /// Gets or sets the h.
        /// </summary>
        /// <value>
        /// The h.
        /// </value>
        public ShapePoint H { get; set; }
        /// <summary>
        /// Gets or sets a.
        /// </summary>
        /// <value>
        /// a.
        /// </value>
        protected ShapePoint A1 { get; set; }
        /// <summary>
        /// Gets or sets the b.
        /// </summary>
        /// <value>
        /// The b.
        /// </value>
        protected ShapePoint B1 { get; set; }
        /// <summary>
        /// Gets or sets the c.
        /// </summary>
        /// <value>
        /// The c.
        /// </value>
        protected ShapePoint C1 { get; set; }
        /// <summary>
        /// Gets or sets the d.
        /// </summary>
        /// <value>
        /// The d.
        /// </value>
        protected ShapePoint D1 { get; set; }
        /// <summary>
        /// Gets or sets the a2.
        /// </summary>
        /// <value>
        /// The a2.
        /// </value>
        protected ShapePoint A2 { get; set; }
        /// <summary>
        /// Gets or sets the b.
        /// </summary>
        /// <value>
        /// The b.
        /// </value>
        protected ShapePoint B2 { get; set; }
        /// <summary>
        /// Gets or sets the c.
        /// </summary>
        /// <value>
        /// The c.
        /// </value>
        protected ShapePoint C2 { get; set; }
        /// <summary>
        /// Gets or sets the d.
        /// </summary>
        /// <value>
        /// The d.
        /// </value>
        protected ShapePoint D2 { get; set; }
        /// <summary>
        /// Gets or sets the e1.
        /// </summary>
        /// <value>
        /// The e1.
        /// </value>
        protected ShapePoint E1 { get; set; }
        /// <summary>
        /// Gets or sets the e2.
        /// </summary>
        /// <value>
        /// The e2.
        /// </value>
        protected ShapePoint E2 { get; set; }
        /// <summary>
        /// Gets or sets the e1.
        /// </summary>
        /// <value>
        /// The e1.
        /// </value>
        protected ShapePoint F1 { get; set; }
        /// <summary>
        /// Gets or sets the e2.
        /// </summary>
        /// <value>
        /// The e2.
        /// </value>
        protected ShapePoint F2 { get; set; }
        /// <summary>
        /// Gets or sets the g1.
        /// </summary>
        /// <value>
        /// The e1.
        /// </value>
        protected ShapePoint G1 { get; set; }
        /// <summary>
        /// Gets or sets the g2.
        /// </summary>
        /// <value>
        /// The e2.
        /// </value>
        protected ShapePoint G2 { get; set; }
        /// <summary>
        /// Gets or sets the h1.
        /// </summary>
        /// <value>
        /// The h1.
        /// </value>
        protected ShapePoint H1 { get; set; }
        /// <summary>
        /// Gets or sets the h2.
        /// </summary>
        /// <value>
        /// The h2.
        /// </value>
        protected ShapePoint H2 { get; set; }

        /// <summary>
        /// Gets or sets the temporary point.
        /// </summary>
        /// <value>
        /// The temporary point.
        /// </value>
        protected ShapePoint TempPoint { get; set; }
        /// <summary>
        /// Gets or sets the center point.
        /// </summary>
        /// <value>
        /// The center point.
        /// </value>
        protected ShapePoint CenterPoint { get; set; }
        /// <summary>
        /// Gets or sets the curve point.
        /// </summary>
        /// <value>
        /// The curve point.
        /// </value>
        protected ShapePoint CurvePoint { get; set; }
        /// <summary>
        /// Gets or sets the points list.
        /// </summary>
        /// <value>
        /// The points list.
        /// </value>
        [Browsable(false)]
        public List<ShapePoint> PointsList { get; set; }
        [Browsable(false)]
        protected ShapePoint A_double { get; set; }
        [Browsable(false)]
        protected ShapePoint B_double { get; set; }
        [Browsable(false)]
        List<dynamic> ShapeParameters { get; set; }
        #endregion
        #region Tooth Points       
        private ShapePoint _ACheck;
        protected ShapePoint ACheck
        {
            get { return _ACheck; }
            set { SetField(ref _ACheck, value, () => ACheck); }
        }

        private ShapePoint _BCheck;
        protected ShapePoint BCheck
        {
            get { return _BCheck; }
            set { SetField(ref _BCheck, value, () => BCheck); }
        }
        private ShapePoint _CCheck;
        protected ShapePoint CCheck
        {
            get { return _CCheck; }
            set { SetField(ref _CCheck, value, () => CCheck); }
        }
        private ShapePoint _DCheck;
        protected ShapePoint DCheck
        {
            get { return _DCheck; }
            set { SetField(ref _DCheck, value, () => DCheck); }
        }
        private ShapePoint _ECheck;
        protected ShapePoint ECheck
        {
            get { return _ECheck; }
            set { SetField(ref _ECheck, value, () => ECheck); }
        }
        private ShapePoint _FCheck;
        protected ShapePoint FCheck
        {
            get { return _FCheck; }
            set { SetField(ref _FCheck, value, () => FCheck); }
        }
        private ShapePoint _GCheck;
        protected ShapePoint GCheck
        {
            get { return _GCheck; }
            set { SetField(ref _GCheck, value, () => GCheck); }
        }
        private ShapePoint _HCheck;
        protected ShapePoint HCheck
        {
            get { return _HCheck; }
            set { SetField(ref _HCheck, value, () => HCheck); }
        }
        #endregion
        #region Lines        
        /// <summary>
        /// Gets or sets a line.
        /// </summary>
        /// <value>
        /// a line.
        /// </value>
        [Browsable(false)]
        protected Line A_line { get; set; }
        /// <summary>
        /// Gets or sets the b line.
        /// </summary>
        /// <value>
        /// The b line.
        /// </value>
        [Browsable(false)]
        protected Line B_line { get; set; }
        /// <summary>
        /// Gets or sets the c line.
        /// </summary>
        /// <value>
        /// The c line.
        /// </value>
        [Browsable(false)]
        protected Line C_line { get; set; }
        /// <summary>
        /// Gets or sets the d line.
        /// </summary>
        /// <value>
        /// The d line.
        /// </value>
        [Browsable(false)]
        protected Line D_line { get; set; }
        /// <summary>
        /// Gets or sets the e line.
        /// </summary>
        /// <value>
        /// The e line.
        /// </value>
        [Browsable(false)]
        public Line E_line { get; set; }
        /// <summary>
        /// Gets or sets the f line.
        /// </summary>
        /// <value>
        /// The f line.
        /// </value>
        [Browsable(false)]
        protected Line F_line { get; set; }
        /// <summary>
        /// Gets or sets the g line.
        /// </summary>
        /// <value>
        /// The g line.
        /// </value>
        [Browsable(false)]
        protected Line G_line { get; set; }
        /// <summary>
        /// Gets or sets the h line.
        /// </summary>
        /// <value>
        /// The h line.
        /// </value>
        [Browsable(false)]
        protected Line H_line { get; set; }

        [Browsable(false)]
        protected Line A_Check_Line { get; set; }
        [Browsable(false)]
        protected Line B_Check_Line { get; set; }
        [Browsable(false)]
        protected Line C_Check_Line { get; set; }
        [Browsable(false)]
        protected Line D_Check_Line { get; set; }
        [Browsable(false)]
        protected Line E_Check_Line { get; set; }
        [Browsable(false)]
        protected Line F_Check_Line { get; set; }
        [Browsable(false)]
        protected Line G_Check_Line { get; set; }
        [Browsable(false)]
        protected Line H_Check_Line { get; set; }

        #endregion
        #region Graphics objects
        [Browsable(false)]
        public Graphics graphicsShape { get; set; }
        [Browsable(false)]
        public PictureEdit pictureBox { get; set; }
        [Browsable(false)]
        protected StringFormat sf { get; set; }
        //[Browsable(false)]
        //protected GraphicsPath p { get; set; }
        //[Browsable(false)]
        //protected GraphicsPath p1 { get; set; }
        [Browsable(false)]
        public Bitmap bitmapShape { get; set; }
        [Browsable(false)]
        protected Pen pen1 { get; set; }
        [Browsable(false)]
        protected Pen pen2 { get; set; }
        [Browsable(false)]
        protected Pen pen3 { get; set; }
        [Browsable(false)]
        protected Pen pen4 { get; set; }
        [Browsable(false)]
        protected Pen pen5 { get; set; }
        [Browsable(false)]
        protected Pen pen6 { get; set; }
        [Browsable(false)]
        protected Pen pen7 { get; set; }
        [Browsable(false)]
        protected Pen pen8 { get; set; }
        [Browsable(false)]
        protected Font drawFontBold { get; set; }
        protected int ThiсknessArgument { get; set; } = 4;
        protected int ThiknessFontArgument { get; set; } = 8;
        protected int LineBoundArgument { get; set; } = 1;
        protected int SizeLineBoundArgument { get; set; } = 1;

        #endregion
        #region Constructors        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="ShapePoints"></param>
        /// <param name="currentShapeParametersList"></param>
        public BaseShape(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList)
        {
            CursorPoint = GetNewPoint();
            ShprossArcWithKeyCollection = new List<Tuple<Guid, System.Drawing.Point[]>>();
             ShprossLineCollection = new List<Line>();
            ShprossArcCollection = new List<System.Drawing.Point[]>();
            ShprosCollection = new List<GraphicsPath>();
            MarkersList = new List<Rectangle>();
            TempList = new List<GraphicsPath>();
            PointsList = new List<ShapePoint>();
            ShapePoints = PointsList;
            ShapePoints = PointsList.GetRange(0, ShapePoints.Count);
            ShapeParameters = new List<dynamic>();
            currentShapeParametersList = ShapeParameters;
            currentShapeParametersList = ShapeParameters.GetRange(0, currentShapeParametersList.Count);
            pictureBox = new PictureEdit();
            sf = new StringFormat();
            SelectedSides = Array.Empty<int>();
            A1 = GetNewPoint();
            A2 = GetNewPoint();
            B1 = GetNewPoint();
            B2 = GetNewPoint();
            C1 = GetNewPoint();
            C2 = GetNewPoint();
            D1 = GetNewPoint();
            D2 = GetNewPoint();
            E1 = GetNewPoint();
            E2 = GetNewPoint();
            F1 = GetNewPoint();
            F2 = GetNewPoint();
            G1 = GetNewPoint();
            G2 = GetNewPoint();
            H1 = GetNewPoint();
            H2 = GetNewPoint();
            TempPoint = GetNewPoint();
            TempPoint = GetNewPoint();
            CenterPoint = GetNewPoint();
            CurvePoint = GetNewPoint();
            First_B_Some_Size_Point = GetNewPoint();// для случаев с размером B4
            Second_B_Some_Size_Point = GetNewPoint();// для случаев с размером B4
            ArF = new RectangleF();
            BrF = new RectangleF();
            CrF = new RectangleF();
            DrF = new RectangleF();
            ErF = new RectangleF();
            FrF = new RectangleF();
            GrF = new RectangleF();
            HrF = new RectangleF();
            W_Base = GetNewPoint();
            X_Base = GetNewPoint();
            Y_Base = GetNewPoint();
            Z_Base = GetNewPoint();
            ACheck = GetNewPoint();
            BCheck = GetNewPoint();
            CCheck = GetNewPoint();
            DCheck = GetNewPoint();
            ECheck = GetNewPoint();
            FCheck = GetNewPoint();
            GCheck = GetNewPoint();
            HCheck = GetNewPoint();
            A_double = GetNewPoint();
            B_double = GetNewPoint();

        }
       
        protected virtual void GetCurrentParameters(List<dynamic> currentShapeParametersList)
        {
            if (currentShapeParametersList != null)
            {
                for (int i = 0; i < currentShapeParametersList.Count; i++)
                {
                    SetB1 = currentShapeParametersList[0];
                    SetB2 = currentShapeParametersList[1];
                    SetB3 = currentShapeParametersList[2];
                    SetB4 = currentShapeParametersList[3];
                    SetChord = currentShapeParametersList[4];
                    SetRadius = currentShapeParametersList[5];
                    SetRadius1 = currentShapeParametersList[6];
                    SetRadius2 = currentShapeParametersList[7];
                    SetRadius3 = currentShapeParametersList[8];
                    SetRadius4 = currentShapeParametersList[9];
                    IsCuttingGlass = currentShapeParametersList[10];
                    IsBendingDistanceFrame = currentShapeParametersList[11];
                    IsFormSealing = currentShapeParametersList[12];
                    IsGasFillingForm = currentShapeParametersList[13];
                    IsVertBendingMashineRobot = currentShapeParametersList[14];
                    IsVertMashineEdgeMaking = currentShapeParametersList[15];
                    IsToothVector = currentShapeParametersList[16];
                    CheckCut1 = currentShapeParametersList[17];
                    CheckCut2 = currentShapeParametersList[18];
                    CheckCut3 = currentShapeParametersList[19];
                    CheckCut4 = currentShapeParametersList[20];
                    CheckCut5 = currentShapeParametersList[21];
                    CheckCut6 = currentShapeParametersList[22];
                    CheckCut7 = currentShapeParametersList[23];
                    CheckCut8 = currentShapeParametersList[24];
                }
            }

        }
        #endregion
        private float _CursorX;
        public float CursorX
        {
            get { return _CursorX; }
            set { SetField(ref _CursorX, value, () => CursorX); }
        }
        private float _CursorY;
        public float CursorY
        {
            get { return _CursorY; }
            set { SetField(ref _CursorY, value, () => CursorY); }
        }
        private Image _ControlImage;
        public Image ControlImage
        {
            get { return _ControlImage; }
            set { SetField(ref _ControlImage, value, () => ControlImage); }
        }
        #region Methods
        /// <summary>
        /// Initializes the shape.
        /// </summary>
        /// <param name="pictureBox">The picture boPointX.</param>
        public void InitShape(PictureEdit pictureBox)
        {
            this.pictureBox = pictureBox;
            using (bitmapShape = new Bitmap(10000, 10000, PixelFormat.Format32bppPArgb))
            {
                using (graphicsShape = Graphics.FromImage(bitmapShape))
                {
                    graphicsShape.SmoothingMode = SmoothingMode.AntiAlias;
                    try
                    {
                        TotalShprosLength = 0.0;
                        RetainerCounter = 0;
                        CheckForeignBorders();
                        ThiсknessArgument = GetCurrentLineThick();
                        SizeLineBoundArgument = GetCurrentBaseLineThick();
                        AllowanceProcessing();
                        DrawMainLines();
                        if (!IsShowSizeAttr){ ParseCurrentCoordinates(); }
                        drawFontBold = new Font("Tahoma", emSize: GetCurrentFontSize());
                        if (!IsShowSizeAttr) { GetShapeComponents(); }
                        if (!IsScale)
                        {
                            SelectedRect = GetShapeBorders();
                            if (IsShowSizeAttr)
                            {
                                if (IsLoadDefaultShpros)
                                {
                                    LoadDefaultShprosComponents();
                                    IsLoadDefaultShpros = false;
                                }
                                if (IsRefreshColorShprosElement)
                                    RefreshPictureEdit();
                                if (IsDrawSideNumbers)
                                    DrawSideNumbers();
                                if (IsDrawSideMarkers)
                                    GetClickedPointIntersection(CursorPoint);
                                if (IsDeleteLastMarker)
                                    GetMarkerPointsList(CursorPoint);
                                if (IsDeleteAllMarkers)
                                    GetMarkerPointsList(CursorPoint);
                                if (IsMarkerInsideAxis)
                                    SelectClickedElement(CursorPoint);
                            }
                        }
                        if (IsScale)
                        {
                            var selectedImageRectangle = ScalePictureComponents();
                            pictureBox.Properties.SizeMode = PictureSizeMode.Zoom;
                            if (selectedImageRectangle.Left < 0)
                            {
                                CursorX = selectedImageRectangle.Left * (-1);
                                selectedImageRectangle.Offset((int)CursorX, 0);
                            }
                            if (selectedImageRectangle.Top < 0)
                            {
                                CursorY = selectedImageRectangle.Top * (-1);
                                selectedImageRectangle.Offset(0, (int)CursorY);
                            }
                            sourceRectangle = selectedImageRectangle;

                            pictureBox.Image = bitmapShape.GetThumbnailImage(selectedImageRectangle.Width,
                                selectedImageRectangle.Height, null, IntPtr.Zero);
                            var image = pictureBox.Image as Image;
                         //   ControlImage = image.Clone() as Image;
                            pictureBox.Image.Dispose();
                            if (selectedImageRectangle.Size.Width <= 0 || selectedImageRectangle.Size.Height <= 0) return;

                            image?.Dispose();
                            image = bitmapShape.Clone(selectedImageRectangle, bitmapShape.PixelFormat);
                            pictureBox.EditValue = image;
                        }

                        //  ControlImage = pictureBox.Image.Clone() as Image;
                        //string _folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                        //string _fileName = _folder + "\\" + "myBitMapImage" + ".Png";
                        //image.Save(_fileName, ImageFormat.Png);

                        else

                        {

                            pictureBox.Properties.SizeMode = PictureSizeMode.Zoom;
                            var selectedImageRectangle = ScalePictureComponents();
                            if (selectedImageRectangle.Left < 0)
                            {
                                CursorX = selectedImageRectangle.Left * (-1);
                                selectedImageRectangle.Offset((int)CursorX, 0);
                            }
                            if (selectedImageRectangle.Top < 0)
                            {
                                CursorY = selectedImageRectangle.Top * (-1);
                                selectedImageRectangle.Offset(0, (int)CursorY);
                            }
                            sourceRectangle = selectedImageRectangle;

                            pictureBox.Image = bitmapShape.GetThumbnailImage(selectedImageRectangle.Width,
                                selectedImageRectangle.Height, null, IntPtr.Zero);
                            var image = pictureBox.Image.Clone() as Image;

                            ControlImage = image.Clone() as Image;

                            pictureBox.Image.Dispose();
                            if (selectedImageRectangle.Size.Width <= 0 || selectedImageRectangle.Size.Height <= 0) return;

                            image?.Dispose();
                            image = bitmapShape.Clone(selectedImageRectangle, bitmapShape.PixelFormat);
                            pictureBox.EditValue = image;
                        }

                        bitmapShape.Dispose();
                        graphicsShape.Dispose();
                    }
                    catch (OutOfMemoryException ov)
                    {
                        Debug.WriteLine(ov.Message);
                        throw new OutOfMemoryException(ov.ToString());
                    }
                    catch (OverflowException ov)
                    {
                        Debug.WriteLine(ov.Message);
                        throw new OverflowException(ov.ToString());
                    }
                    catch (ArgumentOutOfRangeException ov)
                    {
                        Debug.WriteLine(ov.Message);
                        throw new ArgumentOutOfRangeException(ov.ToString());
                    }
                    catch (ArgumentException ov)
                    {
                        Debug.WriteLine(ov.Message);
                        throw new ArgumentException(ov.ToString());
                    }
                }
            }
            graphicsShape.Dispose();
            bitmapShape.Dispose();
        }
        public void DrawCustomShape(PointF[] customPoint)
        {
            graphicsShape.SmoothingMode = SmoothingMode.HighQuality;
            if (customPoint.Length == 2)
            {
                graphicsShape.DrawLine(Pens.Blue, customPoint[0], customPoint[1]);
                return;
            }
            else if (customPoint.Length < 2) return;
            graphicsShape.DrawPolygon(Pens.Blue, customPoint);


        }
        private bool _IsDrawSideNumbers;
        public bool IsDrawSideNumbers
        {
            get { return _IsDrawSideNumbers; }
            set { SetField(ref _IsDrawSideNumbers, value, () => IsDrawSideNumbers); }
        }

        /// <summary>
        /// Determines whether [is correct angle] [the specified angle].
        /// </summary>
        /// <param name="Angle">The angle.</param>
        /// <returns>
        ///   <c>true</c> if [is correct angle] [the specified angle]; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsCorrectAngle(double Angle)
        {
            this.Angle = Angle;
            return
                 Angle > 0 && Angle < 180;
        }

        /// <summary>
        /// Вращение вокруг центра тяжести
        /// </summary>
        public abstract void Rotate();
        /// <summary>
        /// Scales the specified factor.
        /// </summary>
        /// <param name="factor">The factor.</param>
        public abstract void Scale(double factor = 1.1);

        /// <summary>
        /// Resizes the width of the figure.
        /// </summary>
        /// <param name="factor">The factor.</param>
        public virtual void ResizeFigureWidth(double factor) { }
        /// <summary>Gets the figure points.</summary>
        /// <returns></returns>
        public virtual System.Drawing.Point[] GetFigurePoints() { return Array.Empty<System.Drawing.Point>(); }

        /// <summary>Gets the figure points with tooth.</summary>
        /// <returns></returns>
        public virtual System.Drawing.Point[] GetFigureToothPoints()
        {
            return Array.Empty<System.Drawing.Point>();
        }
        /// <summary>
        /// Gets the ePointXtremum points.
        /// </summary>
        /// <returns></returns>
        public virtual void GetExtremumPoints() { }
        /// <summary>
        /// Crops the image.
        /// </summary>
        /// <returns></returns>
        private int GetCurrentLineThick()
        {
            var val = 0;

            if (ShapeHeightValue > pictureBox.Height && ShapeWidthValue > pictureBox.Width)
            {
                val = 8 * (int)((ShapeHeightValue / pictureBox.Height) + (ShapeWidthValue / pictureBox.Width)) / 2;
            }
            else if (ShapeHeightValue > pictureBox.Height && ShapeWidthValue < pictureBox.Width)
            {
                val = 8 * (int)(ShapeHeightValue / pictureBox.Height);
            }
            else if (ShapeHeightValue < pictureBox.Height && ShapeWidthValue > pictureBox.Width)
            {
                val = 8 * (int)(ShapeWidthValue / pictureBox.Width);
            }
            else if (ShapeHeightValue < pictureBox.Height && ShapeWidthValue < pictureBox.Width)
            {
                val = 4;
            }
            return val;
        }
        private int GetCurrentBaseLineThick()
        {
            var val = 0;

            if (ShapeHeightValue > pictureBox.Height && ShapeWidthValue > pictureBox.Width)
            {
                val = 1 * (int)((ShapeHeightValue / pictureBox.Height) + (ShapeWidthValue / pictureBox.Width)) / 2;
            }
            else if (ShapeHeightValue > pictureBox.Height && ShapeWidthValue < pictureBox.Width)
            {
                val = 1 * (int)(ShapeHeightValue / pictureBox.Height);
            }
            else if (ShapeHeightValue < pictureBox.Height && ShapeWidthValue > pictureBox.Width)
            {
                val = 1 * (int)(ShapeWidthValue / pictureBox.Width);
            }
            else if (ShapeHeightValue < pictureBox.Height && ShapeWidthValue < pictureBox.Width)
            {
                val = 1;
            }
            return val;
        }
        private int GetCurrentFontSize()
        {
            var val = 0;
            var selectedImageRectangle = ScalePictureComponents();
            var ShapeWidthValues = selectedImageRectangle.Width;
            var ShapeHeightValues = selectedImageRectangle.Height;
            if (ShapeWidthValue < pictureBox.ClientSize.Width && ShapeHeightValue < pictureBox.ClientSize.Height)
            {
                val = (int)(XProp / 1000) + ((int)(XProp / 1000));
            }
            else if (ShapeHeightValues > ShapeWidthValues)
            {
                val = (int)(XProp / 1000) /*+ ((int)(XProp / 1000) / 2)*/;
                val = (val < 22) ? 22 : val;
            }
            else if (ShapeHeightValues < ShapeWidthValues)
            {
                val = (int)(YProp / 1000)/* + ((int)(YProp / 1000) / 2)*/;
                val = (val < 22) ? 22 : val;
            }
            else if (ShapeHeightValues == ShapeWidthValues)
            {
                val = (int)(XProp / 1000) /*+ ((int)(XProp / 1000) / 2)*/;
                val = (val < 22) ? 22 : val;
            }

            return val;


        }
        private int _WidthZoomPercent;
        public int WidthZoomPercent
        {
            get { return _WidthZoomPercent; }
            set { SetField(ref _WidthZoomPercent, value, () => WidthZoomPercent); }
        }
        private int _HeightZoomPercent;
        public int HeightZoomPercent
        {
            get { return _HeightZoomPercent; }
            set { SetField(ref _HeightZoomPercent, value, () => HeightZoomPercent); }
        }
        protected virtual Rectangle ScalePictureComponents()
        {
            var x = (int)XProp / 100;
            var y = (int)YProp / 100;
            x = (x < 150) ? 150 : x;
            y = (y < 150) ? 150 : y;
            var selectedImageRectangle = new Rectangle((int)X_Base.PointX - 150,
                (int)X_Base.PointY - 150,
                (int)ShapeWidthValue + x+(x/2), (int)ShapeHeightValue + y+(y/2));
            var widthDifferent = ((double)selectedImageRectangle.Width / pictureBox.Width);
            var heightDifferent = ((double)selectedImageRectangle.Height / pictureBox.Height);

            if (IsDrawPictureToAnotherWindows)
            {
              
            }
            else
            {
                if (ShapeWidthValue < pictureBox.ClientSize.Width && ShapeHeightValue < pictureBox.ClientSize.Height)
                {
                    var val = (x <= y) ? y / 100 : x / 100;
                    LineBoundArgument = val;
                    selectedImageRectangle.Width += (int)XProp / 20;
                    selectedImageRectangle.Height += (int)XProp / 20;
                }
                else
                {
                    var coef = ((selectedImageRectangle.Width / pictureBox.Width) +
                                                   ((selectedImageRectangle.Height / pictureBox.Height))) / 2;
                    if (selectedImageRectangle.Height >= selectedImageRectangle.Width)
                    {
                        if (!IsShowSizeAttr)
                        {
                            LineBoundArgument = (selectedImageRectangle.Height / pictureBox.Height) * 2;
                            var xS = (int)XProp / 100;
                            xS = (xS < 150) ? 200 : xS;
                            selectedImageRectangle.Width += xS;
                            selectedImageRectangle.Height += xS;
                        }
                        else
                        {
                            selectedImageRectangle.Width -= y - 200;
                            selectedImageRectangle.Height -= y - 200;
                        }
                    }
                    else
                    {
                        if (!IsShowSizeAttr)
                        {
                            LineBoundArgument = (selectedImageRectangle.Height / pictureBox.Height) * 2;
                            var xS = (int)XProp / 100;
                            xS = (xS < 150) ? 200 : xS;
                            selectedImageRectangle.Width += xS;
                            selectedImageRectangle.Height += xS;
                        }
                        else
                        {
                            selectedImageRectangle.Width -= x - 200;
                            selectedImageRectangle.Height -= x - 200;
                        }
                    }
                }
            }
            return selectedImageRectangle;
        }
        protected virtual void CheckForeignBorders() { }
       
        protected virtual void DrawMainLines() { }
        protected virtual PointF[] GetBasePoints()
        {
            return Array.Empty<PointF>();
        }



        public abstract void GetShapeComponents();
        /// <summary>
        /// Расчет углов
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <param name="thirdPoint"></param>
        /// <returns></returns>
        public virtual double CalculateAngle(ShapePoint firstPoint, ShapePoint secondPoint, ShapePoint thirdPoint)
        {
            double angleBetween = 0;
            Vector vector1 = new Vector((thirdPoint.PointX - secondPoint.PointX), (thirdPoint.PointY - secondPoint.PointY));
            Vector vector2 = new Vector((firstPoint.PointX - secondPoint.PointX), (firstPoint.PointY - secondPoint.PointY));
            angleBetween = Math.Abs(Vector.AngleBetween(vector1, vector2));
            return Math.Round(angleBetween, 1);
        }
        /// <summary>
        /// Makes the round corner.
        /// </summary>
        /// <param name="firstPoint">The first point.</param>
        /// <param name="secondPoint">The second point.</param>
        /// <param name="thirdPoint">The third point.</param>
        /// <param name="setRadius">The set radius.</param>
        /// <param name="radius">The radius.</param>
        /// <returns></returns>
        protected virtual GraphicsPath MakeRoundCorner(ShapePoint firstPoint, ShapePoint secondPoint, ShapePoint thirdPoint, double setRadius, double radius = 0.1)
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
            pt1 = new PointF((float)(secondPoint.PointX + n1.X), (float)(secondPoint.PointY + n1.Y));
            //Точка на прямой, параллельной v2
            pt2 = new PointF((float)(secondPoint.PointX + n2.X), (float)(secondPoint.PointY + n2.Y));
            double m1 = vectorBc.Y / (vectorBc.X + 1), m2 = vectorCd.Y / (vectorCd.X + 1);

            //Координаты центра сопряжения. Выводятся из уравнения прямой по вектору и точке
            if (vectorBc.X == 0)
            {// первая сторона параллельна оси OY
                center.X = pt1.X;
                center.Y = (float)(m2 * (pt1.X - pt2.X) + pt2.Y);
            }
            else if (vectorBc.Y == 0)
            {// первая сторона параллельна оси OPointX
                center.X = (float)((pt1.Y - pt2.Y) / (m2 + 0.001F) + pt2.X);
                center.Y = pt1.Y;
            }
            else if (vectorCd.X == 0)
            {// первая сторона параллельна оси OY
                center.X = pt2.X;
                center.Y = (float)(m1 * (pt2.X - pt1.X) + pt1.Y);
            }
            else if (vectorCd.Y == 0)
            {//вторая сторона параллельна оси OPointX
                center.X = (float)((pt2.Y - pt1.Y) / (m1 + 0.001F) + pt1.X);
                center.Y = pt2.Y;
            }
            else
            {
                center.X = (float)((pt2.Y - pt1.Y + m1 * pt1.X - m2 * pt2.X) / (m1 - m2 + 0.001F));
                center.Y = (float)(pt1.Y + m1 * (center.X - pt1.X));
            }
            RectangleF rectPoint = new RectangleF(center.X - 1, center.Y - 1, 2, 2);
            n1.Negate(); n2.Negate();//Разворот нормалей
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
        /// <summary>
        /// AddEntity Advanced Points
        /// </summary>
        /// <param name="secondPoint"></param>
        /// <param name="rectPoint"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        protected abstract void CreatingAdvancedPoints(ShapePoint secondPoint, RectangleF rectPoint, PointF a, PointF b);
        /// <summary>
        /// Correct Arcs length
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <param name="thirdPoint"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        protected abstract double CorrectingRadiusForShapeAngles(ShapePoint firstPoint, ShapePoint secondPoint, ShapePoint thirdPoint, double radius);
        public abstract List<ShapePoint> ShapePointsList();
        /// <summary>
        /// Moves the point.
        /// </summary>
        /// <param name="PointX">The PointX.</param>
        /// <param name="y">The y.</param>
        public abstract void MovePoint(float x, float y);
        public abstract void Move(double x = 0, double y = 0);
        #region Foreign Border
        /// <summary>
        /// Gets the ePointXtremum point.
        /// </summary>
        /// <param name="firstPoint">The first point.</param>
        /// <param name="rectangleF">The rectangle f.</param>
        /// <param name="_radius">The radius.</param>
        /// <returns></returns>
        public ShapePoint GeTextremumPoint(ShapePoint firstPoint, RectangleF rectangleF, double _radius)
        {
            float l = rectangleF.Left;
            float r = rectangleF.Right;
            float lr = (l + r) / 2;
            float t = rectangleF.Top;
            float b = rectangleF.Bottom;
            float tb = (t + b) / 2;
            ShapePoint point = GetNewPoint();
            ShapePoint custom = new ShapePoint(lr, tb);
            point.PointX = custom.PointX + (firstPoint.PointX - custom.PointX) * (_radius / Math.Sqrt(Math.Pow((firstPoint.PointX - custom.PointX), 2) + Math.Pow((firstPoint.PointY - custom.PointY), 2)));
            point.PointY = custom.PointY + (firstPoint.PointY - custom.PointY) * (_radius / Math.Sqrt(Math.Pow((firstPoint.PointX - custom.PointX), 2) + Math.Pow((firstPoint.PointY - custom.PointY), 2)));
            return point;
        }
        /// <summary>
        /// Moves the border right.
        /// </summary>
        /// <param name="fPoint">The f point.</param>
        /// <param name="sPoint">The s point.</param>
        /// <param name="factor">The factor.</param>
        public virtual void MoveBorderRight(ShapePoint fPoint, ShapePoint sPoint, double factor = 0)
        {
            fPoint.PointX += factor;
            sPoint.PointX += factor;
        }
        /// <summary>
        /// Moves the border left.
        /// </summary>
        /// <param name="fPoint">The f point.</param>
        /// <param name="sPoint">The s point.</param>
        /// <param name="factor">The factor.</param>
        public virtual void MoveBorderLeft(ShapePoint fPoint, ShapePoint sPoint, double factor = 0)
        {
            fPoint.PointX -= factor;
            sPoint.PointX -= factor;
        }
        /// <summary>
        /// Moves the border bottom.
        /// </summary>
        /// <param name="fPoint">The f point.</param>
        /// <param name="sPoint">The s point.</param>
        /// <param name="factor">The factor.</param>
        protected void MoveBorderBottom(ShapePoint fPoint, ShapePoint sPoint, double factor = 0)
        {
            fPoint.PointY += factor;
            sPoint.PointY += factor;
        }
        /// <summary>
        /// Moves the border top.
        /// </summary>
        /// <param name="fPoint">The f point.</param>
        /// <param name="sPoint">The s point.</param>
        /// <param name="factor">The factor.</param>
        protected virtual void MoveBorderTop(ShapePoint fPoint, ShapePoint sPoint, double factor = 0)
        {
            fPoint.PointY -= factor;
            sPoint.PointY -= factor;
        }
        #endregion
        #region Список полей в PropertyGrid
        /// <summary>
        /// Adds the custom properties.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CustomPropertyDescriptorsEventArgs"/> instance containing the event data.</param>
        public virtual void AddCustomProperties(object sender, CustomPropertyDescriptorsEventArgs e) { }

        private bool _IsAddAdwansedParams;
        public bool IsAddAdwansedParams
        {
            get { return _IsAddAdwansedParams; }
            set { SetField(ref _IsAddAdwansedParams, value, () => IsAddAdwansedParams); }
        }

        public virtual void AddCustomToothProperties(object sender, CustomPropertyDescriptorsEventArgs e) { }
        public virtual void AddCustomParametersProperties(object sender, CustomPropertyDescriptorsEventArgs e) { }

        /// <summary>
        /// Adds if property ePointXist.
        /// </summary>
        /// <param name="sourceCollection">The source collection.</param>
        /// <param name="targetCollection">The target collection.</param>
        /// <param name="name">The name.</param>
        protected void AddIfPropertyExist(PropertyDescriptorCollection sourceCollection, PropertyDescriptorCollection targetCollection, string name)
        {
            PropertyDescriptor foundPropertyDescriptor = sourceCollection[name];
            if (foundPropertyDescriptor == null)
                return;
            targetCollection.Add(foundPropertyDescriptor);
        }
        #endregion
        #region AdvansedLines
        protected virtual void FindPointDrawLine(ShapePoint firsrPoint, ShapePoint secondPoint, double factor = 0,
            double anotherFactor = 0, double thofactor = 0)
        { }
        protected void MoveInternalLineFromTop(Graphics graphics, ShapePoint fPoint, ShapePoint sPoint,
            ShapePoint tempFirstPoint, ShapePoint tempSecondPoint, double factor = 0, double anotherFactor = 0)
        {
            tempFirstPoint.PointX = fPoint.PointX;
            tempFirstPoint.PointY = fPoint.PointY;
            tempSecondPoint.PointX = sPoint.PointX;
            tempSecondPoint.PointY = sPoint.PointY;
            if (anotherFactor >= factor) { anotherFactor = factor; }
            tempFirstPoint.PointY += anotherFactor;
            tempSecondPoint.PointY += anotherFactor;
            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                // pen.DashStyle = DashStyle.DashDotDot;
                graphics.DrawLine(pen, tempFirstPoint, tempSecondPoint);
            }
        }
        protected void MoveInternalLineFromLeft(Graphics graphics, ShapePoint fPoint, ShapePoint sPoint,
            ShapePoint tempFirstPoint, ShapePoint tempSecondPoint, double factor = 0, double anotherFactor = 0)
        {
            tempFirstPoint.PointX = fPoint.PointX;
            tempFirstPoint.PointY = fPoint.PointY;
            tempSecondPoint.PointX = sPoint.PointX;
            tempSecondPoint.PointY = sPoint.PointY;
            if (anotherFactor >= factor) { anotherFactor = factor; }
            tempFirstPoint.PointX += anotherFactor;
            tempSecondPoint.PointX += anotherFactor;
            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                //pen.DashStyle = DashStyle.DashDotDot;
                graphics.DrawLine(pen, tempFirstPoint, tempSecondPoint);
            }
        }
        protected void MoveInternalLineFromRight(Graphics graphics, ShapePoint fPoint, ShapePoint sPoint,
            ShapePoint tempFirstPoint, ShapePoint tempSecondPoint, double factor = 0, double anotherFactor = 0)
        {
            tempFirstPoint.PointX = fPoint.PointX;
            tempFirstPoint.PointY = fPoint.PointY;
            tempSecondPoint.PointX = sPoint.PointX;
            tempSecondPoint.PointY = sPoint.PointY;
            if (anotherFactor >= factor) { anotherFactor = factor; }
            tempFirstPoint.PointX -= anotherFactor;
            tempSecondPoint.PointX -= anotherFactor;
            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                //  pen.DashStyle = DashStyle.DashDotDot;
                graphics.DrawLine(pen, tempFirstPoint, tempSecondPoint);
            }
        }
        #endregion
        #region Lines and Sizes
        /// <summary>
        /// Gets the new point.
        /// </summary>
        /// <returns></returns>
        protected ShapePoint GetNewPoint()
        {
            return new ShapePoint();
        }
        /// <summary>
        /// Gets the new custom point.
        /// </summary>
        /// <param name="PointX">The PointX.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public ShapePoint GetNewCustomPoint(double x, double y)
        {
            return new ShapePoint(x, y);
        }
        /// <summary>
        /// Gets the new line.
        /// </summary>
        /// <param name="firstPoint">The first point.</param>
        /// <param name="secondPoint">The second point.</param>
        /// <returns></returns>
        public Line GetNewLine(ShapePoint firstPoint, ShapePoint secondPoint)
        {
            return new Line(firstPoint, secondPoint);
        }
        public Line GetNewLineWithName(ShapePoint firstPoint, ShapePoint secondPoint, string name)
        {
            return new Line(firstPoint, secondPoint, name);
        }
        public Line GetNewLineWithFullParameters(ShapePoint firstPoint, ShapePoint secondPoint, string name, bool isVertical, bool isHorisontal, bool isAxis = false, Guid? id = null)
        {
            return new Line(firstPoint, secondPoint, name, isVertical, isHorisontal, isAxis,id);
        }
        private ShapePoint GetRoundPoint(ShapePoint point)
        {
            var X = 0.0;
            var Y = 0.0;
            if (!(point is null))
            {
                 X = Math.Round(point.PointX, 0);
                 Y = Math.Round(point.PointY, 0);
            }
            return new ShapePoint(X,Y);
        }
        /// <summary>
        /// Moves the point.
        /// </summary>
        /// <param name="firstPoint">The first point.</param>
        /// <param name="secondPoint">The second point.</param>
        /// <param name="factor">The factor.</param>
        /// <returns></returns>
        protected ShapePoint MoveSomePoint(ShapePoint firstPoint, ShapePoint secondPoint, double factor)
        {
            TempPoint.PointX = firstPoint.PointX + (secondPoint.PointX - firstPoint.PointX) * factor;
            TempPoint.PointY = firstPoint.PointY + (secondPoint.PointY - firstPoint.PointY) * factor;
            secondPoint.PointX = TempPoint.PointX;
            secondPoint.PointY = TempPoint.PointY;
            return new ShapePoint(secondPoint.PointX, secondPoint.PointY);
        }
        /// <summary>
        /// Gets the length of some line.
        /// </summary>
        /// <param name="PointX">The PointX.</param>
        /// <param name="y">The y.</param>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        protected double GetSomeLineLength(double x, double y, ShapePoint point)
        {
            ShapePoint p = GetNewCustomPoint(x, y);
            Line line = GetNewLine(p, point);
            return line.Length;
        }
        /// <summary>
        /// Gets some line length by two points.
        /// </summary>
        /// <param name="firstPoint">The first point.</param>
        /// <param name="secondPoint">The second point.</param>
        /// <returns></returns>
        public double GetSomeLineLengthByTwoPoints(ShapePoint firstPoint,
            ShapePoint secondPoint) => GetNewLine(firstPoint, secondPoint).Length;
        /// <summary>
        /// Изменение длины отрезка
        /// </summary>
        /// <param name="firstPoint">The first point.</param>
        /// <param name="secondPoint">The second point.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        protected ShapePoint SetCurrentLineLength(ShapePoint firstPoint,
            ShapePoint secondPoint, double length)
        {
            if (length == 0) { length = 0.001; }

            TempPoint.PointX = firstPoint.PointX + (secondPoint.PointX - firstPoint.PointX) * ((length) / Math.Sqrt(Math.Pow((secondPoint.PointX - firstPoint.PointX), 2) + Math.Pow((secondPoint.PointY - firstPoint.PointY), 2)));
            TempPoint.PointY = firstPoint.PointY + (secondPoint.PointY - firstPoint.PointY) * ((length) / Math.Sqrt(Math.Pow((secondPoint.PointX - firstPoint.PointX), 2) + Math.Pow((secondPoint.PointY - firstPoint.PointY), 2)));
            return GetNewCustomPoint(TempPoint.PointX, TempPoint.PointY);
        }
        /// <summary>
        /// Тип точки от направления зуба
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        protected double SetPointCurrentValueX(ShapePoint point)
        {

            if (IsToothVector == true)
            {
                if (point == A) { point = ACheck; }
                else if (point == B) { point = BCheck; }
                else if (point == C) { point = CCheck; }
                else if (point == D) { point = DCheck; }
                else if (point == E) { point = ECheck; }
                else if (point == F) { point = FCheck; }
                else if (point == G) { point = GCheck; }
                else if (point == H) { point = HCheck; }
            }

            return point.PointX;
        }
        /// <summary>
        /// Тип точки от направления зуба
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        protected double SetPointCurrentValueY(ShapePoint point)
        {

            if (IsToothVector == true)
            {
                if (point == A) { point = ACheck; }
                else if (point == B) { point = BCheck; }
                else if (point == C) { point = CCheck; }
                else if (point == D) { point = DCheck; }
                else if (point == E) { point = ECheck; }
                else if (point == F) { point = FCheck; }
                else if (point == G) { point = GCheck; }
                else if (point == H) { point = HCheck; }

            }
            return point.PointY;
        }
        protected ShapePoint SetPointCurrentType(ShapePoint point)
        {

            if (IsToothVector == true)
            {
                if (point == A) { point = ACheck; }
                else if (point == B) { point = BCheck; }
                else if (point == C) { point = CCheck; }
                else if (point == D) { point = DCheck; }
                else if (point == E) { point = ECheck; }
                else if (point == F) { point = FCheck; }
                else if (point == G) { point = GCheck; }
                else if (point == H) { point = HCheck; }
            }

            return point;
        }
        protected double SetCurrentSize(double size)
        {
            if (IsToothVector == true)
            {
                if (size == SetH) { size = SetH_t; }
                else if (size == SetH) { size = SetH_t; }
                else if (size == SetH1) { size = SetH1_t; }
                else if (size == SetH2) { size = SetH2_t; }
                else if (size == SetL) { size = SetL_t; }
                else if (size == SetL1) { size = SetL1_t; }
                else if (size == SetL2) { size = SetL2_t; }
                else if (size == SetChord) { size = SetChord_t; }
                else if (size == SetRadius) { size = SetRadius_t; }
                else if (size == SetRadius1) { size = SetRadius1_t; }
                else if (size == SetRadius2) { size = SetRadius2_t; }
                else if (size == SetRadius3) { size = SetRadius3_t; }
                else if (size == SetRadius4) { size = SetRadius4_t; }
            }

            return size;
        }
        #endregion
        #region SetSize
        protected virtual void SetHValue() { }
        protected virtual void SetH1Value() { }
        protected virtual void SetH2Value() { }
        protected virtual void SetB1Value() { }
        protected virtual void SetLValue() { }
        protected virtual void SetL1Value() { }
        protected virtual void SetL2Value() { }
        protected virtual void SetChordValue() { }
        protected virtual void SetRadiusValue() { }
        protected virtual void SetRadius1Value() { }
        protected virtual void SetRadius2Value() { }
        protected virtual void SetRadius3Value() { }
        protected static void ValidateSetSizeMessage(string Text, string title = "")
        {

            title = "Ошибка ввода";
            XtraMessageBox.Show(Text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public virtual bool CheckValidSize() => ValidValue;
        #endregion
        #region ToothMethod
        public virtual void SetZeroChecCutValue()
        {
            CheckCut1 = 0;
            CheckCut2 = 0;
            CheckCut3 = 0;
            CheckCut4 = 0;
            CheckCut5 = 0;
            CheckCut6 = 0;
            CheckCut7 = 0;
            CheckCut8 = 0;
        }
        protected virtual void AllowanceProcessing() { }
        #endregion

        #endregion
    }
}
