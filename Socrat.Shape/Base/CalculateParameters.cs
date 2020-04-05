/*Расширение параметров*/
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;


namespace Socrat.Shape.Base
{
    public static class GraphicsPathExtensions
    {
        public static float ComputeArea(this GraphicsPath graphicsPath)
        {
            if (graphicsPath == null)
            {
                throw new ArgumentNullException(nameof(graphicsPath));
            }

            var points = graphicsPath.PathPoints.ToList();
            //Add the first point as the last in order to close the figure and compute area properly.
            points.Add(points[0]);

            return Math.Abs(points.Take(points.Count - 1).Select((p, i) => p.X * points[i + 1].Y - p.Y * points[i + 1].X).Sum()) / 2;
        }

        public static double ComputePerimeter(this GraphicsPath graphicsPath)
        {
            var lineList = new List<Line>();
            if (graphicsPath == null)
            {
                throw new ArgumentNullException(nameof(graphicsPath));
            }

            var points = graphicsPath.PathPoints.ToList();
            var groups = points.Select((item, index) => new { Item = item, Index = index })
                     .GroupBy(x => x.Index % 2 == 0)
                     .ToDictionary(g => g.Key, g => g);

            var evenGroups = groups[true].ToList();
            var oddGroups = groups[false].ToList();
            if (evenGroups.Count() == 0) return 0;
            if (evenGroups.Count() == oddGroups.Count()  )
            {
                for (int i = 0; i < evenGroups.Count(); i++)
                {
                        var evItem = evenGroups[i].Item;
                        lineList.Add(new Line(evenGroups[i].Item, oddGroups[i].Item));
                }
            }
            else
            {
                var lastItem = oddGroups.Last();
                var lastEvenItem = evenGroups.Last();
                for (int i = 0; i < oddGroups.Count(); i++)
                {
                        var evItem = evenGroups[i].Item;
                        lineList.Add(new Line(evenGroups[i].Item, oddGroups[i].Item));
                }
                lineList.Add(new Line(lastItem.Item, lastEvenItem.Item));
            }
            var length = lineList.Sum(x => x.Length);

            return length;
        }
    }



}
