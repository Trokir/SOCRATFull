using System;
using System.Collections.Generic;
using System.Drawing;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider.Repos;


namespace Socrat.Shape.Factory
{
    public enum SelectedShapeBySides
    {
        Треугольник,
        Четырехугольник,
        Пятиугольник,
        Шестиугольник,
        Семиугольник,
        Восьмиугольник
    }

    public class CurrentShape : Entity
    {
        private BaseShape _GetShape;
        private int _Selector;
        private Guid _Selector_Id;
        private BaseShape _SelectedShape;
        private float _Radius;
        private int _GetCatalogNumber;
        private List<PointF> _getCustomPointsList;
        private bool _IsCustomInputEnabledTrue;
        private bool _IsShapeLoaded;
        ShapeCurrentState shapeState = new ShapeCurrentState();
        /// <summary>
        /// Конструктор
        /// </summary>
        public CurrentShape()
        {
            GetCustomPointsList = new List<PointF>();
        }



        /// <summary>
        /// Получаем список точек PointF с канваса
        /// </summary>
        public List<PointF> GetCustomPointsList
        {
            get { return _getCustomPointsList; }
            set { SetField(ref _getCustomPointsList, value, () => GetCustomPointsList); }
        }

        #region Variables
        /// <summary>
        /// Gets or sets the triangle.
        /// </summary>
        /// <value>
        /// The triangle.
        /// </value>
        Triangle triangle { get; set; }
        /// <summary>
        /// Gets or sets the rectangular.
        /// </summary>
        /// <value>
        /// The rectangular.
        /// </value>
        Rectangular rectangular { get; set; }
        /// <summary>
        /// Gets or sets the pentagon.
        /// </summary>
        /// <value>
        /// The pentagon.
        /// </value>
        Pentagon pentagon { get; set; }
        /// <summary>
        /// Gets or sets the Hexagon.
        /// </summary>
        /// <value>
        /// The Hexagon.
        /// </value>
        Hexagon Hexagon { get; set; }
        /// <summary>
        /// Gets or sets the heptagon.
        /// </summary>
        /// <value>
        /// The heptagon.
        /// </value>
        Heptagon heptagon { get; set; }
        /// <summary>
        /// Gets or sets the octagon.
        /// </summary>
        /// <value>
        /// The octagon.
        /// </value>
        Octagon octagon { get; set; }
        /// <summary>
        /// Получает список точек для поередачи в класс фигуры(из бд или ручного ввода)
        /// </summary>
        List<ShapePoint> getAllPoints { get; set; }
        List<dynamic> GetAllShapeParameters { get; set; } 
          
        /// <summary>
        /// The shape repository
        /// </summary>
        ShapeRepository shapeRepository;
        /// <summary>
        /// The shape point repository
        /// </summary>
        ShapePointRepository shapePointRepository;

        public SelectedShapeBySides SetedShape;


        /// <summary>
        /// Разрешает ручной ввод
        /// </summary>
        public bool IsCustomInputEnabledTrue
        {
            get { return _IsCustomInputEnabledTrue; }
            set { SetField(ref _IsCustomInputEnabledTrue, value, () => IsCustomInputEnabledTrue); }
        }




        /// <summary>
        /// Запрещает ввод когда фигура уже загружена
        /// </summary>
        public bool IsShapeLoaded
        {
            get { return _IsShapeLoaded; }
            set { SetField(ref _IsShapeLoaded, value, () => IsShapeLoaded); }
        }



        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>
        /// The radius.
        /// </value>
        public float Radius
        {
            get { return _Radius; }
            set { SetField(ref _Radius, value, () => Radius); }
        }
        /// <summary>
        ///Получает число сторон фигуры
        /// </summary>
        /// <value>
        /// The selector.
        /// </value>
        public int Selector
        {
            get
            {
                return _Selector;
            }
            set { SetField(ref _Selector, value, () => Selector); }
        }

        public Guid Selector_Id
        {
            get { return _Selector_Id; }
            set { SetField(ref _Selector_Id, value, () => Selector_Id); }
        }



        #endregion
        /// <summary>
        /// Выбор фигуры по общему названию 
        /// </summary>
        /// <returns></returns>
        public List<Core.Entities.Shape> GetAllShapesBySidesCount()
        {
            List<Core.Entities.Shape> shapesGroup = new List<Core.Entities.Shape>();
            int counter = 0;
            switch (SetedShape)
            {

                case SelectedShapeBySides.Треугольник:
                    counter = 3;
                    break;
                case SelectedShapeBySides.Четырехугольник:
                    counter = 4;
                    break;
                case SelectedShapeBySides.Пятиугольник:
                    counter = 5;
                    break;
                case SelectedShapeBySides.Шестиугольник:
                    counter = 6;
                    break;
                case SelectedShapeBySides.Семиугольник:
                    counter = 7;
                    break;
                case SelectedShapeBySides.Восьмиугольник:
                    counter = 8;
                    break;
            }

            using (shapeRepository = new ShapeRepository())
            {
                shapesGroup = shapeRepository.GetAllShapesBySidesCount(counter);
            }

            return shapesGroup;
        }

        /// <summary>
        /// Сортировка по сторонам фигур и вызов нужного конструктора
        /// </summary>
        /// <value>
        /// The get shape.
        /// </value>
        public virtual BaseShape GetShape
        {
            get
            {
                using (shapeRepository = new ShapeRepository())
                {
                    using (shapePointRepository = new ShapePointRepository())
                    {
                        getAllPoints = new List<ShapePoint>();
                        
                        if (IsCustomInputEnabledTrue == true)
                        {
                            getAllPoints = null;
                            getAllPoints = customInputPointsList();
                        }
                        else
                        {
                           
                            getAllPoints = null;
                            var getShape = shapeRepository.GetShapeById(Selector_Id);

                            Selector = shapeRepository.GetSidesCountQuery(getShape);
                           // Selector = getShape.SidesCount;
                            getAllPoints = shapePointRepository.GetAllPointsByShape(Selector_Id);
                            if (GetAllShapeParameters!=null)
                            {
                                GetAllShapeParameters = new List<dynamic>()
                                {
                                    getShape.ShapeParam.B1_param,
                                    getShape.ShapeParam.B2_param,
                                    getShape.ShapeParam.B3_param,
                                    getShape.ShapeParam.B4_param,
                                    getShape.ShapeParam.Chord_param,
                                    getShape.ShapeParam.R_param,
                                    getShape.ShapeParam.R1_param,
                                    getShape.ShapeParam.R2_param,
                                    getShape.ShapeParam.R3_param,
                                    getShape.ShapeParam.R4_param,
                                    getShape.ShapeParam.IsCanCutGlass,
                                    getShape.ShapeParam.IsCanBendDistanceFrame,
                                    getShape.ShapeParam.IsCanFormSeal,
                                    getShape.ShapeParam.IsCanGasFillForm,
                                    getShape.ShapeParam.IsCanVertBendMashineRobot,
                                    getShape.ShapeParam.IsCanVertMashineEdgeMake,
                                    getShape.ShapeParam.CheckCut1_param,
                                    getShape.ShapeParam.CheckCut2_param,
                                    getShape.ShapeParam.CheckCut3_param,
                                    getShape.ShapeParam.CheckCut4_param,
                                    getShape.ShapeParam.CheckCut5_param,
                                    getShape.ShapeParam.CheckCut6_param,
                                    getShape.ShapeParam.CheckCut7_param,
                                    getShape.ShapeParam.CheckCut8_param,
                                };
                            }
                           
                        }

                        _GetShape = null;
                        switch (Selector)
                        {
                            case 3:
                                _GetShape = null;
                               // Shape_62
                                _GetShape = new Triangle(getAllPoints, GetAllShapeParameters);

                                break;
                            case 4:
                                _GetShape = null;
                                rectangular = new Rectangular(getAllPoints, GetAllShapeParameters);
                                _GetShape = rectangular;

                                break;
                            case 5:
                                _GetShape = null;
                                pentagon = new Pentagon(getAllPoints, GetAllShapeParameters);
                                _GetShape = pentagon;

                                break;
                            case 6:
                                _GetShape = null;
                                Hexagon = new Hexagon(getAllPoints, GetAllShapeParameters);
                                _GetShape = Hexagon;

                                break;
                            case 7:
                                _GetShape = null;
                                heptagon = new Heptagon(getAllPoints, GetAllShapeParameters);
                                _GetShape = heptagon;

                                break;
                            case 8:
                                _GetShape = null;
                                octagon = new Octagon(getAllPoints, GetAllShapeParameters);
                                _GetShape = octagon;

                                break;
                        }
                        _GetShape.IsScale = true;
                        return _GetShape;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catNum"></param>
        /// <returns></returns>
        public Core.Entities.Shape GetShapeByCatalogNumber(Guid catNum)
        {
            using (shapeRepository = new ShapeRepository())
            {
                using (shapePointRepository = new ShapePointRepository())
                {

                    var getShape = shapeRepository.GetShapeById(catNum);
                    Selector_Id = getShape.Id;
                    return getShape;
                }
            }

        }
        /// <summary>
        /// Формирование записи каталожного номера
        /// </summary>
        public int GetCatalogNumber
        {
            get
            {
                var getShape = shapeRepository.GetShapeById(Selector_Id);
                if (getShape != null)
                    return getShape.CatalogNumber;
                else return -1;

            }
            set { SetField(ref _GetCatalogNumber, value, () => GetCatalogNumber); }
        }




        /// <summary>
        /// Рабочий объект который может менять свойства
        /// </summary>
        /// <value>
        /// The selected shape.
        /// </value>
        public BaseShape SelectedShape
        {
            get
            {
                _SelectedShape = _GetShape;
                return _SelectedShape;
            }
            set { SetField(ref _GetShape, value, () => _GetShape); }
        }


        /// <summary>
        /// Получает список точек с текущими параметрами
        /// </summary>
        /// <returns></returns>
        public List<ShapePoint> ShapePoints(Core.Entities.Shape shape)
        {
            List<ShapePoint> points = new List<ShapePoint>();
            points = SelectedShape.ShapePointsList();
            foreach (var point in points)
            {
                point.PointX = Math.Ceiling(point.PointX);
                point.PointY = Math.Ceiling(point.PointY);
                point.Shape = shape;
                point.ShapeId = shape.Id;
            }
            return points;
        }







        /// <summary>
        /// Конвертер
        /// </summary>
        /// <param name="cP"></param>
        /// <returns></returns>
        private static ShapePoint CustomPointToCustomPoint(ShapePoint cP) =>
            new ShapePoint(cP.PointX, cP.PointY, cP.PointRadius, cP.PointName);

        /// <summary>
        /// Конвертер
        /// </summary>
        /// <param name="pointF"></param>
        /// <returns></returns>

        private static ShapePoint PointFToCustomPoint(PointF pointF) =>
            new ShapePoint(pointF.X, pointF.Y);

        /// <summary>
        /// Получаем все точки введенные вручную
        /// </summary>
        /// <returns></returns>
        private List<ShapePoint> customInputPointsList()
        {
            List<ShapePoint> currentPointsList = new List<ShapePoint>();
            currentPointsList = GetCustomPointsList.ConvertAll(new Converter<PointF, ShapePoint>(PointFToCustomPoint));
            return currentPointsList;
        }
      


        public IEnumerable<Core.Entities.Shape> GetAllShapes()
        {
            using (shapeRepository = new ShapeRepository())
            {
                using (shapePointRepository = new ShapePointRepository())
                {

                    var getShape = shapeRepository.GetAll();
                    return getShape;
                }
            }

        }




    }
}

