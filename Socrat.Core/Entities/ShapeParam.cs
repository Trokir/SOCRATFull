using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Socrat.Core.Entities
{
    public class ShapeParam : Entity
    {
        private bool? _IsCanCutGlass;
        private bool? _IsCanBendDistanceFrame;
        private bool? _IsCanFormSeal;
        private bool? _IsCanGasFillForm;
        private bool? _IsCanVertBendMashineRobot;
        private bool? _IsCanVertMashineEdgeMake;
        private bool? _IsToothVector;
        private double? _L_param;
        private double? _H_param;
        private double _L1_param;
        private double? _L2_param;
        private double? _H1_param;
        private double? _H2_param;
        private double? _R_param;
        private double? _R1_param;
        private double? _R2_param;
        private double? _R3_param;
        private double? _R4_param;
        private double? _Chord_param;
        private double? _B1_param;
        private double? _B2_param;
        private double? _B3_param;
        private double? _B4_param;
        private double? _CheckCut1_param;
        private double? _CheckCut2_param;
        private double? _CheckCut3_param;
        private double? _CheckCut4_param;
        private double? _CheckCut5_param;
        private double? _CheckCut6_param;
        private double? _CheckCut7_param;
        private double? _CheckCut8_param;

        public void DepthOfHermetic(double? val)
        {
            IsToothVector = true;
            _CheckCut1_param = val;
            _CheckCut2_param = val;
            _CheckCut3_param = val;
            _CheckCut4_param = val;
            _CheckCut5_param = val;
            _CheckCut6_param = val;
            _CheckCut7_param = val;
            _CheckCut8_param = val;
        }
        public void SetSize(double? h, double? w)
        {
            H_param = h;
            L_param = w;
        }

        public void SetHvalue(double? val)
        {
            H_param= val;
        }
        public void SetLvalue(double? val)
        {
            L_param = val;
        }

        public bool? IsCanCutGlass
        {
            get { return _IsCanCutGlass; }
            set { SetField(ref _IsCanCutGlass, value, () => IsCanCutGlass); }
        }
        public bool? IsCanBendDistanceFrame
        {
            get { return _IsCanBendDistanceFrame; }
            set { SetField(ref _IsCanBendDistanceFrame, value, () => IsCanBendDistanceFrame); }
        }

        public bool? IsCanFormSeal
        {
            get { return _IsCanFormSeal; }
            set { SetField(ref _IsCanFormSeal, value, () => IsCanFormSeal); }
        }

        public bool? IsCanGasFillForm
        {
            get { return _IsCanGasFillForm; }
            set { SetField(ref _IsCanGasFillForm, value, () => IsCanGasFillForm); }
        }

        public bool? IsCanVertBendMashineRobot
        {
            get { return _IsCanVertBendMashineRobot; }
            set { SetField(ref _IsCanVertBendMashineRobot, value, () => IsCanVertBendMashineRobot); }
        }

        public bool? IsCanVertMashineEdgeMake
        {
            get { return _IsCanVertMashineEdgeMake; }
            set { SetField(ref _IsCanVertMashineEdgeMake, value, () => IsCanVertMashineEdgeMake); }
        }
        public bool? IsToothVector
        {
            get { return _IsToothVector; }
            set { SetField(ref _IsToothVector, value, () => IsToothVector); }
        }

        public double? L_param
        {
            get { return _L_param; }
            set { SetField(ref _L_param, value, () => L_param); }
        }
        public double? H_param
        {
            get { return _H_param; }
            set { SetField(ref _H_param, value, () => H_param); }
        }

        public double L1_param
        {
            get { return _L1_param; }
            set { SetField(ref _L1_param, value, () => L1_param); }
        }
        public double? L2_param
        {
            get { return _L2_param; }
            set { SetField(ref _L2_param, value, () => L2_param); }
        }
        public double? H1_param
        {
            get { return _H1_param; }
            set { SetField(ref _H1_param, value, () => H1_param); }
        }
        public double? H2_param
        {
            get { return _H2_param; }
            set { SetField(ref _H2_param, value, () => H2_param); }
        }
        public double? R_param
        {
            get { return _R_param; }
            set { SetField(ref _R_param, value, () => R_param); }
        }
        public double? R1_param
        {
            get { return _R1_param; }
            set { SetField(ref _R1_param, value, () => R1_param); }
        }
        public double? R2_param
        {
            get { return _R2_param; }
            set { SetField(ref _R2_param, value, () => R2_param); }
        }
        public double? R3_param
        {
            get { return _R3_param; }
            set { SetField(ref _R3_param, value, () => R3_param); }
        }
        public double? R4_param
        {
            get { return _R4_param; }
            set { SetField(ref _R4_param, value, () => R4_param); }
        }
        public double? Chord_param
        {
            get { return _Chord_param; }
            set { SetField(ref _Chord_param, value, () => Chord_param); }
        }
        public double? B1_param
        {
            get { return _B1_param; }
            set { SetField(ref _B1_param, value, () => B1_param); }
        }
        public double? B2_param
        {
            get { return _B2_param; }
            set { SetField(ref _B2_param, value, () => B2_param); }
        }
        public double? B3_param
        {
            get { return _B3_param; }
            set { SetField(ref _B3_param, value, () => B3_param); }
        }
        public double? B4_param
        {
            get { return _B4_param; }
            set { SetField(ref _B4_param, value, () => B4_param); }
        }
        public double? CheckCut1_param
        {
            get { return _CheckCut1_param; }
            set { SetField(ref _CheckCut1_param, value, () => CheckCut1_param); }
        }
        public double? CheckCut2_param
        {
            get { return _CheckCut2_param; }
            set { SetField(ref _CheckCut2_param, value, () => CheckCut2_param); }
        }
        public double? CheckCut3_param
        {
            get { return _CheckCut3_param; }
            set { SetField(ref _CheckCut3_param, value, () => CheckCut3_param); }
        }
        public double? CheckCut4_param
        {
            get { return _CheckCut4_param; }
            set { SetField(ref _CheckCut4_param, value, () => CheckCut4_param); }
        }
        public double? CheckCut5_param
        {
            get { return _CheckCut5_param; }
            set { SetField(ref _CheckCut5_param, value, () => CheckCut5_param); }
        }
        public double? CheckCut6_param
        {
            get { return _CheckCut6_param; }
            set { SetField(ref _CheckCut6_param, value, () => CheckCut6_param); }
        }
        public double? CheckCut7_param
        {
            get { return _CheckCut7_param; }
            set { SetField(ref _CheckCut7_param, value, () => CheckCut7_param); }
        }
        public double? CheckCut8_param
        {
            get { return _CheckCut8_param; }
            set { SetField(ref _CheckCut8_param, value, () => CheckCut8_param); }
        }
        public double? Area { get; set; }
        public Nullable<double> BaseArea { get; set; }
        public Nullable<double> Perimeter { get; set; }


        
        private string _ShapeKisPersent;
        public string ShapeKisPersent
        {
            get { return _ShapeKisPersent; }
            set
            {

                SetField(ref _ShapeKisPersent, value, () => ShapeKisPersent);
                if (_ShapeKisPersent.Length > 10)
                {
                    _ShapeKisPersent = string.Empty;
                    _ShapeKisPersent = "нет данных";
                }
            }
        }


        private double? _ShapeKis;
        public double? ShapeKis
        {
            get => _ShapeKis;
            set
            {
                SetField(ref _ShapeKis, value, () => ShapeKis);
                if (Double.IsNaN(_ShapeKis ?? 0.0) || Double.IsInfinity(_ShapeKis ?? 0.0))
                {
                    _ShapeKis = 0.0;
                }

            }
        }



        private double? _ShapeHeight;
        public double? ShapeHeight
        {
            get => _ShapeHeight;
            set
            {
                SetField(ref _ShapeHeight, value, () => ShapeHeight);

                if (Double.IsNaN(_ShapeHeight ?? 0.0) || Double.IsInfinity(_ShapeHeight ?? 0.0))
                {
                    _ShapeHeight = 0.0;
                }

            }
        }


        private double? _ShapeWidth;
        public double? ShapeWidth
        {
            get => _ShapeWidth;
            set
            {
                SetField(ref _ShapeWidth, value, () => ShapeWidth);
                if (Double.IsNaN(_ShapeWidth ?? 0.0) || Double.IsInfinity(_ShapeWidth ?? 0.0))
                {
                    _ShapeWidth = 0.0;

                }

            }
        }

        public virtual Shape Shape { get; set; }

    }
}
