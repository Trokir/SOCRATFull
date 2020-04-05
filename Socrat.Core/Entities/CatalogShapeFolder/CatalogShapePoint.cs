using Socrat.Core.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;


namespace Socrat.Core.Entities.CatalogShapeFolder
{
    public class CatalogShapePoint : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public CatalogShapePoint()
        {
            PointX = 0;
            PointY = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        public CatalogShapePoint(double a)
        {
            PointX = a;
            PointY = a;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public CatalogShapePoint(double x, double y)
        {
            PointX = x;
            PointY = y;
        }
        public CatalogShapePoint(double x, double y, float? radius)
        {
            PointX = x;
            PointY = y;
            PointRadius = radius;
        }
        public CatalogShapePoint(double x, double y, float? radius, string name)
        {
            PointX = x;
            PointY = y;
            PointRadius = radius;
            PointName = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        public CatalogShapePoint(ShapePoint point)
        {
            PointX = point.PointX;
            PointY = point.PointY;
        }

        private string _pointName;


        public string PointName
        {
            get { return _pointName; }
            set { SetField(ref _pointName, value, () => PointName); }
        }

        private double _pointX;
        public double PointX
        {
            get
            {
                // return _pointX;
                return _pointX;
            }
            set { SetField(ref _pointX, value, () => PointX); }
        }

        private double _pointY;
        public double PointY
        {
            get
            {
                //  return _pointY;
                return _pointY;
            }
            set { SetField(ref _pointY, value, () => PointY); }
        }
        private float? _pointRadius;

        public float? PointRadius
        {
            get
            {
                return _pointRadius;
            }
            set { SetField(ref _pointRadius, value, () => PointRadius); }
        }

        public Guid? ShapeId { get; set; }
        private CatalogShape _catalogShape;

        [ParentItem]
        [Display(AutoGenerateField = false)]
        public virtual CatalogShape CatalogShape
        {
            get { return _catalogShape; }
            set { SetField(ref _catalogShape, value, () => CatalogShape); }
        }



        public override string ToString()
        {
            return $"{PointName}:({PointX},{PointY})";
        }


        #region Перегрузка операторов Равенства , Неравенства ,Equals ,GetHashCode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <returns></returns>
        public static bool operator ==(CatalogShapePoint firstPoint, CatalogShapePoint secondPoint)
        {
            if (Math.Abs(firstPoint.PointX - secondPoint.PointX) < Double.Epsilon && Math.Abs(firstPoint.PointY - secondPoint.PointY) < Double.Epsilon)
                return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <returns></returns>
        public static bool operator !=(CatalogShapePoint firstPoint, CatalogShapePoint secondPoint)
        {
            return !(firstPoint == secondPoint);
        }


        /// <summary>Performs an implicit conversion from<see cref="ShapePoint"/> to <see cref = "Point" />.</ summary >
        /// < param name= "point" > The point.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Point(CatalogShapePoint point)
        {
            return new Point((int)point.PointX, (int)point.PointY);
        }
        /// <summary>Performs an implicit conversion from <see cref="ShapePoint"/> to <see cref="PointF"/>.</summary>
        /// <param name="point">The point.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator PointF(CatalogShapePoint point)
        {
            return new PointF((float)point.PointX, (float)point.PointY);
        }






        /// <summary>
        /// Performs an implicit conversion from <see cref="PointF"/> to <see cref="ShapePoint"/>.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator CatalogShapePoint(PointF point)
        {
            return new CatalogShapePoint((int)point.X, (int)point.Y);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherPoint"></param>
        /// <returns></returns>
        protected bool Equals(CatalogShapePoint otherPoint)
        {
            return PointX.Equals(otherPoint.PointX) && PointY.Equals(otherPoint.PointY);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CatalogShapePoint)obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked { return (PointX.GetHashCode() * 397) ^ PointY.GetHashCode(); }
        }
        #endregion

        public override string ToString(Template template)
        {
            return $"Name ={PointName} X={PointX} Y ={PointY}  ";
        }
    }
}

