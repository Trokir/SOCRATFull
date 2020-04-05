using System;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Log;
using Socrat.References.Params;

namespace Socrat.Module.Order
{
    /// <summary>
    /// Генератор номера счетов
    /// </summary>
    public class InvoiceNumerator
    {
        public static string GetNext()
        {
            string _number = string.Empty;

            CheckOrderNumCounterActuality();

            _number = GenerateNumber();

            while (!IsUniqueness(_number))
            {
                Logger.AddWarning($"Счетчик номеров счетов выдал повторяющийся номер {_number}");
                _number = GenerateNumber();
            }

            return _number;
        }

        private static string GenerateNumber()
        {
            string _number = string.Empty;

            long _num = AppParams.Params.UseNextOrderNum();
            Guid _id;
            Guid.TryParse(AppParams.Params[ParamAlias.CurrentDivision], out _id);
            Division _division = DataHelper.GetItem<Division>(_id);

            string _numStr = _num.ToString();
            while (_numStr.Length < 8)
            {
                _numStr = "0" + _numStr;
            }

            _number = $"{_division.Number}-{DateTime.Now.ToString("yyMMdd")}/{_numStr}";

            return _number;
        }

        private static void CheckOrderNumCounterActuality()
        {
            string _currentYear = String.Empty;
            _currentYear = AppParams.Params[ParamAlias.OrderCounterYear];
            int _cyear = 0;
            int.TryParse(_currentYear, out _cyear);
            if (_cyear != DateTime.Now.Year)
            {
                AppParams.Params.ResetOrderCounter();
            }
        }

        private static bool IsUniqueness(string num)
        {
            bool res = true;
            using (Socrat.Core.IRepository<Core.Entities.Order> _repo = DataHelper.GetRepository<Core.Entities.Order>())
            {
                res = !_repo.Any(x => x.Num == num);
            }
            return res;
        }
    }
}