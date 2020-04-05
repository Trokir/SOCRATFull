using Socrat.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Socrat.DataProvider.Repos;


namespace Socrat.Shape.Factory
{

    public class CurrentUserShape : Entity
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
        public bool IsDrawPictureToAnotherWindows { get; set; }

        readonly ShapeCurrentState shapeState = new ShapeCurrentState();
        /// <summary>
        /// Конструктор
        /// </summary>
        public CurrentUserShape()
        {
            GetCustomPointsList = new List<PointF>();

        }
        List<dynamic> GetAllShapeParameters { get; set; }
        List<dynamic> GetAllShapeParameters1 { get; set; }

        private List<PointF> _GetCustomInputPointsList;
        public List<PointF> GetCustomInputPointsList
        {
            get { return _GetCustomInputPointsList; }
            set { SetField(ref _GetCustomInputPointsList, value, () => GetCustomInputPointsList); }
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
        /// Получает список точек для поередачи в класс фигуры(из бд или ручного ввода)
        /// </summary>
        List<Core.Entities.ShapePoint> getAllPoints { get; set; }
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


        private bool _IsCanDrawSizeLines;
        public bool IsCanDrawSizeLines
        {
            get { return _IsCanDrawSizeLines; }
            set { SetField(ref _IsCanDrawSizeLines, value, () => IsCanDrawSizeLines); }
        }


        #endregion

        private List<dynamic> UpdateShapeParameters(List<dynamic> shapeParams, double? arg1, double? arg2, double? arg3, double? arg4)
        {
            shapeParams.Add(arg1);
            shapeParams.Add(arg2);
            shapeParams.Add(arg3);
            shapeParams.Add(arg4);
            return new List<dynamic>();
        }

        private static Core.Entities.ShapePoint PointFToCustomPoint(PointF pointF) =>
            new Core.Entities.ShapePoint(pointF.X, pointF.Y);
        private List<Core.Entities.ShapePoint> customInputPointsList()
        {
            var currentPointsList = GetCustomPointsList.ConvertAll(new Converter<PointF, Core.Entities.ShapePoint>(PointFToCustomPoint));
            return currentPointsList;
        }
        /// <summary>
        /// Creates the shape object.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="list1">The list1.</param>
        /// <param name="catNumber">The cat number.</param>
        /// <returns></returns>
        public object CreateShapeObject(List<Core.Entities.ShapePoint> list, List<dynamic> list1, int catNumber)
        {
            
            var shape = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).
                 First(x => x.Name == $"Shape_{catNumber}");
            var obj = Activator.CreateInstance(shape, list, list1) as BaseShape;
            return obj;
        }
        public virtual BaseShape GetShape
        {
            get
            {
                using (shapeRepository = new ShapeRepository())
                {
                    using (shapePointRepository = new ShapePointRepository())
                    {
                        var getShape = shapeRepository.GetShapeById(Selector_Id);
                        getAllPoints = new List<Core.Entities.ShapePoint>();
                        if (IsCustomInputEnabledTrue == true)
                        {
                            getAllPoints = null;
                            getAllPoints = customInputPointsList();
                        }
                        else
                        {
                            getAllPoints = null;
                            Selector = shapeRepository.GetSidesCountQuery(getShape);
                            getAllPoints = shapePointRepository.GetAllPointsByShape(Selector_Id);
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
                                    getShape.ShapeParam.IsToothVector,
                                    getShape.ShapeParam.CheckCut1_param,
                                    getShape.ShapeParam.CheckCut2_param,
                                    getShape.ShapeParam.CheckCut3_param,
                                    getShape.ShapeParam.CheckCut4_param,
                                    getShape.ShapeParam.CheckCut5_param,
                                    getShape.ShapeParam.CheckCut6_param,
                                    getShape.ShapeParam.CheckCut7_param,
                                    getShape.ShapeParam.CheckCut8_param,
                            };
                            UpdateShapeParameters(GetAllShapeParameters,
                                getShape.ShapeParam.L1_param,
                                getShape.ShapeParam.L2_param,
                                getShape.ShapeParam.H1_param,
                                getShape.ShapeParam.H2_param);
                            GetAllShapeParameters1 = new List<dynamic>();
                            GetAllShapeParameters1 = GetAllShapeParameters;

                        }
                        var selectCatalogNumber = shapeRepository.GetShapeById(Selector_Id).CatalogNumber;
                        _GetShape = CreateShapeObject(getAllPoints, GetAllShapeParameters, selectCatalogNumber) as BaseShape;
                        switch (selectCatalogNumber)
                        {
                            case 3:
                                _GetShape.SetH1 = getShape.ShapeParam.H1_param + 1 ?? 0;
                                break;
                            case 20:
                                _GetShape.SetH1 = getShape.ShapeParam.H1_param ?? 0;
                                break;
                            case 50:
                                _GetShape.SetH = getShape.ShapeParam.H_param ?? 0;
                                break;
                            case 51:
                                _GetShape.SetRadius = getShape.ShapeParam.R_param ?? 0;
                                break;
                            case 58:
                                _GetShape.SetRadius = getShape.ShapeParam.R_param ?? 0;
                                break;
                            case 60:
                                _GetShape.SetH1 = getShape.ShapeParam.H1_param ?? 0;
                                break;
                        }
                        #region Temp
                        //switch (Selector)
                        //{
                        //    case 3:
                        //        var getShape = shapeRepository.GetShapeById(Selector_Id);
                        //        switch (selectCatalogNumber)
                        //        {
                        //            case 20:
                        //                _GetShape = new Shape_20(getAllPoints, GetAllShapeParameters) as Triangle;
                        //                break;
                        //            case 43:
                        //                _GetShape = new Shape_43(getAllPoints, GetAllShapeParameters) as Triangle;
                        //                break;
                        //            case 44:
                        //                _GetShape = new Shape_44(getAllPoints, GetAllShapeParameters) as Triangle;
                        //                break;
                        //            case 59:
                        //                _GetShape = new Shape_59(getAllPoints, GetAllShapeParameters) as Triangle;
                        //                break;
                        //            case 60:
                        //                _GetShape = new Shape_60(getAllPoints, GetAllShapeParameters) as Triangle;
                        //                _GetShape.SetH1 = getShape.ShapeParam.H1_param ?? 0;
                        //                break;
                        //            case 61:
                        //                _GetShape = new Shape_61(getAllPoints, GetAllShapeParameters) as Triangle;
                        //                break;
                        //            case 62:
                        //                _GetShape = new Shape_62(getAllPoints, GetAllShapeParameters) as Triangle;
                        //                break;
                        //            default:
                        //                _GetShape = triangle;
                        //                break;
                        //        }
                        //        break;
                        //    case 4:
                        //        var getShapeRect = shapeRepository.GetShapeById(Selector_Id);
                        //        switch (selectCatalogNumber)
                        //        {
                        //            case 0:
                        //                _GetShape = new Shape_0(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 1:

                        //                 _GetShape = new Shape_1(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 2:
                        //                _GetShape = new Shape_2(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 5:
                        //                _GetShape = new Shape_5(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 6:
                        //                _GetShape = new Shape_6(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 11:
                        //                _GetShape = new Shape_11(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 12:
                        //                _GetShape = new Shape_12(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 13:
                        //                _GetShape = new Shape_13(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 14:
                        //                _GetShape = new Shape_14(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 15:
                        //                _GetShape = new Shape_15(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 16:
                        //                _GetShape = new Shape_16(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 17:
                        //                _GetShape = new Shape_17(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 18:
                        //                _GetShape = new Shape_18(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 25:
                        //                _GetShape = new Shape_25(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 26:
                        //                _GetShape = new Shape_26(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 27:
                        //                _GetShape = new Shape_27(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 28:
                        //                _GetShape = new Shape_28(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 29:
                        //                _GetShape = new Shape_29(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 30:
                        //                _GetShape = new Shape_30(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 31:
                        //                _GetShape = new Shape_31(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 32:
                        //                _GetShape = new Shape_32(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 33:
                        //                _GetShape = new Shape_33(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 34:
                        //                _GetShape = new Shape_34(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 35:
                        //                _GetShape = new Shape_35(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 36:
                        //                _GetShape = new Shape_36(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 37:
                        //                _GetShape = new Shape_37(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 38:
                        //                _GetShape = new Shape_38(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 45:
                        //                _GetShape = new Shape_45(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 46:
                        //                _GetShape = new Shape_46(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 47:
                        //                _GetShape = new Shape_47(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 49:
                        //                _GetShape = new Shape_49(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 50:
                        //                _GetShape = new Shape_50(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                _GetShape.SetH = getShapeRect.ShapeParam.H_param ?? 0;
                        //                break;
                        //            case 51:
                        //                _GetShape = new Shape_51(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                _GetShape.SetRadius = getShapeRect.ShapeParam.R_param ?? 0;
                        //                break;
                        //            case 52:
                        //                _GetShape = new Shape_52(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 53:
                        //                _GetShape = new Shape_53(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 54:
                        //                _GetShape = new Shape_54(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 55:
                        //                _GetShape = new Shape_55(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 56:
                        //                _GetShape = new Shape_51(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 57:
                        //                _GetShape = new Shape_57(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                break;
                        //            case 58:
                        //                _GetShape = new Shape_58(getAllPoints, GetAllShapeParameters) as Rectangular;
                        //                _GetShape.SetRadius = getShapeRect.ShapeParam.R_param ?? 0;
                        //                break;
                        //            default:
                        //                _GetShape = rectangular;
                        //                break;
                        //        }

                        //        break;
                        //    case 5:
                        //        var getShape1 = shapeRepository.GetShapeById(Selector_Id);
                        //        switch (selectCatalogNumber)
                        //        {
                        //            case 3:
                        //                _GetShape = new Shape_3(getAllPoints, GetAllShapeParameters) as Pentagon;
                        //                _GetShape.SetH1 = getShape1.ShapeParam.H1_param + 1 ?? 0;
                        //                break;
                        //            case 4:
                        //                _GetShape = new Shape_4(getAllPoints, GetAllShapeParameters) as Pentagon;
                        //                break;
                        //            case 7:
                        //                _GetShape = new Shape_7(getAllPoints, GetAllShapeParameters) as Pentagon;
                        //                break;
                        //            case 8:
                        //                _GetShape = new Shape_8(getAllPoints, GetAllShapeParameters) as Pentagon;
                        //                break;
                        //            case 21:
                        //                _GetShape = new Shape_21(getAllPoints, GetAllShapeParameters) as Pentagon;
                        //                break;
                        //            case 40:
                        //                _GetShape = new Shape_40(getAllPoints, GetAllShapeParameters) as Pentagon;
                        //                break;
                        //            case 41:
                        //                _GetShape = new Shape_41(getAllPoints, GetAllShapeParameters) as Pentagon;
                        //                break;
                        //            default:
                        //                _GetShape = pentagon;
                        //                break;
                        //        }
                        //        break;

                        //    case 6:
                        //        switch (selectCatalogNumber)
                        //        {
                        //            case 9:
                        //                _GetShape = new Shape_9(getAllPoints, GetAllShapeParameters) as Hexagon;
                        //                break;
                        //            case 10:
                        //                _GetShape = new Shape_10(getAllPoints, GetAllShapeParameters) as Hexagon;
                        //                break;
                        //            case 22:
                        //                _GetShape = new Shape_22(getAllPoints, GetAllShapeParameters) as Hexagon;
                        //                break;
                        //            case 42:
                        //                _GetShape = new Shape_42(getAllPoints, GetAllShapeParameters) as Hexagon;
                        //                break;
                        //            default:
                        //                _GetShape = Hexagon;
                        //                break;
                        //        }
                        //        break;
                        //    case 7:
                        //        switch (selectCatalogNumber)
                        //        {
                        //            case 23:
                        //                _GetShape = new Shape_23(getAllPoints, GetAllShapeParameters) as Heptagon;
                        //                break;
                        //            default:
                        //                _GetShape = heptagon;
                        //                break;
                        //        }
                        //        break;
                        //    case 8:
                        //        switch (selectCatalogNumber)
                        //        {
                        //            case 19:
                        //                _GetShape = new Shape_19(getAllPoints, GetAllShapeParameters) as Octagon;
                        //                break;
                        //            case 24:
                        //                _GetShape = new Shape_24(getAllPoints, GetAllShapeParameters) as Octagon;
                        //                break;
                        //            case 48:
                        //                _GetShape = new Shape_48(getAllPoints, GetAllShapeParameters) as Octagon;
                        //                break;
                        //            default:
                        //                _GetShape = octagon;
                        //                break;
                        //        }
                        //        break;
                        //    default:
                        //        var shapeDefault = new Shape_0(getAllPoints, GetAllShapeParameters)
                        //        {
                        //            IsShowSizeAttr = _IsCanDrawSizeLines
                        //        };
                        //        _GetShape = shapeDefault;
                        //        break;

                        //}
                        #endregion
                        _GetShape.IsShowSizeAttr = _IsCanDrawSizeLines;
                        _GetShape.IsAddAdwansedParams = shapeRepository.GetShapeById(Selector_Id).IsAddAdwansedParams;
                        _GetShape.IsDrawPictureToAnotherWindows = IsDrawPictureToAnotherWindows;
                        if (Hvalue != null && Hvalue != 0 && Lvalue != null && Lvalue != 0)
                        {
                            _GetShape.SetH = Hvalue.Value;
                            _GetShape.SetL = Lvalue.Value;
                        }
                        return _GetShape;
                    }
                }
            }
        }
        public bool CheckValidValue()
        {
            return _GetShape.CheckValidSize();
        }

        private bool _IsAddAdwansedParams;
        public bool IsAddAdwansedParams
        {
            get { return _IsAddAdwansedParams; }
            set { SetField(ref _IsAddAdwansedParams, value, () => IsAddAdwansedParams); }
        }



        private double? _Hvalue;
        public double? Hvalue
        {
            get { return _Hvalue; }
            set { SetField(ref _Hvalue, value, () => Hvalue); }
        }

        private double? _Lvalue;
        public double? Lvalue
        {
            get { return _Lvalue; }
            set { SetField(ref _Lvalue, value, () => Lvalue); }
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
                    _GetShape.IsScale = false;
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
        public int GetCatalogNumberById(Guid id)
        {
            return shapeRepository.GetShapeById(id).CatalogNumber;

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
        public List<Core.Entities.ShapePoint> ShapePoints(Core.Entities.Shape shape)
        {
            List<Core.Entities.ShapePoint> points = new List<Core.Entities.ShapePoint>();
            points = SelectedShape.ShapePointsList();
            foreach (var point in points)
            {
                point.Shape = shape;
                point.ShapeId = shape.Id;
            }
            return points;
        }

        public IEnumerable<Core.Entities.Shape> GetAllShapesFromCatalog()
        {
            using (shapeRepository = new ShapeRepository())
            {
                var getShape = shapeRepository.GetAllShapesFromCatalog();
                // var getShape = shapeRepository.GetAllShapesFromOrder();
                //  var getShape = shapeRepository.GetAll().OrderBy(x=>x.CatalogNumber).ToList();
                return getShape;
            }
        }
        public IEnumerable<Core.Entities.Shape> GetAllShapesFromOrder()
        {
            using (shapeRepository = new ShapeRepository())
            {
                var getShape = shapeRepository.GetAllShapesFromOrder();
                return getShape;
            }
        }



    }
}