using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class ContractRepository : UniversalRepository<Contract>
    {
        //public override bool Save(Contract entity)
        //{
        //    bool res = base.Save(entity);

        //    if (entity.ContractAddresses.Count > 0)
        //        res = res && DataHelper.SaveCollection(entity.ContractAddresses);
        //    if (entity.ContractTenderFormulas.Count > 0)
        //        res = res && DataHelper.SaveCollection(entity.ContractTenderFormulas);
        //    if (entity.ContractShippingSquares.Count > 0)
        //        res = res && DataHelper.SaveCollection(entity.ContractShippingSquares);

        //    return res;
        //}
    }
}