using System;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class AppParam : Entity
    {
        private string _category;
        public string Category
        {
            get { return _category; }
            set { SetField(ref _category, value, () => Category); }
        }

        private string _alias;
        public string Alias
        {
            get
            {
                return _alias;
            }
            set
            {
                _alias = value;
                if (Enum.TryParse(value, true, out ParamAlias paramAlias))
                {
                    _paramAlias = paramAlias;
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        private string _value;
        public string Value
        {
            get { return _value; }
            set { SetField(ref _value, value, () => Value); }
        }

        private ParamAlias _paramAlias;
        public ParamAlias ParamAlias
        {
            get { return _paramAlias; }
            set
            {
                _alias = value.ToString();
                SetField(ref _paramAlias, value, () => ParamAlias);
            }
        }
    }
}
