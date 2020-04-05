using System.Collections.Generic;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Lib;

namespace Socrat.References.Formula
{
    public static class FormulaCopier
    {
        public static Core.Entities.Formula Copy(Core.Entities.Formula formulaSource)
        {
            Core.Entities.Formula formulaTarget = FormulaParser.Parse(formulaSource.FormulaStr);
            List<FormulaItem> _sourceItems = formulaSource.GetAllItems();
            List<FormulaItem> _targetItems = formulaTarget.GetAllItems();
            FormulaItem _sorceItem = null;
            foreach (FormulaItem _targetItem in _targetItems)
            {
                _sorceItem =
                    _sourceItems.FirstOrDefault(x => x.GetGloabalPosition() == _targetItem.GetGloabalPosition());
                CopyItemPropertyValues(_sorceItem, _targetItem);
            }

            return formulaTarget;
        }

        private static void CopyItemPropertyValues(FormulaItem sorceItem, FormulaItem targetItem)
        {
            switch (targetItem.MaterialEnum)
            {
                case MaterialEnum.Glass:
                    CopyGlassItemProperty((GlassItem)targetItem, 
                        (DataHelper.UnProxy<GlassItem>(sorceItem))?.GlassItemProperty);
                    break;
                case MaterialEnum.Frame:
                    CopyFrameItemProperty((FrameItem)targetItem, 
                        (DataHelper.UnProxy<FrameItem>(sorceItem))?.FrameItemProperty);
                    break;
                case MaterialEnum.Inset:
                    CopyInsetItemProperty((InsetItem)targetItem, 
                        (DataHelper.UnProxy<InsetItem>(sorceItem))?.InsetItemProperty);
                    break;
                case MaterialEnum.Triplex:
                    CopyTriplexItemProperty((TriplexItem)targetItem, 
                        (DataHelper.UnProxy<TriplexItem>(sorceItem))?.TriplexItemProperty);
                    break;
                case MaterialEnum.GU:
                    CopyUnitItemProperty((GlassUnitItem)targetItem, 
                        (DataHelper.UnProxy<GlassUnitItem>(sorceItem))?.UnitItemProperty);
                    break;
            }
        }

        private static void CopyUnitItemProperty(GlassUnitItem tergrtItem, UnitItemProperty unitItemProperty)
        {
            if (unitItemProperty != null)
            {
                tergrtItem.UnitItemProperty = new UnitItemProperty();
            }
        }

        private static void CopyTriplexItemProperty(TriplexItem targetItem, TriplexItemProperty triplexItemProperty)
        {
            if (triplexItemProperty != null)
            {
                targetItem.TriplexItemProperty = new TriplexItemProperty();
                targetItem.TriplexItemProperty.TriplexItem = targetItem;
                targetItem.TriplexItemProperty.Dent = triplexItemProperty.Dent;
            }
        }

        private static void CopyInsetItemProperty(InsetItem targetItem, InsetItemProperty insetItemProperty)
        {
            if (insetItemProperty != null)
            {
                targetItem.InsetItemProperty = new InsetItemProperty();
                targetItem.InsetItemProperty.InsetItem = targetItem;
                foreach (InsetPosition insetPosition in insetItemProperty.InsetPositions)
                {
                    targetItem.InsetItemProperty.InsetPositions.Add(new InsetPosition
                    {
                        Num = insetPosition.Num,
                        SideNum = insetPosition.SideNum,
                        Position = insetPosition.Position,
                        InsetItemProperty = targetItem.InsetItemProperty
                    });
                }
            }
        }

        private static void CopyFrameItemProperty(FrameItem targetItem, FrameItemProperty frameItemProperty)
        {
            if (frameItemProperty != null)
            {
                targetItem.FrameItemProperty = new FrameItemProperty();
                targetItem.FrameItemProperty.FrameItem = targetItem;
                targetItem.FrameItemProperty.Gaz = frameItemProperty.Gaz;
                targetItem.FrameItemProperty.GermDepth = frameItemProperty.GermDepth;
            }
        }

        private static void CopyGlassItemProperty(GlassItem targetItem, GlassItemProperty glassItemProperty)
        {
            if (glassItemProperty != null)
            {
                targetItem.GlassItemProperty = new GlassItemProperty();
                targetItem.GlassItemProperty.GlassItem = targetItem;
                targetItem.GlassItemProperty.Dent = glassItemProperty.Dent;
            }
        }

        public static TEntity ShallowCopyEntity<TEntity>(TEntity source) where TEntity : class, new()
        {
            var sourceProperties = typeof(TEntity)
                .GetProperties()
                .Where(p => p.CanRead && p.CanWrite 
                  && p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute), true).Length == 0
                  && p.GetCustomAttributes(typeof(Socrat.Core.ParentItemAttribute), true).Length == 0);
            var notVirtualProperties = sourceProperties.Where(p => !p.GetGetMethod().IsVirtual);
            var newObj = new TEntity();

            foreach (var property in notVirtualProperties)
            {
                property.SetValue(newObj, property.GetValue(source, null), null);

            }

            return newObj;

        }
    }
}