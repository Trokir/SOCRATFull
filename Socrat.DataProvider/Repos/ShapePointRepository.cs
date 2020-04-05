using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Core.Entities;
using Socrat.Log;

namespace Socrat.DataProvider.Repos
{
    public partial class ShapePointRepository : UniversalRepository<Core.Entities.ShapePoint>
    {



        public List<Core.Entities.ShapePoint> GetAllPointsByShape(Guid shapeId)
        {
            List<Core.Entities.ShapePoint> _shapePoints = null;
            try
            {
                _shapePoints = SocratEntities.ShapePoints.OrderBy(x=>x.PointName).Where(x => x.Shape.Id == shapeId).ToList();
               
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.GetAllPointsByShape", e);
            }
            return _shapePoints.ToList();
        }
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public float? GetRadiusByPointNameAndShapeId(Guid id, string name)
        {
            //try
            //{
            var _customPoint = SocratEntities.ShapePoints.FirstOrDefault(x => x.ShapeId == id && x.PointName == name);
            var _shapeRadius = _customPoint.PointRadius;
            _customPoint.Changed = false;
            return (float?)_shapeRadius;

        }
        public string GetPointName(Guid id)
        {
            //try
            //{
            var _customPoint = SocratEntities.ShapePoints.FirstOrDefault(x => x.ShapeId == id);

            var _pName = _customPoint.PointName;
            _customPoint.Changed = false;
            return _pName;

        }


    }

}