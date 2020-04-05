using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Socrat.Shape.Base
{
    public static class LineIntersection
    {
        public static bool IsBothLinesVertical { get; set; }
        public static bool IsBothLinesHorisontal { get; set; }
        public static ShapePoint EqualsShapePoint { get; set; }
        public static ShapePoint EqualsPoint { get; set; }
        public static ShapePoint EqualsLinePoint { get; set; }
        public static ShapePoint CheckIntersectionOfTwoLineSegments(Line lineA, Line lineB, double tolerance = 0.001)
        {

            EqualsShapePoint = new ShapePoint();
            double x1 = lineA.StartPoint.PointX, y1 = lineA.StartPoint.PointY;
            double x2 = lineA.EndPoint.PointX, y2 = lineA.EndPoint.PointY;
            double x3 = lineB.StartPoint.PointX, y3 = lineB.StartPoint.PointY;
            double x4 = lineB.EndPoint.PointX, y4 = lineB.EndPoint.PointY;
            if (Math.Abs(x1 - x2) < tolerance && Math.Abs(x3 - x4) < tolerance && Math.Abs(x1 - x3) < tolerance)
            {
                IsBothLinesVertical = true;
                return default(ShapePoint);
            }
            if (Math.Abs(y1 - y2) < tolerance && Math.Abs(y3 - y4) < tolerance && Math.Abs(y1 - y3) < tolerance)
            {
                IsBothLinesHorisontal = true;
                return default(ShapePoint);
            }
            if (Math.Abs(x1 - x2) < tolerance && Math.Abs(x3 - x4) < tolerance)
            {
                return default(ShapePoint);
            }
            if (Math.Abs(y1 - y2) < tolerance && Math.Abs(y3 - y4) < tolerance)
            {
                return default(ShapePoint);
            }
            double x, y;
            if (Math.Abs(x1 - x2) < tolerance)
            {
                double m2 = (y4 - y3) / (x4 - x3);
                double c2 = -m2 * x3 + y3;
                x = x1;
                y = c2 + m2 * x1;

            }
            else if (Math.Abs(x3 - x4) < tolerance)
            {
                double m1 = (y2 - y1) / (x2 - x1);
                double c1 = -m1 * x1 + y1;
                x = x3;
                y = c1 + m1 * x3;
            }
            else
            {
                double m1 = (y2 - y1) / (x2 - x1);
                double c1 = -m1 * x1 + y1;
                double m2 = (y4 - y3) / (x4 - x3);
                double c2 = -m2 * x3 + y3;
                x = (c1 - c2) / (m2 - m1);
                y = c2 + m2 * x;
                if (!(Math.Abs(-m1 * x + y - c1) < tolerance
                    && Math.Abs(-m2 * x + y - c2) < tolerance))
                {
                    return default(ShapePoint);
                }
            }
            EqualsShapePoint = new ShapePoint(x, y);
            if (IsInsideLine(lineA, EqualsShapePoint) &&
                IsInsideLine(lineB, EqualsShapePoint))
            {
                EqualsShapePoint = new ShapePoint { PointX = x, PointY = y };
                return EqualsShapePoint;
            }
            return default(ShapePoint);
        }
        public static List<ShapePoint> CheckInterseptionPointsListOfArcAndLine(Line line, System.Drawing.Point[] arr, double tolerace = 0.011)
        {
            int counter = 0;
            EqualsPoint = new ShapePoint();
            List<ShapePoint> points = new List<ShapePoint>();
            var shapePoints = new List<ShapePoint>();
            var lineArray = new List<Line>();
            foreach (var item in arr)
            {
                shapePoints.Add(new ShapePoint(item.X, item.Y));
            }
            arr = arr.Distinct().ToArray();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (i == arr.Length - 1) break;
                lineArray.Add(new Line(shapePoints[i], shapePoints[i + 1]));
            }
            do
            {
                foreach (var item in lineArray)
                {
                    counter++;
                    EqualsPoint = CheckIntersectionOfTwoLineSegments(line, item);
                    if (!(EqualsPoint is null))
                    {
                        EqualsPoint.PointX = Math.Round(EqualsPoint.PointX, 0);
                        EqualsPoint.PointY = Math.Round(EqualsPoint.PointY, 0);
                        points.Add(EqualsPoint);
                    }
                }
                points = points.Distinct().ToList();
            } while (counter == lineArray.Count);
            return points;
        }

        public static List<ShapePoint> CheckInterseptionPointsListOfArcAndArc(System.Drawing.Point[] firstArr, System.Drawing.Point[] lastArr, double tolerace = 0.011)
        {
            int counter = 0;
            EqualsPoint = new ShapePoint();
            List<ShapePoint> points = new List<ShapePoint>();
            var firstShapePoints = new List<ShapePoint>();
            var lastShapePoints = new List<ShapePoint>();
            var firstLinesArray = new List<Line>();
            var lastLinesArray = new List<Line>();
            foreach (var item in firstArr)
            {
                firstShapePoints.Add(new ShapePoint(item.X, item.Y));
            }
            foreach (var item in lastArr)
            {
                lastShapePoints.Add(new ShapePoint(item.X, item.Y));
            }
            firstArr = firstArr.Distinct().ToArray();
            lastArr = lastArr.Distinct().ToArray();
            for (int i = 0; i < firstArr.Length - 1; i+=1)
            {
                if (i == firstArr.Length - 1) break;
                firstLinesArray.Add(new Line(firstShapePoints[i], firstShapePoints[i + 1]));
            }
            for (int i = 0; i < lastArr.Length - 1; i+=1)
            {
                if (i == lastArr.Length - 1) break;
                lastLinesArray.Add(new Line(lastShapePoints[i], lastShapePoints[i + 2]));
            }
            do
            {
                foreach (var firstItem in firstLinesArray)
                {
                    counter++;
                    foreach (var lastItem in lastLinesArray)
                    {
                        EqualsPoint = CheckIntersectionOfTwoLineSegments(firstItem, lastItem);
                        if (!(EqualsPoint is null))
                        {
                            EqualsPoint.PointX = Math.Round(EqualsPoint.PointX, 0);
                            EqualsPoint.PointY = Math.Round(EqualsPoint.PointY, 0);
                            points.Add(EqualsPoint);
                        }
                    }
                }
                points = points.Distinct().ToList();
            } while (counter == firstLinesArray.Count);

            return points;
        }

        /// <summary>
        /// Получает массив точек из линии
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns></returns>
        public static System.Drawing.Point[] GetAllPointsInLine(Line line)
        {
            List<System.Drawing.Point> pointsList = new List<System.Drawing.Point>();
            List<PointF> points = new List<PointF>(2)
            {
                line.StartPoint,
                line.EndPoint
            };
            double ratio;
            Vector v, v1;
            v = new Vector(points[1].X - points[0].X, points[1].Y - points[0].Y);
            ratio = 1 / v.Length;
            pointsList.Clear();
            while (ratio <= 1)
            {
                ratio += 0.001;
                v1 = v * ratio;
                pointsList.Add(new System.Drawing.Point((int)Math.Ceiling(points[0].X + (int)v1.X), (int)Math.Ceiling(points[0].Y + (int)v1.Y)));
            }
            return pointsList.Distinct().ToArray();
        }
        public static bool IsInsideLine(Line line, ShapePoint point)
        {
            return (point.PointX >= line.StartPoint.PointX && point.PointX <= line.EndPoint.PointX
                        || point.PointX >= line.EndPoint.PointX && point.PointX <= line.StartPoint.PointX)
                   && (point.PointY >= line.StartPoint.PointY && point.PointY <= line.EndPoint.PointY
                        || point.PointY >= line.EndPoint.PointY && point.PointY <= line.StartPoint.PointY);
        }
        private static bool IsLinePoint(ShapePoint startPoint, ShapePoint endPoint, ShapePoint point)
        {
            var ds1 = point.PointX - startPoint.PointX;
            var ds2 = endPoint.PointX - startPoint.PointX;
            var res1 = ds1 / ds2;
            if (double.IsNaN(res1))
            {
                res1 = 0;
            }

            var ds3 = point.PointY - startPoint.PointY;
            var ds4 = endPoint.PointY - startPoint.PointY;
            var res2 = ds3 / ds4;
            if ((point.PointX - startPoint.PointX) / (endPoint.PointX - startPoint.PointX)
                == (point.PointY - startPoint.PointY) / (endPoint.PointY - startPoint.PointY))
            {
                return true;
            }
            else return false;
        }
        public static ShapePoint EndOrStartPoint { get; set; }
        public static bool IsPointEndOfLine(Line line, ShapePoint point)
        {
            EndOrStartPoint = new ShapePoint();
            var linePoints = GetAllPointsInLine(line);
            var startArr = linePoints.Take(2).ToList();
            var startPoint = new ShapePoint(startArr[0].X, startArr[0].Y);
            var endPoint = new ShapePoint(startArr[1].X, startArr[1].Y);
            var stLine = new Line(startPoint, endPoint);
            var endArr = linePoints.Skip(linePoints.Length - 2).ToList();
            var startPoint1 = new ShapePoint(endArr[0].X, endArr[0].Y);
            var endPoint1 = new ShapePoint(endArr[1].X, endArr[1].Y);
            var endLine = new Line(startPoint1, endPoint1);
            if (IsLinePointReg(stLine, point))
            {
                EndOrStartPoint = point;
                return true;
            }
            else if (IsLinePointReg(endLine, point))
            {
                EndOrStartPoint = point;
                return true;
            }
            else { EndOrStartPoint = default(ShapePoint); return false; }
        }
        public static bool IsPointEndOfArc(System.Drawing.Point[] arr, ShapePoint point)
        {
            EndOrStartPoint = new ShapePoint();
            arr = arr.Distinct().ToArray();
            var startArr = arr.Take(2).ToList();
            var startPoint = new ShapePoint(startArr[0].X, startArr[0].Y);
            var endPoint = new ShapePoint(startArr[1].X, startArr[1].Y);
            var stLine = new Line(startPoint, endPoint);
            var endArr = arr.Skip(arr.Length - 2).ToList();
            var startPoint1 = new ShapePoint(endArr[0].X, endArr[0].Y);
            var endPoint1 = new ShapePoint(endArr[0].X, endArr[1].Y);
            var endLine = new Line(startPoint1, endPoint1);
            if (IsLinePointReg(stLine, point))
            {
                EndOrStartPoint = point;
                return true;
            }
            else if (IsLinePointReg(endLine, point))
            {
                EndOrStartPoint = point;
                return true;
            }
            else { EndOrStartPoint = default(ShapePoint); return false; }
        }

        public static bool IsLinePointReg(Line line, ShapePoint point)
        {
            bool result = false;
            EqualsLinePoint = new ShapePoint();
            IEnumerable<System.Drawing.Point> pointsCloseCoord;
            var linePoints = GetAllPointsInLine(line);
            //IsVertical
            if (line.StartPoint.PointX == line.EndPoint.PointX)
            {
                pointsCloseCoord = linePoints.Where
                             (y => y.Y > point.PointY - 4 &&
                                   y.Y < point.PointY + 4
                                   ).ToArray();
                pointsCloseCoord = pointsCloseCoord.Where(x => x.X - 4 < point.PointX && x.X + 4 > point.PointX).ToArray();
                if (pointsCloseCoord.Count() > 0)
                {
                    EqualsLinePoint.PointY = Math.Round((double)pointsCloseCoord.Sum(y => y.Y) / pointsCloseCoord.Count(), 0);
                    EqualsLinePoint.PointX = line.StartPoint.PointX;
                }
                else EqualsLinePoint = default(ShapePoint);
                var p = pointsCloseCoord;
            }

            else if (line.StartPoint.PointY == line.EndPoint.PointY)
            {
                pointsCloseCoord = linePoints.Where
                              (x => x.X > point.PointX - 4 &&
                                    x.X < point.PointX + 4
                                    ).ToArray();
                pointsCloseCoord = pointsCloseCoord.Where(y => y.Y - 4 < point.PointY && y.Y + 4 > point.PointY).ToArray();
                if (pointsCloseCoord.Count() > 0)
                {
                    EqualsLinePoint.PointX = Math.Round((double)pointsCloseCoord.Sum(x => x.X) / pointsCloseCoord.Count(), 0);
                    EqualsLinePoint.PointY = line.StartPoint.PointY;
                }
                else EqualsLinePoint = default(ShapePoint);
                var p = pointsCloseCoord;
            }
            else
            {
                pointsCloseCoord = linePoints.Where
                              (x => x.X > point.PointX - 4 &&
                                    x.X < point.PointX + 4
                                    ).ToArray();
                pointsCloseCoord = pointsCloseCoord.Where
                             (x => x.Y > point.PointY - 4 &&
                                   x.Y < point.PointY + 4);
                if (pointsCloseCoord.Count() > 0)
                {
                    EqualsLinePoint.PointX = Math.Round((double)pointsCloseCoord.Sum(x => x.X) / pointsCloseCoord.Count(), 0);
                    EqualsLinePoint.PointY = Math.Round((double)pointsCloseCoord.Sum(y => y.Y) / pointsCloseCoord.Count(), 0);
                }
                var p = pointsCloseCoord;
            }
            if (!(EqualsLinePoint is null))
            {
                if (EqualsLinePoint.PointX > 0 && EqualsLinePoint.PointY > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public static bool IsArcPointReg(System.Drawing.Point[] arr, ShapePoint point)
        {
            bool result = false;
            EqualsLinePoint = new ShapePoint();
            IEnumerable<System.Drawing.Point> pointsCloseCoord;

            pointsCloseCoord = arr.Where
                          (x => x.X > point.PointX - 6 &&
                                x.X < point.PointX + 6
                                ).ToArray();
            pointsCloseCoord = pointsCloseCoord.Where
                         (x => x.Y > point.PointY - 6 &&
                               x.Y < point.PointY + 6);
            if (pointsCloseCoord.Count() > 0)
            {
                EqualsLinePoint.PointX = Math.Round((double)pointsCloseCoord.Sum(x => x.X) / pointsCloseCoord.Count(), 0);
                EqualsLinePoint.PointY = Math.Round((double)pointsCloseCoord.Sum(y => y.Y) / pointsCloseCoord.Count(), 0);
            }
            var p = pointsCloseCoord;

            if (!(EqualsLinePoint is null))
            {
                if (EqualsLinePoint.PointX > 0 && EqualsLinePoint.PointY > 0)
                {
                    result = true;
                }
            }
            return result;
        }

    }
}
