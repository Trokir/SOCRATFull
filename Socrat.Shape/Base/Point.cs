/*Класс точка*/
using System;
using System.ComponentModel;
using System.Drawing;

namespace Socrat.Shape
{
    /// <summary>
    /// Класс точка
    /// </summary>
    
    public class MCustPoint 
    {
        /// <summary>
        /// X
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        public float Radius { get; set; }

        #region Ctors
        /// <summary>
        /// 
        /// </summary>
        public MCustPoint()
        {
            X = 0;
            Y = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        public MCustPoint(double a)
        {
            X = a;
            Y = a;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public MCustPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
        public MCustPoint(double x, double y,float radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }
        public MCustPoint(double x, double y, float radius,string name)
        {
            X = x;
            Y = y;
            Radius = radius;
            Name = name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        public MCustPoint(Core.Entities.ShapePoint point)
        {
            X = point.X;
            Y = point.Y;
        }
        #endregion

        #region Перегрузка операторов Равенства , Неравенства ,Equals ,GetHashCode
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <returns></returns>
        public static bool operator ==(Core.Entities.ShapePoint firstPoint, MCustPoint secondPoint)
        {
            if (Math.Abs(firstPoint.X - secondPoint.X) < Double.Epsilon && Math.Abs(firstPoint.Y - secondPoint.Y) < Double.Epsilon)
                return true;
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <returns></returns>
        public static bool operator !=(Core.Entities.ShapePoint firstPoint, MCustPoint secondPoint)
        {
            return !(firstPoint == secondPoint);
        }
        /// <summary>Performs an implicit conversion from <see cref="Core.Entities.ShapePoint"/> to <see cref="Point"/>.</summary>
        /// <param name="point">The point.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Point(Core.Entities.ShapePoint point)
        {
            return new Point ((int)point.X, (int)point.Y) ;
        }
        /// <summary>Performs an implicit conversion from <see cref="Core.Entities.ShapePoint"/> to <see cref="PointF"/>.</summary>
        /// <param name="point">The point.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator PointF(Core.Entities.ShapePoint point)
        {
            return new PointF((float)point.X, (float)point.Y);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Core.Entities.ShapePoint"/> to <see cref="Socrat.Model.Shapes.Core.Entities.ShapePoint"/>.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Socrat.Model.Shapes.Core.Entities.ShapePoint(Core.Entities.ShapePoint point)
        {
            return new Socrat.Model.Shapes.Core.Entities.ShapePoint();
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="PointF"/> to <see cref="Core.Entities.ShapePoint"/>.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator MCustPoint(PointF point)
        {
            return new MCustPoint((int)point.X, (int)point.Y);
        }

        public static implicit operator MCustPoint(Model.Shapes.Core.Entities.ShapePoint point)
        {
            return new MCustPoint(point.Point_X,point.Point_Y);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherPoint"></param>
        /// <returns></returns>
        protected bool Equals(Core.Entities.ShapePoint otherPoint)
        {
            return X.Equals(otherPoint.X) && Y.Equals(otherPoint.Y);
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
            return Equals((Core.Entities.ShapePoint)obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked {return (X.GetHashCode() * 397) ^ Y.GetHashCode(); }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("X={0}:Y={1}", Math.Round(X, 2), Math.Round(Y, 2));
        }
    }
}
