using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class OrderRowRepository : UniversalRepository<OrderRow>
    {
        //public override void Save(Model.OrderRow entity)
        //{
        //    try
        //    {
        //        Mapper.Initialize(MapperConfig.CfgDesc);
        //        DataProvider.OrderRow _item;
        //        _item = Mapper.Map<Model.OrderRow, DataProvider.OrderRow>(entity);
        //        _socratEntities.Set<DataProvider.OrderRow>().AddOrUpdate(_item);
        //        if (_socratEntities.SafetySaveChanges())
        //            entity.Changed = false;
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.AddErrorMsgEx($"{this}.Save", e);
        //    }
        //}
    }
}