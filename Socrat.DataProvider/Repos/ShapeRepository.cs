using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Core.Entities;
using Socrat.Log;
using Shape = Socrat.Core.Entities.Shape;

namespace Socrat.DataProvider.Repos
{
    public partial class ShapeRepository : UniversalRepository<Shape>
    {

        public int GetShapeBySidesCount(int sidesCount)
        {
            var shape = SocratEntities.Shapes.FirstOrDefault(x => x.SidesCount == sidesCount);
            return shape.SidesCount;
        }

        public List<Shape> GetAllShapesBySidesCount(int counter)
        {
            List<Shape> shapes = null;
            try
            {
                shapes = SocratEntities.Shapes.Where(x => x.SidesCount == counter).ToList();

            }
            catch (Exception e)
            {

                Logger.AddErrorMsgEx($"{this}.GetAllShapesBySidesCount", e);
            }
            return shapes.ToList();
        }


        /// <summary>
        /// Gets the shape by catalog number.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Shape GetShapeById(Guid Id)
        {
            var shape = SocratEntities.Shapes.FirstOrDefault(x => x.Id == Id);
            return shape;
        }

        public Shape GetDefaultShape()
        {
            Shape shape =null;
            try
            {
                 shape = SocratEntities.Shapes.Single(x => x.CatalogNumber == 0 && x.IsCatalogShape == true);
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.GetDefaultShape", e);
            }
            return shape;

        }
        /// <summary>
        /// Gets the radius by point name and shape identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public double? GetRadiusByPointNameAndShapeId(Guid id, string name)
        {
            var _customPoint =
                   SocratEntities.ShapePoints.FirstOrDefault(x => x.ShapeId == id && x.PointName == name);
            var _shapeRadius = _customPoint.PointRadius;
            _customPoint.Changed = false;
            return _shapeRadius;
        }

        public int GetSidesCountQuery(Shape shape)
        {
            List<Core.Entities.ShapePoint> points = null;

            points = SocratEntities.ShapePoints.Where(x => x.ShapeId == shape.Id && x.PointName.Length == 1).ToList();
            return points.Count;
        }
        public IEnumerable<Core.Entities.Shape> GetAllShapesFromCatalog()
        {
            var _shapes = SocratEntities.Shapes.OrderBy(x => x.CatalogNumber).Where(x => x.IsCatalogShape == true).ToList();
            return _shapes;
        }

        public IEnumerable<Core.Entities.Shape> GetAllShapesFromOrder()
        {
            var _shapes = SocratEntities.Shapes.OrderBy(x => x.CatalogNumber).Where(x => x.IsCatalogShape == false).ToList();
            return _shapes;
        }
    }

}