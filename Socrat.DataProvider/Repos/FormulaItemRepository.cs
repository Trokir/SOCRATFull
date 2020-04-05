using System.Data.Entity.Migrations;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;


namespace Socrat.DataProvider.Repos
{
    internal class FormulaItemRepository : UniversalRepository<FormulaItem>
    {
        public override bool Save(FormulaItem entity)
        {
            bool _res = base.Save(entity);

            MaterialEnum _material;
            switch (entity.MaterialEnum)
            {
                case MaterialEnum.Glass:
                    SaveGlassProperties(entity as GlassItem);
                    break;
                case MaterialEnum.Triplex:
                    SaveTriplexProperties(entity as TriplexItem);
                    break;
                case MaterialEnum.Frame:
                    SaveFrameProperties(entity as FrameItem);
                    break;
                case MaterialEnum.Inset:
                    SetInsertProperties(entity as InsetItem);
                    break;
            }

            _res = _res && SocratEntities.SafetySaveChanges();
            return _res;
        }

        private void SetInsertProperties(InsetItem insetItem)
        {
            Core.Entities.InsetItemProperty _item = insetItem.InsetItemProperty;
            SocratEntities.Set<Core.Entities.InsetItemProperty>().AddOrUpdate(_item);

            DataHelper.SaveCollection(insetItem.InsetItemProperty.InsetPositions);
        }

        private void SaveGlassProperties(GlassItem item)
        {
            Core.Entities.GlassItemProperty _item = item.GlassItemProperty;
            SocratEntities.Set<Core.Entities.GlassItemProperty>().AddOrUpdate(_item);
        }

        private void SaveTriplexProperties(TriplexItem item)
        {
            Core.Entities.TriplexItemProperty _item = item.TriplexItemProperty;
            SocratEntities.Set<Core.Entities.TriplexItemProperty>().AddOrUpdate(_item);
        }

        private void SaveFrameProperties(FrameItem item)
        {
            SocratEntities.Set<Core.Entities.FrameItemProperty>().AddOrUpdate(item.FrameItemProperty);
        }

        internal void TreeDelete(FormulaItem entity)
        {
            if (entity.FormulaItems != null && entity.FormulaItems.Count > 0)
            {
                foreach (FormulaItem item in entity.FormulaItems)
                {
                    TreeDelete(item);
                }
            }
            Delete(entity.Id);
        }
    }
}