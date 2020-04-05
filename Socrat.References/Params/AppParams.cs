using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Log;

namespace Socrat.References.Params
{
    public class AppParams
    {
        private static Dictionary<ParamAlias, AppParam> _Items = new Dictionary<ParamAlias, AppParam>();

        public static List<AppParam> Items
        {
            get { return _Items.Values.ToList(); }
        }
        private static readonly List<AppParam> Deleted = new List<AppParam>();

        private static AppParams _appParams;
        public static AppParams Params
        {
            get { return GetAppParams(); }
        }

        private static AppParams GetAppParams()
        {
            if (_appParams == null)
                _appParams = new AppParams();
            return _appParams;
        }

        public string this[ParamAlias alias]
        {
            get { return GetParam(alias); }
            set { SetParam(alias, value); }
        }

        private void SetParam(ParamAlias alias, string value)
        {
            if (_Items.ContainsKey(alias))
                _Items[alias].Value = value;
            else
                _Items.Add(alias, new AppParam { ParamAlias = alias, Name = alias.ToString(), Value = value });
        }

        private string GetParam(ParamAlias alias)
        {
            if (_Items.ContainsKey(alias))
                return _Items[alias].Value;
            return string.Empty;
        }

        public void Save()
        {
            using (DataFactory _factory = new DataFactory())
            {
                IRepository<AppParam> _repo = _factory.CreateRepository<IRepository<AppParam>>();
                foreach (AppParam param in _Items.Values)
                {
                    if (param.Changed)
                        _repo.Save(param);
                }
                foreach (AppParam param in Deleted)
                {
                    _repo.Delete(param.Id);
                }
                Deleted.Clear();
            }
        }

        public void Load()
        {
            using (DataFactory _factory = new DataFactory())
            {
                IRepository<AppParam> _repo = _factory.CreateRepository<IRepository<AppParam>>();
                List<AppParam> _params = _repo.GetAll().ToList();
                for (int i = 0; i < _params.Count; i++)
                {
                    _Items.Add(_params[i].ParamAlias, _params[i]);
                }
            }
        }

        public void Revert()
        {
            using (DataFactory _factory = new DataFactory())
            {
                Deleted.Clear();
                IRepository<AppParam> _repo = _factory.CreateRepository<IRepository<AppParam>>();
                foreach (AppParam param in _Items.Values)
                {
                    if (param.Changed)
                        _repo.Revert(param);
                }
            }
        }

        public bool Changed
        {
            get { return _Items.Values.Count(x => x.Changed) > 0; }
        }

        public void AddNew()
        {
            _Items.Add(ParamAlias.NewParameter,
                new AppParam { ParamAlias = ParamAlias.NewParameter, Name = "Новый параметр", Value = "Значение параметра" });
        }

        public object GetItems()
        {
            return _Items.Values.ToList();
        }

        public long UseNextOrderNum()
        {
            long _id = -1;
            try
            {

                if (long.TryParse(this[ParamAlias.OrderNumber], out _id))
                {
                    _id++;
                    this[ParamAlias.OrderNumber] = _id.ToString();
                    Save();
                }
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx("Ошибка вычисления номера заказа", e);
            }
            return _id;
        }

        public void ResetOrderCounter()
        {
            try
            {
                this[ParamAlias.OrderNumber] = (0).ToString();
                this[ParamAlias.OrderCounterYear] = DateTime.Now.ToString("yyyy");
                Save();
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx("Ошибка вычисления номера заказа", e);
            }
        }
    }
}