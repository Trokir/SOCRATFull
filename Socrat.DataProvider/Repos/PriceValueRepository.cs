namespace Socrat.DataProvider.Repos
{
    internal class PriceValueRepository : UniversalRepository<Core.Entities.PriceValue>
    {
        public override bool Save(Core.Entities.PriceValue entity)
        {
            bool res = base.Save(entity);
            Core.Entities.MaterialMarkType material = entity.MaterialNom.MaterialSizeType.MaterialMarkType;
            DataHelper.Save(material);
            //MaterialNom.MaterialSizeType.MaterialMarkType.Name
            return res;
        }
    }
}