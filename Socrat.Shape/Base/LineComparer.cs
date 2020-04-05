using Socrat.Core.Entities;
using System.Collections.Generic;

namespace Socrat.Shape.Base
{
    class LineComparer : IEqualityComparer<Line>
    {
        public bool Equals(Line firstLine, Line lastLine)
        {
            return firstLine.Equals(lastLine);
        }

        public int GetHashCode(Line obj)
        {
            return 0;
        }
    }

    class ShprossElementComparer : IEqualityComparer<ShprossElement>
    {
     

        public bool Equals(ShprossElement x, ShprossElement y)
        {
            return x.Equals(y);
        }
      
        public int GetHashCode(ShprossElement obj)
        {
            return obj.GetHashCode();
        }
    }
}
