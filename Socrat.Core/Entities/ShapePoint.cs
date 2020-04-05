using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Socrat.Core.Entities
{
    public class ShapePoint : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public ShapePoint()
        {
            PointX = 0;
            PointY = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        public ShapePoint(double a)
        {
            PointX = a;
            PointY = a;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public ShapePoint(double x, double y)
        {
            PointX = x;
            PointY = y;
        }
        public ShapePoint(double x, double y, float? radius)
        {
            PointX = x;
            PointY = y;
            PointRadius = radius;
        }
        public ShapePoint(double x, double y, float? radius, string name)
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
        public ShapePoint(ShapePoint point)
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
            get { return _pointX; }
            set { SetField(ref _pointX, value, () => PointX); }
        }

        private double _pointY;
        public double PointY
        {
            get { return _pointY; }
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
        private Shape _shape;

        public virtual Shape Shape
        {
            get { return _shape; }
            set { SetField(ref _shape, value, () => Shape); }
        }



        #region Перегрузка операторов Равенства , Неравенства ,Equals ,GetHashCode
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <returns></returns>
        public static bool operator ==(ShapePoint firstPoint, ShapePoint secondPoint)
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
        public static bool operator !=(ShapePoint firstPoint, ShapePoint secondPoint)
        {
            return !(firstPoint == secondPoint);
        }
        

        /// <summary>Performs an implicit conversion from<see cref="ShapePoint"/> to <see cref = "Point" />.</ summary >
        /// < param name= "point" > The point.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Point(ShapePoint point)
        {
            return new Point((int)point.PointX, (int)point.PointY);
        }
        /// <summary>Performs an implicit conversion from <see cref="ShapePoint"/> to <see cref="PointF"/>.</summary>
        /// <param name="point">The point.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator PointF(ShapePoint point)
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
        public static implicit operator ShapePoint(PointF point)
        {
            return new ShapePoint((int)point.X, (int)point.Y);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherPoint"></param>
        /// <returns></returns>
        protected bool Equals(ShapePoint otherPoint)
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
            return Equals((ShapePoint)obj);
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
    }
}
