using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.DataProvider.Repos
{
  public  class ShprosElementRepository : UniversalRepository<ShprosElement>
    {
        public int GetItemsCount(Guid id)
        {
            IEnumerable<ShprosElement> shprosElements = SocratEntities.ShprosElements.Where(x => x.Name.Contains("Элемент")&& x.ShapeId==id).ToList();
            int count = (shprosElements.Count() < 0) ? 0 : shprosElements.Count();
            return count ;
        }

        public int GetItemsPackCount(Guid id)
        {
            IEnumerable<ShprosElement> shprosElements = SocratEntities.ShprosElements.Where(x => x.Name.Contains("Набор") && x.ShapeId == id).ToList();
            int count = (shprosElements.Count() < 0) ? 0 : shprosElements.Count();
            return count;
        }
        public double GetMaxMarginOfDirection(string sideDirection)
        {
         var  value = SocratEntities.ShprosElements.Where(x => x.SideVector == sideDirection).Max(x=>x.LeftMargin);
            return value??0.0;
        }

        public Guid GetMaxMarginOfDirectionGuid(string orientation, string sideDirection)
        {
            List<ShprosElement> shprosElements = new List<ShprosElement>();

            var value = SocratEntities.ShprosElements.Where(x => x.SideVector == sideDirection && x.OrientationType == orientation).Max(x=>x.LeftMargin);
            var item = SocratEntities.ShprosElements.Where(x => x.LeftMargin == value).FirstOrDefault();
            return item.Id;
        }

        public double GetMaxMarginOfDirectionById(Guid id,string sideDirection)
        {
            var value = SocratEntities.ShprosElements.Where(x => x.SideVector == sideDirection&& x.ShapeId==id).Max(x => x.LeftMargin);
            return value ?? 0.0;
        }
    }
}
