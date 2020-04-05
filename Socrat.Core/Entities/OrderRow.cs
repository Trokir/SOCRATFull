using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class OrderRow : Entity
    {
        public event EventHandler SizeChanged;
        public void OnSizeChanged()
        {
            SizeChanged?.Invoke(this, EventArgs.Empty);
        }

        private int _Num;
        public int Num
        {
            get { return _Num; }
            set { SetField(ref _Num, value, () => Num); }
        }

        private bool _tmp;
        private Nullable<int> _OverallW;
        public Nullable<int> OverallW
        {
            get { return _OverallW; }
            set
            {
                if (_setSizeFlag || Shape == null || (Shape != null && Shape.IsValidCatalogShape(OverallH, OverallW)))
                {
                    _tmp = _OverallW != value;
                    SetField(ref _OverallW, value, () => OverallW, () => Square);
                    if (Shape != null)
                        Shape.ShapeParam.SetLvalue(OverallW);
                    if (_tmp /*&& _OverallW.ToString().Length>1*/)
                        OnSizeChanged();
                }
            }
        }

        private Nullable<int> _OverallH;
        public Nullable<int> OverallH
        {
            get { return _OverallH; }
            set
            {
                if (_setSizeFlag || Shape == null || (Shape != null && Shape.IsValidCatalogShape(OverallH, OverallW)))
                {
                    _tmp = _OverallH != value;
                    SetField(ref _OverallH, value, () => OverallH, () => Square);
                    if (Shape != null)
                        Shape.ShapeParam.SetHvalue(OverallH);
                    if (_tmp /*&& _OverallH.ToString().Length > 1*/)
                        OnSizeChanged();
                }
            }
        }

        public double Square
        {
            get { return GetSquare(); }
        }

        private double GetSquare()
        {
            double res = ((double)(_OverallW ?? 0) / 1000);
            res = res * ((double)(_OverallH ?? 0) / 1000);
            res = res * 100;
            res = Math.Ceiling(res);
            res = res / 100;
            return res;
        }

        private string _formulaStr;
        public string FormulaStr
        {
            get { return Formula?.FormulaStr ?? _formulaStr; }
            set { SetFormulaStr(value); }
        }

        private void SetFormulaStr(string value)
        {
            //if (Formula == null || Formula.FormulaStr != value)
            //{
            //    if (Formula == null)
            //        Formula = new Formula { FormulaStr = value };
            //    else
            //    {
            //        Formula.Clear();
            //        Formula.FormulaStr = value;
            //    }
            //}
            if (Formula != null && value != null && Formula.FormulaStr != value)
            {
                Formula.Clear();
                Formula.FormulaStr = value;
            }
            SetField(ref _formulaStr, value, () => FormulaStr);
        }

        private Formula _formula;
        public virtual Formula Formula
        {
            get
            {
                return _formula;
            }
            set
            {
                SetField(ref _formula, value, () => Formula, () => FormulaStr);
                if (_formula != null)
                {
                    _formula.PropertyChanged -= _formula_PropertyChanged;
                    _formula.PropertyChanged += _formula_PropertyChanged;
                }
            }
        }

        public Nullable<double> Thickness
        {
            get { return Formula?.Thickness; }
        }


        //public int Weight { get; set; }

        private void _formula_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!Changed)
                Changed = true;
        }

        public Nullable<Guid> FormulaId { get; set; }

        private Nullable<int> _Qty;
        public Nullable<int> Qty
        {
            get { return _Qty; }
            set { SetField(ref _Qty, value, () => Qty); }
        }

        private string _Mark;
        public string Mark
        {
            get { return _Mark; }
            set { SetField(ref _Mark, value, () => Mark); }
        }


        private string _Barcode;
        public string Barcode
        {
            get { return _Barcode; }
            set { SetField(ref _Barcode, value, () => Barcode); }
        }


        private string _Comment;
        public string Comment
        {
            get { return _Comment; }
            set { SetField(ref _Comment, value, () => Comment); }
        }


        private Nullable<double> _PriceSqu;
        public Nullable<double> PriceSqu
        {
            get { return _PriceSqu; }
            set { SetField(ref _PriceSqu, value, () => PriceSqu); }
        }


        private Nullable<double> _PriceRatio;
        public Nullable<double> PriceRatio
        {
            get { return _PriceRatio; }
            set { SetField(ref _PriceRatio, value, () => PriceRatio); }
        }


        private Nullable<double> _PriceRow;
        public Nullable<double> PriceRow
        {
            get { return _PriceRow; }
            set { SetField(ref _PriceRow, value, () => PriceRow); }
        }

        private Nullable<double> _PriceItem;
        public Nullable<double> PriceItem
        {
            get { return _PriceItem; }
            set { SetField(ref _PriceItem, value, () => PriceItem); }
        }

        private Nullable<Guid> _ShapeId;
        public Nullable<Guid> ShapeId
        {
            get { return _ShapeId; }
            set
            {
                SetField(ref _ShapeId, value, () => ShapeId);
                if (Formula != null)
                    Formula.Changed = true;
            }
        }

        private Shape _Shape;
        public virtual Shape Shape
        {
            get { return _Shape; }
            set { SetField(ref _Shape, value, () => Shape, () => ShapeTitle); }
        } 

        [NotMapped]
        public string ShapeTitle
        {
            get
            {
                return Shape != null && Shape.CatalogNumber > 0 ? $"№{Shape.CatalogNumber}" : String.Empty;
            }
        }

        [ParentItem]
        private Order _Order;
        public virtual Order Order
        {
            get { return _Order; }
            set { SetField(ref _Order, value, () => Order); }
        }

        private byte? _BaseSide;
        /// <summary>
        /// Опорная сторона
        /// </summary>
        public byte? BaseSide
        {
            get { return _BaseSide; }
            set { SetField(ref _BaseSide, value, () => BaseSide); }
        }

        public Guid? OrderId { get; set; }


        protected override string GetTitle()
        {
            return $"Изделие {Num}";
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (Order != null)
            {
                Order.OnRowChanged(this);
                if (!Order.Changed && Changed)
                    Order.Changed = true;
                Order.OnRowChanged(this);
            }
        }
        
        public virtual List<OrderRowSloz> OrderRowSlozs { get; set; } = new List<OrderRowSloz>();

        private bool _setSizeFlag = false;
        public void SetSize(double? shapeH, double? shapeL)
        {
            _setSizeFlag = true;
            if (shapeH != null)
                OverallH = (int) shapeH;
            if (shapeL != null)
                OverallW = (int) shapeL;
            _setSizeFlag = false;
        }

        public string SlozStr
        {
            get {
                return OrderRowSlozs != null && OrderRowSlozs.Count > 0
                 ? string.Join(", ", OrderRowSlozs
                        .Where(x => x.SlozType != null)
                        .Select(x => x.SlozType)
                        .OrderBy(x => x.Enumerator)
                        .Select(y => y.ShortName))
                 : String.Empty; }
        }

        public void AppendSloz(SlozType slozType)
        {
            if (OrderRowSlozs.Exists(x => x != null && x.SlozType != null && x.SlozType.Enumerator == slozType.Enumerator))
                return;
            
            OrderRowSlozs.Add(new OrderRowSloz
            {
                OrderRow = this,
                SlozType = slozType
            });
        }

        public void RemoveSloz(SlozEnum sloz)
        {
            OrderRowSlozs.RemoveAll(x => x.SlozType == null || x.SlozType.Enumerator == sloz);
        }
    }
}
