namespace Socrat.Model
{
    public class Country : Entity
    {

        private string _NameAlias;
        public string NameAlias
        {
            get { return _NameAlias; }
            set { SetField(ref _NameAlias, value, () => NameAlias, () => Title); }
        }


        private string _NameShort;
        public string NameShort
        {
            get { return _NameShort; }
            set { SetField(ref _NameShort, value, () => NameShort); }
        }


        private string _NameFull;
        public string NameFull
        {
            get { return _NameFull; }
            set { SetField(ref _NameFull, value, () => NameFull); }
        }

        protected override string GetTitle()
        {
            return "Страна: " + NameAlias;
        }
    }
    
}
