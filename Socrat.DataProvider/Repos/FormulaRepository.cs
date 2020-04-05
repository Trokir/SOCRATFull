using System;
using Socrat.Core.Entities;
using Socrat.Log;

namespace Socrat.DataProvider.Repos
{
    internal class FormulaRepository : UniversalRepository<Formula>
    {
        //public override bool Save(Formula entity)
        //{
        //    bool _res = false;
        //    try
        //    {
        //        entity.Ordering();
        //        _res = base.Save(entity);
                
        //        //удаление и рекурсивное сохранение дерева элементов формулы
        //        using (FormulaItemRepository _repo = new FormulaItemRepository())
        //        {
        //            foreach (FormulaItem item in entity.Items)
        //            {
        //                SaveFormulaItem(_repo, item);
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.AddErrorEx("FormulaRepository.Save", e);
        //    }

        //    return _res;
        //}

        //private void SaveFormulaItem(FormulaItemRepository repo, FormulaItem item)
        //{
        //    try
        //    {
        //        repo.Save(item);
        //        foreach (FormulaItem formulaItem in item.FormulaItems)
        //        {
        //            SaveFormulaItem(repo, formulaItem);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.AddErrorEx("FormulaRepository.SaveFormulaItem", e);
        //    }
        //}
    }
}