using System.Collections.Generic;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class ContractShippingSquareeRepository : UniversalRepository<ContractShippingSquare>
    {
        public override bool Save(ContractShippingSquare entity)
        {
            entity.User = SocratEntities.User;
            return base.Save(entity);
        }

        public override bool Save(IEnumerable<ContractShippingSquare> entities)
        {
            foreach (var _entity in entities)
                if (_entity.Changed)
                    _entity.User = SocratEntities.User;
            return base.Save(entities);
        }
    }
}