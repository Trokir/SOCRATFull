/*Класс линия*/
using Socrat.Core.Entities;
using Socrat.Log;
using System;
using System.Diagnostics;

namespace Socrat.Shape
{
    /// <summary>Класс Line</summary>
    public class Line
    {

        #region Variables        
        /// <summary>Gets or sets the start point.</summary>
        /// <value>The start point.</value>
        public ShapePoint StartPoint { get; set; }
        /// <summary>Gets or sets the end point.</summary>
        /// <value>The end point.</value>
        public ShapePoint EndPoint { get; set; }
        /// <summary>Gets the length.
        /// (readOnly)</summary>
        /// <value>The length.</value>
        public double Length { get { return LineLength(); }  }
        public string Name { get; set; }
        public bool IsVertical { get; set; }
        public bool IsHorisontal { get; set; }
        public bool IsAxis { get; set; }
        public Guid? Id { get; set; }
        #endregion


        #region Constructors     

        /// <summary>Initializes a new instance of the <see cref="Line"/> class.</summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        public Line(ShapePoint startPoint, ShapePoint endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
        public Line(ShapePoint startPoint, ShapePoint endPoint,string name)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Name = name;
        }
        public Line(ShapePoint startPoint, ShapePoint endPoint,bool isVertical ,bool isHorisontal)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            IsVertical = isVertical;
            IsHorisontal = isHorisontal;
        }
        public Line(ShapePoint startPoint, ShapePoint endPoint,string name, bool isVertical, bool isHorisontal,bool isAxis=false)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            IsVertical = isVertical;
            IsHorisontal = isHorisontal;
            Name = name;
            IsAxis = isAxis;
        }
        public Line(ShapePoint startPoint, ShapePoint endPoint, string name, bool isVertical, bool isHorisontal, bool isAxis = false,Guid? id =null)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            IsVertical = isVertical;
            IsHorisontal = isHorisontal;
            Name = name;
            IsAxis = isAxis;
            Id = id;
        }
        #endregion

        /// <summary>
        /// Длина отрезка (Теорема Пифагора)
        /// </summary>
        /// <returns></returns>
        private double LineLength()
        {
            
            return Math.Round(Math.Sqrt((StartPoint.PointX - EndPoint.PointX) * (StartPoint.PointX - EndPoint.PointX)
                + (StartPoint.PointY - EndPoint.PointY) * (StartPoint.PointY - EndPoint.PointY)),0); //округленное до двух знаков
        }
        /// <summary>
        /// проверка на параллельность двух линий
        /// </summary>
        /// <param name="firstLine"></param>
        /// <param name="otherLine"></param>
        /// <returns></returns>
        public static bool IsParallel(Line firstLine, Line otherLine)
        {
            return (firstLine.Length - otherLine.Length) < Double.Epsilon;
        }

        

    }
}
