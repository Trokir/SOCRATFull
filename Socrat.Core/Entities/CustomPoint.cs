/*Класс точка*/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Socrat.Core.Entities
{
    /// <summary>
    /// Класс точка
    /// </summary>

    public class CustomPoint : Entity
    {
        private double _Point_X;
        private double _Point_Y;
        private string _PointName;
        private Nullable<float> _PointRadius;


        [Display(Description = "Радиус"), Required]
        [MaxLength(2)]
        public Nullable<float> PointRadius
        {
            get {
                
                return _PointRadius;
            }
            set { SetField(ref _PointRadius, value, () => PointRadius); }
        }

        [Display(Description = "Имя точки"), Required]
        [MaxLength(2)]
        public string PointName
        {
            get { return _PointName; }
            set { SetField(ref _PointName, value, () => PointName); }
        }


        [Display(Description = "Координата X"), Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(-200, 200.99)]
        public double Point_X
        {
            get { return _Point_X; }
            set { SetField(ref _Point_X, value, () => Point_X); }
        }


        [Display(Description = "Координата Y"), Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(-200, 200.99)]
        public double Point_Y
        {
            get { return _Point_Y; }
            set { SetField(ref _Point_Y, value, () => Point_Y); }
        }


        private Shape _Shape;
        public Shape Shape
        {
            get { return _Shape; }
            set { SetField(ref _Shape, value, () => Shape); }
        }



        private Guid? _Shape_Id;
        private double _x;
        private double _y;
        private float _radius;
        private string _name;

        public Guid? Shape_Id
        {
            get { return Shape?.Id; }
            set { SetField(ref _Shape_Id, value, () => Shape_Id); }
        } 


        //    public long? Shape_Id {  get {return Shape?.Id; } }










        #region Ctors
        /// <summary>
        /// 
        /// </summary>
        public CustomPoint()
        {
            Point_X = 0;
            Point_Y = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        public CustomPoint(double a)
        {
            Point_X = a;
            Point_Y = a;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public CustomPoint(double x, double y)
        {
            Point_X = x;
            Point_Y = y;
        }
        public CustomPoint(double x, double y, float radius)
        {
            Point_X = x;
            Point_Y = y;
            PointRadius = radius;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        public CustomPoint(CustomPoint point)
        {
            Point_X = point.Point_X;
            Point_Y = point.Point_Y;
        }

        public CustomPoint(double x, double y, float radius, string name)
        {
            Point_X = x;
            Point_Y = y;
            PointRadius = radius;
            PointName = name;
        }
        #endregion
        public static implicit operator PointF(CustomPoint point)
        {
            return new PointF((float)point.Point_X, (float)point.Point_Y);
        }

        public Guid? ShapeId { get; set; }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public float Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Point GetPoint()
        {
            return  new Point();
        }
    }
}
