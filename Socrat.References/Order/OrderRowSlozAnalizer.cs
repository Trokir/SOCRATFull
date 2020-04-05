using System.Collections.Generic;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;

namespace Socrat.References.Order
{
    /// <summary>
    /// Анализатор сложности изделия
    /// </summary>
    public static class OrderRowSlozAnalizer
    {
        public static void Analise(OrderRow row)
        {
            List<SlozEnum> _slozs = new List<SlozEnum>();
            if (row == null || row.Formula == null)
                return;

            //нарезка
            if (row.Formula.RootItem.MaterialEnum == MaterialEnum.Glass)
            {
                _slozs.Add(SlozEnum.GlassCutting);
            }
            //Форма
            if (row.Shape != null && row.Shape.CatalogNumber >0)
            {
                _slozs.Add(SlozEnum.Figure);
            }
            //площать
            if (row.Square < 0.3)
            {
                _slozs.Add(SlozEnum.TinySquare);
            }
            else if (row.Square > 2)
            {
                _slozs.Add(SlozEnum.LargeSquare);
            }
            else if (row.Square > 0.3 && row.Square < 0.5)
            {
                _slozs.Add(SlozEnum.SmallSquare);
            }
            //газ
            var _frames = row.Formula.GetAllItems().Where(x => x.MaterialEnum == MaterialEnum.Frame);
            if (_frames != null && _frames.Count() > 0)
            {
                FrameItem _frameItem;
                foreach (FormulaItem formulaItem in _frames)
                {
                    _frameItem = formulaItem as FrameItem;
                    if (_frameItem != null && (_frameItem?.FrameItemProperty?.Gaz ?? false))
                    {
                        _slozs.Add(SlozEnum.Gaz);
                        break;
                    }
                }
            }
            //триплекс
            var  _triplexes = row.Formula.GetAllItems().Where(x => x.MaterialEnum == MaterialEnum.Triplex);
            if (_triplexes != null && _triplexes.Count() > 0)
            {
                _slozs.Add(SlozEnum.Triplex);
            }
            //сложности операций
            SlozEnum[] _processingSlozes = row.Formula.GetProcessingSlozes();
            foreach (SlozEnum slozEnum in _processingSlozes)
            {
                if (!_slozs.Contains(slozEnum))
                    _slozs.Add(slozEnum);
            }

            //сложности которые уже есть
            List<SlozEnum> _existsSlozs = row.OrderRowSlozs
                .Where(x => x.SlozType != null)
                .Select(x => x.SlozType)
                .Select(x => x.Enumerator).ToList();
            IRepository<SlozType> _repo = DataHelper.GetRepository<SlozType>();

            foreach (SlozEnum existsSloz in _existsSlozs)
            {
                if (existsSloz == SlozEnum.None || !_slozs.Contains(existsSloz))
                    row.RemoveSloz(existsSloz);
            }

            foreach (SlozEnum sloz in _slozs)
            {
                if (sloz != SlozEnum.None && !_existsSlozs.Exists(x => x == sloz))
                {
                    SlozType _slozType = _repo.GetItem(x => x.Enumerator == sloz);
                    row.AppendSloz(_slozType);
                }
            }
        }
    }
}