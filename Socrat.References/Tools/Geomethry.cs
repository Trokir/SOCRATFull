using System;

namespace Socrat.References.Tools
{
    public class Geomethry
    {
        public static void Test()
        {
            int shapeNumber = 9;
            double l = 550;
            double h1 = 333;
            double h2 = 459;
            double h = 750;
            double l1 = 150;
            double l2 = 217;

            //Опорная точка А - левая нижняя, далее по часам B,C,D,E,F
            //Берем понятные координаты:
            Point pointA = new Point(0, 0);
            Point pointB = new Point(0, h1);
            Point pointC = new Point(l2, h);
            Point pointD = new Point(l - l1, h);
            Point pointE = new Point(l, h2);
            Point pointF = new Point(l, 0);

            LinearibusEquation lineA = new LinearibusEquation(pointA, pointB);
            LinearibusEquation lineB = new LinearibusEquation(pointB, pointC);
            LinearibusEquation lineC = new LinearibusEquation(pointC, pointD);
            LinearibusEquation lineD = new LinearibusEquation(pointD, pointE);
            LinearibusEquation lineE = new LinearibusEquation(pointE, pointF);

            LinearibusEquation newLineA = lineA.Shift(5);
            LinearibusEquation newLineB = lineB.Shift(-5);
            LinearibusEquation newLineC = lineC.Shift(15);
            LinearibusEquation newLineD = lineD.Shift(0);
            LinearibusEquation newLineE = lineE.Shift(27);

            Point newPointA = newLineA.Intersect(newLineE);
            Point newPointB = newLineA.Intersect(newLineE);
            Point newPointC = newLineA.Intersect(newLineE);
            Point newPointD = newLineA.Intersect(newLineE);
            Point newPointF = newLineA.Intersect(newLineE);
            Point newPointG = newLineA.Intersect(newLineE);
        }

        public class Point: ICloneable
        {
            public double X { get; private set; }
            public double Y { get; private set; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public void Move(double shiftX, double shiftY)
            {
                X += shiftX;
                Y += shiftY;
            }

            public object Clone()
            {
                return new Point(X, Y);
            }

            public override string ToString()
            {
                return $"({X},{Y})";
            }
        }

        public class Triangle
        {
            public double CathetoA { get; private set; }
            public double CathetoB { get; private set; }
            public double Hipotenusa { get; private set; }
            public Point A { get; private set; }
            public Point B { get; private set; }
            public Point Root { get; private set; }

            public Triangle(Point pointA, Point pointB, Point pointRoot)
            {

            }
        }

        public class LinearibusEquation
        {
            public double K { get; private set; }
            public double A { get; private set; }

            public Point PointA { get; }
            public Point PointB { get; }

            public LinearibusEquation(Point a, Point b)
            {
                PointA = a.Clone() as Point;
                PointB = b.Clone() as Point;

                K = (PointA.Y - PointB.Y) / (PointA.X - PointB.X); //если infinity - вертикаль, если 0 - горизонталь
                A = ((PointA.X * PointB.Y) - (PointA.Y * PointB.X)) / (PointA.X - PointB.X);
            }

            public LinearibusEquation Shift(double distance, int direction = 1)
            {
                distance = distance * (direction >= 0 ? 1 : -1);
                LinearibusEquation newLine = new LinearibusEquation(PointA, PointB);
                if (newLine.K == double.NegativeInfinity || newLine.K == double.PositiveInfinity)
                {
                    newLine.PointA.Move((distance), 0);
                    newLine.PointB.Move((distance), 0);
                }
                else if (K == 0)
                {
                    newLine.PointA.Move(0, (distance));
                    newLine.PointB.Move(0, (distance));
                }
                else
                    newLine.A = Math.Sqrt((distance * distance) + (distance * ((PointB.Y - PointA.Y) / (PointB.X - PointA.X))));
                return newLine;
            }

            public Point Intersect(LinearibusEquation line)
            {
                if ((line.K - K) == 0 || (K - line.K == 0))
                    return null;
                return new Point
                    (
                        (A - line.A) / (line.K - K),
                        ((line.K * A - line.A * K) / (K - line.K))
                    );
            }

            public override string ToString()
            {
                return $"y = {K}х + {A}";
            }
        }
    }
}
