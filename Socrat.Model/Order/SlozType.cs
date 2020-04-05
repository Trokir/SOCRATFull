using Socrat.Lib;

namespace Socrat.Model
{
    public class SlozType: Entity, IShortNamedEntity
    {
        private string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set { SetField(ref _ShortName, value, () => ShortName, () => Title); }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name); }
        }


        protected override string GetTitle()
        {
            return $"Тип сложности: {ShortName}";
        }

        public override string ToString()
        {
            return $"Тип сложности: {ShortName}";
        }
    }
}